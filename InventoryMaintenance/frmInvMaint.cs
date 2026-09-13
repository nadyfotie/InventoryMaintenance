using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmInvMaint : Form
    {
        // Nady Fotie
        // This initialize the inventory maintenance form and its controls 
        public frmInvMaint()
        {
            InitializeComponent();
        }

        // TODO: Declare here a private variable that can store a list of InvItem objects and intialize it to null.
        private List<InvItem> invItems = null;

        // Nady Fotie
        //Get the inventory items from the XML to the list box , Even-handler 
        private void frmInvMaint_Load(object sender, EventArgs e)
        {
            // TODO: Load the list of inventory items from the database class (InvItemDB).
            // Hint: Call InvItemDB.GetItems() and assign the result to invItems.
            invItems = InvItemDB.GetItems();

            // This method call updates the list box with the items.
            FillItemListBox();
        }

        //Nady Fotie
        // Clears the ListBox and displays each inventory item from the list.
        private void FillItemListBox()
        {
            lstItems.Items.Clear();
            // TODO: Code here that loads the list box with the items in the list.
            // Hint: Loop through each item in invItems and add it to lstItems.
            foreach (InvItem item in invItems)
            {
                lstItems.Items.Add(item.GetDisplayText("    "));
            }

        }
        // Nady Fotie

        // Creates a new form and, if a new item is created, adds it to the inventory list,
        // which is then saved to the XML file through InvItemDB.
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // TODO: Create an instance of the new item form (frmNewItem).
            frmNewItem newItemForm = new frmNewItem();
            // TODO: Call the form’s method to get the new item from the user.
            InvItem item = newItemForm.GetNewItem();
            // TODO: If a new item was created (not null), add it to invItems,
            if (item != null)
            {
                invItems.Add(item);
                //       save the updated list using InvItemDB.SaveItems, 
                InvItemDB.SaveItems(invItems);
                //       and refresh the list box by calling FillItemListBox().
                FillItemListBox();
            } 
            




        }
        // Nady Fotie
        // Confirms that an items are deleted  has been removed
        // and it updates everything and refreshes 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int i = lstItems.SelectedIndex;
            if (i != -1)
            {
                // TODO: Add code here that displays a dialog box (Yes/No) to confirm the deletion 
                //       Hint: Use MessageBox.Show with MessageBoxButtons.YesNo
                DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", 
                    "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                // TODO: If the user clicks "Yes":
                if (result == DialogResult.Yes)
                {
                    //          - Remove the selected item from invItems
                    invItems.RemoveAt(i);
                    //          - Save the updated list with InvItemDB.SaveItems
                    InvItemDB.SaveItems(invItems);
                    //          - Refresh the list box by calling FillItemListBox()
                    FillItemListBox();
                } 



            }
        }
        // Nady Fotie
        // Event handler handler responsible for closing the form 
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
