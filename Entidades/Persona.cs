using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Persona : BusinessEntity
    {

        public enum TipoPersonas { Administrador = 1, Docente = 2, Alumno = 3 };
        private string _Apellido, _Direccion, _Email, _Nombre, _Telefono;
        private int _IDPlan, _Legajo;
        private DateTime _FechaNacimiento;
        private TipoPersonas _TipoPersona;

        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }
        public string Telefono
        {
            get { return _Telefono; }
            set { _Telefono = value; }
        }
        public int IDPlan {
            get { return _IDPlan; }
            set { _IDPlan = value; }
        }
        public int Legajo
        {
            get { return _Legajo; }
            set { _Legajo = value; }
        }
        public DateTime FechaNacimiento {
            get { return _FechaNacimiento; }
            set { _FechaNacimiento = value; }
        }
        public TipoPersonas TipoPersona {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }

    }

}
