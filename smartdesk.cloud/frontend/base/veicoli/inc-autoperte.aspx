<section id="autoperte">
  <div class="grid-container">
    <img src="https://cdn.spaziogroup.com/spazio2019/img/ricerca-auto-per-te.png" alt="Ricerca auto per te" class="img-ricerca-autoperte lazyload" loading="lazy" />
    <div class="grid-container">
        <div class="grid-x grid-padding-x">
            <div
                class="xxlarge-4 xxlarge-offset-2 xlarge-4 xlarge-offset-2 large-4 large-offset-2 medium-offset-2 medium-4 small-12 cell">
                <span class="titoletto">Non hai trovato<br>l'<strong>Auto che stavi Cercando</strong>?</span>
                <p class="no-margin">Lasciaci la tua email per ricevere<br>le offerte che corrispondono alla tua ricerca!
                </p>
            </div>
            <div class="xxlarge-5 xlarge-5 large-5 medium-6 small-12 cell">
                <div class="box">
                    <form action="/veicoli/autoperte.html" method="get" name="formricerca"
                        id="formricerca" data-abide novalidate>
                        <div data-abide-error class="alert callout" style="display: none;">
                            <p><i class="fi-alert"></i> Controlla tutti i campi obbligatori.</p>
                        </div>
                        <div class="grid-x grid-padding-x">
                            <div class="small-12 medium-12 large-12 xlarge-6 cell">
                                <select name="VeicoliMarca_Ky_Autoperte" id="VeicoliMarca_Ky_Autoperte" class="chosen" value="35"
                                    required="required"
                                    onchange="auto2021CaricaVeicoliModelloMarca('VeicoliMarca_Ky','VeicoliModello_Ky')"
                                    aria-invalid="false">
                                    <option value="">Seleziona marca...</option>
                                    <option value="1">ABARTH</option>
                                    <option value="5">ALFA ROMEO</option>
                                    <option value="9">AUDI</option>
                                    <option value="14">BMW</option>
                                    <option value="22">CHEVROLET</option>
                                    <option value="2755">CITROËN</option>
                                    <option value="27">DACIA</option>
                                    <option value="2754">DS</option>
                                    <option value="35">FIAT</option>
                                    <option value="36">FORD</option>
                                    <option value="44">HYUNDAI</option>
                                    <option value="50">JEEP</option>
                                    <option value="55">LANCIA</option>
                                    <option value="56">LAND ROVER</option>
                                    <option value="58">LEXUS</option>
                                    <option value="2757">MERCEDES-BENZ</option>
                                    <option value="70">MINI</option>
                                    <option value="72">NISSAN</option>
                                    <option value="75">OPEL</option>
                                    <option value="77">PEUGEOT</option>
                                    <option value="84">RENAULT</option>
                                    <option value="86">ROVER</option>
                                    <option value="88">SEAT</option>
                                    <option value="89">SKODA</option>
                                    <option value="90">SMART</option>
                                    <option value="96">TOYOTA</option>
                                    <option value="101">VOLVO</option>
                                </select>
                            </div>

                            <div class="small-12 medium-12 large-12 xlarge-6 cell">
                                <input type="text" name="VeicoliRicerche_Email" id="VeicoliRicerche_Email"
                                    placeholder="La tua email*" size="30" required="required">
                            </div>

                        </div>

                        <div class="grid-x grid-padding-x">
                            <div class="small-12 medium-12 large-12 cell">
                                <button class="button round uppercase expanded warning radius"><strong>Ricevi super offerte <i class="fa-duotone fa-angle-right fa-fw"></i></strong></button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
  </div>
</section>