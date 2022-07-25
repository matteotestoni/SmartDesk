<hr>
<div id="attributi">
<h2>Dati tecnici</h2>
<%
if (dtAttributi!=null && dtAttributi.Rows.Count>0){
    for (int j = 0; j < dtAttributi.Rows.Count; j++){ %>
			<div class="grid-x grid-padding-x">
        <div class="large-2 medium-2 small-4 cell">
					<label class="large-text-right small-text-left middle"><%=dtAttributi.Rows[j]["Attributi_Titolo"].ToString()%>
  		    <%
          if (dtAttributi.Rows[j]["Attributi_Obbligatorio"].Equals(true)){
            Response.Write("*");
          }
          %>
          </label>
				</div>
        <div class="large-10 medium-10 small-8 cell">
				<%
					switch (dtAttributi.Rows[j]["AttributiTipo_Ky"].ToString()){
						case "1":
							Response.Write("<input type=\"text\" name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\" />");
							break;
						case "2":
							Response.Write("<textarea name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" value=\"\">" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "</textarea>");
							break;
						case "3":
							Response.Write("<input type=\"text\" name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" class=\"datepicker txt\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\" />");
							break;
						case "4":
							string strCheck="<input type=\"checkbox\" name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\"";
              if (GetCheckValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString())==true){ 
                strCheck+=" checked=\"checked\"";
              }
              strCheck+=" value=\"on\" />";
              Response.Write(strCheck);
							break;
						case "5":
							Response.Write("<input type=\"number\" name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" class=\"price\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\" />");
							break;
						case "6":
							Response.Write("<select name=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" id=\"" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "\" value=\"" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "\"><option value=\"\"></option>");
							strWHERENet="Attributi_Ky=" + dtAttributi.Rows[j]["Attributi_Ky"].ToString();
	            strORDERNet = "AttributiOpzioni_Ordine";
	            strFROMNet = "AttributiOpzioni";
	            dtAttributiOpzioni = Smartdesk.Sql.getTablePage(strFROMNet, null, "AttributiOpzioni_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  						for (int j2 = 0; j2 < dtAttributiOpzioni.Rows.Count; j2++){
  							Response.Write("<option value=\"" + dtAttributiOpzioni.Rows[j2]["AttributiOpzioni_Opzione"].ToString() + "\">" + dtAttributiOpzioni.Rows[j2]["AttributiOpzioni_Opzione"].ToString() + "</option>");
							}
							Response.Write("</select>\n");
	            Response.Write("<script type=\"text/javascript\">\n");
							Response.Write("selectSet('" + dtAttributi.Rows[j]["Attributi_Codice"].ToString() + "', '" + GetFieldValue(dtAnnunci, dtAttributi.Rows[j]["Attributi_Codice"].ToString()) + "');\n");
	            Response.Write("</script>\n");


							break;
					}
				%>
				</div>
      </div>
    <%
    }
}
%>
</div>