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

    public partial class DeveloperPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //This is needed to stop this code being called every time a button is clicked
            if (!IsPostBack)
            {
                categoryList.Visible = false;
                cardList.Visible = false;


                Label12.Visible = false;
                Label10.Visible = false;

                HideBoxesAndButtons();
                categoryList.Items.Clear();

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


        private string HideBoxesAndButtons()
        {
            categoryList.Visible = false;
            cardList.Visible = false;
            chooseCategory.Visible = false;
            chooseCard.Visible = false;
            createCategory.Visible = false;
            createCard.Visible = false;
            updateCategory.Visible = false;
            updateCard.Visible = false;
            deleteCategory.Visible = false;
            deleteCard.Visible = false;
            nameTxtBox.Visible = false;
            nameTxtBox.Text = "";
            attributeOneTxtBox.Visible = false;
            attributeOneTxtBox.Text = "";
            attributeTwoTxtBox.Visible = false;
            attributeTwoTxtBox.Text = "";
            attributeThreeTxtBox.Visible = false;
            attributeThreeTxtBox.Text = "";
            attributeFourTxtBox.Visible = false;
            attributeFourTxtBox.Text = "";
            attributeFiveTxtBox.Visible = false;
            attributeFiveTxtBox.Text = "";
            blobUpload.Visible = false;
            blobImage.Visible = false;
            Label3.Text = "";
            Label4.Text = "";
            Label5.Text = "";
            Label6.Text = "";
            Label7.Text = "";
            Label8.Text = "";
            Label9.Text = "";
            Label10.Visible = false;
            Label11.Text = "";
            Label12.Visible = false;
            return string.Empty;
        }
        
        private CloudTable GetTable(string tableName)
        {
            // Retrieves the storage account from the connection string.
            CloudStorageAccount gameStorage = CloudStorageAccount.Parse(StorageConnectionString);
            // Creates the table client.
            CloudTableClient gameTable = gameStorage.CreateCloudTableClient();
            // Retrieve a reference to the table via the string tableName used when calling the method
            CloudTable table = gameTable.GetTableReference(tableName);
            // Create the table if it doesn't exist - important to stop the game crashing
            table.CreateIfNotExists();
            return table;
        }

        private string ListAllCategories()
        {
            categoryList.Items.Clear();
            CloudTable getCategoryTable = GetTable("CategoryTable");
            TableQuery<CategoryEntity> query = new TableQuery<CategoryEntity>();//Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, categoryPartKey));
            foreach (CategoryEntity entity in getCategoryTable.ExecuteQuery(query))
            {
                categoryList.Items.Add(Convert.ToString(entity.Name) + "-" + Convert.ToString(entity.PartitionKey) + "-" + Convert.ToString(entity.RowKey));

            }

            return string.Empty;
        }



        private string ListAllCards(string cardPartKey)
        {
            cardList.Items.Clear();
            CloudTable getCardTable = GetTable("CardTable");
            TableQuery<CategoryEntity> query = new TableQuery<CategoryEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, cardPartKey));
            foreach (CategoryEntity entity in getCardTable.ExecuteQuery(query))
            {
                cardList.Items.Add(Convert.ToString(entity.Name) + "-" + Convert.ToString(entity.RowKey));

            }

            return string.Empty;
        }

        private int GetNextCategoryRowKey(string categoryPartKey)
        {
            //Retrieves the Category Table
            CloudTable getCategoryTable = GetTable("CategoryTable");
            //Then locates the category partition key that has been sent
            TableQuery<CategoryEntity> query = 
                new TableQuery<CategoryEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, categoryPartKey));
            List<int> outcome = new List<int> { };
            //If the result is 0 then no key has been sent and this is the first instance of the category

            foreach (CategoryEntity entity in getCategoryTable.ExecuteQuery(query))
            {
                outcome.Add(Convert.ToInt16(entity.RowKey));
            }

            //If the result is 0 then no key has been sent and this is the first instance of the category
            if (outcome.Count == 0)
            {
                return 1;
            }
            //if the result is higher than one then it lists the row keys
            else
            {
                //Puts the row keys in ascending order
                outcome.Sort();
                //Puts the row keys in descending order by reversing the above
                outcome.Reverse();
                //Adds one so the first rowKey in the list (ie the last row key number) so it is one more than the last one
                int newRowKey = 1 + Convert.ToInt16(outcome[0]);
                //Then returns the new row key
                return newRowKey;
            }

        }

        //As above but for the card row key
        private int GetNextCardRowKey(string cardPartKey)
        {
            CloudTable getCardTable = GetTable("CardTable");
            TableQuery<CardEntity> query = new TableQuery<CardEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, cardPartKey));
            List<int> outcome = new List<int> { };
            foreach (CardEntity entity in getCardTable.ExecuteQuery(query))
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

        private string populateCategoryTitles(string partKey, string rowKey)
        {
            CloudTable getCategoryTable = GetTable("CategoryTable");
            TableOperation retrieveOperation = TableOperation.Retrieve<CategoryEntity>(partKey, rowKey);
            TableResult retrievedResult = getCategoryTable.Execute(retrieveOperation);
            nameTxtBox.Visible = true;
            attributeOneTxtBox.Visible = true;
            attributeTwoTxtBox.Visible = true;
            attributeThreeTxtBox.Visible = true;
            attributeFourTxtBox.Visible = true;
            attributeFiveTxtBox.Visible = true;
            Label3.Text = "Card Name";
            Label4.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameOne;
            Label5.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameTwo;
            Label6.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameThree;
            Label7.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameFour;
            Label8.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameFive;




            return string.Empty;
        }

        private string populateCategoryData(string partKey, string rowKey)
        {
            CloudTable getCategoryTable = GetTable("CategoryTable");
            TableOperation retrieveOperation = TableOperation.Retrieve<CategoryEntity>(partKey, rowKey);
            TableResult retrievedResult = getCategoryTable.Execute(retrieveOperation);
            nameTxtBox.Visible = true;
            attributeOneTxtBox.Visible = true;
            attributeTwoTxtBox.Visible = true;
            attributeThreeTxtBox.Visible = true;
            attributeFourTxtBox.Visible = true;
            attributeFiveTxtBox.Visible = true;
            Label3.Text = "Category Name";
            Label4.Text = "Name of First Attribute";
            Label5.Text = "Name of Second Attribute";
            Label6.Text = "Name of Third Attribute";
            Label7.Text = "Name of Fourth Attribute";
            Label8.Text = "Name of Fifth Attribute";
            nameTxtBox.Text = ((CategoryEntity)retrievedResult.Result).Name;
            attributeOneTxtBox.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameOne;
            attributeTwoTxtBox.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameTwo;
            attributeThreeTxtBox.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameThree;
            attributeFourTxtBox.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameFour;
            attributeFiveTxtBox.Text = ((CategoryEntity)retrievedResult.Result).AttributeNameFive;




            return string.Empty;
        }

        private string populateCardData(string partKey, string rowKey)
        {
            CloudTable getCardTable = GetTable("CardTable");
            TableOperation retrieveOperation = TableOperation.Retrieve<CardEntity>(partKey, rowKey);
            TableResult retrievedResult = getCardTable.Execute(retrieveOperation);
            nameTxtBox.Text = ((CardEntity)retrievedResult.Result).Name;
            attributeOneTxtBox.Text = ((CardEntity)retrievedResult.Result).AttributeOne;
            attributeTwoTxtBox.Text = ((CardEntity)retrievedResult.Result).AttributeTwo;
            attributeThreeTxtBox.Text = ((CardEntity)retrievedResult.Result).AttributeThree;
            attributeFourTxtBox.Text = ((CardEntity)retrievedResult.Result).AttributeFour;
            attributeFiveTxtBox.Text = ((CardEntity)retrievedResult.Result).AttributeFive;
            return string.Empty;
        }


        private string ClearTextBoxes()
        {
            attributeOneTxtBox.Text = string.Empty;
            attributeTwoTxtBox.Text = string.Empty;
            attributeThreeTxtBox.Text = string.Empty;
            attributeFourTxtBox.Text = string.Empty;
            attributeFiveTxtBox.Text = string.Empty;
            nameTxtBox.Text = string.Empty;
            return string.Empty;
        }

        private CloudBlobContainer GetImagesBlobContainer()
        {
            // Access cloud storage account. Uses connection string obtained above.
            CloudStorageAccount myCloudStorgageAccount = CloudStorageAccount.Parse(StorageConnectionString);

            // Create cloud table client. Provides access to Tables in your Storage Account 
            CloudBlobClient myCloudBlobClient = myCloudStorgageAccount.CreateCloudBlobClient();

            // Retrieve a reference to a container 'thegameblobs' - which has to be lowercase
            CloudBlobContainer myCloudBlob = myCloudBlobClient.GetContainerReference("thegameblobs");

            // Create thegameblobs Table if it does not already exist. 
            myCloudBlob.CreateIfNotExists();

            //Makes blob container contents publicly accessible. Without it cannot see images in your application or by using their URLs.
            myCloudBlob.SetPermissions(new BlobContainerPermissions
            {
                PublicAccess = BlobContainerPublicAccessType.Blob
            });

            return myCloudBlob;
        }

        private string PopulateBlob1(string blobReference)
        {
            CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
            CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(blobReference);
            blobImage.ImageUrl = myBlobIdentity.Uri.ToString();
            return string.Empty;

        }


        protected void chooseOption_Click(object sender, EventArgs e)
        {
            Label13.Visible = false;
            updateCard.Visible = false;
            updateCategory.Visible = false;
            createCard.Visible = false;
            createCategory.Visible = false;
            HideBoxesAndButtons();


            if (optionList.SelectedValue == "1")
            {
                nameTxtBox.Visible = true;
                attributeOneTxtBox.Visible = true;
                attributeTwoTxtBox.Visible = true;
                attributeThreeTxtBox.Visible = true;
                attributeFourTxtBox.Visible = true;
                attributeFiveTxtBox.Visible = true;
                blobUpload.Visible = true;
                createCategory.Visible = true;
                Label3.Text = "Category Name";
                Label4.Text = "Name of First Attribute";
                Label5.Text = "Name of Second Attribute";
                Label6.Text = "Name of Third Attribute";
                Label7.Text = "Name of Fourth Attribute";
                Label8.Text = "Name of Fifth Attribute";
                Label9.Text = "Select Category Image";

            }

            if (optionList.SelectedValue == "2")
            {
                ListAllCategories();
                categoryList.Visible = true;
                chooseCategory.Visible = true;
                Label10.Visible = true;
            }

            if (optionList.SelectedValue == "3")
            {
                ListAllCategories();
                categoryList.Visible = true;
                chooseCategory.Visible = true;
                Label10.Visible = true;
            }

            if (optionList.SelectedValue == "4")
            {
                ListAllCategories();
                categoryList.Visible = true;
                chooseCategory.Visible = true;
                Label10.Visible = true;
            }

            if (optionList.SelectedValue == "5")
            {
                ListAllCategories();
                categoryList.Visible = true;
                chooseCategory.Visible = true;
                Label10.Visible = true;

            }

            if (optionList.SelectedValue == "6")
            {
                ListAllCategories();
                categoryList.Visible = true;
                chooseCategory.Visible = true;
                Label10.Visible = true;
            }


        }


        protected void chooseCategory_Click(object sender, EventArgs e)
        {
            Label13.Visible = false;
            if (categoryList.SelectedValue == "")
            {
                Label11.Text = "Please select a category";
            }

            else
            {
                string splitText = categoryList.SelectedValue;
                string[] splitText1 = splitText.Split('-');
                //Label5.Text = splitText1[2]



                if (optionList.SelectedValue == "2")
                {
                    populateCategoryTitles(splitText1[1], splitText1[2]);
                    createCard.Visible = true;
                    Label9.Text = "Card Image";
                    blobUpload.Visible = true;
                }


                if (optionList.SelectedValue == "3")
                {
                    populateCategoryData(splitText1[1], splitText1[2]);
                    PopulateBlob1(splitText1[1] + "-" + splitText1[2]);
                    Label9.Text = "Category Image";
                    blobUpload.Visible = true;
                    blobImage.Visible = true;
                    updateCategory.Visible = true;
                }

                if (optionList.SelectedValue == "4")
                {
                    ListAllCards(splitText1[1] + splitText1[2]);
                    cardList.Visible = true;
                    chooseCard.Visible = true;
                    Label12.Visible = true;
                }


                if (optionList.SelectedValue == "5")
                {
                    populateCategoryData(splitText1[1], splitText1[2]);
                    PopulateBlob1(splitText1[1] + "-" + splitText1[2]);
                    blobImage.Visible = true;
                    deleteCategory.Visible = true;
                    Label11.Visible = true;
                    Label11.Text = "Warning - Deleting a Category Also Deletes All Category Cards";
                }


                if (optionList.SelectedValue == "6")
                {
                    ListAllCards(splitText1[1] + splitText1[2]);
                    cardList.Visible = true;
                    chooseCard.Visible = true;
                    Label12.Visible = true;

                }




            }
        }



        protected void createCategory_Click(object sender, EventArgs e)
        {
            if (!IsPostBack) { return; } // Do not insert when refresh.

            //Checks to make sure all the boxes have been completed and an image has been added
            if (nameTxtBox.Text == "" || attributeOneTxtBox.Text == ""  || attributeTwoTxtBox.Text == ""
                || attributeThreeTxtBox.Text =="" || attributeFourTxtBox.Text =="" || attributeFiveTxtBox.Text == "" || blobUpload.HasFile == false)
            {
                Label11.Text = "Please complete all sections and add an image.";
            }

            else
            {
                // Create category object from the text boxes.
                Label11.Text = "";
                CategoryEntity insertCategory = new CategoryEntity();
                insertCategory.Name = nameTxtBox.Text;
                insertCategory.AttributeNameOne = attributeOneTxtBox.Text;
                insertCategory.AttributeNameTwo = attributeTwoTxtBox.Text;
                insertCategory.AttributeNameThree = attributeThreeTxtBox.Text;
                insertCategory.AttributeNameFour = attributeFourTxtBox.Text;
                insertCategory.AttributeNameFive = attributeFiveTxtBox.Text;
                insertCategory.PartitionKey = "Category";

                int newRowKey = GetNextCategoryRowKey("Category");
                insertCategory.RowKey = Convert.ToString(newRowKey);

                // Get Cloud Table object for Category Table.
                CloudTable categoryCloudTable = GetTable("CategoryTable");
                // Create Table Operation to insert new Category Entity.
                TableOperation insertOperation = TableOperation.Insert(insertCategory);

                CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
                CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(insertCategory.PartitionKey + "-" + insertCategory.RowKey);
                myBlobIdentity.UploadFromStream(blobUpload.FileContent);
                insertCategory.ImageURI = myBlobIdentity.Uri.ToString();

                // Insert new message into Category Table.
                categoryCloudTable.Execute(insertOperation);

                // Clear the screen
                ClearTextBoxes();
                Label13.Visible = true;
                Label13.Text = "Category Created";
            }

        }

        protected void createCard_Click(object sender, EventArgs e)
        {
            if (!IsPostBack) { return; } // Do not insert when refresh.

            //Checks to make sure all the boxes have been completed and an image has been added
            if (nameTxtBox.Text == "" || attributeOneTxtBox.Text == "" || attributeTwoTxtBox.Text == ""
                || attributeThreeTxtBox.Text == "" || attributeFourTxtBox.Text == "" || attributeFiveTxtBox.Text == "" || blobUpload.HasFile == false)
            {
                Label11.Text = "Please complete all sections and add an image.";
            }
            else
            {
                Label11.Text = "";
                // Create message object from web form data.
                CardEntity insertCard = new CardEntity();
                //Take the input data from the text boxes
                insertCard.Name = nameTxtBox.Text;
                insertCard.AttributeOne = attributeOneTxtBox.Text;
                insertCard.AttributeTwo = attributeTwoTxtBox.Text;
                insertCard.AttributeThree = attributeThreeTxtBox.Text;
                insertCard.AttributeFour = attributeFourTxtBox.Text;
                insertCard.AttributeFive = attributeFiveTxtBox.Text;
                //
                string splitText = categoryList.SelectedValue;
                string[] splitText1 = splitText.Split('-');
                string partKey = splitText1[1] + splitText1[2];
                insertCard.PartitionKey = partKey;
                int newRowKey = GetNextCardRowKey(splitText1[1] + splitText1[2]);
                insertCard.RowKey = Convert.ToString(newRowKey);
                // Get Cloud Table object for Card Table.
                CloudTable cardCloudTable = GetTable("CardTable");
                // Create Table Operation to insert new Message Entity.
                TableOperation insertOperation = TableOperation.Insert(insertCard);
                CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
                CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(insertCard.PartitionKey + "-" + insertCard.RowKey);
                myBlobIdentity.UploadFromStream(blobUpload.FileContent);
                insertCard.ImageURI = myBlobIdentity.Uri.ToString();
                // Insert new message into Card Table.
                cardCloudTable.Execute(insertOperation);
                // Clear the screen
                ClearTextBoxes();
                Label13.Visible = true;
                Label13.Text = "Card Created";
            }


        }



        protected void updateCategory_Click(object sender, EventArgs e)
        {
            string splitText = categoryList.SelectedValue;
            string[] splitText1 = splitText.Split('-');
            CloudTable myCategoryCloudTable = GetTable("CategoryTable");
            // Create a retrieve operation that takes a category entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<CategoryEntity>(splitText1[1], splitText1[2]);
            // Execute the operation.
            TableResult retrievedResult = myCategoryCloudTable.Execute(retrieveOperation);
            // Assign the result to a CategoryEntity object.
            CategoryEntity updateEntity = (CategoryEntity)retrievedResult.Result;
            // Transfer the textbox entries 
            updateEntity.AttributeNameOne = attributeOneTxtBox.Text;
            updateEntity.AttributeNameTwo = attributeTwoTxtBox.Text;
            updateEntity.AttributeNameThree = attributeThreeTxtBox.Text;
            updateEntity.AttributeNameFour = attributeFourTxtBox.Text;
            updateEntity.AttributeNameFive = attributeFiveTxtBox.Text;
            updateEntity.Name = nameTxtBox.Text;

            if (blobUpload.HasFile)
            {
                CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
                CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(splitText1[1] + "-" + splitText1[2]);
                myBlobIdentity.Delete();
                myBlobIdentity.UploadFromStream(blobUpload.FileContent);
            }


            // Create the Replace TableOperation.
            TableOperation updateOperation = TableOperation.Replace(updateEntity);

            // Execute the operation.
            myCategoryCloudTable.Execute(updateOperation);
            // Clear the screen
            ClearTextBoxes();
            blobImage.ImageUrl = "";
            blobImage.Visible = false;
            Label13.Visible = true;
            Label13.Text = "Category Updated";
        }


        protected void chooseCard_Click(object sender, EventArgs e)
        {
            Label13.Visible = false;
            string splitText = categoryList.SelectedValue;
            string[] splitText1 = splitText.Split('-');
            populateCategoryTitles(splitText1[1], splitText1[2]);


            string splitTheText = cardList.SelectedValue;
            string[] splitTheText1 = splitTheText.Split('-');

            populateCardData(splitText1[1] + splitText1[2], splitTheText1[1]);
            string imageOneID = splitText1[1] + splitText1[2] + "-" + splitTheText1[1];
            //Then calls the method to obtain the blob image and put it into the image holder
            PopulateBlob1(imageOneID);
            blobImage.Visible = true;
            blobUpload.Visible = true;
            if(optionList.SelectedValue == "4")
            {
                updateCard.Visible = true;

            }

            if (optionList.SelectedValue == "6")
            {
                deleteCard.Visible = true;
            }


        }



        protected void updateCard_Click(object sender, EventArgs e)
        {
 
            string splitText = categoryList.SelectedValue;
            string[] splitText1 = splitText.Split('-');
            populateCategoryTitles(splitText1[1], splitText1[2]);

            string splitTheText = cardList.SelectedValue;
            string[] splitTheText1 = splitTheText.Split('-');
            CloudTable myCardCloudTable = GetTable("CardTable");
            // Create a retrieve operation that takes a category entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<CardEntity>(splitText1[1] + splitText1[2], splitTheText1[1]);
            // Execute the operation.
            TableResult retrievedResult = myCardCloudTable.Execute(retrieveOperation);
            // Assign the result to a CategoryEntity object.
            CardEntity updateEntity = (CardEntity)retrievedResult.Result;
            // Transfer the textbox entries 
            updateEntity.AttributeOne = attributeOneTxtBox.Text;
            updateEntity.AttributeTwo = attributeTwoTxtBox.Text;
            updateEntity.AttributeThree = attributeThreeTxtBox.Text;
            updateEntity.AttributeFour = attributeFourTxtBox.Text;
            updateEntity.AttributeFive = attributeFiveTxtBox.Text;
            updateEntity.Name = nameTxtBox.Text;



            if (blobUpload.HasFile)
            {
                CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
                CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(splitText1[1] + splitText1[2] + "-" + splitTheText1[1]);
                myBlobIdentity.Delete();
                myBlobIdentity.UploadFromStream(blobUpload.FileContent);
            }

            // Create the Replace TableOperation.
            TableOperation updateOperation = TableOperation.Replace(updateEntity);

            // Execute the operation.
            myCardCloudTable.Execute(updateOperation);

            // Clear the screen
            ClearTextBoxes();
            blobImage.ImageUrl="";
            blobImage.Visible = false;
            cardList.Items.Clear();
            ListAllCards(splitText1[1] + splitText1[2]);
            Label13.Visible = true;
            Label13.Text = "Card Updated";


        }

        protected void deleteCategory_Click(object sender, EventArgs e)
        {
            Label11.Text = "";
            string splitText = categoryList.SelectedValue;
            string[] splitText1 = splitText.Split('-');
            CloudTable myCategoryCloudTable = GetTable("CategoryTable");
            // Create a retrieve operation that takes a category entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<CategoryEntity>(splitText1[1], splitText1[2]);
            // Execute the operation.
            TableResult retrievedResult = myCategoryCloudTable.Execute(retrieveOperation);
            // Assigns the result to a CategoryEntity object.
            CategoryEntity updateEntity = (CategoryEntity)retrievedResult.Result;


            CloudBlobContainer myBlobContainer0 = GetImagesBlobContainer();
            CloudBlockBlob myBlobIdentity0 = myBlobContainer0.GetBlockBlobReference(splitText1[1] + "-" + splitText1[2] );
            myBlobIdentity0.Delete();


            // Create the Delete TableOperation.
            TableOperation deleteOperation = TableOperation.Delete(updateEntity);
            // Execute the operation.
            myCategoryCloudTable.Execute(deleteOperation);



            //Once category is gone the associated cards and blobs need to go too and they are also deleted
            CloudTable getCategoryTable = GetTable("CardTable");
            TableQuery<CardEntity> query = new TableQuery<CardEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, splitText1[1] + splitText1[2]));
            foreach (CardEntity entity in getCategoryTable.ExecuteQuery(query))
            {
                CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
                CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(entity.PartitionKey + "-" + entity.RowKey);
                myBlobIdentity.Delete();
                // Create the Replace TableOperation.
                TableOperation deleteOperation1 = TableOperation.Delete(entity);
                // Execute the operation.
                getCategoryTable.Execute(deleteOperation1);

            }



            // Clear the screen
            ClearTextBoxes();
            categoryList.Items.Clear();
            ListAllCategories();
            Label13.Visible = true;
            Label13.Text = "Category Deleted";
            blobImage.ImageUrl = "";
            blobImage.Visible = false;



        }

        protected void deleteCard_Click(object sender, EventArgs e)
        {
            string splitText = categoryList.SelectedValue;
            string[] splitText1 = splitText.Split('-');
            populateCategoryTitles(splitText1[1], splitText1[2]);

            string splitTheText = cardList.SelectedValue;
            string[] splitTheText1 = splitTheText.Split('-');
            CloudTable myCardCloudTable = GetTable("CardTable");
            // Create a retrieve operation that takes a category entity.
            TableOperation retrieveOperation = TableOperation.Retrieve<CardEntity>(splitText1[1] + splitText1[2], splitTheText1[1]);
            // Execute the operation.
            TableResult retrievedResult = myCardCloudTable.Execute(retrieveOperation);
            // Assign the result to a CardEntity object.
            CardEntity updateEntity = (CardEntity)retrievedResult.Result;



            CloudBlobContainer myBlobContainer = GetImagesBlobContainer();
            CloudBlockBlob myBlobIdentity = myBlobContainer.GetBlockBlobReference(splitText1[1] + splitText1[2] + "-" + splitTheText1[1]);
            myBlobIdentity.Delete();


            // Create the Replace TableOperation.
            TableOperation deleteOperation = TableOperation.Delete(updateEntity);

            // Execute the operation.
            myCardCloudTable.Execute(deleteOperation);

            // Clear the screen
            ClearTextBoxes();
            blobImage.Visible = false;
            cardList.Items.Clear();
            ListAllCards(splitText1[1] + splitText1[2]);
            Label13.Visible = true;
            Label13.Text = "Card Deleted";


        }

        public IEnumerable<CategoryEntity> GetCategories()
        {

            // Get Cloud Table object for Category Table.
            CloudTable myPlayersCloudTable = GetTable("CategoryTable");


            // Create a Table Query object.
            TableQuery<CategoryEntity> myTableQuery = new TableQuery<CategoryEntity>();


            // Get list from Category Table.
            IEnumerable<CategoryEntity> categoryList =
            myPlayersCloudTable.ExecuteQuery(myTableQuery);


            // Sort in reverse chronological order.
            categoryList = categoryList.OrderByDescending(msg => msg.Timestamp);

            // Output to data list on web form.
            return categoryList;

        }

        public IEnumerable<CardEntity> GetCards()
        {

            // Get Cloud Table object for Card Table.
            CloudTable myPlayersCloudTable = GetTable("CardTable");


            // Create a Table Query object.
            TableQuery<CardEntity> myTableQuery = new TableQuery<CardEntity>();


            // Get list from Card Table.
            IEnumerable<CardEntity> cardList =
            myPlayersCloudTable.ExecuteQuery(myTableQuery);


            // Sort in reverse chronological order.
            cardList = cardList.OrderByDescending(msg => msg.Timestamp);

            // Output to data list on web form.
            return cardList;

        }

    }


}
