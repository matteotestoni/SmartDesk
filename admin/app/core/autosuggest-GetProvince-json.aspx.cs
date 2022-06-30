using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Xml;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strSQL = "";
    public string strWHERE = "";
    public string strInput = "";
    public string strTable = "";
    public string strFields = "";
    public string strCompare = "";
    public string strKey = "";
    public string strLabel = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        int intNum=0;
		Response.Cache.SetCacheability(HttpCacheability.NoCache);
        strInput = Request.QueryString["input"];
        if (strInput==null || strInput.Length<1){
			strInput = Request.QueryString["term"];
		}
        SqlConnection objConnection = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
		objConnection.Open();
        strTable="Province_Vw";
        strFields= "Province_Ky,Province_Provincia";
        strCompare= "Province_Provincia";
        strKey="Province_Ky";
        strLabel= "Province_Provincia";
		if ((strInput!=null) && (strInput!="")){
            strInput=strInput.Replace("'","''");
            strWHERE = "(" + strCompare + " like '%" + strInput + "%')";
        }else{
            strWHERE = "";  
        }
        strSQL = "SELECT TOP 10 " + strFields + " FROM " + strTable + " WHERE " + strWHERE + " ORDER BY " + strCompare;
        if ((strInput!=null) && (strInput!="")){
            strInput=strInput.Replace("'","''");
            strWHERE = "(Province_Provincia like '%" + strInput + "%')";
          }else{
            strWHERE = "Not (Province_Provincia Is Null)";  
          }
        strSQL = "SELECT TOP 10 " + strFields + " FROM " + strTable + " WHERE " + strWHERE + " ORDER BY " + strCompare;
        SqlCommand objCommand = new SqlCommand(strSQL, objConnection);
        SqlDataReader objReader = objCommand.ExecuteReader();
        Response.Clear();
    	  Response.ContentType = "application/json";
    	  TextWriter  objX = new StreamWriter(Response.OutputStream, Encoding.UTF8);
    	  objX.WriteLine("[");
          while (objReader.Read())
			    {
                    if (intNum>0){
                        objX.WriteLine(",");
					}
					objX.WriteLine("{");
                    objX.WriteLine("\"id\" : \"" + objReader[strKey].ToString() + "\",");
                    objX.WriteLine("\"label\" : \"" + objReader[strLabel].ToString() + "\",");
                    objX.WriteLine("\"value\" : \"" + objReader[strKey].ToString() + "\"");
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


}
