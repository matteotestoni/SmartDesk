<a name="contatti"></a>
<section class="section-blu" id="contatti">
    <div class="grid-container">
        <div class="grid-x grid-padding-x">
            <div class="large-12 medium-12 small-12 cell text-center">
                <% if (strDipendentifca!=null && strDipendentifca=="1"){ %>
                <h5 class="text-center" style="color:#ffffff"><strong>Compila il modulo</strong> per ricevere subito il
                    tuo sconto dedicato ai dipendenti FCA e famigliari dipendenti FCA. <strong
                        style="color:#FFEB3B">Senza impegno!</strong></h5>
                        <p> <span style="background-color:#FF0; color:#000; padding:10px;"> &nbsp;Per questa vettura <%=dtVeicolo.Rows[0]["VeicoliModello_Tipo"].ToString().Trim().ToLower()%> il
                        <strong>BUONO SCONTO</strong> a TE riservato &egrave; di
                        <strong><%
              						switch(dtVeicolo.Rows[0]["VeicoliModello_Tipo"].ToString().Trim().ToLower()){
              						case "piccola":
              						Response.Write("<span style=\"font-size:1.5rem;\">300&euro;</span>");
              						break;
              						case "media":
              						Response.Write("<span style=\"font-size:1.5rem;\">500&euro;</span>");
              						break;
              						case "grande":
              						Response.Write("<span style=\"font-size:1.5rem;\">700&euro;</span>");
              						break;
              						}
              					%>
                        </strong>
                        &nbsp;
                    </span>
                </p>
                <br>
                <% } else{ %>
                <div class="grid-x grid-padding-x row-title">
                    <div class="large-12 medium-12 small-12 cell">
                        <hgroup>
                            <h3><span class="grassetto">Sei interessato a questa auto?</span></h3>
                            <h4><strong>Compila il modulo</strong> per essere ricontattato <strong style="color:#FFEB3B">senza impegno!</strong> <strong style="color:#ffffff">Risposte in 24 ore!</strong></h4>
                        </hgroup>
                        <span class="linea-divisoria"><span></span></span>
                    </div>
                </div>
                <% } %>
                     <form action="/form/form-contatti-auto.aspx" name="contattavenditore" id="contattavenditore" method="post" data-abide novalidate>
                        <input type="hidden" id="proteggi" name="proteggi" value="" />
                        <input type="hidden" id="foo" name="foo" />
                        <input type="hidden" id="utm_source" name="utm_source" value="<%=strUtm_source%>">
                        <input type="hidden" id="utm_source" name="utm_medium" value="<%=strUtm_medium%>">
                        <input type="hidden" id="utm_source" name="utm_campaign" value="<%=strUtm_campaign%>">
                        <input type="hidden" id="utm_source" name="utm_term" value="<%=strUtm_term%>">
                        <input type="hidden" id="utm_source" name="utm_content" value="<%=strUtm_content%>">
                        <div data-abide-error class="alert callout" style="display: none;">
                            <p><i class="fa-duotone fa-info-circle fa-fw fa-lg"></i> Ci sono errori nel modulo. Compila tutti i campi.</p>
                        </div>
                        <div class="grid-x grid-padding-x">
                            <div class="large-2 medium-2 small-12 cell">
                                <label class="large-text-right small-text-left" for="nome"
                                    style="padding-top:.2rem;">Vorrei</label>
                            </div>
                            <div class="large-8 medium-8 small-12 cell">
                                <div class="grid-x grid-padding-x">
                                    <div class="large-4 medium-4 small-12 cell text-left">
                                        <input id="motivo" type="radio" name="motivo" value="informazioni" checked="checked">
                                        <label for="motivo" class="motivo-label"><i class="fa-duotone fa-fw fa-info-circle"></i> Ricevere maggiori informazioni</label>
                                    </div>
                                    <div class="large-4 medium-4 small-12 cell text-left">
                                        <input id="motivo" type="radio" name="motivo" value="testdrive">
                                        <label for="motivo" class="motivo-label"><i class="fa-duotone fa-fw fa-car"></i> Prenotare un test drive</label>
                                    </div>
                                    <div class="large-4 medium-4 small-12 cell end text-left">
                                        <input id="motivo" type="radio" name="motivo" value="soddisfatto">
                                        <label for="motivo" class="motivo-label"><i class="fa-duotone fa-fw fa-thumbs-up"></i> Soddisfatto o Cambia Auto</label>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="grid-x grid-padding-x">
                            <div class="large-2 medium-2 small-12 cell">
                            </div>
                            <div class="large-8 medium-8 small-12 cell">                              
                                
                                
                                <div id="valutazioneauto">
                                  <ul class="accordion" data-accordion data-allow-all-closed="true">
                                    <li class="accordion-item" data-accordion-item>
                                      <a href="#" class="accordion-title">Hai un usato da permutare? clicca qui</a>
                                        <div class="accordion-content" data-tab-content>
                                          <ul class="menu vertical text-left"> 
                                            <li><i class="fa-duotone fa-check fa-fw"></i>Inserisci targa e km della tua vettura</li>
                                            <li><i class="fa-duotone fa-check fa-fw"></i>Seleziona l'allestimento ed inserisci i dati mancanti</li>
                                            <li><i class="fa-duotone fa-check fa-fw"></i>Scopri la quotazione del tuo usato!</li>
                                          </ul>
                                          <br>

                                          <div class="grid-x grid-padding-x">
                                              <div class="large-4 medium-4 small-6 cell">
                                                  <div class="input-group">
                                                    <span class="input-group-label hide-for-small-only">Km</span>
                                                    <input type="text" class="input-group-field targa" id="chilometri" name="chilometri" value="" size="40" maxlength="7" minlength="7" placeholder="Km *">
                                                  </div>                          
                                              </div>
                                              <div class="large-6 medium-6 small-6 cell">
                                                  <div class="input-group">
                                                    <span class="input-group-label hide-for-small-only">Targa</span>
                                                    <input type="text" class="input-group-field targa" id="targa" name="targa" value="" size="40" maxlength="7" minlength="7" placeholder="Targa *">
                                                    <div class="input-group-button">
                                                      <button type="button" class="button warning small" id="cerca-targa-usato" name="cerca-targa-usato" onclick="cercatargausato();">Cerca <i class="fa-duotone fa-search fa-fw"></i></button>
                                                    </div>
                                                  </div>                          
                                              </div>
                                          </div>                                              


                                          <p class="help-text text-left" style="color:#ffffff"><i class="fa-duotone fa-info-circle fa-fw"></i> Digita km e targa senza spazi vuoti (es. AA000AA).</p>
                                          
                                          <i class="fa-duotone fa-spinner fa-fw fa-lg fa-spin hide" id="loadingIcon"></i>
                                          <fieldset id="ricercapermuta" class="fieldset text-left hide">
                                            <legend>Abbinati alla targa inserita, il nostro database ha estratto i seguenti dati</legend>
                                            <div id="models" class="text-left"></div>
                                            <div id="nonricordoallestimento"></div>
                                            <div id="modeltextlabel"></div>
                                          </fieldset>
                                          <p id="errortextlabel"></p>
                                          <fieldset id="datiautopermuta" class="fieldset text-left hide">
                                            <legend>I dati della tua auto: Correggi i dati ove necessario oppure inseriscili se sono omessi</legend>
                                              <input type="hidden" name="tipo_veicolo" id="tipo_veicolo" value="auto">
                                              <input type="hidden" name="telaio" id="telaio" value="">
                                              <input type="hidden" name="codice_eurotax" id="codice_eurotax" value="">
                                              <input type="hidden" name="quotazione_eurotax_blu" id="quotazione_eurotax_blu" value="">
                                              <input type="hidden" name="quotazione_eurotax_blu_km" id="quotazione_eurotax_blu_km" value="">
                                              <input type="hidden" name="quotazione_eurotax_blu_totale" id="quotazione_eurotax_blu_totale" value="">
                                              <input type="hidden" name="quotazione_eurotax_giallo" id="quotazione_eurotax_giallo" value="">
                                              <input type="hidden" name="quotazione_eurotax_giallo_km" id="quotazione_eurotax_giallo_km" value="">
                                              <input type="hidden" name="quotazione_eurotax_giallo_totale" id="quotazione_eurotax_giallo_totale" value="">                                              
                                              
                                              <div class="grid-x grid-padding-x">
                                                  <div class="large-2 medium-2 small-4 cell">
                                                      <label class="large-text-right small-text-left" for="brand">Marca*</label>
                                                  </div>
                                                  <div class="large-4 medium-4 small-8 cell">
                                                      <input type="text" name="brand" id="brand" placeholder="Marca">
                                                  </div>
                                                  <div class="large-2 medium-2 small-4 cell">
                                                      <label class="large-text-right small-text-left" for="model">Modello*</label>
                                                  </div>
                                                  <div class="large-4 medium-4 small-8 cell">
                                                      <input type="text" name="model" id="model" placeholder="Modello">
                                                  </div>
                                              </div>
                                              <div class="grid-x grid-padding-x">
                                                  <div class="large-2 medium-2 small-4 cell">
                                                      <label class="large-text-right small-text-left" for="brand">Allestimento</label>
                                                  </div>
                                                  <div class="large-4 medium-4 small-8 cell">
                                                      <input type="text" name="allestimento" id="allestimento" placeholder="Allestimento">
                                                  </div>
                                              </div>
                                              <div class="grid-x grid-padding-x">
                                                  <div class="large-2 medium-2 small-4 cell">
                                                      <label class="large-text-right small-text-left" for="alimentazione">Alimentazione*</label>
                                                  </div>
                                                  <div class="large-4 medium-4 small-8 cell">
                                                      <select name="alimentazione" id="alimentazione"><option value="">---</option><option value="Benzina">Benzina</option><option value="Diesel">Diesel</option><option value="Elettrica">Elettrica</option><option value="GPL">GPL</option><option value="Ibrido">Ibrido</option><option value="Metano">Metano</option><option value="Altro">Altro</option></select>                                                  
                                                  </div>
                                                  <div class="large-2 medium-2 small-4 cell">
                                                      <label class="large-text-right small-text-left" for="stato">Stato*</label>
                                                  </div>
                                                  <div class="large-4 medium-4 small-8 cell">
                                                      <select name="stato" id="stato"><option value="">---</option><option value="Scarso">Scarso</option><option value="Medio">Medio</option><option value="Buono">Buono</option><option value="Ottimo">Ottimo</option></select>
                                                  </div>
                                              </div>
                                              
                                              <div class="grid-x grid-padding-x">
                                                  <div class="large-2 medium-2 small-4 cell">
                                                      <label class="large-text-right small-text-left" for="data-immatricolazione">Data immatricolazione*</label>
                                                  </div>
                                                  <div class="large-4 medium-4 small-8 cell">
                                                      <input type="text" name="data-immatricolazione" id="data-immatricolazione" placeholder="Immatricolazione">
                                                      <span class="form-error">Obbligatorio.</span>
                                                  </div>
                                              </div>                                              
                                          </fieldset>
                                        </div>
                                    </li>
                                  </ul>
                                </div>
                                
                                                              
                            </div>
                        </div>

                        <div class="grid-x grid-padding-x">
                            <div class="large-2 medium-2 small-3 cell hide-for-small-only">
                                <label class="large-text-right small-text-left" for="nome">Nome*</label>
                            </div>
                            <div class="large-3 medium-3 small-6 cell">
                                <input name="nome" type="text" id="nome" placeholder="Il tuo nome"
                                    required="required" /><span class="form-error">Obbligatorio.</span>
                            </div>
                            <div class="large-2 medium-2 small-3 cell hide-for-small-only">
                                <label class="large-text-right small-text-left" for="cognome">Cognome*</label>
                            </div>
                            <div class="large-3 medium-3 small-6 cell end">
                                <input name="cognome" type="text" placeholder="Il tuo cognome" id="cognome"
                                    required="required" /><span class="form-error">Obbligatorio.</span>
                            </div>
                        </div>
                        <div class="grid-x grid-padding-x">
                            <div class="large-2 medium-2 small-3 cell hide-for-small-only">
                                <label class="large-text-right small-text-left" for="telefono">Telefono*</label>
                            </div>
                            <div class="large-3 medium-3 small-6 cell">
                                <input name="telefono" type="text" id="telefono" placeholder="Il tuo numero di telefono"
                                    required="required" /><span class="form-error">Obbligatorio.</span>
                            </div>
                            <div class="large-2 medium-2 small-3 cell hide-for-small-only">
                                <label class="large-text-right small-text-left" for="email">Email*</label>
                            </div>
                            <div class="large-3 medium-3 small-6 cell end">
                                <input name="email" type="text" id="email" placeholder="La tua email"
                                    required="required" /><span class="form-error">Obbligatorio.</span>
                            </div>
                        </div>
    
                        <div class="grid-x grid-padding-x align-middle">
                            <div class="large-2 medium-2 small-4 cell hide-for-small-only">
                                <label  for="orariodicontatto" class="large-text-right small-text-left" for="privacy">A che ora vorresti essere contattato? *</label>
                            </div>
                            <div class="large-3 medium-3 small-6 cell end text-left">
                                <select name="orariodicontatto" aria-required="true" aria-invalid="false" required="required">
                                    <option value="" selected>Orario di contatto</option>
                                    <option value="Mattino 9-12">Mattino 9-12</option>
                                    <option value="Pausa pranzo 12-14">Pausa pranzo 12-14</option>
                                    <option value="Pomeriggio 14-18">Pomeriggio 14-18</option>
                                    <option value="Sera dopo 18">Sera dopo le 18</option>
                                </select>
                                <small class="form-error">E' obbligatorio selezionare un orario di contatto</small>
                            </div>
                            <div class="large-2 medium-2 small-4 cell hide-for-small-only">
                                <label  for="metodocontatto" class="large-text-right small-text-left" for="privacy">Come vorresti essere contattato? *</label>
                            </div>
                            <div class="large-3 medium-3 small-6 cell end text-left">
                                <select name="metodocontatto" aria-required="true" aria-invalid="false" required="required">
                                    <option value="Qualsiasi modo" selected>Modalit&agrave; di contatto</option>
                                    <option value="Chat">Chat</option>
                                    <option value="Telefono">Telefono</option>
                                    <option value="Videochiamata">Videochiamata</option>
                                    <option value="Email">Email</option>
                                </select>
                                <small class="form-error">E' obbligatorio accettare specificar come essere ricontattati</small>
                            </div>
                        </div>
    
                        <div class="grid-x grid-padding-x">
                            <div class="large-2 medium-2 small-3 cell hide-for-small-only">
                                <label class="large-text-right small-text-left" for="messaggio">Messaggio</label>
                            </div>
                            <div class="large-8 medium-8 small-12 cell end">
    
                                <%  if (dtVeicoloOfferteAuto.Rows.Count>0){ %>
                                <textarea name="messaggio" rows="2" id="messaggio"
                                    placeholder="Eventuali richieste"><%=dtVeicoloOfferteAuto.Rows[0]["VeicoliOfferte_Titolo"].ToString().Trim()%></textarea>
                                <%  }else{ %>
                                <textarea name="messaggio" rows="2" id="messaggio"
                                    placeholder="Eventuali richieste"></textarea>
                                <% } %>
    
                            </div>
                        </div>
    
                        <div class="grid-x grid-padding-x align-middle">
                            <div class="large-2 medium-2 small-3 cell hide-for-small-only">
                                <label  for="privacy" class="large-text-right small-text-left" for="privacy">Privacy</label>
                            </div>
                            <div class="large-8 medium-8 small-12 cell end text-left">
                                <div id="testoprivacy" class="reveal tiny" data-reveal aria-hidden="true" role="dialog">
                                    <p class="testoprivacy">
                                        <h4>Informativa in materia di privacy</h4> ai sensi del D.Lgs. 196/2003 e successive modifiche -
                                        Codice in materia di protezione dei dati personali e del regolamento UE 679/2016 -
                                        Regolamento Generale sulla Protezione dei Dati ("RGDP"): 
                                        <a href="https://spaziogroup.com/privacy/" target="_blank">https://spaziogroup.com/privacy/</a>.
                                    </p>
                                    <button class="close-button" data-close aria-label="Chiudi" type="button"><span aria-hidden="true">&times;</span></button >
                                </div>
                                <input type="checkbox" name="privacy" id="privacy" value="si" required="required" class="float-left" />
                                <small style="line-height:0.925rem;float:left;margin-left:5px;width:80%">Ho letto e capito la <a href="#privacy" style="cursor:pointer;color:#FFEB3B" ontouchstart="mostraModal('testoprivacy');" onclick="mostraModal('testoprivacy');">Privacy Policy</a> e acconsento al trattamento dei miei dati</small><br>
                                <small class="form-error">E' obbligatorio accettare la privacy</small>
                            </div>
                        </div>
                        
                        <div class="grid-x grid-padding-x align-top" style="margin-top:0.5rem;">
                            <div class="large-2 medium-2 small-3 cell hide-for-small-only">
                                <label for="consenso" class="large-text-right small-text-left">Finalit&agrave; di marketing</label>
                            </div>
                            <div class="large-8 medium-8 small-12 cell end text-left">
                                <div class="grassetto show-for-small-only">Finalit&agrave; di marketing</div>
                                <p style="font-size:0.75rem;margin-bottom:0.25rem">
                                    Autorizzazione all'elaborazione e al
                                    trattamento dei dati da parte di SPAZIO GROUP S.R.L. per le finalit&agrave; di marketing
                                    di cui al punto b) della Privacy Policy, con le modalit&agrave; di trattamento ivi
                                    previste, cartacee, automatizzate e telematiche e, in particolare, a mezzo posta
                                    ordinaria od elettronica, telefono (tramite chiamate anche automatizzate, SMS, MMS,
                                    etc.), telefax e qualsiasi altro canale informatico (es.: siti web, mobile app).</p>
                                <p>
                                    <input id="acconsento" type="radio" name="consenso" value="acconsento">
                                    <label for="acconsento">Acconsento</label>
                                    <input id="nonAcconsento" type="radio" name="consenso" value="non acconsento">
                                    <label for="nonAcconsento">Non acconsento</label>
                                </p>
                            </div>
                        </div>
    
    
    
                        <div class="grid-x grid-padding-x">
                            <div class="large-8 large-offset-2 medium-12 small-12 cell">
                                <div class="text-center">
                                    <%
                      								if (dtVeicoloOfferteAuto.Rows.Count>0){
                      									Response.Write("<input type=\"hidden\" name=\"promo\" id=\"promo\" value=\"" + dtVeicoloOfferteAuto.Rows[0]["VeicoliOfferte_Titolo"].ToString().Trim() + "\" />");
                      								}
                      								%>
                                    <input type="hidden" name="dipendentifca" id="dipendentifca"
                                        value="<%=strDipendentifca%>" />
                                    <input type="hidden" name="provincia" id="provincia" value="" />
                                    <input type="hidden" name="Veicoli_Ky" id="Veicoli_Ky"
                                        value="<%=dtVeicolo.Rows[0]["Veicoli_Ky"].ToString()%>" />
                                    <button name="invia" id="invia" value="Contatta SpazioGroup" class="button large radius warning animated slower headShake infinite"
                                        onClick="tracciaInviaContatto('<%=dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString().Trim()%>-<%=dtVeicolo.Rows[0]["VeicoliModelloSpazioGroup_Modello"].ToString()%>');"><i
                                            class="fa-duotone fa-envelope fa-fw"></i> Contattaci ora!<br><small>Senza
                                            Impegno</small></button>
                                </div>
                            </div>
                        </div>
                    </form>
            </div>
          </div>
      </div>
</section>