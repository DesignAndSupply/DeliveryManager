using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Document;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace DeliveryManagerUI.ClassLib
{
    public class Label
    {
        private string _sc { get; set; }
        private int _itemID { get; set; }

        private string _desc
        {
            get
            {
                //UPDATES OPERATIONS DATAGRID
                SqlConnection con = new SqlConnection(CS.ConnectionString);

                con.Open();
                //UPDATES THE PAINT TO DOOR DATAGRID
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select description from dbo.stock where stock_code = @sc";
                cmd.Parameters.AddWithValue("@sc", _sc);


                return cmd.ExecuteScalar().ToString();

            }
        }

        public Label(string stockCode, int itemID)
        {
            _sc = stockCode;
            _itemID = itemID;

        }

        public void printSmallStockLabel(string copyCount)
        {
            // get the default printer
            PrinterSettings settings = new PrinterSettings();
            string defaultPrinter = (settings.PrinterName);
            string labelPrinter = @"\\192.168.0.48\ZDesignerGK420d";

            var type = Type.GetTypeFromProgID("WScript.Network");
            var instance = Activator.CreateInstance(type);
            type.InvokeMember("SetDefaultPrinter", System.Reflection.BindingFlags.InvokeMethod, null, instance, new object[] { labelPrinter });


            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            DocumentModel document = DocumentModel.Load(@"\\designsvr1\apps\Design and Supply CSharp\Documents\Stores\BarcodeLabel2.docx");
            PrintOptions po = new PrintOptions();
            po.CopyCount = Convert.ToInt32(copyCount);

            document.Bookmarks["SC"].GetContent(false).LoadText(_sc.ToString());
            document.Bookmarks["DESC"].GetContent(false).LoadText(_desc);
            document.Bookmarks["BC"].GetContent(false).LoadText("*" + _sc.ToString() + "*"); 
            
            
            //PrinterSettings settings2 = new PrinterSettings();

            document.Print(settings.PrinterName, po);

            //revert default back to normal
            type.InvokeMember("SetDefaultPrinter", System.Reflection.BindingFlags.InvokeMethod, null, instance, new object[] { defaultPrinter });
        }








    }
}
