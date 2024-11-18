using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Registro_de_Información_Académica_de_Estudiantes
{
    public class Estudiantes
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }    
        public int Numero { get; set; }
        public string Carrera { get; set; }
        public int Materias { get; set; }
        public int Promedio { get; set; }

        //llamado al constructor para inicializar los campos
        public Estudiantes(string nombre, string apellido, int numero, string carrera, int materias, int promedio)
        {
            Nombre = nombre;
            Apellido = apellido;
            Numero = numero;
            Carrera = carrera;
            Materias = materias;
            Promedio = promedio;
        }
    }

}
