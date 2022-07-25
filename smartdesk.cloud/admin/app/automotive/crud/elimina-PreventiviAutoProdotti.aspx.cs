using System;

public partial class _Default : System.Web.UI.Page
{
    
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e){
        string strPreventiviAutoProdotti_Ky = "0";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        bool boolAjax = false;
        string strJson = "";
        if (Smartdesk.Login.Verify){
            boolAjax = Convert.ToBoolean(Request["ajax"]);
            if (strDeletemultiplo=="deletemultiplo"){
                strPreventiviAutoProdotti_Ky=strIds;
                Smartdesk.Functions.SqlDeleteKeyIn("PreventiviAutoProdotti",strIds);
            }else{
                strPreventiviAutoProdotti_Ky=Request["PreventiviAutoProdotti_Ky"];
                Smartdesk.Functions.SqlDeleteKey("PreventiviAutoProdotti");
                //Response.Write("ok");
            }
            if (boolAjax==true){
              strJson="{\"PreventiviAutoProdotti_Ky\": " + strPreventiviAutoProdotti_Ky + "}";
              Response.Write(strJson);
            }else{
              strRedirect = "/admin/view.aspx?CoreModules_Ky=35&CoreEntities_Ky=255&CoreGrids_Ky=280";
              Response.Redirect(strRedirect);
            }
        }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
    }
}
