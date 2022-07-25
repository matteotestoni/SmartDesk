<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/area-clienti/app/catalogo/elenco-prodotti.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<!--#include file="/area-clienti/inc-head.aspx"--> 
	<link type="text/css" rel="stylesheet" href="/area-clienti/area-clienti.css"/>
  <script type="text/javascript" src="/area-clienti/area-clienti.js"></script>
	<script>
	jQuery(function() {
		jQuery( "input:submit").button();
		jQuery( "#tabs" ).tabs();
	});
	</script>
</head>
<body>
<!--#include file=/area-clienti/inc-mainbar.aspx --> 
  <div id="main">
    <div id="contenuto">
	            <h1>I miei prodotti</h1>
              <table id="rswgrid" class="grid">
    						<thead>
                <tr>
                  <th width="30">ID</th>
                  <th width="30">Codice</th>
                  <th width="350">Prodotto</th>
                  <th width="80">Categoria</th>
                  <th width="180">Disponibili&agrave;</th>
	        				<th width="140">Stato</th>
                  <th width="30" align="center">Visite</th>
                  <th width="100" align="center">Prezzo</th>
                  <th></th>
                </tr>
					    	</thead>
					    	<tbody>
              <%for (int i = 0; i < dtProdotti.Rows.Count; i++){%>
                  <tr class="cliente">
                    <td><%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%></td>
                    <td><%=dtProdotti.Rows[i]["Prodotti_Codice"].ToString()%></td>
                    <td><div class="Titologrid"><a href="scheda-prodotto.aspx?Prodotti_Ky=<%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%>" class="funzione"><%=dtProdotti.Rows[i]["Prodotti_Titolo"].ToString()%></a></div></td>
                    <td><%=dtProdotti.Rows[i]["ProdottiCategorie_Titolo"].ToString()%></td>
                    <td><%=dtProdotti.Rows[i]["ProdottiDisponibilita_Descrizione"].ToString()%></td>
		          			<td><%=getStato(dtProdotti.Rows[i]["Prodotti_InPromozione"].Equals(true), "Promozione", "red")%> <%=getStato(dtProdotti.Rows[i]["Prodotti_InVetrina"].Equals(true), "Vetrina","blue")%> <%=getStato(dtProdotti.Rows[i]["Prodotti_InOfferta"].Equals(true), "Offerta","green")%> <%=getStato(dtProdotti.Rows[i]["Prodotti_Outlet"].Equals(true), "Outlet","yellow")%></td>
                    <td class="text-center"><%=dtProdotti.Rows[i]["Prodotti_Visite"].ToString()%></td>
                    <td class="text-right"><%=((decimal)dtProdotti.Rows[i]["Prodotti_Prezzo"]).ToString("N2", ci)%></td>
                    <td><a href="elimina-prodotto.aspx?Prodotti_Ky=<%=dtProdotti.Rows[i]["Prodotti_Ky"].ToString()%>" class="funzione" title="elimina"><img src="img/delete.png" border="0" alt="elimina"></a></td>
                  </tr>
              <%}%>
					    	</tbody>
              </table>
              <br><br><br>
      </div>  
  </div>
  <div id="footer">
    <!--#include file="/area-clienti/inc-footer.aspx" -->
  </div>

</body>
</html>
