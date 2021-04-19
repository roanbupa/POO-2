using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Segundo_Obligatorio
{
    class Program
    {
        static Sistema sistema = new Sistema();

        static void Main(string[] args)
        {
            int opcion = 0;

            while (opcion != 8)
            {
                Menu();
                opcion = PidoOpcion();
                ProcesoPrincipal(opcion);
            }
        }

        static int PidoOpcion()
        {
            int valor = 0;
            try
            {
                valor = Convert.ToInt32(Console.ReadLine());
                return valor;
            }
            catch
            {
                return 0;
            }
        }

        static void ProcesoPrincipal(int op)
        {

            switch (op)
            {
                case 1:
                    {
                        RegistrarCategoria();
                        break;
                    }
                case 2:
                    {
                        RegistrarArticulo();
                        break;
                    }
                case 3:
                    {
                        RegistrarAvisoComun();
                        break;
                    }
                case 4:
                    {
                        RegistrarAvisoDestacado();
                        break;
                    }
                case 5:
                    {
                        ListarAvisos();
                        break;
                    }
                case 6:
                    {
                        ListadoAviosPorFecha();
                        break;
                    }
                case 7:
                    {
                        ConsultaAviso();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Ingrese opcion correcta");
                        break;
                    }
            }
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\tGESTION DE AVISOS CLASIFICADOS");
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\nMenu");
            Console.WriteLine("1- Agregar Categoria");
            Console.WriteLine("2- Agregar Articulo");
            Console.WriteLine("3- Agregar Aviso Comun");
            Console.WriteLine("4- Agregar Aviso Destacado");
            Console.WriteLine("5- Listado de Avisos");
            Console.WriteLine("6- Listado de Avisos por Fecha");
            Console.WriteLine("7- Consulta de Avisos por Id");
            Console.WriteLine("8- Salir");
            Console.Write("Indique opcion: ");
        }

        private static void ConsultaAviso()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("\tCONSULTA DE AVISOS");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("\nIngrese Id del aviso: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Aviso aviso = sistema.ConsultarAviso(id);
                if (aviso == null)
                {
                    Console.WriteLine("\n* No existe aviso para el Id dado *");
                }
                else
                {
                    Console.WriteLine(aviso.ToString());
                }
            }
            catch
            {
                Console.WriteLine("\n* Debe de ingresar un Id *");
            }

            Console.ReadLine();
        }

        private static void ListadoAviosPorFecha()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("\tLISTADO DE AVISOS POR FECHA");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("\nFecha (dd/mm/yyyy): ");
                DateTime fecha = Convert.ToDateTime(Console.ReadLine());

                List<Aviso> listaAviso = sistema.AvisosParaUnaFecha(fecha);
                if (listaAviso.Count == 0)
                {
                    Console.WriteLine("\n* No hay compras para la fecha dada *");
                }
                else
                {
                    foreach (Aviso avis in listaAviso)
                    {
                        Console.WriteLine(avis.ToString());
                    }
                }
            }
            catch
            {
                Console.WriteLine("\n* Fecha incorrecta *");
            }
            Console.ReadLine();
        }

        static void RegistrarCategoria()
        {

            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("\tREGISTRO DE CATEGORIAS");
                Console.WriteLine("---------------------------------------------------------");

                Console.Write("\nIngrese Codigo de Categoria: ");
                string codigoCat = Console.ReadLine().Trim().ToUpper();

                Categoria categoria = sistema.BuscarCategoria(codigoCat);
                if (categoria == null)
                {
                    Console.Write("\nIngrese Nombre: ");
                    string nom = Console.ReadLine();
                    Console.Write("Ingrese Precio: ");
                    int pre = Convert.ToInt32(Console.ReadLine());

                    Categoria catego = new Categoria(codigoCat, nom, pre);

                    sistema.AgregarCategoria(catego);
                    Console.WriteLine("\t\n* Categoria registrada *");
                }
                else
                {
                    Console.WriteLine("\nOpciones");
                    Console.WriteLine("1- Editar");
                    Console.WriteLine("2- Eliminar");
                    Console.WriteLine("3- Salir");
                    Console.Write("Ingrese opcion: ");
                    int op = Convert.ToInt32(Console.ReadLine());
                    switch (op)
                    {
                        case 1:
                            {
                                try
                                {
                                    Console.WriteLine("\t\n* EDICION *");
                                    Console.Write("Nuevo nombre: ");
                                    string nom = Console.ReadLine();

                                    Console.Write("Precio: ");
                                    int pre = Convert.ToInt32(Console.ReadLine());

                                    categoria.Nombre = nom;
                                    categoria.PrecioBase = pre;

                                    Console.WriteLine("\t\n* Edicion realizada *");

                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);

                                }
                                break;
                            }
                        case 2:
                            {
                                bool catUso = sistema.CategoriaenUso(codigoCat);
                                if (catUso == true)
                                {
                                    Console.WriteLine("\n* No se puede eliminar la catgoria porque tiene avisos asociados *");
                                }
                                else
                                {
                                    sistema.EliminarCategoria(categoria);
                                    Console.WriteLine("\t\n* Categoria eliminada *");
                                }
                                break;
                            }
                        case 3:
                            {
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("\n* Debe ingresar la opcion correcta *");
                                break;
                            }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void RegistrarArticulo()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("\tREGISTRO DE ARTICULOS");
                Console.WriteLine("---------------------------------------------------------");
                Console.Write("\nIngrese codigo de articulo: ");
                string codigoArt = Console.ReadLine().Trim().ToUpper();

                Articulo articulo = sistema.BuscarArticulo(codigoArt);


                if (articulo == null)
                {
                    Console.Write("\nIngrese precio: ");
                    int pre = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Ingrese descripcion del mismo: ");
                    string des = Console.ReadLine();

                    Articulo art = new Articulo(codigoArt, pre, des);

                    sistema.AgregarArticulo(art);

                    Console.WriteLine(art.ToString());

                    Console.WriteLine("\t\n* Articulo Agregado *");

                }
                else
                {
                    Console.WriteLine("\n* El articulo ya existe *");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void RegistrarAvisoComun()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("\tREGISTRO DE AVISOS COMUNES");
                Console.WriteLine("---------------------------------------------------------");

                Console.Write("\nIngrese codigo de categoria: ");
                string codigoCat = Console.ReadLine().Trim().ToUpper();

                Categoria categoria = sistema.BuscarCategoria(codigoCat);

                if (categoria == null)
                {
                    Console.WriteLine("\n* Categoria inexistente *");
                }
                else
                {

                    Comun com = new Comun(sistema.idAviso, IngreseTelefono(), DateTime.Today, (Categoria)categoria, IngresePalabrasClaves());
                    sistema.AltaAviso(com);
                    Console.WriteLine(com.ToString());
                    Console.WriteLine("Palabras claves");
                    foreach (string pc in com.PalabrasClaves)
                    {
                        Console.WriteLine(pc);
                    }
                    Console.WriteLine("\t\n* Aviso comun registrado *");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void RegistrarAvisoDestacado()
        {
            Console.Clear();
            try
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("\tREGISTRO DE AVISOS DESTACARDOS");
                Console.WriteLine("---------------------------------------------------------");

                Console.Write("\nIngrese codigo de categoria: ");
                string codigoCat = Console.ReadLine().Trim().ToUpper();

                Categoria categoria = sistema.BuscarCategoria(codigoCat);
                if (categoria == null)
                {
                    Console.WriteLine("\n* Categoria inexistente *");
                }
                else
                {
                    Console.Write("\nIngrese articulo: ");
                    string art = Console.ReadLine().Trim().ToUpper();

                    Articulo articulo = sistema.BuscarArticulo(art);
                    bool artUso = sistema.ArticuloenUso(art);
                    if (articulo == null)
                    {
                        Console.WriteLine("\n* Debe ingresar un articulo existente *");
                    }
                    else if (artUso == true)
                    {
                        Console.WriteLine("\n* El articulo ya tiene un aviso designado *");
                    }
                    else
                    {
                        Destacado dest = new Destacado(sistema.idAviso, IngreseTelefono(), DateTime.Today, (Categoria)categoria, (Articulo)articulo);
                        sistema.AltaAviso(dest);

                        Console.WriteLine("\t\n* Aviso destacado registrado *");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        static void ListarAvisos()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("\tLISTADO DE AVISOS");
            Console.WriteLine("---------------------------------------------------------");
            foreach (Aviso avis in sistema.avisos)
            {
                if (avis is Destacado)
                {
                    Console.WriteLine(((Destacado)avis).ToString());
                }
                else
                {
                    Console.WriteLine(((Comun)avis).ToString());
                    Console.WriteLine("Palabras claves: ");

                    foreach (string pc in ((Comun)avis).PalabrasClaves)
                    {
                        Console.WriteLine(pc);
                    }
                }
            }
            Console.ReadLine();
        }

        static List<string> IngresePalabrasClaves()
        {
            List<string> pclave = new List<string>();
            Console.Write("Ingrese cantidad de palabras claves: ");
            int cantidad = Convert.ToInt32(Console.ReadLine());
            if (cantidad <= 0)
            {
                return null;
            }
            else
            {
                for (int i = 1; i <= cantidad; i++)
                {
                    Console.Write("Palabra Clave " + i + ": ");
                    string pc = Console.ReadLine();
                    if (pc.Length == 0)
                    {
                        return null;
                    }
                    else
                    {
                        pclave.Add(pc);
                    }
                }
            }
            return pclave;
        }

        static string IngreseTelefono()
        {

            Console.Write("\nTelefono: ");
            string tel = Console.ReadLine();
            return tel;


        }

    }
}
