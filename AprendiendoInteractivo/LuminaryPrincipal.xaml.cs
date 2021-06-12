using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using Aprendiendo.luminary;

namespace Aprendiendo
{
	public partial class LuminaryPrincipal
	{
        Dictionary<String, int> letrasNumeros;
        Vocabulario vocabulario;
        List<int> letrasNumerosBuffer;
		public LuminaryPrincipal()
		{
			this.InitializeComponent();
            vocabulario = new Vocabulario();
            iniciarHashLetrasNumeros();
            letrasNumerosBuffer = new List<int>();
            controles3D.DataContext = modelo3D;
            controlVocabulario.DataContext = vocabulario;
            controlVocabulario.DataContext = vocabulario;

            vocabulario.CambioLetra += new CambioLetraEventHandler(CambioLaLetra);
		}

        private void traducir_Click(object sender, RoutedEventArgs e) {
            vocabulario.textoFrase = controlVocabulario.txtIngresar.Text;
            vocabulario.traducir();

            List<int> numerosAnimaciones = new List<int>();
            foreach (String letra in vocabulario.senalesLetraRutas) {
                int numeroAnimacion;
                letrasNumeros.TryGetValue(letra, out numeroAnimacion);
                numerosAnimaciones.Add(numeroAnimacion);
                Console.WriteLine("CONSTRUYENDO LISTA DE NUMEROS DE ANIMACIONS AGREGADO:" + numeroAnimacion);
            }

            modelo3D._listaAnimacionesLetras = numerosAnimaciones;
            //modelo3D.animacionLetraActual = numeroAnimacion;
            
        }

        private void CambioLaLetra(object sender, EventArgs e)
        {
            Console.WriteLine("AHORA CAMBIO LA LETRA PERO SE LE NOTIFICO AL PRINCIPAL IMAGEREF:" + ((Vocabulario)sender).imageRef + " CARACTER:" + ((Vocabulario)sender).caracterActual);
            //int numeroAnimacion;
            //letrasNumeros.TryGetValue(((Vocabulario)sender).caracterActual,out numeroAnimacion);
            //Console.WriteLine("AHORA CAMBIO LA LETRA PERO SE LE NOTIFICO AL PRINCIPAL ANIMACION NUM:" + numeroAnimacion);
            //modelo3D.animacionLetraActual = numeroAnimacion;
        }

        private void iniciarHashLetrasNumeros() {
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
	}
}