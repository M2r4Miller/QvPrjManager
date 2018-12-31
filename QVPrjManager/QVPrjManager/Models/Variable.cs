using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVPrjManager.Models
{
    class Variable
    {
        public string VariableName { get; set; }
        public bool IsUsed { get; set; }
        public string ObjectName { get; set; }
        public string SheetName { get; set; }
    }
}
