using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    public DataTable dtPreventiviAuto;
    public DataTable dtPreventiviAutoStati;
    public DataTable dtOpportunita;
    public int intNumRecords = 0;
    public string strOpportunita_Ky="";

    protected void Page_Load(object sender, EventArgs e){
      string strKy = "";
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      string strLead_Ky="";
      string strSQL="";
      string strFROMNet = "";
      string strWHERENet="";
      string strORDERNet = "";
      bool boolAjax = false;
      string strJson = "";

      if (Smartdesk.Login.Verify)
      {
        boolAjax = Convert.ToBoolean(Request["ajax"]);
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("PreventiviAuto_Voltura") == "") frm.Add("PreventiviAuto_Voltura", false);
        if (Smartdesk.Current.Request("PreventiviAuto_Immatricolazione") == "") frm.Add("PreventiviAuto_Immatricolazione", false);
        if (Smartdesk.Current.Request("PreventiviAuto_Permuta") == "") frm.Add("PreventiviAuto_Permuta", false);
        strKy = Smartdesk.Functions.SqlWriteKey("PreventiviAuto", frm);
        strWHERENet="PreventiviAuto_Ky=" + strKy;
        strORDERNet = "PreventiviAuto_Ky Desc";
        strFROMNet = "PreventiviAuto_Vw";
        dtPreventiviAuto = new DataTable("PreventiviAuto");
        dtPreventiviAuto = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAuto_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        //Creo la trattativa se non esiste
        if (dtPreventiviAuto.Rows[0]["Opportunita_Ky"].ToString().Length<1 || dtPreventiviAuto.Rows[0]["Opportunita_Ky"].ToString()=="0"){
          //se esiste una trattativa negli ultimi 30gg
          //Response.Write("0");
          strWHERENet="(Opportunita_Data>GETDATE()-30 AND Anagrafiche_Ky=" + dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString() + ")";
          strORDERNet = "Opportunita_Ky Desc";
          strFROMNet = "Opportunita_Vw";
          dtOpportunita = new DataTable("Opportunita");
          dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtOpportunita.Rows.Count>0){
            strOpportunita_Ky=dtOpportunita.Rows[0]["Opportunita_Ky"].ToString();
            Response.Write(strOpportunita_Ky);
      			strSQL = "UPDATE PreventiviAuto SET Opportunita_Ky=" + strOpportunita_Ky + " WHERE PreventiviAuto_Ky=" + strKy;  
      			new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          }else{
            //se non esiste la creo con i dati del preventivo
      			strSQL = "INSERT INTO Opportunita  (Opportunita_Titolo, Opportunita_Data, OpportunitaSorgenti_Ky, Anagrafiche_Ky, Utenti_Ky, Opportunita_UserInsert,Opportunita_DateInsert) ";  
      			strSQL += "SELECT 'Preventivo', GETDATE(), 13, " + dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString() + "," + dtPreventiviAuto.Rows[0]["Utenti_Ky"].ToString() + "," + dtPreventiviAuto.Rows[0]["Utenti_Ky"].ToString() + ",GETDATE()"; 
      			//Response.Write(strSQL);
      			new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
            strWHERENet="(Opportunita_Data>GETDATE()-30 AND Anagrafiche_Ky=" + dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString() + ")";
            strORDERNet = "Opportunita_Ky Desc";
            strFROMNet = "Opportunita_Vw";
            dtOpportunita = new DataTable("Opportunita");
            dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            strOpportunita_Ky=dtOpportunita.Rows[0]["Opportunita_Ky"].ToString();
      			strSQL = "UPDATE PreventiviAuto SET Opportunita_Ky=" + strOpportunita_Ky + " WHERE PreventiviAuto_Ky=" + strKy;  
      			new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          }
        }else{
          strOpportunita_Ky=dtPreventiviAuto.Rows[0]["Opportunita_Ky"].ToString();
        }
        
        
        if (dtPreventiviAuto.Rows[0]["PreventiviAutoStati_Ky"].ToString().Length>0){
          dtPreventiviAutoStati = Smartdesk.Data.Read("PreventiviAutoStati", "PreventiviAutoStati_Ky", dtPreventiviAuto.Rows[0]["PreventiviAutoStati_Ky"].ToString());
          if (dtPreventiviAuto.Rows[0]["Opportunita_Ky"].ToString().Length>0){
            strSQL = "UPDATE Opportunita SET OpportunitaStati_Ky=" + dtPreventiviAutoStati.Rows[0]["OpportunitaStati_Ky"].ToString() + ", Opportunita_DateUpdate=GETDATE(), Opportunita_UserUpdate=" + Smartdesk.Session.CurrentUser.ToString() + " WHERE Opportunita_Ky=" + strOpportunita_Ky;
    				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          }
          if (dtPreventiviAuto.Rows[0]["Lead_Ky"].ToString().Length>0){
            strSQL = "UPDATE Lead SET LeadStato_Ky=" + dtPreventiviAutoStati.Rows[0]["LeadStato_Ky"].ToString() + ", Lead_DateUpdate=GETDATE(), Lead_UserUpdate=" + Smartdesk.Session.CurrentUser.ToString() + " WHERE Lead_Ky=" + dtPreventiviAuto.Rows[0]["Lead_Ky"].ToString();
    				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          }
          if (dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString().Length>0){
            strSQL = "UPDATE Anagrafiche SET AnagraficheStati_Ky=" + dtPreventiviAutoStati.Rows[0]["AnagraficheStati_Ky"].ToString() + ", Anagrafiche_DateUpdate=GETDATE(), Anagrafiche_UserUpdate=" + Smartdesk.Session.CurrentUser.ToString() + " WHERE Anagrafiche_Ky=" + dtPreventiviAuto.Rows[0]["Anagrafiche_Ky"].ToString();
    				new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
          }
        }
        if (boolAjax){
          strJson="{\"PreventiviAuto_Ky\": " + strKy + "}";
          Response.Write(strJson);
        }else{
          strRedirect = "/admin/app/automotive/scheda-PreventiviAuto.aspx?custom=1&CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270&CoreForms_Ky=196&azione=edit&sorgente=scheda-preventiviauto&PreventiviAuto_Ky=" + strKy;
          Response.Redirect(strRedirect);
        }
      }
      //Response.Redirect(strRedirect);
  }
}
