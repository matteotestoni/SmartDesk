using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Text;
using System.IO;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strSQL = "";
    public string strWHERE = "";
    public string strInput = "";
    
    public int intNumRecords = 0;
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";

      if (Request.Cookies["rswcrm-az"] != null){
        strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
        strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
        strORDERNet = "Anagrafiche_Ky";
        strFROMNet = "Anagrafiche";
        dtLogin = new DataTable("Login");
        dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (dtLogin.Rows.Count>0){
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
		          strWHERE = "(AnnunciMarca_Titolo like '%" + strInput + "%')";
		        }else{
		          strWHERE = "Not (AnnunciMarca_Titolo Is Null)";  
		        }
		        strWHERE = getWhere();
		        strSQL = "SELECT TOP 10 AnnunciMarca_Ky, AnnunciMarca_Titolo FROM AnnunciMarca WHERE " + strWHERE + " ORDER BY AnnunciMarca_Titolo";
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
			                objX.WriteLine("\"id\" : \"" + objReader["AnnunciMarca_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["AnnunciMarca_Titolo"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["AnnunciMarca_Titolo"].ToString() + "\"");
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
      	  TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
      	  objX.WriteLine("non loggato");
  		  objX.Flush();
  		  objX.Close();
  		  Response.End();
        }
      }else{
        Response.Clear();
    	Response.ContentType = "application/json";
    	TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
    	objX.WriteLine("no cookie");
		objX.Flush();
		objX.Close();
		Response.End();
      }
    }

    public string getWhere()
    {
        string strWHERE="";

        strWHERE="";
        if ((strInput!=null) && (strInput!="")){
          strInput=strInput.Replace("'","''");
          strWHERE = "(AnnunciMarca_Titolo like '%" + strInput + "%')";
        }else{
          strWHERE = "Not (AnnunciMarca_Titolo Is Null)";  
        }			
        return strWHERE;
    }
}
