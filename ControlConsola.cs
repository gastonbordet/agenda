using System;

namespace agenda 
{
    class ControlConsola 
    {
        private string mensaje = 
            "\n" +
            "COMANDOS\n" +
            "-----------------------------------------------\n" +
            "Cerrar el programa:                       salir\n" +
            "Mostrar agenda:                         mostrar\n" +
            "-----------------------------------------------"; 

        public void IniciarConsola() 
        {
            Agenda agenda = new Agenda();
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

                    default:
                        break;
                }
            }
        }
    }
}