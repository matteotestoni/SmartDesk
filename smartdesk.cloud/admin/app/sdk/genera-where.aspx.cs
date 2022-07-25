using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.IO;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ciit = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo cien = new System.Globalization.CultureInfo("en-US");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public DataTable dtTemp;
    public DataTable dtTempFigli;
    public string strFROMNet = "";
    public string strH1 = "";
    public string strRisultato = "";
    public string strTemp = "";
    
    public DataTable dtCoreModules;
    public DataTable dtCoreEntities;
    public DataTable dtCoreGrids;
    public DataTable dtCoreAttributes;
    public string strCoreModules_Ky = "";
    public string strCoreEntities_Ky = "";
    public string strKeyJoin = "";
    public DataTable dtKey;
    public DataTable dtLookup;
    public string[] strValues;

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strORDERNet = "";
      StreamWriter sw;

      
      strCoreModules_Ky =  Smartdesk.Current.QueryString("CoreModules_Ky");
      strCoreEntities_Ky =  Smartdesk.Current.QueryString("CoreEntities_Ky");

      if (Smartdesk.Login.Verify){
          	dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            strH1="Generazione filtri di ricerca";
						strRisultato="<ul>";
            
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);

            //categorie CMS
            if (strCoreModules_Ky!=null && strCoreModules_Ky.Length>0){
							strWHERENet="CoreModules_Ky=" + strCoreModules_Ky;
						}else{
							strWHERENet="CoreModules_Active=1 AND CoreModules_Ky=33";
						}
            strORDERNet = "CoreModules_Order";
            strFROMNet = "CoreModules";
            dtCoreModules = new DataTable("CoreModules");
            dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            for (int iCoreModules = 0; iCoreModules < dtCoreModules.Rows.Count; iCoreModules++){
	            if (strCoreEntities_Ky!=null && strCoreEntities_Ky.Length>0){
								strWHERENet="CoreEntities_Ky=165";
								strWHERENet="CoreEntities_Ky=" + strCoreEntities_Ky;
							}else{
	            	strWHERENet="CoreModules_Ky=" + dtCoreModules.Rows[iCoreModules]["CoreModules_Ky"].ToString();
							}
	            strORDERNet = "CoreEntities_Order";
	            strFROMNet = "CoreEntities";
	            dtCoreEntities = new DataTable("CoreEntities");
	            dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            	for (int iCoreEntities = 0; iCoreEntities < dtCoreEntities.Rows.Count; iCoreEntities++){

  							strWHERENet="CoreEntities_Ky=" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Ky"].ToString();
  	            strORDERNet = "CoreGrids_Order";
  	            strFROMNet = "CoreGrids";
  	            dtCoreGrids = new DataTable("CoreGrids");
  	            dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		            if (strCoreModules_Ky!=null && strCoreModules_Ky.Length>0){
									strWHERENet="CoreModules_Ky=" + strCoreModules_Ky;
								}else{
									strWHERENet="CoreModules_Active=1 AND CoreModules_Ky=12";
								}

		            strWHERENet="CoreAttributes_Search=1 AND CoreEntities_Ky=" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Ky"].ToString();
		            strORDERNet = "CoreAttributes_Order";
		            strFROMNet = "CoreAttributes_Vw";
		            dtCoreAttributes = new DataTable("CoreAttributes");
		            dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		            if (dtCoreAttributes.Rows.Count>0){
            				sw = new StreamWriter(Server.MapPath("/admin/app/" + dtCoreModules.Rows[iCoreModules]["CoreModules_Code"].ToString() + "/where/where-" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ".inc"), false, System.Text.Encoding.Default);
                  	sw.WriteLine("<fieldset class=\"filtri fieldset hide hide-for-print\" id=\"filtri\" data-toggler=\".hide\">");
                  	sw.WriteLine("<legend>Cerca</legend>");
                  	sw.WriteLine("<form id=\"formRicerca\" class=\"formRicerca\" method=\"get\" action=\"/admin/view.aspx\">");
                  	sw.WriteLine("<input type=\"hidden\" name=\"CoreModules_Ky\" value=\"" + dtCoreModules.Rows[iCoreModules]["CoreModules_Ky"].ToString() + "\" />");                                  
                  	sw.WriteLine("<input type=\"hidden\" name=\"CoreEntities_Ky\" value=\"" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Ky"].ToString() + "\" />");                                  
                  	sw.WriteLine("<input type=\"hidden\" name=\"CoreGrids_Ky\" value=\"" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "\" />");                                  
            		for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
                try{
            			sw.WriteLine("<div class=\"grid-x grid-padding-x " + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesType_Code"].ToString() + "\">");
            			sw.WriteLine("<div class=\"large-2 medium-2 small-4 cell\">");
            			sw.WriteLine("<label for=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" class=\"large-text-right small-text-left middle\">" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "</label>");
            			sw.WriteLine("</div>");
            			sw.WriteLine("<div class=\"large-10 medium-10 small-8 cell\">");
                      switch (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesType_Code"].ToString())
                      {
                          case "join":
                            //chiave della tabella di join
                            strFROMNet = "CoreEntities";
                            strWHERENet = "CoreEntities_Code='" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Join"].ToString() + "'";
                            strORDERNet = "CoreEntities_Ky";
                            dtKey = new System.Data.DataTable("Key");
                            dtKey = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                            strKeyJoin = dtKey.Rows[0]["CoreEntities_Key"].ToString();
                            
                            if (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinWhere"].ToString().Length > 0) {
                                strWHERENet = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinWhere"].ToString();
                            } else {
                                strWHERENet = "";
                            }
                            strFROMNet = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Join"].ToString();
                            strORDERNet = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinOrder"].ToString();
                            dtLookup = new System.Data.DataTable("Lookup");
                            dtLookup = Smartdesk.Sql.getTablePage(strFROMNet, null, strKeyJoin, strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                            switch (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesFormat_Code"].ToString())
                            {
                                case "select":
                                    sw.WriteLine("<select name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[i]["CoreAttributes_Code"].ToString() + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
                                    sw.WriteLine("<option></option>");
                                    for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++)
                                    {
                                        sw.WriteLine("<option value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString()].ToString() + "\">");
                                        strValues = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString().Split (',');
                                        for (int iValues = 0; iValues < strValues.Length; iValues++) {
                                            if (iValues > 0) {
                                               sw.Write (" - ");
                                            }
                                            sw.Write(dtLookup.Rows[iLookup][strValues[iValues].Trim()].ToString());
                                        }
                                        sw.WriteLine("</option>");

                                    }
                                    sw.WriteLine("</select>");
                                    break;
                                case "tags":
                                    sw.WriteLine("<select name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\" multiple class=\"select2\">");
                                    sw.WriteLine("<option></option>");
                                    for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++)
                                    {
                                        sw.WriteLine("<option value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "\">" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "</option>");
                                    }
                                    sw.WriteLine("</select>");
                                    break;
                                case "search":
                                    sw.WriteLine("<div class=\"grid-x grid-padding-x\">");
                                    sw.WriteLine("<div class=\"shrink cell hide-for-small-only\"><input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\"></div>");
                                    sw.WriteLine("<div class=\"auto cell\"><input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\"></div>");
                                    sw.WriteLine("<script type=\"text/javascript\">");
                                    sw.WriteLine("		jQuery(\"#" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\").autocomplete({");
                                    sw.WriteLine("			source: \"/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/autosuggest-Get" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Join"].ToString() + "-json.aspx\",");
                                    sw.WriteLine("			minLength: 2,");
                                    sw.WriteLine("			select: function( event, ui ) {");
                                    sw.WriteLine("				jQuery(\"#" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\").val(ui.item.value);");
                                    sw.WriteLine("				jQuery(\"#" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\").val(ui.item.label);");
                                    sw.WriteLine("				return false;");
                                    sw.WriteLine("			}");
                                    sw.WriteLine("		});");
                                    sw.WriteLine("</script>");
                                    sw.WriteLine("</div>");
                                    break;
                                case "radio":
                                    sw.WriteLine("<div class=\"button-group round toggle\">");
                                    for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++)
                                    {
                                        Response.Write("<input type=\"radio\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString()].ToString() + "\"><label for=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" class=\"button\">" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "</label>");
                                    }
                                    sw.WriteLine("</div>");
                                    break;
                                case "radioicon":
                                    sw.WriteLine("<div class=\"button-group round toggle\">");
                                    for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++)
                                    {
                                        sw.WriteLine("<input type=\"radio\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString()].ToString() + "\"><label for=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" class=\"button\"><i class=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinIconField"].ToString()].ToString() + " fa-fw\"></i>" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "</label>");
                                    }
                                    sw.WriteLine("</div>");
                                    break;
                            }
      		            			//sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" class=\"input-group-field\" placeholder=\"ricerca per " + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
                            break;
                          case "checkbox":
      		            			sw.WriteLine("<input type=\"checkbox\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" class=\"input-group-field\" placeholder=\"ricerca per " + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\" value=\"1\">");
                            break;
                          default:
      		            			sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" class=\"input-group-field\" placeholder=\"ricerca per " + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
                            break;
                      }
								}catch (Exception ex){
                  Response.Write("<hr>");
                  Response.Write("iCoreAttributes:" + iCoreAttributes + "<br>"); 
                  //Response.Write("iLookup:" + iLookup + "<br>"); 
                  Response.Write("strFROMNet:" + strFROMNet + "<br>"); 
                  Response.Write("CoreAttributes_JoinIconField:" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinIconField"].ToString() + "<br>"); 
                  Response.Write("CoreAttributes_JoinText:" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "<br>"); 
                  Response.Write("CoreAttributes_Code: " + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString());
                  Response.Write(ex);
                }


		            			sw.WriteLine("</div>");
		            			sw.WriteLine("</div>");
										}
                  	sw.WriteLine("<div class=\"grid-x grid-padding-x\">");                                  
                  	sw.WriteLine("<div class=\"large-12 medium-12 small-12 text-center\">");                                      
                  	sw.WriteLine("<button type=\"submit\" name=\"Submit\" class=\"button success\"><i class=\"fa-duotone fa-magnifying-glass fa-fw\"></i>Cerca</button>");                                  
                  	sw.WriteLine("</div>");                                
										sw.WriteLine("</div>");                              
                  	sw.WriteLine("</form>");
                  	sw.WriteLine("</fieldset>");
            				sw.Close();
            				strRisultato=strRisultato + "<li>" + dtCoreModules.Rows[iCoreModules]["CoreModules_Code"].ToString() + "-" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + "</li>";        
                }
							}
            }
            strRisultato=strRisultato + "</ul>";        
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
