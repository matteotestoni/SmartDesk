<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<br>
		<div class="card">
		  <div class="card-divider">
	      	<h2><i class="fa-duotone fa-signal fa-fw"></i> SEO</h2>
			</div>				
	  	<div class="card-section">
				<div class="grid-x grid-padding-x">
					<div class="small-4 medium-2 large-2 cell">
						<label class="large-text-right small-text-left top">PageSpeed Desktop</label>
					</div>
					<div class="small-8 medium-4 large-4 cell middle">
						<div class="progress success" role="progressbar" tabindex="0" aria-valuenow="<%=GetFieldValue(dtSitiWeb, "SitiWeb_PageSpeedScore")%>" aria-valuemin="0" aria-valuetext="PageSpeed Desktop" aria-valuemax="100">
							<span class="progress-meter" style="width:<%=GetFieldValue(dtSitiWeb, "SitiWeb_PageSpeedScore")%>%">
							<p class="progress-meter-text"><%=GetFieldValue(dtSitiWeb, "SitiWeb_PageSpeedScore")%>%</p>
							</span>
						</div>
					</div>
					<div class="small-4 medium-2 large-2 cell">
						<label class="large-text-right small-text-left top">PageSpeed Mobile</label>
					</div>
					<div class="small-8 medium-4 large-4 cell middle">
						<div class="progress success" role="progressbar" tabindex="0" aria-valuenow="<%=GetFieldValue(dtSitiWeb, "SitiWeb_PageSpeedScoreMobile")%>" aria-valuemin="0" aria-valuetext="PageSpeed Mobile" aria-valuemax="100">
							<span class="progress-meter" style="width:<%=GetFieldValue(dtSitiWeb, "SitiWeb_PageSpeedScoreMobile")%>%">
							<p class="progress-meter-text"><%=GetFieldValue(dtSitiWeb, "SitiWeb_PageSpeedScoreMobile")%>%</p>
							</span>
						</div>
					</div>
				</div>


				<div class="grid-x grid-padding-x">
						<div class="auto cell text-center">
						 	<small>
							  <a href="/admin/app/sitiweb/sitiweb-pagespeed.aspx?SitiWeb_Ky=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Ky")%>" class="funzione-small"><i class="fa-duotone fa-sync fa-fw"></i>Rileva</a> |
							  <a href="https://developers.google.com/speed/pagespeed/insights/?url=<%=GetFieldValue(dtSitiWeb, "SitiWeb_Url")%>" target="_blank" class="funzione-small">dettagli</a> |
							  <a href="#log" class="funzione-small"><i class="fa-duotone fa-history fa-fw"></i>storico</a> - 
								rilevato il <%=GetFieldValue(dtSitiWeb, "SitiWeb_PageSpeedData")%><br>
							</small>
					 </div>
				</div>
				<div class="grid-x grid-padding-x">
						<div class="auto cell"> <hr>
						</div>
				</div>
  		</div>
		</div>
	</div>
</div>
