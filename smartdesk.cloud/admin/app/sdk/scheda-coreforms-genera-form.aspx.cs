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
    public string strWHERENet="";
    public string strORDERNet = "";
    public string strH1 = "";
    public string strRisultato = "";
    public string strTemp = "";
    
    public DataTable dtCoreModules;
    public DataTable dtCoreModulesJoin;
    public DataTable dtCoreEntities;
    public DataTable dtCoreAttributes;
    public DataTable dtCoreForms;
    public DataTable dtCoreFormsTabs;
    public DataTable dtCoreFormsFieldset;
    public DataTable dtCoreFormsRelations;
    public DataTable dtCoreFormsButtons;
    public DataTable dtLookup;
    public DataTable dtKey;
    public string strAspNetStart = "<%";
    public string strAspNetEnd = "%>";
    public string strSQL = "";
    public string strCoreForms_Ky = "";
    public string strCoreEntities_Ky = "";
    public string strCoreModules_Ky = "";
    public string strActive = "";
    public int intCoreForms_Ky = 1;
    public StreamWriter sw;
    public string strEvent = "";
    public string strKeyJoin = "";
    public string[] strValues;

    protected void Page_Load(object sender, EventArgs e)
    {
      
	  
      if (Smartdesk.Login.Verify){
            dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
            boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
            strCoreEntities_Ky=Request["CoreEntities_Ky"];
            strCoreModules_Ky=Request["CoreModules_Ky"];
            strCoreForms_Ky=Request["CoreForms_Ky"];
            strH1="Generazione form";
			strRisultato="<ul>";
            
            strWHERENet="CoreModules_Active=1 AND CoreModules_Ky=" + strCoreModules_Ky;
            strORDERNet = "CoreModules_Order";
            strFROMNet = "CoreModules";
            dtCoreModules = new DataTable("CoreModules");
            dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            strWHERENet="CoreEntities_Ky=" + strCoreEntities_Ky + " AND CoreModules_Ky=" + dtCoreModules.Rows[0]["CoreModules_Ky"].ToString();
            strORDERNet = "CoreEntities_Code";
            strFROMNet = "CoreEntities";
            dtCoreEntities = new DataTable("CoreEntities");
            dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            
            strWHERENet="CoreForms_Ky=" + strCoreForms_Ky;
            strORDERNet = "CoreForms_Ky";
            strFROMNet = "CoreForms";
            dtCoreForms = new DataTable("CoreAttributes");
            dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreForms_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			intCoreForms_Ky=Convert.ToInt32(dtCoreForms.Rows[0]["CoreForms_Ky"].ToString());
               
            strWHERENet = "(CoreForms_Ky=" + intCoreForms_Ky + ")";
            strFROMNet = "CoreFormsRelations";
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
            strORDERNet = "CoreFormsButtons_Order, CoreFormsButtons_Ky";
            dtCoreFormsButtons = new DataTable ("CoreFormsButtons");
            dtCoreFormsButtons = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsButtons_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

								sw = new StreamWriter(Server.MapPath("/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/forms/" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + "_form.htm"), false, System.Text.Encoding.Default);

								if (dtCoreFormsTabs.Rows.Count>1){
									sw.WriteLine("<ul class=\"tabs\" data-responsive-accordion-tabs=\"tabs small-accordion medium-tabs large-tabs\" role=\"tablist\" id=\"anagrafica-tabs\">");
									for (int iCoreFormsTabs = 0; iCoreFormsTabs < dtCoreFormsTabs.Rows.Count; iCoreFormsTabs++){
										if (iCoreFormsTabs==0){
											strActive=" is-active";
										}else{
											strActive="";
										}
										sw.WriteLine("<li class=\"tabs-title" + strActive + "\" role=\"presentational\"><a href=\"#tabs-" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + "\"><i role=\"img\" class=\"" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Icon"].ToString() + " fa-lg fa-fw\"></i>" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Title"].ToString() + "</a></li>");
									}
									sw.WriteLine("</ul>");
									sw.WriteLine("<div class=\"tabs-content\" data-tabs-content=\"anagrafica-tabs\">");
									for (int iCoreFormsTabs = 0; iCoreFormsTabs < dtCoreFormsTabs.Rows.Count; iCoreFormsTabs++){
										if (iCoreFormsTabs==0){
											strActive=" is-active";
										}else{
											strActive="";
										}
										sw.WriteLine("<section role=\"tabpanel\" aria-hidden=\"false\" class=\"tabs-panel" + strActive + "\" id=\"tabs-" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + "\" name=\"tabs-" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + "\">");
												strWHERENet="(CoreForms_Ky=" + intCoreForms_Ky + " AND CoreFormsTabs_Ky=" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() + ")";
												strFROMNet = "CoreFormsFieldset";
												strORDERNet = "CoreFormsFieldset_Order";
												dtCoreFormsFieldset = new System.Data.DataTable("CoreFormsFieldset");
												dtCoreFormsFieldset = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreFormsFieldset_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
												if (dtCoreFormsFieldset.Rows.Count>1){
																for (int iCoreFormsFieldset = 0; iCoreFormsFieldset < dtCoreFormsFieldset.Rows.Count; iCoreFormsFieldset++){
																	sw.WriteLine("<fieldset class=\"fieldset\"><legend>" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Title"].ToString() + "</legend>");
																	strWHERENet="CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreFormsFieldset_Ky=" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Ky"].ToString() ;
																	strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
																	strFROMNet = "CoreFormsFields_Vw";
																	dtCoreAttributes = new System.Data.DataTable("CoreAttributes");
																	dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
																	if (dtCoreAttributes.Rows.Count>0){
																			for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
																				RenderField(iCoreAttributes,0 );
																			}
																	}
																	sw.WriteLine("</fieldset>");
																}
												}else{
																	strWHERENet="CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreFormsTabs_Ky=" + dtCoreFormsTabs.Rows[iCoreFormsTabs]["CoreFormsTabs_Ky"].ToString() ;
																	strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
																	strFROMNet = "CoreFormsFields_Vw";
																	dtCoreAttributes = new System.Data.DataTable("CoreAttributes");
																	dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
																	if (dtCoreAttributes.Rows.Count>0){
																			for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
																				RenderField(iCoreAttributes,0);
																			}
																	}
				
												}   
										sw.WriteLine("</section>");
									}
									sw.WriteLine("</div>");
								}else{
									if (dtCoreFormsFieldset.Rows.Count>0){
											for (int iCoreFormsFieldset = 0; iCoreFormsFieldset < dtCoreFormsFieldset.Rows.Count; iCoreFormsFieldset++){
												Response.Write("<fieldset class=\"fieldset\"><legend>" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Title"].ToString() + "</legend>");
												strWHERENet="CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString() + " AND CoreFormsFieldset_Ky=" + dtCoreFormsFieldset.Rows[iCoreFormsFieldset]["CoreFormsFieldset_Ky"].ToString() ;
												strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
												strFROMNet = "CoreFormsFields_Vw";
												dtCoreAttributes = new System.Data.DataTable("CoreAttributes");
												dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
												if (dtCoreAttributes.Rows.Count>0){
														for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
															RenderField(iCoreAttributes,0);
														}
												}
												Response.Write("</fieldset>");
											}
									
									}else{
										strWHERENet="CoreAttributes_System<>1 AND CoreAttributes_Key<>1 AND CoreAttributes_Code<>'" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "'  AND CoreEntities_Ky=" + dtCoreEntities.Rows[0]["CoreEntities_Ky"].ToString();
										strORDERNet = "CoreFormsFields_Order, CoreAttributes_Order, CoreAttributes_Code";
										strFROMNet = "CoreFormsFields_Vw";
										dtCoreAttributes = new System.Data.DataTable("CoreAttributes");
										dtCoreAttributes = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreAttributes_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
										if (dtCoreAttributes.Rows.Count>0){
												for (int iCoreAttributes = 0; iCoreAttributes < dtCoreAttributes.Rows.Count; iCoreAttributes++){
															RenderField(iCoreAttributes,0);
											}
										}
									}
								}

            strRisultato=strRisultato + "</ul>";
						sw.Close(); 
            Response.Redirect("/admin/app/sdk/scheda-coreentities.aspx?salvato=salvato&CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky);
            
            Response.Redirect("/admin/app/sdk/scheda-CoreForms.aspx?salvato=salvato&CoreModules_Ky=" + strCoreModules_Ky + "&CoreForms_Ky=196&CoreEntities_Ky=" + strCoreEntities_Ky);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }    

    public void RenderField (int iCoreAttributes, int iCoreEntities) {
			sw.WriteLine("<div class=\"grid-x grid-padding-x\">");
			sw.WriteLine("<div class=\"xlarge1 large-2 medium-2 small-4 cell\">");
			sw.WriteLine("<label for=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" class=\"large-text-right small-text-left middle\">" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "</label>");
			sw.WriteLine("</div>");
			sw.WriteLine("<div class=\"xlarge11 large-10 medium-10 small-8 cell\">");
			switch (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesType_Code"].ToString()){
				case "text":
						switch (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesFormat_Code"].ToString()){
							case "icon":
								sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
							case "color":
								sw.WriteLine("<input type=\"color\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
							case "text":
								sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
							case "phone":
								sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
							case "email":
								sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
							case "link":
								sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
							case "image":
								sw.WriteLine("<input type=\"file\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
							case "select":
									sw.WriteLine("<select name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\"" + strEvent + ">");
									sw.WriteLine("<option value=\"\"></option>");
									string[] strOptions = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Options"].ToString().Split(Environment.NewLine.ToCharArray());
									foreach (string strOption in strOptions)
									{
											if (strOption.Length>0){
												sw.WriteLine("<option value=\"" + strOption + "\">" + strOption + "</option>");
											}
									}                            
									sw.WriteLine("</select>");
									sw.WriteLine("<script type=\"text/javascript\">");
									sw.WriteLine("selectSet('" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "', '" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "');");
									sw.WriteLine("</script>");
									break;
							case "password":
									sw.WriteLine("<div class=\"input-group\">");
									sw.WriteLine("<input class=\"input-group-field\" type=\"password\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\"" + strEvent + " maxlength=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_MaxLength"].ToString() + "\">");
									sw.WriteLine("<div class=\"input-group-button\"><a onclick=\"showPasswordForm('" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "')\"><i class=\"fa-duotone fa-eye fa-lg fa-fw\"></i></a><a onclick=\"generatePassword('" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "')\"><i class=\"fa-duotone fa-redo fa-lg fa-fw\"></i></a></div>");
									sw.WriteLine("</div>");
									break;
							default:
								sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
								break;
						}
						break;
				case "textarea":
						switch (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesFormat_Code"].ToString()){
							case "textarea":
								sw.WriteLine("<textarea name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\">" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "</textarea>");
								break;
							case "html":
								sw.WriteLine("<textarea name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" class=\"ckfinder\"" + strEvent + ">" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "</textarea>");
								sw.WriteLine("<script type=\"text/javascript\">");
								sw.WriteLine("CKEDITOR.replace('" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "',");
								sw.WriteLine("{");
									//sw.WriteLine("filebrowserBrowseUrl: '/ckfinder/ckfinder.html',");
									//sw.WriteLine("filebrowserUploadUrl: '/ckfinder/core/connector/php/connector.php?command=QuickUpload&type=Files'");
								sw.WriteLine("});");
									//sw.WriteLine("CKFinder.setupCKEditor( editor, null, { type: 'Files', currentFolder: '/uploads/foto-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + "/' } );");
								sw.WriteLine("</script>");
									break;
							default:
								sw.WriteLine("<textarea name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\">" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "</textarea>");
								break;
						}
						break;
				case "data":
						switch (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesFormat_Code"].ToString()){
        					case "date":
        						sw.WriteLine("<input type=\"text\" class=\"fdatepicker\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
        						break;
        					case "datetime":
        						sw.WriteLine("<input type=\"text\" class=\"datetimepicker\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
        						break;
        					default:
        						sw.WriteLine("<input type=\"text\" class=\"fdatepicker\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
        						break;
						}
						break;
				case "number":
						sw.WriteLine("<input type=\"number\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
					break;
				case "checkbox":
						sw.WriteLine("<div class=\"switch tiny\">");                                         
						sw.WriteLine("<input class=\"switch-input\" type=\"checkbox\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"on\" " + strAspNetStart  + " if (GetCheckValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")){ Response.Write(\"checked\");} " + strAspNetEnd  + "  />");
						sw.WriteLine("<label class=\"switch-paddle\" for=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\">");
						sw.WriteLine("<span class=\"show-for-sr\">Ok</span>");
						sw.WriteLine("<span class=\"switch-active\" aria-hidden=\"true\"><i class=\"fa-duotone fa-square-check fa-fw fa-lg\"></i></span>");
						sw.WriteLine("<span class=\"switch-inactive\" aria-hidden=\"true\"></span>");
						sw.WriteLine("</label>");
						sw.WriteLine("</div>"); 
						break;
					case "join":
							//chiave della tabella di join
							strFROMNet = "CoreEntities";
							strWHERENet = "CoreEntities_Code='" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Join"].ToString() + "'";
							strORDERNet = "CoreEntities_Ky";
							dtKey = new System.Data.DataTable ("Key");
							dtKey = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							strKeyJoin = dtKey.Rows[0]["CoreEntities_Key"].ToString();

							if (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinWhere"].ToString().Length > 0) {
									strWHERENet = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinWhere"].ToString();
							} else {
									strWHERENet = "";
							}
							strFROMNet = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinFrom"].ToString();
							strORDERNet = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinOrder"].ToString();
							dtLookup = new System.Data.DataTable ("Lookup");
							dtLookup = Smartdesk.Sql.getTablePage(strFROMNet, null, strKeyJoin, strWHERENet, strORDERNet, 1, 20000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

							switch (dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributesFormat_Code"].ToString()) {
									case "select":
											sw.WriteLine("<select name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\"" + strEvent + ">");
											sw.WriteLine("<option></option>");
											for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++) {
													sw.WriteLine("<option value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinKey"].ToString()].ToString() + "\">");
													strValues = dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString().Split (',');
													//Response.Write(dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString());
													for (int iValues = 0; iValues < strValues.Length; iValues++) {
															if (iValues > 0) {
																	sw.WriteLine(" - ");
															}
															sw.WriteLine(dtLookup.Rows[iLookup][strValues[iValues].Trim ()].ToString());
													}
													sw.WriteLine("</option>");
											}
											sw.WriteLine("</select>");
											break;
									case "selectmultiple":
											sw.WriteLine("<select multiple=\"multiple\" class=\"select2\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\"" + strEvent + ">");
											sw.WriteLine("<option></option>");
											for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++) {
													sw.WriteLine("<option value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinKey"].ToString()].ToString() + "\">" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "</option>");
											}
											sw.WriteLine("</select>");
											sw.WriteLine("<script type=\"text/javascript\">");
											sw.WriteLine("selectSetMultiple('" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "', '" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "');");
											sw.WriteLine("</script>");
											break;
									case "tags":
											sw.WriteLine("<select name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\" multiple class=\"select2\"" + strEvent + ">");
											sw.WriteLine("<option></option>");
											for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++) {
													sw.WriteLine("<option value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "\">" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "</option>");
											}
											sw.WriteLine("</select>");

											sw.WriteLine("<script type=\"text/javascript\">");
											sw.WriteLine("selectSetMultiple('" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "', '" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "');");
											sw.WriteLine("</script>");
											break;
									case "search":
											strFROMNet = "CoreEntities_Vw";
											strWHERENet = "CoreEntities_Code='" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Join"].ToString() + "'";
											strORDERNet = "CoreEntities_Ky";
											dtCoreModulesJoin = new System.Data.DataTable ("CoreModulesJoin");
											dtCoreModulesJoin = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
											sw.WriteLine("<div class=\"input-group\">\n");
											//sw.WriteLine("<span class=\"input-group-label\">\n");
											sw.WriteLine("<input style=\"width:60px;margin-right:5px;\" type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\"" + strEvent + ">\n");
											//sw.WriteLine("</span>\n");
											sw.WriteLine("<input style=\"width:70%\" type=\"text\" class=\"input-group-field\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">\n");
											sw.WriteLine("<div class=\"input-group-button\">\n");
											sw.WriteLine("</div>\n");
											sw.WriteLine("</div>\n");
											sw.WriteLine("<script type=\"text/javascript\">\n");
											sw.WriteLine("		jQuery(\"#" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\").autocomplete({\n");
											sw.WriteLine("			source: \"/admin/app/" + dtCoreModulesJoin.Rows[0]["CoreModules_Code"].ToString().ToLower () + "/autosuggest-Get" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Join"].ToString() + "-json.aspx\",\n");
											sw.WriteLine("			minLength: 2,\n");
											sw.WriteLine("			select: function( event, ui ) {\n");
											sw.WriteLine("				jQuery(\"#" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\").val(ui.item.value);\n");
											sw.WriteLine("				jQuery(\"#" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString() + "\").val(ui.item.label);\n");
											sw.WriteLine("				return false;\n");
											sw.WriteLine("			}\n");
											sw.WriteLine("		});\n");
											sw.WriteLine("</script>\n");
											break;
									case "radio":
											sw.WriteLine("<div class=\"button-group round toggle\">");
											for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++) {
													sw.WriteLine("<input type=\"radio\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString()].ToString() + "\"" + strEvent + "><label for=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" class=\"button\">" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "</label>");
											}
											sw.WriteLine("</div>");
											break;
									case "radioicon":
											sw.WriteLine("<div class=\"button-group round toggle\">");
											for (int iLookup = 0; iLookup < dtLookup.Rows.Count; iLookup++) {
													sw.WriteLine("<input type=\"radio\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" value=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinKey"].ToString()].ToString() + "\"" + strEvent + "><label for=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "-" + iLookup + "\" class=\"button\"><i role=\"img\" class=\"" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinIconField"].ToString()].ToString() + " fa-fw\"></i>" + dtLookup.Rows[iLookup][dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_JoinText"].ToString()].ToString() + "</label>");
											}
											sw.WriteLine("</div>");
											break;
							}
							break;


				default:
					sw.WriteLine("<input type=\"text\" name=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" id=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\" value=\"" + strAspNetStart + "=GetFieldValue(dt" + dtCoreEntities.Rows[iCoreEntities]["CoreEntities_Code"].ToString() + ", \"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Code"].ToString() + "\")" + strAspNetEnd  + "\" placeholder=\"" + dtCoreAttributes.Rows[iCoreAttributes]["CoreAttributes_Label"].ToString() + "\">");
					break;
			}
			sw.WriteLine("</div>");
			sw.WriteLine("</div>");

    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
