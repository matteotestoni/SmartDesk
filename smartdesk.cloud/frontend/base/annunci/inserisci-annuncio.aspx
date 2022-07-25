<%@ Page ResponseEncoding="utf-8" Language="C#" AutoEventWireup="true" CodeFile="inserisci-annuncio.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<!--[if IE 9]><html class="lt-ie10" lang="it"><![endif]-->
<html class="no-js" dir="ltr" lang="it-IT">
	<head>	
      <title><%=strH1%></title>
    	<meta name="description" content="<%=strH1%>"/>
      <meta name="robots" content="index,follow">
  	   <!-- #include file ="/frontend/base/inc-head.aspx" -->
	    <script type="text/javascript" src="//cdn.ckeditor.com/4.19.2/basic/ckeditor.js"></script>
	</head>
	<body class="login">
	<!-- #include file ="/frontend/base/inc-header.aspx" -->
		<div class="grid-container">
			<div class="grid-x grid-padding-x">
						<div class="large-12 medium-12 small-12 cell">
							<main>
							<div class="callout">
								<h1>Inserisci il tuo annuncio in autonomia: &egrave; gratis</h1>
		            <form id="form-annunci" enctype="multipart/form-data" action="/form/salva-annunci.aspx" onsubmit="return validateForm()" method="post" data-abide novalidate>
                <input type="hidden" id="foo" name="foo" />
								<input type="hidden" name="proteggi" id="proteggi" value="">
                <input type="hidden" name="sorgente" id="sorgente" value="inserisci-annuncio">
                <input type="hidden" name="azione" id="azione" value="new">
                <input type="hidden" name="Annunci_Ky" id="Annunci_Ky" value="">
                <input type="hidden" name="Anagrafiche_Ky" id="Anagrafiche_Ky" value="<%=dtLogin.Rows[0]["Anagrafiche_Ky"].ToString()%>">
                <input type="hidden" name="AnnunciStato_Ky" id="AnnunciStato_Ky" value="5">
                <input type="hidden" name="AnnunciTipo_Ky" id="AnnunciTipo_Ky" value="1">
                <input type="hidden" name="Annunci_Provvigione" id="Annunci_Provvigione" value="10">
                <input type="hidden" name="Annunci_Cauzione" id="Annunci_Cauzione" value="0">
                <input type="hidden" name="Annunci_Rilancio" id="Annunci_Rilancio" value="0">
                <input type="hidden" name="Annunci_Numero" id="Annunci_Numero" value="1">
                <input type="hidden" name="Nazioni_Ky" id="Nazioni_Ky" value="<%=dtLogin.Rows[0]["Nazioni_Ky"].ToString()%>">
                <input type="hidden" name="Regioni_Ky" id="Regioni_Ky" value="<%=dtLogin.Rows[0]["Regioni_Ky"].ToString()%>">
                <input type="hidden" name="Province_Ky" id="Province_Ky" value="<%=dtLogin.Rows[0]["Province_Ky"].ToString()%>">
                <input type="hidden" name="Comuni_Ky" id="Comuni_Ky" value="<%=dtLogin.Rows[0]["Comuni_Ky"].ToString()%>">
                <input type="hidden" name="Annunci_Indirizzo" id="Annunci_Indirizzo" value="<%=dtLogin.Rows[0]["Anagrafiche_Indirizzo"].ToString()%>">
                <input type="hidden" name="Annunci_Visione" id="Annunci_Visione" value="Accordi venditore">
                <input type="hidden" name="AnnunciSorgenti_Ky" id="AnnunciSorgenti_Ky" value="1">
                <input type="hidden" name="Annunci_Robots" id="Annunci_Robots" value="index,follow">
                <!--#include file=/frontend/base/annunci/annunci_form.htm -->
          			<div class="text-center">
                  <div data-abide-error class="alert callout" style="display: none;">
                    <p><i class="fa-duotone fa-info-circle fa-fw fa-lg"></i>Ci sono errori nel modulo</p>
                  </div>
                	<button type="submit" value="salva" name="salva" class="button large success"><i class="fa-duotone fa-save fa-lg fa-fw"></i>Salva</button>
          			</div>
                </form>
							</div>
							</main>
						</div>
			</div>
    </div>
 	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
          <script type="text/javascript">

            function validateForm(){
              var boolValid=true;
              jQuery('#form-annunci *').filter(':input').each(function(){
                if (jQuery(this).prop('required')){
                  if (!jQuery(this).val()){
                    jQuery(this).addClass("is-invalid-input");
                    jQuery(this).attr('data-invalid', 'invalid');
                    boolValid=false;
                    console.log(this.id);
                  }else{
                    jQuery(this).removeClass("is-invalid-input");
                    jQuery(this).removeData("invalid");
                    jQuery(this).removeAttr("data-invalid");
                  }
                }
              });
              console.log(boolValid);
              return boolValid;          
            }
            
            function loadAnnunciModelli(){
              var sHTML;
              var listField;
              var strWHERE;
              var strXML;
              var strPath;
              var strTipo;
              var strNomeTipo;
              var optgroup;
              var option;

              listField=document.getElementById("AnnunciMarca_Ky");
          	  if (document.getElementById("AnnunciMarca_Ky").value!=""){
                  strPath="/frontend/base/annunci/getAnnunciModello-json.aspx?AnnunciMarca_Ky=" + jQuery("#AnnunciMarca_Ky").val();
                  jQuery.getJSON(strPath, null, function(data) {
                      jQuery("#AnnunciModello_Ky option").remove();
                      jQuery("#AnnunciModello_Ky optgroup").remove();
											jQuery.each(data.modelli, function(index, item) { // Iterates through a collection
                          if (item.tipo!=strTipo){
														switch (item.tipo){
															case "1":
																strNomeTipo="Auto";
																break;
															case "2":
																strNomeTipo="Moto";
																break;
															case "3":
																strNomeTipo="Veicolo commerciale";
																break;
															case "4":
																strNomeTipo="Camion";
																break;
															case "5":
																strNomeTipo="Autobus";
																break;
															case "6":
																strNomeTipo="Mezzo agricolo";
																break;
														}
														optgroup = jQuery('<optgroup>');
														optgroup.attr('label',strNomeTipo);
														jQuery("#AnnunciModello_Ky").append(optgroup);
													}
													option = jQuery("<option></option>");
					                option.val(item.id);
					                option.text(item.label);													
                          optgroup.append(option);
                          strTipo=item.tipo;
                      });
                  });
              }  
            };

            function loadAnnunciCategorie(){
              var sHTML;
              var listField;
              var strWHERE;
              var strXML;
              var strPath;
            
              listField=document.getElementById("AnnunciCategorie_Ky1");
          	  if (document.getElementById("AnnunciCategorie_Ky1").value!=""){
                  strPath="/frontend/base/annunci/getAnnunciCategorie-json.aspx?AnnunciCategorie_Ky=" + jQuery("#AnnunciCategorie_Ky1").val();
                  //console.log(strPath);
                  jQuery.getJSON(strPath, null, function(data) {
                      jQuery("#AnnunciCategorie_Ky option").remove(); // Remove all <option> child tags.
                      jQuery("#AnnunciCategorie_Ky").append( // Append an object to the inside of the select box
                          jQuery("<option></option>") // Yes you can do this.
                              .text("")
                              .val("")
                      );
                      jQuery.each(data.categorie, function(index, item) { // Iterates through a collection
                          jQuery("#AnnunciCategorie_Ky").append( // Append an object to the inside of the select box
                              jQuery("<option></option>") // Yes you can do this.
                                  .text(item.label)
                                  .val(item.id)
                          );
                      });
                  });
              }  
            };
          </script>
				</body>
			</html>			
