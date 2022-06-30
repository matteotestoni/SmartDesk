<%@ Page codepage="65001" Language="C#" AutoEventWireup="true" CodeFile="/admin/settings.aspx.cs" Inherits="_Default" Debug="true"%>
<!DOCTYPE html>
<html class="no-js" lang="it">
<head>
	<title>Core > Impostazioni</title>
	<!--#include file="/admin/inc-head.aspx"-->
</head>
<body>
<!--#include file=/admin/inc-mainbar.aspx --> 
<div data-sticky-container>
  <div class="content-header" data-sticky="content-header" data-margin-top="0" data-margin-bottom="1" style="width:100%">
      <div class="grid-x grid-padding-x align-middle">
          <div class="large-5 medium-5 small-12 cell align-middle">
            	<h1><i class="fa-duotone fa-gears fa-lg fa-fw"></i><%=strH1%></h1>
          </div>
          <div class="large-7 medium-7 small-12 cell float-right align-middle">
  	      </div>
      </div>
  </div>
</div>

<div class="divimpostazioni">
  <div class="grid-container fluid">
    <div class="grid-x grid-padding-x">
      <div class="large-2 medium-2 small-12 cell sidebar-left hide-for-small-only"><!--#include file=/admin/impostazioni-sidebar.aspx --></div>
      <div class="large-10 medium-10 small-12 cell">

        <div class="grid-container fluid">
        <div class="divgrid ">
        <div class="grid-x grid-padding-x">
          <div class="large-12 medium-12 small-12 cell">

            <table class="grid hover scroll" border="0" width="100%">
            	<thead>
        	      <tr>
        	        <th width="40">id</th>
        	        <th width="80">CoreModulesOptionsCode</th>
        	        <th width="250">Title</th>
        	        <th width="30">Icon</th>
        	        <th width="450">Value</th>
        	      </tr>
            	</thead>
            	<tbody>
        		    <%for (int i = 0; i < dtCoreModulesOptionsValue.Rows.Count; i++){ %>
        	        <tr class="riga<%=i%2%>">
        	          <td><%=dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString()%></td>
        	          <td><%=dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptions_Code"].ToString()%></td>
        	          <td><a href="/admin/form.aspx?CoreModules_Ky=26&CoreEntities_Ky=230&CoreGrids_Ky=242&CoreForms_Ky=164&custom=0&azione=edit&CoreModulesOptionsValue_Ky=<%=dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString()%>"><%=dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptions_Title"].ToString()%></a></td>
        	          <td><i class="<%=dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptions_Icon"].ToString()%> fa-fw"></i></td>
        	          <td>
                    <%
                      switch (dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptions_Type"].ToString()){
                        case "boolean":
                          if (Convert.ToBoolean(dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Value"]).Equals(true)){
                            strChecked=" checked";
                          }else{
                            strChecked=" ";
                          }
                          Response.Write("<input type=\"checkbox\" id=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" name=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" onchange=\"saveBooleanOption(" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + ")\"" + strChecked + ">");
                          break;
                        case "checkbox":
                          if (Convert.ToBoolean(dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Value"]).Equals(true)){
                            strChecked=" checked";
                          }else{
                            strChecked=" ";
                          }
                          Response.Write("<input type=\"checkbox\" id=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" name=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" onchange=\"saveBooleanOption(" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + ")\"" + strChecked + ">");
                          break;
                        case "text":
                          Response.Write("<input type=\"text\" id=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" name=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" style=\"resize: none;\" onchange=\"saveOption(" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + ")\" value=\"" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Value"].ToString() + "\">");
                          break;
                        case "email":
                          Response.Write("<input type=\"email\" id=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" name=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" style=\"resize: none;\" onchange=\"saveOption(" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + ")\" value=\"" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Value"].ToString() + "\">");
                          break;
                        case "textarea":
                          Response.Write("<textarea rows=\"3\" id=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" name=\"option" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + "\" onchange=\"saveOption(" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Ky"].ToString() + ")\">" + dtCoreModulesOptionsValue.Rows[i]["CoreModulesOptionsValue_Value"].ToString() + "</textarea>");
                          break;
                      }
                    
                    %>
                    </td>
        	        </tr>
        		    <% } %>
            	</tbody>
            </table>
            <div class="paginazione">
            		<asp:Label ID="PaginaSotto" runat="server" class="paginazione"></asp:Label>
        				<span class="pagination_info">
        				&nbsp;&nbsp;<%=intNumRecords%> elementi
        				</span>
            </div>
          </div>
         </div>
        </div>
        </div>
    </div>
  </div>
<!--#include file=/admin/inc-footer.aspx -->
<script>
  function saveOption(intCoreModulesOptionsValue_Ky){
  	$url="/admin/app/sdk/crud/salva-coremodulesoptionsvalue.aspx";
  	$field="#option" + intCoreModulesOptionsValue_Ky + "";
  	$value=jQuery($field).val();
  	$data= { azione: 'modifica', sorgente: 'ajax', ajax:true, CoreModulesOptionsValue_Ky: intCoreModulesOptionsValue_Ky, CoreModulesOptionsValue_Value: $value };
  	jQuery.ajax({
  		type: "POST",
  		url: $url,
  		data: $data
  	})
  	.done(function( data ) {
      	jQuery($field).css('border-color', "green");
  		//alert( "salvato");
    	});	
  
  }
  
  function saveBooleanOption(intCoreModulesOptionsValue_Ky){
  	$url="/admin/app/sdk/crud/salva-coremodulesoptionsvalue.aspx";
  	$field="#option" + intCoreModulesOptionsValue_Ky + "";
  	if (jQuery($field).prop("checked") == true){
      $value="true";
    }else{
      $value="false";
    }
    console.log($value);
  	$data= { azione: 'modifica', sorgente: 'ajax', ajax:true, CoreModulesOptionsValue_Ky: intCoreModulesOptionsValue_Ky, CoreModulesOptionsValue_Value: $value };
  	jQuery.ajax({
  		type: "POST",
  		url: $url,
  		data: $data
  	})
  	.done(function( data ) {
      	jQuery($field).css('border-color', "green");
  		//alert( "salvato");
    	});	
  
  }
</script>
</body>
</html>
