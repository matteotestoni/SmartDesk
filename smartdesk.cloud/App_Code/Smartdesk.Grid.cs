using System;
using System.Data;
using System.Collections.Specialized;

namespace Smartdesk{

	public class Grid{
		
		public static string getWhere(NameValueCollection coll){
	  	string strWHEREGrid="";
			foreach (String key in coll.AllKeys){
			  if (key!="page" && key!="cerca" && key!="sorgente" && key!="azione" && key!="debug" && key!="salvato" && key!="custom" && key != "CoreModules_Ky" && key != "CoreEntities_Ky" && key != "CoreGrids_Ky" && key != "CoreForms_Ky" && coll[key]!="" && coll[key]!="custom" && coll[key]!="debug"){
				    if (strWHEREGrid.Length>0 || strWHEREGrid!=""){
					    strWHEREGrid+=" AND ";					
				    } 
            if (key.Contains("_Ky"))
            {
                strWHEREGrid += key + "=" + coll[key];
            }
            else
            {
                if (coll[key]=="True"){
                  strWHEREGrid += key + "=1";
                }else{
                  strWHEREGrid += key + " like '%" + coll[key] + "%'";
                }
                
            }
          }
        }
    		return strWHEREGrid;
		}

		public static string getPagination(DataTable dtDati, string strNomePagina, int intRecordsPerPagina, int intNumeroRecords, int intPaginaCorrente, NameValueCollection coll){
	  	string strHTML="";
	  	string strParametri="";
	  	int intNumeroPagine=1;
		
			intNumeroPagine = intNumeroRecords / intRecordsPerPagina;
			if ((intNumeroRecords > 0) && (intNumeroRecords > intRecordsPerPagina)){
		      if ((intNumeroRecords % intRecordsPerPagina) >0){
		          intNumeroPagine += 1;
		      }
		      if (intNumeroPagine == 0){
		        intNumeroPagine = 1;
		      }
					foreach (String key in coll.AllKeys){
					  if (key!="page" && key!="cerca" && key!="cercatop" && key!="custom"){
							if (strParametri.Length>0){
                                strParametri+="&" + key + "=" + coll[key];
                            }else{
                                strParametri=key + "=" + coll[key];
                                
                            }
						}
					}
					
                    if (intPaginaCorrente>1){
                      strHTML = "<div class=\"float-left align-middle\">";
    				          strHTML += "<div class=\"tiny button-group\">";
                	    if (intNumeroPagine>2 && intPaginaCorrente>2){
                        strHTML += "<a href=\"" + strNomePagina + "?page=1&" + strParametri + "\" rel=\"nofollow\" class=\"button tiny clear\" title=\"Vai a pagina 1\" data-tooltip><i class=\"fa-duotone fa-angles-left fa-fw\"></i></a>";
                      }
                      strHTML += "<a href=\"" + strNomePagina + "?page=" + (intPaginaCorrente-1) + "&" + strParametri + "\" rel=\"nofollow\" class=\"button tiny clear\" title=\"Vai a pagina " + (intPaginaCorrente-1).ToString() + "\" data-tooltip><i class=\"fa-duotone fa-angle-left fa-fw\"></i></a>";
                      strHTML += "</div>";
                      strHTML += "</div>";
		            }
                
                	if (intNumeroPagine>1){
    					strHTML += "<div class=\"float-left align-middle\">";
    					strHTML += "<input class=\"pagination-input-text\" id=\"current-page-selector\" type=\"text\" name=\"paged\" value=\"" + intPaginaCorrente + "\" size=\"1\" maxlength=\"2\">";
    					strHTML += "</div>";
                    }
  					strHTML += "<div class=\"float-left align-middle\"><span class=\"pagination-label\">&nbsp;di&nbsp;" + intNumeroPagine + " pagine</span></div>";
				
                	if (intNumeroPagine>1){
    					strHTML += "<div class=\"float-left align-middle\">";
    					strHTML += "<div class=\"tiny button-group\">";
                	    if (intNumeroPagine!=intPaginaCorrente){
        				   strHTML += "<a href=\"" + strNomePagina + "?page=" + (intPaginaCorrente+1) + "&" + strParametri + "\" rel=\"nofollow\" class=\"button tiny clear\" title=\"Vai a pagina " + (intPaginaCorrente+1) + "\" data-tooltip><i class=\"fa-duotone fa-angle-right fa-fw\"></i></a>";
                	       if (intNumeroPagine>2){
    					     strHTML += "<a href=\"" + strNomePagina + "?page=" + intNumeroPagine.ToString() + "&" + strParametri + "\" rel=\"nofollow\" class=\"button tiny clear\" title=\"Vai a pagina " + intNumeroPagine.ToString() + "\" data-tooltip><i class=\"fa-duotone fa-angles-right fa-fw\"></i></a>";
                           }
                        }
    					strHTML += "</div>";
    					strHTML += "</div>";
                    }
					strHTML += "<div class=\"float-left align-middle\"><span class=\"pagination-label\"> - " + intRecordsPerPagina + " di " + intNumeroRecords + " elementi</span></div>";
			}else{
					strHTML += "<div class=\"pagination_left\">1 pagina</div>";	
			}
    	return strHTML;
		}
    
	}  
}
