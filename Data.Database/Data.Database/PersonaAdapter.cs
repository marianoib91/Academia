using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    //tipo_persona es una enumeracion, por eso hacemos un Case
                    switch (Convert.ToInt32(drPersonas["tipo_persona"]))
                    {
                        case 1:
                            per.TipoPersona = Persona.TipoPersonas.Administrador;
                            break;
                        case 2:
                            per.TipoPersona = Persona.TipoPersonas.Docente;
                            break;
                        case 3:
                            per.TipoPersona = Persona.TipoPersonas.Alumno;
                            break;
                        default:
                            break;
                    }
                    per.IDPlan = (int)drPersonas["id_plan"];

                    //Agrego la persona a la lista

                    personas.Add(per);
                }
                drPersonas.Close();
            }
            catch (Exception Ex)
            {

                Exception ExcepcionManejada =
                new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            //Devuelvo la lista de personas
            return personas;
        }
        public Persona GetOne(int ID)
        {
            Persona per = new Persona();
            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona = @id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    //tipo_persona es una enumeracion, por eso hacemos un Case
                    switch (Convert.ToInt32(drPersonas["tipo_persona"]))
                        {
                        case 1:
                            per.TipoPersona = Persona.TipoPersonas.Administrador;
                            break;
                        case 2:
                            per.TipoPersona = Persona.TipoPersonas.Docente;
                            break;
                        case 3:
                            per.TipoPersona = Persona.TipoPersonas.Alumno;
                            break;
                        default:
                            break;
                        }
                    per.IDPlan = (int)drPersonas["id_plan"];
                    }
                drPersonas.Close();
                }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al recuperar datos de persona.", Ex);
                throw ExcepcionManejada;            }
            finally
            {
                this.CloseConnection();
            }

            return per;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete =
                    new SqlCommand("DELETE personas where id_persona = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
                new Exception("Error al eliminarpersona.", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
     //   protected void 
    }
}
