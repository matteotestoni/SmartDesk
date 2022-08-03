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
    public string strNazioni_Ky = "";
    
    public int intNumRecords = 0;
    public DataTable dtLogin;
    public int intRiga = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            int intNum =0;
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
		        strInput = Request.QueryString["input"];
		        strNazioni_Ky = Request.QueryString["Nazioni_Ky"];
		        if (strInput==null || strInput.Length<1){
					strInput = Request.QueryString["term"];
				}
		        SqlConnection objConnection = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
				objConnection.Open();
		        if (strNazioni_Ky!=null || strNazioni_Ky.Length>0){
    		          strWHERE = "(Nazioni_Ky=" + strNazioni_Ky + ")";
				}else{
    		        if ((strInput!=null) && (strInput!="")){
    		          strInput=strInput.Replace("'","''");
    		          strWHERE = "(Regioni_Regione like '%" + strInput + "%')";
    		        }else{
    		          strWHERE = "Not (Regioni_Regione Is Null)";  
    		        }
                }

		        strWHERE = getWhere();
		        strSQL = "SELECT Regioni_Ky, Regioni_Regione FROM Regioni WHERE " + strWHERE + " ORDER BY Regioni_Regione";
		        SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
		        SqlDataReader objReader = objCommand.ExecuteReader();
		        Response.Clear();
			  	  Response.ContentType = "application/json";
			  	  TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
			  	  objX.WriteLine("[");
			        intRiga=0;
                    while (objReader.Read()){
			                if (intNum>0){
			                	objX.WriteLine(",");
							}
							objX.WriteLine("{");
			                objX.WriteLine("\"id\" : \"" + objReader["Regioni_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["Regioni_Regione"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["Regioni_Ky"].ToString() + "\"");
			                objX.WriteLine("}");
			                intNum++;
			                intRiga++;
				     }
					objX.WriteLine("]");
					objReader.Close();
					objConnection.Close();
					objX.Flush();
					objX.Close();
					Response.End();
    }

    public string getWhere()
    {
        string strWHERE="";

        strWHERE="";
        if (strNazioni_Ky!=null || strNazioni_Ky.Length>0){
		          strWHERE = "(Nazioni_Ky=" + strNazioni_Ky + ")";
		}else{
                if ((strInput!=null) && (strInput!="")){
                  strInput=strInput.Replace("'","''");
                  strWHERE = "(Regioni_Regione like '%" + strInput + "%')";
                }else{
                  strWHERE = "Not (Regioni_Regione Is Null)";  
                }
        }			
        return strWHERE;
    }
}
