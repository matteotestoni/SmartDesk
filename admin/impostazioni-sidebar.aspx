<%
 string path = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
 System.IO.FileInfo info = new System.IO.FileInfo(path); 
 string strName=info.Name.ToLower().Replace("elenco-","").Replace("scheda-","");
 string strActive="is-active";
 string strWhereMenu="";
 
 System.Data.DataTable dtCoreModulesMenu;
 System.Data.DataTable dtCoreModulesOptionsValueMenu;
 System.Data.DataTable dtCoreGridsMenu;
 
 dtCoreModulesMenu = Smartdesk.Sql.getTablePage("CoreModules", null, "CoreModules_Ky", "CoreModules_Active=1", "CoreModules_Order", 1, 500,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

 Response.Write("<ul id=\"sidebarimpostazioni\" class=\"accordion hide-for-print\" data-accordion>");
 Response.Write("<li class=\"accordion-item\"><a href=\"/admin/settings.aspx\"><i class=\"fa-duotone fa-gears fa-fw\"></i>Impostazioni generali</a></li>");
 for (int iCoreModulesMenu = 0; iCoreModulesMenu < dtCoreModulesMenu.Rows.Count; iCoreModulesMenu++){
	System.Data.DataTable dtCoreEntitiesMenu;
 	dtCoreEntitiesMenu = Smartdesk.Sql.getTablePage("CoreEntities", null, "CoreEntities_Ky", "CoreEntities_Config=1 AND CoreEntities_InMenu=1 AND CoreModules_Ky=" + dtCoreModulesMenu.Rows[iCoreModulesMenu]["CoreModules_Ky"].ToString(), "CoreEntities_Title", 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	 	if (dtCoreEntitiesMenu.Rows.Count>0){
			if (Request["CoreModules_Ky"]==dtCoreModulesMenu.Rows[iCoreModulesMenu]["CoreModules_Ky"].ToString()){
				strActive="is-active";
			}else{
				strActive="";
			}
			Response.Write("<li class=\"accordion-item " + strActive + "\" data-accordion-item>"); 
			Response.Write("<a href=\"#\" class=\"accordion-title\"><i class=\"" + dtCoreModulesMenu.Rows[iCoreModulesMenu]["CoreModules_Icon"].ToString() + " fa-lg fa-fw\"></i>" + dtCoreModulesMenu.Rows[iCoreModulesMenu]["CoreModules_Title"].ToString() + "</a>");
			Response.Write("<div class=\"accordion-content\" data-tab-content>");
			Response.Write("<ul id=\"impostazionigenerali\" class=\"menu vertical\">");
			  for (int j = 0; j < dtCoreEntitiesMenu.Rows.Count; j++){
					if (Request["CoreEntities_Ky"]==dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString()){
						strActive="is-active";
					}else{
						strActive="";
					}
          strWhereMenu="CoreGrids_Default=1 AND CoreEntities_Ky=" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString();
 					dtCoreGridsMenu = Smartdesk.Sql.getTablePage("CoreGrids", null, "CoreGrids_Ky", strWhereMenu, "CoreGrids_Order", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

					if (dtCoreGridsMenu.Rows.Count>0){
						if (dtCoreGridsMenu.Rows[0]["CoreGrids_Custom"].Equals(true)){
							Response.Write("<li class=\"" + strActive + "\" data-accordion-item><a href=\"/admin/app/" + dtCoreModulesMenu.Rows[iCoreModulesMenu]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Code"].ToString() + ".aspx?CoreModules_Ky=" + dtCoreModulesMenu.Rows[iCoreModulesMenu]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGridsMenu.Rows[0]["CoreGrids_Ky"].ToString() + "\"><i class=\"" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Icon"].ToString() + " fa-fw\"></i>" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_LabelPlural"].ToString() + "</a></li>");
						}else{
							Response.Write("<li class=\"" + strActive + "\" data-accordion-item><a href=\"/admin/view.aspx?CoreModules_Ky=" + dtCoreModulesMenu.Rows[iCoreModulesMenu]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGridsMenu.Rows[0]["CoreGrids_Ky"].ToString() + "\"><i class=\"" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Icon"].ToString() + " fa-fw\"></i>" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_LabelPlural"].ToString() + "</a></li>");
						} 
					}
				}
	    Response.Write("</ul></div></li>");
		}
 }
%>
		<li class="accordion-item <%=strActive%>" data-accordion-item>
			<a href="#" class="accordion-title"><i class="fa-duotone fa-building fa-lg fa-fw"></i>Sistema</a>
			<div class="accordion-content" data-tab-content>
			<ul id="impostazionisdk" class="menu vertical">
				<li data-accordion-item><a href="/admin/app/sistema/test-smtp.aspx?CoreModules_Ky=12"><i class="fa-duotone fa-sync fa-fw"></i>Test SMTP</a></li>
				<li data-accordion-item><a href="/admin/app/sistema/genera-cache.aspx?CoreModules_Ky=12"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna cache</a></li>
				<li data-accordion-item><a href="/admin/app/sistema/genera-url.aspx?CoreModules_Ky=12"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna url</a></li>
				<li data-accordion-item><a href="/admin/app/sdk/genera-where.aspx?CoreModules_Ky=12"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna ricerche</a></li>
				<li data-accordion-item><a href="/admin/app/sdk/genera-form.aspx?CoreModules_Ky=12"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna form</a></li>
				<li data-accordion-item><a href="/admin/app/sistema/aggiornamento-sdk.aspx?CoreModules_Ky=12"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna sdk</a></li>
				<li data-accordion-item><a href="/admin/app/sistema/aggiornamento-db-date.aspx?CoreModules_Ky=26"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna DB Date</a></li>
				<li data-accordion-item><a href="/update/aggiornamento-db-to-xml.aspx?CoreModules_Ky=26"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna da DB --> XML</a></li>
				<li data-accordion-item><a href="/update/aggiornamento-xml-to-db.aspx?CoreModules_Ky=26"><i class="fa-duotone fa-sync fa-fw"></i>Aggiorna da XML --> DB</a></li>
			</ul>
			</div>
	    </li>
<%
 Response.Write("</ul>");
%>
