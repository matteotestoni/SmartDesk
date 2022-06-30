using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strKy="";
    public int intKy = 0;
    public long longKy = 0;
    public string strCoreForms_Ky="";
    public string strCoreEntities_Ky="";
    public string strCoreModules_Ky="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

	    
      if (Smartdesk.Login.Verify){
            strCoreForms_Ky=Smartdesk.Current.Request("CoreForms_Ky");
            strCoreEntities_Ky = Smartdesk.Current.Request("CoreEntities_Ky");
            strCoreModules_Ky=Smartdesk.Current.Request("CoreModules_Ky");
            strSorgente=Smartdesk.Current.Request("sorgente");
            strSQL= "INSERT INTO CoreForms (CoreEntities_Ky, CoreForms_Custom, CoreForms_Default, CoreForms_Title, CoreForms_Order, CoreForms_SQLFrom, CoreForms_WhichFields,CoreForms_UserInsert,CoreForms_DateInsert)";
			      strSQL+= "SELECT CoreEntities_Ky, CoreForms_Custom, 0, 'Copy of ' + CoreForms_Title, CoreForms_Order, CoreForms_SQLFrom, CoreForms_WhichFields,0,GETDATE() FROM CoreForms WHERE CoreForms_Ky = " + strCoreForms_Ky;
            longKy = new Smartdesk.Sql().SQLScriptExecuteNonQueryKy(strSQL, "CoreForms", "CoreForms_Ky");

            strSQL = "INSERT INTO CoreFormsFieldset (CoreForms_Ky,CoreFormsFieldset_Title,CoreFormsFieldset_Order,CoreFormsFieldset_UserInsert,CoreFormsFieldset_DateInsert)";
            strSQL += " SELECT " + longKy.ToString() + ",CoreFormsFieldset_Title,CoreFormsFieldset_Order,0,GETDATE() FROM CoreFormsFieldset WHERE CoreForms_Ky = " + strCoreForms_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL = "INSERT INTO CoreFormsFields (CoreForms_Ky,CoreAttributes_Ky,CoreFormsTabs_Ky,CoreFormsFieldset_Ky,CoreFormsFields_Columns,CoreFormsFields_Order,CoreFormsFields_Label,CoreFormsFields_Hidden,CoreFormsFields_Readonly,CoreFormsFields_UserInsert,CoreFormsFields_DateInsert)";
            strSQL += " SELECT " + longKy.ToString() + ",CoreAttributes_Ky,CoreFormsTabs_Ky,CoreFormsFieldset_Ky,CoreFormsFields_Columns,CoreFormsFields_Order,CoreFormsFields_Label,CoreFormsFields_Hidden,CoreFormsFields_Readonly,0,GETDATE() FROM CoreFormsFields WHERE CoreForms_Ky = " + strCoreForms_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL = "INSERT INTO CoreFormsTabs (CoreForms_Ky,CoreFormsTabs_Title,CoreFormsTabs_Icon,CoreFormsTabs_Order,CoreFormsTabs_UserInsert,CoreFormsTabs_DateInsert)";
            strSQL += " SELECT " + longKy.ToString() + ",CoreFormsTabs_Title,CoreFormsTabs_Icon,CoreFormsTabs_Order,0,GETDATE() FROM CoreFormsTabs WHERE CoreForms_Ky = " + strCoreForms_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL = "INSERT INTO CoreFormsButtons (CoreForms_Ky,CoreFormsButtons_Title,CoreFormsButtons_Icon,CoreFormsButtons_Order,CoreFormsButtons_Action,CoreFormsButtons_UserInsert,CoreFormsButtons_DateInsert)";
            strSQL += " SELECT " + longKy.ToString() + ",CoreFormsButtons_Title,CoreFormsButtons_Icon,CoreFormsButtons_Order,CoreFormsButtons_Action,0,GETDATE() FROM CoreFormsButtons WHERE CoreForms_Ky = " + strCoreForms_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL = "INSERT INTO CoreFormsRelations (CoreForms_Ky,CoreGrids_Ky,CoreFormsRelations_Order,CoreFormsRelations_UserInsert,CoreFormsRelations_DateInsert)";
            strSQL += " SELECT " + longKy.ToString() + ",CoreGrids_Ky,CoreFormsRelations_Order,0,GETDATE() FROM CoreFormsRelations WHERE CoreForms_Ky = " + strCoreForms_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            strSQL = "INSERT INTO UsergroupsForms (CoreForms_Ky,UtentiGruppi_Ky,UsergroupsForms_UserInsert,UsergroupsForms_DateInsert)";
            strSQL += " SELECT " + longKy.ToString() + ",UtentiGruppi_Ky,0,GETDATE() FROM UsergroupsForms WHERE CoreForms_Ky = " + strCoreForms_Ky;
            intKy = new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

            Response.Write(intKy.ToString());
            switch (strSorgente){
                  case "scheda-CoreForms":
                    Response.Redirect("/admin/app/sdk/scheda-CoreForms.aspx?CoreForms_Ky=166&CoreModules_Ky=" + strCoreModules_Ky);
                    break;
                  case "scheda-coreentities":
                    Response.Redirect("/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky);
                    break;
		          default:
                    Response.Redirect("/admin/app/sdk/scheda-coreentities.aspx?CoreModules_Ky=" + strCoreModules_Ky + "&CoreEntities_Ky=" + strCoreEntities_Ky);
		            break;
                }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
