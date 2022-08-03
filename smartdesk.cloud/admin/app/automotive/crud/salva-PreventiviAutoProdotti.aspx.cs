using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        DataTable dtRecord;
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        bool boolAjax = false;
        string strJson = "";
        if (Smartdesk.Login.Verify)
        {
          boolAjax = Convert.ToBoolean(Request["ajax"]);
          strKy = Smartdesk.Functions.SqlWriteKey("PreventiviAutoProdotti");
          if (boolAjax==true){
            
            dtRecord = Smartdesk.Data.Read("PreventiviAutoProdotti", "PreventiviAutoProdotti_Ky", strKy);
            strJson="{\"PreventiviAutoProdotti_Ky\": " + strKy + ",\"PreventiviAutoProdotti_Prezzo\":\"" + dtRecord.Rows[0]["PreventiviAutoProdotti_Prezzo"].ToString() + "\",\"PreventiviAutoProdotti_Descrizione\":\"" + dtRecord.Rows[0]["PreventiviAutoProdotti_Descrizione"].ToString() + "\"}";
            Response.Write(strJson);
          }else{
            strRedirect = "/admin/view.aspx?CoreModules_Ky=35&CoreEntities_Ky=255&CoreGrids_Ky=280";
            Response.Redirect(strRedirect);
          }
        }else{
          Response.Redirect(strRedirect);
        }
    }
}
