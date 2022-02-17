using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace Ultrabalaton
{
    class Versenyzo
    { 
        public string Nev { get; set; }
        public int Rajtszam;
        public string Kategoria;
        public string Ido;
        public int Tav;
        public TimeSpan idoTS
        {
            get
            {
                string[] i = Ido.Split(':');
                TimeSpan ts = new TimeSpan(int.Parse(i[0]), int.Parse(i[1]), int.Parse(i[2]));
                return ts;
            }
        }
        public Versenyzo(string line)
        {
            string[] d=line.Split(';');
            Nev = d[0];
            Rajtszam = int.Parse(d[1]);
            Kategoria = d[2];
            Ido = d[3];
            Tav = int.Parse(d[4]);
        }

        
    }
}
