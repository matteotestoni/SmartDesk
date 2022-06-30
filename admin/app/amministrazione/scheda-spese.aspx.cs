using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;

public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public bool boolCambioForm = false;
    public DataTable dtSpese;
    public DataTable dtFormsData;
    public DataTable dtCommesse;
    public DataTable dtPagamenti;
    public DataTable dtPagamentiDaFare;
    public DataTable dtPagamentiMetodo;
    public DataTable dtTemp;
    public string strFROMNet = "";
    public string strH1 = "Amministrazione > Scheda spesa";
    public string strAzione = "";
    public string strAnagrafiche_Ky = "";
    public string strAnagrafiche_ClienteKy = "";
    public string strCommesse_Ky = "";
    public string strSpese_Ky = "";
    public DataTable dtCoreEntities;
    public int intCoreForms_Ky = 211;
    public DataTable dtCurrentCoreForms;
    public DataTable dtCoreForms;
    public DataTable dtCoreGrids;
    public string strViewUrl = "";
    public string strFormUrl = "";
    public DataTable dtCoreFormsButtons;
    public string strAction = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          if (dtLogin.Rows.Count>0){
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            intCoreForms_Ky = Convert.ToInt32(Request["CoreForms_Ky"]);
            strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
            strFROMNet = "CoreForms_Vw";
            strORDERNet = "CoreForms_Ky";
            dtCurrentCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
            strFROMNet = "CoreFormsButtons";
            strORDERNet = "CoreFormsButtons_Order ASC, CoreFormsButtons_Ky DESC";
            dtCoreFormsButtons = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsButtons_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet = "(CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + ")";
            strFROMNet = "CoreEntities_Vw";
            strORDERNet = "CoreEntities_Ky";
            dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet = "(UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ") AND (CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + ")";
            strFROMNet = "UsergroupsForms_Vw";
            strORDERNet = "CoreForms_Ky";
            dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

            strWHERENet = "(UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString() + ") AND (CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + ")";
            strFROMNet = "UsergroupsGrids_Vw";
            strORDERNet = "CoreGrids_Default DESC, CoreGrids_Ky";
            dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtCoreGrids.Rows.Count > 0){
                if (dtCoreGrids.Rows[0]["CoreGrids_Custom"].Equals (true)){
                    strViewUrl = "/admin/app/" + dtCurrentCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/elenco-" + dtCurrentCoreForms.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + dtCurrentCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString();
                } else {
                    strViewUrl = "/admin/view.aspx?CoreModules_Ky=" + dtCurrentCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString();
                }
            } else {
                strViewUrl = "/admin/app/" + dtCurrentCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCurrentCoreForms.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
            }

            if (dtCurrentCoreForms.Rows[0]["CoreForms_Custom"].Equals (true)){
                strFormUrl = "/admin/app/" + dtCurrentCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + dtCurrentCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCurrentCoreForms.Rows[0]["CoreForms_Ky"].ToString();
            } else {
                strFormUrl = "/admin/form.aspx?CoreModules_Ky=" + dtCurrentCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString();
            }


            strAzione = Request["azione"];
            strAnagrafiche_Ky=Smartdesk.Current.Request("Anagrafiche_Ky");
            if (strAzione!="new"){
    	  	  	dtSpese = Smartdesk.Data.Read("Spese_Vw", "Spese_Ky",Smartdesk.Current.QueryString("Spese_Ky"));
              dtFormsData = dtSpese;
      				strAnagrafiche_Ky=dtSpese.Rows[0]["Anagrafiche_Ky"].ToString();
      				strAnagrafiche_ClienteKy=dtSpese.Rows[0]["Anagrafiche_ClienteKy"].ToString();
      				strSpese_Ky=dtSpese.Rows[0]["Spese_Ky"].ToString();

	            strWHERENet="";
	            strORDERNet = "PagamentiMetodo_Descrizione";
	            strFROMNet = "PagamentiMetodo";
	            dtPagamentiMetodo = Smartdesk.Sql.getTablePage(strFROMNet, null, "PagamentiMetodo_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly,out this.intNumRecords);

				      if (strAnagrafiche_ClienteKy!=null && strAnagrafiche_ClienteKy.Length>0){
		            strWHERENet="Anagrafiche_Ky=" + strAnagrafiche_ClienteKy;
		            strORDERNet = "Commesse_Ky";
		            strFROMNet = "Commesse_Vw";
		            dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1, 1000,Smartdesk.Config.Sql.ConnectionReadOnly,out this.intNumRecords);
	            }

			  	      strWHERENet="Spese_Ky=" + strSpese_Ky + " And PagamentiTipo_Ky=2";
              	strORDERNet = "Pagamenti_Data";
              	strFROMNet = "Pagamenti_Vw";
              	dtPagamentiDaFare = Smartdesk.Sql.getTablePage(strFROMNet, null, "Pagamenti_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly,out this.intNumRecords);

	          }else{
			  	
			  	
		        }
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    
    
    public Boolean GetCheckValue(string strField)
    {
      Boolean boolValore=false;
      if (strAzione=="new"){
        boolValore=false;
      }else{
        if (dtSpese.Rows[0][strField].Equals(true)){
          boolValore=true;
        }
      }
      return boolValore;
    }

	public String GetFieldValue(DataTable dtTabella, string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtTabella.Rows[0][strField].ToString();
      }
      return strValore;

    }

    public String GetDefaultValue(string strField)
    {
      string strValore="";
      switch (strField){
		case "Aziende_Ky":
			strValore="1";
			break;
		case "Conti_Ky":
            dtTemp = new DataTable("Temp");
            dtTemp = Smartdesk.Sql.getTablePage("Conti", null, "Conti_Ky", "Conti_Default=1", "Conti_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly,out this.intNumRecords);
            if (dtTemp.Rows.Count>0){
            	strValore = dtTemp.Rows[0]["Conti_Ky"].ToString();
			}else{
				strValore="";	
			}
			break;
		case "Spese_Totale":
			strValore="0";
			break;
		case "Spese_TotaleRighe":
			strValore="0";
			break;
		case "Spese_TotaleIVA":
			strValore="0";
			break;
	  }
      return strValore;
    }

    public String GetMoneyValue(string strField)
    {
      string strValore="";
      if (strAzione=="new"){
        strValore=GetDefaultValue(strField);
      }else{
        strValore=dtSpese.Rows[0][strField].ToString();
        strValore=strValore.Replace(",0000","");
      }
      return strValore;
    }
 }
