using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Recognition;

namespace Aprendiendo.luminary.voz
{
    public class Reconocimiento
    {
        private SpeechRecognizer speechReco = new SpeechRecognizer();
        private List<string> gramatica = new List<string>();

        public Reconocimiento() {
            this.gramatica.Add("espacio");
            this.gramatica.Add("a");
            this.gramatica.Add("b");
            this.gramatica.Add("c");
            this.gramatica.Add("d");
            this.gramatica.Add("e");
            this.gramatica.Add("f");
            this.gramatica.Add("g");
            this.gramatica.Add("h");
            this.gramatica.Add("i");
            this.gramatica.Add("j");
            this.gramatica.Add("k");
            this.gramatica.Add("l");
            this.gramatica.Add("m");
            this.gramatica.Add("enie");
            this.gramatica.Add("o");
            this.gramatica.Add("p");
            this.gramatica.Add("q");
            this.gramatica.Add("r");
            this.gramatica.Add("s");
            this.gramatica.Add("t");
            this.gramatica.Add("u");
            this.gramatica.Add("v");
            this.gramatica.Add("w");
            this.gramatica.Add("x");
            this.gramatica.Add("y");
            this.gramatica.Add("z");

            Choices misChoices = new Choices(this.gramatica.ToArray());
            GrammarBuilder builder = new GrammarBuilder(misChoices);
            Grammar gramatica = new Grammar(builder);

            speechReco.LoadGrammar(gramatica);
            speechReco.Enabled = true;

            speechReco.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(palabraReconocida);
        }

        private void palabraReconocida(object sender, SpeechRecognizedEventArgs e) {
            Console.WriteLine("RECONOCI ESTO JEJE " + e.Result.Text);
        }
    }
}
