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
        if ((strInput!=null) && (strInput!="")){
            strInput=strInput.Replace("'","''");
            strWHERE = "((Servizi_Titolo like '%" + strInput + "%' Or Servizi_Codice like '%" + strInput + "%'))";
          }else{
            strWHERE = "Not (Servizi_Titolo Is Null)";  
          }
        strSQL = "SELECT TOP 10 Servizi_Ky,Servizi_Titolo, Servizi_Descrizione,Servizi_Codice,Servizi_Prezzo,AttributiGruppi_Ky FROM Servizi WHERE " + strWHERE + " ORDER BY Servizi_Titolo";
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
                    objX.WriteLine("\"id\" : \"" + objReader["Servizi_Ky"].ToString() + "\",");
                    objX.WriteLine("\"label\" : \"" + objReader["Servizi_Titolo"].ToString() + "\",");
                    objX.WriteLine("\"value\" : \"" + objReader["Servizi_Ky"].ToString() + "\",");
                    objX.WriteLine("\"prezzo\" : \"" + objReader["Servizi_Prezzo"].ToString().Replace(",0000","") + "\",");
                    objX.WriteLine("\"attributigruppi_ky\" : \"" + objReader["AttributiGruppi_Ky"].ToString() + "\",");
                    objX.WriteLine("\"descrizione\" : \"" + EncodeTo64(objReader["Servizi_Descrizione"].ToString().Trim()) + "\"");
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

		public static string EncodeTo64(string toEncode)
		{
				byte[] arrayToEncode = System.Text.Encoding.Unicode.GetBytes(toEncode);
		    return System.Convert.ToBase64String(arrayToEncode);
		}

}
