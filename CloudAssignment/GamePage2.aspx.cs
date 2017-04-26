using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudAssignment
{
    public partial class GamePage2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Add("numberOfPlayers", "One");
                Label1.Text = "SELECT PLAYER ONE";
    
            }

        }




        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string checker = Session["numberOfPlayers"] as string;
            if (checker == "One")
            {
                var partKey = GridView2.SelectedRow.Cells[3].Text;
                var rowKey = GridView2.SelectedRow.Cells[4].Text;
                Session.Add("chosenPlayerOne", GridView2.SelectedRow.Cells[2].Text + "-" + GridView2.SelectedRow.Cells[3].Text + "-" + GridView2.SelectedRow.Cells[4].Text);
                GridView2.SelectedRow.Visible = false;
                Session.Remove("numberOfPlayers");
                Label1.Text = "NOW SELECT PLAYER TWO";
  

            }
            else
            {
                var partKey = GridView2.SelectedRow.Cells[3].Text;
                var rowKey = GridView2.SelectedRow.Cells[4].Text;
                Session.Add("chosenPlayerTwo", GridView2.SelectedRow.Cells[2].Text + "-" + GridView2.SelectedRow.Cells[3].Text + "-" + GridView2.SelectedRow.Cells[4].Text);


                Response.Redirect("GamePage.aspx");
            }
        }
    }
}