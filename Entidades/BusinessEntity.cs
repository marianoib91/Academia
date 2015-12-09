using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class BusinessEntity
    {
        //Defino la estructura States
        public enum States { Deleted, New, Modified, Unmodified };

        //Defino las variables _ID y _States con sus respectivas propiedades

        private int _ID;
        private States _State;

        //Propiedad ID

        public int ID { 
            get
            {
                return _ID;
            } 
            set
            {
                _ID=value; 
            }
        }

        //Propiedad States

        public States State { 
            get
            {
                return _State;
            }
            set
            {
                _State = value;
            }
        }
       
    }
}
