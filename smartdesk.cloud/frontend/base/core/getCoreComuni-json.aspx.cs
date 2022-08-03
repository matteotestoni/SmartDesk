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
    public string strProvince_Ky = "";
    
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
            dtLogin = Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            int intNum =0;
				Response.Cache.SetCacheability(HttpCacheability.NoCache);
		        strInput = Request.QueryString["input"];
		        strProvince_Ky = Request.QueryString["Province_Ky"];
		        if (strInput==null || strInput.Length<1){
					strInput = Request.QueryString["term"];
				}
		        SqlConnection objConnection = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
				objConnection.Open();
		        if (strProvince_Ky!=null || strProvince_Ky.Length>0){
    		        strWHERE = "(Province_Ky=" + strProvince_Ky + ")";
				}else{
    		        if ((strInput!=null) && (strInput!="")){
    		          strInput=strInput.Replace("'","''");
    		          strWHERE = "(Comuni_Comune like '%" + strInput + "%')";
    		        }else{
    		          strWHERE = "Not (Comuni_Comune Is Null)";  
    		        }
                }
		        strWHERE = getWhere();
		        strSQL = "SELECT Comuni_Ky, Comuni_Comune FROM Comuni WHERE " + strWHERE + " ORDER BY Comuni_Comune";
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
			                objX.WriteLine("\"id\" : \"" + objReader["Comuni_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["Comuni_Comune"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["Comuni_Ky"].ToString() + "\"");
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
        if (strProvince_Ky!=null || strProvince_Ky.Length>0){
    	        strWHERE = "(Province_Ky=" + strProvince_Ky + ")";
    	}else{
            if ((strInput!=null) && (strInput!="")){
              strInput=strInput.Replace("'","''");
              strWHERE = "(Comuni_Comune like '%" + strInput + "%')";
            }else{
              strWHERE = "Not (Comuni_Comune Is Null)";  
            }
        }			
        return strWHERE;
    }
}
