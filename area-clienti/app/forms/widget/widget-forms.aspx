<%
  System.Data.DataTable dtForms;
  System.Data.DataTable dtFormsAvanzamento;
  string strAvanzamento="";
  strWHERENet="Forms_PubblicaWeb=1";
  strFROMNet = "Forms";
  strORDERNet = "Forms_Data DESC";
  dtForms = new System.Data.DataTable("Forms");
  dtForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "Forms_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);            
  

  if (dtForms.Rows.Count>0){ %>
    <div class="card" id="sectionforms">
      <div class="card-divider">
        <h2>I tuoi Sondaggi</h2>
      </div>		  
    	<div class="card-section">
          <%if (dtForms.Rows.Count>0){%>
            <table class="grid" border="0" style="width:100%;">
            <thead>
              <tr>
              <th class="text-left" width="300"><strong>Sondaggio</strong></th>
              <th class="text-left" width="300"><strong>Data</strong></th>
              <th class="text-left" width="200"><strong>Stato di compilazione</strong></th>
              <th></th>
            </tr>
            </thead>
            <tbody>
            <%
            decTot=0;
            for (int i = 0; i < dtForms.Rows.Count; i++){
              strWHERENet="Forms_Ky=" + dtForms.Rows[i]["Forms_Ky"].ToString() + " AND Anagrafiche_Ky=" + dtLogin.Rows[0]["Anagrafiche_Ky"].ToString();
              strFROMNet = "FormsAvanzamento";
              strORDERNet = "FormsAvanzamento_Ky DESC";
              dtFormsAvanzamento = new System.Data.DataTable("FormsAvanzamento");
              dtFormsAvanzamento = Smartdesk.Sql.getTablePage(strFROMNet, null, "FormsAvanzamento_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtFormsAvanzamento!=null && dtFormsAvanzamento.Rows.Count>0){
                  strAvanzamento=dtFormsAvanzamento.Rows[0]["FormsAvanzamento_Descrizione"].ToString();            
              }else{
                  strAvanzamento="Non compilato";            
              }
            %>
              <tr>
                <td><div class="width250"><%=dtForms.Rows[i]["Forms_Titolo"].ToString()%></div></td>
                <td><div class="width250"><i class="fa-duotone fa-calendar fa-fw"></i><%=dtForms.Rows[i]["Forms_Data"].ToString()%></div></td>
                <td class="text-left"><%=strAvanzamento%></td>
                <td class="text-left">
                  <% 
                    if (dtForms.Rows[i]["Forms_Disattiva"].Equals(false)){
                      if (dtFormsAvanzamento==null || dtFormsAvanzamento.Rows.Count<1){
                            Response.Write("<a href=\"/area-clienti/app/forms/sondaggio.aspx?Forms_Ky=" + dtForms.Rows[i]["Forms_Ky"].ToString() + "\">Completa il modulo<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></a>");
                      }else{
                        //Response.Write(dtFormsAvanzamento.Rows[0]["FormsAvanzamento_Stato"].ToString());
                        if (dtFormsAvanzamento.Rows[0]["FormsAvanzamento_Stato"].ToString()!="3" || dtFormsAvanzamento.Rows[0]["FormsAvanzamento_Stato"].ToString()==""){
                            Response.Write("<a href=\"/area-clienti/app/forms/sondaggio.aspx?Forms_Ky=" + dtForms.Rows[i]["Forms_Ky"].ToString() + "\">Completa il modulo<i class=\"fa-duotone fa-arrow-right fa-fw\"></i></a>");
                        }
                      } 
                    }
                  %>
                </td>
              </tr>
            <% }%>
            </tbody>
            </table>
        </div>
    </div>
    <% }else{
      Response.Write("<span class=\"messaggio\">Nessun Sondaggio</span>");
    } %>
  <br>
<% } %>
