using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4_Ejercicio2
{
    class Estudiante : Persona
    {
        string carnet;
        string nivelEstudios;

        public string Carnet
        {
            get { return carnet; }
            set { carnet = value; }
        }

        public string NivelEstudios
        {
            get { return nivelEstudios; }
            set { nivelEstudios = value; }
        }
    }
}
