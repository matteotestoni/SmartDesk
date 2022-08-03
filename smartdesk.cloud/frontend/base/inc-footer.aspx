					</div>
          <div class="js-off-canvas-exit"></div>
			  </div>
		</div>
<footer id="footer" class="footer">
  <div class="footer-top">
  	<div class="grid-container">
  		<div class="grid-x grid-padding-x align-middle">	
  			<div class="large-3 medium-3 small-12 cell footer-col">
  				<h4 class="title">Contattaci</h4>
  				<p><strong>Sede Operativa</strong><br>
  				Via Gabrio Serbelloni 4<br>
  				20122 Milano</p>
  				<p>
  				<i class="fa-duotone fa-fw fa-envelope"></i> info@linkbiz.it</p>
  			</div>
  			<div class="large-3 medium-3 small-12 cell footer-col">
  				<h4 class="title">Orari</h4>
  				<p><strong>Orari di apertura</strong><br>
  				Lun - Ven: 9.00 - 18.00<br>
  				Sab: 9.00 - 12.00<br>
  				Domenica chiuso</p>
  			</div>
  			<div class="large-3 medium-3 small-12 cell footer-col">
  				<h4 class="title">Informazioni</h4>
  				<ul class="menu vertical">
					<li><a href="/pag/chi-siamo.html" title="chi siamo">Chi siamo</a></li>
					<li><a href="/contatti/" title="contattaci" rel="nofollow">Contattaci</a></li>
        	<li><a href="/blog/"><i class="fa-duotone fa-fw fa-newspaper"></i> <span class="menu-label">News</span></a></li>
        	<li><a href="/frontend/base/contenuti/elenco-faq.aspx"><i class="fa-duotone fa-fw fa-circle-question"></i> <span class="menu-label">FAQ</span></a></li>
				</ul>
  			</div>   
  			<div class="large-3 medium-3 small-12 cell footer-col">
  				<h4 class="title">Note legali</h4>
  				<ul class="menu vertical">
  					<li><a href="/pag/condizioni-generali.html" title="condizioni generali" rel="nofollow">Condizioni generali</a></li>
  					<li><a href="/pag/privacy-policy.html" title="privacy" rel="nofollow">Privacy</a></li>
  					<li><a href="/pag/cookie-policy.html" title="Cookies" rel="nofollow">Cookies</a></li>
				 </ul>
  			</div>    			
  		</div>
  	</div>
  </div>
  <div class="footer-bottom">
		<div class="grid-container">
			<div class="grid-x align-middle">
				<div class="xlarge-12 large-12 medium-12 cell footer-col">			
					VALOREM S.r.l.s. - Via Gabrio Serbelloni 4 - 20122 Milano - C.F. e P.I. 10249950964 - REA : MI - 2516865			
					- <a href="https://www.rswstudio.it" target="_blank" title="realizzazione siti web">Credits</a>
				</div>
			</div>
		</div>
	</div>
</footer>
<% 
  System.Data.DataTable dtPopup = new System.Data.DataTable("Popup");
  dtPopup = Smartdesk.Sql.getTablePage("CMSPopup_Vw", null, "CMSPopup_Ky", "CMSPopup_PubblicaWEB=1", "CMSPopup_Ky DESC", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  if (dtPopup.Rows.Count>0){ %>
  <div class="reveal small text-center" id="popup<%=dtPopup.Rows[0]["CMSPopup_Codice"].ToString()%>" data-reveal data-animation-in="spin-in" data-animation-out="spin-out">
    <a href="<%=dtPopup.Rows[0]["CMSPopup_Url"].ToString()%>"><img src="<%=dtPopup.Rows[0]["CMSPopup_Foto"].ToString()%>"></a>
    <button class="close-button" data-close aria-label="Chiudi" type="button">
      <span aria-hidden="true">&times;</span>
    </button>
  </div>
  <script type="text/javascript">
  	jQuery(document).ready(function(){
      if (Cookies.get('popup<%=dtPopup.Rows[0]["CMSPopup_Codice"].ToString()%>') != 1) {
          Cookies.set('popup<%=dtPopup.Rows[0]["CMSPopup_Codice"].ToString()%>', '1', { path: '/',expires: 10,secure: true, sameSite: 'strict' })
          jQuery("#popup<%=dtPopup.Rows[0]["CMSPopup_Codice"].ToString()%>").foundation('open');
      }
  	});
  </script>
<% } %>
