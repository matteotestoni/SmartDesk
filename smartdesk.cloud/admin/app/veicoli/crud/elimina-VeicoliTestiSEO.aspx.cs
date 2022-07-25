using System;
using System.Data;


  public partial class _Default : System.Web.UI.Page 
	{

    public string strLogin="";
    public DataTable dtLogin;    
    public bool boolAdmin = false;
    
    protected void Page_Load(object sender, EventArgs e)
    {
      string strRedirect = Smartdesk.Current.LoginPageRoot;
      string strSorgente = Smartdesk.Current.Request("sorgente");
      string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
      string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
      string strVeicoliTestiSEO_Ky = Smartdesk.Current.Request("VeicoliTestiSEO_Ky");

      if (Smartdesk.Login.Verify){
            if (strDeletemultiplo=="deletemultiplo"){
								string[] strIdsArray = strIds.Split(',');
                Smartdesk.Functions.SqlDeleteKeyIn("VeicoliTestiSEO",strIds);
            }else{
								Smartdesk.Functions.SqlDeleteKey("VeicoliTestiSEO");
            }
						switch (strSorgente)
            {
                default:
                    strRedirect = "/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=214&CoreGrids_Ky=223";
                    break;
            }
	        	Response.Redirect(strRedirect);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
