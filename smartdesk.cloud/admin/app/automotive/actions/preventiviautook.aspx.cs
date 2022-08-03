using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public DataTable dtPreventiviAuto;
    public DataTable dtLead;
    public DataTable dtOpportunita;
    public bool boolAdmin = false;
    public string strPreventiviAuto_Ky="";
    public string strLead_Ky="";
    public string strAnagrafiche_Ky="";
    public string strOpportunita_Ky="";
    public string strSorgente="";
    
    public string strRedirect="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strFROMNet = "";
      string strWHERENet="";
      string strORDERNet = "";

      
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strPreventiviAuto_Ky=Request["PreventiviAuto_Ky"];
            strSorgente=Smartdesk.Current.Request("sorgente");
            strWHERENet="PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
            strORDERNet = "PreventiviAuto_Ky Desc";
            strFROMNet = "PreventiviAuto_Vw";
            dtPreventiviAuto = new DataTable("PreventiviAuto");
            dtPreventiviAuto = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAuto_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strAnagrafiche_Ky=dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString();

            strOpportunita_Ky=dtPreventiviAuto.Rows[0]["Opportunita_Ky"].ToString();
            if (strOpportunita_Ky!=null && strOpportunita_Ky.Length>0 && strOpportunita_Ky!="0"){
              strWHERENet="Opportunita_Ky=" + strOpportunita_Ky;
              strORDERNet = "Opportunita_Ky Desc";
              strFROMNet = "Opportunita_Vw";
              dtOpportunita = new DataTable("Opportunita");
              dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtOpportunita.Rows.Count>0){
                strSQL = "UPDATE Opportunita SET OpportunitaStati_Ky=7, Opportunita_DateUpdate=GETDATE(), Opportunita_UserUpdate=" + Smartdesk.Session.CurrentUser.ToString() + " WHERE Opportunita_Ky=" + strOpportunita_Ky;
      					new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                strLead_Ky=dtOpportunita.Rows[0]["Lead_Ky"].ToString();
                if (strLead_Ky!=null && strLead_Ky.Length>0){
                  strSQL = "UPDATE Lead SET LeadStato_Ky=2, Lead_DateUpdate=GETDATE(), Lead_UserUpdate=" + Smartdesk.Session.CurrentUser.ToString() + " WHERE Lead_Ky=" + strLead_Ky;
        					new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                }
              }
            }
            
            //ok
            strSQL = "UPDATE PreventiviAuto SET PreventiviAutoStati_Ky=1, PreventiviAuto_DateUpdate=GETDATE(), PreventiviAuto_UserUpdate=" + Smartdesk.Session.CurrentUser.ToString() + " WHERE PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
  					new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strRedirect="/admin/app/automotive/scheda-PreventiviAuto.aspx?custom=1&CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270&CoreForms_Ky=196&azione=edit&sorgente=elenco-preventiviauto&PreventiviAuto_Ky=" + strPreventiviAuto_Ky;
            Response.Redirect(strRedirect);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
