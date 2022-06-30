<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/elenco-opportunita-prospetto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script src="https://cdn.jsdelivr.net/npm/interactjs/dist/interact.min.js"></script>
  <script>
    function dragMoveListener (event) {
      var target = event.target
      // keep the dragged position in the data-x/data-y attributes
      var x = (parseFloat(target.getAttribute('data-x')) || 0) + event.dx
      var y = (parseFloat(target.getAttribute('data-y')) || 0) + event.dy
    
      // translate the element
      target.style.transform = 'translate(' + x + 'px, ' + y + 'px)'
    
      // update the posiion attributes
      target.setAttribute('data-x', x)
      target.setAttribute('data-y', y)
    }
    
    // this function is used later in the resizing and gesture demos
    window.dragMoveListener = dragMoveListener

    interact('.dropzone').dropzone({
      accept: '.drag-drop',
      overlap: 0.75,
      ondrop: function (event) {
        console.log(event.relatedTarget.id);
        console.log(event.target.id);
        changeStatus(jQuery("#" + event.relatedTarget.id).data("opportunita"), jQuery("#" + event.target.id).data("opportunitastati"));
      }
    });
    
    interact('.drag-drop')
      .draggable({
        inertia: false,
        modifiers: [
          interact.modifiers.restrictRect({
            endOnly: false
          })
        ],
        autoScroll: true,
        // dragMoveListener from the dragging demo above
        listeners: { move: dragMoveListener }
      })

    function changeStatus(intOpportunita_Ky, intOpportunitaStati_Ky){
    	$strUrl="/admin/app/commerciale/actions/opportunita-aggiornastato.aspx";
    	console.log($strUrl);
      $data= { ajax:true, Opportunita_Ky: intOpportunita_Ky, OpportunitaStati_Ky: intOpportunitaStati_Ky };
    	console.log($data);
    	jQuery.ajax({
    		type: "POST",
    		url: $strUrl,
    		data: $data
    	})
    	.done(function( data ) {
        window.location.reload();
      });	
    
    }
  </script>  
  <style>
    .dropzone{height:100%;min-height:600px;}
  </style> 
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
  	<div class="grid-x grid-padding-x align-middle">
  			<div class="large-4 medium-4 small-12 cell align-middle">
  				<h1><i class="fa-duotone fa-euro-sign fa-fw"></i><%=strH1%></h1>
  			</div>
  			<div class="large-8 medium-8 small-12 cell float-right align-middle">
  				<div class="stacked-for-small button-group small hide-for-print align-right">
  					<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</a>
  					<a href="/admin/app/commerciale/report/rpt-opportunita-elenco.aspx?sorgente=elenco-opportunita" class="button clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa elenco</a>
  					<a href="/admin/app/commerciale/scheda-opportunita.aspx?azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-fw"></i>Aggiungi nuova trattativa</a> 
  				</div>
  			</div>
  </div>
  </div>
</div>

