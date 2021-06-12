//#define USE_ARTAG
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using GoblinXNA;
using GoblinXNA.Graphics;
using GoblinXNA.SceneGraph;
using Model = GoblinXNA.Graphics.Model;
using GoblinXNA.Graphics.Geometry;
using GoblinXNA.Device.Capture;
using GoblinXNA.Device.Vision;
using GoblinXNA.Device.Vision.Marker;
using GoblinXNA.Device.Util;
using GoblinXNA.Physics;
using GoblinXNA.Physics.Newton1;
using GoblinXNA.Helpers;

using Luminary_Chat_AR.animatedModel;
using Luminary_Chat_AR.comunicacion;

namespace Luminary_Chat_AR
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class LuminaryChatAR : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Scene escena;

        MarkerNode aliciaMarkerNode;

        AnimatedModel modelAlicia;
        TransformNode transformNodeAlicia;

        Administrador administradorComunicacion;

        // EL listado de las animaciones que debe listar en secuencia
        public List<String> _listaAnimacionesLetras;

        public LuminaryChatAR()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _listaAnimacionesLetras = new List<string>();
            //_listaAnimacionesLetras.Add("hola");
            //_listaAnimacionesLetras.Add("como");
            //_listaAnimacionesLetras.Add("estas");
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            State.InitGoblin(graphics, Content, "");
            // Inicializar el grafo de la escena
            escena = new Scene(this);
            
            // For some reason, it causes memory conflict when it attempts to update the
            // marker transformation in the multi-threaded code, so if you're using ARTag
            // then you should not enable the marker tracking thread
#if !USE_ARTAG
            State.ThreadOption = (ushort)ThreadOptions.MarkerTracking;
