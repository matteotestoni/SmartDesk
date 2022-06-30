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
        strTable="Comuni_Vw";
        strFields= "Comuni_Ky,Comuni_Comune,Comuni_Cap";
        strCompare= "Comuni_Comune";
        strKey="Comuni_Ky";
        strLabel= "Comuni_Comune";
		if ((strInput!=null) && (strInput!="")){
            strInput=strInput.Replace("'","''");
            strWHERE = "(" + strCompare + " like '%" + strInput + "%')";
        }else{
            strWHERE = "";  
        }
        strSQL = "SELECT TOP 10 " + strFields + " FROM " + strTable + " WHERE " + strWHERE + " ORDER BY " + strCompare;
        if ((strInput!=null) && (strInput!="")){
            strInput=strInput.Replace("'","''");
            strWHERE = "((Comuni_Comune like '%" + strInput + "%') And (Comuni_Zona=0))";
          }else{
            strWHERE = "Not (Comuni_Comune Is Null And Comuni_Zona=0)";  
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
                    objX.WriteLine("\"value\" : \"" + objReader[strKey].ToString() + "\",");
                    objX.WriteLine("\"cap\" : \"" + objReader["Comuni_Cap"].ToString() + "\"");
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
