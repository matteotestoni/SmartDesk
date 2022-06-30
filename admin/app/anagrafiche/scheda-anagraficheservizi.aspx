<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Anagrafiche > Scheda servizio per anagrafica</title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script type="text/javascript">
  	function calcolaTotali(){
			jQuery("#AnagraficheServizi_Importo").val(  jQuery("#AnagraficheServizi_Qta").val()*jQuery("#AnagraficheServizi_Prezzo").val() );
		}
		
		function chgServizi_Ky(){
			var sel = document.getElementById('Servizi_Ky');
			var selected = sel.options[sel.selectedIndex];
			var extra = selected.getAttribute('AttributiGruppi_Ky');
			jQuery("#AttributiGruppi_Ky").val(extra);
			selectSet("AttributiGruppi_Ky",extra);
		}
		
		function chgAttributiGruppi_Ky(){
			alert("ATTENZIONE: Salvare il servizio e poi rientrare per modificarlo;")
		}
	</script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-servizio" action="/admin/app/catalogo/crud/salva-servizio.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-euro-sign fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAnagraficheServizi, "AnagraficheServizi_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
  			<div class="stacked-for-small button-group small hide-for-print align-right">
  				<a href="/admin/app/anagrafiche/elenco-anagrafiche-servizi.aspx" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
  				<a href="/admin/app/anagrafiche/scheda-anagraficheservizi.aspx?azione=new&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&sorgente=scheda-anagrafiche" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
                <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
  			</div>
  	      </div>
      </div>
  </div>
</div>

  <div class="grid-x grid-padding-x">
    <div class="large-12 medium-12 small-12 cell">
  	<div class="divform">
       
        <input type="hidden" name="sorgente" id="sorgente" value="<%=strSorgente%>">
        <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
        <input type="hidden" name="AnagraficheServizi_Ky" id="AnagraficheServizi_Ky" value="<%=GetFieldValue(dtAnagraficheServizi, "AnagraficheServizi_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
   			<!--#include file=/admin/app/anagrafiche/forms/anagraficheservizi_form.htm -->
  				<% if (strAzione!="new"){
  				if (dtAttributi!=null){ %>
          <div class="grid-x grid-padding-x">
            <div class="large-12 medium-12 small-12 cell">
  									<h2>Opzioni aggiuntive sul servizio (definite nel set di attributi)</h2>
  							    <% if (dtAttributi!=null && dtAttributi.Rows.Count>0){ %>
  							        <%for (int i = 0; i < dtAttributi.Rows.Count; i++){ %>
  													<div class="grid-x grid-padding-x">
  							              <div class="large-2 medium-2 small-4 cell">
  															<label class="large-text-right small-text-left middle"><%=dtAttributi.Rows[i]["Attributi_Titolo"].ToString()%> <i class="<%=dtAttributi.Rows[i]["Attributi_Icona"].ToString()%> fa-fw"></i></label>
  														</div>
  							              <div class="large-10 medium-10 small-8 cell">
  														<%
  															switch (dtAttributi.Rows[i]["AttributiTipo_Ky"].ToString()){
  																case "1":
  																	Response.Write("<input type=\"text\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
  																	break;
  																case "2":
  																	Response.Write("<textarea required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"\">" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "</textarea>");
  																	break;
  																case "3":
  																	Response.Write("<input type=\"text\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" class=\"datepicker txt\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
  																	break;
  																case "4":
  																	Response.Write("<input type=\"checkbox\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
  																	break;
  																case "5":
  																	Response.Write("<input type=\"text\" required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" class=\"price\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\" />");
  																	break;
  																case "6":
  																	Response.Write("<select required=\"required\" name=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" id=\"attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "\" value=\"" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "\"><option value=\"\"></option>");
  																	strWHERENet="Attributi_Ky=" + dtAttributi.Rows[i]["Attributi_Ky"].ToString();
  											            strORDERNet = "AttributiOpzioni_Ky";
  											            strFROMNet = "AttributiOpzioni";
  											            dtAttributiOpzioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiOpzioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  							        						for (int j = 0; j < dtAttributiOpzioni.Rows.Count; j++){
  							        							Response.Write("<option value=\"" + dtAttributiOpzioni.Rows[j]["AttributiOpzioni_Opzione"].ToString() + "\">" + dtAttributiOpzioni.Rows[j]["AttributiOpzioni_Opzione"].ToString() + "</option>");
  																	}
  																	Response.Write("</select>\n");
  																	Response.Write("<small class=\"form-error\">Obbligatorio</small>");
  											            Response.Write("<script type=\"text/javascript\">\n");
  																	Response.Write("selectSet('attr-" + dtAttributi.Rows[i]["Attributi_Codice"].ToString() + "', '" + GetAttributoValue("attr-"+dtAttributi.Rows[i]["Attributi_Codice"].ToString()) + "');\n");
  											            Response.Write("</script>\n");
  																	break;
  															}
  														%>
  														</div>
  							            </div>
  							        <% } %>
  							    <% } %>							    
  					</div>
          </div>
  				<% }
  				} %>
      </div>
    </div>
  </div>
  </form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
