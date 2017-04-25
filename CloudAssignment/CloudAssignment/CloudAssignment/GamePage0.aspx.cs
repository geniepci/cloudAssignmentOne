using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using Microsoft.WindowsAzure.Storage.Blob;

namespace CloudAssignment
{
    public partial class GamePage0 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string checker = Session["loggedIn"] as string;
            if (checker == "yes")
            {
                Response.Redirect("GamePage1a.aspx");
            }


            else
            {
                Label1.Text = "Please login to play the game";
            }

        }
    }
}