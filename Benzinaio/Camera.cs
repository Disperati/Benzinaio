using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benzinaio
{
    public class Camera
    {

        static Tipo[] tipo = { new Tipo("Singola", "S"),new Tipo("Doppia", "D"), new Tipo("Suite Reale", "X"),
                        new Tipo("Bungolow", "B"), new Tipo("Tugurio", "U") };

        private string idCamera;  //"Es S-01, D-01, U-10 Prima Lettera indica il tipo - Due Cifre indicano il numero progressivo della camera."
        private int nPosti;
        private string[] optional;
        private string tipoCamera;
        private string etichetta;

        public Camera(String TipoCamera, int NPosti, params string[] opt)
        {
            this.NPosti = nPosti;
            Optional = opt;
            IdCamera = TipoCamera;
            this.TipoCamera = TipoCamera;
            Etichetta = TipoCamera;


        }
        public int NPosti
        {
            get { return nPosti; }
            set { nPosti = value >= 1 && value <= 5 ? value : throw new ArgumentException("Valore non Valido"); }
        }

        public string[] Optional { get => optional; set
            {
                if (value.Length == 0)
                    optional[0] = "Nessun optional";
                else
                {
                    optional = new String[value.Length];
                    for (int i = 0; i < optional.Length; i++)
                        optional[i] = value[i];
                }
            }
        }

        public string TipoCamera { get => tipoCamera; set => tipoCamera = value; }
        public string IdCamera { get => idCamera; set
            {
                foreach (Tipo t in tipo)
                {
                    if (t.nome == value)
                    {
                        idCamera = t.numeroCamera > 10 ? $"{t.identificativo}-{t.numeroCamera++}" :
                                                         $"{t.identificativo}-0{t.numeroCamera++}";
                        break;
                    }
                    throw new ArgumentException("Camera non Trovata");
                }
            }
        }

        public string Etichetta { get => etichetta; set
            {
                foreach (Tipo t in tipo)
                    if (t.nome == value)
                        etichetta = t.identificativo;
            }
        }

        public override string ToString()
        {
            return $"Stampare Attributi ";
        }

        public class Tipo
        {          
            public string nome { get; set; }
            public string identificativo { get; set; }
            public int numeroCamera { get; set; }

            public Tipo(string nome, string identificativo)
            {
                this.nome = nome;
                this.identificativo = identificativo;
                this.numeroCamera = 1;
            }
        }
    }
}
