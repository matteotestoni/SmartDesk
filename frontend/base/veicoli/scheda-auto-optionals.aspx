<div class="grid-x grid-padding-x wow fadeInUp optionals">
    <div class="large-12 medium-12 small-12 cell">

        <ul id="accordionoptionals" class="accordion" data-accordion data-multi-expand="true" data-allow-all-closed="true">
            <% if (dtVeicoloOptionals!=null && dtVeicoloOptionals.Rows.Count>0){ %>
            <li class="accordion-item is-active" data-accordion-item>
                <a href="#" class="accordion-title hide-for-medium">Optionals</a>
                <div id="accordioncontentoptionals" class="accordion-content" data-tab-content>
                    <div id="optionals">
                        <div class="hgroup text-center">
                            <h2><span class="grassetto">Optionals</span> inclusi su
                                <%=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString()%>
                                <%=dtVeicolo.Rows[0]["VeicoliModello_Titolo"].ToString()%>
                            <span class="linea-divisoria"><span></span></span>
                        </div>
                        <%
                        Response.Write("<ul class=\"check fa-ul\">");
                        for (i = 0; i < dtVeicoloOptionals.Rows.Count; i++){
                            Response.Write("<li><span class=\"fa-li\"><i class=\"fa-duotone fa-check fa-fw fa-lg\" style=\"color:#008246\"></i></span>"+ dtVeicoloOptionals.Rows[i]["equipment"].ToString() + "</li>");
                        }
                        Response.Write("</ul>");
                        %>
                        <br />
                    </div>
                </div>
            </li>
            <% } %>

            <% if (dtVeicoloEquipaggiamenti!=null && dtVeicoloEquipaggiamenti.Rows.Count>0){ %>
            <li id="accordionequipaggiamenti" class="accordion-item is-active" data-accordion-item>
                <a href="#" class="accordion-title hide-for-medium">Equipaggiamenti</a>
                <div id="accordioncontentequipaggiamenti" class="accordion-content" data-tab-content>
                    <div id="equipaggiamenti">
                        <div class="hgroup text-center">
                            <h2><span class="grassetto">Equipaggiamenti</span> su
                                <%=dtVeicolo.Rows[0]["VeicoliMarca_Titolo"].ToString()%>
                                <%=dtVeicolo.Rows[0]["VeicoliModello_Titolo"].ToString()%>
                            <span class="linea-divisoria"><span></span></span>
                        </div>
                        <p>
                            <%
                                    strValore=dtVeicolo.Rows[0]["Veicoli_Optional"].ToString().Trim().ToLower();
                                    if (strValore.Length>0){
                                    string[] words = strValore.Split(',');
                                    Response.Write("<ul class=\"check fa-ul\">");
                                    foreach (string word in words)
                                    {
                                    Response.Write("<li><span class=\"fa-li\"><i class=\"fa-duotone fa-check fa-fw fa-lg\" style=\"color:#008246\"></i></span>"+ word + "</li>");
                                    }										
                                    Response.Write("</ul>");
                                    }
                                %>
                        </p>
                        <% if (dtVeicoloEquipaggiamenti!=null && dtVeicoloEquipaggiamenti.Rows.Count>0){
                                Response.Write("<ul class=\"check fa-ul\">");
                                for (i = 0; i < dtVeicoloEquipaggiamenti.Rows.Count; i++){
                                                Response.Write("<li><span class=\"fa-li\"><i class=\"fa-duotone fa-check fa-fw fa-lg\" style=\"color:#008246\"></i></span>"+ dtVeicoloEquipaggiamenti.Rows[i]["equipment"].ToString() + "</li>");
                                        }
                                Response.Write("</ul>");
                        } %>
                    </div>

                </div>
            </li>
            <% } %>
        </ul>
        <script>
            function checkWidth(init) {
                if (jQuery(window).width() < 640) {
                    //console.log("tolgo");
                    jQuery('#accordionequipaggiamenti').removeClass('is-active');
                    jQuery('#accordioncontentequipaggiamenti').hide();
                }else{
                    //console.log("aggiungo");
                    jQuery('#accordionequipaggiamenti').addClass('is-active');
                    jQuery('#accordioncontentequipaggiamenti').show();
                }
            }

        jQuery(document).ready(function () {
            checkWidth(true);

            jQuery(window).resize(function () {
                checkWidth(false);
            });
        });
            
        </script>
            
    </div>
</div>