<% if (dtCoreGrids.Rows.Count>1 || boolAdmin==true){ %> 
    <% 
      if (boolCambioGrid){ %>
        <a href="#" class="grid-switch-icon secondary" data-toggle="grids-dropdown"><i class="fa-duotone fa-angle-down fa-lg fa-fw" data-fa-transform="down-4"></i></a>
        <div class="dropdown-pane" id="grids-dropdown" data-dropdown data-auto-focus="true">
  		    <ul class="menu vertical">
            <% if (dtCoreGrids.Rows.Count>1){ 
              for (int i = 0; i < dtCoreGrids.Rows.Count; i++){
                if (dtCoreGrids.Rows[i]["CoreGrids_Custom"].Equals(true)){
                  strViewUrl="/admin/app/" + dtCoreGrids.Rows[i]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreGrids.Rows[i]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreGrids_Ky=" + dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString();
                }else{
                  strViewUrl="/admin/view.aspx?CoreGrids_Ky=" + dtCoreGrids.Rows[i]["CoreGrids_Ky"].ToString();
                }
               %>
    		      <li><a href="<%=strViewUrl%>"><i class="<%=dtCoreGrids.Rows[i]["CoreEntities_Icon"].ToString()%> fa-fw"></i><%=dtCoreGrids.Rows[i]["CoreGrids_Title"].ToString()%></a></li>
    	        <% 
              } 
            } 
    		    if (boolAdmin==true){ %>
            <li><a href="/admin/app/sdk/scheda-coregrids.aspx?CoreModules_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString()%>&CoreGrids_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>"><i class="fa-duotone fa-pen-to-square fa-fw"></i>Personalizza griglia</a></li>
    	      <li><a href="/admin/app/sdk/scheda-coregrids.aspx?azione=new&CoreModules_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString()%>&CoreEntities_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString()%>"><i class="fa-duotone fa-square-plus fa-fw"></i>Nuova griglia</a></li>
    				<% } %>
			    </ul>
        </div>
      <%
      }
    %>
<% } %>
<% if (boolAdmin==true){ %>
	<a href="/admin/app/sdk/scheda-coregrids.aspx?CoreModules_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString()%>&CoreGrids_Ky=<%=dtCurrentCoreGrids.Rows[0]["CoreGrids_Ky"].ToString()%>" class="grid-edit-icon secondary" onclick="showGridEditor(this);"><i class="fa-duotone fa-pen-to-square fa-fw" data-fa-transform="down-2"></i></a>
<% } %>

