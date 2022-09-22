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
      
	  
      Response.Write(1);
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
		          strWHERE = "((Anagrafiche_RagioneSociale like '%" + strInput + "%' Or Anagrafiche_ParoleChiave like '%" + strInput + "%') And (Anagrafiche_Disdetto=0))";
		        }else{
		          strWHERE = "Not (Anagrafiche_RagioneSociale Is Null And Anagrafiche_Disdetto=0)";  
		        }
		        strWHERE = getWhere();
		        strSQL = "SELECT TOP 10 Anagrafiche_Ky,Anagrafiche_RagioneSociale,AnagraficheTipologia_Ky,Anagrafiche_Cognome,Anagrafiche_Nome,Anagrafiche_Indirizzo,Anagrafiche_CAP,Anagrafiche_Telefono,Anagrafiche_EmailContatti,Anagrafiche_PartitaIVA,Anagrafiche_CodiceFiscale FROM Anagrafiche WHERE " + strWHERE + " ORDER BY Anagrafiche_RagioneSociale";
		        Response.Write(strSQL);
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
			                objX.WriteLine("\"id\" : \"" + objReader["Anagrafiche_Ky"].ToString() + "\",");
			                objX.WriteLine("\"label\" : \"" + objReader["Anagrafiche_RagioneSociale"].ToString() + "\",");
			                objX.WriteLine("\"value\" : \"" + objReader["Anagrafiche_Ky"].ToString() + "\",");
			                objX.WriteLine("\"AnagraficheTipologia_Ky\" : \"" + objReader["AnagraficheTipologia_Ky"].ToString() + "\",");
			                objX.WriteLine("\"nome\" : \"" + objReader["Anagrafiche_Nome"].ToString() + "\",");
			                objX.WriteLine("\"cognome\" : \"" + objReader["Anagrafiche_Cognome"].ToString() + "\",");
			                objX.WriteLine("\"indirizzo\" : \"" + objReader["Anagrafiche_Indirizzo"].ToString() + "\",");
			                objX.WriteLine("\"cap\" : \"" + objReader["Anagrafiche_CAP"].ToString() + "\",");
			                objX.WriteLine("\"telefono\" : \"" + objReader["Anagrafiche_Telefono"].ToString() + "\",");
			                objX.WriteLine("\"emailcontatti\" : \"" + objReader["Anagrafiche_EmailContatti"].ToString() + "\",");
			                objX.WriteLine("\"piva\" : \"" + objReader["Anagrafiche_PartitaIVA"].ToString() + "\",");
			                objX.WriteLine("\"codfisc\" : \"" + objReader["Anagrafiche_CodiceFiscale"].ToString() + "\"");
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
        Response.Write(1);
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
          strWHERE = "((Anagrafiche_RagioneSociale like '%" + strInput + "%' Or Anagrafiche_ParoleChiave like '%" + strInput + "%') And (Anagrafiche_Disdetto=0))";
        }else{
          strWHERE = "Not (Anagrafiche_RagioneSociale Is Null And Anagrafiche_Disdetto=0)";  
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
}
