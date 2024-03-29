using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.IO;


public partial class _Default : System.Web.UI.Page
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strSQL = "";
    public string strWHERE = "";
    public string strInput = "";
    
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            int intNum =0;
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
		        strInput = Request.QueryString["input"];
		        if (strInput==null || strInput.Length<1){
					strInput = Request.QueryString["term"];
				}
		        SqlConnection objConnection = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
				objConnection.Open();
		        if ((strInput!=null) && (strInput!="")){
		          strInput=strInput.Replace("'","''");
		          strWHERE = "(Opportunita_Titolo like '%" + strInput + "%')";
		        }else{
		          strWHERE = "Not (Opportunita_Titolo Is Null)";  
		        }
		        strWHERE = getWhere();
		        strSQL = "SELECT TOP 10 Opportunita_Ky,Opportunita_Titolo, Anagrafiche_Ky, Anagrafiche_RagioneSociale FROM Opportunita_Vw WHERE " + strWHERE + " ORDER BY Opportunita_Titolo";
		        SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
		        SqlDataReader objReader = objCommand.ExecuteReader();
		        Response.Clear();
			  	  Response.ContentType = "application/json";
			  	  TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
			  	  objX.WriteLine("[");
			        while (objReader.Read()){
			                if (intNum>0){
			                	objX.WriteLine(",");
							}
							objX.WriteLine("{");
			                objX.WriteLine("\"id\" : \"" + objReader["Opportunita_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["Opportunita_Titolo"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["Opportunita_Ky"].ToString() + "\",");
			                objX.WriteLine("\"Anagrafiche_Ky\" : \"" + objReader["Anagrafiche_Ky"].ToString() + "\",");
			                objX.WriteLine("\"Anagrafiche_RagioneSociale\" : \"" + objReader["Anagrafiche_RagioneSociale"].ToString() + "\"");
			                objX.WriteLine("}");
			                intNum++;
				     }
					objX.WriteLine("]");
					objReader.Close();
					objConnection.Close();
					objX.Flush();
					objX.Close();
					Response.End();
      }else{
        Response.Clear();
    	Response.ContentType = "application/json";
		Response.End();
      }
    }

    public string getWhere()
    {
        string strWHERE="";

        strWHERE="";
        if ((strInput!=null) && (strInput!="")){
          strInput=strInput.Replace("'","''");
          strWHERE = "(Opportunita_Titolo like '%" + strInput + "%')";
        }else{
          strWHERE = "Not (Opportunita_Titolo Is Null)";  
        }
    	//permessi
        return strWHERE;
    }
}
