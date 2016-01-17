using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class DocenteCursoLogic : BusinessLogic
    {
        private DocenteCursoAdapter _DcData;
        public DocenteCursoAdapter DcData
        {
            get { return _DcData; }
            set { _DcData = value; }
        }

        public DocenteCursoLogic()
        {
            DcData = new DocenteCursoAdapter();
        }

        public List<DocenteCurso> GetAll()
        {
            return DcData.GetAll();
        }
        public List<DocenteCurso> GetAll(int id)
        {
            return DcData.GetAll(id);
        }
        public DocenteCurso GetOne(int ID)
        {
            return DcData.GetOne(ID);
        }

        public void Save(DocenteCurso a)
        {
            DcData.Save(a);
        }
        public void Delete(int ID)
        {
            DcData.Delete(ID);
        }
    }
}
