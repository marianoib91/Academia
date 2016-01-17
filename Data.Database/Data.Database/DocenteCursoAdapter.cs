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
    public class DocenteCursoAdapter : Adapter
    {
        private static List<DocenteCurso> _DocentesCurso;
        public List<DocenteCurso> DocentesCurso
        {
            get { return _DocentesCurso; }
            set { _DocentesCurso = value; }
        }

        public List<DocenteCurso> GetAll()
        {
            DocentesCurso = new List<DocenteCurso>();
            this.OpenConnection();

            SqlCommand cmdDocentesCurso = new SqlCommand("select * from docentes_cursos", sqlConn);
            SqlDataReader drDocentesCurso = cmdDocentesCurso.ExecuteReader();
            while (drDocentesCurso.Read())
            {
                DocenteCurso dcActual = new DocenteCurso();
                dcActual.ID = (int)drDocentesCurso["id_dictado"];
                dcActual.IDDocente = (int)drDocentesCurso["id_docente"];
                dcActual.IDCurso = (int)drDocentesCurso["id_curso"];
                dcActual.Cargo = (DocenteCurso.TiposCargos)drDocentesCurso["cargo"];
                DocentesCurso.Add(dcActual);
            }

            drDocentesCurso.Close();
            this.CloseConnection();
            return DocentesCurso;

        }
        public List<DocenteCurso> GetAll(int idProfesor)
        {
            DocentesCurso = new List<DocenteCurso>();

            this.OpenConnection();

            SqlCommand cmdDocentesCurso = new SqlCommand("select * from docentes_cursos where id_docente=@id_docente", sqlConn);
            cmdDocentesCurso.Parameters.Add("@id_docente", SqlDbType.Int).Value = idProfesor;
            SqlDataReader drDocentesCurso = cmdDocentesCurso.ExecuteReader();
            while (drDocentesCurso.Read())
            {
                DocenteCurso dcActual = new DocenteCurso();
                dcActual.ID = (int)drDocentesCurso["id_dictado"];
                dcActual.IDDocente = (int)drDocentesCurso["id_docente"];
                dcActual.IDCurso = (int)drDocentesCurso["id_curso"];
                dcActual.Cargo = (DocenteCurso.TiposCargos)drDocentesCurso["cargo"];
                DocentesCurso.Add(dcActual);
            }

            drDocentesCurso.Close();
            this.CloseConnection();
            return DocentesCurso;

        }
        public DocenteCurso GetOne(int ID)
        {
            DocenteCurso dcActual = new DocenteCurso();
            try
            {
                this.OpenConnection();
                SqlCommand cmdDocentesCurso = new SqlCommand("Select * from docentes_cursos where id_dictado=@id", sqlConn);
                cmdDocentesCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drDocentesCurso = cmdDocentesCurso.ExecuteReader();
                if (drDocentesCurso.Read())
                {
                    dcActual.ID = (int)drDocentesCurso["id_dictado"];
                    dcActual.IDDocente = (int)drDocentesCurso["id_docente"];
                    dcActual.IDCurso = (int)drDocentesCurso["id_curso"];
                    dcActual.Cargo = (DocenteCurso.TiposCargos)drDocentesCurso["cargo"];
                }
                drDocentesCurso.Close();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de docente", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return dcActual;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("Delete docentes_cursos where id_dictado=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExceptionManejada = new Exception("Error al eliminar docente", ex);
                throw ExceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Update(DocenteCurso dcActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE docentes_cursos SET id_curso= @id_curso, id_docente = @id_docente, " +
                    "cargo = @cargo WHERE id_dictado=@id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = dcActual.ID;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dcActual.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dcActual.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dcActual.Cargo;
                cmdSave.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Exception exceptionManejada = new Exception("Error al modificar datos de docente", ex);
                throw exceptionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        protected void Insert(DocenteCurso dcActual)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("Insert into docentes_cursos(id_curso,id_docente,cargo) " +
                    "values(@id_curso,@id_docente,@cargo) " +
                    "Select @@identity",
                    sqlConn);
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = dcActual.IDCurso;
                cmdSave.Parameters.Add("@id_docente", SqlDbType.Int).Value = dcActual.IDDocente;
                cmdSave.Parameters.Add("@cargo", SqlDbType.Int).Value = dcActual.Cargo;
                dcActual.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception excepcionManejada = new Exception("Error al crear docente", ex);
                throw excepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }
        public void Save(DocenteCurso dcActual)
        {
            if (dcActual.State == BusinessEntity.States.New)
            {
                this.Insert(dcActual);
            }
            else if (dcActual.State == BusinessEntity.States.Deleted)
            {
                this.Delete(dcActual.ID);
            }
            else if (dcActual.State == BusinessEntity.States.Modified)
            {
                this.Update(dcActual);
            }
            dcActual.State = BusinessEntity.States.Unmodified;
        }
    }
}