using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QVPrjManager.Models
{
    class VariableStat
    {
        public string QVWName { get; set; }
        /// <summary>
        /// Total # of Variables in QVW
        /// </summary>
        public int NumVariables { get; set; }
        /// <summary>
        /// # of Used Variables in QVW
        /// </summary>
        public int NumUsed { get; set; }
        /// <summary>
        /// # of Times Variables are used in QVW
        /// </summary>
        public int NumUses { get; set; }
        /// <summary>
        /// # of Un-Used Variables in QVW
        /// </summary>
        public int NumUnUsed { get; set; }
        /// <summary>
        /// Index of the grid row in use
        /// </summary>
        public int GridRowIdx { get; set; }
    }
}
