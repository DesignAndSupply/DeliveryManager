using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DeliveryManagerUI.ClassLib
{
    public class PurchaseOrderItem
    {

        public string _stockCode { get; set; }
        public int _userID { get; set; }







        public double _onOrderAmount
        {
            get
            {
                SqlConnection conn = new SqlConnection(CS.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT onOrder from c_view_on_order_amount where stock_code = @sc", conn);
                cmd.Parameters.AddWithValue("@sc", _stockCode);
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
        }



        public PurchaseOrderItem(string stockCode,int user_id)
        {
            _stockCode = stockCode;
            _userID = user_id;
        }


        public void insertActivityRecord(double qty,string itemDesc, double poID, string delNote)
        {
            //Fixes truncation issue
            string shortDesc = itemDesc.Substring(0, (itemDesc.Length > 49 ? 49 : itemDesc.Length));


            if (_stockCode == "M" || _stockCode == "T" || _stockCode == "m"  || _stockCode == "t")
            {

            }
            else
            {
                SqlConnection conn = new SqlConnection(CS.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO dbo.po_activity_log (PO_id,user_created,date_created,action,para_1,para_2) " +
                                  "VALUES (@poID,@userID,@date,'ITEM DELIVERED',@qty,@desc);";
                cmd.Parameters.AddWithValue("@userID", _userID);
                cmd.Parameters.AddWithValue("@poID", poID);
                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@qty", qty + " DN(" + delNote + ")");
                cmd.Parameters.AddWithValue("@desc", shortDesc);

                cmd.ExecuteNonQuery();
                conn.Close();
            }

            
        }

        public double getPreviousQuantity(int poItemId)
        {
            SqlConnection conn = new SqlConnection(CS.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT delivered_quantity from dbo.po_item where id = @id",conn);
            cmd.Parameters.AddWithValue("@id", poItemId);
            return Convert.ToDouble(cmd.ExecuteScalar());
            conn.Close();


        }

        public void updateStock(string stockCode, double qtyDiff)
        {
            SqlConnection conn = new SqlConnection(CS.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE dbo.stock set amount_in_stock = amount_in_stock + @qty where stock_code = @sc", conn);
            cmd.Parameters.AddWithValue("@qty", qtyDiff);
            cmd.Parameters.AddWithValue("@sc", stockCode);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        public void updateItem(int itemID, double deliveredQty)
        {
            SqlConnection conn = new SqlConnection(CS.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("UPDATE dbo.po_item set delivered_quantity = @qty where id = @id", conn);
            cmd.Parameters.AddWithValue("@qty", deliveredQty);
            cmd.Parameters.AddWithValue("@id", itemID);
            cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void checkItemDeliveryComplete(int itemID, double orderQty, double deliveredQty)
        {
            string dateStamp;

            SqlConnection conn = new SqlConnection(CS.ConnectionString);
            conn.Open();


            SqlCommand cmdread = new SqlCommand("select date_complete from dbo.po_item where id=@id", conn);
            cmdread.Parameters.AddWithValue("@id", itemID);
            dateStamp = cmdread.ExecuteScalar().ToString() ;


            if (string.IsNullOrWhiteSpace(dateStamp))
            {
                if (deliveredQty >= orderQty)
                {


                    SqlCommand cmd = new SqlCommand("UPDATE dbo.po_item set date_complete = @date where id = @id", conn);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@id", itemID);

                    cmd.ExecuteNonQuery();

                }
            }

            conn.Close();

        }






    }
}
