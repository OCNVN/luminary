using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Collections.Generic;

using Aprendiendo.luminary;
using Aprendiendo.controles.teclado;

namespace Aprendiendo
{
    public partial class ControlAdivina : INotifyPropertyChanged
	{
        Dictionary<String, int> letrasNumeros;
        List<String> letrasNumerosAdivina;

        Dictionary<String, List<String>> categorias;

        private String palabraOrgiinal = "";

        private String _palabraActual = "";
        public String palabraActual
        {
            get { return _palabraActual; }
            set
            {
                _palabraActual = value;
                OnPropertyChanged("palabraActual");
            }

        }

        private String _imageRef;
        public String imageRef
        {
            get { return _imageRef; }
            set
            {
                _imageRef = value;
                OnPropertyChanged("imageRef");
            }
        }

        public String letraAAdivinar;
		public ControlAdivina()
		{
			this.InitializeComponent();

            iniciarHashLetrasNumeros();
            llenarLetrasAdivina();
            imagenAdivina.DataContext = this;
            lblAdivina.DataContext = this;
            palabraActual = "Carlitox";

            controles3D.DataContext = modelo3D;
		}

        private void btnTeclado_Click(object sender, RoutedEventArgs e)
        {
            //vocabulario.textoFrase += ((Teclado)sender).letraActualOprimida;
            if (((Teclado)sender).letraActualOprimida.Equals(letraAAdivinar))
            {
                int numeroAnimacion;
                letrasNumeros.TryGetValue(((Teclado)sender).letraActualOprimida, out numeroAnimacion);
                modelo3D._listaAnimacionesLetras.Add(numeroAnimacion);
                palabraActual = palabraOrgiinal;
            }

            //juego.enviarLetra(((Teclado)sender).letraActualOprimida);
        }

        private void iniciarHashLetrasNumeros()
        {
            letrasNumeros = new Dictionary<String, int>();
            letrasNumeros.Add("a", 1);
            letrasNumeros.Add("b", 2);
            letrasNumeros.Add("c", 3);
            letrasNumeros.Add("d", 4);
            letrasNumeros.Add("e", 5);
            letrasNumeros.Add("f", 6);
            letrasNumeros.Add("g", 7);
            letrasNumeros.Add("h", 8);
            letrasNumeros.Add("i", 9);
            letrasNumeros.Add("j", 10);
            letrasNumeros.Add("k", 11);
            letrasNumeros.Add("l", 12);
            letrasNumeros.Add("m", 13);
            letrasNumeros.Add("n", 14);
            letrasNumeros.Add("ñ", 15);
            letrasNumeros.Add("o", 16);
            letrasNumeros.Add("p", 17);
            letrasNumeros.Add("q", 18);
            letrasNumeros.Add("r", 19);
            letrasNumeros.Add("s", 20);
            letrasNumeros.Add("t", 21);
            letrasNumeros.Add("u", 22);
            letrasNumeros.Add("v", 23);
            letrasNumeros.Add("w", 24);
            letrasNumeros.Add("x", 25);
            letrasNumeros.Add("y", 26);
            letrasNumeros.Add("z", 27);

            letrasNumeros.Add("A", 1);
            letrasNumeros.Add("B", 2);
            letrasNumeros.Add("C", 3);
            letrasNumeros.Add("D", 4);
            letrasNumeros.Add("E", 5);
            letrasNumeros.Add("F", 6);
            letrasNumeros.Add("G", 7);
            letrasNumeros.Add("H", 8);
            letrasNumeros.Add("I", 9);
            letrasNumeros.Add("J", 10);
            letrasNumeros.Add("K", 11);
            letrasNumeros.Add("L", 12);
            letrasNumeros.Add("M", 13);
            letrasNumeros.Add("N", 14);
            letrasNumeros.Add("Ñ", 15);
            letrasNumeros.Add("O", 16);
            letrasNumeros.Add("P", 17);
            letrasNumeros.Add("Q", 18);
            letrasNumeros.Add("R", 19);
            letrasNumeros.Add("S", 20);
            letrasNumeros.Add("T", 21);
            letrasNumeros.Add("U", 22);
            letrasNumeros.Add("V", 23);
            letrasNumeros.Add("W", 24);
            letrasNumeros.Add("X", 25);
            letrasNumeros.Add("Y", 26);
            letrasNumeros.Add("Z", 27);
        }

        private void llenarLetrasAdivina()
        {
            categorias = new Dictionary<string, List<string>>();

            List<String> listaFrutas = new List<string>();
            listaFrutas.Add("MANZANA");
            listaFrutas.Add("PERA");
            listaFrutas.Add("SANDIA");
            listaFrutas.Add("FRESA");
            listaFrutas.Add("COCO");
            listaFrutas.Add("MANDARINA");
            categorias.Add("Frutas", listaFrutas);

            List<String> animalesSalvajes = new List<string>();
            animalesSalvajes.Add("DELFINES");
            animalesSalvajes.Add("LEON");
            animalesSalvajes.Add("ELEFANTE");
            animalesSalvajes.Add("OSO");
            animalesSalvajes.Add("TIGRE");
            animalesSalvajes.Add("ZEBRA");
            animalesSalvajes.Add("JIRAFA");
            categorias.Add("Animales salvajes", animalesSalvajes);

            List<String> mediosTransporte = new List<string>();
            mediosTransporte.Add("AVION");
            mediosTransporte.Add("CARRO");
            categorias.Add("Medios de transporte", mediosTransporte);

            List<String> animalesDomesticos = new List<string>();
            animalesDomesticos.Add("GATO");
            animalesDomesticos.Add("BURRO");
            animalesDomesticos.Add("GALLINA");
            categorias.Add("Animales domesticos", animalesDomesticos);

            List<String> insectos = new List<string>();
            insectos.Add("MARIPOSA");
            categorias.Add("Insectos", insectos);

            letrasNumerosAdivina = new List<String>();
            letrasNumerosAdivina.Add("TELEVISOR");
            letrasNumerosAdivina.Add("ESTADIO");
            letrasNumerosAdivina.Add("LAPTOP");
        }

        private void btnNuevaPalabra_Click(object sender, RoutedEventArgs e)
        {
            generarNuevaPalabra();
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

        private void selCategoria_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine("Has seleccionado "+((Label)selCategoria.SelectedItem).Content.ToString());
            
            List<String> categoriaSeleccionada;
            categorias.TryGetValue(((Label)selCategoria.SelectedItem).Content.ToString(), out categoriaSeleccionada);
            letrasNumerosAdivina = categoriaSeleccionada;
            generarNuevaPalabra();
        }

        private void generarNuevaPalabra() {
            Random r = new Random();
            String[] tontera = letrasNumerosAdivina.ToArray();
            String palabraAAdivinar = tontera[(r.Next(tontera.Length))];
            palabraOrgiinal = palabraAAdivinar;
            imageRef = "assets/adivina/" + palabraOrgiinal + ".jpg";
            int posicionARemplazar = r.Next(palabraAAdivinar.Length - 1);
            letraAAdivinar = palabraAAdivinar.Substring(posicionARemplazar, 1);
            palabraActual = palabraAAdivinar.Remove(posicionARemplazar, 1);
            palabraActual = palabraActual.Insert(posicionARemplazar, "_");
        }
	}
}