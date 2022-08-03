using System;
using System.Data;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public string strUtentiGruppi_Ky="";
    public DataTable dtUtentiGruppi;
    public DataTable dtCoreForms;
    public DataTable dtCoreGrids;
    public DataTable dtUsergroupsForms;
    public DataTable dtUsergroupsGrids;
    public string strAzione = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strKy = "";
      string strFROMNet = "";
      string strWHERENet="";
      string strORDERNet = "";
      string strSQL="";

      
      
	  
      if (Smartdesk.Login.Verify){
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("UtentiGruppi_RicambiVeicoli") == "") frm.Add("UtentiGruppi_RicambiVeicoli", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Core") == "") frm.Add("UtentiGruppi_Core", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Sdk") == "") frm.Add("UtentiGruppi_Sdk", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Preferiti") == "") frm.Add("UtentiGruppi_Preferiti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Calendario") == "") frm.Add("UtentiGruppi_Calendario", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Anagrafiche") == "") frm.Add("UtentiGruppi_Anagrafiche", false);
        if (Smartdesk.Current.Request("UtentiGruppi_AnagraficheClienti") == "") frm.Add("UtentiGruppi_AnagraficheClienti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_AnagraficheConcorrenti") == "") frm.Add("UtentiGruppi_AnagraficheConcorrenti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_AnagraficheFornitori") == "") frm.Add("UtentiGruppi_AnagraficheFornitori", false);
        if (Smartdesk.Current.Request("UtentiGruppi_AnagraficheLead") == "") frm.Add("UtentiGruppi_AnagraficheLead", false);
        if (Smartdesk.Current.Request("UtentiGruppi_AnagraficheContatti") == "") frm.Add("UtentiGruppi_AnagraficheContatti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Amministrazione") == "") frm.Add("UtentiGruppi_Amministrazione", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Servizi") == "") frm.Add("UtentiGruppi_Servizi", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Pagamenti") == "") frm.Add("UtentiGruppi_Pagamenti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Fatturato") == "") frm.Add("UtentiGruppi_Fatturato", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Persone") == "") frm.Add("UtentiGruppi_Personale", false);
        if (Smartdesk.Current.Request("UtentiGruppi_PersonaleAssenze") == "") frm.Add("UtentiGruppi_PersonaleAssenze", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Trasferte") == "") frm.Add("UtentiGruppi_Trasferte", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Contenuti") == "") frm.Add("UtentiGruppi_Contenuti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Catalogo") == "") frm.Add("UtentiGruppi_Catalogo", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Annunci") == "") frm.Add("UtentiGruppi_Annunci", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Immobili") == "") frm.Add("UtentiGruppi_Immobili", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Aste") == "") frm.Add("UtentiGruppi_Aste", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Veicoli") == "") frm.Add("UtentiGruppi_Veicoli", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Prodotti") == "") frm.Add("UtentiGruppi_Prodotti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_ServiziCatalogo") == "") frm.Add("UtentiGruppi_ServiziCatalogo", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Vendite") == "") frm.Add("UtentiGruppi_Vendite", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Opportunita") == "") frm.Add("UtentiGruppi_Opportunita", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Fatture") == "") frm.Add("UtentiGruppi_Fatture", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Notedicredito") == "") frm.Add("UtentiGruppi_Notedicredito", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Preventivi") == "") frm.Add("UtentiGruppi_Preventivi", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Ordini") == "") frm.Add("UtentiGruppi_Ordini", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Produzione") == "") frm.Add("UtentiGruppi_Produzione", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Note") == "") frm.Add("UtentiGruppi_Note", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Attivita") == "") frm.Add("UtentiGruppi_Attivita", false);
        if (Smartdesk.Current.Request("UtentiGruppi_SitiWeb") == "") frm.Add("UtentiGruppi_SitiWeb", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Rapporti") == "") frm.Add("UtentiGruppi_Rapporti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Lead") == "") frm.Add("UtentiGruppi_Lead", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Social") == "") frm.Add("UtentiGruppi_Social", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Faq") == "") frm.Add("UtentiGruppi_Faq", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Campagne") == "") frm.Add("UtentiGruppi_Campagne", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Commerciale") == "") frm.Add("UtentiGruppi_Commerciale", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Ticket") == "") frm.Add("UtentiGruppi_Ticket", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Marketing") == "") frm.Add("UtentiGruppi_Marketing", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Assistenza") == "") frm.Add("UtentiGruppi_Assistenza", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Officina") == "") frm.Add("UtentiGruppi_Officina", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Knowledgebase") == "") frm.Add("UtentiGruppi_Knowledgebase", false);				  
        if (Smartdesk.Current.Request("UtentiGruppi_Eventi") == "") frm.Add("UtentiGruppi_Eventi", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Recensioni") == "") frm.Add("UtentiGruppi_Recensioni", false);
        if (Smartdesk.Current.Request("UtentiGruppi_PreventiviAuto") == "") frm.Add("UtentiGruppi_PreventiviAuto", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Passwordmanager") == "") frm.Add("UtentiGruppi_Passwordmanager", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Automotive") == "") frm.Add("UtentiGruppi_Automotive", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Documenti") == "") frm.Add("UtentiGruppi_Documenti", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Files") == "") frm.Add("UtentiGruppi_Files", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Logistica") == "") frm.Add("UtentiGruppi_Logistica", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Sitiweb") == "") frm.Add("UtentiGruppi_Sitiweb", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Spese") == "") frm.Add("UtentiGruppi_Spese", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Forms") == "") frm.Add("UtentiGruppi_Forms", false);
        if (Smartdesk.Current.Request("UtentiGruppi_Admin") == "") frm.Add("UtentiGruppi_Admin", false);
        strKy = Smartdesk.Functions.SqlWriteKey("UtentiGruppi", frm);
        //Permessi su forms e grids
        
        strWHERENet="UtentiGruppi_Ky=" + strKy;
        strORDERNet = "UtentiGruppi_Ky";
        strFROMNet = "UtentiGruppi";
        dtUtentiGruppi = Smartdesk.Sql.getTablePage(strFROMNet, null, "UtentiGruppi_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        if (Convert.ToBoolean(dtUtentiGruppi.Rows[0]["UtentiGruppi_Admin"])==true){
              //Forms
              strWHERENet="";
              strORDERNet = "CoreForms_Ky";
              strFROMNet = "CoreForms";
              dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtCoreForms.Rows.Count>0){
                for (int i = 0; i < dtCoreForms.Rows.Count; i++){
                  strWHERENet="UtentiGruppi_Ky=" + strKy + " AND CoreForms_Ky=" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString();
                  strORDERNet = "UsergroupsForms_Ky";
                  strFROMNet = "UsergroupsForms";
                  dtUsergroupsForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtUsergroupsForms.Rows.Count<1){                
                      strSQL="INSERT INTO UsergroupsForms (CoreForms_Ky, UtentiGruppi_Ky,UsergroupsForms_UserInsert,UsergroupsForms_DateInsert) VALUES (" + dtCoreForms.Rows[i]["CoreForms_Ky"].ToString() + ", " + dtUtentiGruppi.Rows[0]["UtentiGruppi_Ky"].ToString() + ",0,GETDATE());";
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }
                }
              }
              //Grids
              strWHERENet="";
              strORDERNet = "CoreGrids_Ky";
              strFROMNet = "CoreGrids";
              dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtCoreGrids.Rows.Count>0){
                for (int i = 0; i < dtCoreGrids.Rows.Count; i++){
                  strWHERENet="UtentiGruppi_Ky=" + strKy + " AND CoreGrids_Ky=" + dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString();
                  strORDERNet = "UsergroupsGrids_Ky";
                  strFROMNet = "UsergroupsGrids";
                  dtUsergroupsGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtUsergroupsGrids.Rows.Count<1){                
                      strSQL="INSERT INTO UsergroupsGrids (CoreGrids_Ky, UtentiGruppi_Ky,UsergroupsGrids_UserInsert,UsergroupsGrids_DateInsert) VALUES (" + dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString() + ", " + dtUtentiGruppi.Rows[0]["UtentiGruppi_Ky"].ToString() + ",0,GETDATE());";
                      new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
                  }
                }
              }

              
              
              
              
              
              
        }

        
        Response.Redirect("/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=19&CoreGrids_Ky=18&CoreForms_Ky=156&custom=0&salvate=salvate&UtentiGruppi_Ky=" + strKy);
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
