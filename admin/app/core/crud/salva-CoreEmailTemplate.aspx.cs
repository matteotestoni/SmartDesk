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
        string strSQL = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        bool boolAjax = false;
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
          boolAjax = Convert.ToBoolean(Request["ajax"]);
          strKy = Smartdesk.Functions.SqlWriteKey("CoreEmailTemplate", frm);
          if (boolAjax==true){
            Response.Write("ok");
          }else{
            strRedirect = "/admin/view.aspx?CoreModules_Ky=12&CoreEntities_Ky=256&CoreGrids_Ky=281";
            Response.Redirect(strRedirect);
          }
        }
        Response.Redirect(strRedirect);
    }
}
