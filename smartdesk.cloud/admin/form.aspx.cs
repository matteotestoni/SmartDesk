using System;
using System.Data;
using System.Linq;

public partial class _Default : System.Web.UI.Page {
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo ("it-IT");
    public string strLogin = "";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public bool boolWysiwyg = false;
    public bool boolCambioForm = false;
    public string strH1 = "";
    public string strAzione = "";
    public DataTable dtCoreEntities;
    public DataTable dtCoreEntitiesGrid;
    public DataTable dtCoreModules;
    public DataTable dtCoreModulesGrid;
    public DataTable dtCoreModulesJoin;
    public DataTable dtCoreForms;
    public DataTable dtCoreFormsGrid;
    public DataTable dtCoreFormsRelations;
    public DataTable dtCoreFormsButtons;
    public DataTable dtCoreFormsTabs;
    public DataTable dtCoreFormsFields;
    public DataTable dtCoreFormsFieldset;
    public DataTable dtCoreGrids;    
    public DataTable dtCoreAttributes;
    public DataTable dtCurrentCoreForms;
    public DataTable dtFormsData;
    public DataTable dtLookup;
    public DataTable dtKey;
    public DataTable dtCurrentCoreGrids;
    public DataTable dtCoreGridsButtons;
    public DataTable dtCoreGridsColumns;
    public int intCoreGrids_Ky = 1;
    public int intCoreForms_Ky = 1;
    public int intCoreEntities_Ky = 1;
    public int intCoreModules_Ky = 28;
    public string strKy = "";
    public string strViewUrl = "";
    public string strFormUrl = "";
    public string strFormUrlJoin = "";
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public string strSelected = "";
    public string strActive = "";
    public string strKeyJoin = "";
    public string[] strValues;
    public string strValue;
    public string strEvent = "";
    public int intRecxPag = 30;
    public int intPage = 0;
    public int intNumPagine=1;
    public string strPathWhere = "";
    public DataTable dtGridData;
    public DataTable dtGridDataChildren;
    public DataTable dtTemp;
    public string strFieldValue = "";
    public string strPaginationId = "";
    public string strPaginationText = "";
    public string strAction = "";
    public string strSorgente = "";
    public string strCoreGrids_Ky = "";
    public int intTotalColumns=0;    
    public string strRenderer = "";
    public string strUtentiGruppi_Ky = "";
    public string strFormAction = "";

