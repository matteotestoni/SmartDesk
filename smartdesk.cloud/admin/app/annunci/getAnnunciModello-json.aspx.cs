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
    public string strAnnunciMarca_Ky = "";
    
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        int intNum =0;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        strAnnunciMarca_Ky = Request.QueryString["AnnunciMarca_Ky"];
        SqlConnection objConnection = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        objConnection.Open();
          if ((strAnnunciMarca_Ky!=null) && (strAnnunciMarca_Ky!="")){
            strAnnunciMarca_Ky=strAnnunciMarca_Ky.Replace("'","''");
            strWHERE = "(AnnunciMarca_Ky=" + strAnnunciMarca_Ky + ")";
              }else{
                strWHERE = "Not (AnnunciModello_Titolo Is Null)";  
              }			
          strWHERE = getWhere();
          strSQL = "SELECT AnnunciModello_Ky, AnnunciModello_Titolo FROM AnnunciModello WHERE " + strWHERE + " ORDER BY AnnunciModello_Titolo";
          SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
          SqlDataReader objReader = objCommand.ExecuteReader();
          Response.Clear();
      	  Response.ContentType = "application/json";
      	  TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
	  	  objX.WriteLine("{\"modelli\":[");
            while (objReader.Read()){
                    if (intNum>0){
                    	objX.WriteLine(",");
      			}
      			objX.WriteLine("{");
                    objX.WriteLine("\"id\" : \"" + objReader["AnnunciModello_Ky"].ToString() + "\",");
                    objX.WriteLine("\"label\" : \"" + objReader["AnnunciModello_Titolo"].ToString() + "\",");
                    objX.WriteLine("\"value\" : \"" + objReader["AnnunciModello_Ky"].ToString() + "\"");
                    objX.WriteLine("}");
                    intNum++;
           }
      	objX.WriteLine("]");
		objX.WriteLine("}");
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
        if ((strAnnunciMarca_Ky!=null) && (strAnnunciMarca_Ky!="")){
          strAnnunciMarca_Ky=strAnnunciMarca_Ky.Replace("'","''");
          strWHERE = "(AnnunciMarca_Ky=" + strAnnunciMarca_Ky + ")";
        }else{
          strWHERE = "Not (AnnunciModello_Titolo Is Null)";  
        }			
        return strWHERE;
    }
}
