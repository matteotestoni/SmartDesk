using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page 
	{
    public string strAzione = "";
    
    public DataTable dtRegioni;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    public string strSorgente="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strNazioni_Ky = "";
      
	  
      if (Smartdesk.Login.Verify){
		dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());       
		strAzione = Request["azione"];
        strSorgente=Smartdesk.Current.Request("sorgente");
        strNazioni_Ky = Smartdesk.Current.Request("Nazioni_Ky");
		strKy = Smartdesk.Functions.SqlWriteKey("Regioni");
        Response.Write(strSorgente);
        switch (strSorgente){
          case "scheda-regione":
		    Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=7&CoreGrids_Ky=8&CoreForms_Ky=155&salvato=salvato&azione=edit&Regioni_Ky=" + strKy);
            break;
          case "scheda-nazione":
		    Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=5&CoreGrids_Ky=6&CoreForms_Ky=154&salvato=salvato&azione=edit&Nazioni_Ky=" + strNazioni_Ky);
            break;
        }
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
