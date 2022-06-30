<%@ Page Language="C#" Culture="it-IT" uiCulture="it-IT" AutoEventWireup="true"  CodeFile="carrello-conferma.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-15" />
  <title>Rehastore - Distributore per l'italia dei prodotti homecraft rolyan</title>
	<meta name="description" content="Distributore per l'italia dei prodotti homecraft rolyan" />
	<meta name="keywords" content="prodotti homecraft rolyan, prodotti medicali" />
  <link rel="stylesheet" href="/style.css" type="text/css" />
  <script type="text/javascript" src="/rehastore.js"></script>
  <script src="/Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
  <link rel="shortcut icon" href="/images/favicon.ico" />
</head>
<body bgcolor="#083591" background="/bg.gif" style="background-repeat: repeat-x" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0" onload="Init()">
<table width="970" border="0" align="center" cellpadding="0" cellspacing="0">
  <tr>
    <td width="13" background="/img/bordo-sx.gif" style="background-repeat: no-repeat; background-position:top">&nbsp;</td>
    <td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <%Response.WriteFile("/inc-menuheader.htm");%>
      </tr>
      <tr>
        <td>
        <%Response.WriteFile("/inc-animazioneflash.htm");%>
        </td>
      </tr>
      <tr>
        <td>&nbsp;</td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="12">&nbsp;</td>
            <td width="10"><img src="/img/sx-menutop.gif" width="10" height="45" /></td>
            <td background="/img/bg-menutop.gif">
            <%Response.WriteFile("/inc-menutop.htm");%>
            </td>
            <td width="11"><img src="/img/dx-top.gif" width="11" height="45" /></td>
            <td width="12">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="12">&nbsp;</td>
            <td width="265" valign="top" background="/img/ombra-menu.gif" style="background-repeat: repeat-x; padding-top:13px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td height="38" background="/img/bg-titolo-prodotti.gif" style="padding-left: 12px"><span class="TITOLETTI">I NOSTRI PRODOTTI</span></td>
              </tr>
              <tr>
                <td height="100" valign="top" background="/img/ombra-titolo-prodotti.gif" style="background-repeat: no-repeat; padding-top:12px; padding-left: 6px">
                  <!--#include file=/inc-menucategorie.aspx -->
                </td>
              </tr>
              <tr>
                <td><img src="/img/trasp.gif" width="1" height="12" /></td>
              </tr>
              <tr>
                <td height="38" background="/img/bg-cerca.gif">
                  <%Response.WriteFile("/inc-cerca.htm");%>
                </td>
              </tr>
              <tr>
                <td><img src="/img/trasp.gif" width="1" height="12" /></td>
              </tr>
              <tr>
                <td><table width="100%" border="0" cellspacing="0" cellpadding="0">
                  <tr>
                    <td><img src="/img/top-carrello.gif" width="265" height="10" /></td>
                  </tr>
                  <tr>
                    <td height="68" valign="top" background="/img/bg-carrello.gif" bgcolor="#434343" style="background-repeat:repeat-x; padding-left: 14px">
                      <!--#include file=/inc-carrello.aspx -->
                    </td>
                  </tr>
                  <tr>
                    <td><img src="/img/bottom-carrello.gif" width="265" height="12" /></td>
                  </tr>
                </table></td>
              </tr>
              <tr>
                <td><img src="/img/trasp.gif" width="1" height="12" /></td>
              </tr>
              <%
              if (boolLogin==false){
                Response.WriteFile("/inc-login.htm");
              }
              %>
              <tr>
                <td>&nbsp;</td>
              </tr>
            </table></td>
            <td width="23" background="/img/ombra-menu.gif" style="background-repeat: repeat-x; padding-top:13px">&nbsp;</td>
            <td valign="top" background="/img/ombra-menu.gif" style="background-repeat: repeat-x; padding-top:13px"><table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><span  class="titolohome">CONFERMA ORDINE</span></td>
              </tr>
              <tr>
                <td height="8"><img src="/img/sep-vetrina.gif" width="627" height="1" /></td>
              </tr>
              <tr>
                <td style="padding-right: 15px; padding-top: 5px">
                  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableCarrello">
                  <tr>
                    <td align="left">
                      <div id="destinatario">
                        Destinatario<br />
                        <span class="ragionesociale"><%=dtAnagrafiche.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%> <%=dtAnagrafiche.Rows[0]["Anagrafiche_Nome"].ToString()%> <%=dtAnagrafiche.Rows[0]["Anagrafiche_Cognome"].ToString()%></span><br />
                        <%=dtAnagrafiche.Rows[0]["Anagrafiche_Email"].ToString()%><br />
                        <%=dtAnagrafiche.Rows[0]["Anagrafiche_Indirizzo"].ToString()%><br />
                        <%=dtAnagrafiche.Rows[0]["Comuni_Comune"].ToString()%><br />
                        Cod. Fisc. <%=dtAnagrafiche.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%> - P.IVA <%=dtAnagrafiche.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%><br />
                      </div>
                    </td>
                  </table>

                  <table width="100%" border="0" cellspacing="0" cellpadding="0" class="tableCarrello" style="margin-top:5px;">
                  <tr>
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
                        <td class="tdRow" align="center">
                          <a href="/scheda-prodotto.aspx?Prodotti_Ky=<%=dtCarrello.Rows[i]["Prodotti_Ky"].ToString()%>" class="menuprodottivetrina" title="<%=dtCarrello.Rows[i]["Prodotti_Titolo"].ToString()%>">
                          <%if (dtCarrello.Rows[i]["Prodotti_Foto1s"].ToString().Length>0){%>
                            <img src="<%=dtCarrello.Rows[i]["Prodotti_Foto1s"].ToString()%>" height="50" border="0" style="border:1px solid #cdcdcd" alt="<%=dtCarrello.Rows[i]["Prodotti_Titolo"].ToString()%>" />
                          <%}else{%>
                            <img src="/img/no-image.gif" width="100" border="0" style="border:1px solid #cdcdcd" />
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
                          Response.Write(((decimal)dtCarrello.Rows[i]["Prodotti_Prezzo"]).ToString("N2", ci));
                          %>
                        </td>
                        <td class="tdRow" align="right"><%=dtCarrello.Rows[i]["Carrello_Qta"].ToString()%></td>
                        <td class="tdRow" align="right"><span class="prezzo">&euro; <%=((decimal)dblSubtotale).ToString("N2", ci)%></span>
                        <br />
                        <%Response.Write(dtCarrello.Rows[i]["ImposizioniIVA_Descrizione"].ToString());%>
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
                </table>
                <form action="/invia-ordine.aspx" method="post" name="formInviaOrdine" id="formInviaOrdine">
                <table border="0" cellspacing="2" cellpadding="2" style="border:1px solid #BEBCB7;width:100%;margin-top:5px;">
                <tr>
                  <td align="right">Metodo di Spedizione</td>
                  <td align="right" width="150">
                    <select name="Spedizioni_Ky" id="Spedizioni_Ky" style="width:150px">
                    <%for (i = 0; i <= intNumRecordsSpedizioni-1; i++){
                      if (i < intNumRecordsSpedizioni){
                        Response.Write("<option value=\"" + dtSpedizioni.Rows[i]["Spedizioni_Ky"].ToString()  + "\">" + dtSpedizioni.Rows[i]["Spedizioni_Descrizione"].ToString()  + "</option>");
                      }
                    }%>
                    </select>
                  </td>
                </tr>
                <tr>
                  <td align="right">Metodo di Pagamento</td>
                  <td align="right" width="150">
                    <select name="PagamentiMetodo_Ky" id="PagamentiMetodo_Ky" style="width:150px">
                    <%for (i = 0; i <= intNumRecordsPagamenti-1; i++){
                      if (i < intNumRecordsPagamenti){
                        Response.Write("<option value=\"" + dtPagamentiMetodo.Rows[i]["PagamentiMetodo_Ky"].ToString()  + "\">" + dtPagamentiMetodo.Rows[i]["PagamentiMetodo_Descrizione"].ToString()  + "</option>");
                      }
                    }%>
                    </select>
                  </td>
                </tr>
                </table>
                <%
                  dblTotiva4 = (dblTotimponibile4*4/100);
                  dblTotiva10 = (dblTotimponibile10*10/100);
                  dblTotiva22 = (dblTotimponibile22*22/100);

                  dblTotiva = dblTotiva4 + dblTotiva10 + dblTotiva22;
                  dblTotimponibile=dblTotimponibile4+dblTotimponibile10+dblTotimponibile22;
                  dblTotcomplessivo = dblTotimponibile+dblTotiva;
                %>
                <table border="0" cellspacing="2" cellpadding="2" style="border:1px solid #BEBCB7;width:100%;margin-top:5px;">
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
                <tr>
                  <td align="right" colspan="2">
                    <br />
                    <input type="hidden" id="Totale" name="Totale" value="<%=dblTotcomplessivo.ToString().Replace(",",".")%>" />
                    <input type="submit" id="btnInviaOrdine" name="btnInviaOrdine" class="buttoninviaordine" value="" />
                  </td>
                </tr>
                </table>
                </form>


                  </td>
              </tr>
            </table></td>
            <td width="12">&nbsp;</td>
          </tr>
        </table></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">&nbsp;</td>
      </tr>
    </table></td>
    <td width="13" background="/img/bordo-dx.gif" style="background-repeat: no-repeat; background-position:top">&nbsp;</td>
  </tr>
</table>
<script type="text/javascript">
var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<script type="text/javascript">
try {
var pageTracker = _gat._getTracker("UA-7394836-7");
pageTracker._trackPageview();
} catch(err) {}</script>
</body>
</html>
