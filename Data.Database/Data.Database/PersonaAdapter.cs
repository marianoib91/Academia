using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {

            //Devuelvo todas las personas que tengo en la base de datos y las cargo a la grilla
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
                    per.FechaNacimiento = ((DateTime)drPersonas["fecha_nac"]);
                    per.Legajo = (int)drPersonas["legajo"];
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return personas;
        }

        /*RECORDAR TIPOS DE PERSONA:
        1- Admin
        2- Docente
        3- Alumno*/

        public List<Persona> GetAllAlumnos()
        {

            List<Persona> alumnos = new List<Persona>();

            try
            {
                this.OpenConnection();
                //Recupero SOLO a las personas Alumno
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE tipo_persona=3", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();
                while (drPersonas.Read())
                {
                    Persona alu = new Persona();

                    alu.ID = (int)drPersonas["id_persona"];
                    alu.Nombre = (string)drPersonas["nombre"];
                    alu.Apellido = (string)drPersonas["apellido"];
                    alu.Direccion = (string)drPersonas["direccion"];
                    alu.Email = (string)drPersonas["email"];
                    alu.Telefono = (string)drPersonas["telefono"];
                    alu.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    alu.Legajo = (int)drPersonas["legajo"];
                    alu.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    alu.IDPlan = (int)drPersonas["id_plan"];

                    alumnos.Add(alu);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de alumnos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return alumnos;
        }

        /*RECORDAR TIPOS DE PERSONA:
        1- Admin
        2- Docente
        3- Alumno*/

        public List<Persona> GetAllDocentes()
        {

            List<Persona> profesores = new List<Persona>();

            try
            {
                this.OpenConnection();
                //Recupero SOLO a las personas docente
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE tipo_persona=2", sqlConn);

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
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    profesores.Add(per);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de profesores", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return profesores;
        }
        /*RECORDAR TIPOS DE PERSONA:
        1- Admin
        2- Docente
        3- Alumno*/
        public List<Persona> GetAllDocentes(int idPlan)
        {
            //Recupero a TODOS los Docentes
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE tipo_persona=2 and id_plan=@idPlan", sqlConn);
                cmdPersonas.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
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
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];

                    personas.Add(per);
                }

                drPersonas.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return personas;
        }

        public int AsignarPersona(string nom, string ape, int leg)
        {

            this.OpenConnection();

            SqlCommand cmdPersonas = new SqlCommand("SELECT id_persona FROM personas WHERE nombre = @nombre AND apellido = @apellido AND legajo = @legajo ", sqlConn);
            cmdPersonas.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = nom;
            cmdPersonas.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = ape;
            cmdPersonas.Parameters.Add("@legajo", SqlDbType.Int).Value = leg;
            SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

            int id;

            if (drPersonas.Read())
                id = (int)drPersonas[0];
            else id = 0;

            this.CloseConnection();

            return id;

        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();
                //Devuelve una persona (sin importar el tipo)
                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE id_persona = @id", sqlConn);
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
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

            return per;
        }

        public Persona GetOneLegajo(int legajo)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("SELECT * FROM personas WHERE legajo = @legajo_docente", sqlConn);
                cmdPersonas.Parameters.Add("@legajo_docente", SqlDbType.Int).Value = legajo;
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
                    per.TipoPersona = (Persona.TipoPersonas)drPersonas["tipo_persona"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos", Ex);
                throw ExcepcionManejada;
            }
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
                SqlCommand cmdDelete = new SqlCommand("DELETE personas WHERE id_persona = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();


                SqlCommand cmdsave = new SqlCommand("UPDATE personas SET nombre = @nombre, apellido = @apellido, email = @email, " +
                    "direccion = @direccion, telefono = @telefono, legajo = @legajo, fecha_nac = @fecha_nac, tipo_persona = @tipo_persona, " +
                    "id_plan = @id_plan WHERE id_persona = @id", sqlConn);


                cmdsave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdsave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdsave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdsave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdsave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdsave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdsave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdsave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdsave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdsave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;


                cmdsave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos de la persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdsave = new SqlCommand("INSERT into personas(nombre, apellido, email, direccion, telefono, legajo,fecha_nac, tipo_persona, id_plan)" +
                    "values(@nombre,@apellido,@email,@direccion,@telefono,@legajo,@fecha_nac,@tipo_persona,@id_plan) " +
                    "select @@identity", sqlConn);


                cmdsave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdsave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdsave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdsave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdsave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdsave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdsave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdsave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = persona.TipoPersona;
                cmdsave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                persona.ID = Decimal.ToInt32((decimal)cmdsave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Save(Persona persona)
        {
            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }


    }
}