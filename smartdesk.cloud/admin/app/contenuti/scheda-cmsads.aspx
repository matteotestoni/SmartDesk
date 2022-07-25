<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="scheda-cmsads.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>

<html class="no-js" lang="it">
<head>
	<title>Contenuti > Scheda contenuto</title>
	<!--#include file="/admin/inc-head.aspx"-->
	<script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
	<script src="https://cdn.smartdesk.cloud/lib/jquery-file-upload/js/jquery.fileupload.js"></script>	
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-cmsads" enctype="multipart/form-data" action="/admin/app/contenuti/crud/salva-cmsads.aspx" method="post" data-abide novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-image fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtCMSAds, "CMSAds_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
      			<div class="stacked-for-small button-group small hide-for-print align-right">
      				<a href="/admin/app/contenuti/elenco-cmsads.aspx" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
      				<a href="/admin/app/contenuti/scheda-cmsads.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
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
        <input type="hidden" name="CMSAds_Ky" id="CMSAds_Ky" value="<%=GetFieldValue(dtCMSAds, "CMSAds_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
   			<!--#include file=/admin/app/contenuti/forms/cmsads_form.htm -->
      </div>
    </div>
  </div>
</form>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
