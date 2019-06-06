using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DeliveryManagerUI.ClassLib
{
    public class Location
    {


        public string _stockCode { get; set; }
        public string _location { get; set; }
        public double _updateValue { get; set; }

        public Location(string stockCode, string location, double updateValue)
        {
            _stockCode = stockCode;
            _location = location;
            _updateValue = updateValue;
        }




        public void updateInsertLocation()
        {
            using (SqlConnection con = new SqlConnection(CS.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_update_stores_location", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@stockCode", SqlDbType.VarChar).Value = _stockCode;
                    cmd.Parameters.Add("@location", SqlDbType.VarChar).Value = _location;
                    cmd.Parameters.Add("@updateValue", SqlDbType.Float).Value = _updateValue;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

        }
    }
}
