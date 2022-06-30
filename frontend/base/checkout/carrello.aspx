<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/frontend/base/checkout/carrello.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" dir="ltr" lang="it-IT">
  <head>
   	<title>Carrello</title>
  	<meta name="description" content="Carrello"/>
		<meta name="robots" content="noindex,nofollow">
  	<!-- #include file ="/frontend/base/inc-head.aspx" -->
  </head>
  <body>
	<!-- #include file ="/frontend/base/inc-header.aspx" -->
  <div class="grid-container">
     <div class="grid-x grid-padding-x">
      <div class="large-9 medium-9 small-12 cell">
        <h1>Carrello</h1>
        <hr>
                  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableCarrello">
                  <tr>
                    <td class="tdFirst">Rimuovi</td>
                    <td class="tdFirst">Foto</td>
                    <td class="tdFirst">Nome prodotto</td>
                    <td class="tdFirst">Prezzo<br />unitario</td>
                    <td class="tdFirst">Q.t&agrave;</td>
                    <td class="tdFirst" width="90">Subtotale</td>
                  <tr>
                    <%
                    dblSubtotale=0;
                    dblTotcomplessivo=0;
                    for (i = 0; i <= intNumRecordsCarrello-1; i++){
                      if (i < intNumRecordsCarrello){
                        dblSubtotale=Convert.ToDouble(dtCarrello.Rows[i]["Prodotti_Prezzo"])*Convert.ToDouble(dtCarrello.Rows[i]["Carrello_Qta"]);
                      %>
                      <tr>
                        <td class="tdRow" align="center" valign="middle">
                        <a href="/elimina-riga-carrello.aspx?Carrello_Ky=<%=dtCarrello.Rows[i]["Carrello_Ky"].ToString()%>">
                          <img src="/img/btn_trash.gif" border="0" border="0" alt="elimina prodotto" />
                        </a>
                        </td>
                        <td class="tdRow" align="center">
                          <%if (dtCarrello.Rows[i]["Prodotti_Foto1s"].ToString().Length>0){%>
                            <img src="<%=dtCarrello.Rows[i]["Prodotti_Foto1s"].ToString()%>" width="100" border="0" style="border:1px solid #cdcdcd" alt="<%=dtCarrello.Rows[i]["Prodotti_Titolo"].ToString()%>" />
                          <%}else{%>
                            <%if (dtCarrello.Rows[i]["Prodotti_Foto1s-padre"].ToString().Length>0){%>
                              <img src="<%=dtCarrello.Rows[i]["Prodotti_Foto1s-padre"].ToString()%>" width="100" border="0" style="border:1px solid #cdcdcd" alt="<%=dtCarrello.Rows[i]["Prodotti_Titolo"].ToString()%>" />
                            <%}else{%>
                              <img src="/img/no-image.gif" width="100" border="0" style="border:1px solid #cdcdcd" />
                            <%}%>
                          <%}%>
                          </a>
                        </td>
                        <td class="tdRow" align="left">
                        Codice: <%=dtCarrello.Rows[i]["Prodotti_Codice"].ToString()%><br />
                        <a href="/scheda-prodotto.aspx?Prodotti_Ky=<%=dtCarrello.Rows[i]["Prodotti_Ky"].ToString()%>" class="menuprodottivetrina" title="<%=dtCarrello.Rows[i]["Prodotti_Titolo"].ToString()%>">
                        <%=dtCarrello.Rows[i]["Prodotti_Titolo"].ToString()%>
                        </a>
                        </td>
                        <td class="tdRow" align="right">&euro; 
                          <%
                          Response.Write(((decimal)dtCarrello.Rows[i]["Prodotti_Prezzo"]).ToString("N2", ci) + " ");
                          %>
                        </td>
                        <td class="tdRow" align="right">
                        <form action="aggiornacarrello.aspx" name="FormAggiornaCarrello" id="FormAggiornaCarrello" method="post">
                        <input type="text" name="qta" id="qta<%=dtCarrello.Rows[i]["Carrello_Ky"].ToString()%>" value="<%=dtCarrello.Rows[i]["Carrello_Qta"].ToString()%>" length="2" size="2" style="width:30px;" />
                        <input type="hidden" name="Carrello_Ky" id="Carrello_Ky" value="<%=dtCarrello.Rows[i]["Carrello_Ky"].ToString()%>" />
                        <input type="submit" class="buttonaggiornacarrello" name="buttonaggiornacarrello" id="buttonaggiornacarrello" value="" />
                        </form>
                        
                        </td>
                        <td class="tdRow" align="right"><span class="prezzo">&euro; <%=((decimal)dblSubtotale).ToString("N2", ci)%></span>
                        <br />
                        <%
                        //if (intAnagraficheCategorie_Ky!=1){
                          Response.Write(dtCarrello.Rows[i]["ImposizioniIVA_Descrizione"].ToString());
                        //}
                        %>
                        </td>
                      </tr>
                      <%
                        if (intAnagraficheCategorie_Ky!=1){
                          if (dtCarrello.Rows[i]["ImposizioniIVA_Ky"].ToString()=="1"){
                            dblTotimponibile4=dblTotimponibile4+dblSubtotale;
                            dblTotiva4 = (dblTotimponibile4*4/100);
                          }
                          if (dtCarrello.Rows[i]["ImposizioniIVA_Ky"].ToString()=="2"){
                            dblTotimponibile10=dblTotimponibile10+dblSubtotale;
                            dblTotiva10 = (dblTotimponibile10*10/100);
                          }
                          if (dtCarrello.Rows[i]["ImposizioniIVA_Ky"].ToString()=="3"){
                            dblTotimponibile22=dblTotimponibile22+dblSubtotale;
                            dblTotiva22 = (dblTotimponibile22*22/100);
                          }
                        }else{
                          if (dtCarrello.Rows[i]["ImposizioniIVA_Ky"].ToString()=="1"){
                            dblTotimponibile4=dblTotimponibile4+(dblSubtotale/104*100);
                            dblTotiva4 = (dblTotimponibile4*4/100);
                          }
                          if (dtCarrello.Rows[i]["ImposizioniIVA_Ky"].ToString()=="2"){
                            dblTotimponibile10=dblTotimponibile10+(dblSubtotale/110*100);
                            dblTotiva10 = (dblTotimponibile10*10/100);
                          }
                          if (dtCarrello.Rows[i]["ImposizioniIVA_Ky"].ToString()=="3"){
                            dblTotimponibile22=dblTotimponibile22+(dblSubtotale/122*100);
                            dblTotiva22 = (dblTotimponibile22*22/100);
                          }
                        }
                      }
                      }%>
                  <tr>
                    <td class="tdLast" align="center" colspan="2"><a href="/" title="continua con gli acquisti" class="continuaacquisti">Continua gli acquisti</a></td>
                    <td class="tdLast" align="center"><a href="/frontend/base/checkout/svuota-carrello.aspx" title="continua con gli acquisti" class="continuaacquisti">Svuota il carrello</a></td>
                    <td colspan="3" class="tdLast" align="right"></td>
                  <tr>
                </table>
                <%
                  dblTotiva4 = (dblTotimponibile4*4/100);
                  dblTotiva10 = (dblTotimponibile10*10/100);
                  dblTotiva22 = (dblTotimponibile22*22/100);

                  dblTotiva = dblTotiva4 + dblTotiva10 + dblTotiva22;
                  dblTotimponibile=dblTotimponibile4+dblTotimponibile10+dblTotimponibile22;
                  dblTotcomplessivo = dblTotimponibile+dblTotiva;
                %>
                <table border="0" cellspacing="0" cellpadding="2" style="border:1px solid #BEBCB7;width:100%;margin-top:5px;">
                <tr>
                  <td align="right" class="tdTotLabel">Totale Imponibile</td>
                  <td align="right" class="tdTot" width="100"><%=((decimal)dblTotimponibile).ToString("N2", ci)%> &euro;</td>
                </tr>
                <%if (dblTotiva4>0){%>
                <tr>
                  <td align="right" class="tdTotLabel">IVA 4% - Imponibile &euro; <%=((decimal)dblTotimponibile4).ToString("N2", ci) %></td>
                  <td align="right" class="tdTot" width="100"><%=((decimal)dblTotiva4).ToString("N2", ci) %> &euro;</td>
                </tr>
                <%}%>
                <%if (dblTotiva10>0){%>
                <tr>
                  <td align="right" class="tdTotLabel">IVA 10% - Imponibile &euro; <%=((decimal)dblTotimponibile10).ToString("N2", ci) %></td>
                  <td align="right" class="tdTot" width="100"><%=((decimal)dblTotiva10).ToString("N2", ci)%> &euro;</td>
                </tr>
                <%}%>
                <%if (dblTotiva22>0){%>
                <tr>
                  <td align="right" class="tdTotLabel">IVA 22% - Imponibile &euro; <%=((decimal)dblTotimponibile22).ToString("N2", ci) %></td>
                  <td align="right" class="tdTot" width="100"><%=((decimal)dblTotiva22).ToString("N2", ci)%> &euro;</td>
                </tr>
                <%}%>
                <tr>
                  <td align="right" class="tdTotLabel">Totale Complessivo</td>
                  <td align="right" class="tdTot" width="100"><%=((decimal)dblTotcomplessivo).ToString("N2", ci)%> &euro;</td>
                </tr>
                </table>
      </div>                
      <div class="large-3 medium-3 small-12 cell">
        <div class="sidebar text-center">
          <a class="button large primary" href="/checkout/conferma-carrello.html" title="conferma ordine"><i class="fa-duotone fa-cart-shopping"></i>Procedi all'ordine</a>
        </div>
      </div>
    </div>
                

 	<!-- #include file ="/frontend/base/inc-footer.aspx" -->
	<!-- #include file ="/frontend/base/inc-foot.aspx" -->
  </body>
</html>
