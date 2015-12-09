using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;
using Data.Database;

namespace Business.Logic
{
    public class ComisionLogic : BusinessLogic
    {
        private Data.Database.ComisionAdapter _ComisionData;

        public ComisionAdapter ComisionData
        {
            get
            {
                return _ComisionData;
            }

            set
            {
                _ComisionData = value;
            }
        }

        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();
            comisiones = _ComisionData.GetAll();
            return comisiones;
        }
        public Comision GetOne(int ID)
        {
            Comision comision = new Comision();
            comision = _ComisionData.GetOne(ID);
            return comision;
        }
        public void Delete(int ID)
        {
            _ComisionData.Delete(ID);
        }
        public void Save(Comision comision)
        {
            _ComisionData.Save(comision);
        }
    }
}
