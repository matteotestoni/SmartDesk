<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/forms/sondaggio.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html>
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
</head>
<body>
<style>
	i.alert, svg.alert{
	  color:#f04124;
	}
	i.success, svg.success{
	  color:#43ac6a;
	}
</style>
<script type="text/javascript">
	var bitInizializza=0;
	
	function aggiornaCampo(campoCambiato){
		var strAggiorna="";
		var strNomecheck="";
		if (bitInizializza!=1){
			strAggiorna="/area-clienti/app/forms/sondaggio-salva-scelta.aspx?Forms_Ky=<%=GetFieldValue(dtForms, "Forms_Ky")%>&Anagrafiche_Ky=<%=strAnagrafiche_Ky%>&campo=" + campoCambiato.name + "&valore=" + campoCambiato.value;
			jQuery.post(strAggiorna,function(){
  			strNomecheck="status-" + campoCambiato.name;
  			if (jQuery("#"+strNomecheck).hasClass('fa-triangle-exclamation')){
  				jQuery("#"+strNomecheck).removeClass('fa-triangle-exclamation');
  			}
  			jQuery("#"+strNomecheck).addClass("fa-check");
  			if (jQuery("#"+strNomecheck).hasClass('fa-question')){
  				jQuery("#"+strNomecheck).removeClass('fa-question');
  			}		
        jQuery("#"+strNomecheck).css("--fa-primary-color", "green");
		  })
			.fail(function() {
				//alert( "error" );
			});
		}
	}
	
	function impostaRadio(idOggetto, strValue){
		var strNomecheck="";
		jQuery('input:radio[name="' + idOggetto + '"][value="' + strValue + '"]').click();
		//console.log(idOggetto + '-' + strValue);
		strNomecheck="status-" + idOggetto;
		if (jQuery("#"+strNomecheck).hasClass('fa-triangle-exclamation')){
			jQuery("#"+strNomecheck).removeClass('fa-triangle-exclamation');
		}
		jQuery("#"+strNomecheck).addClass("fa-check");
		if (jQuery("#"+strNomecheck).hasClass('fa-question')){
			jQuery("#"+strNomecheck).removeClass('fa-question');
		}		
    jQuery("#"+strNomecheck).css("--fa-primary-color", "green");
	}
	
	function impostaText(idOggetto, strValue){
		var strNomecheck="";
  		jQuery("#" + idOggetto).val(strValue);
      strNomecheck="status-" + idOggetto;
  		if (jQuery("#"+strNomecheck).hasClass('fa-triangle-exclamation')){
  			jQuery("#"+strNomecheck).removeClass('fa-triangle-exclamation');
      }
  		jQuery("#"+strNomecheck).addClass("fa-check");
  		if (jQuery("#"+strNomecheck).hasClass('fa-question')){
  			jQuery("#"+strNomecheck).removeClass('fa-question');
  		}		
      jQuery("#"+strNomecheck).css("--fa-primary-color", "green");
	}
