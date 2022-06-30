<div class="grid-x grid-padding-x">
	<div class="small-12 medium-4 large-4 cell end">
		<div class="card">
		  <div class="card-divider">
					<h2><i class="fa-duotone fa-calculator fa-lg fa-fw"></i>Totali del documento</h2>
			</div>
	  	<div class="card-section">
				<div class="grid-x grid-padding-x">
					<div class="large-4 medium-4 small-4 cell text-right">
						<label class="large-text-right small-text-left">Totale Righe:</label>
					</div>
					<div class="large-8 medium-8 small-8 cell text-left">
						&euro; <%=GetFieldValue(dtDocumenti, "Documenti_TotaleRighe_IT")%>
					</div>
				</div>

				<div class="grid-x grid-padding-x">
					<div class="large-4 medium-4 small-4 cell text-right">
						<label class="large-text-right small-text-left">Totale IVA:</label>
					</div>
					<div class="large-8 medium-8 small-8 cell text-left">
						&euro; <%=GetFieldValue(dtDocumenti, "Documenti_TotaleIVA_IT")%>
					</div>	    		
				</div>

				<div class="grid-x grid-padding-x">
					<div class="large-4 medium-4 small-4 cell text-right">
						<label class="large-text-right small-text-left alert">Totale Documento:</label>
					</div>
					<div class="large-8 medium-8 small-8 cell text-left">
						<span class="alert"><strong>&euro; <%=GetFieldValue(dtDocumenti, "Documenti_Totale_IT")%></strong></span>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>		
