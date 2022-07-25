<% if (dtLogin.Rows[0]["UtentiGruppi_Annunci"].Equals(true) && strAzione!="new"){ %>
  <a name="foto"></a>
	<div class="grid-x grid-padding-x">
  	<div class="large-12 medium-12 small-8 cell">
		<div class="card">
		  <div class="card-divider">
			  <h2><i class="fa-duotone fa-image fa-lg fa-fw"></i>Immagini dell'annuncio gi&agrave; caricate (<%=GetFieldValue(dtAnnunci, "Annunci_NumeroFoto")%>)</h2>
		  </div>
		  <div class="card-section">
        <form name="azionidigruppo-formfoto" id="azionidigruppo-formfoto" class="form-azione" method="post" action="#">
	      <input type="hidden" name="Annunci_Ky" id="Annunci_Ky" value="<%=GetFieldValue(dtAnnunci, "Annunci_Ky")%>">
	      <input type="hidden" name="Aste_Ky" id="Aste_Ky" value="<%=GetFieldValue(dtAnnunci, "Aste_Ky")%>">
        <input type="hidden" name="azionidigruppo-ids" id="azionidigruppo-ids" class="azionidigruppo-ids" value="">
	      <input type="hidden" name="sorgente" id="sorgente" class="sorgente" value="scheda-annunci">
	      <input type="hidden" name="azione" id="azione" class="azione" value="">
				<input type="hidden" id="deletemultiplo" name="deletemultiplo" class="deletemultiplo" value="deletemultiplo">
		    <div class="grid-x grid-padding-x">
			      <div class="large-2 medium-3 small-4 cell">
			      	<input type="checkbox" id="selectallfoto" name="selectallfoto" /> Seleziona tutte
			      </div>
			      <div class="large-3 medium-3 small-8 cell end">
				        <div class="input-group">
									<span class="input-group-label">Se selezionati</span>
									<select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
				            <option value="">Azioni di gruppo</option>
				            <option value="delete" data-action="/admin/app/annunci/crud/elimina-foto-annunci.aspx">Elimina</option>
				          </select>
				          <div class="input-group-button">
				            <input type="submit" id="doactionfoto" class="button secondary doactionfoto" value="Applica">
				          </div>
				        </div>
			      </div>
		    </div>
		
        <div class="grid-x grid-padding-x small-up-2 medium-up-4 large-up-8">
		          <% 
		          string strTemp="";
		          Random rnd = new Random();
		          int intNumeroRandom = rnd.Next(1, 51);
		          for (int i = 1; i < 31; i++){
		            strTemp="Annunci_Foto" + i;
		            if (GetFieldValue(dtAnnunci, strTemp).Length>0){
		              Response.Write("<div class=\"cell\"><div class=\"thumbnail " + strTemp + "\"><a href=\"" + GetFieldValue(dtAnnunci, strTemp)  + "\" data-fancybox=\"images\"><img src=\"" + GetFieldValue(dtAnnunci, strTemp)  + "?id=" + i + "&random=" + intNumeroRandom + "\" height=\"150\" width=\"100\" style=\"width:150px;height:100px;\" data-caption=\"immagine annuncio\"></a></div>");
		              Response.Write("<div class=\"text-center\"><small>");
		              Response.Write("<input type=\"checkbox\" class=\"checkrow\" name=\"record" + GetFieldValue(dtAnnunci, "Annunci_Ky") + "\" id=\"recordfoto" + GetFieldValue(dtAnnunci, "Annunci_Ky") + "\" data-value=\""+ i + "\">");
		
									if (i>1){
		                Response.Write("<a href=\"/admin/app/annunci/crud/scheda-annunci-foto-predefinita.aspx?foto=" + i + "&Annunci_Ky=" + GetFieldValue(dtAnnunci, "Annunci_Ky") + "\"><i class=\"fa-duotone fa-image fa-fw\"></i>predefinita</a> - ");
		              }
		              Response.Write("<a href=\"/admin/app/annunci/crud/elimina-foto-annunci.aspx?azione=delete&foto=" + i + "&Annunci_Ky=" + GetFieldValue(dtAnnunci, "Annunci_Ky") + "\"><i class=\"fa-duotone fa-trash-can fa-fw\"></i>elimina</a>");
		              Response.Write("<a href=\"/admin/app/annunci/actions/ruota-foto-annunci.aspx?azione=modifica&foto=" + i + "&Annunci_Ky=" + GetFieldValue(dtAnnunci, "Annunci_Ky") + "\"><i class=\"fa-duotone fa-redo fa-fw\"></i>ruota</a>");
		              Response.Write("</small></div>");
		              Response.Write("</div>");
		              intNumeroFoto++;                                                                                                                                                                                                                                                                                                                                    
		            }
		          }
		          %>
		    </div>
	    	</form>

		    </div>
      </div> 
    </div>
  </div>
<% } %>
