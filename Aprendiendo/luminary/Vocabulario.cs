using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Collections;
using Aprendiendo.luminary.comun;
using System.Timers;

namespace Aprendiendo.luminary
{
    public delegate void CambioLetraEventHandler(object sender, EventArgs e);

    public class Vocabulario:INotifyPropertyChanged
    {
        private string _textoFrase;
        public string textoFrase {
            get { return _textoFrase; }
            set { 
                _textoFrase = value;
                OnPropertyChanged("textoFrase");
            }
        }

        private string _imageRef;
        public string imageRef{
            get { return _imageRef; }
            set{
                _imageRef = value;
                OnPropertyChanged("imageRef");
            }
        }

        public string caracterActual;
        

        private System.Collections.Generic.List<String> senalesImagenesRutas;
        public System.Collections.Generic.List<String> senalesLetraRutas;

        private Frase procesaFrase;
        private Timer timer;

        public Vocabulario() { 
            
        }

        public void traducir() {
            procesaFrase = new Frase(_textoFrase);
            senalesImagenesRutas = new System.Collections.Generic.List<String>();
            senalesLetraRutas = new System.Collections.Generic.List<String>();
            indice = 0;
            
            for (int i = 0; i < procesaFrase.palabras.Length; i++) {
                int numeroAnimacion;
                VariablesConfiguracion.letrasNumeros.TryGetValue(
                    procesaFrase.palabras[i].palabra, 
                    out numeroAnimacion);
                Console.WriteLine("Probanle la palabra {0} = {1} ", 
                    procesaFrase.palabras[i].palabra, numeroAnimacion);
                if (numeroAnimacion == 0)
                {
                    for (int j = 0; j < procesaFrase.palabras[i].letras.Length; j++)
                    {
                        senalesImagenesRutas.Add(procesaFrase.palabras[i].letras[j].caracterSena);
                        senalesLetraRutas.Add(procesaFrase.palabras[i].letras[j].caracter);
                        Console.WriteLine(procesaFrase.palabras[i].letras[j].caracterSena);
                    }
                }
                else {
                    senalesLetraRutas.Add(procesaFrase.palabras[i].palabra);
                }
            }
            //animar();
            Console.WriteLine("EXISTEN {0} LETRAS ",senalesImagenesRutas.Count);
        }
        /// <summary>
        /// Al iniciar inicia el timer para recoger los caracteres y modificar la propiedad imagenRef
        /// </summary>
        private void animar() {
            timer = new Timer();
            timer.Interval = 2000;
            timer.Elapsed += new ElapsedEventHandler(onTimeEvent);
            timer.Enabled = true;
        }

        private int indice;
        private String[] senalesRutas;
        private String[] senalesCaracter;
        /// <summary>
        /// Es el delegado que hace el cambio de la imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void onTimeEvent(object sender, EventArgs e){
            if (senalesRutas == null)
            {
                senalesRutas = senalesImagenesRutas.ToArray();
                senalesCaracter =senalesLetraRutas.ToArray();
                indice = 0;
            }
            // Asigna el nombre del archivo de imagen a mostrar.
            imageRef = senalesRutas[indice];
            caracterActual = senalesCaracter[indice];

            EventArgs ea = new EventArgs();
            //CambioLetra(this, EventArgs.Empty);
            Console.WriteLine("VEAMOS EL HILOS PUES " + imageRef);
            indice++;

            if (indice == senalesRutas.Length)
            {
                senalesRutas = null;
                indice = 0;
                timer.Enabled = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propiedadNombre) {
            if (this.PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propiedadNombre));
            }
        }


        //Eventos para cuando cambia la letra
        public event CambioLetraEventHandler CambioLetra;
    }

    public class JuegoImageConverter : System.Windows.Data.IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            Console.WriteLine("CONVIRTIENDO IMAGEN " + value);
            if (value != null)
            {
                string imageName = value.ToString();
                Uri uri = new Uri(imageName, UriKind.RelativeOrAbsolute);
                System.Windows.Media.Imaging.BitmapFrame source = System.Windows.Media.Imaging.BitmapFrame.Create(uri);
                return source;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
