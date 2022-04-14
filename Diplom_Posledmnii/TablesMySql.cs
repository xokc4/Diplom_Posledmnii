using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Posledmnii
{
   public  class TablesMySql
    {
        public TablesMySql(string nameTable)
        {
            NameTable = nameTable;
        }

        public string NameTable { get; set; }

    }
}
