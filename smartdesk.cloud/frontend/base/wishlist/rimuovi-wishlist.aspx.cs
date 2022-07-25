using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    
    public bool boolLogin = false;
    public int intNumRecords = 0;
    public DataTable dtUtenti;
    public DataTable dtLogin;
    public DataTable dtWishlist;
    public string strUtenti_Ky="";
    public string strUtentiLogin="";
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    
    public string strLogin="";
    public string strAste_Ky="";
    public string strAnnunci_Ky="";
    public string strProdotti_Ky="";
    public string strImmobili_Ky="";
    public string strCantieri_Ky="";
    public string strVeicoli_Ky="";
    public string strAzione="";
    public string strCosa="";
   
    protected void Page_Load(object sender, EventArgs e){
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
      string strSQL="";
      string strValue="";
      string strUtenti_Ky="";

  	  
  	  
      
       if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolLogin=true;
            strLogin="<a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa fa-envelope fa-fw\"></i>" + dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "</a> | <a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa fa-user-times fa-fw\"></i>Esci</a>";
            strAste_Ky=Request["Aste_Ky"];
            strAzione=Request["azione"];
            strCosa=Request["cosa"];
            strAste_Ky=Request["Aste_Ky"];
            strAnnunci_Ky=Request["Annunci_Ky"];
            strProdotti_Ky=Request["Prodotti_Ky"];
            strImmobili_Ky=Request["Immobili_Ky"];
            strCantieri_Ky=Request["Cantieri_Ky"];
            strVeicoli_Ky=Request["Veicoli_Ky"];
            switch (strCosa){
                case "aste":
                    strWHERENet = "Aste_Ky =" + strAste_Ky;
                    break;
                case "annunci":
                    strWHERENet = "Annunci_Ky =" + strAnnunci_Ky;
                    break;
                case "prodotti":
                    strWHERENet = "Prodotti_Ky =" + strProdotti_Ky;
                    break;
                case "immobili":
                    strWHERENet = "Immobili_Ky =" + strImmobili_Ky;
                    break;
                case "cantieri":
                    strWHERENet = "Cantieri_Ky =" + strCantieri_Ky;
                    break;
                case "veicoli":
                    strWHERENet = "Veicoli_Ky =" + strVeicoli_Ky;
                    break;
            }
            strFROMNet = "Wishlist";
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable("getTable");
            SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
            SqlCommand cm = new SqlCommand();
            strSQL = "DELETE FROM Wishlist WHERE " + strWHERENet;
            cm.CommandText = strSQL;
            cm.CommandType = CommandType.Text;
            cm.Connection = cn;
            cm.CommandTimeout = 300;
            da.SelectCommand = cm;
            cn.Open();
            cm.ExecuteNonQuery();			
            //Response.Write(strSQL);
            Response.Redirect("/account/area-personale.html");
          
          }else{
            Response.Redirect("/account/login.html");
          }
      }else{
        Response.Redirect("/account/login.html");
      }
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App)
    {
        if (table.Trim() == "" || App.Trim() == "")
        {
            Exception ex = new Exception("csLoadData->getTablePage: Manca Tabella: " + table + " o App: " + App);
            throw ex;
        }
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(App);
        SqlCommand cm = new SqlCommand();
        SqlParameter pm = null;

        cm.CommandTimeout = 0;
        cm.CommandText = "getTablePage";
        cm.CommandType = CommandType.StoredProcedure;
        cm.Connection = cn;

        pm = new SqlParameter("@table", SqlDbType.VarChar, 50);
        pm.Value = table;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@tableout", SqlDbType.VarChar, 50);
        pm.Value = tableout;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@key", SqlDbType.VarChar, 50);
        pm.Value = key;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@whr", SqlDbType.VarChar, 1000);
        pm.Value = where;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@ord", SqlDbType.VarChar, 100);
        pm.Value = orderby;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@pg", SqlDbType.Int);
        pm.Value = pagina;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@pgmax", SqlDbType.Int);
        pm.Value = paginamax;
        cm.Parameters.Add(pm);

        pm = new SqlParameter("@rows", SqlDbType.Int);
        pm.Value = paginamax;
        pm.Direction = System.Data.ParameterDirection.Output;
        cm.Parameters.Add(pm);
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            da.Fill(dt);
        }
        catch (SqlException ex)
        {
            string msg = "<br />Table: " + table + "<br />Tableout:" + tableout + "<br />Where:" + where + "<br />Orderby:" + orderby;
            Exception err = new Exception("csLoadData->getTablePage: " + ex.Message + msg);
            throw err;
        }
        finally
        {
            dt.Dispose();
            cm.Dispose();
            cn.Close();
        }
        System.Data.IDataParameter[] id;
        id = da.GetFillParameters();
        this.intNumRecords = Convert.ToInt32(id[7].Value.ToString());
        return dt;
    }
}
