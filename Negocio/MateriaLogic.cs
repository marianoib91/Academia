using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entities;
using Data.Database;

namespace Business.Logic
{
    public class MateriaLogic : BusinessLogic
    {

        private MateriaAdapter _MateriaData;
        public MateriaAdapter MateriaData
        {
            get { return _MateriaData; }
            set { _MateriaData = value; }
        }

        public MateriaLogic()
        {
            _MateriaData = new MateriaAdapter();
        }

        public List<Materia> GetAll()
        {
            return MateriaData.GetAll();
        }
        public List<Materia> GetAll(int idPlan)
        {
            return MateriaData.GetAll(idPlan);
        }

        public Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }

        public Materia GetOne(string desc, int idPlan)
        {
            return MateriaData.GetOne(desc, idPlan);
        }
        public void Save(Materia materia)
        {
            MateriaData.Save(materia);
        }

        public void Delete(int ID)
        {
            MateriaData.Delete(ID);
        }

    }
}
