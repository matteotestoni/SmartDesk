<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/view.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Attivit&agrave; > Elenco trasferte</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            	<h1><i class="fa-duotone fa-car fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<button class="button secondary" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</button>
        				<a href="/admin/app/attivita/scheda-trasferta.aspx?azione=new&tipo=trasferta" class="tiny button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        			</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
      <!--#include file=/admin/app/attivita/where/where-attivita-trasferte.inc --> 
		    <div class="divgrid">
          <div class="grid-x grid-padding-x">
            <div class="large-9 medium-9 small-12 cell">
        			<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
            </div>
            <div class="large-3 medium-3 small-4 cell end">
              <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
              <div class="input-group">
                <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                  <option value="">Azioni di gruppo</option>
                  <option value="delete" data-action="/admin/app/attivita/crud/elimina-attivita.aspx">Elimina</option>
                </select>
                <div class="input-group-button">
                  <input type="hidden" name="grid" value="elencoattivitatrasferte">
                  <input type="hidden" id="sorgente" name="sorgente" value="elenco-attivita-trasferte">
                  <input type="hidden" id="azione" name="azione" value="">
                  <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                  <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                  <input type="submit" id="doaction" class="button secondary" value="Applica">
                </div>
              </div>
              </form>
            </div>
          </div>
				<%
        int intUtenti_Ky=0;
        decimal decTotMeseOre=0; 
        decimal decTotMeseKm=0; 
        decimal decTotMeseSpeseKm=0; 
        decimal decTotMeseParcheggi=0; 
        decimal decTotMesePasti=0; 
        decimal decTotMeseAutostrada=0; 
        decimal decTotMeseMezziPubblici=0; 	
    	  decimal decTotMeseSpese=0; 
        decimal decTotMeseNumero=0; 
        decimal decTotTrasferteOre=0; 
        decimal decTotTrasferteKm=0; 
        decimal decTotTrasferteSpeseKm=0; 
        decimal decTotTrasferteSpeseParcheggi=0; 
        decimal decTotTrasferteSpesePasti=0; 
        decimal decTotTrasferteSpeseAutostrada=0; 
        decimal decTotTrasferteSpeseMezziPubblici=0; 
        decimal decTotTrasferteSpese=0; 
        string strAnno = "";
        string strMese = "";
        int intYear=DateTime.Now.Year;
        int intMonth=DateTime.Now.Month;
        
        for (int i = 0; i < dtGridData.Rows.Count; i++){

            if (intUtenti_Ky!=Convert.ToInt32(dtGridData.Rows[i]["Utenti_Ky"])){
            	if (i>0){
						%>
    					</tbody>
							<tfoot>
				        <tr class="totale">
			        		<th bgcolor="#ffffff"></th>
			        		<th bgcolor="#ffffff"></th>
			        		<th bgcolor="#ffffff"></th>
				          <th class="large-text-right small-text-left" colspan="2">Tot Trasferte:</th>
				          <th class="large-text-right small-text-left">Km <strong><%=decTotTrasferteKm.ToString("N0", ci)%></strong><br>&euro; <strong><%=decTotTrasferteSpeseKm.ToString("N2", ci)%></strong></th>
				          <th class="large-text-right small-text-left">
										<i class="fa-duotone fa-square-parking fa-fw" style="--fa-primary-color: #ffffff;--fa-secondary-color: #0000c6;--fa-secondary-opacity:1"></i>&euro; <strong><%=decTotTrasferteSpeseParcheggi.ToString("N2", ci)%></strong><br>
										<i class="fa-duotone fa-subway fa-fw"></i> &euro; <strong><%=decTotTrasferteSpeseMezziPubblici.ToString("N2", ci)%></strong>
									</th>
				          <th class="large-text-right small-text-left">
										<i class="fa-duotone fa-road fa-fw" style="--fa-primary-color: #008001;--fa-secondary-color: #ffffff;--fa-secondary-opacity:1"></i> &euro; <strong><%=decTotTrasferteSpeseAutostrada.ToString("N2", ci)%></strong><br>
				          	<i class="fa-duotone fa-fork-knife fa-fw"></i> &euro; <strong><%=decTotTrasferteSpesePasti.ToString("N2", ci)%></strong>
									</th>
				          <th class="large-text-right small-text-left"><span class="label success">&euro; <%=decTotTrasferteSpese.ToString("N2", ci)%></span></th>
				          <th bgcolor="#ffffff" colspan="2"></th>
				        </tr>
							</tfoot>
							</table>
						<%
	            decTotTrasferteOre=0;
	            decTotTrasferteKm=0;
	            decTotTrasferteSpese=0;
							decTotMeseOre=0;
							decTotMeseKm=0;
							decTotMeseSpese=0;
							decTotMeseNumero=0;

						} %>
							
							<div class="titolotabella">
									<div class="grid-x grid-padding-x">
									  	<div class="small-8 large-4 cell">
												<img src="<%=dtGridData.Rows[i]["Utenti_Logo"].ToString()%>" width="40" height="40" align="left" style="padding-right:10px;">
												<h2><%=dtGridData.Rows[i]["Utenti_Nominativo"].ToString()%></h2>
											</div>
											<div class="small-4 large-8 cell">
												<a href="/admin/app/attivita/report/rpt-trasferte.aspx?Utenti_Ky=<%=dtGridData.Rows[i]["Utenti_Ky"].ToString()%>&anno=<%=strAnno%>&mese=<%=strMese%>" target="_blank" class="tiny button secondary"><i class="fa-duotone fa-print fa-fw"></i>Stampa</a>
												<a href="/admin/app/attivita/esporta-trasferte.aspx?Utenti_Ky=<%=dtGridData.Rows[i]["Utenti_Ky"].ToString()%>&anno=<%=strAnno%>&mese=<%=strMese%>" target="_blank" class="tiny button secondary"><i class="fa-duotone fa-file-excel fa-fw"></i>Esporta</a>
											</div>
									</div>
							</div>
							<table id="elencoattivitatrasferte" class="grid hover scroll" border="0" width="100%">
				    	<thead>
					      <tr>
	                <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
			          	<th width="40" class="text-left">Cod.</th>
					        <th width="170">Data / Ora</th>
					        <th width="300">Anagrafica<br>Descrizione attivit&agrave;</th>
					        <th width="100">Comune</th>
					        <th width="80">Km</th>
					        <th width="100">Parcheggi<br>Mezzi pubb.</th>
					        <th width="100">Autostrada<br>Pasti</th>
					        <th width="80">Spese TOT</th>
		        			<th width="60">Utente</th>
					        <th width="12" class="nowrap" data-orderable="false"></th>
					      </tr>
				    	</thead>
    					<tbody>
              <%
							decTotMeseOre=0;
							decTotMeseKm=0;
							decTotMeseSpese=0;
							decTotMeseNumero=0;
              decTotTrasferteOre=0;
              decTotTrasferteKm=0;
              decTotTrasferteSpese=0;
          	} %>

			      <%
						if (decTotMeseNumero>0 && dtGridData.Rows[i]["Mese"].ToString()!=null && dtGridData.Rows[i]["Mese"].ToString().Length>0 && intMonth!=Convert.ToInt32(dtGridData.Rows[i]["Mese"].ToString())){
			      %>
			        <tr class="totale">
		        		<th bgcolor="#ffffff"></th>
		        		<th bgcolor="#ffffff"></th>
		        		<th bgcolor="#ffffff"></th>
			          <th class="large-text-right small-text-left" colspan="2">Tot Trasferte : <%=Smartdesk.Functions.GetMese(intMonth.ToString())%>/<%=intYear%></th>
			          <th class="large-text-right small-text-left">Km <strong><%=decTotMeseKm.ToString("N0", ci)%></strong><br>&euro; <strong><%=decTotMeseSpeseKm.ToString("N2", ci)%></strong></th>
			          <th class="large-text-right small-text-left">
									<i class="fa-duotone fa-square-parking fa-fw" style="--fa-primary-color: #ffffff;--fa-secondary-color: #0000c6;--fa-secondary-opacity:1"></i>&euro; <strong><%=decTotMeseParcheggi.ToString("N2", ci)%></strong><br>
									<i class="fa-duotone fa-subway fa-fw"></i> &euro; <strong><%=decTotMeseMezziPubblici.ToString("N2", ci)%></strong>
								</th>
			          <th class="large-text-right small-text-left">
									<i class="fa-duotone fa-road fa-fw" style="--fa-primary-color: #008001;--fa-secondary-color: #ffffff;--fa-secondary-opacity:1"></i> &euro; <strong><%=decTotMeseAutostrada.ToString("N2", ci)%></strong><br>
			          	<i class="fa-duotone fa-fork-knife fa-fw"></i> &euro; <strong><%=decTotMesePasti.ToString("N2", ci)%></strong>
								</th>
			          <th class="large-text-right small-text-left"><span class="label success">&euro; <%=decTotMeseSpese.ToString("N2", ci)%></span></th>
		        		<th bgcolor="#ffffff"></th>
		        		<th bgcolor="#ffffff"></th>
			        </tr>
						<%						
							decTotMeseOre=0;
							decTotMeseKm=0;
							decTotMeseSpeseKm=0;
							decTotMeseParcheggi=0;
							decTotMesePasti=0;
							decTotMeseAutostrada=0;
							decTotMeseMezziPubblici=0;
							decTotMeseSpese=0;
							decTotMeseNumero=0;
						} %>

		        <tr class="riga<%=i%>">
		          <td><input type="checkbox" class="checkrow" id="record<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>" data-value="<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>" /></td>
				      <td class="text-left nowrap"><a href="/admin/app/attivita/scheda-trasferta.aspx?Attivita_Ky=<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>&Utenti_Ky=<%=dtGridData.Rows[i]["Utenti_Ky"].ToString()%>&sorgente=elenco-trasferte"><%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%></td>
		          <td>
								<i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtGridData.Rows[i]["Attivita_Scadenza"].ToString()%>-<%=dtGridData.Rows[i]["Mese"].ToString()%><br>
							</td>
		          <td>
								<div class="width300">
				            <% if (dtGridData.Rows[i]["Anagrafiche_Disdetto"].Equals(true)){ %>
				            <strong>>>DISDETTA<<</strong>
				            <% } %>
										<a href="/admin/goto-form.aspx?CoreEntities_Ky=162&Anagrafiche_Ky=<%=dtGridData.Rows[i]["Anagrafiche_Ky"].ToString()%>">
	                  <% if (dtGridData.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
	                  <img src="https://www.google.com/s2/favicons?domain=<%=dtGridData.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>" width="16" height="16" border="0">
	                  <% }else{ %>
	                  <i class="fa-duotone fa-user fa-fw"></i>
	                  <% } %>  
										<%=dtGridData.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%></a>
								</div>
								<div class="width300">
								<i class="<%=dtGridData.Rows[i]["AttivitaTipo_Icona"].ToString()%> fa-fw "></i>
							 	<% if (dtGridData.Rows[i]["Attivita_Trasferta"].Equals(true)){ %>
									<i class="fa-duotone fa-car fa-fw"></i>
							 	<% } %>
								<%=dtGridData.Rows[i]["Attivita_Descrizione"].ToString()%></div>
							</td>
		          <td class="text-left"><i class="fa-duotone fa-location-dot fa-fw"></i><%=dtGridData.Rows[i]["Comuni_Comune"].ToString()%></strong></td>
		          <td class="large-text-right small-text-left" style="padding-right:2px">
								Km <%=((decimal)dtGridData.Rows[i]["Attivita_Km"]).ToString("N0", ci)%><br>
								<strong>&euro; <%=((decimal)dtGridData.Rows[i]["Attivita_SpeseKm"]).ToString("N2", ci)%></strong>
							</td>
		          <td class="large-text-right small-text-left" style="padding-right:2px">
								<i class="fa-duotone fa-square-parking fa-fw" style="--fa-primary-color: #ffffff;--fa-secondary-color: #0000c6;--fa-secondary-opacity:1"></i>&euro; <%=((decimal)dtGridData.Rows[i]["Attivita_SpeseParcheggi"]).ToString("N2", ci)%><br>
								<i class="fa-duotone fa-subway fa-fw"></i>&euro; <%=((decimal)dtGridData.Rows[i]["Attivita_SpeseMezziPubblici"]).ToString("N2", ci)%>
							</td>
		          <td class="large-text-right small-text-left" style="padding-right:2px">
								<i class="fa-duotone fa-road fa-fw" style="--fa-primary-color: #008001;--fa-secondary-color: #ffffff;--fa-secondary-opacity:1"></i> &euro; <%=((decimal)dtGridData.Rows[i]["Attivita_SpeseAutostrada"]).ToString("N2", ci)%><br>
		          	<i class="fa-duotone fa-fork-knife fa-fw"></i> &euro; <%=((decimal)dtGridData.Rows[i]["Attivita_SpesePasti"]).ToString("N2", ci)%>
							</td>
		          <td class="large-text-right small-text-left" style="padding-right:2px"><strong>&euro; <%=((decimal)dtGridData.Rows[i]["Attivita_SpeseTotali"]).ToString("N2", ci)%></strong></td>
		          <td class="text-center show-for-medium-up"><i class="fa-duotone fa-user-secret fa-fw"></i><%=dtGridData.Rows[i]["Utenti_Iniziali"].ToString()%></td>
		          <td><a href="/admin/app/attivita/crud/elimina-trasferta.aspx?azione=delete&Attivita_Ky=<%=dtGridData.Rows[i]["Attivita_Ky"].ToString()%>&Utenti_Ky=<%=dtGridData.Rows[i]["Utenti_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
		        </tr>
			    <%
			      decTotMeseOre+=convertiDecimale(dtGridData.Rows[i]["Attivita_Ore"].ToString());
			      decTotMeseKm+=convertiDecimale(dtGridData.Rows[i]["Attivita_Km"].ToString());
						decTotMeseSpeseKm+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseKm"].ToString());
						decTotMeseParcheggi+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseParcheggi"].ToString());
						decTotMesePasti+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpesePasti"].ToString());
						decTotMeseAutostrada+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseAutostrada"].ToString());;
						decTotMeseMezziPubblici+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseMezziPubblici"].ToString());
			      decTotMeseSpese+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseTotali"].ToString());
			      decTotMeseNumero+=1;
						if (dtGridData.Rows[i]["Mese"].ToString()!=null && dtGridData.Rows[i]["Mese"].ToString().Length>0){
				      intMonth=Convert.ToInt32(dtGridData.Rows[i]["Mese"].ToString());
				    }
						if (dtGridData.Rows[i]["Anno"].ToString()!=null && dtGridData.Rows[i]["Anno"].ToString().Length>0){
				      intYear=Convert.ToInt32(dtGridData.Rows[i]["Anno"].ToString());
				    }
						decTotTrasferteOre+=convertiDecimale(dtGridData.Rows[i]["Attivita_Ore"].ToString());
						decTotTrasferteKm+=convertiDecimale(dtGridData.Rows[i]["Attivita_Km"].ToString());
						decTotTrasferteSpeseKm+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseKm"].ToString());
						decTotTrasferteSpeseParcheggi+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseParcheggi"].ToString());
						decTotTrasferteSpesePasti+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpesePasti"].ToString());
						decTotTrasferteSpeseAutostrada+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseAutostrada"].ToString());
						decTotTrasferteSpeseMezziPubblici+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseMezziPubblici"].ToString());
						decTotTrasferteSpese+=convertiDecimale(dtGridData.Rows[i]["Attivita_SpeseTotali"].ToString());
			      intUtenti_Ky=Convert.ToInt32(dtGridData.Rows[i]["Utenti_Ky"].ToString());				
					} %>

	        <tr class="totale">
        		<th bgcolor="#ffffff"></th>
        		<th bgcolor="#ffffff"></th>
        		<th bgcolor="#ffffff"></th>
	          <th class="large-text-right small-text-left" colspan="2">Tot Trasferte: <%=Smartdesk.Functions.GetMese(DateTime.Now.Month.ToString())%>/<%=DateTime.Now.Year%></th>
	          <th class="large-text-right small-text-left">Km <strong><%=decTotMeseKm.ToString("N0", ci)%></strong><br>&euro; <strong><%=decTotMeseSpeseKm.ToString("N2", ci)%></strong></th>
	          <th class="large-text-right small-text-left">
							<i class="fa-duotone fa-square-parking fa-fw" style="--fa-primary-color: #ffffff;--fa-secondary-color: #0000c6;--fa-secondary-opacity:1"></i>&euro; <strong><%=decTotMeseParcheggi.ToString("N2", ci)%></strong><br>
							<i class="fa-duotone fa-subway fa-fw"></i> &euro; <strong><%=decTotMeseMezziPubblici.ToString("N2", ci)%></strong>
						</th>
	          <th class="large-text-right small-text-left">
							<i class="fa-duotone fa-road fa-fw" style="--fa-primary-color: #008001;--fa-secondary-color: #ffffff;--fa-secondary-opacity:1"></i> &euro; <strong><%=decTotMeseAutostrada.ToString("N2", ci)%></strong><br>
	          	<i class="fa-duotone fa-fork-knife fa-fw"></i> &euro; <strong><%=decTotMesePasti.ToString("N2", ci)%></strong>
						</th>
	          <th class="large-text-right small-text-left"><span class="label success">&euro; <%=decTotMeseSpese.ToString("N2", ci)%></span></th>
        		<th bgcolor="#ffffff"></th>
        		<th bgcolor="#ffffff"></th>
	        </tr>
				</tbody>
				<tfoot>
	        <tr class="totale">
        		<td bgcolor="#ffffff" colspan="3"></td>
	          <td class="large-text-right small-text-left" colspan="2">Tot Trasferte:</td>
	          <td class="large-text-right small-text-left">Km <strong><%=decTotTrasferteKm.ToString("N0", ci)%></strong><br>&euro; <strong><%=decTotTrasferteSpeseKm.ToString("N2", ci)%></strong></td>
	          <td class="large-text-right small-text-left">
							<i class="fa-duotone fa-square-parking fa-fw" style="--fa-primary-color: #ffffff;--fa-secondary-color: #0000c6;--fa-secondary-opacity:1"></i>&euro; <strong><%=decTotTrasferteSpeseParcheggi.ToString("N2", ci)%></strong><br>
							<i class="fa-duotone fa-subway fa-fw"></i> &euro; <strong><%=decTotTrasferteSpeseMezziPubblici.ToString("N2", ci)%></strong>
						</td>
	          <td class="large-text-right small-text-left">
							<i class="fa-duotone fa-road fa-fw" style="--fa-primary-color: #008001;--fa-secondary-color: #ffffff;--fa-secondary-opacity:1"></i> &euro; <strong><%=decTotTrasferteSpeseAutostrada.ToString("N2", ci)%></strong><br>
	          	<i class="fa-duotone fa-fork-knife fa-fw"></i> &euro; <strong><%=decTotTrasferteSpesePasti.ToString("N2", ci)%></strong>
						</td>
	          <td class="large-text-right small-text-left"><span class="label success">&euro; <%=decTotTrasferteSpese.ToString("N2", ci)%></span></td>
	          <td bgcolor="#ffffff" colspan="2"></td>
	        </tr>
				</tfoot>
    </table>
	</div>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
