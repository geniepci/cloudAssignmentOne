using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace CloudAssignment
{
    public class CategoryEntity : TableEntity
    {
        public CategoryEntity()
        {
            RowKey = "";
            PartitionKey = "";

        }
        public string Name { get; set; }
        public string AttributeNameOne { get; set; }
        public string AttributeNameTwo { get; set; }
        public string AttributeNameThree { get; set; }
        public string AttributeNameFour { get; set; }
        public string AttributeNameFive { get; set; }
        public string ImageURI { get; set; }
    }

    public class CardEntity : TableEntity
    {
        public CardEntity()
            {
                RowKey = "";
                PartitionKey = "";

            }
  
        public string Name { get; set; }
        public string AttributeOne { get; set; }
        public string AttributeTwo { get; set; }
        public string AttributeThree { get; set; }
        public string AttributeFour { get; set; }
        public string AttributeFive { get; set; }
        public string ImageURI { get; set; }

    }

    public class PlayersEntity : TableEntity
    {
        public PlayersEntity()
        {
            // For simplicity make the RowKey globally unique
            RowKey = "";

            // Although not used here, cannot be left as null
            PartitionKey = "";
        }

        public string PlayerName { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string Games { get; set; }
        public string ImageURI { get; set; }

    }
}
    






