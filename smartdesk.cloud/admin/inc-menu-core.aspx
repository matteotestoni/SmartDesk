<ul class="menu vertical medium-horizontal hide-for-print align-middle" data-responsive-menu="drilldown medium-dropdown">
  <% if (dtLogin.Rows[0]["UtentiGruppi_Calendario"].Equals(true)){ %>
    <li class="has-submenu"><a href="/admin/app/attivita/calendario.aspx" title="Calendario"><i class="fa-duotone fa-calendar-days fa-xl fa-fw"></i></a></li>
  <% } %>
  <%
      System.Data.DataTable dtCoreMenusMenu; 
      dtCoreMenusMenu = Smartdesk.Sql.getTablePage("CoreMenusMenu_Vw", null, "CoreMenusMenu_Ky", "(CoreMenusMenu_Parent Is Null OR CoreMenusMenu_Parent = '' ) AND CoreMenus_Ky=" + dtLogin.Rows[0]["CoreMenus_Ky"].ToString(), "CoreMenusMenu_Order", 1, 200,Smartdesk.Config.Sql.ConnectionReadOnly,out this.intNumRecords);
      string strViewUrlMenu="";
      for (int iCoreMenusMenu = 0; iCoreMenusMenu < dtCoreMenusMenu.Rows.Count; iCoreMenusMenu++){
        switch (dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreMenusMenuType_Ky"].ToString()){
          case "1":
            if (dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreGrids_Custom"].Equals(true)){
              strViewUrlMenu="/admin/app/" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreGrids_Ky=" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreGrids_Ky"].ToString();
            }else{
              strViewUrlMenu="/admin/view.aspx?CoreGrids_Ky=" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreGrids_Ky"].ToString();
            }
            break;
          case "2":
            strViewUrlMenu="/admin/forms.aspx?CoreForms_Ky=" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreForms_Ky"].ToString();
            break;
          case "3":
            strViewUrlMenu="/admin/" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreMenusMenu_Url"].ToString();
            break;
          default:
            break;
        }
        Response.Write("<li class=\"has-submenu " + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreGrids_Custom"].ToString()  + "\">");  
        Response.Write("<a href=\"" + strViewUrlMenu + "\" title=\"" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreMenusMenu_Title"].ToString() + "\"><i class=\"" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreMenusMenu_Icon"].ToString() + " fa-fw fa-lg\"></i>" + dtCoreMenusMenu.Rows[iCoreMenusMenu]["CoreMenusMenu_Title"].ToString() + "</a>");  
        Response.Write("</li>");  
        }
    	%>
</ul>
