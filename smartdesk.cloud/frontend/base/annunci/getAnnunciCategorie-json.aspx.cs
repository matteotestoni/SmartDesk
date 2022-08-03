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
    public string strAnnunciCategorie_Ky = "";
    
    public int intNumRecords = 0;
    public DataTable dtLogin;

    protected void Page_Load(object sender, EventArgs e)
    {
      
        int intNum =0;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        strAnnunciCategorie_Ky = Request.QueryString["AnnunciCategorie_Ky"];
        SqlConnection objConnection = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        objConnection.Open();
          if ((strAnnunciCategorie_Ky!=null) && (strAnnunciCategorie_Ky!="")){
            strAnnunciCategorie_Ky=strAnnunciCategorie_Ky.Replace("'","''");
            strWHERE = "(AnnunciCategorie_Padre=" + strAnnunciCategorie_Ky + ")";
          }else{
            strWHERE = "Not (AnnunciCategorie_Titolo Is Null)";  
          }			
          strWHERE = getWhere();
          strSQL = "SELECT AnnunciCategorie_Ky, AnnunciCategorie_Titolo FROM AnnunciCategorie WHERE " + strWHERE + " ORDER BY AnnunciCategorie_Titolo";
          SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
          SqlDataReader objReader = objCommand.ExecuteReader();
          Response.Clear();
      	  Response.ContentType = "application/json";
      	  TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
	  	  objX.WriteLine("{\"categorie\":[");
            while (objReader.Read()){
                    if (intNum>0){
                    	objX.WriteLine(",");
      			}
      			objX.WriteLine("{");
                    objX.WriteLine("\"id\" : \"" + objReader["AnnunciCategorie_Ky"].ToString() + "\",");
                    objX.WriteLine("\"label\" : \"" + objReader["AnnunciCategorie_Titolo"].ToString() + "\",");
                    objX.WriteLine("\"value\" : \"" + objReader["AnnunciCategorie_Ky"].ToString() + "\"");
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
        if ((strAnnunciCategorie_Ky!=null) && (strAnnunciCategorie_Ky!="")){
          strAnnunciCategorie_Ky=strAnnunciCategorie_Ky.Replace("'","''");
          strWHERE = "(AnnunciCategorie_Padre=" + strAnnunciCategorie_Ky + ")";
        }else{
          strWHERE = "Not (AnnunciCategorie_Titolo Is Null)";  
        }			
        return strWHERE;
    }
}
