<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/attivita/attivita-da-fare.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Attivit&agrave; > Attivit&agrave; da fare per scadenza</title>
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
        alert(event.relatedTarget.id
              + ' was dropped into '
              + event.target.id);

        strUrl="admin/app/attivita/actions/attivita-cambiastato.aspx?Attivita_Ky=29625&AttivitaStati_Ky=1&sorgente=prospetto";              
        window.location.reload();
        //event.relatedTarget.textContent = 'Dropped'
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
          			<a href="/admin/app/calendario/calendario.aspx" class="tiny button clear"><i class="fa-duotone fa-calendar-days fa-fw"></i>Vai al calendario</a>
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
      <ul class="tabs" data-tabs id="attivita-tabs">
        <li class="tabs-title"><a href="/admin/app/attivita/elenco-attivita.aspx?CoreModules_Ky=6&CoreEntities_Ky=79&CoreGrids_Ky=62" aria-selected="true"><i class="fa-duotone fa-calendar fa-fw"></i>Elenco attivit&agrave;</a></li>
        <li class="tabs-title is-active"><a href="#panel1"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per scadenza</a></li>
        <li class="tabs-title"><a href="/admin/app/attivita/attivita-da-fare-stato.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1"><i class="fa-duotone fa-square-kanban fa-fw"></i>Prospetto per stato</a></li>
      </ul>		  
      <div class="tabs-content" data-tabs-content="attivita-tabs" style="background-color:transparent">
        <div class="tabs-panel is-active" id="panel1">
    <%	
        if (intNumeroColonne>0){
            intNumeroColonneResponsive=12/intNumeroColonne;
        }else{
            intNumeroColonneResponsive=12;
        }
        for (int j = 0; j < dtUtenti.Rows.Count; j++){
            strHtml+="<div><div class=\"grid-x grid-padding-x\"><div class=\"small-12 medium-12 large-12 cell align-middle\"><img src=\"" + dtUtenti.Rows[i]["Utenti_Logo"].ToString() + "\" width=\"40\" height=\"40\" align=\"left\" class=\"align-middle\" style=\"border-radius:50%\"><h2>" + dtUtenti.Rows[j]["Utenti_Nominativo"].ToString() + "</h2></div></div></div>";

            strHtml+="<div class=\"grid-x grid-padding-x\">";
            strHtml+="<div class=\"auto cell\">";
            strHtml+="<h2 class=\"text-center\" style=\"color:#ff7a59\">Scaduti da oltre 30gg (" + dtDaFareScaduti.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
            strHtml+="<div class=\"appenascaduti dropzone\" id=\"appenascaduti\">";
            intNumeroAttivita=0;
            strHtmlCorpo="";
            for (i = 0; i < dtDaFareScaduti.Rows.Count; i++){
                if (dtDaFareScaduti.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
                    strHtml+=renderAttivita(dtDaFareScaduti.Rows[i],"scaduti");
                    intNumeroAttivita++;
                }
            }
            strHtml+=strHtmlCorpo;
            strHtml+="</div>";
            strHtml+="</div>";

            strHtml+="<div class=\"auto cell\">";
            strHtml+="<h2 class=\"text-center\" style=\"color:#FFA726\">Scaduti da meno di 30gg (" + dtDaFareAppenaScaduti.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
            strHtml+="<div class=\"scaduti dropzone\">";
            intNumeroAttivita=0;
            strHtmlCorpo="";
            for (i = 0; i < dtDaFareAppenaScaduti.Rows.Count; i++){
                if (dtDaFareAppenaScaduti.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
                    strHtml+=renderAttivita(dtDaFareAppenaScaduti.Rows[i],"appenascaduti");
                    intNumeroAttivita++;
                }
            }
            if (intNumeroAttivita==0){
                strHtmlCorpo+="<div>Nessuna attivit&agrave;</div>";
            }
            strHtml+=strHtmlCorpo;
            strHtml+="</div>";
            strHtml+="</div>";

            strHtml+="<div class=\"auto cell\">";
            strHtml+="<h2 class=\"text-center\" style=\"color:#43ac6a\">Prossime scadenze (" + dtDaFareProssimi.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
            strHtml+="<div class=\"prossimi dropzone\">";
            intNumeroAttivita=0;
            strHtmlCorpo="";
            for (i = 0; i < dtDaFareProssimi.Rows.Count; i++){
                if (dtDaFareProssimi.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
                    strHtml+=renderAttivita(dtDaFareProssimi.Rows[i],"prossimi");
                    intNumeroAttivita++;
                }
            }
            if (intNumeroAttivita==0){
                strHtmlCorpo+="<div>Nessuna attivit&agrave;</div>";
            }
            strHtml+=strHtmlCorpo;
            strHtml+="</div>";
            strHtml+="</div>";

            strHtml+="<div class=\"auto cell\">";
            strHtml+="<h2 class=\"text-center\" style=\"color:#000000\">Scadenze future (" + dtDaFareFuturi.Rows.Count + ")<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></h2>";
            strHtml+="<div class=\"futuri dropzone\">";
            intNumeroAttivita=0;
            strHtmlCorpo="";
            for (i = 0; i < dtDaFareFuturi.Rows.Count; i++){
                if (dtDaFareFuturi.Rows[i]["Utenti_Ky"].ToString()==dtUtenti.Rows[j]["Utenti_Ky"].ToString()){
                    strHtml+=renderAttivita(dtDaFareFuturi.Rows[i],"prossimi");
                    intNumeroAttivita++;
                }
            }
            if (intNumeroAttivita==0){
                strHtmlCorpo+="<div>Nessuna attivit&agrave;</div>";
            }
            strHtml+=strHtmlCorpo;
            strHtml+="</div>";
            strHtml+="</div>";
            strHtml+="</div>";
        }
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
    
