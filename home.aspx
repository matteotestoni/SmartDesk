<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="home.aspx.cs" Inherits="_Default" Debug="true"%><!doctype html>
<html class="no-js" lang="it">
  <head>
    	<title>Home</title>
    	<meta name="description" content="Home"/>
  		<meta name="robots" content="index,follow">
      <% Response.WriteFile("/frontend/" + strTheme + "/inc-head.aspx"); %>          
  </head>
  <body>
  <% Response.WriteFile("/frontend/" + strTheme + "/inc-header.aspx"); %>          
  <% Response.WriteFile("/frontend/" + strTheme + "/inc-footer.aspx"); %>          
  <% Response.WriteFile("/frontend/" + strTheme + "/inc-foot.aspx"); %>          
  </body>
</html>

