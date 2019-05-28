using System;

namespace agenda 
{
    class ControlConsola 
    {

        private Agenda agenda = new Agenda();
        private string mensaje = 
            "\n" +
            "COMANDOS\n" +
            "-----------------------------------------------\n" +
            "Cerrar el programa:                       salir\n" +
            "Mostrar agenda:                         mostrar\n" +
            "Ingresar datos:                        ingresar\n" +
            "Modificar datos:                      modificar\n" +
            "Borrar entrada:                          borrar\n" +
            "-----------------------------------------------"; 

        public void IniciarConsola() 
        {
            bool exit = false; 

            Console.WriteLine(mensaje);

            while(exit == false) 
            {
                Console.WriteLine("");
                Console.WriteLine("Ingrese un comando: ");
                string comando = Console.ReadLine().ToString();
                Console.WriteLine("");

                switch(comando) 
                {
                    case "salir":
                        exit = true;
                        break;

                    case "mostrar":
                        agenda.LeerDiccionario();
                        break;

                    case "ingresar":
                        IngresarDatos();
                        break;

                    case "modificar":
                        ModificarDatos();
                        break;
                        
                    case "borrar":
                        BorrarDatos();
                        break;

                    default:
                        Console.WriteLine("Ingrese un comando valido");
                        break;
                }
            }
        }

        private void IngresarDatos()
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine().ToString();
            Console.WriteLine("Telefono: ");
            int numero;
            if (int.TryParse(Console.ReadLine(), out numero)) 
            {
                agenda.GuardarEnDiccinario(nombre, numero);
            }
            else 
            {
                Console.WriteLine("Los datos ingresados son invalidos");
            }
        }

        private void ModificarDatos() 
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine().ToString();
            if (agenda.ExisteNombre(nombre)) 
            {
                Console.WriteLine("Nuevo telefono: ");
                try 
                {
                    int nuevoTelefono = int.Parse(Console.ReadLine());
                    agenda.ModificarEntrada(nombre, nuevoTelefono);
                    Console.WriteLine("La entrada fue modificada exitosamente");
                }

                catch 
                {
                    Console.WriteLine("El numero ingresado no es valido");
                }
            }

            else 
            {
                Console.WriteLine("El nombre buscado no existe");
            }
        }

        private void BorrarDatos() 
        {
            Console.WriteLine("Nombre: ");
            string nombre = Console.ReadLine().ToString();

            // 1 Verifico que nombre exista
            if (agenda.ExisteNombre(nombre))
            {
                agenda.BorrarEntradaDiccionario(nombre);
                Console.WriteLine("La entrada fue borrar exitosamente.");
            }

            else 
            {
                Console.WriteLine("El nombre buscado no existe");
            }
        }
     }
}