<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
	    <div class="table-scroll">
				<asp:Label ID="PaginaSotto" runat="server" class="paginazione align-middle"></asp:Label>
				<table style="background-color:transparent">
					<tbody style="background-color:transparent">
						<tr>
						<% for (int i = 0; i < dtOpportunitaStati.Rows.Count; i++){ %>
							<td valign="top">
							<div class="board dropzone" id="opportunitastati<%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Ky"].ToString()%>" data-opportunitastati="<%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Ky"].ToString()%>" style="width:300px;">
							<h2 class="text-center" style="color:<%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Colore"].ToString()%>"><i class="<%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Icona"].ToString()%> fa-fw"></i><%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Titolo"].ToString()%>
								<%
								if (dtOpportunitaStati.Rows[i]["OpportunitaStati_Chiusa"].Equals(true)){
	              	Response.Write("<small>Ultime 5</small>");
	              }
								%>
								<i class="fa-duotone fa-arrow-right fa-fw"></i>
							</h2> 
							<div class="progress" role="progressbar" tabindex="0" aria-valuenow="<%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Probabilita"].ToString()%>" aria-valuemin="0" aria-valuetext="<%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Probabilita"].ToString()%> percent" aria-valuemax="100">
							  <div class="progress-meter" style="width: <%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Probabilita"].ToString()%>%"></div>
							</div>							
			        <%
							if (dtOpportunitaStati.Rows[i]["OpportunitaStati_Chiusa"].Equals(true)){
              	intRecxPag=5;
							}else{
              	intRecxPag=100;
							}
              switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
                case 2:
            			strWHERENet = "OpportunitaStati_Ky=" + dtOpportunitaStati.Rows[i]["OpportunitaStati_Ky"].ToString() + " AND UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
                  break;
                case 3:
                  strWHERENet = "OpportunitaStati_Ky=" + dtOpportunitaStati.Rows[i]["OpportunitaStati_Ky"].ToString() + " AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
                  break;
              }
			        strFROMNet = "Opportunita_Vw";
			        strORDERNet = "Opportunita_Ky DESC";
			        dtOpportunita = Smartdesk.Sql.getTablePage(strFROMNet, null, "Opportunita_Ky", strWHERENet, strORDERNet, 1,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							for (int j = 0; j < dtOpportunita.Rows.Count; j++){ %>
								<div class="card drag-drop" id="opportunita<%=dtOpportunita.Rows[j]["Opportunita_Ky"].ToString()%>" data-opportunita="<%=dtOpportunita.Rows[j]["Opportunita_Ky"].ToString()%>" style="border-left:2px solid <%=dtOpportunitaStati.Rows[i]["OpportunitaStati_Colore"].ToString()%>">
									<div class="card-divider align-middle" style="min-height:110px;">
										<div class="grid-x grid-padding-x">
												<div class="large-10 medium-10 small-10 cell">
													<a href="/admin/app/commerciale/scheda-opportunita.aspx?Opportunita_Ky=<%=dtOpportunita.Rows[j]["Opportunita_Ky"].ToString()%>">
													<%=dtOpportunita.Rows[j]["Opportunita_Titolo"].ToString()%> - 
			                    <% if (dtOpportunita.Rows[j]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
			                    <img src="https://www.google.com/s2/favicons?domain=<%=dtOpportunita.Rows[j]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
			                    <% }else{ %>
			                    <i class="fa-duotone fa-users fa-fw"></i>
			                    <% } %>  
			                    <%=dtOpportunita.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%></a>
		                		</div>
												<div class="large-2 medium-2 small-2 cell">
													<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=3&AttivitaSettore_Ky=2&Opportunita_Ky=<%=dtOpportunita.Rows[j]["Opportunita_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtOpportunita.Rows[j]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-opportunita" data-tooltip title="pianifica telefonata"><i class="fa-duotone fa-phone fa-fw"></i></a>
													<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=6&AttivitaSettore_Ky=2&Opportunita_Ky=<%=dtOpportunita.Rows[j]["Opportunita_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtOpportunita.Rows[j]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-opportunita" data-tooltip title="pianifica email"><i class="fa-duotone fa-envelope fa-fw"></i></a>
													<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=1&AttivitaSettore_Ky=2&Opportunita_Ky=<%=dtOpportunita.Rows[j]["Opportunita_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtOpportunita.Rows[j]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-opportunita" data-tooltip title="pianifica attivit&agrave;"><i class="fa-duotone fa-gear fa-fw"></i></a>
		                		</div>
		                </div>
								  </div>
									<div class="card-section">
										<i class="fa-duotone fa-user fa-fw" style="color:<%=dtOpportunita.Rows[j]["Utenti_Colore"].ToString()%>"></i><%=dtOpportunita.Rows[j]["Utenti_Nome"].ToString()%> <%=dtOpportunita.Rows[j]["Utenti_Cognome"].ToString()%> - 
										<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtOpportunita.Rows[j]["Opportunita_Data_IT"].ToString()%><br>
									  <i class="<%=dtOpportunita.Rows[j]["OpportunitaSorgenti_Icona"].ToString()%> fa-fw"></i><%=dtOpportunita.Rows[j]["OpportunitaSorgenti_Titolo"].ToString()%>
									</div>
								</div>
							<% 
								}
							 %>
							 </div>
					    </td>
						<% } %>
					</tr>
					</tbody>
			</table>
			</div>

  	</div>
 </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
