using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4_Ejercicio2
{
    class Ingenieria : Universitario
    {

        string nomproyecto;
        double thoras;
        double nhorascompletas;
        double promedio;

        public string Nombreproyecto
        {
            get { return nomproyecto; }
            set { nomproyecto = value; }
        }

        public double Thoras
        {
            get { return thoras; }
            set { thoras = value; }
        }

        public double Nhorascompletas
        {
            get { return nhorascompletas; }
            set { nhorascompletas = value; }
        }

        public double Promedio
        {
            get { return promedio; }
            set { promedio = value; }
        }

    }
}
