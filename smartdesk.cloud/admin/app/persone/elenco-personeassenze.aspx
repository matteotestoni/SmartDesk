<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/persone/elenco-personeassenze.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Assenze > Elenco assenze</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-4 medium-4 small-12 cell align-middle">
            <h1><i class="fa-duotone fa-users fa-fw"></i>Persone > <i class="fa-duotone fa-calendar-days fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-8 medium-8 small-12 cell float-right align-middle">
        			<div class="stacked-for-small button-group small hide-for-print align-right">
        				<a class="button clear" data-toggle="filtri"><i class="fa-duotone fa-magnifying-glass fa-lg fa-fw"></i>Cerca</a>
        				<a href="/admin/app/persone/elenco-personeassenze.aspx?tutti=tutti" class="button clear"><i class="fa-duotone fa-filter-slash fa-lg fa-fw"></i>Rimuovi filtri</a>
        				<a href="/admin/app/persone/scheda-personeassenze.aspx?azione=new" class="button clear hide"><i class="fa-duotone fa-umbrella-beach fa-lg fa-fw"></i>Richiedi Permesso/Ferie</a>
        				<a href="/admin/app/persone/scheda-personeassenze.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Inserisci presenza/assenza</a>
          		</div>
  	      </div>
      </div>
  </div>
</div>

