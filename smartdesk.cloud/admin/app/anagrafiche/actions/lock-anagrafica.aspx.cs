using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strAnagrafiche_Ky="";
    public string strLock="";
    public string strSorgente="";
    public string strCommesse_Ky="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	  
      if (Smartdesk.Login.Verify){
                strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
                strLock=Request["lock"];
                strSorgente=Smartdesk.Current.Request("sorgente");
	        	strCommesse_Ky=Smartdesk.Current.Request("Commesse_Ky");
                strSQL = "UPDATE Anagrafiche SET Anagrafiche_Lock=" + strLock + " WHERE Anagrafiche_Ky=" + strAnagrafiche_Ky;
                new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                switch (strSorgente){
                  case "scheda-anagrafiche":
                    Response.Redirect("/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                  case "elenco-anagrafiche":
                    Response.Redirect("/admin/view.aspx?CoreModules_Ky=1&CoreEntities_Ky=162&CoreGrids_Ky=199&Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
                  case "elenco-documenti":
                    Response.Redirect("/admin/app/documenti/elenco-documenti.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                    break;
    		          case "scheda-commessa":
    		            Response.Redirect("/admin/goto-form.aspx?CoreEntities_Ky=107&Commesse_Ky=" + strCommesse_Ky);
    		            break;
                }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
  }
