using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aprendiendo.luminary.comun
{
    public class Frase
    {
        private Palabra[] _palabras;
        public Palabra[] palabras {
            get {
                return _palabras;
            }
        }

        private String _frase;

        public Frase(String fraseNueva) {
            this._frase = fraseNueva;
            descomponerFrase();
        }

        private void descomponerFrase(){
            char[] parm = new char[1];
            parm[0] = ' ';

            String[] pedazos = _frase.Split(parm);
            _palabras = new Palabra[pedazos.Length];
            for (int i = 0; i < pedazos.Length; i++) {
                _palabras[i] = new Palabra(pedazos[i]);
                Console.WriteLine("SPLITEADO " + _palabras[i].palabra);
            }
        }
    }
}
