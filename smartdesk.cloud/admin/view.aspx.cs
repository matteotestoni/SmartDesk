using System;
using System.Data;
using System.Globalization;
public partial class _Default : System.Web.UI.Page 
{
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    public bool boolCambioGrid = false;
    public DataTable dtCurrentCoreGrids;
    public DataTable dtCoreForms;
    public DataTable dtCoreGrids;
    public DataTable dtCoreGridsButtons;
    public DataTable dtCoreGridsColumns;
    public DataTable dtCoreEntities;
    public DataTable dtCoreModules;
    public DataTable dtGridData;
    public DataTable dtGridDataChildren;
    public int intCoreForms_Ky = 1;
    public int intCoreGrids_Ky = 1;
    public int intCoreEntities_Ky = 1;
    public int intCoreModules_Ky = 28;
    public string strH1 = "";
    public int intRecxPag = 30;
    public int intPage = 0;
    public int intNumPagine=1;
    public string strPathWhere = "";
    public string strFieldValue = "";
    public string strViewUrl = "";
    public string strFormUrl = "";
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public bool boolDebug=false;
    public bool boolWhere=false;
    public string strRenderer = "";
    public string strQuali = "";
    public string strUtentiGruppi_Ky = "";
    public string strDeleteAction = "";
    public string strCaret = "";

