<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/app/veicoli/scheda-veicolimarca.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Veicoli > Scheda marca veicoli</title>
	<!--#include file="/admin/inc-head.aspx"-->
  	<script type="text/javascript" src="/admin/app/veicoli/veicoli.js?id=2"></script>
	<% if (boolWysiwyg==true){ %>
	 <script src="//cdn.ckeditor.com/4.19.1/full/ckeditor.js"></script>
	<% } %>
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<h1><i class="fa-duotone fa-car fa-lg fa-fw"></i>Marca veicolo: <span class="badge large secondary"><i class="fa-duotone fa-database fa-fw"></i><%=GetFieldValue(dtVeicoliMarca, "VeicoliMarca_Ky")%></span></h1>
<div class="grid-x grid-padding-x">
  <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
  <div class="large-10 medium-10 small-12 cell">
		<form id="form-veicolimarca" action="/admin/app/veicoli/crud/salva-veicolimarca.aspx" method="post" data-abide novalidate>
      <input type="hidden" name="azione" id="azione" value="<%=strAzione%>">
      <input type="hidden" name="VeicoliMarca_Ky" id="VeicoliMarca_Ky" value="<%=GetFieldValue(dtVeicoliMarca, "VeicoliMarca_Ky")%>">
			<div class="stacked-for-small button-group small hide-for-print align-right">
				<a href="/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=117&CoreGrids_Ky=138" class="button clear"><i class="fa-duotone fa-backward fa-fw"></i>Torna all'elenco</a>
				<a href="/admin/app/veicoli/scheda-veicolimarca.aspx?azione=new" class="button"><i class="fa-duotone fa-square-plus fa-lg fa-fw"></i>Nuovo</a>
      	<button type="submit" value="salva" name="salva" class="button success"><i class="fa-duotone fa-floppy-disk fa-lg fa-fw"></i>Salva</button>
			</div>
      <!--#include file=/admin/forms_messaggi.inc -->
 			<!--#include file=/admin/app/veicoli/forms/veicolimarca_form.htm -->
		</form>


		<% if (strAzione!="new"){ %>
		<br>
		<div class="grid-x grid-padding-x">
		  <div class="small-12 medium-12 large-12 cell">
		    <a name="modelli"></a>
				<div class="card">
				  <div class="card-divider">
							<h2><i class="fa-duotone fa-car fa-lg fa-fw"></i>Modelli (<%=dtVeicoliModello.Rows.Count%>)</h2>
							<div class="button-group tiny">
								<button class="tiny button secondary" data-open="formNuovoModello"><i class="fa-duotone fa-square-plus fa-fw"></i> Nuova modello</button>
					  	</div>
				  </div>
				  <div class="card-section">		
				    <div class="reveal" id="formNuovoModello" data-reveal>
				    <form class="form-azione" id="form-veicolimodello" action="/admin/app/core/salva-veicolimodello.aspx" method="post" data-abide novalidate>
				      <input type="hidden" name="sorgente" id="sorgente" documento="scheda-attributo">
				      <input type="hidden" name="azione" id="azione" value="new">
				      <input type="hidden" name="VeicoliModello_Ky" id="VeicoliModello_Ky" value="">
				      <input type="hidden" name="VeicoliMarca_Ky" id="VeicoliMarca_Ky" value="<%=dtVeicoliMarca.Rows[0]["VeicoliMarca_Ky"].ToString()%>">
							<div data-abide-error class="alert callout" style="display: none;">
								<p><i class="fa-duotone fa-triangle-exclamation-triangle fa-lg fa-fw"></i> Ci sono errori nel tuo modulo: compila tutti i campi richiesti e controlla i formati.</p>
							</div>
				        <h4>Nuovo modello</h4>
								<div class="grid-x grid-padding-x">
				          <div class="large-2 medium-2 small-4 cell">modello:</div>
				          <div class="large-10 medium-10 small-8 cell">
				            <input type="text" name="VeicoliModello_Descrizione" id="VeicoliModello_Descrizione" size="25" required="required">
						        <span class="form-error">Obbligatorio</span>
				          </div>
				        </div>
				        <div class="grid-x grid-padding-x">
				          <div class="large-2 medium-2 small-4 cell">Url Key:</div>
				          <div class="large-10 medium-10 small-8 cell">
				            <input type="text" name="VeicoliModello_UrlKey" id="VeicoliModello_UrlKey" size="12" required="required">
						        <span class="form-error">Obbligatorio</span>
				          </div>
				        </div>
				        <div class="grid-x grid-padding-x">
				          <div class="large-2 medium-2 small-4 cell">Importante:</div>
				          <div class="large-10 medium-10 small-8 cell">
				            <input type="checkbox" name="VeicoliModello_Importante" id="VeicoliModello_Importante" value="on" />
				          </div>
				        </div>
				        <div class="grid-x grid-padding-x">
				          <div class="large-12 medium-12 small-12 cell text-left">
										<button type="submit" value="salva" name="salva" class="small button success"><i class="fa-duotone fa-square-plus fa-fw"></i> Inserisci modello</button>
				          </div>
				        </div>
				    </form>
				    </div>

				    <% if (dtVeicoliModello!=null && dtVeicoliModello.Rows.Count>0){ %>
				      <table class="grid hover scroll" border="0" width="100%">
					    <thead>
				        <tr>
							<th width="10"><input type="checkbox" id="selectall" name="selectall" /></th>
							<th class="text-left" width="50">Codice</th>
							<th class="text-left" width="350">Modello</th>
							<th class="text-left" width="150">UrlKey</th>
							<th class="text-center" width="40">Premium</th>
							<th class="text-center" width="40">Importante</th>
							<th class="text-center" width="40">Km0</th>
							<th class="text-center" width="40">Usato</th>
							<th class="text-center" width="40">Dismesso</th>
							<th class="text-center" width="100">Carrozzeria</th>
							<th class="text-center" width="120">Auto presenti</th>
							<th class="text-center" width="40">Ordine</th>
							<th width="30" class="nowrap"></th>
				        </tr>
					    </thead>
					    <tbody>
				        <%for (int i = 0; i < dtVeicoliModello.Rows.Count; i++){ %>
				            <tr>
				          		<td><input type="checkbox" class="checkrow" id="record<%=dtVeicoliModello.Rows[i]["VeicoliModello_Ky"].ToString()%>" data-value="<%=dtVeicoliModello.Rows[i]["VeicoliModello_Ky"].ToString()%>" /></td>
				             	<td class="text-left"><%=dtVeicoliModello.Rows[i]["VeicoliModello_Ky"].ToString()%></td>
				              	<td class="text-left"><a href="/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=122&CoreForms_Ky=140&VeicoliModello_Ky=<%=dtVeicoliModello.Rows[i]["VeicoliModello_Ky"].ToString()%>"><%=dtVeicoliModello.Rows[i]["VeicoliModello_Titolo"].ToString()%></a></td>
				              	<td class="text-left"><%=dtVeicoliModello.Rows[i]["VeicoliModello_UrlKey"].ToString()%></td>
				              	<td class="large-text-center small-text-left">
        									<% if (dtVeicoliModello.Rows[i]["VeicoliModello_Premium"].Equals(true)){ %>
        										<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
        									<% }else{ %>
        										<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
        									<% } %>
        								</td>
				              	<td class="large-text-center small-text-left">
        									<% if (dtVeicoliModello.Rows[i]["VeicoliModello_Importante"].Equals(true)){ %>
        										<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
        									<% }else{ %>
        										<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
        									<% } %>
        								</td>
				              	<td class="large-text-center small-text-left">
        									<% if (dtVeicoliModello.Rows[i]["VeicoliModello_Km0"].Equals(true)){ %>
        										<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
        									<% }else{ %>
        										<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
        									<% } %>
        								</td>
				              	<td class="large-text-center small-text-left">
        									<% if (dtVeicoliModello.Rows[i]["VeicoliModello_Usato"].Equals(true)){ %>
        										<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
        									<% }else{ %>
        										<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
        									<% } %>
        								</td>
				              	<td class="large-text-center small-text-left">
        									<% if (dtVeicoliModello.Rows[i]["VeicoliModello_Dismesso"].Equals(true)){ %>
        										<i class="fa-duotone fa-check fa-lg fa-fw" style="--fa-primary-color:green;--fa-primary-opacity: 1.0"></i>
        									<% }else{ %>
        										<i class="fa-duotone fa-xmark fa-lg fa-fw" style="--fa-secondary-color:red;--fa-secondary-opacity: 1.0"></i>
        									<% } %>
        								</td>
						          <td class="text-center"><%=dtVeicoliModello.Rows[i]["VeicoliCarrozzeria_Descrizione"].ToString()%></td>
						          <td class="text-center">
									<%	
									strWHERENet="VeicoliModello_Ky=" + dtVeicoliModello.Rows[i]["VeicoliModello_Ky"].ToString();
									strORDERNet = "Veicoli_Ky";
									strFROMNet = "Veicoli";
									dtVeicoli = new System.Data.DataTable("Veicoli");
									dtVeicoli = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1, 10,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
									if (dtVeicoli.Rows.Count>0){
										Response.Write("<i class=\"fa-duotone fa-square-check success fa-fw\"></i>");
									}else{
										Response.Write("<i class=\"fa-duotone fa-square success fa-fw\"></i>");	
									}
									Response.Write(dtVeicoli.Rows.Count);
									%>					  
								  <td>
						          <td class="text-center"><%=dtVeicoliModello.Rows[i]["VeicoliModello_Ordine"].ToString()%></td>
				              <td>
				                <a href="/admin/app/veicoli/crud/elimina-veicolimodello.aspx?azione=delete&VeicoliMarca_Ky=<%=dtVeicoliModello.Rows[i]["VeicoliMarca_Ky"].ToString()%>&VeicoliModello_Ky=<%=dtVeicoliModello.Rows[i]["VeicoliModello_Ky"].ToString()%>&sorgente=scheda-veicolimarca" title="elimina" class="delete" id="delete<%=dtVeicoliModello.Rows[i]["VeicoliModello_Ky"].ToString()%>"><i class="fa-duotone fa-trash-can fa-fw"></i></a>
				              </td>
				            </tr>
				        <% } %>
					    	</tbody>
				      </table>
				    <% }else{
							 Response.Write("<div class=\"grid-x grid-padding-x\"><div class=\"small-12 large-12 medium-12 cell\"><span class=\"messaggio\"><i class=\"fa-duotone fa-circle-info fa-fw\"></i>Nessun dato</span></div></div>");
				    } %>
				</div>    
			</div>

		</div>    
	</div>    
		<% } %>
  </div>
</div>
<!--#include file=/admin/inc-footer.aspx -->
<script>
		ClassicEditor
			.create(document.querySelector('.ckeditor'))
			.catch(error => {
				console.error(error);
			});
</script>
<style>
	.ck-editor__editable_inline {
		min-height: 200px;
	}
</style>
</body>
</html>
