using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class InscripcionCursadoAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll(Curso curso, Persona alumno)
        {

            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            int idCurso = curso.ID;
            int idAlumno = alumno.ID;

            try
            {
                this.OpenConnection();

                SqlCommand cmdInsc = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso = @id_curso AND id_alumno = @id_alumno ", sqlConn);
                cmdInsc.Parameters.Add("@id_curso", SqlDbType.Int).Value = idCurso;
                cmdInsc.Parameters.Add("@id_alumno", SqlDbType.Int).Value = idAlumno;

                SqlDataReader drInsc = cmdInsc.ExecuteReader();
                while (drInsc.Read())
                {
                    AlumnoInscripcion insc = new AlumnoInscripcion();

                    insc.ID = (int)drInsc["id_inscripcion"];
                    insc.IDAlumno = (int)drInsc["id_alumno"];
                    insc.IDCurso = (int)drInsc["id_curso"];
                    insc.Condicion = (string)drInsc["condicion"];
                    insc.Nota = (int)drInsc["nota"];

                    inscripciones.Add(insc);

                }

                drInsc.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return inscripciones;
        }


        public List<AlumnoInscripcion> GetAll(int idAlumno)
        {

            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInsc = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno = @id_alumno", sqlConn);
                cmdInsc.Parameters.Add("@id_alumno", SqlDbType.Int).Value = idAlumno;


                SqlDataReader drInsc = cmdInsc.ExecuteReader();
                while (drInsc.Read())
                {
                    AlumnoInscripcion insc = new AlumnoInscripcion();

                    insc.ID = (int)drInsc["id_inscripcion"];
                    insc.IDAlumno = (int)drInsc["id_alumno"];
                    insc.IDCurso = (int)drInsc["id_curso"];
                    insc.Condicion = (string)drInsc["condicion"];
                    insc.Nota = (int)drInsc["nota"];

                    inscripciones.Add(insc);

                }

                drInsc.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return inscripciones;
        }

        public List<AlumnoInscripcion> GetAll()
        {

            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInsc = new SqlCommand("SELECT * FROM alumnos_inscripciones ", sqlConn);


                SqlDataReader drInsc = cmdInsc.ExecuteReader();
                while (drInsc.Read())
                {
                    AlumnoInscripcion insc = new AlumnoInscripcion();

                    insc.ID = (int)drInsc["id_inscripcion"];
                    insc.IDAlumno = (int)drInsc["id_alumno"];
                    insc.IDCurso = (int)drInsc["id_curso"];
                    insc.Condicion = (string)drInsc["condicion"];
                    insc.Nota = (int)drInsc["nota"];

                    inscripciones.Add(insc);

                }

                drInsc.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de inscripciones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return inscripciones;
        }

        public AlumnoInscripcion GetOne(int ID)
        {
            AlumnoInscripcion alInsc = new AlumnoInscripcion();
            try
            {
                this.OpenConnection();
                SqlCommand cmdAlumnoInscripcion = new SqlCommand("Select * from alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdAlumnoInscripcion.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drAlumnoInscripcion = cmdAlumnoInscripcion.ExecuteReader();

                if (drAlumnoInscripcion.Read())
                {
                    alInsc.ID = (int)drAlumnoInscripcion["id_inscripcion"];
                    alInsc.IDAlumno = (int)drAlumnoInscripcion["id_alumno"];
                    alInsc.IDCurso = (int)drAlumnoInscripcion["id_curso"];
                    alInsc.Condicion = (string)drAlumnoInscripcion["condicion"];
                    alInsc.Nota = (int)drAlumnoInscripcion["nota"];
                }
                drAlumnoInscripcion.Close();

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos en inscripciones", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return alInsc;
        }


        protected void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdsave = new SqlCommand("INSERT into alumnos_inscripciones(id_alumno, id_curso, condicion, nota) values(@id_alumno,@id_curso,@condicion, @nota)" +
                    "select @@identity", sqlConn);

                cmdsave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdsave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdsave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdsave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;

                inscripcion.ID = Decimal.ToInt32((decimal)cmdsave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al generar inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(AlumnoInscripcion ins)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdsave = new SqlCommand("UPDATE alumnos_inscripciones SET nota = @nota, condicion = @condicion WHERE id_inscripcion = @id ", sqlConn);

                cmdsave.Parameters.Add("@id", SqlDbType.Int).Value = ins.ID;
                cmdsave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = ins.Condicion;
                cmdsave.Parameters.Add("@nota", SqlDbType.Int).Value = ins.Nota;

                cmdsave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos del usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar inscripcion", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion ins)
        {
            if (ins.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ins.ID);
            }
            else if (ins.State == BusinessEntity.States.New)
            {
                this.Insert(ins);
            }
            else if (ins.State == BusinessEntity.States.Modified)
            {
                this.Update(ins);
            }
            ins.State = BusinessEntity.States.Unmodified;
        }

    }
}
