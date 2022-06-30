
<footer id="footer">
	<div class="credits credits-spazio credits-usato">
		<div class="grid-container">
			<div class="grid-x grid-padding-x">
				<div class="large-10 medium-10 small-12 cell">
					<span class="testo-copyright">&copy; Copyright <span itemprop="copyrightYear">2009</span>-<%=DateTime.Now.Year%> <span itemprop="copyrightHolder">Spazio S.P.A.</span>  <i>Concessionaria Ufficiale Fiat, Abarth, Jeep, Lancia, Alfa Romeo, Peugeot, Opel, Hyundai, Toyota, Lexus, Citroen</i><br>
					Sede Legale: <span itemprop="address">Via Ala di Stura 84, 10148 Torino TO</span><br>
					Cap.Soc. &euro; 1.000.000,00 - P.IVA 07411090017 - C.F. 07411090017 - REA nr&deg; TO-891169</span>
				</div>
				<div class="large-2 medium-2 small-12 cell">
					<span class="testo-copyright">Made with <i class="fa-duotone fa-heart"></i> by <a href="https://www.rswstudio.it" rel="author" title="realizzazione siti web" target="_blank"><strong>RSW Studio</strong></a></span>
				</div>
			</div>
		</div>
	</div>
</footer>

<!--Cookie Popup-->
<div id="cookie-banner" style="display:none">
	<div class="grid-container">
		<div class="grid-x grid-padding-x align-middle">
			<div class="large-12 medium-12 small-12 cell text-center">
				Il nostro sito utilizza cookie tecnici necessari per il funzionamento del sito e
					di profilazione. <a href="https://spaziogroup.com/privacy/" rel="nofollow"><strong>Leggi
							Informativa</strong>.</a><a href="javascript:void(0)" id="btn-close-cookie"
						class="button tiny warning">Accetto</a>
			</div>
		</div>
	</div>
</div>
<!--fine Cookie Popup-->

<script src="https://cdnjs.cloudflare.com/ajax/libs/fancybox/3.5.7/jquery.fancybox.min.js" integrity="sha512-uURl+ZXMBrF4AwGaWmEetzrd+J5/8NRkWAvJx5sbPSSuOb0bZLqf+tOzniObO00BjHa/dD7gub9oCGMLPQHtQA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/wow/1.1.2/wow.min.js" integrity="sha512-Eak/29OTpb36LLo2r47IpVzPBLXnAMPAVypbSZiZ4Qkf8p/7S/XRG5xp7OKWPPYfJT6metI+IORkR5G8F900+g==" crossorigin="anonymous" referrerpolicy="no-referrer"></script> 
<script src="https://cdnjs.cloudflare.com/ajax/libs/slick-carousel/1.9.0/slick.min.js" integrity="sha512-HGOnQO9+SP1V92SrtZfjqxxtLmVzqZpjFFekvzZVWoiASSQgSr4cw9Kqd2+l8Llp4Gm0G8GIFJ4ddwZilcdb8A==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
<script type="text/javascript">
  function tracciaRemarketingFacebook(){
    //console.log("traccia");
    fbq('track', 'ViewContent', {
      content_type: 'vehicle',
      content_ids: ['<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>'],
      postal_code: '10148',
      country: 'Italy',
      make: '<%=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString()%>',
      model: '<%=dtVeicolo.Rows[0]["VeicoliModello_Titolo"].ToString()%>',
      year: '<%=Convert.ToDateTime(dtVeicolo.Rows[0]["Veicoli_DataPrimaImmatricolazione"]).Year%>',
      state_of_vehicle: 'Used',
      exterior_color: '<%=dtVeicolo.Rows[0]["VeicoliColore_Descrizione"].ToString().Trim().Replace("&","")%>',
      transmission: 'automatic',
      body_style: '<%=GetBodyStyle(dtVeicolo.Rows[0]["Veicoli_Carrozzeria"].ToString())%>',
      fuel_type: '<%=GetFuelType(dtVeicolo.Rows[0]["VeicoliCarburante_Descrizione"].ToString().Trim())%>',
      price: <%=strPrice.Replace(",","")%>,
      value: 1,
      currency: 'EUR'
    });
  }
</script>

<script type="text/javascript">
  jQuery.noConflict();
 console.log('start foundation'); 
  jQuery(document).foundation();
	jQuery(document).ready(function(){
	
	updateHistory('<%=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString().Trim().ToLower()%> <%=dtVeicolo.Rows[0]["VeicoliModello_Titolo"].ToString().Trim().ToLower()%> <%=dtVeicolo.Rows[0]["Veicoli_Targa"].ToString().Trim()%>');

	jQuery(".gallery").fancybox({
				animationEffect: "zoom-in-out",
				animationDuration: 500,
				loop: true,
				lang: "it"
		});
		
	jQuery('.autoplay').slick({
			slidesToShow: 4,
			slidesToScroll: 4,
			autoplay: true,
			autoplaySpeed: 2000,
			mobileFirst: true,
			arrows: false,
			dots: true,
			infinite: false,
			responsive: [
            {
				breakpoint: 1024,
				settings: {
					slidesToShow: 4,
					slidesToScroll: 4,
					infinite: true,
					dots: true
				}
			},
            {
				breakpoint: 600,
				settings: {
					slidesToShow: 4,
					slidesToScroll: 4
				}
			},
			{
				breakpoint: 300,
				settings: {
					slidesToShow: 1,
					slidesToScroll: 1
				}
			}
			]
			
		});
	});
	
	function show_sidebar(){
		document.getElementById('sidebar').style.visibility="visible";
	}
	
	function hide_sidebar(){
		document.getElementById('sidebar').style.visibility="hidden";
	}
	
	new WOW().init();

	/*Cookie Popup*/
	if (Cookies.get("adv-popup-cookie") != '1') {
		jQuery('#cookie-banner').fadeIn(1000);
		jQuery('.credits-spazio').css('margin', '0 0 4rem');
		//Set cookie
		Cookies.set("adv-popup-cookie", "1", { secure: true, sameSite: 'None' });
	}

	jQuery("#btn-close-cookie").click(function (e) {
		//Cancel the link behavior
		e.preventDefault();
		jQuery('#cookie-banner').fadeOut(500);
		jQuery('.credits-spazio').css('margin', '0');
	});
	/*Fine Cookie Popup*/	
</script>