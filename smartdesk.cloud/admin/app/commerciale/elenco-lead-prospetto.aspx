<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/commerciale/elenco-lead-prospetto.aspx.cs" Inherits="_Default" Debug="true"%>
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
        changeStatus(jQuery("#" + event.relatedTarget.id).data("lead"), jQuery("#" + event.target.id).data("leadstato"));
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

    function changeStatus(intLead_Ky, intLeadStato_Ky){
    	$strUrl="/admin/app/commerciale/actions/lead-cambiastato.aspx";
    	console.log($strUrl);
      $data= { ajax:true, Lead_Ky: intLead_Ky, LeadStato_Ky: intLeadStato_Ky };
    	console.log($data);
    	jQuery.ajax({
    		type: "POST",
    		url: $strUrl,
    		data: $data,
        contentType: "application/json"
    	})
    	.done(function( data ) {
        window.location.reload();
      });	
    
    }
  </script>  
  <style>
    .dropzone{height:100%;}
  </style> 
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-users fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
        		<div class="stacked-for-small button-group small hide-for-print align-right">
        			<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</a>
        			<a href="/admin/app/commerciale/report/rpt-lead-elenco.aspx?sorgente=elenco-lead" class="button clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa elenco</a>
        			<a href="/admin/form.aspx?CoreForms_Ky=200&azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-fw"></i>Aggiungi nuova trattativa</a> 
        		</div>
          </div>
  	</div>
  </div>
</div>

<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
	    <div class="table-scroll">
			<table style="background-color:transparent">
					<tbody style="background-color:transparent">
						<tr>
						<% for (int i = 0; i < dtLeadStato.Rows.Count; i++){ %>
							<td valign="top">
							<div class="board dropzone" id="leadstato<%=dtLeadStato.Rows[i]["LeadStato_Ky"].ToString()%>" style="width:100%;" data-leadstato="<%=dtLeadStato.Rows[i]["LeadStato_Ky"].ToString()%>">
							<h2 class="text-center" style="color:<%=dtLeadStato.Rows[i]["LeadStato_Colore"].ToString()%>"><i class="<%=dtLeadStato.Rows[i]["LeadStato_Icona"].ToString()%> fa-fw"></i><%=dtLeadStato.Rows[i]["LeadStato_Titolo"].ToString()%>
								<%
									Response.Write("<small>Ultime 20</small>");
								%>
								<i class="fa-duotone fa-arrow-right fa-fw"></i>
							</h2> 
							<div class="progress" role="progressbar" tabindex="0" aria-valuenow="<%=dtLeadStato.Rows[i]["LeadStato_Probabilita"].ToString()%>" aria-valuemin="0" aria-valuetext="<%=dtLeadStato.Rows[i]["LeadStato_Probabilita"].ToString()%> percent" aria-valuemax="100">
							  <div class="progress-meter" style="width: <%=dtLeadStato.Rows[i]["LeadStato_Probabilita"].ToString()%>%"></div>
							</div>							
			        <%
							if (dtLeadStato.Rows[i]["LeadStato_Chiusa"].Equals(true)){
              					intRecxPag=5;
							}else{
              					intRecxPag=20;
							}
              switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
                case 2:
            			strWHERENet = "LeadStato_Ky=" + dtLeadStato.Rows[i]["LeadStato_Ky"].ToString() + " AND UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
                  break;
                case 3:
                  strWHERENet = "LeadStato_Ky=" + dtLeadStato.Rows[i]["LeadStato_Ky"].ToString() + " AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
                  break;
              }
							strFROMNet = "Lead_Vw";
							strORDERNet = "Lead_Ky DESC";
							dtLead = Smartdesk.Sql.getTablePage(strFROMNet, null, "Lead_Ky", strWHERENet, strORDERNet, 1,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							for (int j = 0; j < dtLead.Rows.Count; j++){ %>
								<div class="card drag-drop" id="lead<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>" data-lead="<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>" style="border-left:2px solid <%=dtLeadStato.Rows[i]["LeadStato_Colore"].ToString()%>">
									<div class="card-divider align-middle" style="min-height:110px;">
										<div class="grid-x grid-padding-x">
												<div class="large-10 medium-10 small-10 cell">
													<a href="/admin/form.aspx?CoreForms_Ky=200&Lead_Ky=<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>">
													<%=dtLead.Rows[j]["Lead_Titolo"].ToString()%> - 
													<% if (dtLead.Rows[j]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
													<img src="https://www.google.com/s2/favicons?domain=<%=dtLead.Rows[j]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
													<% }else{ %>
													<i class="fa-duotone fa-users fa-fw"></i>
													<% } %>  
													<%=dtLead.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%></a>
												</div>
												<div class="large-2 medium-2 small-2 cell">
													<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=3&AttivitaSettore_Ky=2&Lead_Ky=<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtLead.Rows[j]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-lead" data-tooltip title="pianifica telefonata"><i class="fa-duotone fa-phone fa-fw"></i></a>
													<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=6&AttivitaSettore_Ky=2&Lead_Ky=<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtLead.Rows[j]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-lead" data-tooltip title="pianifica email"><i class="fa-duotone fa-envelope fa-fw"></i></a>
													<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new&AttivitaTipo_Ky=1&AttivitaSettore_Ky=2&Lead_Ky=<%=dtLead.Rows[j]["Lead_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtLead.Rows[j]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-lead" data-tooltip title="pianifica attivit&agrave;"><i class="fa-duotone fa-gear fa-fw"></i></a>
		                						</div>
		                				</div>
								    </div>
									<div class="card-section">
										<i class="fa-duotone fa-user fa-fw" style="color:<%=dtLead.Rows[j]["Utenti_Colore"].ToString()%>"></i><%=dtLead.Rows[j]["Utenti_Nome"].ToString()%> <%=dtLead.Rows[j]["Utenti_Cognome"].ToString()%> - 
										<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtLead.Rows[j]["Lead_Data_IT"].ToString()%><br>
									  <i class="<%=dtLead.Rows[j]["LeadSorgenti_Icona"].ToString()%> fa-fw"></i><%=dtLead.Rows[j]["LeadSorgenti_Titolo"].ToString()%>
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
