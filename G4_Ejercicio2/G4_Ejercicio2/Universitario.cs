using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G4_Ejercicio2
{
    class Universitario : Estudiante
    {

        string universidad;
        string carrera;
        int materiasInscritas;
        double notas;
        double cum;


        public string Universidad
        {
            get { return universidad; }
            set { universidad = value; }
        }

        public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

        public int MateriasInscritas
        {
            get { return materiasInscritas; }
            set { materiasInscritas = value; }
        }

        public double Notas
        {
            get { return notas; }
            set { notas = value; }
        }

        public double Cum
        {
            get { return cum; }
            set { cum = value; }
        }
    }
}
