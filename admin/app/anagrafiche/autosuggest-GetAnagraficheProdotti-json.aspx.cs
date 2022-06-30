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
		          strWHERE = "(AnagraficheProdotti_Titolo like '%" + strInput + "%' Or AnagraficheProdotti_Descrizione like '%" + strInput + "%')";
		        }else{
		          strWHERE = "Not (AnagraficheProdotti_Titolo Is Null)";  
		        }
		        strWHERE = getWhere();
		        strSQL = "SELECT TOP 10 AnagraficheProdotti_Ky,AnagraficheProdotti_Titolo FROM AnagraficheProdotti WHERE " + strWHERE + " ORDER BY AnagraficheProdotti_Titolo";
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
			                objX.WriteLine("\"id\" : \"" + objReader["AnagraficheProdotti_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["AnagraficheProdotti_Titolo"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["AnagraficheProdotti_Ky"].ToString() + "\"");
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
          strWHERE = "(AnagraficheProdotti_Titolo like '%" + strInput + "%' Or AnagraficheProdotti_Descrizione like '%" + strInput + "%')";
        }else{
          strWHERE = "Not (AnagraficheProdotti_Titolo Is Null)";  
        }
    	//permessi
      		switch (dtLogin.Rows[0]["UtentiGruppi_AnagraficheQuali"].ToString()){
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
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheClienti"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And AnagraficheTipo_Ky<>1";	
				}else{
					strWHEREPermessi="AnagraficheTipo_Ky<>1";	
				}
			}
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheFornitori"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And AnagraficheTipo_Ky<>4";	
				}else{
					strWHEREPermessi="AnagraficheTipo_Ky<>4";	
				}
			}
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheConcorrenti"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And AnagraficheTipo_Ky<>5";	
				}else{
					strWHEREPermessi="AnagraficheTipo_Ky<>5";	
				}
			}
			if (dtLogin.Rows[0]["UtentiGruppi_AnagraficheLead"].Equals(false)){
				if (strWHEREPermessi.Length>0){
					strWHEREPermessi+=" And AnagraficheTipo_Ky<>3";	
				}else{
					strWHEREPermessi="AnagraficheTipo_Ky<>3";	
				}
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


    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
