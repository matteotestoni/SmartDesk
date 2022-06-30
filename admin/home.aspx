<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/home.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>	
  <title><%=strH1%></title>
  <!--#include file="/admin/inc-head.aspx"-->
	<script src="https://cdnjs.cloudflare.com/ajax/libs/highcharts/10.1.0/highcharts.min.js" integrity="sha512-SogfwUFpH9rofYV9j8NNbDSOuFOBvaVR86iNy3RblVGzRBMPWLA8es+P3JrfvRLNgCZLFK3SmnTddImp3UK0pQ==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/highcharts/10.1.0/highcharts-3d.min.js" integrity="sha512-uqz7yyIqQbcbaO6gmrXtJ+HMbXFX7YlsVG+S7Mqoq9bjSWhWhRGCCRiYgloJvntEf1r0bsRivm6BUaCWgv3TIA==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/highcharts/10.1.0/modules/exporting.min.js" integrity="sha512-a65yKVWaMTqOJbXD+fkCsv8ENApqxchdbBW8+PpUbPPSgTVSwJFKG3TnKfqz4p3GRHiY0fnRyjLoFMN0jyM6Sw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
</head>
<body> 
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container="">
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            	<h1><i class="fa-duotone fa-gauge fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
          		<div class="text-right"><i class="fa-duotone fa-user fa-xl fa-fw" title="<%=dtLogin.Rows[0]["Utenti_Nominativo"].ToString()%>" data-tooltip></i><%=dtLogin.Rows[0]["Utenti_Nominativo"].ToString()%></div>
              <div class="stacked-for-small button-group small hide-for-print align-right hide">
            			<a href="/admin/app/calendario/calendario.aspx" class="tiny button clear"><i class="fa-duotone fa-calendar-days fa-fw"></i>Vai al calendario</a>
            			<a href="/admin/app/attivita/attivita-da-fare.aspx?attivita-scadute=1&prossime-scadenze=1&scadenze-future=1" class="tiny button clear"><i class="fa-duotone fa-columns fa-fw"></i>Vai al prospetto per scadenza</a>
          		</div>
  	      </div>
      </div>
  </div>
</div>

