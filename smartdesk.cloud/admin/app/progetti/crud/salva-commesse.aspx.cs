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
  		  	if (Smartdesk.Current.Request("Commesse_DataConsegna") == "") frm.Add("Commesse_DataConsegna", null);
  		  	if (Smartdesk.Current.Request("Commesse_DataChiusura") == "") frm.Add("Commesse_DataChiusura", null);
          strKy = Smartdesk.Functions.SqlWriteKey("Commesse", frm);
          aggiornaOre(strKy);
          strRedirect = "/admin/app/progetti/scheda-commesse.aspx?salvato=salvato&Commesse_Ky=" + strKy;
  	    	Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
    		}
    }
        
    public bool aggiornaOre(string strCommesse_Ky)
    {
        string strSQL = "gg";
        bool output = false;

        if (strCommesse_Ky != null && strCommesse_Ky.Length > 0)
        {
            strSQL = "UPDATE Commesse SET";
            strSQL += " Commesse_OreImpiegate=Commesse_Totali_Vw.TotaleOreImpiegate, Commesse_OreResidue=Commesse_Totali_Vw.Commesse_OrePreviste-Commesse_Totali_Vw.TotaleOreImpiegate";
            strSQL += " FROM Commesse INNER JOIN Commesse_Totali_Vw ON Commesse.Commesse_Ky=Commesse_Totali_Vw.Commesse_Ky";
            strSQL += " WHERE Commesse.Commesse_Ky=" + strCommesse_Ky;
            //Response.Write(strSQL);
            new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
        }
        output=true;
        return output;
    }
    
}