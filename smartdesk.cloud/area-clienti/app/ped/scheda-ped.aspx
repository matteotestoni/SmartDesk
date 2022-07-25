<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="/area-clienti/app/ped/scheda-ped.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html lang="it">
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
  <div class="content-header">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-8 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-user fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-user fa-fw"></i><%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%></span></h1>
          </div>
          <div class="large-4 medium-8 small-12 cell right float-right align-middle">
  	      </div>
      </div>
  </div>
    
    <div class="grid-container">
        <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-12 cell">
		        <br><br><br>
                <ul class="menu vertical">         
                <% for (int j = 0; j < dtSocialpedsidebar.Rows.Count; j++){ %>
			              <% 
										if (j==0 || intSettimana!=Convert.ToInt32(dtSocialpedsidebar.Rows[j]["settimana"])){
												if (intWeekNum==Convert.ToInt32(dtSocialpedsidebar.Rows[j]["settimana"])){
												  strTitolo="Settimana corrente";
												}
												if (intWeekNum<Convert.ToInt32(dtSocialpedsidebar.Rows[j]["settimana"])){
												  strTitolo="Settimana prossima";
												}
												if (intWeekNum>Convert.ToInt32(dtSocialpedsidebar.Rows[j]["settimana"])){
												  strTitolo="Settimana precedente";
												}
												Response.Write("<h2><i class=\"fa-duotone fa-calendar-week fa-fw fa-lg\"></i>" + strTitolo + "</h2>");
										} 
			              %>  
                     <li>
                       <a href="scheda-ped.aspx?Socialped_Ky=<%=dtSocialpedsidebar.Rows[j]["Socialped_Ky"].ToString()%>" style="color:#237ff3">
                       <i class="<%=dtSocialpedsidebar.Rows[j]["SocialchannelsType_Icona"].ToString()%> fa-fw fa-lg"></i>
                       <%=dtSocialpedsidebar.Rows[j]["Socialchannels_Titolo"].ToString()%>
                       <small>
				   						 <%=Convert.ToDateTime(dtSocialpedsidebar.Rows[j]["Socialped_DataInizio"]).ToString("dd/M/yyyy",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>-
                       <%=Convert.ToDateTime(dtSocialpedsidebar.Rows[j]["Socialped_DataFine"]).ToString("dd/M/yyyy",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>
                       </small>
                       </a>
                     </li>
                <% 
								intSettimana=Convert.ToInt32(dtSocialpedsidebar.Rows[j]["settimana"]);
								} %>
                </ul>


            </div>

            <div class="large-9 medium-9 small-12 cell">
          	<iframe id="iframepedcorrente" src="<%=dtSocialped.Rows[0]["Socialped_Url"].ToString()%>" frameborder="0" height="520" width="100%">
                  Il tuo Browser non supporta gli iframe.
            </iframe>
            </div>
        </div>
    </div>
<!--#include file=/ped/inc-footer.inc -->
</body>
</html>      