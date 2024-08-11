using EmpanadasApp.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpanadasApp.Logica
{
    public class CNTipoE
    {
        private CDTipoE objecTipoe = new CDTipoE();

        public List<CTipoE>Listar()
        {
            return objecTipoe.Listar();
        }
    }
}
