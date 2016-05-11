using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Certification_System.Error
{
    public partial class ErrorInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Error"] != null)
            {
                errorDetailLabel.Text = Session["Error"].ToString();
            }
            else
            {
                Response.Redirect("~/UCRMSHome/Home.html");
            }
        }
    }
}