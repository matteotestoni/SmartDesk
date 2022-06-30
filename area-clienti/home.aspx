<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="/area-clienti/home.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-12 medium-12 small-12 cell align-middle">
            	<h1><i class="fa-duotone fa-gauge fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
      </div>
  </div>
</div>

<div class="homecontent">
  <div class="grid-container fluid">
    <div class="grid-x grid-padding-x">
    	<div class="large-12 medium-12 small-12 cell">
          <!--#include file=/area-clienti/app/anagrafiche/widget/widget-anagrafica.aspx --> 
          <% if (boolEnableproducts){ %>
          <!--#include file=/area-clienti/app/anagrafiche/widget/widget-anagraficheprodotti.aspx --> 
          <% } %>
          <% if (boolEnableticket){ %>
          <!--#include file=/area-clienti/app/ticket/widget/widget-ticket.aspx --> 
          <% } %>
          <% if (boolEnableprojects){ %>
          <!--#include file=/area-clienti/app/progetti/widget/widget-progetti.aspx --> 
          <% } %>
          <!--#include file=/area-clienti/app/forms/widget/widget-forms.aspx --> 
    	</div>
    </div>
  </div>
</div>
<!--#include file=/area-clienti/inc-footer.aspx -->
</body>
</html>

