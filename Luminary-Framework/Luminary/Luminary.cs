using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

using XNAnimation;
using XNAnimation.Controllers;
using XNAnimation.Effects;

using LuminaryFramework.LuminaryBase.Luces;
using LuminaryFramework.LuminaryBase.Camaras;
using LuminaryFramework.LuminaryBase.Modelos;

namespace LuminaryFramework
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Luminary : Arcane.Xna.Presentation.Game, INotifyPropertyChanged
    {
        Arcane.Xna.Presentation.GraphicsDeviceManager graphics;

        // Texto interfaz
        private SpriteBatch spriteBatch;
        private SpriteFont spriteFont;
        private SpriteFont spriteFontBig;

        // Modelo
        private string modeloFilename = "Modelos/Alicia";

        private AdministradorLuz administradorLuz;
        private AdministradorCamara administradorCamara;

        private float _cameraArc = 0;
        public float cameraArc {
            get { return _cameraArc; }
            set {
                _cameraArc = value;
                OnPropertyChanged("cameraArc");
            }

        }

        private float _cameraRotation = 0;
        public float cameraRotation {
            get { return _cameraRotation; }
            set {
                _cameraRotation = value;
                OnPropertyChanged("cameraRotation");
            }
        }

        private float _cameraDistance = 50;
        public float cameraDistance {
            get { return _cameraDistance; }
            set {
                _cameraDistance = value;
                OnPropertyChanged("cameraDistance");
            }
        }

        private float _velocidadAnimacion = 1;
        public float velocidadAnimacion {
            get { return _velocidadAnimacion; }
            set {
                _velocidadAnimacion = value;
                OnPropertyChanged("velocidadAnimacion");
            }
        }

        private ModeloAnimado modeloAnimado;

        public List<int> _listaAnimacionesLetras;

        public Luminary()
        {
            if (!(System.ComponentModel.DesignerProperties.GetIsInDesignMode(this)))
            {
                graphics = new Arcane.Xna.Presentation.GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
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
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Console.WriteLine("Cargando juego");
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteFont = Content.Load<SpriteFont>("Fuentes/Arial");
            spriteFontBig = Content.Load<SpriteFont>("Fuentes/Calibri");

            // Administrador de camaras
            administradorCamara = new AdministradorCamara();
            //object servicioCamara = Services.GetService(typeof(AdministradorCamara));
            //if (servicioCamara == null)
            Services.RemoveService(typeof(AdministradorCamara));
            Services.AddService(typeof(AdministradorCamara), administradorCamara);

            // Camara 1
            CamaraAlrededor camara1 = new CamaraAlrededor();
            administradorCamara.Add("Camara1", camara1);

            // Administrador de luces
            administradorLuz = new AdministradorLuz();
            administradorLuz.ColorLuzAmbiente = new Vector3(0.2f, 0.2f, 0.2f);
            //object servicioLuz = Services.GetService(typeof(AdministradorLuz));
            //if (servicioLuz == null)
            Services.RemoveService(typeof(AdministradorLuz));
            Services.AddService(typeof(AdministradorLuz), administradorLuz);

            // Luz 0
            administradorLuz.Add("Luz0", new LuzPunto(new Vector3(0, 500f, 1000f), Vector3.One));
            // Luz 1
            administradorLuz.Add("Luz1", new LuzPunto(new Vector3(0, 500f, -1000f), Vector3.One));

            _listaAnimacionesLetras = new List<int>();


            // Modelo animado
            Console.WriteLine("Cargando modelo");
            modeloAnimado = new ModeloAnimado(this);
            modeloAnimado.Cargar(modeloFilename);
            Console.WriteLine("Ya Cargo modelo");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            Console.WriteLine("Descargando contenido mira ve ");
            graphics.GraphicsDevice.Dispose();
            base.UnloadContent();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        int cont = 0;
        protected override void Update(GameTime gameTime)
        {
            administradorCamara.SetCamaraActiva(0);
            modeloAnimado.Update(gameTime);

            //UpdateCamera(gameTime);

            if(!modeloAnimado.animationController.IsPlaying && _listaAnimacionesLetras != null && _listaAnimacionesLetras.Count != 0){
                int numeroDeAnimacion = _listaAnimacionesLetras.ElementAt(0);
                modeloAnimado.animationController.CrossFade(modeloAnimado.skinnedModel.AnimationClips.Values[numeroDeAnimacion], TimeSpan.FromSeconds(0.3f));
                if (cont == 1)
                {
                    _listaAnimacionesLetras.RemoveAt(0);
                    cont = 0;
                }
                else
                    cont++;
                if(_listaAnimacionesLetras.Count > 0)
                    Console.WriteLine("QUEDAN TODAVIA " + _listaAnimacionesLetras.Count + " ANIMACIONES LA SIGUIENTE ES " + _listaAnimacionesLetras.ElementAt(0));
            }
            

            //////////////////// SOLO PRUEBAS PARA ANIMACIONS
             //_listaAnimacionesLetras.ElementAt(0)
            //estaCorriendoAnimacion = animationController.HasFinished;
            //if (animacionLetraActual != -1) {
            //    if (animationController.HasFinished){
            //        animationController.CrossFade(skinnedModel.AnimationClips.Values[animacionLetraActual],
            //            TimeSpan.FromSeconds(0.3f));
            //    }
            //    else {
            //        animacionLetraActual = -1;
            //    }
            //}

            /*if (keyboardState.IsKeyDown(Keys.Escape))
                Exit();

            if (keyboardState.IsKeyDown(Keys.A) &&
                ultimoKeyoardState.IsKeyUp(Keys.A))
            {
                clipAnimacionActiva = (clipAnimacionActiva - 1);
                if (clipAnimacionActiva < 0)
                    clipAnimacionActiva = skinnedModel.AnimationClips.Count - 1;

                // Change the current animation clip
                //animationController.StartClip(skinnedModel.AnimationClips.Values[activeAnimationClip]);
                animationController.CrossFade(skinnedModel.AnimationClips.Values[clipAnimacionActiva],
                    TimeSpan.FromSeconds(0.3f));
            }
            else if (keyboardState.IsKeyDown(Keys.D) &&
                ultimoKeyoardState.IsKeyUp(Keys.D))
            {
                clipAnimacionActiva = (clipAnimacionActiva + 1) % skinnedModel.AnimationClips.Count;

                // Change the current animation clip
                //animationController.StartClip(skinnedModel.AnimationClips.Values[activeAnimationClip]);
                animationController.CrossFade(
                    skinnedModel.AnimationClips.Values[clipAnimacionActiva],
                    TimeSpan.FromSeconds(0.3f));
            }*/

            // Velocidad de animacion
            modeloAnimado.animationController.Speed = velocidadAnimacion;
            
            
            base.Update(gameTime);
        }

        
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice device = graphics.GraphicsDevice;
            device.Clear(Color.White);

            float aspectRatio = (float)device.Viewport.Width /
                                (float)device.Viewport.Height;

            CamaraAlrededor camara1 = administradorCamara.CamaraActiva as CamaraAlrededor;
            camara1.AspectoRadio = aspectRatio;
            camara1.SetVista(cameraRotation, cameraArc, cameraDistance);
            GraphicsDevice.RenderState.DepthBufferEnable = true;

            modeloAnimado.Draw(gameTime);
            
            base.Draw(gameTime);
        }

        #region Notificacion de cambio de propiedades para data binding
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propiedadNombre)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedadNombre));
            }
        }
        #endregion
    }


    #region Conversores para ligarlos con los controles Sliders
    /// <summary>
    /// Esta clase se encarga de convertir un valor del rango de 0-10 a un rango de 0 
    /// hasta el limite establecido en la propiedad 'angulo', la camara solo puede rotar
    /// hasta un angulo 'angulo'
    /// </summary>
    public class LuminaryArcoCamaraConverter : System.Windows.Data.IValueConverter
    {
        private float angulo = 180;

        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                float valor = System.Convert.ToSingle(value);
                valor = valor / (angulo / 5);
                valor = valor + 5;
                if (valor > 10) valor = 10;
                if (valor < 0) valor = 0;
                return valor;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                float valor = System.Convert.ToSingle(value);
                valor = valor - 5;
                valor = valor * (angulo / 5);
                if (valor > angulo) valor = angulo;
                if (valor < -angulo) valor = -angulo;
                return valor;
            }
            return null;
        }
    }
    /// <summary>
    /// Esta clase convierte el valor del slider 0-10 a un rango desde cero hasta
    /// la distancia determinada por la variable del mismo nombre, la camara solo
    /// puede alejarse hasta una distancia 'distancia' maxima
    /// </summary>
    public class LuminaryDistanciaCamaraConverter : System.Windows.Data.IValueConverter
    {
        private float distancia = 50;

        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                float valor = System.Convert.ToSingle(value);
                valor = valor / (distancia / 10);
                if (valor > 10) valor = 10;
                if (valor < 0) valor = 0;
                return valor;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                float valor = System.Convert.ToSingle(value);
                valor = valor * (distancia / 10);
                if (valor > distancia) valor = distancia;
                return valor;
            }
            return null;
        }
    }

    public class LuminaryVelocidadAnimacionConverter : System.Windows.Data.IValueConverter
    {
        // Define la velocidad normal de reproduccion, esta se puede escalar hasta un factor
        private float velocidad = 1;
        private float factor = 2;

        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                float valor = System.Convert.ToSingle(value);
                valor = valor / ( (velocidad * factor) / 10);
                if (valor > 10) valor = 10;
                if (valor < 0) valor = 0;
                return valor;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                float valor = System.Convert.ToSingle(value);
                valor = valor * ((velocidad * factor) / 10);
                if (valor > (velocidad * factor)) valor = (velocidad * factor);
                return valor;
            }
            return null;
        }
    }
    #endregion
}
