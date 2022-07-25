<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/veicoli/scheda-veicoli.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
  <title>Veicoli > Scheda veicolo</title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script type="text/javascript" src="/admin/app/veicoli/veicoli.js?id=2"></script>
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.css" integrity="sha512-H9jrZiiopUdsLpg94A333EfumgUBpO9MdbxStdeITo+KEIMaNfHNvwyjjDJb+ERPaRS6DpyRlKbvPUasNItRyw==" crossorigin="anonymous" referrerpolicy="no-referrer" />
  <script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.js" integrity="sha512-uURl+ZXMBrF4AwGaWmEetzrd+J5/8NRkWAvJx5sbPSSuOb0bZLqf+tOzniObO00BjHa/dD7gub9oCGMLPQHtQA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-veicoli" action="/admin/app/veicoli/crud/salva-veicoli.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-car fa-lg fa-fw"></i>Scheda tipo di veicolo: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtVeicoli,"Veicoli_Ky")%></span></h1>
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">

  			<div class="stacked-for-small button-group small hide-for-print align-right">
  				<a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=109&CoreGrids_Ky=130" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
  				<a href="/admin/app/veicoli/scheda-veicoli.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
        	<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
  			</div>
      
			</div>
		</div>
	</div>
</div>
<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
 		<div class="divform">
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="Veicoli_Ky" id="Veicoli_Ky" value="<%=GetFieldValue(dtVeicoli, "Veicoli_Ky")%>">
      <!--#include file=/admin/forms_messaggi.inc -->
			<!--#include file=/admin/app/veicoli/forms/veicoli_form.htm -->
    </div> 
  </div>
</div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
<script>
	jQuery("[data-fancybox]").fancybox({
  	thumbs : {
  		autoStart : true,
      infobar : true,
      lang : 'it'
  	}
  });
</script>
</body>
</html>
