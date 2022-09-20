<%
	System.Data.DataTable dtUtenti;
	System.Data.DataTable dtCommesse;
	string strWHERENet="";
	strWHERENet="Utenti_Attivo=1";
	string strFROMNet = "Utenti";
	string strORDERNet = "Utenti_Nominativo";
	dtUtenti = new System.Data.DataTable("Utenti");
	dtUtenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "Utenti_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

	strFROMNet = "Commesse_Vw";
  strWHERENet="CommesseStato_Ky=4";
  strORDERNet = "Commesse_Ky DESC";
	dtCommesse = new System.Data.DataTable("Commesse");
	dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

%>
<br>
<h4>Filtri</h4>
<form action="<%=HttpContext.Current.Request.Url.AbsoluteUri%>" name="formRicerca" id="formRicerca">
  <input type="hidden" name="CoreModules_Ky" value="6" />
  <input type="hidden" name="CoreEntities_Ky" value="79" />
  <input type="hidden" name="CoreGrids_Ky" value="62" />
  <div class="input-group">
  	<select name="Commesse_Ky" id="Commesse_Ky" class="input-group-field select2" placeholder="Filtra progetto">
      <option value=""></option>
      <%  for (int j = 0; j < dtCommesse.Rows.Count; j++){ %>
        <option value="<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>"><%=dtCommesse.Rows[j]["Commesse_Riferimenti"].ToString()%> - <%=dtCommesse.Rows[j]["Commesse_Titolo"].ToString()%> - <%=dtCommesse.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%></option>
      <% } %>
    </select>
    <div class="input-group-button">
      <button type="submit" value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
    </div>
  </div>
</form>
<hr>
<ul class="no-bullet align-middle">
    <li><i class="fa-duotone fa-user fa-fw"></i><a href="/admin/app/attivita/calendario.aspx">Tutti</a><div style="width:12px;height:12px;float:right;background-color:#ff0000;"></div></li>
    <li><i class="fa-duotone fa-user fa-fw"></i><a href="#">Festa</a> <div style="width:12px;height:12px;float:right;background-color:#ff0000;"></div></li>
    <li><hr></li>
    <%  for (int j = 0; j < dtUtenti.Rows.Count; j++){ %>
      <li class="align-middle">
        <% if (dtUtenti.Rows[j]["Utenti_Logo"].ToString().Length>0){
        Response.Write("<img src=\"" + dtUtenti.Rows[j]["Utenti_Logo"].ToString() + "\" width=\"24\" height=\"24\" style=\"border-radius:50%\" loading=\"lazy\">");
        }else{
        Response.Write("<i class=\"fa-duotone fa-user fa-fw\" style=\"color:" + dtUtenti.Rows[j]["Utenti_Colore"].ToString() + "\"></i>");
        } %>
        <a href="/admin/app/attivita/calendario.aspx?Utenti_Ky=<%=dtUtenti.Rows[j]["Utenti_Ky"].ToString()%>&amp;sorgente=calendario"><%=dtUtenti.Rows[j]["Utenti_Nominativo"].ToString()%></a> <div style="width:12px;height:12px;float:right;background-color:<%=dtUtenti.Rows[j]["Utenti_Colore"].ToString()%>"></div></li>
    <% } %>
</ul>

