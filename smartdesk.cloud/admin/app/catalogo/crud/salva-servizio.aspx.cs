using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{

    
    public string strKy = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string strAnagrafiche_Ky="";
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        if (Smartdesk.Login.Verify)
        {
            
            strAnagrafiche_Ky =Smartdesk.Current.Request("Anagrafiche_Ky");
            Dictionary<string, object> frm = new Dictionary<string, object>();
            if (Smartdesk.Current.Request("AnagraficheServizi_Chiuso") == "") frm.Add("AnagraficheServizi_Chiuso", false);
            strKy = Smartdesk.Functions.SqlWriteKey("AnagraficheServizi", frm);
            //aggiornaAttributi();
            strRedirect = "/admin/goto-form.aspx?CoreEntities_Ky=162&salvato=salvato&Anagrafiche_Ky=" + strAnagrafiche_Ky;
	        Response.Redirect(strRedirect);
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
		}
    }

	public bool aggiornaAttributi()
    {
		string strSQL="";
		SqlDataAdapter da = new SqlDataAdapter();
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        cn.Open();
        SqlCommand cmd = new SqlCommand("checkColumnExists", cn);
        cmd.CommandType = System.Data.CommandType.StoredProcedure;
        
        //aggiungo gli attributi se mancano
		foreach (String key in Request.Form)
		{
		    if (key.Substring(0,5)=="attr-"){
	  				cmd.Parameters.Clear();
					cmd.Parameters.Add(new SqlParameter("@table", "AnagraficheServizi"));
					cmd.Parameters.Add(new SqlParameter("@field", key));
	  				cmd.ExecuteNonQuery();
			}
		}

		//salvo gli attributi
		strSQL="";
		foreach (String key in Request.Form)
		{
		    if (key.Substring(0,5)=="attr-"){
      			if (strSQL.Length>0){
				  strSQL+=", [" + key + "]='" + Request.Form[key] + "'";
				}else{
				  strSQL+="[" + key + "]='" + Request.Form[key] + "'";
				}
			}
		}
		strSQL="UPDATE AnagraficheServizi SET " + strSQL + " WHERE AnagraficheServizi_Ky=" + strKy;
        Response.Write(strSQL);
        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);

		//chiudo la connessione
		if (cn != null)
        {
            cn.Close();
        }
		return true;
	}


}
