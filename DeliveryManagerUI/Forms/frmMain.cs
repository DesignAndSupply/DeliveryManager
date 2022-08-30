using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeliveryManagerUI.ClassLib;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Drawing.Printing;

namespace DeliveryManagerUI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
       
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'order_databaseDataSet.stores_location' table. You can move, or remove it, as needed.
            this.stores_locationTableAdapter.Fill(this.order_databaseDataSet.stores_location);
            // TODO: This line of code loads data into the 'order_databaseDataSet.stores_delivery_company' table. You can move, or remove it, as needed.
            this.stores_delivery_companyTableAdapter.Fill(this.order_databaseDataSet.stores_delivery_company);
            // TODO: This line of code loads data into the 'user_infoDataSet.c_view_stores_staff' table. You can move, or remove it, as needed.
            this.c_view_stores_staffTableAdapter.Fill(this.user_infoDataSet.c_view_stores_staff);


            //cmbStaff.SelectedIndex = -1;
            //cmbDelComp.SelectedIndex = -1;

           // comboBox1.Dock = DockStyle.Top;
            //Controls.Add(comboBox1);

            // Add list of installed printers found to the combo box.
            // The pkInstalledPrinters string will be used to provide the display string.
            int i;
            string pkInstalledPrinters;

            for (i = 0; i < PrinterSettings.InstalledPrinters.Count; i++)
            {
                pkInstalledPrinters = PrinterSettings.InstalledPrinters[i];
                comboBox1.Items.Add(pkInstalledPrinters);

            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {

            fillGrid();
            double n;
            bool isNumeric = double.TryParse(txtPOID.Text, out n);
            PurchaseOrder po = new PurchaseOrder(n);

            if (po._isSlimline == "True")
            {
                lblSlimline.Visible = true;
            }
            else
            {
                lblSlimline.Visible = false;
            }

        }


        

        private void fillGrid()
        {
            double n;
            bool isNumeric = double.TryParse(txtPOID.Text, out n);

            try
            {
                dg.Columns.Remove("Print Label");
                dg.Columns.Remove("Location");
                dg.DataSource = null;
            }
            catch
            {

            }


            if (isNumeric)
            {
                PurchaseOrder po = new PurchaseOrder(n);
                if (po._isValid)
                {


                    //SETS UP THE DELIVERY STATUS LABEL
                    if (po._deliveryStatus == "COMPLETE")
                    {
                        lblOrderStatus.Text = "Order status: COMPLETE";
                        lblOrderStatus.ForeColor = Color.Green;
                    }
                    else
                    {
                        if (po._orderStatus == "PART")
                        {
                            lblOrderStatus.ForeColor = Color.Orange;
                        }
                        else
                        {
                            lblOrderStatus.ForeColor = Color.Red;
                        }

                        lblOrderStatus.Text = "Order status: " + po._orderStatus;

                    }


                    SqlConnection conn = new SqlConnection(CS.ConnectionString);

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;

                    cmd.CommandText = "SELECT id,po_id, stock_code, description, quantity, delivered_quantity, additional_info, due_date from dbo.po_item where po_id =@poID;";
                    cmd.Parameters.AddWithValue("@poID", txtPOID.Text);

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    adap.Fill(dt);

                    dg.DataSource = dt;


                    //ADD BUTTON

                    DataGridViewButtonColumn buttonlabel = new DataGridViewButtonColumn();
                    buttonlabel.Text = "Print Label";
                    buttonlabel.Name = "Print Label";
                    buttonlabel.UseColumnTextForButtonValue = true;
                    int columnIndex = 8;

                    if (dg.Columns["Print Label"] == null)
                    {
                        dg.Columns.Insert(columnIndex, buttonlabel);
                    }

                    //INSERTS THE LOCATION SELECTION

                    string str = "SELECT id,stores_location FROM stores_location";

      
                    SqlDataAdapter sqladap = new SqlDataAdapter(str, conn);
                    SqlCommandBuilder sqlcmdBuild = new SqlCommandBuilder(sqladap);
                    DataTable dtlocation = new DataTable();
                    sqladap.Fill(dtlocation);
                    BindingSource bs = new BindingSource();
                    bs.DataSource = dtlocation;


                    DataGridViewComboBoxColumn location = new DataGridViewComboBoxColumn();
                    location.HeaderText = "Location";
                    location.Name = "Location";
                    location.DataSource = bs;
                    location.ValueMember = "id";
                    location.DisplayMember = "stores_location";

                    columnIndex = 7;

                    if (dg.Columns["Location"] == null)
                    {
                        dg.Columns.Insert(columnIndex, location);
                    }

                }
                else
                {
                    MessageBox.Show("This is not a valid purchase order number, please try again!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Only numerical values can be searched", "Non numerical value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        private void btnSubmit_Click(object sender, EventArgs e)
        {
            double n;
            bool isNumeric = double.TryParse(txtPOID.Text, out n);

            if (isNumeric)
            {
                PurchaseOrder po = new PurchaseOrder(n);

                if (validateDeliveryDetails() == true && po._isValid && dg.Rows.Count > 0 && string.IsNullOrWhiteSpace(cmbStaff.Text) == false)
                {
                    logDelivery();
                    gridLoop();
                    clearDelivery();
                    MessageBox.Show("Successfully added delivery and updated purchase order information", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    //CLEAN UP THE GRID
                    //dg.DataSource = null;
                    //dg.Columns.RemoveAt(0);
                    //txtPOID.Text = "";


                }
                else
                {
                    MessageBox.Show("Please ensure all delivery information is added, a valid purchase order number must be used and (Recieved by) must not be blank", "Missing information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Purchase order numbers can only be numerical values", "Non numerical value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              
            
        }

        private void gridLoop()
        {

            double previousDeliveredValue;
            double newDeliveredValue;
            double stockUpdateValue;
            string stockCode;
            double lineItemID;
            //string location;
            double amountOnOrder;
            int userID;
            foreach (DataGridViewRow row in dg.Rows)
            {

                if (string.IsNullOrWhiteSpace(row.Cells[2].Value.ToString()))
                {


                }
                else
                {
                    stockCode = row.Cells[2].Value.ToString();
                    lineItemID = Convert.ToDouble(row.Cells[0].Value);
                    amountOnOrder = Convert.ToDouble(row.Cells[4].Value);
                    //location = row.Cells[7].Value.ToString();
                    userID = Convert.ToInt32(cmbStaff.SelectedValue);


                    PurchaseOrderItem poi = new PurchaseOrderItem(stockCode, userID, lineItemID);
                    //USES THE ID TO GET THE PREVIOUS DELIVERED AMOUNT
                    previousDeliveredValue = poi.getPreviousQuantity(Convert.ToInt32(row.Cells[0].Value));

                    //GETS THE NEW DELIVERED AMOUNT FROM THE DATAGRID
                    newDeliveredValue = Convert.ToDouble(row.Cells[5].Value);

                    //GETS THE DIFFERENCE VALUE
                    stockUpdateValue = newDeliveredValue - previousDeliveredValue;

                    //updates the po item delivered amount
                    poi.updateItem(Convert.ToInt32(row.Cells[0].Value), newDeliveredValue);


                    //INSERT ACTIVITY RECORD --ONLY INSERT RECORDS WHERE THERE IS A DIFFERENT IN THE OLD STOCK FIGURE TO THE NEW

                    if (stockUpdateValue != 0)
                    {
                        poi.insertActivityRecord(stockUpdateValue, row.Cells[3].Value.ToString(), Convert.ToDouble(txtPOID.Text),txtIdentifier.Text);
                    }

                    int n;
                    bool isNumeric = int.TryParse(stockCode, out n);

                    if (isNumeric)
                    {
                        //UPDATES STOCK
                        poi.updateStock(n.ToString(), stockUpdateValue);

                        SqlConnection conn = new SqlConnection(CS.ConnectionString);
                        conn.Open();
                        //UPDATES AMOUNT ON ORDER
                        SqlCommand cmdOnOrder = new SqlCommand("UPDATE dbo.stock set on_order = @qty where stock_code = @sc", conn);
                        cmdOnOrder.Parameters.AddWithValue("@qty", poi._onOrderAmount);
                        cmdOnOrder.Parameters.AddWithValue("@sc", stockCode);
                        cmdOnOrder.ExecuteNonQuery();

                        //Adds quantity to location
                        //Location l = new Location(stockCode, location, stockUpdateValue);
                        //l.updateInsertLocation();

                    }

                    if (isNumeric || stockCode == "S1" || stockCode == "s1")
                    {
                        poi.checkItemDeliveryComplete(Convert.ToInt32(row.Cells[0].Value), amountOnOrder, newDeliveredValue);
                    }

                }



            }


            //UPDATES THE PO STATUS 
            PurchaseOrder p = new PurchaseOrder(Convert.ToDouble(txtPOID.Text));
            p.updateOrderStatus();

            try
            {
                txtPOID.Text = "";
                dg.Columns.Remove("Print Label");
                dg.Columns.Remove("Location");
                dg.DataSource = null;
            }
            catch
            {

            }
           


        }

        private void updateOnOrderAmount(string stockCode)
        {
           
        }

        private void clearDelivery()
        {
            cmbStaff.SelectedIndex = -1;
            cmbDelComp.SelectedIndex = -1;
            txtBoxQty.Text = "";
            txtDesc.Text = "";
            txtIdentifier.Text = "";
            

        }

        private bool validateDeliveryDetails()
        {
            if (string.IsNullOrEmpty(txtIdentifier.Text) || string.IsNullOrWhiteSpace(cmbStaff.Text) || string.IsNullOrWhiteSpace(cmbDelComp.Text) || string.IsNullOrWhiteSpace(txtBoxQty.Text) || string.IsNullOrWhiteSpace(txtDesc.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        private void btnLogDel_Click(object sender, EventArgs e)
        {
            DialogResult result = new DialogResult();


            if (validateDeliveryDetails() == true)
            {
                result = MessageBox.Show("Are you sure you wish to log this delivery?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    logDelivery();
                    MessageBox.Show("Successfully logged!", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearDelivery();
                }
                else
                {
                    MessageBox.Show("No Action taken.", "Cancelled!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("Please ensure all fields are correctly filled in before proceeding!", "Missing info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         }

        private void logDelivery()
        {
     
            Delivery d = new Delivery(Convert.ToInt32(cmbStaff.SelectedValue), Convert.ToInt32(cmbDelComp.SelectedValue), Convert.ToInt32(txtBoxQty.Text), txtDesc.Text, txtIdentifier.Text);
            d.insertDeliveryRecord();
                    
        }


        private void btnPoUpdate_Click(object sender, EventArgs e)
        {
            //try
            //{

            double n;
            bool isNumeric = double.TryParse(txtPOID.Text, out n);

            if (isNumeric)
            {
                PurchaseOrder po = new PurchaseOrder(n);
                if (po._isValid && dg.Rows.Count > 0 && string.IsNullOrWhiteSpace(cmbStaff.Text)==false)
                {
                    gridLoop();
                    MessageBox.Show("Delivery has successfully been updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    

                }
                else
                {
                    MessageBox.Show("Purchase order number selection is not valid or (Recieved by field) has not been completed. Please try again!", "Invalid Number", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Purchase orders can only be numerical values", "Non numerical value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



}

        private void lblOrderStatus_Click(object sender, EventArgs e)
        {

        }

        private void dg_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string sc="" ;
            int itemID = 0;

            if (dg.SelectedCells.Count > 0)
            {
                int selectedrowindex = dg.SelectedCells[0].RowIndex;

                DataGridViewRow selectedRow = dg.Rows[selectedrowindex];

                itemID = Convert.ToInt32(selectedRow.Cells["id"].Value) ;
                sc = selectedRow.Cells["stock_code"].Value.ToString();
          
                
            }



            if (e.ColumnIndex == dg.Columns["Print Label"].Index)
            {
                var type = Type.GetTypeFromProgID("WScript.Network");
                var instance = Activator.CreateInstance(type);
                string defaultPrinter = "";
                try
                {

                   
                    PrinterSettings settings = new PrinterSettings();
                    defaultPrinter = (settings.PrinterName); //should always get this

                    string labelCount = Interaction.InputBox("How many labels would you like?", "How Many?", "1", -1, -1);

                    ClassLib.Label l = new ClassLib.Label(sc, itemID);
                    l.printSmallStockLabel(labelCount);
                }
                catch
                {
                    type.InvokeMember("SetDefaultPrinter", System.Reflection.BindingFlags.InvokeMethod, null, instance, new object[] { defaultPrinter });
                    MessageBox.Show("An error has occured, this is likely due to you attempting to print a label for an item without a stock code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
              
                
            }

            
        }

        private void dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dg_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dg.Rows)
            {            //Here 2 cell is target value and 1 cell is Volume

                if (string.IsNullOrWhiteSpace(Myrow.Cells[5].Value.ToString())==true || string.IsNullOrWhiteSpace(Myrow.Cells[4].Value.ToString()) == true)
                {
                    
                }
                else
                {
                    try
                    {
                        if (Convert.ToDouble(Myrow.Cells[5].Value) < Convert.ToDouble(Myrow.Cells[4].Value))// Or your condition 
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.PaleVioletRed;
                        }
                        else
                        {
                            Myrow.DefaultCellStyle.BackColor = Color.PaleGreen;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }


                
            }
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string labelCount = Interaction.InputBox("How many labels would you like?", "How Many?", "1", -1, -1);
            ClassLib.Label l = new ClassLib.Label("559", 8265);
            l.printSmallStockLabel(labelCount);
        }
    }
}
