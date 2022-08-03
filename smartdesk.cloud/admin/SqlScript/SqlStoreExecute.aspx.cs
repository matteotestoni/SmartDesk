using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml;

public partial class _Default : System.Web.UI.Page
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    
    string strNomeStore = "";
    string strNomeTabella = "";
    string strKy = "";
    string strValue = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        

        strNomeStore = Request["st"];
        strNomeTabella = Request["AnnunciModello"];
        strKy = Request["AnnunciModello_Ky"];
        SqlConnection sqlConnection1 = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        SqlCommand cmd = new SqlCommand();
        SqlDataReader reader;
        cmd.CommandText = strNomeStore;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = sqlConnection1;
        cmd.Parameters.Add("@tb", SqlDbType.VarChar).Value = strNomeTabella;
        cmd.Parameters.Add("@ky", SqlDbType.VarChar).Value = strKy;
        cmd.Parameters.Add("@vl", SqlDbType.VarChar).Value = strValue;
        sqlConnection1.Open();
        reader = cmd.ExecuteReader();     
        sqlConnection1.Close();  
    }
}
