using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;
using Data.Database;

namespace Business.Logic
{
    public class PlanLogic : BusinessLogic
    {
        PlanAdapter _PlanData = new PlanAdapter();

        public PlanAdapter PlanData
        {
            get
            {
                return _PlanData;
            }

            set
            {
                _PlanData = value;
            }
        }

        public List<Plan> GetAll()
        {
            return PlanData.GetAll();
        }
        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }
        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }
    }
}