    protected void Page_Load (object sender, EventArgs e){
        if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read ("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
            boolAdmin = (dtLogin.Rows[0]["Utenti_Admin"]).Equals (true);
            boolWysiwyg = (dtLogin.Rows[0]["Utenti_Wysiwyg"]).Equals (true);
            boolCambioForm = (dtLogin.Rows[0]["Utenti_CambioForm"]).Equals (true);
            strUtentiGruppi_Ky=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
            intCoreForms_Ky = Convert.ToInt32(Request["CoreForms_Ky"]);
            intCoreEntities_Ky = Convert.ToInt32(Request["CoreEntities_Ky"]);
            intCoreModules_Ky = Convert.ToInt32(Request["CoreModules_Ky"]);
            intCoreGrids_Ky = Convert.ToInt32(Request["CoreGrids_Ky"]);
            strCoreGrids_Ky = Request["CoreGrids_Ky"];
            strAzione = Request["azione"];
            strSorgente = Request["sorgente"];

            strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
            strFROMNet = "CoreForms_Vw";
            strORDERNet = "CoreForms_Ky";
            dtCurrentCoreForms = new DataTable ("CurrentCoreForms");
            dtCurrentCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            if (dtCurrentCoreForms.Rows.Count > 0){
                intCoreModules_Ky=Convert.ToInt32(dtCurrentCoreForms.Rows[0]["CoreModules_Ky"]);
                strWHERENet = "(CoreModules_Ky=" + dtCurrentCoreForms.Rows[0]["CoreModules_Ky"].ToString() + ")";
                strFROMNet = "CoreModules";
                strORDERNet = "CoreModules_Ky";
                dtCoreModules = new DataTable ("CoreModules");
                dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                intCoreEntities_Ky = Convert.ToInt32(dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"]);
                strWHERENet = "(CoreEntities_Ky=" + dtCurrentCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + ")";
                strFROMNet = "CoreEntities_Vw";
                strORDERNet = "CoreEntities_Ky";
                dtCoreEntities = new DataTable ("CoreEntities");
                dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (Convert.ToBoolean(dtCurrentCoreForms.Rows[0]["CoreEntities_CustomSave"])){
                  strFormAction="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/salva-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx";
                }else{
                  strFormAction="/admin/crud/salva.aspx";
                }
                
                if (strCoreGrids_Ky!=null && strCoreGrids_Ky.Length>0 && strCoreGrids_Ky!="0"){
                  strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreGrids_Ky=" + strCoreGrids_Ky + ")";
        		      strFROMNet = "UsergroupsGrids_Vw";
                  strORDERNet = "CoreGrids_Default DESC, CoreGrids_Ky";
                  dtCoreGrids = new DataTable ("CoreGrids");
                  dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtCoreGrids.Rows.Count > 0){
                      intCoreGrids_Ky = Convert.ToInt32(dtCoreGrids.Rows[0]["CoreGrids_Ky"]);
                      if (dtCoreGrids.Rows[0]["CoreGrids_Custom"].Equals (true)){
                          strViewUrl = "/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
                      } else {
                          strViewUrl = "/admin/view.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky;
                      }
                  } else {
                      strViewUrl = "/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
                  }
                }else{
                  strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
                  strFROMNet = "UsergroupsGrids_Vw";
                  strORDERNet = "CoreGrids_Default DESC, CoreGrids_Ky";
                  dtCoreGrids = new DataTable ("CoreGrids");
                  dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtCoreGrids.Rows.Count > 0){
                      intCoreGrids_Ky = Convert.ToInt32 (dtCoreGrids.Rows[0]["CoreGrids_Ky"]);
                      if (dtCoreGrids.Rows[0]["CoreGrids_Custom"].Equals (true)){
                          strViewUrl = "/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
                      } else {
                          strViewUrl = "/admin/view.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky;
                      }
                  } else {
                      strViewUrl = "/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
                  }
                }

                strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
                strFROMNet = "UsergroupsForms_Vw";
                strORDERNet = "CoreForms_Ky";
                dtCoreForms = new DataTable ("CoreForms");
                dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                if (intCoreForms_Ky == 0){
                    intCoreForms_Ky = Convert.ToInt32 (dtCoreForms.Rows[0]["CoreForms_Ky"]);
                }

                if (dtCurrentCoreForms.Rows[0]["CoreForms_Custom"].Equals (true)){
                    strFormUrl = "/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
                } else {
                    strFormUrl = "/admin/form.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky;
                }

                //strWHERENet = "(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreForms_Ky=" + intCoreForms_Ky + ")";
                strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
                strFROMNet = "CoreFormsRelations_Grid_Vw";
                strORDERNet = "CoreFormsRelations_Order, CoreFormsRelations_Ky";
                dtCoreFormsRelations = new DataTable ("CoreFormsRelations");
                dtCoreFormsRelations = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsRelations_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
                strFROMNet = "CoreFormsTabs";
                strORDERNet = "CoreFormsTabs_Order, CoreFormsTabs_Ky";
                dtCoreFormsTabs = new DataTable ("CoreFormsTabs");
                dtCoreFormsTabs = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsTabs_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
                strFROMNet = "CoreFormsFieldset";
                strORDERNet = "CoreFormsFieldset_Order";
                dtCoreFormsFieldset = new DataTable ("CoreFormsFieldset");
                dtCoreFormsFieldset = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFieldset_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
                strFROMNet = "CoreFormsButtons";
                strORDERNet = "CoreFormsButtons_Order ASC, CoreFormsButtons_Ky DESC";
                dtCoreFormsButtons = new DataTable ("CoreFormsButtons");
                dtCoreFormsButtons = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsButtons_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                strH1 = dtCoreModules.Rows[0]["CoreModules_Title"].ToString() + " > " + dtCurrentCoreForms.Rows[0]["CoreForms_Title"].ToString();

                if (dtCurrentCoreForms.Rows[0]["CoreForms_WhichFields"].ToString() == "1"){
                    strWHERENet = "CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString();
                    strORDERNet = "CoreAttributes_Order, CoreAttributes_Code";
                    strFROMNet = "CoreAttributes_Vw";
                    dtCoreAttributes = new DataTable ("CoreAttributes");
                    dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                } else {
                    strWHERENet = "CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString();
                    strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
                    strFROMNet = "CoreFormsFields_Vw";
                    dtCoreAttributes = new DataTable ("CoreAttributes");
                    dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                }

                if (strAzione != "new"){
                    strAzione = "modifica";
                    strKy = dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString();
                    strFROMNet = dtCurrentCoreForms.Rows[0]["CoreForms_SQLFrom"].ToString();
                    dtFormsData = Smartdesk.Data.Read (strFROMNet, strKy, Smartdesk.Current.QueryString (strKy));
                }

          }
        } else {
            Response.Redirect (Smartdesk.Current.LoginPageRoot);
        }
    }


    public void CiclaCoreAttributes(){
      intTotalColumns=0;
  		for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
        intTotalColumns+=Convert.ToInt32(dtCoreAttributes.Rows[iCoreAttributes]["CoreFormsFields_Columns"]);
        Response.Write("<div class=\"grid-x grid-padding-x\" data-columns=\"12\">");
        RenderField(dtCoreAttributes.Rows[iCoreAttributes], 12);
        Response.Write("</div>");
			}
    }
    
    
    public void CiclaCoreFormsFields(){
      intTotalColumns=0;
      for (int iCoreFormsFields = 0; iCoreFormsFields < dtCoreFormsFields.Rows.Count; iCoreFormsFields++){
        if (Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"])==12){
          if (iCoreFormsFields>0 && intTotalColumns>0){
            Response.Write("</div>");
          }
          Response.Write("<div class=\"grid-x grid-padding-x\" data-columns=\"" + Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]) + "\" data-totalcolumns=\"" + intTotalColumns + "\">");
          RenderField(dtCoreFormsFields.Rows[iCoreFormsFields],Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]));
          Response.Write("</div>");
          intTotalColumns=0;
        }else{
          Response.Write("<span data-columns=\"" + Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]) + "\" data-totalcolumns=\"" + intTotalColumns + "\"></span>");
          if (intTotalColumns==0){
            Response.Write("<div class=\"grid-x grid-padding-x\" data-columns=\"" + Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]) + "\" data-totalcolumns=\"" + intTotalColumns + "\">");
            RenderField(dtCoreFormsFields.Rows[iCoreFormsFields],Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]));
          }
          if (intTotalColumns==3){
            RenderField(dtCoreFormsFields.Rows[iCoreFormsFields],Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]));
          }
          if (intTotalColumns==4){
            RenderField(dtCoreFormsFields.Rows[iCoreFormsFields],Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]));
          }
          if (intTotalColumns==6){
            RenderField(dtCoreFormsFields.Rows[iCoreFormsFields],Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]));
          }
          if (intTotalColumns==12){
            intTotalColumns=0;
            Response.Write("</div><div class=\"grid-x grid-padding-x\" data-columns=\"" + Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]) + "\" data-totalcolumns=\"" + intTotalColumns + "\">");
            RenderField(dtCoreFormsFields.Rows[iCoreFormsFields],Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]));
          }
          intTotalColumns+=Convert.ToInt32(dtCoreFormsFields.Rows[iCoreFormsFields]["CoreFormsFields_Columns"]);
        }
        
			}
    }
    

    public void RenderField (DataRow dtRow, int intColumns){
        string strLabel = "";
        bool boolHidden = false;
        bool boolReadonly = false;
        string strReadonly = "";

        try {
            boolHidden = dtRow["CoreFormsFields_Hidden"].Equals (true);
        } catch {
            boolHidden = false;
        }
        try {
            boolReadonly = dtRow["CoreFormsFields_Readonly"].Equals(true);
        } catch {
            boolReadonly = false;
        }
        if (boolReadonly.Equals(true)){
          strReadonly="readonly disabled";
        }else{
          strReadonly="";
        }

        if (boolHidden.Equals (true)){
            Response.Write("<input type=\"hidden\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\">");
        } else {
            try {
                if (dtRow["CoreFormsFields_Label"].ToString().Length > 0){
                    strLabel = dtRow["CoreFormsFields_Label"].ToString();
                } else {
                    strLabel = dtRow["CoreAttributes_Label"].ToString();
                }
            } catch {
                strLabel = dtRow["CoreAttributes_Label"].ToString();
            }
            //Response.Write("<div class=\"grid-x grid-padding-x\">");
            Response.Write("<div class=\"large-2 medium-2 small-4 cell\">");
            if (dtRow["CoreAttributesType_Code"].ToString() == "join"){
                Response.Write("<label id=\"lbl" + dtRow["CoreAttributes_Code"].ToString() + "\" for=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" class=\"large-text-right small-text-left middle\">" + strLabel + " <i role=\"img\" class=\"" + dtRow["CoreEntities_IconJoin"].ToString() + " fa-fw\"></i></label>");
            } else {
                Response.Write("<label id=\"lbl" + dtRow["CoreAttributes_Code"].ToString() + "\" for=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" class=\"large-text-right small-text-left middle\">" + strLabel + "</label>");
            }
            Response.Write("</div>");
            if (intColumns==12){
              Response.Write("<div class=\"large-10 medium-10 small-8 cell\">");
            }else{
              Response.Write("<div class=\"large-4 medium-4 small-8 cell\">");
            }
            if (dtRow["CoreAttributes_EventOn"].ToString().Length>0){
                strEvent=dtRow["CoreAttributes_EventOn"].ToString() + "=\"" + dtRow["CoreAttributes_EventAction"].ToString() + "\"";
            }else{
                strEvent="";
            }
            switch (dtRow["CoreAttributesType_Code"].ToString()){
                case "text":
                    switch (dtRow["CoreAttributesFormat_Code"].ToString()){
                        case "icon":
                            Response.Write("<input type=\"text\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            break;
                        case "color":
                            Response.Write("<input type=\"color\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            break;
                        case "text":
                            if (boolReadonly.Equals(false)){
                              Response.Write("<input type=\"text\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " maxlength=\"" + dtRow["CoreAttributes_MaxLength"].ToString() + " " + strReadonly + "\">");
                            }else{
                              Response.Write("<span name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\">" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</span>");
                            }
                            break;
                        case "phone":
                            if (boolReadonly.Equals (false)){
                              Response.Write("<input type=\"text\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            }else{
                              Response.Write("<span name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\"><i class=\"fa-duotone fa-phone fa-fw\"></i>" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</span>");
                            }
                            break;
                        case "email":
                            if (boolReadonly.Equals (false)){
                              Response.Write("<input type=\"text\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            }else{
                              Response.Write("<span name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</span>");
                            }
                            break;
                        case "link":
                            Response.Write("<div class=\"input-group\"><input type=\"text\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " input-group-field\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + "><div class=\"input-group-button\"><a class=\"button\" href=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" target=\"_blank\"><i class=\"fa-duotone fa-arrow-up-right-from-square fa-fw\"></i>apri</a></div></div>");
                            break;
                        case "image":
                            Response.Write("<label for=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" class=\"button small\">Carica immagini<i role=\"img\" class=\"fa-duotone fa-arrow-up fa-fw\"></i></label>");
                            Response.Write("<input type=\"file\" class=\"show-for-sr fileupload\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            Response.Write("<div id=\"gallery-" + dtRow["CoreAttributes_Code"].ToString() + "\" class=\"gallery\"></div>");
                            Response.Write("<script>\n");
                            Response.Write("jQuery(function(){\n");
                            Response.Write("var imagesPreview = function(input, placeToInsertImagePreview){\n");
                            Response.Write("if (input.files){\n");
                            Response.Write("var filesAmount = input.files.length;\n");
                            Response.Write("jQuery(placeToInsertImagePreview).html('');\n");
                            Response.Write("for (i = 0; i < filesAmount; i++){\n");
                            Response.Write("var reader = new FileReader();\n");
                            Response.Write("reader.onload = function(event){\n");
                            Response.Write("jQuery(jQuery.parseHTML('<img width=\"150\" height=\"100\" hspace=\"10\" vspace=\"10\" style=\"border:1px solid #000000\">')).attr('src', event.target.result).appendTo(placeToInsertImagePreview);");
                            Response.Write("}\n");
                            Response.Write("reader.readAsDataURL(input.files[i]);\n");
                            Response.Write("}\n");
                            Response.Write("}\n");
                            Response.Write("};\n");
                            Response.Write("jQuery('#" + dtRow["CoreAttributes_Code"].ToString() + "').on('change', function(){\n");
                            Response.Write("imagesPreview(this, '#gallery-" + dtRow["CoreAttributes_Code"].ToString() + "');\n");
                            Response.Write("});\n");
                            Response.Write("});\n");
                            Response.Write("</script>\n");

                            if (GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()).Length > 0){
                                Response.Write("<div class=\"thumbnail\"><img src=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" height=\"150\" width=\"150\"></div><br>");
                            }

                            break;
                        case "select":
                            Response.Write("<select class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            Response.Write("<option value=\"\"></option>");
                            string[] strOptions = dtRow["CoreAttributes_Options"].ToString().Split(Environment.NewLine.ToCharArray());
                            foreach (string strOption in strOptions)
                            {
                                if (strOption.Length>0){
                                    if (strOption.Contains(",")){
                                        Response.Write("<option value=\"" + strOption.Split(',')[0] + "\">" + strOption.Split(',')[1] + "</option>");
                                    }else{
                                        Response.Write("<option value=\"" + strOption + "\">" + strOption + "</option>");
                                    }
                                }
                            }                            
                            Response.Write("</select>");
                            Response.Write("<script type=\"text/javascript\">");
                            Response.Write("selectSet('" + dtRow["CoreAttributes_Code"].ToString() + "', '" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "');");
                            Response.Write("</script>");
                            break;
                        case "password":
                            Response.Write("<div class=\"input-group align-middle\">");
                            Response.Write("<input class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " input-group-field\" type=\"password\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" data-password=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " maxlength=\"" + dtRow["CoreAttributes_MaxLength"].ToString() + " " + strReadonly + "\" autocomplete=\"new-password\">");
                            Response.Write("<div class=\"input-group-button\"><a onclick=\"showPasswordForm('" + dtRow["CoreAttributes_Code"].ToString() + "')\" class=\"showpassword\" title=\"mostra password\" data-tooltip><i class=\"fa-duotone fa-eye fa-xl fa-fw\"></i></a><a onclick=\"copyToClipboard('" + dtRow["CoreAttributes_Code"].ToString() + "',true)\" class=\"copypassword\" title=\"copia password\" data-tooltip><i class=\"fa-duotone fa-copy fa-xl fa-fw\"></i></a><a onclick=\"generatePassword('" + dtRow["CoreAttributes_Code"].ToString() + "')\" class=\"generatepassword\" title=\"genera password\" data-tooltip><i class=\"fa-duotone fa-redo fa-xl fa-fw\"></i></a></div>");
                            Response.Write("</div>");
                            break;
                        default:
                            Response.Write("<input type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " maxlength=\"" + dtRow["CoreAttributes_MaxLength"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            break;
                    }
                    break;
                case "textarea":
                    switch (dtRow["CoreAttributesFormat_Code"].ToString()){
                        case "textarea":
                            if (boolReadonly.Equals (false)){
                              Response.Write("<textarea class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" rows=\"5\"" + strEvent + " maxlength=\"" + dtRow["CoreAttributes_MaxLength"].ToString() + "\"" + strReadonly + ">" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</textarea>");
                            }else{
                              Response.Write("<span name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" >" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</span>");
                            }
                            break;
                        case "html":
                            Response.Write("<textarea class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" class=\"ckfinder\"" + strEvent + " " + strReadonly + ">" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</textarea>");
                            Response.Write("<script type=\"text/javascript\">");
                            Response.Write("CKEDITOR.replace('" + dtRow["CoreAttributes_Code"].ToString() + "',");
                            Response.Write("{");
                            //Response.Write("filebrowserBrowseUrl: '/ckfinder/ckfinder.html',");
                            //Response.Write("filebrowserUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files'");
                            Response.Write("});");
                            //Response.Write("CKFinder.setupCKEditor( editor, null, { type: 'Files', currentFolder: '/uploads/foto-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + "/' } );");
                            Response.Write("</script>");
                            break;
                        default:
                            Response.Write("<textarea name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\"" + strEvent + " " + strReadonly + ">" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</textarea>");
                            break;
                    }

                    break;
                case "data":
                    if (GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()).Length >= 10){
                        switch (dtRow["CoreAttributesFormat_Code"].ToString()){
                            case "date":
                                Response.Write("<input class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " fdatepicker\" type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + Convert.ToDateTime (GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString())).ToString ("dd-MM-yyyy") + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\" class=\"fdatepicker\" autocomplete=\"off\"" + strEvent + " " + strReadonly + ">");
                                break;
                            case "datetime":
                                Response.Write("<input class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " fdatetimepicker\" type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + Convert.ToDateTime (GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString())).ToString ("dd-MM-yyyy HH:mm tt").Trim () + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\" class=\"datetimepicker\" autocomplete=\"off\"" + strEvent + " " + strReadonly + ">");
                                break;
                            default:
                                Response.Write("<input class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + Convert.ToDateTime (GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString())).ToString ("dd-MM-yyyy") + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\" class=\"fdatepicker\" autocomplete=\"off\"" + strEvent + " " + strReadonly + ">");
                                break;
                        }
                    } else {
                        switch (dtRow["CoreAttributesFormat_Code"].ToString()){
                            case "date":
                                Response.Write("<input class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " fdatepicker\" type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\" class=\"fdatepicker\" autocomplete=\"off\"" + strEvent + " " + strReadonly + ">");
                                break;
                            case "datetime":
                                Response.Write("<input class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " fdatetimepicker\" type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\" class=\"fdatetimepicker\" autocomplete=\"off\"" + strEvent + " " + strReadonly + ">");
                                break;
                            default:
                                strValue=GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString());
                                if (strValue!=null && strValue.Length>0){
                                  strValue=Convert.ToDateTime(strValue).ToString("dd-MM-yyyy");
                                }
                                Response.Write("<input type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + strValue + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\" class=\"fdatepicker\" autocomplete=\"off\"" + strEvent + " " + strReadonly + ">");
                                break;
                        }
                    }
                    break;
                case "number":
                    if (boolReadonly.Equals (false)){
                      Response.Write("<input type=\"number\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                    }else{
                      Response.Write("<span name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\">" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "</span>");
                    }
                    break;
                case "join":
                    //chiave della tabella di join
                    strFROMNet = "CoreEntities";
                    strWHERENet = "CoreEntities_Code='" + dtRow["CoreAttributes_Join"].ToString() + "'";
                    strORDERNet = "CoreEntities_Ky";
                    dtKey = new System.Data.DataTable ("Key");
                    dtKey = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                    strKeyJoin = dtKey.Rows[0]["CoreEntities_Key"].ToString();

                    if (dtRow["CoreAttributes_JoinWhere"].ToString().Length > 0){
                        strWHERENet = dtRow["CoreAttributes_JoinWhere"].ToString();
                    } else {
                        strWHERENet = "";
                    }
                    strFROMNet = dtRow["CoreAttributes_JoinFrom"].ToString();
                    strORDERNet = dtRow["CoreAttributes_JoinOrder"].ToString();
                    dtLookup = new System.Data.DataTable ("Lookup");
                    dtLookup = Smartdesk.Sql.getTablePage(strFROMNet, null, strKeyJoin, strWHERENet, strORDERNet, 1, 20000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

                    switch (dtRow["CoreAttributesFormat_Code"].ToString()){
                        case "select":
                            Response.Write("<select class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            Response.Write("<option></option>");
                            for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++){
                                if (dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinKey"].ToString()].ToString() == GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString())){
                                    strSelected = " selected";
                                } else {
                                    strSelected = "";
                                }

                                Response.Write("<option value=\"" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinKey"].ToString()].ToString() + "\"" + strSelected + ">");
                                strValues = dtRow["CoreAttributes_JoinText"].ToString().Split (',');
                                //Response.Write(dtRow["CoreAttributes_JoinText"].ToString());
                                for (int iValues = 0; iValues < strValues.Length; iValues++){
                                    if (iValues > 0){
                                        Response.Write(" - ");
                                    }
                                    Response.Write(dtLookup.Rows[iLookup][strValues[iValues].Trim ()].ToString());
                                }
                                Response.Write("</option>");
                            }
                            Response.Write("</select>");
                            break;
                        case "selectmultiple":
                            Response.Write("<select multiple=\"multiple\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " select2\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                            Response.Write("<option></option>");
                            strValues = GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()).Split (',');;
                            for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++){

                                if (strValues.Contains (dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinKey"].ToString()].ToString())){
                                    strSelected = " selected";
                                } else {
                                    strSelected = "";
                                }
                                Response.Write("<option value=\"" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinKey"].ToString()].ToString() + "\"" + strSelected + ">" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinText"].ToString()].ToString() + "</option>");
                            }
                            Response.Write("</select>");
                            Response.Write("<script type=\"text/javascript\">");
                            Response.Write("selectSetMultiple('" + dtRow["CoreAttributes_Code"].ToString() + "', '" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "');");
                            Response.Write("</script>");
                            break;
                        case "tags":
                            Response.Write("<select class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " select2\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\" multiple " + strEvent + " " + strReadonly + ">");
                            Response.Write("<option></option>");
                            strValues = GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()).Split (',');;
                            for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++){
                                if (strValues.Contains (dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinKey"].ToString()].ToString())){
                                    strSelected = " selected";
                                } else {
                                    strSelected = "";
                                }
                                Response.Write("<option value=\"" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinText"].ToString()].ToString() + "\"" + strSelected + ">" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinText"].ToString()].ToString() + "</option>");
                            }
                            Response.Write("</select>");

                            Response.Write("<script type=\"text/javascript\">");
                            Response.Write("selectSetMultiple('" + dtRow["CoreAttributes_Code"].ToString() + "', '" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "');");
                            Response.Write("</script>");
                            break;
                        case "search":
                            //url del form
                            strWHERENet = "(CoreEntities_Code='" + dtRow["CoreAttributes_Join"].ToString() + "')";
                  		      strFROMNet = "CoreForms_Vw";
                            strORDERNet = "CoreForms_Default DESC, CoreForms_Ky";
                            dtTemp = new DataTable ("CoreForms");
                            dtTemp = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                            if (dtTemp.Rows.Count > 0){
                                if (dtCoreGrids.Rows[0]["CoreGrids_Custom"].Equals (true)){
                                    strFormUrlJoin = "/admin/app/" + dtTemp.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtTemp.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1";
                                } else {
                                    strFormUrlJoin = "/admin/form.aspx?CoreModules_Ky=" + dtTemp.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" +  dtTemp.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" +  dtTemp.Rows[0]["CoreForms_Ky"].ToString();
                                }
                            }
                            //campo
                            strFROMNet = "CoreEntities_Vw";
                            strWHERENet = "CoreEntities_Code='" + dtRow["CoreAttributes_Join"].ToString() + "'";
                            strORDERNet = "CoreEntities_Ky";
                            dtCoreModulesJoin = new System.Data.DataTable ("CoreModulesJoin");
                            dtCoreModulesJoin = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                            Response.Write("<div class=\"input-group\">\n");
                            //Response.Write("<span class=\"input-group-label\">\n");
                            Response.Write("<input style=\"width:60px;margin-right:5px;\" type=\"text\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">\n");
                            //Response.Write("</span>\n");
                            Response.Write("<input style=\"width:70%\" type=\"text\" class=\"input-group-field\" name=\"" + dtRow["CoreAttributes_JoinText"].ToString() + "\" id=\"" + dtRow["CoreAttributes_JoinText"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_JoinText"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\">\n");
                            Response.Write("<div class=\"input-group-button\"><a href=\"javascript:gotoScheda('" + dtRow["CoreAttributes_Join"].ToString() + "','" + dtRow["CoreAttributes_JoinKey"].ToString() + "','" + strFormUrlJoin + "');\" style=\"margin-top:4px\"><i class=\"fa-duotone fa-arrow-alt-circle-right fa-fw fa-lg\"></i></a>\n");
                            Response.Write("</div>\n");
                            Response.Write("</div>\n");
                            Response.Write("<script type=\"text/javascript\">\n");
                            Response.Write("		jQuery(\"#" + dtRow["CoreAttributes_JoinText"].ToString() + "\").autocomplete({\n");
                            Response.Write("			source: \"/admin/app/" + dtCoreModulesJoin.Rows[0]["CoreModules_Code"].ToString().ToLower () + "/autosuggest-Get" + dtRow["CoreAttributes_Join"].ToString() + "-json.aspx\",\n");
                            Response.Write("			minLength: 2,\n");
                            Response.Write("			select: function( event, ui ){\n");
                            Response.Write("				jQuery(\"#" + dtRow["CoreAttributes_Code"].ToString() + "\").val(ui.item.value);\n");
                            Response.Write("				jQuery(\"#" + dtRow["CoreAttributes_JoinText"].ToString() + "\").val(ui.item.label);\n");
                            Response.Write("				return false;\n");
                            Response.Write("			}\n");
                            Response.Write("		});\n");
                            Response.Write("</script>\n");
                            break;
                        case "radio":
                            Response.Write("<div class=\"stacked-for-small button-group tiny round toggle\">");
                            for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++){
                                if (dtLookup.Rows[iLookup][dtRow["CoreAttributes_Code"].ToString()].ToString() == GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString())){
                                    strSelected = " checked";
                                } else {
                                    strSelected = "";
                                }

                                Response.Write("<input type=\"radio\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" value=\"" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_Code"].ToString()].ToString() + "\"" + strSelected + "" + strEvent + " " + strReadonly + "><label for=\"" + dtRow["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" class=\"button\">" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinText"].ToString()].ToString() + "</label>");
                            }
                            Response.Write("</div>");
                            break;
                        case "radioicon":
                            Response.Write("<div class=\"stacked-for-small button-group tiny round toggle\">");
                            for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++){
                                if (dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinKey"].ToString()].ToString() == GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString())){
                                    strSelected = " checked";
                                } else {
                                    strSelected = "";
                                }

                                Response.Write("<input type=\"radio\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + "\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" value=\"" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinKey"].ToString()].ToString() + "\"" + strSelected + "" + strEvent + " " + strReadonly + "><label for=\"" + dtRow["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" class=\"button " + strReadonly + "\"><i role=\"img\" class=\"" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinIconField"].ToString()].ToString() + " fa-fw\"></i>" + dtLookup.Rows[iLookup][dtRow["CoreAttributes_JoinText"].ToString()].ToString() + "</label>");
                            }
                            Response.Write("</div>");
                            break;
                    }
                    break;
                case "checkbox":
                    Response.Write("<div class=\"switch tiny\">");
                    Response.Write("<input type=\"checkbox\" class=\"" + dtRow["CoreAttributesFormat_Code"].ToString() + " switch-input\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"on\"" + strEvent + " " + strReadonly + "");
                    if (GetCheckValue (dtFormsData, dtRow["CoreAttributes_Code"].ToString())){
                        Response.Write(" checked=\"checked\"");
                    }
                    Response.Write(" />");
                    Response.Write("<label class=\"switch-paddle\" for=\"" + dtRow["CoreAttributes_Code"].ToString() + "\">");
                    Response.Write("<span class=\"show-for-sr\">Ok</span>");
                    Response.Write("<span class=\"switch-active\" aria-hidden=\"true\"><i role=\"img\" class=\"fa-duotone fa-square-check fa-fw fa-lg\"></i></span>");
                    Response.Write("<span class=\"switch-inactive\" aria-hidden=\"true\"></span>");
                    Response.Write("</label>");
                    Response.Write("</div>");
                    break;
                default:
                    Response.Write("<input type=\"text\" name=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" id=\"" + dtRow["CoreAttributes_Code"].ToString() + "\" value=\"" + GetFieldValue(dtFormsData, dtRow["CoreAttributes_Code"].ToString()) + "\" placeholder=\"" + dtRow["CoreAttributes_Label"].ToString() + "\"" + strEvent + " " + strReadonly + ">");
                    break;
            }
            if (dtRow["CoreAttributes_Helptext"].ToString().Length > 0){
                Response.Write("<p class=\"help-text\">" + dtRow["CoreAttributes_Helptext"].ToString() + "</p>");
            }

            //Response.Write("</div>");
            Response.Write("</div>");
        }
    }

    public Boolean GetCheckValue(DataTable dtTabella, string strField){
        Boolean boolValore = false;
        if (strAzione == "new"){
            boolValore = false;
        } else {
            boolValore = Smartdesk.Data.FieldBool(dtTabella, strField);
        }
        return boolValore;
    }

    public String GetFieldValue(DataTable dtTabella, string strField){
        string strValore = "";
        if (strAzione == "new"){
            strValore = GetDefaultValue(strField);
        } else {
            strValore = Smartdesk.Data.Field(dtTabella, strField);
        }
        return strValore;
    }

    public String GetDefaultValue (string strField){
        DataTable dtDefaultValue;
        string strValore = "";
        
        if (strField!=null && strField.Length>0){
          if (Request[strField]!=null){
              strValore = Request[strField];
          }else{
              strWHERENet = "(CoreAttributes_Code='" + strField + "')";
              strFROMNet = "CoreAttributes";
              strORDERNet = "CoreAttributes_Ky";
              dtDefaultValue = new DataTable ("CoreAttributes");
              dtDefaultValue = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtDefaultValue!=null && dtDefaultValue.Rows.Count>0){
                strValore = dtDefaultValue.Rows[0]["CoreAttributes_DefaultValue"].ToString();
              }
          }
        }
        return strValore;
    }

    public string render(string strRenderer, DataTable drDati, int intRow){
      string strReturn="";
      string strColumn="";
      string strField="";
      string strData="";
      strReturn=strRenderer;
      foreach(DataColumn dataColumn in drDati.Columns)
      {
        strColumn="[" + dataColumn.ColumnName  + "]";
        strField=dataColumn.ColumnName;
        strData=drDati.Rows[intRow][strField].ToString();
        strReturn=strReturn.Replace(strColumn,strData);
        //strReturn+=strColumn + "-" + strField + "-" + strData + "|";
      }
      return strReturn;
    }  
    
    public string getLabel(DataRow drDati){
      string strReturn="";
      if (drDati["CoreGridsColumns_Label"].ToString().Length>0){
         strReturn=drDati["CoreGridsColumns_Label"].ToString();
      }else{
        strReturn=drDati["CoreAttributes_Title"].ToString();
      }
      return strReturn;
    }  

    public DataTable getTablePage (string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
        DataTable dt = Smartdesk.Sql.getTablePage (table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }
}
