using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Program
    {
        public static void Menu()
        {
        menuPrincipal:
            Console.WriteLine("1. CONSULTAS SQL");
            Console.WriteLine("2. STORED PROCEDURES");
            Console.WriteLine("3. ENTITY FRAMEWORK");
            Console.WriteLine("4. LINKQ");
            Console.WriteLine();
            Console.Write("Selecciona una Opcion: ");
            int opcionPrincipal = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcionPrincipal)
            {
                //CONSULTAS SQL
                case 1:
                menu:
                    int menu = 0;
                    Console.WriteLine("CONSULTAS SQL\n");
                    Console.WriteLine("1. INSERT");
                    Console.WriteLine("2. UPDATE");
                    Console.WriteLine("3. DELETE");
                    Console.WriteLine("4. SELECT");
                    Console.WriteLine("5. GET BY ID");
                    Console.WriteLine("6. REGRESAR");
                    Console.WriteLine();
                    Console.Write("Selecciona una Opcion: ");
                    int opcion = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (opcion)
                    {
                        //INSERT
                        case 1:
                            Console.WriteLine("INSERTAR UN USUARIO\n");
                            PL.Usuario.Add();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menu = int.Parse(Console.ReadLine());
                            if (menu == 1)
                            {
                                Console.Clear();
                                goto menu;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //UPDATE
                        case 2:
                            Console.WriteLine("ACTUALIZAR UN USUARIO\n");
                            PL.Usuario.Update();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menu = int.Parse(Console.ReadLine());
                            if (menu == 1)
                            {
                                Console.Clear();
                                goto menu;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //DELETE
                        case 3:
                            Console.WriteLine("ELIMINAR UN USUARIO\n");
                            PL.Usuario.Delete();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menu = int.Parse(Console.ReadLine());
                            if (menu == 1)
                            {
                                Console.Clear();
                                goto menu;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //LISTA COMPLETA
                        case 4:
                            Console.WriteLine("LISTA DE USUARIOS\n");
                            PL.Usuario.GetAll();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menu = int.Parse(Console.ReadLine());
                            if (menu == 1)
                            {
                                Console.Clear();
                                goto menu;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //BUSQUEDA
                        case 5:
                            Console.WriteLine("BÚSQUEDA DE USUARIOS\n");
                            PL.Usuario.GetById();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menu = int.Parse(Console.ReadLine());
                            if (menu == 1)
                            {
                                Console.Clear();
                                goto menu;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //REGRESAR
                        case 6:
                            Console.Clear();
                            goto menuPrincipal;


                        //DEFAULT
                        default:
                            Console.Write("Saliendo");
                            break;
                    }
                    break;

                //STORED PROCEDURES
                case 2:
                menuStored:
                    int menuStored = 0;
                    Console.WriteLine("STORED PROCEDURES \n");
                    Console.WriteLine("1. INSERT");
                    Console.WriteLine("2. UPDATE");
                    Console.WriteLine("3. DELETE");
                    Console.WriteLine("4. SELECT");
                    Console.WriteLine("5. GET BY ID");
                    Console.WriteLine("6. REGRESAR");
                    Console.WriteLine();
                    Console.Write("Selecciona una Opcion: ");
                    int opcionStored = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (opcionStored)
                    {
                        //INSERT
                        case 1:
                            Console.WriteLine("INSERTAR UN USUARIO\n");
                            PL.Usuario.AddProcedure();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuStored = int.Parse(Console.ReadLine());
                            if (menuStored == 1)
                            {
                                Console.Clear();
                                goto menuStored;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //UPDATE
                        case 2:
                            Console.WriteLine("ACTUALIZAR UN USUARIO\n");
                            PL.Usuario.UpdateProcedure();
                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuStored = int.Parse(Console.ReadLine());
                            if (menuStored == 1)
                            {
                                Console.Clear();
                                goto menuStored;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //DELETE
                        case 3:
                            Console.WriteLine("ELIMINAR UN USUARIO\n");
                            PL.Usuario.DeleteProcedure();
                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuStored = int.Parse(Console.ReadLine());
                            if (menuStored == 1)
                            {
                                Console.Clear();
                                goto menuStored;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //LISTA COMPLETA
                        case 4:
                            Console.WriteLine("LISTA DE USUARIOS\n");
                            PL.Usuario.GetAllProcedure();
                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuStored = int.Parse(Console.ReadLine());
                            if (menuStored == 1)
                            {
                                Console.Clear();
                                goto menuStored;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //BUSQUEDA
                        case 5:
                            Console.WriteLine("BUSQUEDA DE USUARIOS\n");
                            PL.Usuario.GetByIdProcedure();
                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuStored = int.Parse(Console.ReadLine());
                            if (menuStored == 1)
                            {
                                Console.Clear();
                                goto menuStored;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //REGRESAR  
                        case 6:
                            Console.Clear();
                            goto menuPrincipal;

                        //DEFAULT
                        default:
                            Console.Write("Saliendo");
                            break;
                    }
                    break;

                //ENTITY FRAMEWORK
                case 3:
                menuEntity:
                    int menuEntity = 0;
                    Console.WriteLine("ENTITY FRAMEWORK \n");
                    Console.WriteLine("1. INSERT");
                    Console.WriteLine("2. UPDATE");
                    Console.WriteLine("3. DELETE");
                    Console.WriteLine("4. SELECT");
                    Console.WriteLine("5. GET BY ID");
                    Console.WriteLine("6. REGRESAR");
                    Console.WriteLine();
                    Console.Write("Selecciona una Opcion: ");
                    int opcionEntity = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (opcionEntity)
                    {
                        //INSERT
                        case 1:
                            Console.WriteLine("INSERTAR UN USUARIO\n");
                            PL.Usuario.AddEF();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuEntity = int.Parse(Console.ReadLine());
                            if (menuEntity == 1)
                            {
                                Console.Clear();
                                goto menuEntity;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //UPDATE
                        case 2:
                            Console.WriteLine("ACTUALIZAR UN USUARIO\n");
                            PL.Usuario.UpdateEF();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuEntity = int.Parse(Console.ReadLine());
                            if (menuEntity == 1)
                            {
                                Console.Clear();
                                goto menuEntity;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //DELETE
                        case 3:
                            Console.WriteLine("ELIMINAR UN USUARIO\n");
                            PL.Usuario.DeleteEF();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuEntity = int.Parse(Console.ReadLine());
                            if (menuEntity == 1)
                            {
                                Console.Clear();
                                goto menuEntity;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //LISTA COMPLETA
                        case 4:
                            Console.WriteLine("LISTA DE USUARIOS\n");
                            PL.Usuario.GetAllEF();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuEntity = int.Parse(Console.ReadLine());
                            if (menuEntity == 1)
                            {
                                Console.Clear();
                                goto menuEntity;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //BUSQUEDA
                        case 5:
                            Console.WriteLine("BÚSQUEDA DE USUARIOS\n");
                            PL.Usuario.GetByIdEF();
                            //Console.WriteLine("En Proceso");

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuEntity = int.Parse(Console.ReadLine());
                            if (menuEntity == 1)
                            {
                                Console.Clear();
                                goto menuEntity;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //REGRESAR
                        case 6:
                            Console.Clear();
                            goto menuPrincipal;

                        //DEFAULT
                        default:
                            Console.Write("Saliendo");
                            break;
                    }
                    break;

                //LINQ
                case 4:
                menuLQ:
                    int menuLinq = 0;
                    Console.WriteLine("LINQ \n");
                    Console.WriteLine("1. INSERT");
                    Console.WriteLine("2. UPDATE");
                    Console.WriteLine("3. DELETE");
                    Console.WriteLine("4. SELECT");
                    Console.WriteLine("5. GET BY ID");
                    Console.WriteLine("6. REGRESAR");
                    Console.WriteLine();
                    Console.Write("Selecciona una Opcion: ");
                    int opcionLinq = int.Parse(Console.ReadLine());
                    Console.Clear();
                    switch (opcionLinq)
                    {
                        //INSERT
                        case 1:
                            Console.WriteLine("INSERTAR UN USUARIO\n");
                            PL.Usuario.AddLQ();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuLinq = int.Parse(Console.ReadLine());
                            if (menuLinq == 1)
                            {
                                Console.Clear();
                                goto menuLQ;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //UPDATE
                        case 2:
                            Console.WriteLine("ACTUALIZAR UN USUARIO\n");
                            PL.Usuario.UpdateLQ();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuLinq = int.Parse(Console.ReadLine());
                            if (menuLinq == 1)
                            {
                                Console.Clear();
                                goto menuLQ;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //DELETE
                        case 3:
                            Console.WriteLine("ELIMINAR UN USUARIO\n");
                            PL.Usuario.DeleteLQ();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuLinq = int.Parse(Console.ReadLine());
                            if (menuLinq == 1)
                            {
                                Console.Clear();
                                goto menuLQ;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }

                            break;

                        //LISTA COMPLETA
                        case 4:
                            Console.WriteLine("LISTA DE USUARIOS\n");
                            PL.Usuario.GetAllLQ();
                            //Console.WriteLine("En Proceso");

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuLinq = int.Parse(Console.ReadLine());
                            if (menuLinq == 1)
                            {
                                Console.Clear();
                                goto menuLQ;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //BUSQUEDA
                        case 5:
                            Console.WriteLine("BÚSQUEDA DE USUARIOS\n");
                            PL.Usuario.GetByIdLQ();

                            Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                            menuLinq = int.Parse(Console.ReadLine());
                            if (menuLinq == 1)
                            {
                                Console.Clear();
                                goto menuLQ;
                            }
                            else
                            {
                                Console.Write("Saliendo");
                            }
                            break;

                        //REGRESAR
                        case 6:
                            Console.Clear();
                            goto menuPrincipal;

                        //DEFAULT
                        default:
                            Console.Write("Saliendo");
                            break;
                    }
                    break;

                //DEFAULT
                default:
                    Console.WriteLine("Saliendo");
                    break;
            }
        }

        public static void EntityFramework()
        {
        menuEntity:
            int menuEntity = 0;
            Console.WriteLine("ENTITY FRAMEWORK \n");
            Console.WriteLine("1. INSERT");
            Console.WriteLine("2. UPDATE");
            Console.WriteLine("3. DELETE");
            Console.WriteLine("4. SELECT");
            Console.WriteLine("5. GET BY ID");
            Console.WriteLine();
            Console.Write("Selecciona una Opcion: ");
            int opcionEntity = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (opcionEntity)
            {
                //INSERT
                case 1:
                    Console.WriteLine("INSERTAR UN USUARIO\n");
                    PL.Usuario.AddEF();

                    Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                    menuEntity = int.Parse(Console.ReadLine());
                    if (menuEntity == 1)
                    {
                        Console.Clear();
                        goto menuEntity;
                    }
                    else
                    {
                        Console.Write("Saliendo");
                    }
                    break;

                //UPDATE
                case 2:
                    Console.WriteLine("ACTUALIZAR UN USUARIO\n");
                    PL.Usuario.UpdateEF();

                    Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                    menuEntity = int.Parse(Console.ReadLine());
                    if (menuEntity == 1)
                    {
                        Console.Clear();
                        goto menuEntity;
                    }
                    else
                    {
                        Console.Write("Saliendo");
                    }

                    break;

                //DELETE
                case 3:
                    Console.WriteLine("ELIMINAR UN USUARIO\n");
                    PL.Usuario.DeleteEF();

                    Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                    menuEntity = int.Parse(Console.ReadLine());
                    if (menuEntity == 1)
                    {
                        Console.Clear();
                        goto menuEntity;
                    }
                    else
                    {
                        Console.Write("Saliendo");
                    }

                    break;

                //LISTA COMPLETA
                case 4:
                    Console.WriteLine("LISTA DE USUARIOS\n");
                    PL.Usuario.GetAllEF();

                    Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                    menuEntity = int.Parse(Console.ReadLine());
                    if (menuEntity == 1)
                    {
                        Console.Clear();
                        goto menuEntity;
                    }
                    else
                    {
                        Console.Write("Saliendo");
                    }

                    break;

                //BUSQUEDA
                case 5:
                    Console.WriteLine("BÚSQUEDA DE USUARIOS\n");
                    PL.Usuario.GetByIdEF();
                    //Console.WriteLine("En Proceso");

                    Console.Write("¿Desea realizar otra operación?\nSi(1), No(0): ");
                    menuEntity = int.Parse(Console.ReadLine());
                    if (menuEntity == 1)
                    {
                        Console.Clear();
                        goto menuEntity;
                    }
                    else
                    {
                        Console.Write("Saliendo");
                    }
                    break;

                //DEFAULT
                default:
                    Console.Write("Saliendo");
                    break;
            }
        }

        public static void Suma(double numero1, double numero2, out double resultado)
        {
            resultado = numero1 + numero2;
            Console.WriteLine("El resultado de: " + numero1 + " + " + numero2 + " = " + resultado);
        }

        public static void Resta(double numero1, double numero2, out double resultado)
        {
            resultado = numero1 - numero2;
            Console.WriteLine("El resultado de: " + numero1 + " - " + numero2 + " = " + resultado);
        }

        public static void Division(double numero1, double numero2, out double resultado)
        {
            resultado = numero1 / numero2;
            Console.WriteLine("El resultado de: " + numero1 + " / " + numero2 + " = " + resultado);
        }

        public static void Multiplicacion(double numero1, double numero2, out double resultado)
        {
            resultado = numero1 * numero2;
            Console.WriteLine("El resultado de: " + numero1 + " * " + numero2 + " = " + resultado);
        }

        public static void Operaciones()
        {
            double resultado;
            Console.Write("Escribe un Número: ");
            int numero1 = int.Parse(Console.ReadLine());

            Console.Write("Escribe un Número: ");
            int numero2 = int.Parse(Console.ReadLine());

            Suma(numero1, numero2, out resultado);
            Resta(numero1, numero2, out resultado);
            Multiplicacion(numero1, numero2, out resultado);
            Division(numero1, numero2, out resultado);
        }

        static void Main(string[] args)
        {
            //Menu();
            BL.Text.ReadText();
            Console.ReadKey();
        }
    }
}
