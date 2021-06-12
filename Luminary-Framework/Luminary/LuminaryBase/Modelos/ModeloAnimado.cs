using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using LuminaryFramework.LuminaryBase.Efectos;
using LuminaryFramework.LuminaryBase.Materiales;
using LuminaryFramework.LuminaryBase.Camaras;
using LuminaryFramework.LuminaryBase.Luces;

using XNAnimation;
using XNAnimation.Controllers;
using XNAnimation.Effects;

namespace LuminaryFramework.LuminaryBase.Modelos
{
    public class ModeloAnimado{

        private static Arcane.Xna.Presentation.Game Game;

        AnimatedModelEffect animatedModelEffect;

        public SkinnedModel skinnedModel;
        public AnimationController animationController;

        // Administradores
        AdministradorCamara administradorCamara;
        AdministradorLuz administradorLuz;

        MaterialLuz materialLuz;

        private bool inicializado;

        public ModeloAnimado(Arcane.Xna.Presentation.Game game)
        {
            Game = game;
            inicializado = false;
        }

        public void Initialize()
        {
            administradorCamara = Game.Services.GetService(typeof(AdministradorCamara)) as AdministradorCamara;
            administradorLuz = Game.Services.GetService(typeof(AdministradorLuz)) as AdministradorLuz;

            if (administradorLuz == null || administradorCamara == null)
                throw new InvalidOperationException();

            inicializado = true;
        }

        public void Cargar(String nombreArhivoModelo)
        {
            if (!inicializado)
                Initialize();
            // Cargar el skinned model
            skinnedModel = Game.Content.Load<SkinnedModel>(nombreArhivoModelo);
            //transformacionHuesosFinal = new Matrix[skinnedModel.SkeletonBones.Count];

            // Crear el controlador de animacion y comenzar el clip
            animationController = new AnimationController(skinnedModel.SkeletonBones);
            animationController.StartClip(skinnedModel.AnimationClips["Idle"]);
            animationController.LoopEnabled = false;

            animatedModelEffect = new AnimatedModelEffect(skinnedModel.Model.Meshes[0].Effects[0]);

            materialLuz=new MaterialLuz();
        }

        public void Update(GameTime time)
        {
            // Interpolacion Cubica
            animationController.TranslationInterpolation = InterpolationMode.Cubic;
            animationController.OrientationInterpolation = InterpolationMode.Linear;
            animationController.ScaleInterpolation = InterpolationMode.Cubic;

            animationController.Update(time.ElapsedGameTime, Matrix.Identity);
        }

        public void Draw(GameTime gameTime)
        {
            foreach (ModelMesh modelMesh in skinnedModel.Model.Meshes)
            {
                //Console.WriteLine("RENDERIZANDO " + modelMesh.Name);
                //if(!modelMesh.Name.Equals("mesh_Cabellera"))
                foreach (ModelMeshPart meshPart in modelMesh.MeshParts)
                {
                    SkinnedModelBasicEffect basicEffect = (SkinnedModelBasicEffect)meshPart.Effect;

                    AsignarEfectosMaterial(basicEffect);


                    //basicEffect.World = Matrix.CreateRotationY(rotacion);
                    basicEffect.Bones = animationController.SkinnedBoneTransforms;
                    ////ANTERIOR
                    //basicEffect.View = vistaCamara;
                    //basicEffect.Projection = proyeccionCamara;
                    ////FIN ANTERIOR

                    basicEffect.View = administradorCamara.CamaraActiva.Vista;
                    basicEffect.Projection = administradorCamara.CamaraActiva.Proyeccion;

                    // OPTIONAL - Configure material
                    //basicEffect.Material.DiffuseColor = new Vector3(1f);
                    //basicEffect.Material.SpecularColor = new Vector3(0.3f);
                    //basicEffect.Material.SpecularPower = 8;

                    //basicEffect.NormalMapEnabled = activarTexturaNormal;

                    //basicEffect.SpecularMapEnabled = activarTexturaEspecular;
                    //basicEffect.SpecularMap = texturaSpecular;
                    //if (activarTexturaEspecular)
                        //basicEffect.Material.SpecularColor = new Vector3(1.0f);

                    /*basicEffect.AmbientLightColor = new Vector3(0.1f);
                    basicEffect.LightEnabled = true;
                    basicEffect.EnabledLights = EnabledLights.One;
                    basicEffect.PointLights[0].Color = Vector3.One;
                    basicEffect.PointLights[0].Position = new Vector3(100, 100, 100);*/
                }

                modelMesh.Draw();
            }
        }

        private void AsignarEfectosMaterial(SkinnedModelBasicEffect efecto)
        {
            // Get the first two lights from the light manager
            LuzPunto light0 = LuzPunto.NoLight;
            LuzPunto light1 = LuzPunto.NoLight;
            if (administradorLuz.Conteo > 0){
                light0 = administradorLuz[0] as LuzPunto;
                if (administradorLuz.Conteo > 1){
                    light1 = administradorLuz[1] as LuzPunto;
                }
            }

            // CONFIGURACION LUCES MIAS
            
            efecto.AmbientLightColor = administradorLuz.ColorLuzAmbiente;
            efecto.PointLights[0].Position = light0.Posicion;
            efecto.PointLights[0].Color = light0.Color;
            efecto.PointLights[1].Position = light1.Posicion;
            efecto.PointLights[1].Color = light1.Color;

            efecto.LightEnabled = true;
            efecto.EnabledLights = EnabledLights.Two;

            //animatedModelEffect.AmbientLightColor = administradorLuz.ColorLuzAmbiente;
            //animatedModelEffect.Light1Position = light0.Posicion;
            //animatedModelEffect.Light1Color = light0.Color;
            //animatedModelEffect.Light2Position = light1.Posicion;
            //animatedModelEffect.Light2Color = light1.Color;

            // CONFIGURACIONES MATERIALES MIOS
            efecto.Material.DiffuseColor = materialLuz.ColorDifuso;
            efecto.Material.SpecularColor = materialLuz.ColorEspecular;
            efecto.Material.SpecularPower = materialLuz.PoderEspecular;


            // Configure material
            //animatedModelEffect.DiffuseColor = lightMaterial.DiffuseColor;
            //animatedModelEffect.SpecularColor = lightMaterial.SpecularColor;
            //animatedModelEffect.SpecularPower = lightMaterial.SpecularPower;

            // Camera and world transformations
            //animatedModelEffect.World = transformation.Matrix;
            //animatedModelEffect.View = cameraManager.ActiveCamera.View;
            //animatedModelEffect.Projection = cameraManager.ActiveCamera.Projection;
            //animatedModelEffect.Bones = bonesAnimation;
        }
         
    }
 
}

