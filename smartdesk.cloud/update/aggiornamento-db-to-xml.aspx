<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/update/aggiornamento-db-to-xml.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
  <meta charset="utf-8">
  <meta http-equiv="x-ua-compatible" content="ie=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=1.0, user-scalable=no">
  <meta name="robots" content="noindex,nofollow">
  <link rel="shortcut icon" href="/img/favicon/favicon.ico">
  <link rel="apple-touch-icon" sizes="57x57" href="/img/favicon/apple-icon-57x57.png">
  <link rel="apple-touch-icon" sizes="60x60" href="/img/favicon/apple-icon-60x60.png">
  <link rel="apple-touch-icon" sizes="72x72" href="/img/favicon/apple-icon-72x72.png">
  <link rel="apple-touch-icon" sizes="76x76" href="/img/favicon/apple-icon-76x76.png">
  <link rel="apple-touch-icon" sizes="114x114" href="/img/favicon/apple-icon-114x114.png">
  <link rel="apple-touch-icon" sizes="120x120" href="/img/favicon/apple-icon-120x120.png">
  <link rel="apple-touch-icon" sizes="144x144" href="/img/favicon/apple-icon-144x144.png">
  <link rel="apple-touch-icon" sizes="152x152" href="/img/favicon/apple-icon-152x152.png">
  <link rel="apple-touch-icon" sizes="180x180" href="/img/favicon/apple-icon-180x180.png">
  <link rel="icon" type="image/png" sizes="192x192" href="/img/favicon/android-icon-192x192.png">
  <link rel="icon" type="image/png" sizes="32x32" href="/img/favicon/favicon-32x32.png">
  <link rel="icon" type="image/png" sizes="96x96" href="/img/favicon/favicon-96x96.png">
  <link rel="icon" type="image/png" sizes="16x16" href="/img/favicon/favicon-16x16.png">
  <link rel="manifest" href="/img/favicon/manifest.json">
  <meta name="msapplication-TileColor" content="#ffffff">
  <meta name="msapplication-TileImage" content="/img/favicon/ms-icon-144x144.png">
  <meta name="theme-color" content="#ffffff">  
  <link type="text/css" rel="stylesheet" href="https://cdn.smartdesk.cloud/fonts/Geomanist/Geomanist.css" media="screen, print" />
  <link type="text/css" rel="stylesheet" href="https://cdn.smartdesk.cloud/lib/foundation6.7.5/css/app.css" media="screen">
  <link type="text/css" rel="stylesheet" href="https://code.jquery.com/ui/1.13.2/themes/base/jquery-ui.min.css" media="screen, print">	
  <link type="text/css" rel="stylesheet" href="/login.css" media="screen, print" />
  <link rel="stylesheet" href="https://cdn.smartdesk.cloud/lib/fontawesome6/css/all.min.css" />
  <script type="text/javascript" src="https://cdn.smartdesk.cloud/lib/jquery/jquery-3.6.0.min.js"></script>
  <script type="text/javascript" src="https://code.jquery.com/ui/1.13.2/jquery-ui.min.js"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/what-input/5.2.12/what-input.min.js" integrity="sha512-jdMp80Gf2e7K/JH3+mucRwyeRaqRPD+ykSpkmbBqxWMMCfEZEL9PF0zzF3JEgV4IVNj6eTjV8X41e7Gz5nNwyA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
  <script src="https://cdnjs.cloudflare.com/ajax/libs/foundation/6.7.5/js/foundation.min.js" integrity="sha512-xpawU2EKh0HLTLWu8khGczejw+OaWWr+JBcbFBWtRUIkkhuMRZZeEFxY0n51aeC9YF4jxOMzd0pTR9m0tiSvsQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
  </head>
<body>
  <header data-sticky-container>
  	<div class="content-header" id="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x">
        <div class="large-12 medium-12 small-12 cell">
      	<h1><i class="fa-duotone fa-cog fa-lg fa-fw"></i><%=strH1%></h1>
        </div>
      </div>
    </div>
  </header>

  <main class="grid-container">
   		<div class="divform" id="divscheda" data-magellan-target="divscheda">
        <%=strRisultato%>
      </div>
  </main>

	<footer id="footer" class="grid-container fluid footer text-center hide-for-print">
	  <div class="grid-x grid-margin-x">
	  <div class="small-12 medium-12 large-12 cell">
				  &copy; <%=DateTime.Now.Year.ToString()%>
					<abbr title="realizzazione siti web">RSW</abbr> Studio s.n.c. - 
					<i class="fa-duotone fa-phone fa-fw"></i>Tel: +39 0425.460364<br>
					<i class="fa-duotone fa-location-dot-alt fa-fw"></i> Sede legale: Via G. Matteotti 42 - 45031 Arqu&agrave; Polesine (RO) | REA: RO - 148409 | P.I. 01349210292
					<i class="fa-duotone fa-location-dot-alt fa-fw"></i> Sede operativa: Via Danieli 57 - 45021 Badia Polesine (Rovigo)
		</div>
    </div>
	</footer>
	<script type="text/javascript">
	  jQuery.noConflict();
		jQuery(document).foundation();

    if (jQuery('#message').length){
      jQuery('#message').foundation('open');
    	window.setTimeout(function(){ jQuery("#message button.close-button").click(); }, 1500);
    }
  </script>	
</body>
</html>
