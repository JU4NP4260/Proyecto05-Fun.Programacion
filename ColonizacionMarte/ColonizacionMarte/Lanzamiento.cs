using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColonizacionMarte
{
    class Lanzamiento
    {
        public string planicie { get; set; }
        public float carga { get; set; }

        public Lanzamiento()
        {
            planicie = "";
            carga = 0;
        }
    }
}
