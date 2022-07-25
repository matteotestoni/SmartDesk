<h2>I miei annunci</h2>
<hr>
<p><i class="fa-duotone fa-table fa-fw"></i>Hai inserito <%=dtAnnunci.Rows.Count%> annunci.</p>
<table class="hover stack">
<thead>
  <tr>
    <th></th>
    <th></th>
    <th>Titolo</th>
    <th>Prezzo</th>
    <th>Visite</th>
    <th>Stato</th>
    <th></th>
   </tr>
</thead>
<tbody>
	<% for (int i = 0; i < dtAnnunci.Rows.Count; i++){%>
  <tr>
    <td>
      <div class="foto-elenco-annunnci" style="background-image:url('<%=dtAnnunci.Rows[i]["Annunci_Foto1"].ToString()%>');height:100px;min-width:150px;">
       <% if (dtAnnunci.Rows[i]["AnnunciTipo_Ky"].ToString()=="1"){ %>
         <a href="/scheda-annuncio.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" class="link" target="blank">
       <% }else{ %>
         <a href="/scheda-lotto.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" class="link" target="blank">
       <% } %>
      </a>
      </div>
    </td>
    <td class="large-text-left small-text-left">
      ID Annuncio: <%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%><br>
      <i class="fa-duotone fa-camera fa-fw"></i><%=dtAnnunci.Rows[i]["Annunci_NumeroFoto"].ToString()%>
    </td>
    <td class="large-text-left small-text-left"><%=dtAnnunci.Rows[i]["Annunci_Titolo"].ToString()%><br><small><%=dtAnnunci.Rows[i]["AnnunciCategorie_Titolo"].ToString()%></small></td>
    <td class="large-text-left small-text-left"><span class="show-for-small-only">Prezzo:</span><strong>&euro; <%=((decimal)dtAnnunci.Rows[i]["Annunci_Valore"]).ToString("N0", ci)%></strong></td>
    <td class="large-text-center small-text-left"><span class="show-for-small-only">Visite:</span><%=dtAnnunci.Rows[i]["Annunci_Visite"].ToString()%></td>
    <td class="large-text-center small-text-left">
      <span class="show-for-small-only">Stato:</span>
      <%
        Response.Write("<span class=\"label\" style=\"background-color:" + dtAnnunci.Rows[i]["AnnunciStato_Colore"].ToString() + "\"><i class=\"fa " + dtAnnunci.Rows[i]["AnnunciStato_Icona"].ToString() + " fa-fw\"></i>" + dtAnnunci.Rows[i]["AnnunciStato_Titolo"].ToString() + "</span>");
      %>
      </span>
    </td>
    <td class="large-text-left small-text-left">
      <a href="/modifica-annuncio.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>"><i class="fa-duotone fa-edit fa-fw"></i>modifica</a>&nbsp;&nbsp; 
      <a href="/scheda-annuncio.aspx?Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" target="blank"><i class="fa-duotone fa-eye fa-fw"></i>vedi</a>&nbsp;&nbsp;      
      <a href="/frontend/areapersonale/elimina-annunci.aspx?azione=delete&Annunci_Ky=<%=dtAnnunci.Rows[i]["Annunci_Ky"].ToString()%>" class="delete"><i class="fa-duotone fa-times fa-fw"></i>elimina</a>
    </td>  
  </tr>
	<% } %>
</tbody>
</table>
