using System;
using System.Collections.Generic;
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
          Dictionary<string, object> frm = new Dictionary<string, object>();
      	  if (Smartdesk.Current.Request("CMSGallerie_PubblicaWeb") == "") frm.Add("CMSGallerie_PubblicaWeb", false);
          strKy = Smartdesk.Functions.SqlWriteKey("CMSGallerie", frm);
          strRedirect = "/admin/view.aspx?CoreModules_Ky=9&CoreEntities_Ky=101&CoreGrids_Ky=84";
          Response.Redirect(strRedirect);
        }
        Response.Redirect(strRedirect);
    }
}
