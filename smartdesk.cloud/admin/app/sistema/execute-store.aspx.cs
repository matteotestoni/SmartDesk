using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
      SqlConnection conn;
      conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
      conn.Open();
      
      using (SqlCommand cmd = new SqlCommand("frk_Create_Field", conn))
      {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@XmlDoc", "<db><rs><Vw>VeicoliPrenotazioni</Vw><App>29</App></rs></db>");
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                       //more code
                }
             }
        }
      }
      /*
      using (SqlCommand cmd = new SqlCommand("frk_Create_Field", conn))
      {
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@XmlDoc", "<db><rs><Vw>VeicoliPrenotazioni</Vw><App>29</App></rs></db>");
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            if (reader.HasRows)
            {
                if (reader.Read())
                {
                       //more code
                }
             }
        }
      }*/
      Response.Write("ok");
    }    
}
