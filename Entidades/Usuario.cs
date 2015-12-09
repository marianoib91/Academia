﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : BusinessEntity
    {

        private string _Apellido;
        private string _Nombre;
        private string _Clave;
        private string _EMail;
        private string _NombreUsuario;
        private bool _Habilitado;

        public string Apellido {
            get { return _Apellido;}
            set { _Apellido=value;}
        }
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        public string EMail
        {
            get { return _EMail; }
            set { _EMail = value; }
        }
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }
    }
}
