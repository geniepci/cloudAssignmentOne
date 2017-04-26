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
    public partial class Players0 : System.Web.UI.Page
    {
        // Get storage connection string. LOCAL: Storage Emulator. CLOUD: Azure Storage Account.
        private string StorageConnectionString3
        {
            get
            {

                return "DefaultEndpointsProtocol=https;AccountName=ashleyeasterbrook;AccountKey=XXOwxxid/rXYtS+Wd2QSn5jEmCLRzEnqbZVcAu7jqDzgbercrVzMadvAjEQXcwADylWdidGLDdfdbu7Hz664UQ==";
                //return "UseDevelopmentStorage=true";
            }
        }


        private int GetNextPlayerRowKey()
        {
            string partKey = Session["userName"] as string;
            CloudTable getCategoryTable = GetPlayersCloudTable();
            //string partKey = Session
            TableQuery<CategoryEntity> query = new TableQuery<CategoryEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partKey));
            List<int> outcome = new List<int> { };
            foreach (CategoryEntity entity in getCategoryTable.ExecuteQuery(query))
            {
                outcome.Add(Convert.ToInt16(entity.RowKey));
            }

            if (outcome.Count == 0)
            {
                return 1;
            }

            else
            {
                outcome.Sort();
                outcome.Reverse();
                int newRowKey = 1 + Convert.ToInt16(outcome[0]);
                return newRowKey;
            }
        }


        protected void addPlayer_Click(object sender, EventArgs e)
        {
            if (!IsPostBack) { return; } //  Stops inserting when it refreshes.

            if (txtPlayerName.Text == "" || PhotoUpload.HasFile == false)
            {
                Label1.Text = "Please complete all sections and add an image.";
            }

            else
            {
                // Create player object from data.
                Label1.Text = "";
                PlayersEntity insertPlayer = new PlayersEntity();
                insertPlayer.PartitionKey = Session["userName"] as string;
                insertPlayer.PlayerName = txtPlayerName.Text;
                insertPlayer.Wins = "0";
                insertPlayer.Losses = "0";


                int newRowKey = GetNextPlayerRowKey();
                insertPlayer.RowKey = Convert.ToString(newRowKey);
                // Get Cloud Table object for Players Table.
                CloudTable myPlayersCloudTable = GetPlayersCloudTable();


                // Create Table Operation to insert new Player Entity.
                TableOperation insertOperation = TableOperation.Insert(insertPlayer);

                //Adds the photo
                if (PhotoUpload.HasFile)
                {
                    CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
                    CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(insertPlayer.PartitionKey + "-" + insertPlayer.RowKey);
                    myBlobIdentity.UploadFromStream(PhotoUpload.FileContent);
                    insertPlayer.ImageURI = myBlobIdentity.Uri.ToString();
                }
                else
                {
                    insertPlayer.ImageURI = string.Empty;

                }

                // Insert new player into Players Table.
                myPlayersCloudTable.Execute(insertOperation);


                // Update web form. Clear text boxes.
                txtPlayerName.Text = string.Empty;


                dataListPlayers.DataBind();
            }
  
        }

     
        

        public IEnumerable<PlayersEntity> GetPlayers()
        {
            string partKey = Session["userName"] as string;

            // Get Cloud Table object for Players Table.
            CloudTable myPlayersCloudTable = GetPlayersCloudTable();


            // Create a Table Query object.
            TableQuery<PlayersEntity> myTableQuery =
            new TableQuery<PlayersEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partKey));


            // Get list from Players Table.
            IEnumerable<PlayersEntity> playersList =
            myPlayersCloudTable.ExecuteQuery(myTableQuery);


            // Sort in reverse chronological order.
            playersList = playersList.OrderByDescending(msg => msg.Timestamp);

            // Output to data list on web form.
            return playersList;

        }

        public IEnumerable<PlayersEntity> GetPlayerScores()
        {
            string partKey = Session["userName"] as string;

            // Get Cloud Table object for Players Table.
            CloudTable myPlayersCloudTable = GetPlayersCloudTable();


            // Create a Table Query object.
            TableQuery<PlayersEntity> myTableQuery =
            new TableQuery<PlayersEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partKey));


            // Get list from Players Table.
            IEnumerable<PlayersEntity> playersList =
            myPlayersCloudTable.ExecuteQuery(myTableQuery);


            // Sort in reverse chronological order.
            playersList = playersList.OrderByDescending(msg => msg.Wins);

            // Output to data list on web form.
            return playersList;

        }


        private CloudTable GetPlayersCloudTable()
        {
            // Access cloud storage account. Uses connection string obtained above.
            CloudStorageAccount myCloudStorageAccount =
            CloudStorageAccount.Parse(StorageConnectionString3);


            // Create cloud table client. Provides access to Tables in your Storage Account 
            CloudTableClient myCloudTableClient =
            myCloudStorageAccount.CreateCloudTableClient();


            // Get Cloud Table for Player Table.
            CloudTable myPlayersCloudTable =
            myCloudTableClient.GetTableReference("PlayerTable");

            // Create Players Table if it does not already exist. 
            myPlayersCloudTable.CreateIfNotExists();


            // Output Players Cloud Table object. Provides the means of accessing the Players Table.
            return myPlayersCloudTable;

        }

        private CloudBlobContainer GetImagesBlobContainer()
        {
            // Access cloud storage account. Uses connection string obtained above.
            CloudStorageAccount myCloudStorgageAccount = CloudStorageAccount.Parse(StorageConnectionString3);

            // Create the blob client.
            CloudBlobClient myCloudBlobClient = myCloudStorgageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container.
            CloudBlobContainer myPlayersCloudBlob = myCloudBlobClient.GetContainerReference("thegameblobs");

            // Create the container if it doesn't already exist.
            myPlayersCloudBlob.CreateIfNotExists();

            //The purpose of the this code is to make the images in your container publicly accessible. Without it you would not be able to see the images in your application or by using their URLs.
            myPlayersCloudBlob.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });


            return myPlayersCloudBlob;
        }

 

        protected void Page_Load(object sender, EventArgs e)
        {

        }

 
    }
}