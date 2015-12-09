using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using System.Data.SqlClient;
using Business.Entities;

namespace Business.Logic
{
    public class UsuarioLogic : BusinessLogic
    {



        private UsuarioAdapter _UsuarioData = new UsuarioAdapter();

        public UsuarioAdapter UsuarioData
        {
            get { return _UsuarioData; }
            set { _UsuarioData = value; }
        }

        // MÉTODOS GETALL, GETONE, DELETE Y SAVE

        public List<Usuario> GetAll() {
       
            return _UsuarioData.GetAll();
        }
        public Usuario GetOne(int Id)
        {
            return _UsuarioData.GetOne(Id);
        }
        public void Delete(int Id)
        {
            _UsuarioData.Delete(Id);
        }
        public void Save(Usuario U)
        { 
            _UsuarioData.Save(U);
        }

        //MÉTODOS DE MENÚ



    }
}
