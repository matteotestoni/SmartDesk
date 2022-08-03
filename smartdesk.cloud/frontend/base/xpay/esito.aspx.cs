using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public bool boolAdmin = false;
    public string strUtentiLogin="";
    public bool boolSSL = false;
    public DataTable dtAsteEsperimenti;
    public DataTable dtAste;
    public string strAste_Ky="";
    public string strAsteEsperimenti_Ky="";
    public string strCausale="";
    public string strUri="";
    public string strValue="";
    public string strKey="";
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public string strEsito="";
    public string strSQL="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
      string strUrlPerPagare = "";

      boolSSL=Request.IsSecureConnection;
	  System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
      

      strWHERENet = "AnnunciCategorie_Padre=0";
      dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	  strWHERENet = "";
      dtAsteCategorie = new DataTable("AsteCategorie");
      dtAsteCategorie = Smartdesk.Sql.getTablePage("AsteCategorie", null, "AsteCategorie_Ky", strWHERENet, "AsteCategorie_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtLogin.Rows.Count>0){
                strEsito=Request["esito"];
                strAsteEsperimenti_Ky=Request["num_contratto"].Split('-')[0];
                strAste_Ky=Request["num_contratto"].Split('-')[1];
                
                if (strEsito=="OK"){
                   //se esito ok metto la cauzione    
                   strSQL="INSERT INTO AsteCauzioni (Anagrafiche_Ky,Aste_Ky,AsteEsperimenti_Ky,AsteCauzioni_Data,AsteCauzioni_Valore,PagamentiMetodo_Ky,AsteCauzioni_Autorizzata,AsteCauzioni_Riferimenti,AsteCauzioni_UserInsert,AsteCauzioni_UserUpdate,AsteCauzioni_UserDelete,AsteCauzioni_DateInsert,AsteCauzioni_DateUpdate,AsteCauzioni_DateDelete, Conti_Ky)";
                   strSQL+=" VALUES (";
                   strSQL+=strUtentiLogin + ",";
                   strSQL+=strAste_Ky + ",";
                   strSQL+=strAsteEsperimenti_Ky + ",";
                   strSQL+="GETDATE(),";
                   strSQL+=Convert.ToInt32(Request["importo"])/100 + ",";
                   strSQL+="4,";
                   strSQL+="1,";
                   strSQL+="'" + Request["codTrans"] + "-" + Request["codAut"] + "',";
                   strSQL+="0,";
                   strSQL+="0,";
                   strSQL+="0,";
                   strSQL+="GETDATE(),";
                   strSQL+="GETDATE(),";
                   strSQL+="GETDATE(),";
                   strSQL+="1)";
                }else{
                   strSQL="INSERT INTO AsteCauzioni (Anagrafiche_Ky,Aste_Ky,AsteEsperimenti_Ky,AsteCauzioni_Data,AsteCauzioni_Valore,PagamentiMetodo_Ky,AsteCauzioni_Autorizzata,AsteCauzioni_Riferimenti,AsteCauzioni_UserInsert,AsteCauzioni_UserUpdate,AsteCauzioni_UserDelete,AsteCauzioni_DateInsert,AsteCauzioni_DateUpdate,AsteCauzioni_DateDelete, Conti_Ky)";
                   strSQL+=" VALUES (";
                   strSQL+=strUtentiLogin + ",";
                   strSQL+=strAste_Ky + ",";
                   strSQL+=strAsteEsperimenti_Ky + ",";
                   strSQL+="GETDATE(),";
                   strSQL+=Convert.ToInt32(Request["importo"])/100 + ",";
                   strSQL+="4,";
                   strSQL+="0,";
                   strSQL+="'" + Request["codTrans"] + "-" + Request["codAut"] + "',";
                   strSQL+="0,";
                   strSQL+="0,";
                   strSQL+="0,";
                   strSQL+="GETDATE(),";
                   strSQL+="GETDATE(),";
                   strSQL+="GETDATE(),";
                   strSQL+="1)";
                }
                //Response.Write(strSQL);
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
             
            }else{
              Response.Redirect("/login.aspx");
            }
      }else{
        Response.Redirect("/login.aspx");
        strLogin="<a href=\"/account/login.html\"><i class=\"fa fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa fa-user-plus fa-lg fa-fw\"></i>Registrati</a>";
        boolLogin=false;
      }
    }
}


