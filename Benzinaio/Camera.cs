using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benzinaio
{
    public class Camera
    {

        Tipo[] tipo = { new Tipo("Singola", "S"),new Tipo("Doppia", "D"), new Tipo("Suite Reale", "X"),
                        new Tipo("Bungolow", "B"), new Tipo("Tugurio", "U") };
       
        private string idCamera;  //"Es S-01, D-01, U-10 Prima Lettera indica il tipo - Due Cifre indicano il numero progressivo della camera."
        private int nPosti;
        private string[] optional;
        public Camera(String tipoCamera, int nPosti, params string[] opt)
        {
            NPosti = nPosti;
            Optional = opt;
            assegnaID(tipoCamera);   
            
        }

        public int NPosti
        {
            get { return nPosti; }
            set { nPosti = value >= 1 && value <= 5 ? value : throw new ArgumentException("Valore non Valido"); }
        }

        public string[] Optional { get => optional; set
            {
                if (value.Length == 0)
                    optional[0] = " Nessun optional";
                else
                {
                    optional = new String[value.Length];
                    for (int i = 0; i < optional.Length; i++)
                        optional[i] = value[i];
                }
            }
        }

        public void assegnaID(String nomeCamera)
        {
            foreach (Tipo t in tipo)
            {
                if (t.nome == nomeCamera)
                {
                    idCamera = t.numeroCamera > 10 ? $"{t.identificativo}-{t.numeroCamera++}" :
                                                     $"{t.identificativo}-0{t.numeroCamera++}";
                    break;
                }

                throw new ArgumentException("Non Esiste il tipo di Camera");
            }

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