    protected void Page_Load(object sender, EventArgs e)
    {
    string strPage="";
    boolDebug = Convert.ToBoolean(Request["debug"]);
    if (Smartdesk.Login.Verify){
      dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
      boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
      boolCambioGrid = (dtLogin.Rows[0]["Utenti_CambioGrid"]).Equals(true);
      strUtentiGruppi_Ky=dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
		  intCoreGrids_Ky = Convert.ToInt32(Request["CoreGrids_Ky"]);
		  strWHERENet="(CoreGrids_Ky=" + intCoreGrids_Ky + ")";
		  strFROMNet = "CoreGrids_Vw";
		  strORDERNet = "CoreGrids_Ky";
		  dtCurrentCoreGrids = new DataTable("CurrentCoreGrids");
		  dtCurrentCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGrids_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      intCoreEntities_Ky=Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreEntities_Ky"].ToString());
      intCoreModules_Ky=Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreModules_Ky"].ToString());
      if (dtCurrentCoreGrids.Rows[0]["CoreForms_Ky"].ToString().Length>0){
        intCoreForms_Ky=Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreForms_Ky"].ToString());
      }

    	strWHERENet="(CoreModules_Ky=" + intCoreModules_Ky + ")";
    	strFROMNet = "CoreModules";
    	strORDERNet = "CoreModules_Ky";
    	dtCoreModules = new DataTable("CoreModules");
    	dtCoreModules = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreModules_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    	strWHERENet="(CoreEntities_Ky=" + intCoreEntities_Ky + ")";
    	strFROMNet = "CoreEntities";
    	strORDERNet = "CoreEntities_Ky";
    	dtCoreEntities = new DataTable("CoreEntities");
    	dtCoreEntities = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreEntities_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      if (Convert.ToBoolean(dtCoreEntities.Rows[0]["CoreEntities_CustomDelete"])){
        strDeleteAction="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/crud/elimina-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx";
      }else{
        strDeleteAction="/admin/crud/elimina.aspx";
      }

      strWHERENet ="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
    	strFROMNet = "UsergroupsGrids_Vw";
    	strORDERNet = "CoreGrids_Ky";
    	dtCoreGrids = new DataTable("CoreGrids");
    	dtCoreGrids = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsGrids_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
    
    	if (intCoreGrids_Ky==0){
    		intCoreGrids_Ky=Convert.ToInt32(dtCoreGrids.Rows[0]["CoreGrids_Ky"]);
    	}

      if (intCoreForms_Ky!=1 && intCoreForms_Ky!=0){
          strWHERENet="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreForms_Ky=" + intCoreForms_Ky + ")";
      }else{
          strWHERENet="(UtentiGruppi_Ky=" + strUtentiGruppi_Ky + ") AND (CoreEntities_Ky=" + intCoreEntities_Ky + ")";
      }
      //Response.Write(strWHERENet);
  		strFROMNet = "UsergroupsForms_Vw";
  		strORDERNet = "CoreForms_Default DESC, CoreForms_Ky DESC";
  		dtCoreForms = new DataTable("CoreGrids");
  		dtCoreForms = Smartdesk.Sql.getTablePage(strFROMNet, null, "UsergroupsForms_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
  		if (dtCoreForms.Rows.Count>0){
          intCoreForms_Ky=Convert.ToInt32(dtCoreForms.Rows[0]["CoreForms_Ky"]);
          if (dtCoreForms.Rows[0]["CoreForms_Custom"].Equals(true)){
            strFormUrl="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreForms.Rows[0]["CoreForms_Code"].ToString() + ".aspx?custom=1&CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky + "&CoreForms_Ky=" + intCoreForms_Ky;
          }else{
            strFormUrl="/admin/form.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky + "&CoreForms_Ky=" + intCoreForms_Ky + "&custom=0";
          }
      }else{
        strFormUrl="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky;
      }

      strH1=dtCoreModules.Rows[0]["CoreModules_Title"].ToString() + " > " + dtCurrentCoreGrids.Rows[0]["CoreGrids_Title"].ToString();
      if (dtCurrentCoreGrids.Rows.Count>0){
        intRecxPag = Convert.ToInt32(dtCurrentCoreGrids.Rows[0]["CoreGrids_Rows"].ToString());

        strWHERENet = "(CoreGrids_Ky=" + intCoreGrids_Ky + ")";
        strFROMNet = "CoreGridsButtons";
        strORDERNet = "CoreGridsButtons_Ky";
        dtCoreGridsButtons = new DataTable("CoreGridsButtons");
        dtCoreGridsButtons = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsButtons_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        if (dtCurrentCoreGrids.Rows[0]["CoreGrids_Custom"].Equals(true)){
          strViewUrl="/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreGrids_Ky=" + intCoreGrids_Ky;
        }else{
          strViewUrl="/admin/view.aspx?CoreModules_Ky=" + intCoreModules_Ky + "&CoreEntities_Ky=" + intCoreEntities_Ky + "&CoreGrids_Ky=" + intCoreGrids_Ky + "&custom=0";
        }
      }

				strWHERENet="(CoreGrids_Ky=" + intCoreGrids_Ky + ")";
				strFROMNet = "CoreGridsColumns_Vw";
				strORDERNet = "CoreGridsColumns_Order ASC";
				dtCoreGridsColumns = new DataTable("CoreGridsColumns");
				dtCoreGridsColumns = Smartdesk.Sql.getTablePage(strFROMNet, null, "CoreGridsColumns_Ky", strWHERENet, strORDERNet, 1,2000,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

				strPage = Request["page"];
        if ((strPage == null) || (strPage == "")){
          intPage = 1;
        }
        else{
          intPage = Convert.ToInt32(strPage);
        }
        strWHERENet=Smartdesk.Grid.getWhere(Request.QueryString);
        if ((strWHERENet==null || strWHERENet.Length<1) && (dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLWhere"].ToString().Length>0)){
					strWHERENet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLWhere"].ToString();
          strWHERENet = strWHERENet.Replace("[USER]",dtLogin.Rows[0]["Utenti_Ky"].ToString());
			    if (boolDebug){
           Response.Write("filtro:" + strWHERENet + "<br>");
          }

				}
        
        if (dtCurrentCoreGrids.Rows[0]["CoreEntities_Tree"].Equals(true)){
          if ((strWHERENet==null || strWHERENet.Length<1)){
  					strWHERENet = dtCurrentCoreGrids.Rows[0]["CoreEntities_TreeAttribute"].ToString() + " Is Null OR " + dtCurrentCoreGrids.Rows[0]["CoreEntities_TreeAttribute"].ToString() + "=0";
  				}else{
  					strWHERENet = strWHERENet + " AND (" + dtCurrentCoreGrids.Rows[0]["CoreEntities_TreeAttribute"].ToString() + " Is Null OR " + dtCurrentCoreGrids.Rows[0]["CoreEntities_TreeAttribute"].ToString() + "=0)";
          }
        }
      
      if (dtCoreEntities.Rows[0]["CoreEntities_Config"].Equals(false)) {      
        //permessi limitati
        strQuali ="UtentiGruppi_" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "Quali";
        if (dtLogin.Columns.Contains(strQuali)) { 
          //Response.Write(Convert.ToInt32(dtLogin.Rows[0][strQuali].ToString()));
          if (dtLogin.Rows[0][strQuali]!=null && dtLogin.Rows[0][strQuali].ToString().Length > 0) { 
            switch (Convert.ToInt32(dtLogin.Rows[0][strQuali].ToString())){
              case 2:
                  if ((strWHERENet==null || strWHERENet.Length<1)){
      					    strWHERENet = "UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
      				    }else{
      					    strWHERENet = strWHERENet + " AND (UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
                  }
                break;
              case 3:
                  if ((strWHERENet==null || strWHERENet.Length<1)){
      					    strWHERENet = "Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString();
      				    }else{
      					    strWHERENet = strWHERENet + " AND (Utenti_Ky=" + dtLogin.Rows[0]["Utenti_Ky"].ToString() + ")";
                  }
                break;
            }
          }
        }
      }



        strORDERNet =Request["orderby"];
        if ((strORDERNet==null || strORDERNet.Length<1) && (dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLOrder"].ToString().Length>0)){
					strORDERNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLOrder"].ToString();
				}
				strFROMNet = dtCurrentCoreGrids.Rows[0]["CoreGrids_SQLFrom"].ToString();
				
				dtGridData = new DataTable("GridData");
				dtGridData = Smartdesk.Sql.getTablePage(strFROMNet, null, dtCoreEntities.Rows[0]["CoreEntities_Key"].ToString(), strWHERENet, strORDERNet, intPage,intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
				this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtGridData,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            

				strPathWhere=Server.MapPath("/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/where/where-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + "-" + intCoreGrids_Ky + ".inc");
        if (System.IO.File.Exists(strPathWhere)){
          boolWhere=true;
        }else{
  				strPathWhere=Server.MapPath("/admin/app/" + dtCoreModules.Rows[0]["CoreModules_Code"].ToString() + "/where/where-" + dtCoreEntities.Rows[0]["CoreEntities_Code"].ToString() + ".inc");
          if (System.IO.File.Exists(strPathWhere)){
            boolWhere=true;
          }else{
            boolWhere=false;
          }
        }

        dtGridDataChildren = new DataTable("dtGridDataChildren");
			  if (boolDebug){
          Response.Write("FROMNet:" + strFROMNet + "<br>");
          Response.Write("WHERE:" + strWHERENet + "<br>");
          Response.Write("ORDER:" + strORDERNet + "<br>");
          Response.Write("Records:" + dtGridData.Rows.Count + "<br>");
        }
            
            }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }  
    }  
    
  public string render(string strRenderer, DataTable drDati, int intRow){
    string strReturn="";
    string strColumn="";
    string strField="";
    string strData="";
    strReturn=strRenderer;
    foreach(DataColumn dataColumn in drDati.Columns)
    {
      strColumn="[" + dataColumn.ColumnName  + "]";
      strField=dataColumn.ColumnName;
      strData=drDati.Rows[intRow][strField].ToString();
      strReturn=strReturn.Replace(strColumn,strData);
      //strReturn+=strColumn + "-" + strField + "-" + strData + "|";
    }
    return strReturn;
  }  

  public string getLabel(DataRow drDati){
    string strReturn="";
    if (drDati["CoreGridsColumns_Label"].ToString().Length>0){
       strReturn=drDati["CoreGridsColumns_Label"].ToString();
    }else{
      strReturn=drDati["CoreAttributes_Title"].ToString();
    }
    return strReturn;
  }  
  
  public decimal convertiDecimale(string strValore){
    decimal dclOut;
	    if (strValore!=null & strValore.Length>0){
	    	dclOut=Convert.ToDecimal(strValore);
	    }else{
				dclOut=0;
			}
			return dclOut;
		}
    
}
