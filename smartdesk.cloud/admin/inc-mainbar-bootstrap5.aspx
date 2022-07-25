<%
System.Data.DataTable dtLogin=Smartdesk.Data.Read("Utenti_Vw", "Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
%>
<div id="header-bar">
	<div class="title-bar show-for-small-only" data-responsive-toggle="main-menu" data-hide-for="medium">
		<button class="menu-icon" type="button" data-toggle="main-menu"></button>
		<div class="title-bar-title">
			<a href="/admin/<%=dtLogin.Rows[0]["UtentiGruppi_Home"].ToString()%>" title="home" class="home name"><i class="fa-duotone fa-home fa-fw"></i></a>
    </div>
		<ul class="menu horizontal small-horizontal align-middle" style="max-width:180px;margin-left:10px;">
			<li>
			<form action="/admin/app/search/elenco-search.aspx">
				<div class="input-group">
					<input class="input-group-field" name="cercatxt" id="cercatxt" size="28" placeholder="cerca">
					<div class="input-group-button">
						<button value="cerca" name="cerca" class="button secondary tiny"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
					</div>
				</div>
				</form>
			</li>
		</ul>
  </div>
	<div class="grid-x grid-padding-x align-middle" id="header-bar-desktop">
				<div class="shrink cell hide-for-small-only hide-for-medium-only align-middle" style="padding-right:0;">
				  <ul class="menu vertical medium-horizontal align-middle" data-responsive-menu="drilldown medium-dropdown">
						<li class="hide">
							<a href="#" title="sidebar" class="home name"><i class="fa-solid fa-bars fa-fw"></i></a>
						</li>
						<li>
							<a href="/admin/<%=dtLogin.Rows[0]["UtentiGruppi_Home"].ToString()%>" title="home" class="home name"><i class="fa-duotone fa-home fa-lg fa-fw"></i></a>
						</li>
					</ul>
				</div>
				<div class="auto cell text-left" style="padding-left:0;">		
					<div class="top-bar" id="main-menu">
    				<div class="top-bar-left">
					    <% if (dtLogin.Rows[0]["CoreMenus_Ky"].ToString().Length>0){ %>
                  <!--#include file=/admin/inc-menu-core.aspx --> 
              <% }else{ %>
                  <!--#include file=/admin/inc-menu.aspx --> 
              <% } %>
						</div>						    
						<% if (dtLogin.Rows[0]["UtentiGruppi_Anagrafiche"].Equals(true)){ %>
							<div class="top-bar-right hide-for-small-only">
											<form action="/admin/app/search/elenco-search.aspx">
											<div class="input-group">
												<input class="input-group-field" name="cercatxt" id="cercatxt" size="28" placeholder="cerca">
												<div class="input-group-button">
													<button value="cerca" name="cerca" class="button secondary tiny"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
												</div>
											</div>
											</form>
							</div>						    
						<% } %>
					</div>
				</div>
        <div class="shrink cell hide-for-small-only">
          <ul class="menu vertical medium-horizontal hide-for-print" data-responsive-menu="drilldown medium-dropdown" style="z-index:999999">
            <li class="has-submenu">
              <% if (dtLogin.Rows[0]["Utenti_Logo"].ToString().Length>0){ %>
                <a href="/admin/<%=dtLogin.Rows[0]["UtentiGruppi_Home"].ToString()%>" class="user-image" title="<%=dtLogin.Rows[0]["Utenti_Email"].ToString()%>">
                <img src="<%=dtLogin.Rows[0]["Utenti_Logo"].ToString()%>" width="30" height="30" alt="<%=dtLogin.Rows[0]["Utenti_Email"].ToString()%>" title="<%=dtLogin.Rows[0]["Utenti_Email"].ToString()%>" style="width:30px;height:30px;border-radius:50%;">
                </a>
              <% }else{ %>
                <a href="/admin/<%=dtLogin.Rows[0]["UtentiGruppi_Home"].ToString()%>" title="<%=dtLogin.Rows[0]["Utenti_Email"].ToString()%>" class="icon">
                <i class="fa-duotone fa-user fa-xl fa-fw" title="<%=dtLogin.Rows[0]["Utenti_Email"].ToString()%>"></i></a>
                </a>
              <% } %>
              <ul class="submenu menu vertical" data-submenu>  
                <li><a href="#"><i class="fa-duotone fa-user fa-fw"></i><%=dtLogin.Rows[0]["Utenti_Nominativo"].ToString()%></a></li>
                <%if (dtLogin.Rows[0]["Utenti_Admin"].Equals(true)){%>
                  <li><a href="/admin/form.aspx?CoreModules_Ky=12&CoreEntities_Ky=17&CoreGrids_Ky=16&CoreForms_Ky=101&custom=0&azione=edit&sorgente=elenco-utenti&Utenti_Ky=<%=Smartdesk.Session.CurrentUser.ToString()%>"><i class="fa-duotone fa-user fa-fw"></i>Profilo</a></li>
                  <li><a href="/admin/settings.aspx"><i class="fa-duotone fa-gear fa-fw"></i>Impostazioni</a></li>
                <%}%>
                <li><a href="/admin/logout.aspx" target="_parent"><i class="fa-duotone fa-power-off fa-fw"></i>Esci</a></li>
              </ul>
            </li>
          </ul>
      
        </div>
        
        
        
		</div>
</div>
