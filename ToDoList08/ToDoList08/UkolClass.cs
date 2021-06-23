using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList08
{
    class UkolClass
    {
        public static HashSet<UkolClass> ukoly = new HashSet<UkolClass>();
        public string cinnost { get; set; }
        public string info { get; set; }
        public DateTime datum { get; set; }
        public bool splneno { get; set; }
        public string test
        {
            get
            {
                return cinnost;
            }
        }
        public override int GetHashCode()
        {
            return test.GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (test == ((UkolClass)obj).test)
            {
                return true;
            }
            return false;
        }
    }
}
