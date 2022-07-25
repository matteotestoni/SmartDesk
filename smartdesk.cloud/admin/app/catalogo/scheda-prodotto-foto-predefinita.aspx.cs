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
    public string strFoto="";
    

    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";

      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());          if (dtLogin.Rows.Count>0){
                strProdotti_Ky=Smartdesk.Current.Request("Prodotti_Ky");
                strFoto=Smartdesk.Current.Request("foto");
                SqlDataAdapter da = new SqlDataAdapter();
                DataTable dt = new DataTable("getTable");
                SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
                SqlCommand cm = new SqlCommand();
                
                cm.CommandTimeout = 300;
                cm.Connection = cn;
                cm.CommandType = CommandType.Text;
                cn.Open();
  							strSQL = "UPDATE Prodotti set Prodotti_Foto11=Prodotti_Foto1,Prodotti_Foto11s=Prodotti_Foto1s WHERE Prodotti_Ky=" + strProdotti_Ky;
                cm.CommandText = strSQL;
                cm.ExecuteNonQuery();
							  strSQL = "UPDATE Prodotti set Prodotti_Foto1=Prodotti_Foto" + strFoto + ",Prodotti_Foto1s=Prodotti_Foto" + strFoto + "s WHERE Prodotti_Ky=" + strProdotti_Ky;
                cm.CommandText = strSQL;
                cm.ExecuteNonQuery();
							  strSQL = "UPDATE Prodotti set Prodotti_Foto" + strFoto + "=Prodotti_Foto11,Prodotti_Foto" + strFoto + "s=Prodotti_Foto11s WHERE Prodotti_Ky=" + strProdotti_Ky;
                cm.CommandText = strSQL;
                cm.ExecuteNonQuery();
                cn.Close();
                Response.Redirect("/admin/app/catalogo/scheda-prodotto.aspx?Prodotti_Ky=" + strProdotti_Ky + "#tabs-4");
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

     
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
