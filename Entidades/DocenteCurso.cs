using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class DocenteCurso : BusinessEntity
    {
        public enum TiposCargos {Teoria = 1, Practica = 2}
        private int _IDCurso, _IDDocente;
        private TiposCargos _Cargo;

        public int IDCurso
        {
            get { return _IDCurso; }
            set { _IDCurso = value; }
        }
        public int IDDocente
        {
            get { return _IDDocente; }
            set { _IDDocente = value; }
        }
        public TiposCargos Cargo
        {
            get { return _Cargo; }
            set { _Cargo = value; }
        }
    }
}
