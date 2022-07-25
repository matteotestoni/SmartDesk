<div id="sidebarveicoli">
<a name="formRicercaAuto"></a>
<form id="formRicercaAuto" name="formRicercaAuto" action="/veicoli/ricerca-veicoli.html" method="GET" target="_parent" data-sticky-container>
	<div class="sidebar panel wow fadeInRight orderby sticky shadow" data-sticky data-sticky-on="large" data-top-anchor="header:bottom" data-btm-anchor="footer:top" data-margin-top="2.7">
		<div class="grid-x grid-padding-x collapse">
			<div class="large-4 medium-4 small-4 cell align-middle text-center">
		      <label for="orderby">Ordina per:</label>
      </div>
			<div class="large-8 medium-8 small-8 cell text-center">
      		<select id="orderby" name="orderby">
      			<option value="prezzo" selected>Prezzo</option>
      			<option value="anno">Anno Imm.</option>
      			<option value="km">Km</option>
      			<option value="id">Ultime inserite</option>
      		</select>
      		<script type="text/javascript">
      			selectSet('orderby', '<%=strOrderby%>');
      		</script>
      </div>
    </div>

		<div class="grid-x grid-padding-x">
			<div class="large-6 medium-6 small-6 cell">
  			<input type="checkbox" name="bestprice" id="bestprice" value="1">
  			<label for="bestprice" class="labelBestPrice">&nbsp;</label>
  				<% if (strBestprice.Length>0){ %>
  					<script type="text/javascript">
  					jQuery("#bestprice").prop("checked", true);
  					</script>
  				<% } %>
			</div>
			<div class="large-6 medium-6 small-6 cell">
				<input type="checkbox" name="autoecologiche" id="autoecologiche" value="1">
				<label for="autoecologiche" data-tooltip title="Auto ibride elettriche gpl metano">Ecologiche<i class="fa-duotone fa-leaf text-primary fa-fw"></i></label>
					<% if (strAutoecologiche.Length>0){ %>
						<script type="text/javascript">
						jQuery("#autoecologiche").prop("checked", true);
						</script>
					<% } %>
			</div>
		</div>

		<div class="grid-x grid-padding-x">
			<div class="large-6 medium-6 small-6 cell">
				<input type="checkbox" name="topcar" id="topcar" value="1">
				<label for="topcar" data-tooltip title="Auto usate di alta gamma">Top Car</label>
					<% if (strTopcar.Length>0){ %>
						<script type="text/javascript">
						jQuery("#topcar").prop("checked", true);
						</script>
					<% } %>
			</div>
			<div class="large-6 medium-6 small-6 cell">
  			<input type="checkbox" name="neopatentati" id="neopatentati" value="1">
  			<label for="neopatentati" data-tooltip title="Auto adatte ai neopatentati">Neopatentati</label>
  				<% if (strNeopatentati.Length>0){ %>
  					<script type="text/javascript">
  					jQuery("#neopatentati").prop("checked", true);
  					</script>
  				<% } %>
			</div>
		</div>
		<div class="grid-x grid-padding-x">
			<div class="large-6 medium-6 small-6 cell">
  			<input type="checkbox" name="tags" id="tags" value="incentivi2021" class="hide">
  			<label for="tags" class="hide">Ecoincentivo</label>
  				<% if (strTags.Length>0){ %>
  					<script type="text/javascript">
  					jQuery("#tags").prop("checked", true);
  					</script>
  				<% } %>

			</div>
		</div>

		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell">
				<select name="VeicoliCategoria_Ky" id="VeicoliCategoria_Ky">
					<option value="" selected>Auto usate, km0, aziendali</option>
					<option value="4">Solo Auto usate</option>
					<option value="7">Solo Auto Km0</option>
					<option value="3" style="display:none;">Solo Auto Aziendali</option>
				</select>
				<script type="text/javascript">
					selectSet('VeicoliCategoria_Ky', '<%=strVeicoliCategoria_Ky%>');
				</script>
			</div>
		</div>

		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell">
				<select name="VeicoliCarburante_Ky" id="VeicoliCarburante_Ky" class="required">
			     <!--#include file="/var/cache/VeicoliCarburante-options.htm"--> 
				</select>
				<script type="text/javascript">
					selectSet('VeicoliCarburante_Ky', '<%=strVeicoliCarburante_Ky%>');
				</script>
			</div>
		</div>
      	<div class="grid-x grid-padding-x collapse">
      		<div class="large-12 medium-12 small-12 cell">
      			<select name="VeicoliNormativeEuro_Ky" id="VeicoliNormativeEuro_Ky">
          	  <!--#include file="/var/cache/VeicoliNormativeEuro-options.htm"--> 
      			</select>
      			<script type="text/javascript">
      				selectSet('VeicoliNormativeEuro_Ky', '<%=Request["VeicoliNormativeEuro_Ky"]%>');
      			</script>
      		</div>
      	</div>
		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell">
				<select name="VeicoliMarca_Ky" id="VeicoliMarca_Ky" data-count="<%=dtVeicoliMarca.Rows.Count%>" onchange="auto2021CaricaVeicoliModelloMarca('VeicoliMarca_Ky','VeicoliModello_Ky')">
					<option value="">Marca</option>
					<%
						for (i = 0; i < dtVeicoliMarca.Rows.Count; i++){
						Response.Write("<option value=\"" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Ky"].ToString().Trim() + "\">" + dtVeicoliMarca.Rows[i]["VeicoliMarca_Titolo"].ToString().Trim() + "</option>");
						}
					%>
				</select> 
				<script type="text/javascript">
					selectSet('VeicoliMarca_Ky', '<%=strVeicoliMarca_Ky%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell">
				<select name="VeicoliModello_Ky" id="VeicoliModello_Ky" data-count="<%=intNumRecordsModelli%>">
					<option value="">Modello</option>
					<%
					if (intNumRecordsModelli>0){
						strTemp="";
						for (i = 0; i < intNumRecordsModelli; i++){
                      if (dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString()!=strTemp){
          					   Response.Write("<option value=\"" + dtVeicoloModello2.Rows[i]["VeicoliModello_Ky"].ToString() + "\">" + dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString() + "</option>");
                      }
                      strTemp=dtVeicoloModello2.Rows[i]["VeicoliModello_Titolo"].ToString();
                    }
					}%>
				</select>
				<script type="text/javascript">
					selectSet('VeicoliModello_Ky', '<%=strVeicoliModello_Ky%><%=strVeicoliModello_DescrizioneHTML%>');
				</script>
			</div>
		</div>	

		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell">
				<select name="VeicoliCambio_Ky" id="VeicoliCambio_Ky" class=" required" placeholder="Cambio">
                  <!--#include file="/var/cache/VeicoliCambio-options.htm"--> 
				</select>
				<script type="text/javascript">
					selectSet('VeicoliCambio_Ky', '<%=strVeicoliCambio_Ky%>');
				</script>
			</div>
		</div>

		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell">
				<select name="Anno" id="Anno">
					<option selected="selected" value="">Anno imm. da</option>
					<%
					for (int i = DateTime.Now.Year-16; i <= DateTime.Now.Year; i++){
						Response.Write("<option value=\"" + i + "\">" + i + "</option>");
					}
					%>
				</select>
				<script type="text/javascript">
					selectSet('Anno', '<%=strAnno%>');
				</script>
			</div>
		</div>	
		<div class="grid-x grid-padding-x">
			<div class="large-12 medium-12 small-12 cell">
				<select class="prezzoa" id="Veicoli_Valorea" name="Veicoli_Valorea">
					<option value="">Prezzo fino a</option>
					<option value="4000">4.000 Euro</option>
					<option value="6000">6.000 Euro</option>
					<option value="8000">8.000 Euro</option>
					<option value="10000">10.000 Euro</option>
					<option value="12500">12.500 Euro</option>
					<option value="15000">15.000 Euro</option>
					<option value="20000">20.000 Euro</option>
					<option value="100000">Oltre 20.000 Euro</option>
				</select>
				<script type="text/javascript">
					selectSet('Veicoli_Valorea', '<%=strVeicoli_Valorea%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x">		
			<div class="large-12 medium-12 small-12 cell">
				<select class="kma" id="Veicoli_KMa" name="Veicoli_KMa">
					<option value="">KM fino a</option>
					<option value="2500">2.500 Km</option>
					<option value="5000">5.000 Km</option>
					<option value="10000">10.000 Km</option>
					<option value="15000">15.000 Km</option>
					<option value="20000">20.000 Km</option>
					<option value="25000">25.000 Km</option>
					<option value="30000">30.000 Km</option>
					<option value="35000">35.000 Km</option>
					<option value="40000">40.000 Km</option>
					<option value="45000">45.000 Km</option>
					<option value="50000">50.000 km</option>
					<option value="60000">60.000 Km</option>
					<option value="70000">70.000 Km</option>
					<option value="80000">80.000 Km</option>
					<option value="90000">90.000 Km</option>
					<option value="100000">100.000 Km</option>
					<option value="110000">110.000 Km</option>
					<option value="120000">120.000 Km</option>
					<option value="130000">130.000 Km</option>
					<option value="140000">140.000 Km</option>
					<option value="150000">150.000 Km</option>
					<option value="175000">175.000 Km</option>
					<option value="200000">200.000 Km</option>
					<option value="1000000">Oltre 200.000 Km</option>
				</select>
				<script type="text/javascript">
					selectSet('Veicoli_KMa', '<%=strVeicoli_KMa%>');
				</script>
			</div>
		</div>
	
		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell">
				<select name="VeicoliCarrozzeria_Ky" id="VeicoliCarrozzeria_Ky" class=" required">
			 <!--#include file="/var/cache/VeicoliCarrozzeria-options.htm"--> 
				</select>
				<script type="text/javascript">
					selectSet('VeicoliCarrozzeria_Ky', '<%=strVeicoliCarrozzeria_Ky%>');
				</script>
			</div>
		</div>
		<div class="grid-x grid-padding-x collapse">
			<div class="large-12 medium-12 small-12 cell text-center">
				<input type="hidden" name="fromricerca" id="fromricerca" value="1">
				<input type="hidden" name="VeicoliTipo_Ky" id="VeicoliTipo_Ky" value="1">
				<button type="submit" class="button radius expanded secondary"><i class="fa-duotone fa-search fa-fw fa-lg"></i>&nbsp;&nbsp;CERCA</button>
			</div>
		</div>	
	</div>
</form>
</div>