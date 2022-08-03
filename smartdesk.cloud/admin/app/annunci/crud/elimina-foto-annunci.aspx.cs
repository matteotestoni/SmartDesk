using System;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page {
    
	public int intNumRecords = 0;
    public DataTable dtAnnunci;
   	public string strAnnunci_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
      string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
      string strAste_Ky="";
      string strFoto="";
      string strFields="";
      int i=0;
  	  string strWHERENet="";
  	  string strFROMNet = "";
  	  string strORDERNet = "";

      if (Smartdesk.Login.Verify){
          strAnnunci_Ky = Smartdesk.Current.Request("Annunci_Ky");
          strAste_Ky = Smartdesk.Current.Request("Aste_Ky");
          strFoto = Smartdesk.Current.Request("foto");
            if (strDeletemultiplo=="deletemultiplo"){
			  string[] words = strIds.Split(',');
	          foreach (string word in words){
	          	strFields = strFields + "Annunci_Foto" + word + "=null, ";
	          	i++;
	          }
	          strFields=strFields.Substring(0, strFields.Length-2);
	          strSQL = "UPDATE Annunci SET " + strFields + " WHERE Annunci_Ky=" + strAnnunci_Ky;
			  Response.Write(strSQL);
	          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }else{
	          strSQL = "UPDATE Annunci SET Annunci_Foto" + strFoto + "=null WHERE Annunci_Ky=" + strAnnunci_Ky;
	          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            }
            strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
            strORDERNet = "Annunci_Ky";
            strFROMNet = "Annunci";
            dtAnnunci = new DataTable("Annunci");
            dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            aggiornaNumeroFoto();
        	riordinaFoto();
            Response.Redirect("/admin/app/annunci/scheda-annunci.aspx?Annunci_Ky=" + strAnnunci_Ky);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public bool aggiornaNumeroFoto()
    {
        string strSQL="";
        string strTemp="";
      	int intNumeroFoto=0;
        bool output = false;
        
  		for (int i = 1; i < 51; i++){
			strTemp="Annunci_Foto" + i;
			if (dtAnnunci.Rows[0][strTemp].ToString().Length>0){
				intNumeroFoto++;
			}
  		}
        strSQL = "UPDATE Annunci SET Annunci_NumeroFoto=" + (intNumeroFoto) + " WHERE Annunci_Ky = " + strAnnunci_Ky;
      	new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }


    public bool riordinaFoto()
    {
        string strSQL="";
        string strTemp="";
        string strUpdate="";
      	int intNuovoNumero=1;
        bool output = false;
        
  		for (int i = 1; i < 51; i++){
			strTemp="Annunci_Foto" + i;
			if (dtAnnunci.Rows[0][strTemp].ToString().Length>0){
				if (strUpdate.Length>0){
					strUpdate=strUpdate+",";
				}
				strUpdate+="Annunci_Foto" + intNuovoNumero + "='" + dtAnnunci.Rows[0][strTemp].ToString() + "'";
				intNuovoNumero++;
			}
  		}
		//intNuovoNumero++;
  		for (int i = intNuovoNumero; i < 51; i++){
			if (strUpdate.Length>0){
				strUpdate=strUpdate+",";
			}
			strUpdate+="Annunci_Foto" + i + "=null";
  		}

        strSQL = "UPDATE Annunci SET " + strUpdate + " WHERE Annunci_Ky = " + strAnnunci_Ky;
      	Response.Write(strSQL);
		new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        output=true;
        return output;
    }
}
