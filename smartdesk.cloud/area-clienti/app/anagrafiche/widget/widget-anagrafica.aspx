<div class="card" id="sectionanagrafiche">
  <div class="card-divider">
    <h2>I tuoi dati
        &nbsp;&nbsp;
    </h2>
    <a href="/area-clienti/app/anagrafiche/profilo.aspx" class="small button secondary"><i class="fa-duotone fa-square-plus fa-fw"></i>Modifica</a>
  </div>		  
	<div class="card-section">
        <i class="fa-duotone fa-user fa-fw"></i><%=dtAnagrafica.Rows[0]["Anagrafiche_RagioneSociale"].ToString()%><br />
        <i class="fa-duotone fa-location-dot fa-fw"></i><%=dtAnagrafica.Rows[0]["Anagrafiche_Indirizzo"].ToString()%> - <%=dtAnagrafica.Rows[0]["Anagrafiche_CAP"].ToString()%> <%=dtAnagrafica.Rows[0]["Comuni_Comune"].ToString()%> (<%=dtAnagrafica.Rows[0]["Province_Provincia"].ToString()%>)<br />
        <%if (dtAnagrafica.Rows[0]["Anagrafiche_PartitaIVA"].ToString().Length>0){ %>
          <b>Partita IVA: <%=dtAnagrafica.Rows[0]["Anagrafiche_PartitaIVA"].ToString()%></b>
        <% } %>
        <%if (dtAnagrafica.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){ %>
         - <b>Codice Fiscale: <%=dtAnagrafica.Rows[0]["Anagrafiche_CodiceFiscale"].ToString()%></b>
        <% } %>
        <br />
        <i class="fa-duotone fa-phone fa-fw"></i>Telefono: <%=dtAnagrafica.Rows[0]["Anagrafiche_Telefono"].ToString()%><br />
        <i class="fa-duotone fa-envelope fa-fw"></i>Email di contatto: <%=dtAnagrafica.Rows[0]["Anagrafiche_EmailContatti"].ToString()%><br />
        <i class="fa-duotone fa-envelope fa-fw"></i>Email dove ti inviamo le fatture: <%=dtAnagrafica.Rows[0]["Anagrafiche_EmailAmministrazione"].ToString()%><br />
  </div>		  
</div>
