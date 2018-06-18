using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DeliveryManagerUI.ClassLib
{
    public class Delivery
    {



        public int _recievedByID { get; set; }
        public int _delCompID { get; set; }
        public int _boxQty { get; set; }
        public string _delDescription { get; set; }
        public string _identifier { get; set; }

        public Delivery(int recievedByID, int delCompID, int boxQty, string delDescription, string identifier)
        {
            _recievedByID = recievedByID;
            _delCompID = delCompID;
            _boxQty = boxQty;
            _delDescription = delDescription;
            _identifier = identifier;
        }

        public void insertDeliveryRecord()
        {
            SqlConnection conn = new SqlConnection(CS.ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "INSERT INTO dbo.stores_delivery (delivery_date, recieved_by_id,delivery_company_id,package_qty, delivery_description, identifier_no) " +
                              " VALUES (@date, @recievedByID, @delCompID, @boxQty, @delDescription,@identifier)";
            cmd.Parameters.AddWithValue("@date", DateTime.Now);
            cmd.Parameters.AddWithValue("@recievedByID", _recievedByID);
            cmd.Parameters.AddWithValue("@delCompID", _delCompID);
            cmd.Parameters.AddWithValue("@boxQty", _boxQty);
            cmd.Parameters.AddWithValue("@delDescription", _delDescription);
            cmd.Parameters.AddWithValue("@identifier", _identifier);

            cmd.ExecuteNonQuery();
            conn.Close();

        }



    }
}
