<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/automotive/elenco-preventiviauto-prospetto.aspx.cs" Inherits="_Default" Debug="true"%>
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
        changeStatus(jQuery("#" + event.relatedTarget.id).data("opportunita"), jQuery("#" + event.target.id).data("PreventiviAutoStati"));
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

    function changeStatus(intPreventiviAuto_Ky, intPreventiviAutoStati_Ky){
    	$strUrl="/admin/app/commerciale/actions/opportunita-aggiornastato.aspx";
    	console.log($strUrl);
      $data= { ajax:true, PreventiviAuto_Ky: intPreventiviAuto_Ky, PreventiviAutoStati_Ky: intPreventiviAutoStati_Ky };
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
						<% for (int i = 0; i < dtPreventiviAutoStati.Rows.Count; i++){ %>
							<td valign="top">
							<div class="board dropzone" id="PreventiviAutoStati<%=dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Ky"].ToString()%>" data-PreventiviAutoStati="<%=dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Ky"].ToString()%>" style="width:100%;">
							<h2 class="text-center" style="color:<%=dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Colore"].ToString()%>"><i class="<%=dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Icona"].ToString()%> fa-fw"></i><%=dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Titolo"].ToString()%>
								<i class="fa-duotone fa-arrow-right fa-fw"></i>
							</h2> 
			        <%
							if (dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Ky"].ToString()=="2"){
              	intRecxPag=5;
							}else{
              	intRecxPag=100;
							}
              switch (Convert.ToInt32(dtLogin.Rows[0]["UtentiGruppi_CommercialeQuali"].ToString())){
                case 2:
            			strWHERENet = "PreventiviAutoStati_Ky=" + dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Ky"].ToString() + " AND UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
                  break;
                case 3:
                  strWHERENet = "PreventiviAutoStati_Ky=" + dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Ky"].ToString() + " AND Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
                  break;
              }
			        strFROMNet = "PreventiviAuto_Vw";
			        strORDERNet = "PreventiviAuto_Ky DESC";
			        dtPreventiviAuto = Smartdesk.Sql.getTablePage(strFROMNet, null, "PreventiviAuto_Ky", strWHERENet, strORDERNet, 1,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
							for (int j = 0; j < dtPreventiviAuto.Rows.Count; j++){ %>
								<div class="card drag-drop" id="opportunita<%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Ky"].ToString()%>" data-opportunita="<%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Ky"].ToString()%>" style="border-left:2px solid <%=dtPreventiviAutoStati.Rows[i]["PreventiviAutoStati_Colore"].ToString()%>">
									<div class="card-divider align-middle" style="min-height:50px;">
										<div class="grid-x grid-padding-x">
												<div class="large-12 medium-12 small-12 cell">
													<a href="/admin/app/automotive/scheda-PreventiviAuto.aspx?custom=1&CoreForms_Ky=196&PreventiviAuto_Ky=<%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Ky"].ToString()%>">
			                    <i class="fa-duotone fa-users fa-fw"></i><%=dtPreventiviAuto.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%></a><br>
			                    <i class="fa-duotone fa-car fa-fw"></i><%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Marca"].ToString()%> <%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Modello"].ToString()%>
		                		</div>
		                </div>
								  </div>
									<div class="card-section">
										<i class="fa-duotone fa-user fa-fw" style="color:<%=dtPreventiviAuto.Rows[j]["Utenti_Colore"].ToString()%>"></i><%=dtPreventiviAuto.Rows[j]["Utenti_Nome"].ToString()%> <%=dtPreventiviAuto.Rows[j]["Utenti_Cognome"].ToString()%> - <i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtPreventiviAuto.Rows[j]["PreventiviAuto_Data"].ToString()%><br>
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
