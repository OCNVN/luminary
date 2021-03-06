using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprendiendo.luminary.comun
{
    public class Palabra
    {
        private Letra[] _letras;
        /// <summary>
        /// Almacena las letras que conforman la palabra
        /// </summary>
        public Letra[] letras {
            get {
                return _letras;
            }
        }

        private String _palabra;
        /// <summary>
        /// Almacena la palabra completa en un string
        /// </summary>
        public String palabra {
            get {
                return _palabra;
            }
        }

        public Palabra(String palabraNueva) {
            this._palabra = palabraNueva;
            descomponerPalabra();
        }

        /// <summary>
        /// Descompone la palabra y cada Letra la almacena en el array letras
        /// </summary>
        private void descomponerPalabra() {
            _letras = new Letra[_palabra.Length];
            char[] aux = _palabra.ToCharArray();

            for (int i = 0; i < _palabra.Length; i++) {
                _letras[i] = new Letra();
                _letras[i].caracter = aux[i] + "";
            }
        }
    }
}
