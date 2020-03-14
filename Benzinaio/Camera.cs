using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benzinaio
{
    public class Camera
    {

        private static string[] ElencoCamere = { "SINGOLA", "DOPPIA", "TRIPLA", "SUITE", "BUNGALOW", "TUGURIO" };
        private static string[] ElencoEtichette = { "S", "D", "X", "B", "T" };
        private  static int[] numeri = { 0, 0, 0, 0, 0 };

        private string id;  //"Es S-01, D-01, U-10 Prima Lettera indica il tipo - Due Cifre indicano il numero progressivo della camera."
        private string nome; // valori consentiti  "SINGOLA", "DOPPIA", "TRIPLA", "SUITE", "BUNGALOW", "TUGURIO"
        private string etichetta; // valori consentiti "S", "D", "X", "B", "T" 
        private int nPosti; //valori consenti 1,2,3,4,5.
        private string[] optional;
        

        public Camera(String Nome, int NPosti, params string[] opt)
        {
            this.Nome = Nome;
            etichetta = ElencoEtichette[Array.IndexOf(ElencoCamere, Nome)];
            id = numeri[Array.IndexOf(ElencoCamere, Nome)] >= 10 ? $"{Etichetta}-{numeri[Array.IndexOf(ElencoCamere, Nome)]++}":
                                                                   $"{Etichetta}-0{numeri[Array.IndexOf(ElencoCamere, Nome)]++}";
            this.NPosti = NPosti;
            Optional = opt;
        }

        //
        public string Nome { get => nome; set => nome =  ElencoCamere.Contains(value) ? value : throw new ArgumentException("La Camera non Esiste"); }
        public string Etichetta { get => etichetta; }
        public string Id { get => id;  }
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
        public override string ToString()
        {
            return $"Tipo Camera:{Nome} Numero:{id} Occupanti:{NPosti} Optional:{optional.ToString()}";
        }

    }
}
