using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace InventoryMaintenance
{
    public partial class frmNewItem : Form
    {
        // Nady Fotie
        // Constructor: Initializes the New Item form and its controls.

        public frmNewItem()
        {
            InitializeComponent();
        }

        // TODO: Declare a variable that declares a new InvItem object and set it to null.
        // Hint: Make it public so frmInvMaint can access the item after this form closes.\

        // Nady Fotie
        public InvItem invItem = null;


        // TODO: Create a method that shows this form as a dialog window
        //       and then returns the new InvItem created by the user.
        // Hint: Use this.ShowDialog() to display the form.

        // Nady Fotie
        // Displays the New Item form as a dialog box and returns the new InvItem to the Main form .
        public InvItem GetNewItem()
        {
            this.ShowDialog();
            return invItem;
        }
        // Nady Fotie 
        // Validates the entered data, creates a new InvItem, and closes the form.
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                // TODO: Create a new InvItem object using the values from the text boxes.
                invItem  = new InvItem(Convert.ToInt32(txtItemNo.Text),
                    txtDescription.Text, Convert.ToDecimal(txtPrice.Text));
                //       - Convert txtItemNo.Text to an int
                //       - Use txtDescription.Text as the description
                //       - Convert txtPrice.Text to a decimal
                // TODO: Assign the new object to the item variable.
                // TODO: Close the form after saving the item.
                this.Close();
            }
            
        }
        // Nady Fotie
        // Validates that the item number, description, and price contain valid data.

        private bool IsValidData()
        {
            return Validator.IsPresent(txtItemNo) &&
                   Validator.IsInt32(txtItemNo) &&
                   Validator.IsPresent(txtDescription) &&
                   Validator.IsPresent(txtPrice) &&
                   Validator.IsDecimal(txtPrice);
        }

        // Nady
        //Closes the New Item form without creating a new inventory item.

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
