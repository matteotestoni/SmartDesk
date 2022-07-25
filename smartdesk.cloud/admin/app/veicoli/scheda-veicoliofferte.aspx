<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/veicoli/scheda-veicoliofferte.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Veicoli > Scheda offerta veicoli</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx -->
<form id="form-veicoliofferte" action="/admin/app/veicoli/crud/salva-veicoliofferte.aspx" method="post" enctype="multipart/form-data" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
		        <h1><i class="fa-duotone fa-table fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtVeicoliOfferte, "VeicoliOfferte_Ky","text")%></span></h1> 
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=126&CoreGrids_Ky=147" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
      				<a href="/admin/app/veicoli/scheda-veicoliofferte.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
              <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
      			</div>
  	      </div>
      </div>
  </div>
</div>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="Ky" id="Ky" value="<%=GetFieldValue(dtVeicoliOfferte, "VeicoliOfferte_Ky","text")%>">
      <input type="hidden" name="VeicoliOfferte_Ky" id="VeicoliOfferte_Ky" value="<%=GetFieldValue(dtVeicoliOfferte, "VeicoliOfferte_Ky","text")%>">
      <div class="divform">
      <!--#include file=/admin/forms_messaggi.inc -->
			<!--#include file=/admin/app/veicoli/forms/veicoliofferte_form.htm -->
      </div>
  </div>
</div>
</form>
<!--#include file=/admin/app/veicoli/scheda-veicoliofferteauto.inc -->
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
