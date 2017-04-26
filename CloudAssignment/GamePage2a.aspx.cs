using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CloudAssignment
{
    public partial class GamePage2a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Session.Add("numberOfPlayers", "One");
                Label1.ForeColor = System.Drawing.Color.Black;
                Label1.Text = "SELECT PLAYER ONE";
    
            }

            if (GridView2.Rows.Count == 0)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "PLEASE CREATE TWO PLAYERS TO PLAY THE GAME";
            }


            if (GridView2.Rows.Count == 1)
            {
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "PLEASE CREATE TWO PLAYERS TO PLAY THE GAME";
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