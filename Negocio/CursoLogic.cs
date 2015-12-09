using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using Data.Database;


namespace Business.Logic
{
    public class CursoLogic : BusinessLogic
    {
        CursoAdapter _CursoData = new CursoAdapter();

        public CursoAdapter CursoData
        {
            get
            {
                return _CursoData;
            }

            set
            {
                _CursoData = value;
            }
        }
        public List<Curso> GetAll()
        {
            List<Curso> cursos = _CursoData.GetAll();
            return cursos;
        }
        public Curso GetOne(int ID)
        {
            Curso curso = _CursoData.GetOne(ID);
            return curso;
        }
        public void Delete(int ID)
        {
            _CursoData.Delete(ID);
        }
        public void Save(Curso curso)
        {
            _CursoData.Save(curso);
        }
    }
}
