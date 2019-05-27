using System.Collections.Generic;
using System.IO;
using System;
using System.Linq;

namespace agenda
{
    public class Agenda
    {
        private Dictionary<string, int> agenda = new Dictionary<string, int>();
        private string path = @"C:\Users\gastonb\proyects\agenda\agenda.txt";


        public Agenda() 
        {
            if (!(LeerArchivo())) // ! Si no se pudo leer el archivo 
            {
                Console.WriteLine("No se pudo leer el archivo. Por favor cierre el programa. ");
            }
        }

        private void GuardarEnDiccinario(string linea) 
        {
            string[] entrada = linea.Split(" - ");
            if (!(agenda.ContainsKey(entrada[0]))) /// Si la agenda no contiene esa nombre
            {
                agenda.Add(entrada[0], int.Parse(entrada[1]));
            }
        }

        public void GuardarEnDiccinario(string nombre, int telefono)
        {
            if(!(agenda.ContainsKey(nombre))) // Si la agenda no contiene ese nombre
            {
                agenda.Add(nombre, telefono);
            }

            else 
            {
                Console.WriteLine("Ese nombre ya existe");
            }
        }

        public void LeerDiccionario()
        {
            if (agenda.Count == 0) 
            {
                Console.WriteLine("La agenda esta vacia");
            }
            foreach(string key in agenda.Keys)
            {
                Console.WriteLine(key + ": " + agenda[key]); 
            }
        }

        public bool LeerArchivo() 
        {
            try 
            {
                string[] entradas = File.ReadAllLines(path);

                foreach(string linea in entradas) 
                {
                    GuardarEnDiccinario(linea);
                }

                return true; 
            }

            catch 
            {
                return false; 
            }
        }

        public void EscribirArchivo() 
        {
            string[] datosAgenda = new string[agenda.Count];
            int index = 0;

            foreach (string key in agenda.Keys) 
            {
                datosAgenda[index] = (key + " - " + agenda[key].ToString());
                index++;
            }

            File.WriteAllLines(path, datosAgenda);
        }
    }
}