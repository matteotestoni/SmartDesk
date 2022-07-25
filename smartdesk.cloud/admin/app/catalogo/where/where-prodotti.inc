<fieldset class="filtri fieldset hide hide-for-print" id="filtri" data-toggler=".hide">
	<legend>Cerca</legend>
		<form id="formRicerca" class="formRicerca" method="get" action="/admin/app/catalogo/elenco-prodotti.aspx">
      <input type="hidden" name="CoreModules_Ky" value="8" />
      <input type="hidden" name="CoreEntities_Ky" value="83" />
      <input type="hidden" name="CoreGrids_Ky" value="66" />
			<div class="grid-x grid-padding-x">                                  
				<div class="large-2 medium-2 small-4 cell">																	
					<label for="Prodotti_PubblicaWEB" class="large-text-right small-text-left middle">Pubblicato:</label>																
				</div>                                
				<div class="auto cell">                                  
					<select name="Prodotti_PubblicaWEB" id="Prodotti_PubblicaWEB" class="select">                                    
						<option value="">Tutti</option>                                    
						<option value="1">Pubblicati</option>                                    
						<option value="0">Non pubblicati</option>                                  
					</select>                    																
				</div>                             
				<div class="large-1 medium-2 small-4 cell">                                	
					<label for="Prodotti_InOfferta" class="large-text-right small-text-left middle">In offerta:
					</label>																
				</div>                                
				<div class="auto cell">																	
					<input type="checkbox" name="Prodotti_InOfferta" id="Prodotti_InOfferta" value="1">																
				</div>                              
				<div class="large-1 medium-2 small-4 cell">                                	
					<label for="Prodotti_InVetrina" class="large-text-right small-text-left middle">In vetrina:
					</label>																
				</div>                                
				<div class="auto cell">																	
					<input type="checkbox" name="Prodotti_InVetrina" id="Prodotti_InVetrina" value="1">																
				</div>                              
				<div class="large-1 medium-2 small-4 cell">                                	
					<label for="Prodotti_InPromozione" class="large-text-right small-text-left middle">In promozione:
					</label>																
				</div>                                
				<div class="auto cell">																	
					<input type="checkbox" name="Prodotti_InPromozione" id="Prodotti_InPromozione" value="1">																
				</div>                              
				<div class="large-1 medium-2 small-4 cell">                                	
					<label for="Prodotti_Outlet" class="large-text-right small-text-left middle">Outlet:
				</div>                                
				<div class="auto cell">
					<input type="checkbox" name="Prodotti_Outlet" id="Prodotti_Outlet" value="1">
				</div>                              
			</div>                              
			<div class="grid-x grid-padding-x">                                  
				<div class="large-2 medium-2 small-4 cell">                                	
					<label for="Prodotti_Codice" class="large-text-right small-text-left middle">ID prodotto:
				</div>                                
				<div class="auto cell">                                    
					<input type="text" name="Prodotti_Ky" id="Prodotti_Ky" size="30">                                
				</div>                              
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="Prodotti_Eancode" class="large-text-right small-text-left middle">Codice EAN:
				</div>                                
				<div class="auto cell">                                    
					<input type="text" name="Prodotti_Eancode" id="Prodotti_Eancode" size="30">                                
				</div>                              
			</div>                              
			<div class="grid-x grid-padding-x">                                  
				<div class="large-2 medium-2 small-4 cell">                                	
					<label for="Prodotti_Codice" class="large-text-right small-text-left middle">Codice prodotto:
				</div>                                
				<div class="auto cell">                                    
					<input type="text" name="Prodotti_Codice" id="Prodotti_Codice" size="30">                                
				</div>                              
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="Prodotti_CodicePadre" class="large-text-right small-text-left middle">Codice padre:
				</div>                                
				<div class="auto cell">                                    
					<input type="text" name="Prodotti_CodicePadre" id="Prodotti_CodicePadre" size="30">                                
				</div>                              
			</div>                              
			<div class="grid-x grid-padding-x">                                  
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="Prodotti_Titolo" class="large-text-right small-text-left middle">Titolo prodotto:
				</div>                                
				<div class="auto cell">                                    
					<input type="text" name="Prodotti_Titolo" id="Prodotti_Titolo" size="30">                                
				</div>                              
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="Prodotti_Descrizione" class="large-text-right small-text-left middle">Descrizione prodotto:
				</div>                                
				<div class="auto cell">                                    
					<input type="text" name="Prodotti_Descrizione" id="Prodotti_Descrizione" size="30">                                
				</div>                              
			</div>                              
			<div class="grid-x grid-padding-x">                                
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="ProdottiCategorie_Ky" class="large-text-right small-text-left middle">Categoria
				</div>                                
				<div class="auto cell">                                    
					<select name="ProdottiCategorie_Ky" id="ProdottiCategorie_Ky">									                  
						<!--#include file="/var/cache/ProdottiCategorie-options.htm"-->  									                
					</select>                                
				</div>                                
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="ProdottiTipo_Ky" class="large-text-right small-text-left middle">Tipo
				</div>                                
				<div class="auto cell">                                    
					<select name="ProdottiTipo_Ky" id="ProdottiTipo_Ky">									                  
						<!--#include file="/var/cache/ProdottiTipo-options.htm"-->  									                
					</select>                                
				</div>                                
			</div>                              
			<div class="grid-x grid-padding-x">                                
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="AliquoteIVA_Ky" class="large-text-right small-text-left middle">IVA
				</div>                                
				<div class="auto cell">									                
					<select name="AliquoteIVA_Ky" id="AliquoteIVA_Ky">									                  
						<option value=""></option>
            <!--#include file="/var/cache/AliquoteIVA-options.htm"-->  									                
					</select>                                
				</div>                                
				<div class="large-2 medium-2 small-4 cell">	                                
					<label for="ProdottiDisponibilita_Ky" class="large-text-right small-text-left middle">Disponibilit&agrave;
				</div>                                
				<div class="auto cell">						 			                
					<select name="ProdottiDisponibilita_Ky" id="ProdottiDisponibilita_Ky">									                  
						<!--#include file="/var/cache/ProdottiDisponibilita-options.htm"-->  									                
					</select>                                
				</div>                                
			</div>                              
			<div class="grid-x grid-padding-x">                                  
					<div class="large-12 medium-12 small-12 text-center">                                      
						<button type="submit" name="Submit" class="button success"><i class="fa-duotone fa-magnifying-glass fa-fw"></i>Cerca</button>                                  
					</div>                                
			</div>                              
    </form>
</fieldset>