<div class="homecontent">
  <div class="grid-container fluid">
    <div class="grid-x grid-padding-x">
    	<div class="large-12 medium-12 small-12 cell">
    					<ul class="tabs" data-responsive-accordion-tabs="tabs small-accordion medium-tabs large-tabs" role="tablist" id="home-tabs">
    			      	<% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-1"><i class="fa-duotone fa-euro-sign fa-fw"></i>Amministrazione</a></li>
    			    		<%
                      strActiveTab = "";
                  }
    						  %>
    			      	    <% if (dtLogin.Rows[0]["UtentiGruppi_Lead"].Equals(true)){ %>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-lead"><i class="fa-duotone fa-money-bill-1-wave fa-fw"></i>Lead</a></li>
    			    		<%
                                strActiveTab = "";
                            }
    						  %>
    			      	    <% if (dtLogin.Rows[0]["UtentiGruppi_Commerciale"].Equals(true)){ %>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-commerciale"><i class="fa-duotone fa-file fa-fw"></i>Commerciale</a></li>
    			    		<%
                                strActiveTab = "";
                            }
    						  %>
    			    		<%if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){%>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-attivita"><i class="fa-duotone fa-calendar-days fa-fw"></i>Attivit&agrave;</a></li>
    			    		<%
                                strActiveTab = "";
                            }
    						  %>
    			    		<%if (dtLogin.Rows[0]["UtentiGruppi_Officina"].Equals(true)){%>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-officina"><i class="fa-duotone fa-car-wrench fa-fw"></i>Officina</a></li>
    			    		<%
                                strActiveTab = "";
                            }
    						  %>
    			    		<%if (dtLogin.Rows[0]["UtentiGruppi_Progetti"].Equals(true)){%>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-progetti"><i class="fa-duotone fa-buildings fa-fw"></i>Progetti</a></li>
    			    		<%
                                strActiveTab = "";
                            }
    						%>
       
    			    		<%if (dtLogin.Rows[0]["UtentiGruppi_PersonaleAssenze"].Equals(true)){%>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-4"><i class="fa-duotone fa-calendar fa-fw"></i>Presenze/Assenze</a></li>
    			    		<%
                                strActiveTab = "";
                            }
    						%>
    			    		<%if (dtLogin.Rows[0]["UtentiGruppi_Ticket"].Equals(true)){%>
    			    		<li class="tabs-title<%=strActiveTab%>" role="presentational"><a href="#tabs-5"><i class="fa-duotone fa-calendar fa-fw"></i>Ticket</a></li>
    			    		<%
                                strActiveTab = "";
                            }
    						%>
    			    	</ul>
    			      <div class="tabs-content" data-tabs-content="home-tabs">
    						<% if (dtLogin.Rows[0]["UtentiGruppi_Amministrazione"].Equals(true)){ %>
    					  		<section role="tabpanel" aria-hidden="false" class="tabs-panel<%=strActive%>" id="tabs-1">
    					  				<%strActive="";%>
    								<div class="grid-x grid-padding-x">                                                                     
    									<div class="small-12 medium-12 large-6 cell">
    			      						<%if (dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){%>
    											<!--#include file=/admin/app/pagamenti/widget/widget-pagamenti-ricevere-scaduti.inc --> 
    										<%}%>
    	      								<%if (dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){%>
    											<!--#include file=/admin/app/pagamenti/widget/widget-pagamenti-ricevere-futuri.inc --> 
    										<%}%>
    									  </div>
    									<div class="small-12 medium-12 large-6 cell left">
    		    						<%if (dtLogin.Rows[0]["UtentiGruppi_Pagamenti"].Equals(true)){%>
    											<!--#include file=/admin/app/pagamenti/widget/widget-pagamenti-dafare.inc --> 
    										<% }%>
    			
    			      				<%if (dtLogin.Rows[0]["UtentiGruppi_Servizi"].Equals(true)){%>
    											<!--#include file=/admin/app/amministrazione/widget/widget-servizi-da-fatturare.inc --> 
    							  <%}%>
    								 </div>
    								</div>
    				    		</section>
    			    		<% } %>
      						<% if (dtLogin.Rows[0]["UtentiGruppi_Lead"].Equals(true)){ %>
      					  		<section role="tabpanel" aria-hidden="false" class="tabs-panel<%=strActive%>" id="tabs-lead">
      					  				<%strActive="";%>
          								<div class="grid-x grid-padding-x">                                                                     
          									<div class="small-12 medium-12 large-12 cell">
          										<!--#include file=/admin/app/commerciale/widget/widget-lead-andamento.inc --> 
          								 </div>
      								    </div>
          				    		</section>
      			    	<% } %>
      						<% if (dtLogin.Rows[0]["UtentiGruppi_Commerciale"].Equals(true)){ %>
      					  		<section role="tabpanel" aria-hidden="false" class="tabs-panel<%=strActive%>" id="tabs-commerciale">
      					  				<%strActive="";%>
          								<div class="grid-x grid-padding-x">                                                                     
          									<div class="small-12 medium-12 large-12 cell">
          										<!--#include file=/admin/app/commerciale/widget/widget-preventiviauto-andamento.inc --> 
          								 </div>
      								    </div>
          				    		</section>
      			    	<% } %>

    			    		<% if (dtLogin.Rows[0]["UtentiGruppi_Attivita"].Equals(true)){%>
    					  	<section role="tabpanel" aria-hidden="true" class="tabs-panel<%=strActive%>" id="tabs-attivita">
    					  		<%strActive="";%>
    								<!--#include file=/admin/app/attivita/widget/widget-attivita.inc --> 
    			    		</section>
    			    		<%}%>
    			    		<% if (dtLogin.Rows[0]["UtentiGruppi_Officina"].Equals(true)){ %>
                  <section role="tabpanel" aria-hidden="true" class="tabs-panel<%=strActive%>" id="tabs-officina">
    					  		<%strActive="";%>
    								<!--#include file=/admin/app/officina/widget/widget-officina.inc --> 
    			    		</section>
    			    		<%}%>

    			    		<% if (dtLogin.Rows[0]["UtentiGruppi_Progetti"].Equals(true)){%>
    					  	<section role="tabpanel" aria-hidden="true" class="tabs-panel<%=strActive%>" id="tabs-progetti">
    					  		<%strActive="";%>
    								<!--#include file=/admin/app/progetti/widget/widget-progetti.inc --> 
    			    		</section>
    			    		<%}%>
    
    
    						<% if (dtLogin.Rows[0]["UtentiGruppi_PersonaleAssenze"].Equals(true)){ %>
    							<section role="tabpanel" aria-hidden="true" class="tabs-panel<%=strActive%>" id="tabs-4">
      							<%strActive="";%>
    								<!--#include file=/admin/app/persone/widget/widget-personeassenze.inc --> 
    							</section>
    						<% } %>
    
    						<% if (dtLogin.Rows[0]["UtentiGruppi_Ticket"].Equals(true)){ %>
    							<section role="tabpanel" aria-hidden="true" class="tabs-panel<%=strActive%>" id="tabs-5">
      							<%strActive="";%>
    								<!--#include file=/admin/app/assistenza/widget/widget-ticket.inc --> 
    							</section>
    						<% } %>
    
    
              </div>
    		</div>
    </div>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
