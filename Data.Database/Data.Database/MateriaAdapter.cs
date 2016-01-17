using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Business.Entities;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {

            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias", sqlConn);
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(mat);

                }

                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return materias;
        }
        public List<Materia> GetAll(int idPlan)
        {

            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_plan = @id_plan", sqlConn);
                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = idPlan;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();
                while (drMaterias.Read())
                {
                    Materia mat = new Materia();

                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(mat);

                }

                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar la lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {

                this.CloseConnection();
            }
            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE id_materia = @id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }


        public Materia GetOne(string desc, int idPlan)
        {
            Materia mat = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("SELECT * FROM materias WHERE desc_materia = @desc and id_plan = @idPlan", sqlConn);
                cmdMaterias.Parameters.Add("@idPlan", SqlDbType.Int).Value = idPlan;
                cmdMaterias.Parameters.Add("@desc", SqlDbType.VarChar).Value = desc;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read())
                {
                    mat.ID = (int)drMaterias["id_materia"];
                    mat.Descripcion = (string)drMaterias["desc_materia"];
                    mat.HSTotales = (int)drMaterias["hs_totales"];
                    mat.HSSemanales = (int)drMaterias["hs_semanales"];
                    mat.IDPlan = (int)drMaterias["id_plan"];
                }
                drMaterias.Close();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return mat;
        }
        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("DELETE materias WHERE id_materia = @id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Update(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdsave = new SqlCommand("UPDATE materias SET desc_materia = @desc_materia, id_plan = @id_plan, hs_totales = @hs_totales, hs_semanales = @hs_semanales WHERE id_materia = @id", sqlConn);

                cmdsave.Parameters.Add("@id", SqlDbType.Int).Value = mat.ID;
                cmdsave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdsave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;
                cmdsave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdsave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;

                cmdsave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar los datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Materia mat)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdsave = new SqlCommand("INSERT into materias(desc_materia, id_plan, hs_totales, hs_semanales) values(@desc_materia,@id_plan,@hs_totales,@hs_semanales )" +
                    "select @@identity", sqlConn);

                cmdsave.Parameters.Add("@desc_materia", SqlDbType.VarChar, 50).Value = mat.Descripcion;
                cmdsave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mat.IDPlan;
                cmdsave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = mat.HSTotales;
                cmdsave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = mat.HSSemanales;

                mat.ID = Decimal.ToInt32((decimal)cmdsave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al cargar una nueva materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }


        public void Save(Materia mat)
        {
            if (mat.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mat.ID);
            }
            else if (mat.State == BusinessEntity.States.New)
            {
                this.Insert(mat);
            }
            else if (mat.State == BusinessEntity.States.Modified)
            {
                this.Update(mat);
            }
            mat.State = BusinessEntity.States.Unmodified;
        }

    }
}