</script>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-edit fa-lg fa-fw"></i>Partecipa al sondaggio</h1>
<div class="grid-container fluid">
<div class="grid-x grid-padding-x">
  <div class="small-12 large-12 medium-12 cell">
		<br>
		<div class="card">
		  <div class="card-divider">
				<h2><i class="fa-duotone fa-edit fa-lg fa-fw"></i><%=GetFieldValue(dtForms, "Forms_Titolo")%></h2>
			</div>        
			<div class="card-section">
					<p><%=GetFieldValue(dtForms, "Forms_Descrizione")%></p>

					<strong>Hai compilato <%=dtFormsValori.Rows.Count%> di <%=dtFormsFieldsConteggio.Rows.Count%> quesiti.</strong>
					<div class="success progress" role="progressbar" tabindex="0" aria-valuenow="<%=decPercCompilato%>" aria-valuemin="0" aria-valuetext="<%=decPercCompilato%> percent" aria-valuemax="100">
					  <div class="progress-meter" style="width:<%=decPercCompilato%>%"></div>
					</div>					
          
					<hr>
	      	<form class="clean" action="/area-clienti/app/forms/crud/salva-sondaggio.aspx" method="post" data-abide>
					<%for (int i = 0; i < dtFormsFields.Rows.Count; i++){ %>
							<%
								if (dtFormsFields.Rows[i]["FormsFields_Obbligatorio"].Equals(true)){
                  strRequired=" required";
                }else{
                  strRequired="";
                }
								switch (dtFormsFields.Rows[i]["FormsFieldsTipo_Ky"].ToString()){
								  case "1":
										Response.Write("<div class=\"grid-x grid-padding-x\">");
										Response.Write("<div class=\"large-4 medium-4 small-4 cell text-right\">");
                    Response.Write("<i class=\"fa-duotone fa-question fa-fw fa-lg\" style=\"--fa-primary-color:red\" id=\"status-" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\"></i>");
								  	Response.Write(dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString());
								  	Response.Write("</div>");
										Response.Write("<div class=\"large-8 medium-8 small-8 cell\">");
								  	Response.Write("<input type=\"text\" name=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\" id=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\" placeholder=\"" + dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString() + "\" onchange=\"aggiornaCampo(this);\"" + strRequired + ">");
								  	Response.Write("<div class=\"help-text\">" + dtFormsFields.Rows[i]["FormsFields_Info"].ToString() + "</div>");
    								if (dtFormsFields.Rows[i]["FormsFields_Obbligatorio"].Equals(true)){
                      Response.Write("<span class=\"form-error\">Obbligatorio</span>");
                    }
								  	Response.Write("</div></div>");
								  	break;
								  case "2":
										Response.Write("<div class=\"grid-x grid-padding-x\">");
										Response.Write("<div class=\"large-4 medium-4 small-4 cell text-right\">");
                    Response.Write("<i class=\"fa-duotone fa-question fa-fw fa-lg\" style=\"--fa-primary-color:red\" id=\"status-" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\"></i>");
								  	Response.Write(dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString());
								  	Response.Write("</div>");
										Response.Write("<div class=\"large-8 medium-8 small-8 cell\">");
								  	Response.Write("<input type=\"checkbox\" name=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\" id=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\" value=\"" + dtFormsFields.Rows[i]["FormsFields_Valori"].ToString() + "\" placeholder=\"" + dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString() + "\" onchange=\"aggiornaCampo(this);\"" + strRequired + ">");
								  	Response.Write("<div class=\"help-text\">" + dtFormsFields.Rows[i]["FormsFields_Info"].ToString() + "</div>");
    								if (dtFormsFields.Rows[i]["FormsFields_Obbligatorio"].Equals(true)){
                      Response.Write("<span class=\"form-error\">Obbligatorio</span>");
                    }
								  	Response.Write("</div></div>");
								  	break;
								  case "3":
										Response.Write("<div class=\"grid-x grid-padding-x\">");
										Response.Write("<div class=\"large-4 medium-4 small-4 cell text-right\">");
                    Response.Write("<i class=\"fa-duotone fa-question fa-fw fa-lg\" style=\"--fa-primary-color:red\" id=\"status-" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\"></i>");
								  	Response.Write(dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString());
								  	Response.Write("</div>");
										Response.Write("<div class=\"large-8 medium-8 small-8 cell\">");
										string[] words = dtFormsFields.Rows[i]["FormsFields_Valori"].ToString().Split(',');
						        foreach (string word in words)
						        {
						     			Response.Write("<input type=\"radio\" id=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + word + "\" name=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\" value=\"" + word + "\" onchange=\"aggiornaCampo(this);\"" + strRequired + "><label for=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + word + "\">" + word + "</label>");
						        }
								  	Response.Write("<div class=\"help-text\">" + dtFormsFields.Rows[i]["FormsFields_Info"].ToString() + "</div>");
    								if (dtFormsFields.Rows[i]["FormsFields_Obbligatorio"].Equals(true)){
                      Response.Write("<span class=\"form-error\">Obbligatorio</span>");
                    }
								  	Response.Write("</div></div>");
								  	break;
								  case "4":
										Response.Write("<div class=\"grid-x grid-padding-x\">");
										Response.Write("<div class=\"large-4 medium-4 small-4 cell text-right\">");
                    Response.Write("<i class=\"fa-duotone fa-question fa-fw fa-lg\" style=\"--fa-primary-color:red\" id=\"status-" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\"></i>");
								  	Response.Write(dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString());
								  	Response.Write("</div>");
										Response.Write("<div class=\"large-8 medium-8 small-8 cell\">");
								  	Response.Write("<textarea name=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\" id=\"" + dtFormsFields.Rows[i]["FormsFields_Codice"].ToString() + "\" placeholder=\"" + dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString() + "\" onchange=\"aggiornaCampo(this);\"" + strRequired + "></textarea>");
								  	Response.Write("<div class=\"help-text\">" + dtFormsFields.Rows[i]["FormsFields_Info"].ToString() + "</div>");
    								if (dtFormsFields.Rows[i]["FormsFields_Obbligatorio"].Equals(true)){
                      Response.Write("<span class=\"form-error\">Obbligatorio</span>");
                    }
								  	Response.Write("</div></div>");
								  	break;
								  case "5":
										Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"large-12 medium-12 small-12 cell text-center\">");
								  	Response.Write(dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString());
								  	Response.Write(dtFormsFields.Rows[i]["FormsFields_Info"].ToString());
								  	Response.Write("</div></div>");
								  	break;
								  case "6":
										Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"large-12 medium-12 small-12 cell text-center\">");
								  	Response.Write("<br><h2>" + dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString() + "</h2>");
								  	Response.Write("<p>" + dtFormsFields.Rows[i]["FormsFields_Info"].ToString() + "</p>");
								  	Response.Write("</div></div>");
								  	break;
								}
							%>
	        <% } %>
			    <hr>
			    <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
			    <input type="hidden" name="Forms_Ky" id="Forms_Ky" value="<%=GetFieldValue(dtForms, "Forms_Ky")%>">

			    <div class="grid-x grid-padding-x">
					    <div class="small-12 large-12 medium-12 cell text-center">
                <div data-abide-error class="alert callout" aria-live="assertive" role="alert" style="display: none;">
                  <p><i class="fa-duotone fa-alert fa-fw fa-lg"></i> Ci sono errori nel modulo. Controlla tutti i campi obbligatori</p>
                </div>
								<button type="submit" value="salva" name="salva" class="button tiny radius success"><i class="fa-duotone fa-triangle-exclamation fa-lg fa-fw"></i>Salva ed invia (il sondaggio sar&agrave; chiuso)</button>
					    </div>
					</div>
			    </form>

		  </div>
		</div>
				
			</p>
	</div>
</div>
<script type="text/javascript">
	bitInizializza=1;
  <%for (int i = 0; i < dtFormsValori.Rows.Count; i++){
		switch (dtFormsValori.Rows[i]["FormsFieldsTipo_Ky"].ToString()){
			case "1":
				Response.Write("impostaText(\"" + dtFormsValori.Rows[i]["FormsFields_Codice"].ToString() + "\",\"" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "\");\n");
				break;
			case "2":
				Response.Write("impostaRadio(\"" + dtFormsValori.Rows[i]["FormsFields_Codice"].ToString() + "\",\"" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "\");\n");
				break;
			case "3":
				Response.Write("impostaRadio(\"" + dtFormsValori.Rows[i]["FormsFields_Codice"].ToString() + "\",\"" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "\");\n");
				break;
			case "4":
				Response.Write("impostaText(\"" + dtFormsValori.Rows[i]["FormsFields_Codice"].ToString() + "\",\"" + dtFormsValori.Rows[i]["FormsValori_Valore"].ToString() + "\");\n");
				break;
			
		}
  }%>
	bitInizializza=0;
</script>
</div>
<!--#include file=/area-clienti/inc-footer.aspx -->
</body>
</html>
