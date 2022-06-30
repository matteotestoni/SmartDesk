using System;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    public string strVeicoliMarca_Ky="";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strKy = "";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
    	    Dictionary<string, object> frm = new Dictionary<string, object>();
    	    if (Smartdesk.Current.Request("VeicoliModello_Importante") == "") frm.Add("VeicoliModello_Importante", false);
    	    if (Smartdesk.Current.Request("VeicoliModello_Premium") == "") frm.Add("VeicoliModello_Premium", false);
    	    if (Smartdesk.Current.Request("VeicoliModello_Dismesso") == "") frm.Add("VeicoliModello_Dismesso", false);
     	    if (Smartdesk.Current.Request("VeicoliModello_Km0") == "") frm.Add("VeicoliModello_Km0", false);
     	    if (Smartdesk.Current.Request("VeicoliModello_Usato") == "") frm.Add("VeicoliModello_Usato", false);
          strVeicoliMarca_Ky=Smartdesk.Current.Request("VeicoliMarca_Ky");
          strKy = Smartdesk.Functions.SqlWriteKey("VeicoliModello",frm);
          strRedirect = "/admin/form.aspx?CoreModules_Ky=29&CoreEntities_Ky=122&CoreGrids_Ky=143&CoreForms_Ky=140&salvato=salvato&VeicoliModello_Ky=" + strKy + "&VeicoliMarca_Ky=" + strVeicoliMarca_Ky;
          Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}