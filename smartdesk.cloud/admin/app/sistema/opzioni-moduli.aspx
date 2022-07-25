<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sistema/opzioni-moduli.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
    <h1><i class="fa-duotone fa-gear fa-lg fa-fw"></i><%=strH1%></h1>
  	<%=strRisultato%>
  </div>
</div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
