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
    public string strRegioni_Ky = "";
    
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            int intNum =0;
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
		        strInput = Request.QueryString["input"];
		        strRegioni_Ky = Request.QueryString["Regioni_Ky"];
		        if (strInput==null || strInput.Length<1){
					strInput = Request.QueryString["term"];
				}
		        SqlConnection objConnection = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
				objConnection.Open();
		        if (strRegioni_Ky!=null || strRegioni_Ky.Length>0){
    		          strWHERE = "(Regioni_Ky=" + strRegioni_Ky + ")";
				}else{
    		        if ((strInput!=null) && (strInput!="")){
    		          strInput=strInput.Replace("'","''");
    		          strWHERE = "(Province_Provincia like '%" + strInput + "%')";
    		        }else{
    		          strWHERE = "Not (Province_Provincia Is Null)";  
    		        }
                }

		        strWHERE = getWhere();
		        strSQL = "SELECT Province_Ky, Province_Provincia FROM Province WHERE " + strWHERE + " ORDER BY Province_Provincia";
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
			                objX.WriteLine("\"id\" : \"" + objReader["Province_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["Province_Provincia"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["Province_Ky"].ToString() + "\"");
			                objX.WriteLine("}");
			                intNum++;
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
        if (strRegioni_Ky!=null || strRegioni_Ky.Length>0){
		          strWHERE = "(Regioni_Ky=" + strRegioni_Ky + ")";
		}else{
                if ((strInput!=null) && (strInput!="")){
                  strInput=strInput.Replace("'","''");
                  strWHERE = "(Province_Provincia like '%" + strInput + "%')";
                }else{
                  strWHERE = "Not (Province_Provincia Is Null)";  
                }
        }			
        return strWHERE;
    }


    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
