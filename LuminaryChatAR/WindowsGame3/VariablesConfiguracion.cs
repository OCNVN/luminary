using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luminary_Chat_AR
{
    public static class VariablesConfiguracion
    {
        public static String HOST_CLIENTE = "Host cliente";
        public static String HOST_SERVIDOR = "Host servidor";

        public static Dictionary<String, int> letrasNumeros = iniciarHashLetrasNumeros();
        private static Dictionary<String, int> iniciarHashLetrasNumeros()
        {
            Dictionary<String, int> _letrasNumeros = new Dictionary<String, int>();
            _letrasNumeros.Add("a", 1);
            _letrasNumeros.Add("b", 2);
            _letrasNumeros.Add("c", 3);
            _letrasNumeros.Add("d", 4);
            _letrasNumeros.Add("e", 5);
            _letrasNumeros.Add("f", 6);
            _letrasNumeros.Add("g", 7);
            _letrasNumeros.Add("h", 8);
            _letrasNumeros.Add("i", 9);
            _letrasNumeros.Add("j", 10);
            _letrasNumeros.Add("k", 11);
            _letrasNumeros.Add("l", 12);
            _letrasNumeros.Add("m", 13);
            _letrasNumeros.Add("n", 14);
            _letrasNumeros.Add("ñ", 15);
            _letrasNumeros.Add("o", 16);
            _letrasNumeros.Add("p", 17);
            _letrasNumeros.Add("q", 18);
            _letrasNumeros.Add("r", 19);
            _letrasNumeros.Add("s", 20);
            _letrasNumeros.Add("t", 21);
            _letrasNumeros.Add("u", 22);
            _letrasNumeros.Add("v", 23);
            _letrasNumeros.Add("w", 24);
            _letrasNumeros.Add("x", 25);
            _letrasNumeros.Add("y", 26);
            _letrasNumeros.Add("z", 27);

            _letrasNumeros.Add("A", 1);
            _letrasNumeros.Add("B", 2);
            _letrasNumeros.Add("C", 3);
            _letrasNumeros.Add("D", 4);
            _letrasNumeros.Add("E", 5);
            _letrasNumeros.Add("F", 6);
            _letrasNumeros.Add("G", 7);
            _letrasNumeros.Add("H", 8);
            _letrasNumeros.Add("I", 9);
            _letrasNumeros.Add("J", 10);
            _letrasNumeros.Add("K", 11);
            _letrasNumeros.Add("L", 12);
            _letrasNumeros.Add("M", 13);
            _letrasNumeros.Add("N", 14);
            _letrasNumeros.Add("Ñ", 15);
            _letrasNumeros.Add("O", 16);
            _letrasNumeros.Add("P", 17);
            _letrasNumeros.Add("Q", 18);
            _letrasNumeros.Add("R", 19);
            _letrasNumeros.Add("S", 20);
            _letrasNumeros.Add("T", 21);
            _letrasNumeros.Add("U", 22);
            _letrasNumeros.Add("V", 23);
            _letrasNumeros.Add("W", 24);
            _letrasNumeros.Add("X", 25);
            _letrasNumeros.Add("Y", 26);
            _letrasNumeros.Add("Z", 27);

            //_letrasNumeros.Add("saludo", 28);
            //_letrasNumeros.Add("amigo", 29);
            //_letrasNumeros.Add("recuerda", 30);
            //_letrasNumeros.Add("aprender", 31);
            _letrasNumeros.Add("hola", 28);
            _letrasNumeros.Add("como", 29);
            _letrasNumeros.Add("estas", 30);
            _letrasNumeros.Add("yo", 31);
            _letrasNumeros.Add("estoy", 32);
            _letrasNumeros.Add("bien", 33);

            return _letrasNumeros;
        }
        /// <summary>
        /// INCOMPLETOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        /// </summary>
        public static Dictionary<String, int> letrasInterpreteAR = iniciarHashletrasInterpreteAR();
        private static Dictionary<String, int> iniciarHashletrasInterpreteAR()
        {
            Dictionary<String, int> _letrasNumeros = new Dictionary<String, int>();
            _letrasNumeros.Add("a", 1);
            _letrasNumeros.Add("b", 2);
            _letrasNumeros.Add("c", 3);
            _letrasNumeros.Add("d", 4);
            _letrasNumeros.Add("e", 5);
            _letrasNumeros.Add("f", 6);
            _letrasNumeros.Add("g", 7);
            _letrasNumeros.Add("h", 8);
            _letrasNumeros.Add("i", 9);
            _letrasNumeros.Add("j", 10);
            _letrasNumeros.Add("k", 11);
            _letrasNumeros.Add("l", 12);
            _letrasNumeros.Add("m", 13);
            _letrasNumeros.Add("n", 14);
            _letrasNumeros.Add("ñ", 15);
            _letrasNumeros.Add("o", 16);
            _letrasNumeros.Add("p", 17);
            _letrasNumeros.Add("q", 18);
            _letrasNumeros.Add("r", 19);
            _letrasNumeros.Add("s", 20);
            _letrasNumeros.Add("t", 21);
            _letrasNumeros.Add("u", 22);
            _letrasNumeros.Add("v", 23);
            _letrasNumeros.Add("w", 24);
            _letrasNumeros.Add("x", 25);
            _letrasNumeros.Add("y", 26);
            _letrasNumeros.Add("z", 27);

            _letrasNumeros.Add("A", 1);
            _letrasNumeros.Add("B", 2);
            _letrasNumeros.Add("C", 3);
            _letrasNumeros.Add("D", 4);
            _letrasNumeros.Add("E", 5);
            _letrasNumeros.Add("F", 6);
            _letrasNumeros.Add("G", 7);
            _letrasNumeros.Add("H", 8);
            _letrasNumeros.Add("I", 9);
            _letrasNumeros.Add("J", 10);
            _letrasNumeros.Add("K", 11);
            _letrasNumeros.Add("L", 12);
            _letrasNumeros.Add("M", 13);
            _letrasNumeros.Add("N", 14);
            _letrasNumeros.Add("Ñ", 15);
            _letrasNumeros.Add("O", 16);
            _letrasNumeros.Add("P", 17);
            _letrasNumeros.Add("Q", 18);
            _letrasNumeros.Add("R", 19);
            _letrasNumeros.Add("S", 20);
            _letrasNumeros.Add("T", 21);
            _letrasNumeros.Add("U", 22);
            _letrasNumeros.Add("V", 23);
            _letrasNumeros.Add("W", 24);
            _letrasNumeros.Add("X", 25);
            _letrasNumeros.Add("Y", 26);
            _letrasNumeros.Add("Z", 27);

            //_letrasNumeros.Add("saludo", 28);
            //_letrasNumeros.Add("amigo", 29);
            //_letrasNumeros.Add("recuerda", 30);
            //_letrasNumeros.Add("aprender", 31);
            _letrasNumeros.Add("hola", 28);
            _letrasNumeros.Add("como", 29);
            _letrasNumeros.Add("estas", 30);
            _letrasNumeros.Add("yo", 31);
            _letrasNumeros.Add("estoy", 32);
            _letrasNumeros.Add("bien", 33);

            return _letrasNumeros;
        }
    }
}
