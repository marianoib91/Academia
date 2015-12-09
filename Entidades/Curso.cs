﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Curso : BusinessEntity
    {

        private int _AnioCalendario, _Cupo, _IDComision, _IDMateria;
        private string _Descripcion;

        public int AnioCalendario 
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }
        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }
        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
    }
}
