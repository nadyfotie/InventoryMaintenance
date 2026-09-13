using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryMaintenance
{
    //This class represents an inventory item and encapsulates its properties and
    //methods within one class. Encapsulation means grouping the data and the behavior
    //that operates on that data together. The properties store information about the inventory item,
    //while the methods provide behavior related to that item. It would also enure access-control if the 
    //some methods or properties are private and not accessible outside the class.

    public class InvItem
    {
        //Nady Fotie 
        // Creates a new InvItem with default property values.
        public InvItem() { }

        //Nady Fotie 
        // Construtor: Creates a new InvItem with specific with parameters (itemNo, description, price)
        // and assigns them to the properties of the class.
        public InvItem(int itemNo, string description, decimal price)
        {
            ItemNo = itemNo;
            Description = description;
            Price = price;
        }
        public int ItemNo { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        // Nady Fotie
        // Returns a formatted string for ItemNo, Description, and Price. 
        public string GetDisplayText(string sep)
        {
            return ItemNo + sep + Description + sep + Price.ToString("c");
        }




    }
}
