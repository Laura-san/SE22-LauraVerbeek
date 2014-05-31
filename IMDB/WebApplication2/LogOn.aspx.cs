using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class LogOn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            btn_logon.Enabled = false;
            btn_AddActor.Visible = false;
            btn_AddMovie.Visible = false;
        }
    }
}