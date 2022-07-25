<div class="hide-for-small-only hide-for-medium-only">
    <div data-sticky-container>
        <div class="sidebar sticky dark shadow contactside" data-sticky data-margin-top="10" data-margin-bottom="10"
            data-top-anchor="breadcrumbs:bottom" data-btm-anchor="main:bottom">
            <h3 class="text-center contactside-title"><i class="fa-duotone fa-arrow-down fa-fw"></i> Sei interessato a quest'auto?</h3>
            <div class="contactside-content">
                <div class="text-center">
                    <a href="tel:+39<%=dtVeicolo.Rows[0]["Veicoli_TelefonoPersonaRiferimento"].ToString().Trim()%>" class="phone">
                        <i class="fa-duotone fa-phone fa-fw"></i><%=dtVeicolo.Rows[0]["Veicoli_TelefonoPersonaRiferimento"].ToString().Trim()%>
                    </a>
                    <br>
                    Referente per l'auto: <strong><%=dtVeicolo.Rows[0]["Utenti_PersContattare"].ToString().Trim()%></strong>
                
                </div>
                <hr>
                <div class="text-center">
                    <h4><i class="fa-duotone fa-laptop"></i> APERTI ONLINE</h4>
                    Siamo sempre disponibili, da oggi anche in <b>videochiamata</b> e <b>chat</b>. Contattaci subito!
                </div>
                <hr>                
                <div class="text-center">
                    <a class="button warning radius expanded large animated slower headShake infinite" href="#contatti" data-smooth-scroll>
                        <i class="fa-duotone fa-envelope fa-fw"></i> Contattaci<br><small>per bloccare l'offerta</small>
                    </a>
                </div>
                <div class="grid-x grid-padding-x">
                    <div class="large-6 medium-6 small-12 cell text-center">
                        <a class="button radius hollow white expanded" href="#contatti" data-smooth-scroll><i class="fa-duotone fa-coins fa-fw"></i> Permuta</a>
                    </div>
                    <div class="large-6 medium-6 small-12 cell text-center">
                        <a class="button radius hollow white expanded" href="#contatti" data-smooth-scroll><i class="fa-duotone fa-car fa-fw"></i> Test drive</a>
                    </div>
                </div>

                <!--<div class="grid-x grid-padding-x">
                    <div class="large-6 medium-6 small-12 cell">
                        <a class="button radius hollow warning expanded" href="https://pay.spaziogroup.com/?add-to-cart=9&rif=<%=dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString().Trim()%>" target="_blank">
                            <i class="fa-duotone fa-coins"></i> Prenota auto
                        </a>
                    </div>
                    <div class="large-6 medium-6 small-12 cell">
                        <a class="button radius hollow warning expanded" href="#contatti" data-smooth-scroll>
                            <i class="fa-duotone fa-car"></i> Test drive
                        </a>
                    </div>
                </div>-->
                <!--<div class="text-center">
                    <a class="button warning radius large" href="https://pay.spaziogroup.com/?add-to-cart=9&rif=<%=dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString().Trim()%>" target="_blank">
                        <i class="fa-duotone fa-coins"></i> Prenota auto
                    </a>
                </div>
                <div class="text-center">
                    <a class="button radius hollow warning" target="_blank" href="#contatti" data-smooth-scroll>
                        <i class="fa-duotone fa-envelope"></i> Ottieni preventivo
                    </a>
                </div>-->
            </div>
        </div>
    </div>
</div>

<div class="hide-for-large">
        <div class="title-bar-footer contactside align-middle " id="title-bar-bottom" style="max-width: 100%!important;">
            <div class="grid-x grid-padding-x" style="width:100%">
                <div class="large-6 medium-6 small-6 cell text-center">
                    <a href="#contatti" class="button warning radius expanded small" data-smooth-scroll><i class="fa-duotone fa-envelope"></i> Blocca l'offerta</a>
                </div>
                <div class="large-6 medium-6 small-6 cell text-center">
                    <a href="tel:+39<%=dtVeicolo.Rows[0]["Veicoli_TelefonoPersonaRiferimento"].ToString().Trim()%>" class="button radius hollow warning expanded small"><i class="fa-duotone fa-phone fa-fw"></i><%=dtVeicolo.Rows[0]["Veicoli_TelefonoPersonaRiferimento"].ToString().Trim()%></a>
                    <!--<a class="button radius hollow warning expanded small" href="https://pay.spaziogroup.com/?add-to-cart=9&rif=<%=dtVeicolo.Rows[0]["Veicoli_Riferimento"].ToString().Trim()%>" target="_blank">
                        <i class="fa-duotone fa-coins"></i> Prenota Auto
                    </a>-->
                </div>
            </div>
        </div>
</div>