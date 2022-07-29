<p class="label secondary recordqty"><span class="grassetto text-primary"><%=intNumRecordsVeicoli %></span> auto disponibili</p>
<% if(intNumRecordsVeicoli == 0){ %>
	<section class="section">
		<div class="callout small">
			<i class="fa-solid fa-info-circle fa-fw fa-pull-left fa-2x"></i>
			<h5>Ops, nessun risultato per le tua ricerca!</h5>
			<p>Prova a modificare o <a href="/">cancellare</a> i filtri impostati.</p>
		</div>
	</section>
	<!--#include file="/frontend/base/veicoli/inc-autoperte.aspx"-->

<% } %>
<asp:Label ID="PaginaSopra" runat="server"></asp:Label>
<div class="elenco-auto">
	<% for (i = 0; i < dtVeicoli.Rows.Count; i++){
		strScheda=GetUrlScheda(dtVeicoli);
		strAlt=dtVeicoli.Rows[i]["VeicoliMarcaSpazioGroup_Marca"].ToString().Trim() + " " + dtVeicoli.Rows[i]["VeicoliModelloSpazioGroup_Modello"].ToString().Trim();
		strAlt+=" " + dtVeicoli.Rows[i]["VeicoliCategoria_DescrizioneWEB"].ToString() + " a " + dtVeicoli.Rows[i]["Comuni_Comune"].ToString();
		if (dtVeicoli.Rows[i]["Veicoli_Foto1"].ToString().Trim().Length>0){
			strImg=dtVeicoli.Rows[i]["Veicoli_Foto1"].ToString().Trim();
		}else{
			strImg="https://picsum.photos/seed/" + dtVeicoli.Rows[i]["Veicoli_Ky"].ToString() + "/800/600.webp";
		}
	%>
	<div class="card panelofferta <% if(dtVeicoli.Rows[i]["Veicoli_BestPrice"].Equals(true)){ %>bestprice<% } %>" id="veicolo<%=dtVeicoli.Rows[i]["Veicoli_Targa"].ToString()%>" itemprop="itemOffered" itemscope itemtype="http://schema.org/Car">
		<div class="corner-ribbon">
    <% if(dtVeicoli.Rows[i]["Veicoli_BestPrice"].Equals(true)){ %><span class="bestpriceribbon"></span><br><% } %>
		<% if(dtVeicoli.Rows[i]["VeicoliCarburante_Ecologico"].Equals(true)){ %><span class="ecoribbon">Eco <i class="fa-duotone fa-leaf text-primary"></i></span><br><% } %>
		<% if(dtVeicoli.Rows[i]["VeicoliCategoria_Ky"].ToString() == "7"){ %><span class="km0ribbon">KM 0</span><br><% } %>
		<% if(dtVeicoli.Rows[i]["Veicoli_Premium"].Equals(true)){ %><span class="topcarribbon">Topcar</span><br><% } %>
		<% if(dtVeicoli.Rows[i]["Veicoli_Neopatentati"].Equals(true)){ %><span class="neopatentatiribbon">Neopatentati</span><br><% } %>
		<%
		System.Data.DataTable dtVeicoliOfferteAuto;
		string srtWhereTemp="VeicoliOfferte_DataInizio<=GETDATE() AND VeicoliOfferte_DataFine>GETDATE() AND VeicoliOfferte_Abilitata=1 AND Veicoli_Targa='" + dtVeicoli.Rows[i]["Veicoli_Targa"].ToString().Trim() + "'";
		dtVeicoliOfferteAuto = Smartdesk.Sql.getTablePage("VeicoliOfferteAuto_Vw", null, "VeicoliOfferteAuto_Ky", srtWhereTemp, "VeicoliOfferte_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

		if (dtVeicoliOfferteAuto.Rows.Count>0 && dtVeicoliOfferteAuto.Rows[0]["VeicoliOfferte_Mostraetichetta"].Equals(true)){
			Response.Write("<span class=\"promoribbon\" style=\"color:" + dtVeicoliOfferteAuto.Rows[0]["VeicoliOfferte_ColoreTesto"].ToString() + ";background-color:" + dtVeicoliOfferteAuto.Rows[0]["VeicoliOfferte_ColoreSfondo"].ToString() + "\">");
			Response.Write(dtVeicoliOfferteAuto.Rows[0]["VeicoliOfferte_Etichetta"].ToString() + "</span><br>");		
		}	

		string srtWhereTemp2="equipment like '%IMPIANTO GPL Landi%' AND externalId = '" + dtVeicoli.Rows[i]["Veicoli_Riferimento"].ToString() + "'";
		dtVeicoliOptionals = Smartdesk.Sql.getTablePage("VehiclesEquipments", null, "VehiclesEquipments_Ky", srtWhereTemp2, "VehiclesEquipments_Ky", 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
		if (dtVeicoliOptionals.Rows.Count>0){
			Response.Write("<span class=\"landiribbon\">Impianto GPL Landi</span>");
		}
		%>
		</div>

		<div class="grid-x grid-padding-x collapse clickable">
			<div class="large-4 medium-4 small-12 cell panelofferta-img">
				<a href="<%=strScheda%>" title="<%=strAlt%>">
					<img src="<%=strImg%>" alt="<%=strAlt%>" class="panelofferta-img-img lazyload" itemprop="image" loading="lazy" />
				</a>
				<a href="<%=strScheda%>">
					<span class="counter"><i class="fa-duotone fa-fw fa-camera"></i> <%=GetNumeroFotoVeicolo(dtVeicoli.Rows[i])%></span>
				</a>
			</div>
			<div class="large-8 medium-8 small-12 cell">
    		<div class="panelofferta-links text-right">
    			<% if (strPreferitiCookie.Contains(dtVeicoli.Rows[i]["Veicoli_Ky"].ToString())){ %>
    				<a href="#" onclick="aggiungiPreferiti(<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>);return false;" data-tooltip title="Veicolo nei preferiti"><i id="iconapreferiti<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>" class="fa-solid fa-heart fa-fw" style="color:red"></i></a>
    			<% }else{ %>
    				<a href="#" onclick="aggiungiPreferiti(<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>);return false;"><i id="iconapreferiti<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>" class="fa-duotone fa-heart fa-fw"></i></a>
    			<% } %>
    			<% if (strConfrontoCookie.Contains(dtVeicoli.Rows[i]["Veicoli_Ky"].ToString())){ %>
    				<a href="#" onclick="aggiungiConfronto(<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>);return false;" data-tooltip title="Veicolo nel confronto"><i id="iconaconfronto<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>" class="fa-solid fa-plus-square fa-fw"></i></a>
    			<% }else{ %>
    				<a href="#" onclick="aggiungiConfronto(<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>);return false;"><i id="iconaconfronto<%=dtVeicoli.Rows[i]["Veicoli_Ky"].ToString()%>" class="fa-duotone fa-plus-square fa-fw"></i></a>
    			<% } %>
    		</div>
				<div class="grid-x align-middle">
					<div class="text-left large-6 medium-12 small-12 cell">
						<img src="https://cdn.spaziogroup.com/spazio2019/img/marchi/60x60/logo-<%=dtVeicoli.Rows[i]["VeicoliMarca_Titolo"].ToString().Trim().ToLower()%>.png" alt="auto usate <%=dtVeicoli.Rows[i]["VeicoliMarca_Titolo"].ToString().Trim().ToLower()%>" class="logo float-left lazyload" style="margin-right:7px;" width="60" height="60" loading="lazy">
						<div itemprop="name" class="float-left">
						<%
							Response.Write("<h4 class=\"item-auto-title\">" + dtVeicoli.Rows[i]["VeicoliMarca_Titolo"].ToString().Trim() + " ");
							Response.Write(dtVeicoli.Rows[i]["VeicoliModello_Titolo"].ToString().Trim() + "</h4>");
							Response.Write("<span class=\"item-auto-version\">" + dtVeicoli.Rows[i]["Veicoli_Allestimento"].ToString().Trim() + "</span>");
						%>
						</div>
					</div>
					<div class="panelofferta-price text-left small-text-center large-6 medium-12 small-12 cell">
						<span class="prezzo <% if(dtVeicoli.Rows[i]["Veicoli_BestPrice"].Equals(true)){ %>bestprice<% } %>">
						<%
						if ((dtVeicoli.Rows[i]["Veicoli_ValoreNascondi"].Equals(true)) || (dtVeicoli.Rows[i]["Veicoli_Valore"].Equals(null))){
							Response.Write("Trattativa riservata");
						}else{ 
							if (dtVeicoliOfferteAuto.Rows.Count>0){
								if ((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreTagliato"]>0){
									Response.Write("<span class=\"oldprice\">&euro; " + ((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreTagliato"]).ToString("N0", ci) + "</span>");
									Response.Write("<span class=\"discount\">-&euro; " + (((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreTagliato"])-((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"])).ToString("N0", ci) + "* </span>");
									Response.Write("<span class=\"price\">&euro; " + ((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]).ToString("N0", ci) + "</span>");											
								}else{
									if ((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]!=(decimal)dtVeicoli.Rows[i]["Veicoli_Valore"]){
										Response.Write("<span class=\"price\">&euro; " + ((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"]).ToString("N0", ci) + "</span>");
										Response.Write("<span class=\"oldprice\">&euro; " + ((decimal)dtVeicoli.Rows[i]["Veicoli_Valore"]).ToString("N0", ci) + "</span>");
										Response.Write("<span class=\"discount\">-&euro; " + (((decimal)dtVeicoli.Rows[i]["Veicoli_Valore"])-((decimal)dtVeicoliOfferteAuto.Rows[0]["Veicoli_ValoreInOfferta"])).ToString("N0", ci) + "* </span>");
									}else{
										if (dtVeicoli.Rows[i]["Veicoli_Valore"]!=null && dtVeicoli.Rows[i]["Veicoli_Valore"].ToString().Length>0){
											Response.Write("&euro; " + ((decimal)dtVeicoli.Rows[i]["Veicoli_Valore"]).ToString("N0", ci));
										}
									}
								}
							}else{
                if (dtVeicoli.Rows[i]["Veicoli_ValoreIniziale"]!=null && (decimal)dtVeicoli.Rows[i]["Veicoli_ValoreIniziale"]-(decimal)dtVeicoli.Rows[i]["Veicoli_Valore"]>=500){
									Response.Write("<span class=\"oldprice bestprice\">&euro; " + ((decimal)dtVeicoli.Rows[i]["Veicoli_ValoreIniziale"]).ToString("N0", ci) + "</span>");
									Response.Write("<span class=\"discount bestprice\">-&euro; " + (((decimal)dtVeicoli.Rows[i]["Veicoli_ValoreIniziale"])-((decimal)dtVeicoli.Rows[i]["Veicoli_Valore"])).ToString("N0", ci) + " </span>");
									Response.Write("<span class=\"price bestprice\">&euro; " + ((decimal)dtVeicoli.Rows[i]["Veicoli_Valore"]).ToString("N0", ci) + "</span>");											
                }else{
                  if (dtVeicoli.Rows[i]["Veicoli_Valore"]!=null && dtVeicoli.Rows[i]["Veicoli_Valore"].ToString().Length>0){
										Response.Write("&euro; " + ((decimal)dtVeicoli.Rows[i]["Veicoli_Valore"]).ToString("N0", ci));
									}
                }
							}
						}                        
						%>
						</span> <small>IVA incl.</small><br>
					</div>										
        </div>
				<hr>
        <div class="grid-x grid-padding-x small-up-3 medium-up-3 large-up-6">
					<div class="cell text-center">
						<i class="fa-duotone fa-gauge fa-fw fa-lg"></i><br>
            <% if (dtVeicoli.Rows[i]["Veicoli_KM"].ToString().Length>0){
							Response.Write(dtVeicoli.Rows[i]["Veicoli_KM"].ToString().Trim());
						}else{
							Response.Write("0");
						} %>
						km
					</div>
					<div class="cell text-center">
						<i class="fa-duotone fa-calendar-days fa-fw fa-lg"></i><br>
						<%=dtVeicoli.Rows[i]["Veicoli_DataPrimaImmatricolazione"].ToString()%>
					</div>
					<% 
					if (dtVeicoli.Rows[i]["VeicoliCarburante_Ecologico"].Equals(true)){ 
						strClass="detail-alimentazione-eco";
					}else{
						strClass="";
					}
					%>
					<div class="cell text-center" itemprop="fuelType">
						<i class="fa-duotone fa-gas-pump fa-fw fa-lg"></i><br>
						<%=dtVeicoli.Rows[i]["VeicoliCarburante_Descrizione"].ToString().Trim()%>
						<% 
							if (dtVeicoli.Rows[i]["VeicoliNormativeEuro_Descrizione"].ToString().Trim().Length>0){
								if (dtVeicoli.Rows[i]["VeicoliNormativeEuro_Descrizione"].ToString().ToLower()!="n/d"){
									Response.Write("<span class=\"normativa\">" + dtVeicoli.Rows[i]["VeicoliNormativeEuro_Descrizione"].ToString().Trim() + "</span>");
								}
							} 
						%>
					</div>
					<div class="cell text-center" itemprop="numberOfDoors">
						<i class="fa-duotone fa-car fa-fw fa-lg"></i><br>
						<%
						if (dtVeicoli.Rows[i]["Veicoli_NumeroPorte"].ToString().Length>0){
							Response.Write(dtVeicoli.Rows[i]["Veicoli_NumeroPorte"].ToString().Trim());
						}else{
							Response.Write("n/d");
						} %>
					</div>
					<div class="cell text-center" itemprop="vehicleTransmission">
						<i class="fa-duotone fa-gear fa-fw fa-lg"></i><br>
						<%=dtVeicoli.Rows[i]["VeicoliCambio_Descrizione"].ToString()%>
					</div>
					<div class="cell text-center" itemprop="vehicleIdentificationNumber">
						<i class="fa-duotone fa-barcode fa-fw fa-lg"></i><br>
						<% Response.Write("rif: " + dtVeicoli.Rows[i]["Veicoli_Riferimento"].ToString() + "");%>
					</div>
				</div>

        <div class="grid-x grid-padding-x">
    			<div class="large-12 medium-12 small-12 cell text-right">
					  <br><a href="<%=strScheda%>" class="button warning radius">VEDI DETTAGLI <i class="fa-duotone fa-angle-right fa-fw"></i></a>
          </div>
				</div>
			</div>
	</div>
</div>	
	<% } %>
<asp:Label ID="PaginaSotto" runat="server"></asp:Label>
