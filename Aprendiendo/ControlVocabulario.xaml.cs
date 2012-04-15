using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Aprendiendo.luminary;
using Aprendiendo.controles.teclado;
using Aprendiendo.luminary.voz;

namespace Aprendiendo
{
    /// <summary>
    /// Interaction logic for ControlVocabulario.xaml
    /// </summary>
    public partial class ControlVocabulario : UserControl
    {
        private Dictionary<String, int> letrasNumeros;
        private Vocabulario vocabulario;
        private List<int> letrasNumerosBuffer;

        //Reconocimiento reco;
        public ControlVocabulario()
        {
            InitializeComponent();
            vocabulario = new Vocabulario();
            iniciarHashLetrasNumeros();
            letrasNumerosBuffer = new List<int>();
            controles3D.DataContext = modelo3D;
            this.DataContext = vocabulario;

            //reco = new Reconocimiento();
        }

        private void btnTraducir_Click(object sender, RoutedEventArgs e)
        {
            vocabulario.textoFrase = txtIngresar.Text;
            vocabulario.traducir();

            List<int> numerosAnimaciones = new List<int>();
            foreach (String letra in vocabulario.senalesLetraRutas)
            {
                int numeroAnimacion;
                letrasNumeros.TryGetValue(letra, out numeroAnimacion);
                numerosAnimaciones.Add(numeroAnimacion);
                Console.WriteLine("CONSTRUYENDO LISTA DE NUMEROS DE ANIMACIONS AGREGADO: {0} = {1}", numeroAnimacion, letra);
            }

            modelo3D._listaAnimacionesLetras = numerosAnimaciones;
        }

        private void btnTeclado_Click(object sender, RoutedEventArgs e)
        {
            String nuevoTexto = txtIngresar.Text + ((Teclado)sender).letraActualOprimida;
            txtIngresar.Text = nuevoTexto;
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

            //letrasNumeros.Add("saludo", 28);
            //letrasNumeros.Add("amigo", 29);
            //letrasNumeros.Add("recuerda", 30);
            //letrasNumeros.Add("aprender", 31);

            letrasNumeros.Add("hola", 28);
            letrasNumeros.Add("como", 29);
            letrasNumeros.Add("estas", 30);
            letrasNumeros.Add("yo", 31);
            letrasNumeros.Add("estoy", 32);
            letrasNumeros.Add("bien", 33);
        }
    }
}
