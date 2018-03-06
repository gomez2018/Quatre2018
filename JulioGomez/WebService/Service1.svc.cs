using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSTestAsp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSTestAsp.svc or WSTestAsp.svc.cs at the Solution Explorer and start debugging.
    public class WSTestAsp : IWSTestAsp
    {
        public Corresponsal getCorresponsal(int CodCorresponsal, string NombreCorresponsal)
        {
            Corresponsal corresponsal1 = new Corresponsal();

            corresponsal1.CodCorresponsal = CodCorresponsal;
            corresponsal1.NombreCorresponsal = NombreCorresponsal;

            return corresponsal1;
        }
    }
}
