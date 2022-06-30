<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/impostazioni-generali.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-gears fa-lg fa-fw"></i>Impostazioni generali</h1>
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">
			</div>
		</div>
	</div>
</div>

<div class="divimpostazioni">
  <div class="grid-container fluid">
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
      <div class="large-10 medium-10 small-12 cell">
          <div class="grid-x grid-padding-x small-up-1 medium-up-2 large-up-3" data-equalizer data-equalize-on="medium" id="test-eq">
          <%
           for (int i = 0; i < dtCoreModules.Rows.Count; i++){
          	System.Data.DataTable dtCoreEntitiesMenu;
           	dtCoreEntitiesMenu = Smartdesk.Sql.getTablePage("CoreEntities", null, "CoreEntities_Ky", "CoreEntities_Config=1 AND CoreModules_Ky=" + dtCoreModules.Rows[i]["CoreModules_Ky"].ToString(), "CoreEntities_Title", 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          	 	if (dtCoreEntitiesMenu.Rows.Count>0){
          	    Response.Write("<div class=\"cell\"><div class=\"card\" data-equalizer-watch>");
          	    Response.Write("<div class=\"card-divider align-middle\"><i class=\"" + dtCoreModules.Rows[i]["CoreModules_Icon"].ToString() + " fa-lg fa-fw\"></i>" + dtCoreModules.Rows[i]["CoreModules_Title"].ToString() + "</div>");
          			Response.Write("<div class=\"card-section\">");
          			Response.Write("<ul style=\"columns:2;list-style-type:none;\">");
          			  for (int j = 0; j < dtCoreEntitiesMenu.Rows.Count; j++){
          					if (Request["CoreEntities_Ky"]==dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString()){
          						strActive="is-active";
          					}else{
          						strActive="";
          					}
                    strWHERE="CoreGrids_Default=1 AND CoreEntities_Ky=" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString();
           					dtCoreGrids = Smartdesk.Sql.getTablePage("CoreGrids", null, "CoreGrids_Ky", strWHERE, "CoreGrids_Order", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          
          					if (dtCoreGrids.Rows.Count>0){
          						if (dtCoreGrids.Rows[0]["CoreGrids_Custom"].Equals(true)){
          							Response.Write("<li class=\"" + strActive + "\" data-accordion-item><a href=\"/admin/app/" + dtCoreModules.Rows[i]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Code"].ToString() + ".aspx?CoreModules_Ky=" + dtCoreModules.Rows[i]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "\"><i class=\"" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Icon"].ToString() + " fa-fw\"></i>" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_LabelPlural"].ToString() + "</a></li>");
          						}else{
          							Response.Write("<li class=\"" + strActive + "\" data-accordion-item><a href=\"/admin/view.aspx?CoreModules_Ky=" + dtCoreModules.Rows[i]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Ky"].ToString() + "&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString() + "\"><i class=\"" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_Icon"].ToString() + " fa-fw\"></i>" + dtCoreEntitiesMenu.Rows[j]["CoreEntities_LabelPlural"].ToString() + "</a></li>");
          						} 
          					}
          				}
          			Response.Write("</ul>");
          	    Response.Write("</div></div></div>");
          		}
           }
           %>
           </div>
      </div>
    </div>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
