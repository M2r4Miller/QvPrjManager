using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QVPrjManager.Models
{
    class Settings
    {
        public string ExecutePath { get; set; }
        public Settings()
        {
            ExecutePath = Path.GetDirectoryName(Application.ExecutablePath);
        }
    }
}
