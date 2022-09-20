using System;
using System.Data;
using System.Data.SqlClient;


  public partial class _Default : System.Web.UI.Page 
	{
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    
    public bool boolAdmin = false;
    
    public string strProdotti_Ky="";
    public string strSorgente="";
    public string strCampo="";
    public string strValore="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      string strUPDATE = "";

      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          
          strProdotti_Ky=Smartdesk.Current.Request("Prodotti_Ky");
          strSorgente=Smartdesk.Current.Request("sorgente");
          strCampo=Request["campo"];
          strValore=Request["valore"];
          switch (strCampo){
						case "Offerta":
							strUPDATE="Prodotti_InOfferta=" + strValore;
							break;
						case "Promozione":
							strUPDATE="Prodotti_InPromozione=" + strValore;
							break;
						case "Vetrina":
							strUPDATE="Prodotti_InVetrina=" + strValore;
							break;
						case "Outlet":
							strUPDATE="Prodotti_Outlet=" + strValore;
							break;
					}
                    
          strSQL = "UPDATE Prodotti SET " + strUPDATE + " WHERE Prodotti_Ky=" + strProdotti_Ky;
          //Response.Write(strSQL);
          new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
					switch (strSorgente){
            case "home":
              Response.Redirect("/admin/home.aspx");
              break;
            case "elenco-prodotti":
              Response.Redirect("/admin/app/catalogo/elenco-prodotti.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&");
              break;
            case "scheda-prodotto":
              Response.Redirect("/admin/app/catalogo/scheda-prodotto.aspx?CoreModules_Ky=8&CoreEntities_Ky=83&CoreGrids_Ky=66&Prodotti_Ky=" + strProdotti_Ky);
              break;
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
}