<div class="grid-x grid-padding-x">
  <div class="large-12 medium-12 small-12 cell">
        <div class="divgridfilter">
          <!--#include file=/admin/app/persone/where/where-personeassenze.inc --> 
          <div class="stacked-for-small button-group tiny hide-for-print align-left">
            <% for (int x = 1; x < 13; x++){ %>
              <a href="/admin/app/persone/elenco-personeassenze.aspx?mese=<%=x%>&anno=<%=strAnno%>" class="button secondary"><%=Smartdesk.Functions.GetMese(x.ToString())%> <%=strAnno%></a>
            <% } %>
              <a href="/admin/app/persone/elenco-personeassenze.aspx?anno=<%=strAnno%>&mese=tutti" class="button secondary">Tutto il <%=strAnno%></a>
          </div>
          <br>
        </div>

		    <%
          intAnno=0;
					for (int x = 0; x < dtPersone.Rows.Count; x++){ 
          	intOreFerie=Convert.ToInt32(dtPersone.Rows[x]["Persone_OreFerie"].ToString());
          	intOreGiornaliere=Convert.ToInt32(dtPersone.Rows[x]["Persone_OreGiornaliere"].ToString());
            if (intOreGiornaliere==0){ intOreGiornaliere=1; }
            strFROMNet = "PersoneAssenze_Vw";
            strWHERENet = "Persone_Ky=" + dtPersone.Rows[x]["Persone_Ky"].ToString() + " AND PersoneAssenze_Anno=" + strAnno;
            if (Request["mese"] != null && Request["mese"] != "" && Request["mese"] != "tutti") {
              strWHERENet = strWHERENet + " And (Month(PersoneAssenze_Data)=" + Request["mese"] + ")";
            }else{
              if (Request["mese"] != "tutti"){
                strWHERENet = strWHERENet + " And (Month(PersoneAssenze_Data)=" + strMese + ")";
              }
            }       
            strORDERNet = "Persone_Cognome, PersoneAssenze_Data ASC";
            dtAssenze = Smartdesk.Sql.getTablePage(strFROMNet, null, "PersoneAssenze_Ky", strWHERENet, strORDERNet, 1, 2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          %>
          <div class="divgrid">
    <div class="grid-x grid-padding-x">
      <div class="large-9 medium-9 small-12 cell">
  			<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
      </div>
      <div class="large-3 medium-3 small-8 cell end">
        <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
        <div class="input-group">
          <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
            <option value="">Azioni di gruppo</option>
            <option value="delete" data-action="/admin/app/progetti/crud/elimina-commesse.aspx">Elimina</option>
          </select>
          <div class="input-group-button">
            <input type="hidden" id="sorgente" name="sorgente" value="elenco-commesse">
            <input type="hidden" id="azione" name="azione" value="">
            <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
            <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
            <button id="doaction" class="button secondary">Applica</button>
          </div>
        </div>
        </form>
      </div>
    </div>
              <div class="grid-x grid-padding-x">
                <div class="small-12 medium-12 large-12 cell">
                  <img src="<%=dtPersone.Rows[x]["Persone_Foto"].ToString()%>" width="40" height="40" align="left" style="padding-right:10px;">
                  <h2><%=dtPersone.Rows[x]["Persone_Nome"].ToString()%> <%=dtPersone.Rows[x]["Persone_Cognome"].ToString()%> - <%=intOreGiornaliere%> ore giornaliere</h2>
                </div>
              </div>
              
              <table class="grid hover scroll" border="0" width="100%">
              <thead>
                <tr>
              		<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
                  <th width="110" class="text-center date">Data</th>
                  <th width="80">Giorno</th>
                  <th width="100">Settimana</th>
                  <th width="130">Anno compentenza</th>
                  <th align="left" width="250">Descrizione</th>
                  <th width="150" align="left">Di chi</th>
                  <th width="70">Ore</th>
                  <th width="120">Tipo</th>
                  <th width="12" class="nowrap" data-orderable="false"></th>
                  <th width="12" class="nowrap" data-orderable="false"></th>
                </tr>
              </thead>
              <tbody>
              <% 
              decTotProgressivo=0;
              decTotAssenze=0;
              decTotRecuperi=0;              
              decTotMalattia=0;
              decTotCassaIntegrazione=0;
              decTotPresenzeOrdinarie=0;
              decTotPresenzeStraordinarie=0;
              decTotFestivita=0;
              for (int i = 0; i < dtAssenze.Rows.Count; i++){
                switch (dtAssenze.Rows[i]["PersoneAssenzeTipo_Segno"].ToString()){
                  case "+":
                    decTotProgressivo+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
                    break;
                  case "-":
                    decTotProgressivo-=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
                    break;
                 } %>
            
                <tr class="riga<%=i%2%>" id="<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>">
                  <td><input type="checkbox" class="checkrow" id="record<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>" data-value="<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>" /></td>
                  <td>
                    <i class="fa-duotone fa-calendar-days fa-fw"></i>
                  <% if (dtAssenze.Rows[i]["PersoneAssenze_Lock"].Equals(false)){ %>
                  <a href="/admin/app/persone/scheda-personeassenze.aspx?PersoneAssenze_Ky=<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>">
                  <% } %>
                  <%=dtAssenze.Rows[i]["PersoneAssenze_Data_IT"].ToString()%>
                  <% if (dtAssenze.Rows[i]["PersoneAssenze_Lock"].Equals(false)){ %>
                  </a> 
                  <% } %>
                  
                  </td>
                  <td class="large-text-center small-text-left"><%=Smartdesk.Functions.GetGiorno(dtAssenze.Rows[i]["PersoneAssenze_Data"].ToString())%></td>
                  <td class="large-text-center small-text-left"><%=Smartdesk.Functions.GetSettimana(dtAssenze.Rows[i]["PersoneAssenze_Data"].ToString())%></td>
                  <td class="large-text-center small-text-left"><%=dtAssenze.Rows[i]["PersoneAssenze_Anno"].ToString()%></td>
                  <td><div class="width300"><%=dtAssenze.Rows[i]["PersoneAssenze_Descrizione"].ToString()%></div></td>
                  <td><i class="fa-duotone fa-user fa-fw"></i><%=dtAssenze.Rows[i]["Persone_Nome"].ToString()%> <%=dtAssenze.Rows[i]["Persone_Cognome"].ToString()%></td>
                  <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=dtAssenze.Rows[i]["PersoneAssenzeTipo_Segno"].ToString()%><%=dtAssenze.Rows[i]["PersoneAssenze_Ore"].ToString()%></strong></td>
                  <td class="large-text-center small-text-left"><strong><%=dtAssenze.Rows[i]["PersoneAssenzeTipo_Descrizione"].ToString()%></strong></td>
                  <td>
                  	<% if (dtAssenze.Rows[i]["PersoneAssenze_Lock"].Equals(false)){ %>
                  		<a href="/admin/app/persone/actions/conferma-assenza.aspx?PersoneAssenze_Ky=<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>&Persone_Ky=<%=dtAssenze.Rows[i]["Persone_Ky"].ToString()%>&sorgente=elenco-personeassenze" title="conferma assenza pianificata"><i class="fa-duotone fa-check success"></i></a>
                  	<% } %>
                  </td>
                  <td>
                  	<% if (dtAssenze.Rows[i]["PersoneAssenze_Lock"].Equals(false)){ %>
                  		<a href="/admin/app/persone/crud/elimina-personeassenze.aspx?azione=delete&PersoneAssenze_Ky=<%=dtAssenze.Rows[i]["PersoneAssenze_Ky"].ToString()%>&Persone_Ky=<%=dtAssenze.Rows[i]["Persone_Ky"].ToString()%>&sorgente=elenco-personeassenze" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
                  	<% } %>
                  </td>
                </tr>
            <%
            j=j+1;
            switch (Convert.ToInt32(dtAssenze.Rows[i]["PersoneAssenzeTipo_Ky"])){
            case 1:
              decTotAssenze+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            case 2:
              decTotRecuperi+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            case 3:
              decTotMalattia+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            case 4:
              decTotCassaIntegrazione+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;					
            case 5:
              decTotPresenzeOrdinarie+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            case 6:
              decTotPresenzeStraordinarie+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            case 7:
              decTotFestivita+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            case 8:
              decTotRitardi+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            case 9:
              decTotUsciteAnticipate+=Convert.ToDecimal(dtAssenze.Rows[i]["PersoneAssenze_Ore"]);
              break;
            }
            intPersone_Ky=Convert.ToInt32(dtAssenze.Rows[i]["Persone_Ky"].ToString());
            intAnno=Convert.ToInt32(dtAssenze.Rows[i]["PersoneAssenze_Anno"].ToString());			
            }
            decSaldo=intOreFerie+decTotRecuperi-decTotAssenze;
            %>
            <tr class="totale">
            <td bgcolor="#ffffff" colspan="6"></td>
            <td class="text-left">Ore Festivit&agrave;:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotFestivita.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotFestivita/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
            <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
              <td bgcolor="#ffffff" colspan="6"></td>
              <td class="text-left">Assenze <%=intAnno%>:</td>
              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotAssenze.ToString("N2", ci)%></strong></td>
              <td colspan="2">| circa <%=(decTotAssenze/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
              <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
              <td bgcolor="#ffffff" colspan="6"></td>
              <td class="text-left">Ritardi <%=intAnno%>:</td>
              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotRitardi.ToString("N2", ci)%></strong></td>
              <td colspan="2">| circa <%=(decTotRitardi/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
              <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
              <td bgcolor="#ffffff" colspan="6"></td>
              <td class="text-left">Uscite anticipate <%=intAnno%>:</td>
              <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotUsciteAnticipate.ToString("N2", ci)%></strong></td>
              <td colspan="2">| circa <%=(decTotUsciteAnticipate/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
              <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
            <td bgcolor="#ffffff" colspan="6"></td>
            <td class="text-left">Recuperi <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotRecuperi.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotRecuperi/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
            <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
            <td bgcolor="#ffffff" colspan="6"></td>
            <td class="text-left">Presenze ordinarie <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotPresenzeOrdinarie.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotPresenzeOrdinarie/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
            <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
            <td bgcolor="#ffffff" colspan="6"></td>
            <td class="text-left">Presenze straordinarie <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotPresenzeStraordinarie.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotPresenzeStraordinarie/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
            <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
            <td bgcolor="#ffffff" colspan="6"></td>
            <td class="text-left">Malattia <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotMalattia.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotMalattia/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
            <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale">
            <td bgcolor="#ffffff" colspan="6"></td>
            <td class="text-left">Cassa integrazione <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=decTotCassaIntegrazione.ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=(decTotCassaIntegrazione/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
            <td bgcolor="#ffffff"></td>
            </tr>
            <tr class="totale hide">
            <td bgcolor="#ffffff" colspan="6"></td>
            <td class="text-left">Saldo <%=intAnno%>:</td>
            <td class="large-text-right small-text-left"><i class="fa-duotone fa-clock fa-fw"></i><strong><%=(intOreFerie+decTotRecuperi-decTotAssenze).ToString("N2", ci)%></strong></td>
            <td colspan="2">| circa <%=((intOreFerie+decTotRecuperi-decTotAssenze)/intOreGiornaliere).ToString("N2", ci)%> giorni</td>
            <td bgcolor="#ffffff"></td>
            </tr>
            </table>
          </div>
          
          
          <% } %>          

  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
</body>
</html>
