using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diplom_Posledmnii
{
   public class ScriptingPostgreSql
    {
        public ScriptingPostgreSql(string scripting)
        {
            this.scripting = scripting;
        }

        public string scripting { get; set; }
    }
}
