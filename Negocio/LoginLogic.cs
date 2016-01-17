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
    class LoginLogic : BusinessLogic
    {
        private LoginAdapter _LoginData;

        public LoginAdapter LoginData
        {
            get
            {
                return _LoginData;
            }
            set
            {
                _LoginData = value;
            }
        }

        public LoginLogic()
        {
            _LoginData = new LoginAdapter();
        }


        public Usuario GetOne(string nombUsuario)
        {
            return LoginData.GetOne(nombUsuario);
        }
    }
}
