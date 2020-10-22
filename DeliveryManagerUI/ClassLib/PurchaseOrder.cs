using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DeliveryManagerUI.ClassLib;

namespace DeliveryManagerUI.ClassLib
{
    public class PurchaseOrder
    {

        public double _poID { get; set; }

        public string _orderStatus { get
            {

                SqlConnection conn = new SqlConnection(CS.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT on_order_identifier from dbo.po where PO_id = @poID", conn);
                cmd.Parameters.AddWithValue("@poID", _poID);


                return cmd.ExecuteScalar().ToString();


            }
        }

        public string _deliveryStatus
        {
            get
            {

                SqlConnection conn = new SqlConnection(CS.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT delivered_identifier from dbo.po where PO_id = @poID", conn);
                cmd.Parameters.AddWithValue("@poID", _poID);


                return cmd.ExecuteScalar().ToString();


            }
        }

        public bool _isValid { get
            {

                SqlConnection conn = new SqlConnection(CS.ConnectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id from dbo.po where PO_id = @poID", conn);
                cmd.Parameters.AddWithValue("@poID", _poID);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }


        public string _isComplete {
            get
            {

                bool partCatch = false;
                bool completeCatch = false;

                SqlConnection conn = new SqlConnection(CS.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM dbo.po_item WHERE po_id = @poID";
                cmd.Parameters.AddWithValue("@poID", _poID);
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {

                    //SKIP IF TRASPORT OR MESSAGE LINE
                    if (rdr["stock_code"].ToString() == "M" || rdr["stock_code"].ToString() == "T")
                    {

                    }
                    else
                    {
                        if (rdr["delivered_quantity"].ToString() != rdr["quantity"].ToString())
                        {
                            partCatch = true;
                        }
                        if (rdr["delivered_quantity"].ToString() == rdr["quantity"].ToString())
                        {
                            completeCatch = true;
                        }
                    }

                }

                if (partCatch == true)
                {
                    return "PART";
                }
                else
                {
                    if (completeCatch == true)
                    {
                        return "COMPLETE";
                    }
                    else
                    {
                        return "ON ORDER";
                    }
                }



            }
        }


        public PurchaseOrder(double poID)
        {
            _poID = poID;
        }


        public string _isSlimline
        {
            get
            {
                SqlConnection conn = new SqlConnection(CS.ConnectionString);
                conn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM dbo.po WHERE po_id = @poID and slimline_identifier = -1";
                cmd.Parameters.AddWithValue("@poID", _poID);
                SqlDataReader rdr = cmd.ExecuteReader();


                if (rdr.HasRows)
                {
                    return "True";
                }
                else
                {
                    return "False";
                }



            }

                   
        }


        public void updateOrderStatus()
        {
            SqlConnection conn = new SqlConnection(CS.ConnectionString);
            conn.Open();
            
           
                switch (_isComplete)
                {
                    case "PART":

                    SqlCommand cmdP = new SqlCommand("UPDATE dbo.po SET on_order_identifier = 'PART' WHERE po_id = @poID",conn);
                    cmdP.Parameters.AddWithValue("@poID", _poID);
                    cmdP.ExecuteNonQuery();

                    break;
                    case "COMPLETE":

                    SqlCommand cmdC = new SqlCommand("UPDATE dbo.po SET on_order_identifier = '' , delivered_identifier = 'COMPLETE', locked_identifier = -1, complete_flag = -1 WHERE po_id = @poID", conn);
                    cmdC.Parameters.AddWithValue("@poID", _poID);
                    cmdC.ExecuteNonQuery();

                    break;
            }
        




        }







    }
}
