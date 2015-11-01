using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empleados
{
    public class ExcepcionEstudios : Exception
    {
        public ExcepcionEstudios(String msg) : base (msg){ }
    }
}
