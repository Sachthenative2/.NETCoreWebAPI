using System.Data.SqlClient;

namespace WEB_API
{
    public class DBManager
    {
        public string connectionString;
        public DBManager()
        {
            connectionString = AppConfig.GetConnectionString();
        }

        public List<Temp> GetData()
        {
            List<Temp> lData = new List<Temp>();
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("csp_getdata",con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@process", System.Data.SqlDbType.VarChar, 50).Value = "get";
                SqlDataReader sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    Temp temp = new Temp();
                    temp.Column1 = sdr["Column1"].ToString();
                    temp.Column2 = sdr["Column2"].ToString();
                    lData.Add(temp);
                }
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return lData;
        }
        public bool SaveData(Temp temp)
        {
            bool result  = false;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("csp_getdata", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@process", System.Data.SqlDbType.VarChar, 50).Value = "put";
                cmd.Parameters.Add("@column1", System.Data.SqlDbType.VarChar, 50).Value = temp.Column1;
                cmd.Parameters.Add("@column2", System.Data.SqlDbType.VarChar, 50).Value = temp.Column2;
                cmd.ExecuteNonQuery();
               result = true;
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public bool RemoveData(string a)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("csp_getdata", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@process", System.Data.SqlDbType.VarChar, 50).Value = "delete";
                cmd.Parameters.Add("@column1", System.Data.SqlDbType.VarChar, 50).Value = a;
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }
        public bool UpdateData(string a, string b)
        {
            bool result = false;
            SqlConnection con = new SqlConnection(connectionString);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("csp_getdata", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@process", System.Data.SqlDbType.VarChar, 50).Value = "update";
                cmd.Parameters.Add("@column1", System.Data.SqlDbType.VarChar, 50).Value = a;
                cmd.Parameters.Add("@column2", System.Data.SqlDbType.VarChar, 50).Value = b;
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception ex)
            {
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return result;
        }
    }
}
