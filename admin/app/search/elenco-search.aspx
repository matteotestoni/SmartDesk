<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/search/elenco-search.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Elenco anagrafiche</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
    <div class="grid-x grid-padding-x align-middle">
        <div class="large-3 medium-5 small-12 cell align-middle">
          	<h1><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i><%=strH1%></h1>
        </div>
        <div class="large-9 medium-7 small-12 cell float-right align-middle">
    			<div class="stacked-for-small button-group small hide-for-print align-right">
    			</div>
	      </div>
    </div>
  </div>
</div>

    <div class="grid-container fluid">
      <div class="grid-x grid-padding-x">
       <div class="large-12 medium-12 small-12 cell">


      <% if (dtAnagrafiche.Rows.Count>0){ 
      
        strWHERENet="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=162)";
        //Response.Write(strWHERENet);
    		strFROMNet = "UsergroupsForms_Vw";
    		strORDERNet = "CoreForms_Default DESC, CoreForms_Ky DESC";
    		dtCoreForms = new System.Data.DataTable("CoreGrids");
    		dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		if (dtCoreForms.Rows.Count>0){
          //Response.Write(dtCoreForms.Rows[0]["CoreForms_Ky"].ToString());
          if (dtCoreForms.Rows[0]["CoreForms_Custom"].Equals(true)){
            strFormUrl="/admin/app/" + dtCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreForms.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString();
          }else{
            strFormUrl="/admin/form.aspx?CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString() + "&custom=0";
          }
        }else{
          strFormUrl="/admin/app/anagrafiche/scheda-anagrafiche.aspx?custom=1&CoreEntities_Ky=162";
        }
      
      %>
        <div class="divgrid">
          <div class="grid-x grid-padding-x">
            <div class="large-9 medium-9 small-12 cell">
              <h2><i class="fa-duotone fa-fw fa-users"></i>Anagrafiche</h2>
            </div>
            <div class="large-3 medium-3 small-12 cell">
              <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
              <div class="input-group">
                <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                  <option value="">Azioni di gruppo</option>
                  <option value="delete" data-action="/admin/app/anagrafiche/crud/elimina-anagrafiche.aspx">Elimina</option>
                </select>
                <div class="input-group-button">
                  <input type="hidden" id="sorgente" name="sorgente" value="elenco-anagrafiche">
                  <input type="hidden" id="azione" name="azione" value="">
                  <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                  <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                  <input type="submit" id="doaction" class="button secondary" value="Applica">
                </div>
              </div>
              </form>
            </div>
          </div>
    
    		  <table class="grid hover scroll">
    		    <thead>
    		      <tr>
    	        	<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
    		        <th width="30">Cod.</th>
      	        <th width="200" class="text-left">Anagrafica</th>
    		        <th width="80">Tipologia</th>
    		        <th width="80">Tipo</th>
    		        <th width="150">Comune</th>
    		        <th width="120">Prov.</th>
    		        <th width="80">Nazione</th>
    		        <th width="120">Telefono</th>
    		        <th width="110" class="text-center date">Data</th>
    		      </tr>
    			   </thead>
    			   <tbody>
    		    <%for (int i = 0; i < dtAnagrafiche.Rows.Count; i++){ %>
  		        <tr class="riga<%=i%2%>">
  		          <td><input type="checkbox" class="checkrow" id="record<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>" data-value="<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>" /></td>
  		          <td class="show-for-medium-up large-text-center small-text-left nowrap"><a href="<%=strFormUrl%>&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>"><%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%></a></td>
  		          <td>
  								<div class="width200">
  			            <% if (dtAnagrafiche.Rows[i]["Anagrafiche_Disdetto"].Equals(true)){ %>
  				            <i class="fa-duotone fa-circle-info fa-fw" style="color:#ec5840" title="chiuso"></i>
  				          <% } %>
  									<a href="<%=strFormUrl%>&Anagrafiche_Ky=<%=dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString()%>">
                    <% if (dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString().Length>1){ %>
                    <img src="https://www.google.com/s2/favicons?domain=<%=dtAnagrafiche.Rows[i]["Anagrafiche_SitoWeb"].ToString()%>&size=16" width="16" height="16" border="0">
                    <% }else{ %>
                    <i class="fa-duotone fa-user fa-fw"></i>
                    <% } %>  
                    <%=dtAnagrafiche.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%>
                    </a>
  								</div>
  							</td>
  		          <td><%=dtAnagrafiche.Rows[i]["AnagraficheTipologia_Titolo"].ToString()%></td>
  		          <td><%=dtAnagrafiche.Rows[i]["AnagraficheTipo_Descrizione"].ToString()%></td>
  		          <td><div class="width150"><i class="fa-duotone fa-location-dot fa-fw"></i><%=dtAnagrafiche.Rows[i]["Comuni_Comune"].ToString()%></div></td>
  		          <td><i class="fa-duotone fa-location-dot fa-fw"></i><%=dtAnagrafiche.Rows[i]["Province_Provincia"].ToString()%></td>
  		          <td><img src="/img/flags/<%=dtAnagrafiche.Rows[i]["Nazioni_Codice"].ToString()%>.png" hspace="5"><%=dtAnagrafiche.Rows[i]["Nazioni_Nazione"].ToString()%></td>
  		          <td><div class="width300"><i class="fa-duotone fa-phone fa-fw"></i><a href="tel:<%=dtAnagrafiche.Rows[i]["Anagrafiche_Telefono"].ToString().Trim()%>"><%=dtAnagrafiche.Rows[i]["Anagrafiche_Telefono"].ToString()%></a></div></td>
  		          <% if (dtAnagrafiche.Rows[i]["Anagrafiche_DateInsert"]!=System.DBNull.Value){  %>
  							<td data-order="<%=Convert.ToDateTime(dtAnagrafiche.Rows[i]["Anagrafiche_DateInsert"]).ToString("yyyyMMddHHmmssfff")%>"><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagrafiche.Rows[i]["Anagrafiche_DateInsert"].ToString()%></td>
  							<% } else{ %>
  							<td><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtAnagrafiche.Rows[i]["Anagrafiche_DateInsert"].ToString()%></td>
  							<% }  %>
  		        </tr>
  		    <%
  		      intAnagrafiche_Ky=Convert.ToInt32(dtAnagrafiche.Rows[i]["Anagrafiche_Ky"].ToString());
  		    } %>
  			    </tbody>
  			  </table>
      </div>
      <% } %>

      <% if (dtCommesse.Rows.Count>0 && dtLogin.Rows[0]["UtentiGruppi_Progetti"].Equals(true)){ 
        strWHERENet="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=107)";
        //Response.Write(strWHERENet);
    		strFROMNet = "UsergroupsForms_Vw";
    		strORDERNet = "CoreForms_Default DESC, CoreForms_Ky DESC";
    		dtCoreForms = new System.Data.DataTable("CoreGrids");
    		dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		if (dtCoreForms.Rows.Count>0){
          //Response.Write(dtCoreForms.Rows[0]["CoreForms_Ky"].ToString());
          if (dtCoreForms.Rows[0]["CoreForms_Custom"].Equals(true)){
            strFormUrl="/admin/app/" + dtCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreForms.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString();
          }else{
            strFormUrl="/admin/form.aspx?CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString() + "&custom=0";
          }
        }else{
          strFormUrl="/admin/app/progetti/scheda-progetti.aspx?custom=1&CoreEntities_Ky=162";
        }
      %>
        <div class="divgrid">
          <div class="grid-x grid-padding-x">
            <div class="large-9 medium-9 small-12 cell">
              <h2><i class="fa-duotone fa-fw fa-buildings"></i>Progetti</h2>
            </div>
            <div class="large-3 medium-3 small-12 cell">
              <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
              <div class="input-group">
                <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                  <option value="">Azioni di gruppo</option>
                  <option value="delete" data-action="/admin/app/Commesse/crud/elimina-Commesse.aspx">Elimina</option>
                </select>
                <div class="input-group-button">
                  <input type="hidden" id="sorgente" name="sorgente" value="elenco-Commesse">
                  <input type="hidden" id="azione" name="azione" value="">
                  <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                  <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                  <input type="submit" id="doaction" class="button secondary" value="Applica">
                </div>
              </div>
              </form>
            </div>
          </div>
    
          <table class="grid hover scroll" border="0" width="100%">
          	<thead>
      	      <tr>
      	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
      	        <th width="100">Codice</th>
      	        <th width="200" class="text-left">Anagrafica</th>
      	        <th width="220">Date</th>
      	        <th width="300">Progetto</th>
      	        <th width="100">Azioni</th>
      	        <th width="250">Stato</th>
      	        <th width="130">Ore</th>
      	      	<% if (boolAdmin && dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
      	        <th width="100" class="text-right">Valore</th>
      	        <% } %>
      	        <th width="60" class="nowrap" data-orderable="false"></th>
      	      </tr>
          	</thead>
          	<tbody>
      		    <%
      					for (int i = 0; i < dtCommesse.Rows.Count; i++){ %>
      		        <tr class="riga<%=i%2%>">
      		          <td><input type="checkbox" class="checkrow" id="record<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" data-value="<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" /></td>
      		          <td class="show-for-medium-up text-center nowrap">
      								<div class="width100"><%=dtCommesse.Rows[i]["Commesse_Riferimenti"].ToString()%></div>
      							</td>
      		          <td>
      								<div class="width200">
      	            	    <i class="fa-duotone fa-user fa-fw"></i><%=dtCommesse.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%>
      								</div>
      							</td>
      		          <td>
      								<div style="float:left;width:70px;text-align:right">Inserita:</div><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtCommesse.Rows[i]["Commesse_Data_IT"].ToString()%><br>
      								<% if (dtCommesse.Rows[i]["Commesse_DataConsegna_IT"].ToString().Length>0){ %>
                      <div style="float:left;width:70px;text-align:right">Consegna:</div><i class="fa-duotone fa-calendar-days fa-fw"></i><%=dtCommesse.Rows[i]["Commesse_DataConsegna_IT"].ToString()%>
                      <% } %>
      							</td>
      		          <td>
      								<div class="width300">
      									<a href="<%=strFormUrl%>&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-building fa-fw"></i><strong><%=dtCommesse.Rows[i]["Commesse_Titolo"].ToString()%></strong></a><br>
      								</div>
      							</td>
      		          <td>
      								<a href="/admin/app/progetti/scheda-progetti.aspx?Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>"><i class="fa-duotone fa-gears fa-fw"></i>Attivit&agrave;</a><br>
      							</td>
      							<td>
      									<div class="width250">
                            <i class="fa-duotone fa-user fa-fw"></i> <%=dtCommesse.Rows[i]["Utenti_Iniziali"].ToString()%>
      									</div> 
      									<div style="margin-top:5px" class="progress success" role="progressbar" tabindex="0" aria-valuenow="<%=dtCommesse.Rows[i]["Commesse_Avanzamento"].ToString()%>" aria-valuemin="0" aria-valuetext="<%=dtCommesse.Rows[i]["Commesse_Avanzamento"].ToString()%>%" aria-valuemax="100">
      									  <span class="progress-meter" style="width:<%=dtCommesse.Rows[i]["Commesse_Avanzamento"].ToString()%>%">
      									    <p class="progress-meter-text"><%=dtCommesse.Rows[i]["Commesse_Avanzamento"].ToString()%>%</p>
      									  </span>
      									</div>
      							</td>
      							<td class="large-text-right small-text-left">
      								previste: <i class="fa-duotone fa-clock fa-fw"></i> <%=dtCommesse.Rows[i]["Commesse_OrePreviste"].ToString()%><br>
      								impiegate: <i class="fa-duotone fa-clock fa-fw"></i> <%=dtCommesse.Rows[i]["Commesse_OreImpiegate"].ToString()%>
      							</td>
      			      	<% if (boolAdmin && dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
      		          <td class="large-text-right small-text-left" style="padding-right:4px">&euro; <%=dtCommesse.Rows[i]["Commesse_Valore_IT"].ToString()%></td>
      	        		<% } %>
      		          <td class="show-for-medium-up text-center nowrap">
                      <a href="<%=strFormUrl%>&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" title="modifica" class="edit"><i class="fa-duotone fa-pen-to-square fa-fw"></i></a>
                      <a href="/admin/app/progetti/crud/elimina-commesse.aspx?azione=delete&Commesse_Ky=<%=dtCommesse.Rows[i]["Commesse_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
                    </td>
      		        </tr>
      					<% } %>
          	</tbody>
          </table>
       </div>
      <% } %>
            
      <% if (dtPasswordmanager.Rows.Count>0 && dtLogin.Rows[0]["UtentiGruppi_Produzione"].Equals(true)){ 
        strWHERENet="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=166)";
        //Response.Write(strWHERENet);
    		strFROMNet = "UsergroupsForms_Vw";
    		strORDERNet = "CoreForms_Default DESC, CoreForms_Ky DESC";
    		dtCoreForms = new System.Data.DataTable("CoreGrids");
    		dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		if (dtCoreForms.Rows.Count>0){
          //Response.Write(dtCoreForms.Rows[0]["CoreForms_Ky"].ToString());
          if (dtCoreForms.Rows[0]["CoreForms_Custom"].Equals(true)){
            strFormUrl="/admin/app/" + dtCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreForms.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString();
          }else{
            strFormUrl="/admin/form.aspx?CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString() + "&custom=0";
          }
        }else{
          strFormUrl="/admin/app/passwordmanager/scheda-passwordmanager.aspx?custom=1&CoreEntities_Ky=162";
        }
      
      %>
        <div class="divgrid">
          <div class="grid-x grid-padding-x">
            <div class="large-9 medium-9 small-12 cell">
              <h2><i class="fa-duotone fa-fw fa-key"></i>Password</h2>
            </div>
            <div class="large-3 medium-3 small-12 cell">
              <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
              <div class="input-group">
                <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                  <option value="">Azioni di gruppo</option>
                  <option value="delete" data-action="/admin/app/passwordmanager/crud/elimina-passwordmanager.aspx">Elimina</option>
                </select>
                <div class="input-group-button">
                  <input type="hidden" id="sorgente" name="sorgente" value="elenco-passwordmanager">
                  <input type="hidden" id="azione" name="azione" value="">
                  <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                  <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                  <input type="submit" id="doaction" class="button secondary" value="Applica">
                </div>
              </div>
              </form>
            </div>
          </div>
          
          <table class="grid hover scroll" border="0" width="100%">
          	<thead>
      	      <tr>
      	        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
      	        <th width="30">Codice</th>
      	        <th width="150" class="text-left">Anagrafica</th>
      	        <th width="200">Titolo</th>
      	        <th width="150">Sito</th>
      	        <th width="150">Categoria</th>
      	        <th width="100">Username</th>
      	        <th width="180">Password</th>
      	        <th width="12" class="nowrap" data-orderable="false"></th>
      	      </tr>
          	</thead>
          	<tbody>
      		    <%for (int i = 0; i < dtPasswordmanager.Rows.Count; i++){
      						%>
      		        <tr class="riga<%=i%2%>">
      		          <td><input type="checkbox" class="checkrow" id="record<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>" data-value="<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>" /></td>
      		          <td><a href="<%=strFormUrl%>&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>"><%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%></a></td>
      		          <td>
      								<div class="width150">
      		            	<i class="fa-duotone fa-users fa-fw"></i><%=dtPasswordmanager.Rows[i]["Anagrafiche_RagioneSociale"].ToString()%>
      								</div> 
      		          </td>
      		          <td><div class="width200"><a href="<%=strFormUrl%>&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>"><%=dtPasswordmanager.Rows[i]["Passwordmanager_Titolo"].ToString()%></a></div></td>
      		          <td><%=dtPasswordmanager.Rows[i]["SitiWeb_Url"].ToString()%></td>
      		          <td><%=dtPasswordmanager.Rows[i]["PasswordmanagerCategorie_Titolo"].ToString()%></td>
      		          <td><%=dtPasswordmanager.Rows[i]["Passwordmanager_Username"].ToString()%></td>
      			        <td class="text text-left"><i class="fa-duotone fa-file-lines fa-fw"></i><span id="passwordgrid<%=i%>" class="passwordgrid" data-password="<%=dtPasswordmanager.Rows[i]["Passwordmanager_Password"].ToString()%>">xxxxxxxxxxxxxxx</span><a><i onclick="showPasswordGrid('passwordgrid<%=i%>')" class="fa-duotone fa-eye fa-fw"></i></a><a><i onclick="copyToClipboard('passwordgrid<%=i%>',true)" class="fa-duotone fa-copy fa-fw"></i></a></td>
      		          <td><a href="/admin/app/passwordmanager/crud/elimina-passwordmanager.aspx?azione=delete&Passwordmanager_Ky=<%=dtPasswordmanager.Rows[i]["Passwordmanager_Ky"].ToString()%>" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a></td>
      		        </tr>
      		    <% } %>
          	</tbody>
          </table>
       </div>
      <% } %>
      
      <% if (dtSitiWeb.Rows.Count>0){ 
        strWHERENet="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=142)";
        //Response.Write(strWHERENet);
    		strFROMNet = "UsergroupsForms_Vw";
    		strORDERNet = "CoreForms_Default DESC, CoreForms_Ky DESC";
    		dtCoreForms = new System.Data.DataTable("CoreGrids");
    		dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    		if (dtCoreForms.Rows.Count>0){
          //Response.Write(dtCoreForms.Rows[0]["CoreForms_Ky"].ToString());
          if (dtCoreForms.Rows[0]["CoreForms_Custom"].Equals(true)){
            strFormUrl="/admin/app/" + dtCoreForms.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreForms.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString();
          }else{
            strFormUrl="/admin/form.aspx?CoreModules_Ky=" + dtCoreForms.Rows[0]["CoreModules_Ky"].ToString() + "&CoreEntities_Ky=" + dtCoreForms.Rows[0]["CoreEntities_Ky"].ToString() + "&CoreForms_Ky=" + dtCoreForms.Rows[0]["CoreForms_Ky"].ToString() + "&custom=0";
          }
        }else{
          strFormUrl="/admin/app/passwordmanager/scheda-passwordmanager.aspx?custom=1&CoreEntities_Ky=162";
        }
      %>
        <div class="divgrid">
          <div class="grid-x grid-padding-x">
            <div class="large-9 medium-9 small-12 cell">
              <h2><i class="fa-duotone fa-fw fa-globe"></i>Siti Web</h2>
            </div>
            <div class="large-3 medium-3 small-12 cell">
              <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
              <div class="input-group">
                <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                  <option value="">Azioni di gruppo</option>
                  <option value="delete" data-action="/admin/app/sitiweb/crud/elimina-sitiweb.aspx">Elimina</option>
                </select>
                <div class="input-group-button">
                  <input type="hidden" id="sorgente" name="sorgente" value="elenco-sitiweb">
                  <input type="hidden" id="azione" name="azione" value="">
                  <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                  <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                  <input type="submit" id="doaction" class="button secondary" value="Applica">
                </div>
              </div>
              </form>
            </div>
          </div>
          
		      <table class="grid hover scroll" border="0" width="100%">
			    	<thead>
		        <tr>
	        		<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
		          <th width="40" class="text-left">Cod.</th>
		          <th width="350" class="text-left">Dominio</th>
							<th width="100" class="text-left">Tipo</th>
							<th width="80" class="text-center">Provider</th>
							<th width="60" class="text-center">IP</th>
							<th width="100" class="text-left">Versione</th>
							<th width="70" class="text-center">PageSpeed</th>
							<th width="40" class="text-center">SEO</th>
							<th width="50" class="text-center nowrap" data-orderable="false"></th>
		        </tr>
			    	</thead>
			    	<tbody>
		        <%for (int i = 0; i < dtSitiWeb.Rows.Count; i++){ %>
		            <tr>
		          		<td><input type="checkbox" class="checkrow" id="record<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>" data-value="<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>" /></td>
		              <td class="text-left"><a href="<%=strFormUrl%>&SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%></a></td>
		              <td class="text-left">
										<a href="<%=dtSitiWeb.Rows[i]["SitiWeb_Url"].ToString()%>" target="_blank"><i class="fa-duotone fa-up-right-from-square fa-fw"></i></a>
										<a href="<%=strFormUrl%>&SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&sorgente=scheda-anagrafiche"><%=dtSitiWeb.Rows[i]["SitiWeb_Dominio"].ToString()%></a>
									</td>
		              <td class="text-left">
		              <i class="<%=dtSitiWeb.Rows[i]["SitiWebTipo_Icona"].ToString()%> fa-lg fa-fw"></i>
									<%=dtSitiWeb.Rows[i]["SitiWebTipo_Titolo"].ToString()%></td>
			          	<td class="large-text-center small-text-left">
		              <%=dtSitiWeb.Rows[i]["Providers_Descrizione"].ToString()%></td>
		              <td class="large-text-center small-text-left"><%=dtSitiWeb.Rows[i]["SitiWeb_IP"].ToString()%></td>
		              <td class="text-left"><%=dtSitiWeb.Rows[i]["SitiWeb_Versione"].ToString()%></td>
		              <td class="large-text-center small-text-left"><i class="fa-duotone fa-chart-waterfall fa-fw"></i><%=Smartdesk.Functions.GetValorePageSpeed(dtSitiWeb.Rows[i]["SitiWeb_PageSpeedScore"].ToString())%></td>
					  			<td>
											<% if (dtSitiWeb.Rows[i]["SitiWeb_SEO"].Equals(true)){ %>
												<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
											<% }else{ %>
												<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
											<% } %>
									</td>
		              <td class="text-center nowrap">
		                <a href="/admin/app/sitiweb/crud/elimina-sitiweb.aspx?azione=delete&Anagrafiche_Ky=<%=dtSitiWeb.Rows[i]["Anagrafiche_Ky"].ToString()%>&SitiWeb_Ky=<%=dtSitiWeb.Rows[i]["SitiWeb_Ky"].ToString()%>&sorgente=scheda-anagrafiche" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
		              </td>
		            </tr>
		        <% } %>
			    	</tbody>
					  <% if (dtSitiWeb.Rows.Count<1){
					      	Response.Write("<tfoot><tr><td colspan=\"10\"><div class=\"messaggio\">Nessun dato</div></td></tr></foot>");
						} %> 
		      </table>
       </div>
      <% } %>
      
     </div>
    </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
