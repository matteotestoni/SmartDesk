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
  strORDERNet = "Anagrafiche_RagioneSociale, Commesse_Ky DESC";
	dtCommesse = new System.Data.DataTable("Commesse");
	dtCommesse = Smartdesk.Sql.getTablePage(strFROMNet, null, "Commesse_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            

%>
<fieldset class="fieldset">
  <legend>Filtri attivi</legend>
  <ul class="no-bullet align-middle">
      <%  if (Request.Cookies["attivitautente"]!=null && Request.Cookies["attivitautente"].Value.Length>0){ %>
        <li class="align-middle"><a onclick="impostaFiltroUtente(0)"><i class="fa-duotone fa-times fa-fw"></i>Rimuovi filtro utente</a></li>
      <%  } %>
      <%  if (Request.Cookies["attivitaprogetto"]!=null && Request.Cookies["attivitaprogetto"].Value.Length>0){ %>
        <li class="align-middle"><a onclick="impostaFiltroProgetto(0)"><i class="fa-duotone fa-times fa-fw"></i>Rimuovi filtro progetto</a></li>
      <%  } %>
      <%  if (Request.Cookies["attivitastato"]!=null && Request.Cookies["attivitastato"].Value.Length>0){ %>
        <li class="align-middle"><a onclick="impostaFiltroStato(0)"><i class="fa-duotone fa-times fa-fw"></i>Rimuovi filtro stato</a></li>
      <%  } %>
      <%  if (Request.Cookies["attivitatipo"]!=null && Request.Cookies["attivitatipo"].Value.Length>0){ %>
        <li class="align-middle"><a onclick="impostaFiltroTipo(0)"><i class="fa-duotone fa-times fa-fw"></i>Rimuovi filtro tipo</a></li>
      <%  } %>
      <%  if (Request.Cookies["attivitacategoria"]!=null && Request.Cookies["attivitacategoria"].Value.Length>0){ %>
        <li class="align-middle"><a onclick="impostaFiltroCategoria(0)"><i class="fa-duotone fa-times fa-fw"></i>Rimuovi filtro categoria</a></li>
      <%  } %>
      <%  if (Request.Cookies["attivitasettore"]!=null && Request.Cookies["attivitasettore"].Value.Length>0){ %>
        <li class="align-middle"><a onclick="impostaFiltroSettore(0)"><i class="fa-duotone fa-times fa-fw"></i>Rimuovi filtro settore</a></li>
      <%  } %>
  </ul>
</fieldset>

<fieldset class="fieldset">
  <legend>Filtri</legend>
  <label>Filtro per utente</label>
  <ul class="no-bullet align-middle">
      <%  for (int j = 0; j < dtUtenti.Rows.Count; j++){ %>
        <li class="align-middle">
          <% if (dtUtenti.Rows[j]["Utenti_Logo"].ToString().Length>0){
          Response.Write("<img src=\"" + dtUtenti.Rows[j]["Utenti_Logo"].ToString() + "\" width=\"24\" height=\"24\" style=\"border-radius:50%\" loading=\"lazy\">");
          }else{
          Response.Write("<i class=\"fa-duotone fa-user fa-fw\" style=\"color:" + dtUtenti.Rows[j]["Utenti_Colore"].ToString() + "\"></i>");
          } %>
          <a onclick="impostaFiltroUtente('<%=dtUtenti.Rows[j]["Utenti_Ky"].ToString()%>')"><%=dtUtenti.Rows[j]["Utenti_Nominativo"].ToString()%></a> <div style="width:12px;height:12px;float:right;background-color:<%=dtUtenti.Rows[j]["Utenti_Colore"].ToString()%>"></div></li>
      <% } %>
  </ul>
  <hr>
  <form action="<%=HttpContext.Current.Request.Url.AbsoluteUri%>" name="formRicerca" id="formRicerca">
    <input type="hidden" name="CoreModules_Ky" value="6" />
    <input type="hidden" name="CoreEntities_Ky" value="79" />
    <input type="hidden" name="CoreGrids_Ky" value="62" />
    <label>Filtro per progetto</label>
    <div class="input-group">
    	<select name="Commesse_Ky" id="Commesse_Ky" class="input-group-field" placeholder="Filtra progetto" onchange="impostaFiltroProgetto(this.value)">
        <option value=""></option>
        <%  for (int j = 0; j < dtCommesse.Rows.Count; j++){ %>
          <option value="<%=dtCommesse.Rows[j]["Commesse_Ky"].ToString()%>"><%=dtCommesse.Rows[j]["Anagrafiche_RagioneSociale"].ToString()%> - <%=dtCommesse.Rows[j]["Commesse_Riferimenti"].ToString()%> - <%=dtCommesse.Rows[j]["Commesse_Titolo"].ToString()%></option>
        <% } %>
      </select>
      <div class="input-group-button">
        <button type="submit" value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
      </div>
    </div>
  </form>
  <label>Filtro per stato</label>
  <div class="input-group">
  	<select name="AttivitaStati_Ky" id="AttivitaStati_Ky" class="input-group-field" placeholder="Filtra per stato" onchange="impostaFiltroStato(this.value)">
      <option value=""></option>
      <!--#include file="/var/cache/AttivitaStati-options.htm"-->
    </select>
    <div class="input-group-button">
      <button value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
    </div>
  </div>
  <label>Filtro per settore</label>
  <div class="input-group">
  	<select name="AttivitaSettore_Ky" id="AttivitaSettore_Ky" class="input-group-field" placeholder="Filtra per categoria" onchange="impostaFiltroSettore(this.value)">
      <option value=""></option>
      <!--#include file="/var/cache/AttivitaSettore-options.htm"-->
    </select>
    <div class="input-group-button">
      <button value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
    </div>
  </div>
  <label>Filtro per categoria</label>
  <div class="input-group">
  	<select name="AttivitaCategorie_Ky" id="AttivitaCategorie_Ky" class="input-group-field" placeholder="Filtra per categoria" onchange="impostaFiltroCategoria(this.value)">
      <option value=""></option>
      <!--#include file="/var/cache/AttivitaCategorie-options.htm"-->
    </select>
    <div class="input-group-button">
      <button value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
    </div>
  </div>
  <label>Filtro per tipo</label>
  <div class="input-group">
  	<select name="AttivitaTipo_Ky" id="AttivitaTipo_Ky" class="input-group-field" placeholder="Filtra per tipo" onchange="impostaFiltroTipo(this.value)">
      <option value=""></option>
      <!--#include file="/var/cache/AttivitaTipo-options.htm"-->
    </select>
    <div class="input-group-button">
      <button value="cerca" name="cerca" class="tiny button secondary"><i class="fa-duotone fa-magnifying-glass fa-fw"></i></button>
    </div>
  </div>
</fieldset>
<script>
  function impostaFiltroUtente(intUtenti_Ky){
    if (intUtenti_Ky==0){
      Cookies.set("attivitautente", "", { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }else{
      Cookies.set("attivitautente", intUtenti_Ky, { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }
    location.reload();
  }
  function impostaFiltroProgetto(intCommesse_Ky){
    if (intCommesse_Ky==0){
      Cookies.set("attivitaprogetto", "", { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }else{
      Cookies.set("attivitaprogetto", intCommesse_Ky, { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }
    location.reload();
  }
  function impostaFiltroStato(intAttivitaStati_Ky){
    if (intAttivitaStati_Ky==0){
      Cookies.set("attivitastato", "", { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }else{
      Cookies.set("attivitastato", intAttivitaStati_Ky, { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }
    location.reload();
  }
  function impostaFiltroCategoria(intAttivitaCategorie_Ky){
    if (intAttivitaCategorie_Ky==0){
      Cookies.set("attivitacategoria", "", { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }else{
      Cookies.set("attivitacategoria", intAttivitaCategorie_Ky, { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }
    location.reload();
  }
  function impostaFiltroSettore(intAttivitaSettore_Ky){
    if (intAttivitaSettore_Ky==0){
      Cookies.set("attivitasettore", "", { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }else{
      Cookies.set("attivitasettore", intAttivitaSettore_Ky, { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }
    location.reload();
  }
  function impostaFiltroTipo(intAttivitaTipo_Ky){
    if (intAttivitaTipo_Ky==0){
      Cookies.set("attivitatipo", "", { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }else{
      Cookies.set("attivitatipo", intAttivitaTipo_Ky, { secure: true, sameSite: 'Lax', expires: 1, path: '/' });
    }
    location.reload();
  }
</script>