#endif
            // Inicializar el marcker tracke en la escena
            SetupMarkerTrackerAlicia();

            // Inicializar iluminacion
            CrearIluminacion();

            // Crear los objetos de la escena
            CrearObjetos();

            // Crear el piso de la escena
            CrearPiso();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        int cont = 0;
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();
            //modelAlicia.LoadAnimationClip("anim2");
            
            //Console.WriteLine("REPRODUCIENDO TIEMPO " + modelAlicia.AnimationPlayer.CurrentTime.Milliseconds);
            if (cont == 640) { 
                cont = 0;
                //modelAlicia.LoadAnimationClip("hola");
            }
            else cont++;

            if (aliciaMarkerNode.MarkerFound) {// Solo si el marquer es encontrado realiza la animacion
                modelAlicia.Update(gameTime);
                Console.WriteLine("ESTADO ALICIA PARADA : " + modelAlicia.reproduciendo + " FALTAN : " + _listaAnimacionesLetras.Count);
                if (!modelAlicia.reproduciendo) {
                    Console.WriteLine("PARO");
                    if (_listaAnimacionesLetras != null && _listaAnimacionesLetras.Count > 0) {
                        modelAlicia.LoadAnimationClip(_listaAnimacionesLetras.ElementAt(0));
                        _listaAnimacionesLetras.RemoveAt(0);
                    }
                }
            }
            
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        #region Creacion de la escena
        private void SetupMarkerTrackerAlicia() {
            DirectShowCapture dispositivoCaptura = new DirectShowCapture();
            dispositivoCaptura.InitVideoCapture(0, FrameRate._30Hz, Resolution._800x600, 
                ImageFormat.R8G8B8_24, false);

            // Agregar el dispositivo de captura de video a la escena
            escena.AddVideoCaptureDevice(dispositivoCaptura);

            IMarkerTracker tracker = null;
#if USE_ARTAG
            // Create an optical marker tracker that uses ARTag library
            tracker = new ARTagTracker();
            // Set the configuration file to look for the marker specifications
            tracker.InitTracker(638.052f, 633.673f, captureDevice.Width,
                captureDevice.Height, false, "ARTag.cf");
#else
            // Create an optical marker tracker that uses ALVAR library
            tracker = new ALVARMarkerTracker();
            ((ALVARMarkerTracker)tracker).MaxMarkerError = 0.02f;
            tracker.InitTracker(dispositivoCaptura.Width, dispositivoCaptura.Height, "calib.xml", 9.0);
#endif
            // Agregar el MarkerTracker a la escena
            escena.MarkerTracker = tracker;

            // Mostrar la imagen de la camara en la escena
            escena.ShowCameraImage = true;
        }

        public void CrearIluminacion() {
            // Create a directional light source
            LightSource lightSource = new LightSource();
            lightSource.Direction = new Vector3(-1, -1, -1);
            lightSource.Diffuse = Color.White.ToVector4();

            LightSource lightSource2 = new LightSource();
            lightSource2.Direction = new Vector3(1, 0, 0);
            lightSource2.Diffuse = Color.White.ToVector4();

            LightSource lightSource3 = new LightSource();
            lightSource3.Direction = new Vector3(-0.5f, 0, 1);
            lightSource3.Diffuse = new Vector4(0.5f, 0.5f, 0.5f, 1);

            // Create a light node to hold the light source
            LightNode lightNode1 = new LightNode();
            lightNode1.LightSource = lightSource;

            LightNode lightNode2 = new LightNode();
            lightNode2.LightSource = lightSource2;

            LightNode lightNode3 = new LightNode();
            lightNode3.LightSource = lightSource3;

            escena.RootNode.AddChild(lightNode1);
            escena.RootNode.AddChild(lightNode2);
            escena.RootNode.AddChild(lightNode3);
        }

        public void CrearObjetos() {
            LoadModel();


        }

        private void LoadModel() {
            AnimatedModelLoader loader = new AnimatedModelLoader();
            modelAlicia = (AnimatedModel)loader.Load("", "Alicia");
            modelAlicia.UseInternalMaterials = true;

            modelAlicia.ShaderTechnique = "SkinnedModelTechnique";

            GeometryNode nodoModelo = new GeometryNode("Alicia");
            nodoModelo.Model = modelAlicia;

            modelAlicia.LoadAnimationClip("como");

            transformNodeAlicia = new TransformNode();
            transformNodeAlicia.Translation = new Vector3(20, 0, 37);
            transformNodeAlicia.Rotation = Quaternion.CreateFromAxisAngle(Vector3.Right, MathHelper.ToRadians(180));
            transformNodeAlicia.Scale = new Vector3(2.3f, 2.3f, 2.3f);

            //escena.RootNode.AddChild(transformNodeAlicia);
            transformNodeAlicia.AddChild(nodoModelo);

            // Create a marker node to track a ground marker array.
#if USE_ARTAG
            aliciaMarkerNode = new MarkerNode(scene.MarkerTracker, "ground");

            // Since we expect that the ground marker array won't move very much, we use a 
            // small smoothing alpha.
            //groundMarkerNode.Smoother = new DESSmoother(0.2f, 0.1f, 1, 1);
#else
            aliciaMarkerNode = new MarkerNode(escena.MarkerTracker, "Toolbar.txt");
#endif

            escena.RootNode.AddChild(aliciaMarkerNode);
            aliciaMarkerNode.AddChild(transformNodeAlicia);



            // detected, it will be overlaid on top of the toolbar marker array.)
            GeometryNode boxNode = new GeometryNode("Box");
            boxNode.Model = new Sphere(2, 8, 8);
            // Make this box model cast and receive shadows
            boxNode.Model.CastShadows = true;
            boxNode.Model.ReceiveShadows = true;

            //aliciaMarkerNode.AddChild(boxNode);
        }

        private void CrearPiso() {
            GeometryNode groundNode = new GeometryNode("Ground");

#if USE_ARTAG
            groundNode.Model = new Box(85, 66, 0.1f);
#else
            groundNode.Model = new Box(200, 200, 0.1f);
#endif
            // Set this ground model to act as an occluder so that it appears transparent
            groundNode.IsOccluder = true;
            groundNode.Physics.Collidable = true;
            groundNode.Physics.Pickable = true;
            groundNode.AddToPhysicsEngine = true;

            // Make the ground model to receive shadow casted by other objects with
            // CastShadows set to true
            groundNode.Model.ReceiveShadows = true;

            Material groundMaterial = new Material();
            groundMaterial.Diffuse = Color.Gray.ToVector4();
            groundMaterial.Specular = Color.White.ToVector4();
            groundMaterial.SpecularPower = 20;

            groundNode.Material = groundMaterial;

            aliciaMarkerNode.AddChild(groundNode);
        }
        #endregion 
    }
}
