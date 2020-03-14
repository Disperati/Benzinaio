using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Benzinaio
{
    public class Cliente
    {
        // Attributi e Properties
        private static int _gen_id = 0; // Attributo statico (istanza di classe)
        public int idCliente { get; } // es. 1158 (codice autoincrementante)

        private string _nome;
        public string nome
        { // es. Mario Luigi (min 4 caratteri, max 25 caratteri, solo lettere)
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4 || value.Length > 25) throw new ArgumentException("Lunghezza nome non valida.");
                foreach (char c in value)
                {
                    if (char.IsLetter(c) == false) throw new ArgumentException("Nome non valido.");
                }
                _nome = value;
            }
        }

        private string _cognome;
        public string cognome
        { // es. Rossi (min 4 caratteri, max 25 caratteri, solo lettere)
            get { return _cognome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4 || value.Length > 25) throw new ArgumentException("Lunghezza cognome non valida.");
                foreach (char c in value)
                {
                    if (char.IsLetter(c) == false) throw new ArgumentException("Nome non valido.");
                }
                _cognome = value;
            }
        }

        private DateTime _dataNascita;
        public DateTime dataNascita
        { // Accettati solo maggiorenni
            get { return _dataNascita; }
            set
            {
                if (value.AddYears(18) > DateTime.Now) throw new ArgumentException("Si accettano solo clienti maggiorenni.");
                _dataNascita = value;
            }
        }

        public bool haveCartaIdentita { get; }
        public bool havePassaporto { get; }

        // se C.I. 2 lettere – 5 numeri – 2 lettere (ad esempio CA00000AA)
        // se passaporto YA seguite da 7 cifre con numerazione che inizierà dal numero YA0370001
        private string _codDocRegistrato;
        public string codiceDocumento
        {
            get { return _codDocRegistrato; }
            set
            {
                if (value.Length != 7 && value.Length != 9) throw new ArgumentException("Lunghezza codice non valida.");
                if (value.Length == 9)
                    if (!new Regex(@"\D{2}\w{5}\D{2}").IsMatch(value)) throw new ArgumentException("Codice C.I. non valido.");
                if (value.Length == 7)
                    if (!new Regex(@"YA\D{7}").IsMatch(value)) throw new ArgumentException("Codice passaporto non valido.");
                _codDocRegistrato = value;
            }
        }

        // Costruttore
        public Cliente(string nome, string cognome, DateTime nascita, bool carta_identita, bool passaporto, string cod_doc_registrato)
        {
            this.nome = nome;
            this.cognome = cognome;
            this.dataNascita = nascita;
            haveCartaIdentita = carta_identita;
            havePassaporto = passaporto;
            codiceDocumento = cod_doc_registrato;

            _gen_id++;
            idCliente = _gen_id;
        }
    }
}