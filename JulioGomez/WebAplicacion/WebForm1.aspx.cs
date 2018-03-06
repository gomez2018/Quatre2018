using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebAplicacion
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            WebServiceCorresponsal.WSTestAspClient servicio = new WebServiceCorresponsal.WSTestAspClient();

            var corresponsal = servicio.getCorresponsal(1, "Argentina");

            //lblCodCorresponsal.Text = corresponsal.CodCorresponsal.ToString();
            //lblNombreCorresponsal.Text = corresponsal.NombreCorresponsal;

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient WS = new ServiceReference1.WebService1SoapClient();
            DataSet ds = WS.GetData();
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataBind();
        }
    }
}