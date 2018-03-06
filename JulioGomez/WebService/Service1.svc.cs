using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "WSTestAsp" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select WSTestAsp.svc or WSTestAsp.svc.cs at the Solution Explorer and start debugging.
    public class WSTestAsp : IWSTestAsp
    {
        public List<Corresponsales> GetCorresponsales()
        {
            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Local"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("select C.COR_CORRESPONSAL_ID, C.COR_NOMBRE, count(O.OFI_CORRESPONSAL_ID) OFICINAS from CORRESPONSALES C inner join OFICINAS O(NOLOCK)ON C.COR_CORRESPONSAL_ID = O.OFI_CORRESPONSAL_ID GROUP BY C.COR_CORRESPONSAL_ID, C.COR_NOMBRE, O.OFI_CORRESPONSAL_ID", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Corresponsales> lista = new List<Corresponsales>();
                Corresponsales cor;

                while (dr.Read())
                {
                    cor = new Corresponsales();
                    cor.COR_CORRESPONSAL_ID = Convert.ToInt32(dr[0]);
                    cor.COR_NOMBRE = dr[1].ToString();
                    lista.Add(cor);
                }
                return lista;
            }
        }

        public List<Oficinas> GetOficinas()
        {
            using (SqlConnection cn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Local"].ToString()))
            {
                SqlCommand cmd = new SqlCommand("select * from [dbo].[OFICINAS]", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                List<Oficinas> lista2 = new List<Oficinas>();
                Oficinas ofc;

                while (dr.Read())
                {
                    ofc = new Oficinas();
                    ofc.OFI_CORRESPONSAL_ID = Convert.ToInt32(dr[0]);
                    ofc.OFI_NOMBRE = dr[1].ToString();
                    lista2.Add(ofc);
                }
                return lista2;

            }
        }

    }
}
