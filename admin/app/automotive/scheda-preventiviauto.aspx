<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/automotive/scheda-preventiviauto.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title><%=strH1%></title>
	<!--#include file="/admin/inc-head.aspx"-->
  <script type="text/javascript" src="/admin/app/automotive/automotive.js?id=5"></script>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<form id="form-preventiviauto" action="/admin/app/automotive/crud/salva-preventiviauto.aspx" method="post" data-abide="" novalidate>
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-car fa-lg fa-fw"></i><%=strH1%>: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtPreventiviAuto, "PreventiviAuto_Ky")%></span></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
            <div class="stacked-for-small button-group small hide-for-print align-right">
                <a href="/admin/view.aspx?CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270" class="button clear"><i class="fa-duotone fa-table fa-fw"></i>Vai all'elenco</a>
                <a href="#" class="button clear" id="print" onclick="stampaDocumento();"><i class="fa-duotone fa-print fa-lg fa-fw"></i>Stampa</a>
    						<%
    						if (dtCoreFormsButtons.Rows.Count>0){
    							for (int iCoreFormsButtons = 0; iCoreFormsButtons < dtCoreFormsButtons.Rows.Count; iCoreFormsButtons++){ 
    								strAction=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Action"].ToString();
                    if (strAction.Contains("javascript")){
                        
                    }else{
                        strAction=strAction + "?" + dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString() + "=" + GetFieldValue(dtFormsData, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString());
                    }
                    %>  
                    <a href="<%=strAction%>" class="button clear" data-number="<%=iCoreFormsButtons%>" data-order="<%=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Order"].ToString()%>"><i role="img" class="<%=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Icon"].ToString()%> fa-fw"></i><%=dtCoreFormsButtons.Rows[iCoreFormsButtons]["CoreFormsButtons_Title"].ToString()%></a>
    							<%
    							}
    						}
                %>
                <a href="/admin/app/automotive/scheda-preventiviauto.aspx?azione=new&CoreModules_Ky=35&CoreEntities_Ky=249&CoreGrids_Ky=270&CoreForms_Ky=196&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&sorgente=<%=strSorgente%>" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a> 
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
        <input type="hidden" name="PreventiviAuto_Ky" id="PreventiviAuto_Ky" value="<%=GetFieldValue(dtPreventiviAuto, "PreventiviAuto_Ky")%>">
        <!--#include file=/admin/forms_messaggi.inc -->
		<!--#include file=/admin/app/automotive/forms/preventiviauto_form.htm -->
      </div>
    </div>
  </div>
</form>

<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
