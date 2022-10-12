<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/attivita/attivita-da-fare-stato.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Attivit&agrave; > <%=strH1%></title>
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
        //console.log(jQuery("#" + event.relatedTarget.id).data("attivita"));
        //console.log(jQuery("#" + event.target.id).data("stato"));
        changeStatus(jQuery("#" + event.relatedTarget.id).data("attivita"), jQuery("#" + event.target.id).data("stato"));
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
      });

    function changeStatus(intAttivita_Ky, intAttivitaStati_Ky){
    	$strUrl="/admin/app/attivita/actions/attivita-cambiastato.aspx";
    	console.log($strUrl);
      $data= { ajax:true, Attivita_Ky: intAttivita_Ky, AttivitaStati_Ky: intAttivitaStati_Ky };
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
    .dropzone{height:100%;}
  </style> 
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-calendar-days fa-lg fa-fw"></i>Attivit&agrave; > <%=strH1%></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
          		<div class="stacked-for-small button-group small hide-for-print align-right">
                <a class="button dropdown clear" data-toggle="print-dropdown"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa</a>
                <div class="dropdown-pane" id="print-dropdown" data-dropdown data-auto-focus="true">
            			<a href="/admin/app/attivita/report/rpt-attivita.aspx?Utenti_Ky=<%=dtLogin.Rows[0]["Utenti_Ky"].ToString()%>" target="_blank" class="clear"><i class="fa-duotone fa-print fa-fw"></i>Stampa attivit&agrave; persona</a><br>
            			<a href="/admin/app/attivita/report/rpt-attivita-planning.aspx?sorgente=elenco-attivita" class="clear" target="_blank"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa planning</a> 
                </div>      
          			<a href="/admin/app/attivita/scheda-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreForms_Ky=129&azione=new" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
          		</div>	
  	      </div>
      </div>
  </div>
</div>

<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-3 small-12 cell" id="sidebarfilter" class="sidebar">
          <!--#include file=/admin/app/attivita/elenco-attivita-where.aspx -->
  </div>
  <div class="large-10 medium-9 small-12 cell">
    <ul class="horizontal tabs" data-tabs id="attivita-tabs">
        <li class="tabs-title"><a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=276" aria-selected="true"><i class="fa-duotone fa-calendar fa-fw"></i>Elenco attivit&agrave;</a></li>
      <li class="tabs-title"><a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per scadenza</a></li>
      <li class="tabs-title is-active"><a href="#panel1"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per stato</a></li>
        <li class="tabs-title"><a href="/admin/app/attivita/calendario.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-calendar-days fa-fw"></i>Calendario</a></li>
    </ul>		  
    <div class="tabs-content" data-tabs-content="attivita-tabs" style="background-color:transparent">
      <div class="tabs-panel is-active" id="panel1">
    <%	
        strHtml+="<div class=\"grid-x grid-padding-x\">";
        for (iStati = 0; iStati < dtAttivitaStati.Rows.Count; iStati++){
            strHtml+="<div class=\"auto cell\">";
              strHtml+="<h2 class=\"text-center\" style=\"color:" + dtAttivitaStati.Rows[iStati]["AttivitaStati_Colore"].ToString() + "\"><i class=\"" + dtAttivitaStati.Rows[iStati]["AttivitaStati_Icona"].ToString() + " fa-fw\"></i>" + dtAttivitaStati.Rows[iStati]["AttivitaStati_Titolo"].ToString() + "<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
              strHtml+="<div class=\"dropzone\" id=\"dropzone" + dtAttivitaStati.Rows[iStati]["AttivitaStati_Ky"].ToString() + "\" data-stato=\"" + dtAttivitaStati.Rows[iStati]["AttivitaStati_Ky"].ToString() + "\" style=\"min-height:100%\">";
              strFROMNet = "Attivita_Vw";
              strWHERENet="AttivitaStati_Ky=" + dtAttivitaStati.Rows[iStati]["AttivitaStati_Ky"].ToString();
              if (Request["Utenti_Ky"] != null && Request["Utenti_Ky"] != ""){
                  strWHERENet = strWHERENet + " AND (Utenti_Ky=" + Request["Utenti_Ky"] + ")";
              }else{
                  strWHERENet = strWHERENet + " AND (Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + ")";
  		    }
  
              strORDERNet = "Utenti_Ky, Attivita_Scadenza,Anagrafiche_RagioneSociale ASC";
              dtAttivitaxStato = new System.Data.DataTable("AttivitaxStato");
              dtAttivitaxStato = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attivita_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              for (iAttivita = 0; iAttivita < dtAttivitaxStato.Rows.Count; iAttivita++){
                  strHtml+=renderAttivita(dtAttivitaxStato.Rows[iAttivita],"appenascaduti");
                  intNumeroAttivita++;
              }
              strHtml +="</div>";
            strHtml +="</div>";
        }
        strHtml+="</div>";
        Response.Write(strHtml);
    %>
        </div>
      </div>
  </div>
</div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
    
