using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO.Models.Services
{
    internal class ClientServices
    {

        public static List<Client> clients= new List<Client>();

        public static void AddClient()  //Creación de la funcion para agregar cliente
        {
            Console.Clear();
            String document = Validation(); //Validacion de documento existente
            if (document != null) // SI ----> El documento no existe
            {
                // Pide datos del cliente
                Console.WriteLine("Porfavor ingrese el nombre:");
                String name = Console.ReadLine();
                Console.WriteLine("Porfavor ingrese el apellido:");
                String lastName = Console.ReadLine();
                Console.WriteLine("Ingrese su numero de telefono");
                String phoneNumber = Console.ReadLine();


                int status = 1; // Asignamos un estado de Activo por defecto

                int id = clients.Count() + 1; // Generamos un Id del cliente unico en nuestra aplicacion

                clients.Add(new Client(id, document,  name, lastName, phoneNumber, status)); // Instancia del objeto y se agrega a la lista
                Console.WriteLine("Cliente agregado correctamente!");
            }
            else // SI -----> El docucumento ya existe
            {
                Console.WriteLine("Este documento ya esta en uso");
            }
            Console.ReadKey();
        }
        public static String Validation() //Creación de la funcion para validar documento
        {
            Console.WriteLine("Porfavor ingrese su numero de documento:"); //Se pide el documento
            String document = Console.ReadLine();
            foreach (var c in clients)  // Se recorre la lista de Clients
            {
                if (c.Document == document) // Valida si el documento ingresado es igual a algun otro registro
                {
                    return null; //Si es igual retorna un Null
                }
            }
            return document; // Si es diferente devuelve el documento para continuar con el registro
        }
        public static Client SearchClient() // Creacion de funcion para buscar cliente por documento
        { 
                Console.WriteLine("Ingrese su documento porfavor: "); //Se pide el documento
            String document = Console.ReadLine();

                foreach (Client client in clients) // Se recorre la lista de Clients
            {
                    if (client.Document == document)// Valida si el documento ingresado es igual a algun otro registro
                {
                        return client; //Si es igual retorna un el cliente

                }
           }
            return null;  //Si es diferente retorna un Null
        }
        public static void DeleteClient()  //Creacion de funcion para eliminar cliente por documento
        {
            Client client = SearchClient(); // Buscamos el cliente por el documento
            if (client != null)  // Si encuentra un cliente con ese documento continua el proceso
            {
                Console.WriteLine($"Esta seguro de querer eliminar a {client.Name} {client.LastName}?\n" +
                        $"Si (1) - Cancelar (0).");
                int option = int.Parse(Console.ReadLine());
                if (option != 1) // Si el usuario ingresa un numero diferente de 1 se cancelara el proceso
                {
                    Console.WriteLine("Proceso cancelado");
                }
                else // Si el usuario ingresa 1 se eliminara el cliente
                {
                    clients.RemoveAt(clients.IndexOf(client));
                    Console.WriteLine("Eliminado correctamente");
                }
            }
        }
        public static void ShowClients()//Creacion de funcion para mostrar todos los registros
        {
            int i = 1;
            foreach (Client c in clients) // Recorre la lista del cliente
            {
                Console.WriteLine( // Imprime cada cliente con toda su informacion
                    $"Cliente #{i}:\nId: {c.ClientId}, Documenot: {c.Document}, Nombre: {c.Name}," +
                    $" Apellido: {c.LastName}" +
                    $"Telefono: {c.Phone}, " +
                    $"Estado: {c.Status}.\n");
                    i++;
                }
        }
        public static void EditClient()//Creacion de funcion para editar cliente por documento
        {
                Client c = SearchClient(); // Buscamos el cliente por el documento
            if (c != null) // Si encuentra un cliente con ese documento continua el proceso
            {
                    Console.WriteLine("Que atributo desea editar? Documento (1) - Nombre (2) - " +
                        "Apellido (3) - Telefono (4) - Estado (5) - Cancelar - (6)");
                    int option = int.Parse(Console.ReadLine()); // Pregunta que atributo desea editar
                    Console.Clear();
                    switch (option) // Segun la opcion edita el campo
                    {
                        case 1:
                            bool condition = true;
                            while (condition)
                            {
                                Console.Clear();
                                Console.WriteLine("Ingrese su numero de documento:");
                                String document = Console.ReadLine();
                                bool flag = false;
                                foreach (Client co in clients)
                                {
                                    if (co.Document == document)
                                    {
                                        condition = true;
                                        Console.WriteLine("Este documento ya esta en uso" +
                                            "Intenta con uno diferente.\nDe nuevo (1) - Salir (0).");
                                        int decision = int.Parse(Console.ReadLine());
                                        if (decision != 1)
                                        {
                                            flag = false;
                                            condition = false;
                                            Console.WriteLine("Cancelado");
                                        }
                                    }
                                    else
                                    {
                                        flag = true;
                                        condition = false;
                                    }
                                }
                                if (flag)
                                {
                                    c.Document = document;
                                    Console.WriteLine("Documento editado correctamente");
                                }
                            }
                            break;
                        case 2:
                            Console.WriteLine("Porfavor ingrese su nombre:"); // Pide dato nuevo
                            String name = Console.ReadLine();
                            c.Name = name; // Asigna el dato nuevo
                            Console.WriteLine("Nombre editado correctamente");
                            break;
                        case 3:
                            Console.WriteLine("Porfavor ingrese su apellido:"); // Pide dato nuevo
                        String lastName = Console.ReadLine();
                            c.LastName = lastName; // Asigna el dato nuevo
                        Console.WriteLine("Apellido editado correctamente");
                            break;
                        case 4:
                            Console.WriteLine("Porfavor ingrese su telefono"); // Pide dato nuevo
                        String phoneNumber = Console.ReadLine();
                            c.Phone = phoneNumber; // Asigna el dato nuevo
                        Console.WriteLine("Telefono editado correctamente");
                            break;
                        case 5:
                            Console.WriteLine("Porfavor ingrese el estado\n Activo (1) - Inactivo (0).");
                            int desicion = int.Parse(Console.ReadLine());
                            int status;
                            if (desicion != 1)
                            {
                                status = 0;
                            }
                            else
                            {
                                status = 1;
                            }
                            c.Status = status;
                            Console.WriteLine("Estado editado correctamente");
                            break;

                    case 6:
                            Console.WriteLine("Cancelado");
                            break;
                        default:
                            Console.WriteLine("Opcion erronea, el proceso se cancelara");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Cliente no encontrado.");
                }
        }

    }
}
