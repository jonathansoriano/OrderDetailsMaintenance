
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace OrderDetailsMaintenance
{
    public partial class frmCustomerMaintenance : Form
    {
        private NorthwindContext _context;//Instantiated the Northwind DB object and called this instance "_context"
        private Customer _customer;// Instantiated the Class Customer that is part of the Northwind parent class

        public frmCustomerMaintenance()
        {
            InitializeComponent();

        }
        //Jon Soriano Sanjuan
        private void btnFind_Click(object sender, EventArgs e)
        {
            //Since we are needing the "Find" button to perform actions, makes sense to assign the variable "_context" and "_customer" inside
            //this event handler
            _context = new NorthwindContext();//Assign the DB Northwind class inside of the Find Button

            string customerID = txtCustomerId.Text;// To make it easier, we will make the txt from the txtBox and make it a type String
                                                    // We this we avoid typing more than we have to.


            if (string.IsNullOrWhiteSpace(customerID)) //Same as customerID == ""
            {
                MessageBox.Show("Please enter a valid Customer ID", "Entry Error");
                txtCustomerId.Focus();//Puts a colored under the txtbox.

            }
            else
            {
                _customer = _context.Customers.Find(customerID); //Here we are setting the customer class(in DB its a table) to get info from the DB(_context) and specifically 
                                                        // from the Customer's list called "Customers" (this list is part of the NorthWindContext Class) and use the method
                                                        // Find(txtboxName) so it can search in the DB that specific customerID in the CustomerID field.
                if (_customer != null) //As long as the DB doens't return "null" (returns nothing)...
                {
                    txtContact.Text = _customer.ContactName;// We will set each txtBox to the properties of Customer class 
                    txtAddress.Text = _customer.Address;
                    txtCity.Text = _customer.City;
                    txtCountry.Text = _customer.Country;


                }
                else
                {
                    MessageBox.Show("Customer not found", "Search Error"); //If the CustomerID doesn't appear to be in the DB Northwind's table Customer
                                                                        // then we show a Dialog MessageBox saying the customer is not found
                   
                }

            }

        }
        //Jon Soriano Sanjuan
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); //Close() method is the same as "System.exit(0)" in java.
        }

        
       
    }
}