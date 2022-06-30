<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/annunci/scheda-annuncimodello.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Annunci > Scheda modello</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
		<h1><i class="fa-duotone fa-globe fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtAnnunciModello, "AnnunciModello_Ky")%></span></h1>
		<form id="form-annuncimodello" action="/admin/app/annunci/crud/salva-annuncimodello.aspx" method="post" data-abide novalidate>
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="AnnunciModello_Ky" id="AnnunciModello_Ky" value="<%=GetFieldValue(dtAnnunciModello, "AnnunciModello_Ky")%>">
      <input type="hidden" name="AnnunciMarca_Ky" id="AnnunciMarca_Ky" value="<%=GetFieldValue(dtAnnunciModello, "AnnunciMarca_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/app/annunci/scheda-annuncimarca.aspx?AnnunciMarca_Ky=<%=GetFieldValue(dtAnnunciModello, "AnnunciMarca_Ky")%>" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
      	<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
      <!--#include file=/admin/app/annunci/forms/annuncimodello_form.htm -->
    </form>
  </div>
</div>



<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
