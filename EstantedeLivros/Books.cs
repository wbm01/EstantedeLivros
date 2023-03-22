using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstantedeLivros
{
    internal class Books
    {
        public string Name { get; set; }
        public string Edition { get; set; }
        public  string Writer { get; set; }
        public string ?Writer2 { get; set; }
        public string ISBN { get; set; }
        public bool Lent { get; set; }

        public bool Reading { get; set; }

        public Books(string name, string edition, string writer, string writer2, string isbn)
        {

            this.Name = name;
            this.Edition = edition;
            this.Writer = writer;
            this.Writer2 = writer2;
            this.ISBN = isbn;
        }

            

        
        public override string ToString()
        {
            return "Nome: " + Name + " | " + "Editora: " + Edition + " | " + "Autor 1: " + Writer
                + " | " + "Autor 2: " + Writer2 + " | " + "ISBN: " + ISBN + "*";
        }
    }
}
