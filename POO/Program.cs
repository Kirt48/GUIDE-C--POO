using POO.Models.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool option = true; 
            while (option)
            {
                Console.Clear();
                Console.WriteLine("MENU");
                Console.WriteLine("Que desea hacer?");
                Console.WriteLine("1 - Agregar cliente \n2 - Editar cliente \n3 - Eliminar cliente \n4 - Mostrar clientes \n5 - Cerrar el programa \n");
                string election = Console.ReadLine();
                switch (election)
                {
                    case "1": 
                        ClientServices.AddClient();
                        break;
                    case "2":
                        ClientServices.EditClient();
                        break;
                    case "3":
                        ClientServices.DeleteClient();
                        break;
                    case "4":
                        ClientServices.ShowClients();
                        break;
                    case "5":
                        option= false;
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta");
                        break;

                }
            }
        }
    }
}
