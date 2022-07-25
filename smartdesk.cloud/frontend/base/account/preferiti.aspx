<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="area-personale.aspx.cs" Inherits="_Default" Debug="false"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
	<head>
  	<title><%=strH1%></title>
    <meta name="description" content="<%=strH1%>"/>
    <meta name="robots" content="noindex,nofollow">
    <!--#include file="/frontend/base/inc-head.aspx"--> 
	</head>
	<body>
		<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
      <div class="grid-x grid-padding-x">
				<div class="large-3 medium-3 small-12 cell">
          <!--#include file="/frontend/base/account/inc-sidebar.aspx"--> 
				</div>
        <div class="large-9 medium-9 small-12 cell">
        	<h1>Preferiti</h1>
        	<div class="grid-x grid-padding-x">
        		<div class="large-12 medium-12 small-12 cell">
  	           <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-aste-wishlist.inc" -->
  	           <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-lotti-wishlist.inc" -->
  	           <!-- #include file ="/frontend/base/account/areapersonale/inc-elenco-annunci-wishlist.inc" -->
						</div>                
					</div>
        </div>
      </div>
    </div>
		<!-- #include file ="/frontend/base/inc-footer.aspx" -->
		<!-- #include file ="/frontend/base/inc-foot.aspx" -->
	</body>
</html>