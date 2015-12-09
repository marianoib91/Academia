using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class EspecialidadLogic : BusinessLogic
    {
        private EspecialidadAdapter _EspecialidadAdapter = new EspecialidadAdapter();

        public EspecialidadAdapter UsuarioData
        {
            get { return _EspecialidadAdapter; }
            set { _EspecialidadAdapter = value; }
        }
        public List<Especialidad> GetAll()
        {

            return _EspecialidadAdapter.GetAll();
        }
        public Especialidad GetOne(int Id)
        {
            return _EspecialidadAdapter.GetOne(Id);
        }
        public void Delete(int Id)
        {
            _EspecialidadAdapter.Delete(Id);
        }
        public void Save(Especialidad E)
        {
            _EspecialidadAdapter.Save(E);
        }
    }
}
