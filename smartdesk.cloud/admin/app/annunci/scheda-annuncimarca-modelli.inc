<% if (dtLogin.Rows[0]["UtentiGruppi_Annunci"].Equals(true) && strAzione!="new"){ %>
<a name="annuncimodelli"></a>
<div class="grid-container" id="divannuncimodelli" data-magellan-target="divannuncimodelli">
<div class="grid-x grid-padding-x">
  <div class="small-12 medium-12 large-12 cell">
		<div class="card">
		  <div class="card-divider">
    		<a name="SitiWeb"></a>
	    		<h2><i class="fa-duotone fa-building fa-lg fa-fw"></i>Modelli associati alla marca (<%=dtAnnunciModello.Rows.Count%>)</h2>
		  </div>
		  <div class="card-section">
		    <fieldset class="fieldset">
		    	<legend>Inserisci nuovo modello</legend>
					<form action="/admin/app/annunci/crud/salva-annuncimodello.aspx" method="post" data-abide novalidate style="background:none;padding:0;border:0;box-shadow:none;">
			      <input type="hidden" name="AnnunciMarca_Ky" id="AnnunciMarca_Ky" value="<%=GetFieldValue(dtAnnunciMarca, "AnnunciMarca_Ky")%>">
			      <input type="hidden" name="AnnunciModello_Ky" id="AnnunciModello_Ky" value="">
		      	<input type="hidden" name="azione" id="azione" value="new">
		      	<input type="hidden" name="sorgente" id="sorgente" value="scheda-annuncimarca">
		      	<!--#include file=/admin/app/annunci/forms/annuncimodello_form.htm -->
				  </form>
				</fieldset>
	    	<% if (dtAnnunciModello!=null && dtAnnunciModello.Rows.Count>0){ %>
          <div class="grid-x grid-padding-x">
            <div class="large-3 medium-3 small-8 cell end">
              <form name="azionidigruppo-form" id="azionidigruppo-form" class="form-azione" method="post" action="#">
              <div class="input-group">
                <select class="input-group-field" name="azionidigruppo" id="azionidigruppo">
                  <option value="">Azioni di gruppo</option>
                  <option value="delete" data-action="/admin/app/core/crud/elimina-annuncimodelli.aspx">Elimina</option>
                </select>
                <div class="input-group-button">
                  <input type="hidden" id="sorgente" name="sorgente" value="elenco-annuncimodelli">
                  <input type="hidden" id="azione" name="azione" value="">
                  <input type="hidden" id="deletemultiplo" name="deletemultiplo" value="deletemultiplo">
                  <input type="hidden" id="azionidigruppo-ids" name="azionidigruppo-ids" value="">
                  <input type="submit" id="doaction" class="button secondary" value="Applica">
                </div>
              </div>
              </form>
            </div>
          </div>
          
			    <table class="grid hover scroll" border="0" width="100%">
			    	<thead>
				      <tr>
				        <th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
				        <th width="40">Cod.</th>
				        <th width="400">Titolo</th>
				        <th width="100">Tipo</th>
				        <th width="12" class="nowrap" data-orderable="false"></th>
				      </tr>
			    	</thead>
			    	<tbody>
					    <%for (int i = 0; i < dtAnnunciModello.Rows.Count; i++){ %>
					        <tr class="riga<%=i%2%>">
		                <td><input type="checkbox" class="checkrow" id="record<%=dtAnnunciModello.Rows[i]["AnnunciModello_Ky"].ToString()%>" data-value="<%=dtAnnunciModello.Rows[i]["AnnunciModello_Ky"].ToString()%>" /></td>
					          <td><a href="/admin/app/annunci/scheda-annuncimodello.aspx?AnnunciModello_Ky=<%=dtAnnunciModello.Rows[i]["AnnunciModello_Ky"].ToString()%>&azione=edit"><%=dtAnnunciModello.Rows[i]["AnnunciModello_Ky"].ToString()%></a></td>
					          <td><i class="fa-duotone fa-tag fa-fw"></i><%=dtAnnunciModello.Rows[i]["AnnunciModello_Titolo"].ToString()%></td>
					          <td><%=dtAnnunciModello.Rows[i]["AnnunciModelloTipo_Titolo"].ToString()%></td>
										<td>
                      <a href="/admin/crud/elimina.aspx?azione=delete&ajax=&CoreGrids_Ky=45&AnnunciModello_Ky=<%=dtAnnunciModello.Rows[i]["AnnunciModello_Ky"].ToString()%>&AnnunciMarca_Ky=<%=dtAnnunciModello.Rows[i]["AnnunciMarca_Ky"].ToString()%>&sorgente=form-213" title="elimina" class="delete"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
                    </td>
					        </tr>
					    <% } %>
			    	</tbody>
			    </table>
	    <% }else{
			    Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><span class=\"messaggio\"><i class=\"fa-duotone fa-circle-info fa-fw\"></i>Nessun modello</span></div></div>");
	    } %>
    </div>
  </div>

	</div>
</div>
<% } %>
