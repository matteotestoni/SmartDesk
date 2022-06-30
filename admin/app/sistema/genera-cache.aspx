<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/sistema/genera-cache.aspx.cs" Inherits="_Default" Debug="true"%>
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
      <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
          <div class="grid-x grid-padding-x align-middle">
              <div class="large-4 medium-4 small-12 cell align-middle">
                <h1><i class="fa-duotone fa-gear fa-lg fa-fw"></i><%=strH1%></h1>
              </div>
              <div class="large-8 medium-8 small-12 cell float-right align-middle">
      	      </div>
          </div>
      </div>
      <div class="divform">
      	<%=strRisultato%>
      </div>
  </div>
</div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
