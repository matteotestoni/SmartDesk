<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="/area-clienti/app/ped/ped.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html lang="it">
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
  <div class="content-header">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-user fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-user fa-fw"></i><%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
  	      </div>
      </div>
  </div>

    <div class="grid-container" style="max-width:1600px">
         <div class="grid-x grid-padding-x small-up-1 medium-up-3 large-up-5" data-equalizer data-equalize-on="medium" id="ped-eq">
		 <% for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){ %>
            <div class="cell">
              <div class="card" data-equalizer-watch>
                <div class="card-divider">
                  <img src="<%=dtAnagrafiche.Rows[i]["Anagrafiche_Logo"].ToString()%>" height="65" style="height:65px;">
                </div>
                <div class="card-section">
                  <div class="text-center">
                      <i class="fa-brands fa-facebook fa-4x fa-fw" style="color:#4267b2"></i><br><br>
                      <%
                      strWHERENet="Socialchannels_Attivo=1 AND SocialchannelsType_Ky=1 AND Anagrafiche_Ky=" + dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString() + " AND Socialped_DataFine>GETDATE()" ;
                      strFROMNet = "Socialped_Vw";
                      strORDERNet = "Socialchannels_Titolo ASC, Socialped_DataInizio";
                      dtSocialpedFacebook = new System.Data.DataTable("SocialpedFacebook");
                      dtSocialpedFacebook = Smartdesk.Sql.getTablePage(strFROMNet, null, "Socialped_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		              for (int j = 0; j < dtSocialpedFacebook.Rows.Count; j++){ %>
                            <%
							if (intWeekNum==Convert.ToInt32(dtSocialpedFacebook.Rows[j]["settimana"])){
							  strTitolo="Settimana corrente";
							}
							if (intWeekNum<Convert.ToInt32(dtSocialpedFacebook.Rows[j]["settimana"])){
							  strTitolo="Settimana prossima";
							}
							if (intWeekNum>Convert.ToInt32(dtSocialpedFacebook.Rows[j]["settimana"])){
							  strTitolo="Settimana precedente";
							}
							%>
							<h5><%=strTitolo%></h5>
                            dal <%=Convert.ToDateTime(dtSocialpedFacebook.Rows[j]["Socialped_DataInizio"]).ToString("dd/M/yyyy",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>
                            al <%=Convert.ToDateTime(dtSocialpedFacebook.Rows[j]["Socialped_DataFine"]).ToString("dd/M/yyyy",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>
                            
                            <a href="scheda-ped.aspx?Socialped_Ky=<%=dtSocialpedFacebook.Rows[j]["Socialped_Ky"].ToString()%>">
                            <br>
                            </a>
                            <a href="scheda-ped.aspx?Socialped_Ky=<%=dtSocialpedFacebook.Rows[j]["Socialped_Ky"].ToString()%>" style="margin-top:10px" class="button radius">Visualizza <i class="fa-duotone fa-arrow-right fa-fw"></i></a>
                            <hr>
                      <% } %>
                      
                      <%
                      strWHERENet="Socialchannels_Attivo=1 AND SocialchannelsType_Ky=2 AND Anagrafiche_Ky=" + dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString() + " AND Socialped_DataFine>GETDATE()" ;
                      strFROMNet = "Socialped_Vw";
                      strORDERNet = "Socialchannels_Titolo ASC, Socialped_DataInizio";
                      dtSocialpedInstagram = new System.Data.DataTable("SocialpedInstagram");
                      dtSocialpedInstagram = Smartdesk.Sql.getTablePage(strFROMNet, null, "Socialped_Ky", strWHERENet, strORDERNet, 1,100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                      if (dtSocialpedInstagram.Rows.Count>0){
                          Response.Write("<img src=\"assets/instagram.png\"><br>");
    		              for (int j = 0; j < dtSocialpedInstagram.Rows.Count; j++){ %>
	                            <%
								if (intWeekNum==Convert.ToInt32(dtSocialpedInstagram.Rows[j]["settimana"])){
								  strTitolo="Settimana corrente";
								}
								if (intWeekNum<Convert.ToInt32(dtSocialpedInstagram.Rows[j]["settimana"])){
								  strTitolo="Settimana prossima";
								}
								if (intWeekNum>Convert.ToInt32(dtSocialpedInstagram.Rows[j]["settimana"])){
								  strTitolo="Settimana precedente";
								}
								%>
								<h5><%=strTitolo%></h5>
                                dal <%=Convert.ToDateTime(dtSocialpedInstagram.Rows[j]["Socialped_DataInizio"]).ToString("dd/M/yyyy",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>
                                al <%=Convert.ToDateTime(dtSocialpedInstagram.Rows[j]["Socialped_DataFine"]).ToString("dd/M/yyyy",System.Globalization.CultureInfo.InvariantCulture).Replace(".",":")%>
                                <a href="scheda-ped.aspx?Socialped_Ky=<%=dtSocialpedInstagram.Rows[j]["Socialped_Ky"].ToString()%>">
                                <br>
                                </a>
                                <a href="scheda-ped.aspx?Socialped_Ky=<%=dtSocialpedInstagram.Rows[j]["Socialped_Ky"].ToString()%>" style="margin-top:10px" class="button radius">Visualizza <i class="fa-duotone fa-arrow-right fa-fw"></i></a>
                                <hr>
                          <% 
                          } 
                      }
                      %>

                      
                    </div>
                </div>
              </div>          
            </div>
		 <% } %>


          <!--
          <div class="cell">
            <div class="card" data-equalizer-watch>
              <div class="card-divider">
                Piani editoriali Spazio s.p.a.
              </div>
              <div class="card-section">
                <img src="https://cdn.spaziogroup.com/spazio2016/img/loghi/logo-spazio-torino.png" height="65" style="height:65px;">
                <br><br>
                <ul>
                    <li><a href="ped-spazio-fb.aspx"><i class="fa-brands fa-facebook fa-fw"></i>PED Facebook</a></li>
                    <li><a href="ped-spazio-ig.aspx"><i class="fa-brands fa-instagram fa-fw"></i>PED Instagram</a></li>
                </ul>
              </div>
            </div>          
          </div>
          <div class="cell">
            <div class="card" data-equalizer-watch>
              <div class="card-divider">
                Piani editoriali Spazio 3
              </div>
              <div class="card-section">
                <img src="https://peugeot.spaziogroup.com/wp-content/themes/2016-minisito/img/logo-peugeot-spazio.png" height="65" style="height:65px;">
                <br><br>
                <ul>
                    <li><a href="ped-spazio3-fb.aspx"><i class="fa-brands fa-facebook fa-fw"></i>PED Facebook</a></li>
                </ul>
              </div>
            </div>          
          </div>
          <div class="cell">
            <div class="card" data-equalizer-watch>
              <div class="card-divider">
                Piani editoriali Spazio 4
              </div>
              <div class="card-section">
                <img src="https://spazio4to.spaziogroup.com/wp-content/themes/2016-minisito/img/logo-spazio4to-spazio.png" height="65" style="height:65px;">
                <br><br>
                <ul>
                    <li><a href="ped-spazio4-fb.aspx"><i class="fa-brands fa-facebook fa-fw"></i>PED Facebook</a></li>
                    <li><a href="ped-spazio4-ig.aspx"><i class="fa-brands fa-instagram fa-fw"></i>PED Instagram</a></li>
                </ul>
              </div>
            </div>          
          </div>
          <div class="cell">
            <div class="card" data-equalizer-watch>
              <div class="card-divider">
                Piani editoriali Spazio 6
              </div>
              <div class="card-section">
                <img src="https://hyundai.spaziogroup.com/wp-content/themes/2016-minisito/img/logo-hyundai-spazio.png" height="65" style="height:65px;">
                <br><br>
                <ul>
                    <li><a href="ped-spazio6-fb.aspx"><i class="fa-brands fa-facebook fa-fw"></i>PED Facebook</a></li>
                </ul>
              </div>
            </div>          
          </div>
          <div class="cell">
            <div class="card" data-equalizer-watch>
              <div class="card-divider">
               Piani editoriali Spazio 8
              </div>
              <div class="card-section">
                <img src="https://citroen.spaziogroup.com/wp-content/themes/2016-minisito/img/logo-citroen-spazio.png" height="65" style="height:65px;">
                <br><br>
                <ul>
                    <li><a href="ped-spazio8-fb.aspx"><i class="fa-brands fa-facebook fa-fw"></i>PED Facebook</a></li>
                </ul>
              </div>
            </div>          
          </div>
          -->
        </div>
    </div>
</body>
</html>      