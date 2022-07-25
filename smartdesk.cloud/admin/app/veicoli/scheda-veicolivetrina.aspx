<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/veicoli/scheda-veicolivetrina.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Veicoli > Scheda vetrina veicoli</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-car fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue("VeicoliVetrina_Ky")%></span></h1>
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">
  			<div class="stacked-for-small button-group small hide-for-print align-right">
  				<a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=252&CoreGrids_Ky=275" class="button clear"><i class="fa-duotone fa-backward success fa-fw"></i>Torna all'elenco</a>
  				<a href="/admin/app/veicoli/scheda-veicolivetrina.aspx?CoreModules_Ky=29&CoreEntities_Ky=252&azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
          <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
  			</div>
			</div>
		</div>
	</div>
</div>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
			<form id="form-veicolivetrina" action="/admin/app/veicoli/crud/salva-veicolivetrina.aspx" method="post" data-abide novalidate>
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="VeicoliVetrina_Ky" id="VeicoliVetrina_Ky" value="<%=GetFieldValue("VeicoliVetrina_Ky")%>">
      <input type="hidden" name="Utenti_Ky" id="Utenti_Ky" value="<%=Smartdesk.Session.CurrentUser.ToString()%>">
      <input type="hidden" name="UtentiGruppi_Ky" id="UtentiGruppi_Ky" value="<%=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString()%>">
      <!--#include file=/admin/forms_messaggi.inc -->
	 		<div class="divform">
      <!--#include file=/admin/app/veicoli/forms/veicolivetrina_form.htm -->
      </div>
    </form>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
