using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;

namespace WebServiceJulioGomez
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public DataSet GetData()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=mugiwaraPC; Initial Catalog=cmmoneycash; Integrated Security=True; User id=sa;Password=123456;";
            SqlDataAdapter da = new SqlDataAdapter("select * from corresponsales", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;

        }

        [WebMethod]
        public DataSet GetCorresponsales()
        {

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=mugiwaraPC; Initial Catalog=cmmoneycash; Integrated Security=True; User id=sa;Password=123456;";
            SqlDataAdapter da = new SqlDataAdapter("select C.COR_CORRESPONSAL_ID, C.COR_NOMBRE + ' - ' + CAST(count(O.OFI_CORRESPONSAL_ID) AS varchar) NOMBRE from CORRESPONSALES C inner join OFICINAS O(NOLOCK)ON C.COR_CORRESPONSAL_ID = O.OFI_CORRESPONSAL_ID GROUP BY C.COR_CORRESPONSAL_ID, C.COR_NOMBRE, O.OFI_CORRESPONSAL_ID", conn);
            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds;
        }

    }
}
