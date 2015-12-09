using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private UsuarioLogic _UsuarioNegocio = new UsuarioLogic();

        public UsuarioLogic UsuarioNegocio {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; } 
        }
        public void Menu() {

            int op = 1;
            while (op != 6) 
            {
                Console.Clear();  
            Console.WriteLine("1- Listado general \n ");
            Console.WriteLine("2- Consulta \n ");
            Console.WriteLine("3- Agregar \n ");
            Console.WriteLine("4- Modificar \n ");
            Console.WriteLine("5- Eliminar \n ");
            Console.WriteLine("6- Salir \n ");
            op = Convert.ToInt32(Console.ReadLine());            
            switch (op)
                {
                case 1: ListadoGeneral();
                    break;
                case 2: Consultar();
                    break;
                case 3: Agregar();
                    break;
                case 4: Modificar();
                    break;
                case 5: Eliminar();
                    break;
                case 6:
                    break;
                default:
                    break;
                }
            
            }
            
        }

        public void ListadoGeneral(){
            Console.Clear();
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }  
        }
        public void MostrarDatos(Usuario usr) {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.EMail);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.ReadKey();
        }
        public void Consultar()
        {
            Console.Clear();
            Console.Write("Ingrese el ID del usuario a Consultar: ");

            try
            {
                int ID = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(ID));
                Console.ReadKey();
            }
            catch (FormatException) 
            {
               
                Console.Clear();
                Console.WriteLine("ERROR! La ID ingresada debe ser un número entero.");
                
            }
            catch(NullReferenceException e)
            {
              
                    Console.Clear();
                    Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\n\nPresione una tecla para continuar");
                Console.ReadKey();
            }

        }

        public void Modificar()
        {
            try 
            { 
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                Usuario usuario = (UsuarioNegocio.GetOne(ID));
                Console.WriteLine("Ingrese Nombre: ");
                usuario.Nombre = Console.ReadLine();
                Console.WriteLine("Ingrese Apellido: ");
                usuario.Apellido = Console.ReadLine();
                Console.WriteLine("Ingrese Nombre de Usuario: ");
                usuario.NombreUsuario = Console.ReadLine();
                Console.WriteLine("Ingrese Clave: ");
                usuario.Clave = Console.ReadLine();
                Console.WriteLine("Ingrese Email: ");
                usuario.EMail = Console.ReadLine();
                Console.WriteLine("Ingrese Habilitación de Usuario (1- Si / Otro-No): ");
                usuario.Habilitado = (int.Parse(Console.ReadLine()) == 1 );
                usuario.State = BusinessEntity.States.Modified;
                UsuarioNegocio.Save(usuario);
            }
            catch (FormatException)
            {

                Console.Clear();
                Console.WriteLine("ERROR! La ID ingresada debe ser un número entero.");

            }
            catch (NullReferenceException e)
            {

                Console.Clear();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\n\nPresione una tecla para continuar");
                Console.ReadKey();
            }
        }

        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.WriteLine("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.WriteLine("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.WriteLine("Ingrese Nombre de Usuario: ");
            usuario.NombreUsuario = Console.ReadLine();
            Console.WriteLine("Ingrese Clave: ");
            usuario.Clave = Console.ReadLine();
            Console.WriteLine("Ingrese Email: ");
            usuario.EMail = Console.ReadLine();
            Console.WriteLine("Ingrese Habilitación de Usuario (1- Si / Otro-No): ");
            usuario.Habilitado = (int.Parse(Console.ReadLine()) == 1);
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine("\nID: {0}", usuario.ID);
            Console.ReadKey();

        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                int ID = int.Parse(Console.ReadLine());
                UsuarioNegocio.Delete(ID);
            }
            catch (FormatException)
            {

                Console.Clear();
                Console.WriteLine("ERROR! La ID ingresada debe ser un número entero.");

            }
            catch (NullReferenceException e)
            {

                Console.Clear();
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("\n\nPresione una tecla para continuar");
                Console.ReadKey();
            }
        }
        
    }

}
