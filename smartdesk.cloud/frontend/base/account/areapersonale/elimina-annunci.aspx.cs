using System;
public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = "/area-personale.aspx";

        Smartdesk.Functions.SqlDeleteKey("Annunci");
        strRedirect="/area-personale.aspx";
    	Response.Redirect(strRedirect);

    }
}
                      