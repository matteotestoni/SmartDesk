<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="elenco-contenuti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
		<title>News</title>
		<meta name="description" content="News"/>
		<meta name="robots" content="index,follow">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
    <style>
			.callout-scheda-foto {
			    padding: 0;
			    border: 0;
			    border-radius: 0;
			    color: #0a0a0a;
			    background-repeat: no-repeat;
			    background-position: center;
			}
			div.sfumatura-foto {
			    position: absolute;
			    bottom: 0;
			    width: 100%;
			    height: 192px;
			    background: -moz-linear-gradient(top, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 100%);
			    background: -webkit-linear-gradient(top, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 100%);
			    background: linear-gradient(to bottom, rgba(0, 0, 0, 0) 0%, rgba(0, 0, 0, 1) 100%);
			    filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#000000', endColorstr='#000000', GradientType=0);
			}			
			span.aggiungiwishlist {
			    color: #fff;
			    border: 0;
			    height: 45px;
			    display: block;
			    position: absolute;
			    top: 5px;
			    left: 15px;
			    padding-top: 10px;
			    font-weight: 600;
			    text-align: center;
			}			
			
				@media screen and (min-width: 40em){
					.callout-scheda-foto {
					    position: relative;
					    margin: 2rem 0 1rem 0;
					    background-size: cover;
					    height: 520px !important;
					    max-height: 520px;
					}			
				}
    </style>
  </head>
  <body>
	<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
				<div class="grid-x grid-padding-x">
          <hr style="margin: 0px 0 20px 0">
      	</div>
        <div class="grid-x grid-padding-x">
          <div class="xlarge-12 large-12 medium-12 small-12 cell">
              <h1><b>Suggerimenti</b> degli esperti</h1>
              <hr class="linea-blu"/>
            	<!-- #include file ="/frontend/base/contenuti/inc-elenco-contenuti.aspx" -->
          </main>                           
         </div>
       <p class="hide-for-small-only"><br><br></p> 
					<div class="js-off-canvas-exit"></div>
        </div>
			</div>
 	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
