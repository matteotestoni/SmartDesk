using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");    
    public string strAnagraficheServizi_Ky="";
    public string strAnagrafiche_Ky="";
    public string strSorgente="";
    
    public DataTable dtServizio;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strWHERENet="";
      string strORDERNet = "";
      string strFROMNet = "";

      
	  
      if (Smartdesk.Login.Verify){
          strAnagraficheServizi_Ky=Smartdesk.Current.Request("AnagraficheServizi_Ky");
          strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
          strSorgente=Smartdesk.Current.Request("sorgente");
          strSQL = "UPDATE AnagraficheServizi SET AnagraficheServizi_DataChiusura=GETDATE(), AnagraficheServizi_Chiuso=1 WHERE AnagraficheServizi_Ky=" + strAnagraficheServizi_Ky;
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          strWHERENet = "AnagraficheServizi_Ky =" + strAnagraficheServizi_Ky;
          strORDERNet = "AnagraficheServizi_Ky";
          strFROMNet = "AnagraficheServizi";
          dtServizio = new DataTable("AnagraficheServizi");
          dtServizio = Smartdesk.Sql.getTablePage(strFROMNet, null, "AnagraficheServizi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            switch (strSorgente){
              case "home":
                 Response.Redirect("/admin/home.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky); 
                break;
              case "dafatturare":
                Response.Redirect("/admin/app/anagrafiche/elenco-anagrafiche-da-fatturare.aspx");
                break;
              case "scheda-anagrafiche":
                Response.Redirect("/admin/app/anagrafiche/scheda-anagrafiche.aspx?Anagrafiche_Ky=" + strAnagrafiche_Ky);
                break;
            }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
