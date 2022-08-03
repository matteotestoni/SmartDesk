using System;
using System.Data;

  public partial class _Default : System.Web.UI.Page {
    
    public int intNumRecords = 0;
    public int i = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public string strAste_Ky="";
    public string strAsteNatura_Ky="";
    public string strSorgente="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
		string strSQL="";
	  
		if (Smartdesk.Login.Verify){
      		
			strAste_Ky=Smartdesk.Current.Request("Aste_Ky");
			strAsteNatura_Ky =Request["AsteNatura_Ky"];
			strSorgente=Smartdesk.Current.Request("sorgente");

			strSQL = "INSERT INTO AsteCommissioni  (Aste_Ky, AsteCommissioni_Da, AsteCommissioni_A, AsteCommissioni_Commissione) ";  
			strSQL += "SELECT " + strAste_Ky + ", AsteCommissioniDefault_Da, AsteCommissioniDefault_A, AsteCommissioniDefault_Commissione "; 
			strSQL += "FROM AsteCommissioniDefault ";  
			strSQL += "WHERE (AsteNatura_Ky=" + strAsteNatura_Ky + ")";
			//Response.Write(strSQL);
			new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

			switch (strSorgente){
			    case "scheda-aste":
			    	Response.Redirect("/admin/app/aste/scheda-aste.aspx?Aste_Ky=" + strAste_Ky);
			    	break;
			    default:
			    	Response.Redirect("/admin/app/aste/scheda-aste.aspx?Aste_Ky=" + strAste_Ky);
			    	break;
			}
		}else{
		    Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }
}
