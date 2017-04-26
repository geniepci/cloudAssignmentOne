using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CloudAssignment
{
    public partial class LoginBasic : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Remove("loggedIn");
            Session.Remove("userName");
            Session.Add("loggedIn", "yes");
            Session.Add("userName", Email.Text);
            Response.Redirect("default.aspx");
        }
    }
        }
    
