<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/forms/anteprima-forms.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Forms > Anteprima form</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
	<div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
		<div class="grid-x grid-padding-x">
			<div class="large-4 medium-6 small-12 cell">
        <h1><i class="fa-duotone fa-circle-question fa-lg fa-fw"></i><%=strH1%><span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtForms, "Forms_Ky")%></span></h1>
      </div>
			<div class="large-8 medium-6 small-12 cell float-right">
			</div>
		</div>
	</div>
</div>

<script type="text/javascript">
	var bitInizializza=0;
	
	function aggiornaCampo(campoCambiato){
		var strAggiorna="";
		var strNomecheck="";
        strNomecheck="status-" + campoCambiato.name;
    	if (jQuery("#"+strNomecheck).hasClass('fa-triagle-exclamation')){
    		jQuery("#"+strNomecheck).removeClass('fa-triagle-exclamation');
	    }
	    jQuery("#"+strNomecheck).addClass("fa-check");
		  if (jQuery("#"+strNomecheck).hasClass('fa-question')){
		    jQuery("#"+strNomecheck).removeClass('fa-question');
	    }
	    jQuery("#"+strNomecheck).css("--fa-primary-color", "green");
	}
	
	function impostaRadio(idOggetto, strValue){
		var strNomecheck="";
		jQuery('input[name="' + idOggetto + '"][value="' + strValue + '"]').click();
		console.log(idOggetto);
    strNomecheck="status-" + idOggetto;
		if (jQuery("#"+strNomecheck).hasClass('fa-triagle-exclamation')){
			jQuery("#"+strNomecheck).removeClass('fa-triagle-exclamation');
    }
    jQuery("#"+strNomecheck).addClass("fa-check");
    jQuery("#"+strNomecheck).css("--fa-primary-color", "green");
	}
	
	function impostaText(idOggetto, strValue){
	var strNomecheck="";
      jQuery("#" + idOggetto).val(strValue);
      strNomecheck="status-" + idOggetto;
      if (jQuery("#"+strNomecheck).hasClass('fa-triagle-exclamation')){
      	jQuery("#"+strNomecheck).removeClass('fa-triagle-exclamation');
      }
      jQuery("#"+strNomecheck).addClass("fa-check");
    jQuery("#"+strNomecheck).css("--fa-primary-color", "green");
	}
</script>

<div class="grid-x grid-padding-x">
  <div class="small-12 large-12 medium-12 cell">
		<div class="card">
		  <div class="card-divider">
				<h2><i class="fa-duotone fa-pen-to-square fa-lg fa-fw"></i><%=GetFieldValue(dtForms, "Forms_Titolo")%></h2>
			</div>        
			<div class="card-section">
					<p><%=GetFieldValue(dtForms, "Forms_Descrizione")%></p>
					<hr>
	        <form action="#" method="post" name="testform" id="testform" data-abide>
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
								  	Response.Write("</div>");
								  	Response.Write("</div>");
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
    								if (dtFormsFields.Rows[i]["FormsFields_Obbligatorio"].Equals(true)){
                      Response.Write("<span class=\"form-error\">Obbligatorio</span>");
                    }
								  	Response.Write("</div></div>");
								  	break;
								  case "6":
										Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"large-12 medium-12 small-12 cell text-center\">");
								  	Response.Write("<br><h2>" + dtFormsFields.Rows[i]["FormsFields_Descrizione"].ToString() + "</h2>");
								  	Response.Write("<p>" + dtFormsFields.Rows[i]["FormsFields_Info"].ToString() + "</p>");
    								if (dtFormsFields.Rows[i]["FormsFields_Obbligatorio"].Equals(true)){
                      Response.Write("<span class=\"form-error\">Obbligatorio</span>");
                    }
								  	Response.Write("</div></div>");
								  	break;
								}
							%>
	        <% } %>
          
					<div class="grid-x grid-padding-x">
					 <div class="large-12 medium-12 small-21 cell text-center">
            <input type="submit" class="button large success" value="Test form">
           </div>
          </div>
        </form>

		  </div>
		</div>
	</div>
	</div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
