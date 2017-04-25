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
    public partial class GamePage1a : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This resets the session data in case the player has used the menu bar to leave the game
            Session.Remove("chosenPlayerOne");
            Session.Remove("chosenPlayerTwo");
            Session.Remove("chosenCategory");
            Session.Remove("playerOneDetails");
            Session.Remove("playerTwoDetails");
            Session.Remove("whoseTurn");
            Session.Remove("playerOneCard");
            Session.Remove("playerTwoCard");
            Session.Remove("playerOneHand");
            Session.Remove("playerTwoHand");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var partKey = GridView1.SelectedRow.Cells[3].Text;
            var rowKey = GridView1.SelectedRow.Cells[4].Text;
            Session.Add("chosenCategory", GridView1.SelectedRow.Cells[2].Text + "-" + GridView1.SelectedRow.Cells[3].Text + "-" + GridView1.SelectedRow.Cells[4].Text);
            //Need to check the total card number for the category
            //If the category has less than 4 cards it makes the game unplayable. Even four is pretty rubbish.       
            int checker = ListAllCards(GridView1.SelectedRow.Cells[3].Text + GridView1.SelectedRow.Cells[4].Text);
            if (checker > 3)
            {
                Response.Redirect("GamePage2a.aspx");
            }

            else
            {
                Label1.Text = "The Category Does Not Have Enough Cards - Please Add More or Choose Another";
            }

  

        }

        private string StorageConnectionString
        {
            get
            {
                return "DefaultEndpointsProtocol=https;AccountName=ashleyeasterbrook;AccountKey=XXOwxxid/rXYtS+Wd2QSn5jEmCLRzEnqbZVcAu7jqDzgbercrVzMadvAjEQXcwADylWdidGLDdfdbu7Hz664UQ==";

                //return "UseDevelopmentStorage=true";
            }
        }

        private CloudTable GetTable(string tableName)
        {
            CloudStorageAccount gameStorage = CloudStorageAccount.Parse(StorageConnectionString);
            CloudTableClient gameTable = gameStorage.CreateCloudTableClient();
            CloudTable table = gameTable.GetTableReference(tableName);
            table.CreateIfNotExists();
            return table;
        }


        private int ListAllCards(string cardPartKey)
        {
         
            CloudTable getCardTable = GetTable("CardTable");
            TableQuery<CategoryEntity> query = new TableQuery<CategoryEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, cardPartKey));
            int x = 0;
            foreach (CategoryEntity entity in getCardTable.ExecuteQuery(query))
            {
                x = x + 1;
            }

            return x;
        }
    }
}