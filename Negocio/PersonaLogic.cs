using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Data.Database;
using Business.Entities;

namespace Business.Logic
{
    public class PersonaLogic : BusinessLogic
    {
        private PersonaAdapter _PersonaData;

        public PersonaAdapter PersonaData
        {
            get
            {
                return _PersonaData;
            }
            set
            {
                _PersonaData = value;
            }
        }

        public PersonaLogic()
        {
            _PersonaData = new PersonaAdapter();
        }

        public List<Persona> GetAll()
        {
            return PersonaData.GetAll();
        }

        public List<Persona> GetAllAlumnos()
        {
            return PersonaData.GetAllAlumnos();
        }


        public List<Persona> GetAllDocentes()
        {
            return PersonaData.GetAllDocentes();
        }

        public List<Persona> GetAllDocentes(int id_plan)
        {
            return PersonaData.GetAllDocentes(id_plan);
        }

        public int AsignarPersona(string nom, string ape, int leg)
        {
            return PersonaData.AsignarPersona(nom, ape, leg);
        }

        public Persona GetOne(int ID)
        {
            return PersonaData.GetOne(ID);
        }

        public Persona GetOneLegajo(int legajo)
        {
            return PersonaData.GetOneLegajo(legajo);
        }

        public void Save(Persona persona)
        {
            PersonaData.Save(persona);
        }

        public void Delete(int ID)
        {
            PersonaData.Delete(ID);
        }


    }
}