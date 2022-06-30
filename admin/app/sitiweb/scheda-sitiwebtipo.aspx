<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sitiweb/scheda-SitiWebTipo.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Siti web > Scheda tipo siti web</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
		<h1><i class="fa-duotone fa-table fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue("SitiWebTipo_Ky")%></span></h1>
		<form id="form-sitiwebtipo" action="/admin/app/sitiweb/crud/salva-sitiwebtipo.aspx" method="post" data-abide novalidate>
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="SitiWebTipo_Ky" id="SitiWebTipo_Ky" value="<%=GetFieldValue("SitiWebTipo_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/view.aspx?CoreModules_Ky=27&CoreEntities_Ky=144&CoreGrids_Ky=128" class="button clear"><i class="fa-duotone fa-backward success fa-fw"></i> Torna all'elenco</a>
        <button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
			<!--#include file=/admin/app/sitiweb/forms/sitiwebtipo_form.htm --> 
    </form>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
