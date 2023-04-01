using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace POO.Models
{
    internal class Client
    {

        public int ClientId {set; get;}
        public string Document {set; get; }
        public string Name {set; get; }
        public string LastName {set; get; }
        public string Phone {set; get; }
        public int  Status {set; get; }


        //Recibimos los parametros del contructor
        public Client(int id, string document, string name, string lastName, string phone, int status)
        {
            //Asignamos el valor que nos mandan a las variables de nuestro
            //modelo para la instancia de un objeto
            ClientId = id;
            Document = document;
            Name = name;
            LastName = lastName;
            Phone = phone;
            Status = status;
        }


        //Metodo toString es el encargado de imprimir nuestro objeto por consola
        public override string ToString()
        {

            //Este sera el formato en el cual se mostrara el objeto en consola
            return string.Format(
                $"Documento : {Document}\n"+
                $"Nombre : {Name}\n" +
                $"Apellido : {LastName}\n" +
                $"Telefono : {Phone}\n" +
                $"Estado : {Status}\n");
        }

    }
}
