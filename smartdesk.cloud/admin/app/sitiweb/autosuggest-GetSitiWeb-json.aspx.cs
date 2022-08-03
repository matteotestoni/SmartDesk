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
		          strWHERE = "(SitiWeb_Dominio like '%" + strInput + "%')";
		        }else{
		          strWHERE = "Not (SitiWeb_Dominio Is Null)";  
		        }
		        strWHERE = getWhere();
		        strSQL = "SELECT TOP 10 SitiWeb_Ky, SitiWeb_Dominio FROM SitiWeb WHERE " + strWHERE + " ORDER BY SitiWeb_Dominio";
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
			                objX.WriteLine("\"id\" : \"" + objReader["SitiWeb_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["SitiWeb_Dominio"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["SitiWeb_Ky"].ToString() + "\"");
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
        string strWHEREPermessi="";

        strWHERE="";
        if ((strInput!=null) && (strInput!="")){
          strInput=strInput.Replace("'","''");
          strWHERE = "(SitiWeb_Dominio like '%" + strInput + "%')";
        }else{
          strWHERE = "Not (SitiWeb_Dominio Is Null)";  
        }
    	//permessi
      		switch (dtLogin.Rows[0]["UtentiGruppi_ProduzioneQuali"].ToString()){
      			case "1":
      				strWHEREPermessi="";
      				break;
      			case "2":
       				strWHEREPermessi="UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
     				break;
      			case "3":
       				strWHEREPermessi="Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
      				break;
			}
			if (strWHEREPermessi.Length>0){
				if (strWHERE.Length>0){
					strWHERE=strWHERE + " And " + strWHEREPermessi;
				}else{
					strWHERE=strWHEREPermessi;
				}	
			}	
			
        //Response.Write("1:" + strWHEREPermessi);
        //Response.Write("2:" + strWHERE);
        return strWHERE;
    }
}
