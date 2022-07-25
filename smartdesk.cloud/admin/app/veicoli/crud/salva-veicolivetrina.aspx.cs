using System;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;


  public partial class _Default : System.Web.UI.Page 
	{

    public bool fCaricato = false;
    public string strAzione = "";
    public string strVeicoliVetrina_Ky = "";
    public string strCheck = "";
    public string strKy = "";
    public string strDispobilita = "";
    public string strCategoria = "";
    public int intNumeroFoto = 0;

    
    
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtVeicoli;
    public DataTable dtVeicoliVetrina;
    public int intNumRecords = 0;
    public DataTable dtLogin;
    
    public string strVeicoli_Riferimento="";
    public string strVeicoli_Ky="";
    public string strSorgente="";

    protected void Page_Load(object sender, EventArgs e)
    {
      
      
	  
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());        if (dtLogin.Rows.Count>0){
	      strKy=Smartdesk.Current.Request("ky");
	      strAzione = Request["azione"];
	      strVeicoliVetrina_Ky=Smartdesk.Current.Request("VeicoliVetrina_Ky");
          strSorgente=Smartdesk.Current.Request("sorgente");
          strVeicoli_Riferimento=Request["Veicoli_Riferimento"];
		  strWHERENet="Veicoli_Riferimento='" + strVeicoli_Riferimento + "' And UtentiGruppi_Ky=" + dtLogin.Rows[0]["UtentiGruppi_Ky"].ToString();
          strFROMNet = "Veicoli";
          strORDERNet = "Veicoli_Ky";
          dtVeicoli = new DataTable("Veicoli");
          dtVeicoli = Smartdesk.Sql.getTablePage(strFROMNet, null, "Veicoli_Ky", strWHERENet, strORDERNet, 1,1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtVeicoli.Rows.Count>0){
          	strVeicoli_Ky=dtVeicoli.Rows[0]["Veicoli_Ky"].ToString();
		  }else{
          	strVeicoli_Ky="0";
		  }
	      aggiornaAnnuncio();
	      aggiornaCodice();
	      aggiornaPremium();
		  switch (strSorgente){
		  	case "elenco-veicolivetrina":
		  		Response.Redirect("/admin/view.aspx?CoreModules_Ky=29&CoreEntities_Ky=252&CoreGrids_Ky=275&salvato=salvato&VeicoliVetrina_Ky=" + strVeicoliVetrina_Ky);
		  		break;
		  	case "sheda-veicolivetrina":
		  		Response.Redirect("/admin/app/veicoli/scheda-VeicoliVetrina.aspx?CoreModules_Ky=29&CoreEntities_Ky=252&CoreGrids_Ky=275&salvato=salvato&VeicoliVetrina_Ky=" + strVeicoliVetrina_Ky);
		  		break;
		  	default:
		  		Response.Redirect("/admin/app/veicoli/scheda-VeicoliVetrina.aspx?CoreModules_Ky=29&CoreEntities_Ky=252&CoreGrids_Ky=275&salvato=salvato&VeicoliVetrina_Ky=" + strVeicoliVetrina_Ky);
		  		break;
		  }
        }else{
          Response.Redirect(Smartdesk.Current.LoginPageRoot);
        }
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public bool aggiornaCodice(){
      string strSQL="";
      
	  SqlDataAdapter da = new SqlDataAdapter();
      DataTable dt = new DataTable("getTable");
      SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
      SqlCommand cm = new SqlCommand();
      
      strSQL = "UPDATE VeicoliVetrina set VeicoliVetrina.Veicoli_Ky=Veicoli.Veicoli_Ky";
	  strSQL += " FROM VeicoliVetrina INNER JOIN Veicoli ON dbo.VeicoliVetrina.Veicoli_Riferimento = dbo.Veicoli.Veicoli_Riferimento";
	  strSQL += " WHERE VeicoliVetrina.UtentiGruppi_Ky=11";
      //Response.Write(strSQL);
      cm.CommandText = strSQL;
      cm.CommandType = CommandType.Text;
      cm.Connection = cn;
      cm.CommandTimeout = 300;
      da.SelectCommand = cm;
      cn.Open();
      cm.ExecuteNonQuery();	
	  return true;		
	}

    public bool aggiornaPremium(){
      string strSQL="";
      
	  SqlDataAdapter da = new SqlDataAdapter();
      DataTable dt = new DataTable("getTable");
      SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
      SqlCommand cm = new SqlCommand();
      
      strSQL = "UPDATE Veicoli SET Veicoli.Veicoli_Premium=1"; 
	  strSQL += " FROM Veicoli INNER JOIN VeicoliVetrina ON Veicoli.Veicoli_Ky = VeicoliVetrina.Veicoli_Ky";
	  strSQL += " WHERE VeicoliVetrina_Titolo='premium' AND VeicoliVetrina.UtentiGruppi_Ky=11";
      //Response.Write(strSQL);
      cm.CommandText = strSQL;
      cm.CommandType = CommandType.Text;
      cm.Connection = cn;
      cm.CommandTimeout = 300;
      da.SelectCommand = cm;
      cn.Open();
      cm.ExecuteNonQuery();	
	  return true;		
	}

    public bool aggiornaAnnuncio()
    {
        string strSQL="";
        string strValue="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        SqlCommand cm = new SqlCommand();
        
        csSql sql = new csSql();
        sql.hrRequest = Request;     
        sql.Table = "VeicoliVetrina";
        if (strAzione=="new"){
            strValue=Request["VeicoliVetrina_Titolo"];
            if (strValue!=null && strValue.Length>1){
              sql.StringInsert("VeicoliVetrina_Titolo", strValue);
            }else{
              sql.NullInsert("VeicoliVetrina_Titolo");
            }
            strValue=Request["Veicoli_Riferimento"];
            if (strValue!=null && strValue.Length>1){
              sql.StringInsert("Veicoli_Riferimento", strValue);
            }else{
              sql.NullInsert("Veicoli_Riferimento");
            }
            sql.NumberInsert("Utenti_Ky");
            sql.NumberInsert("UtentiGruppi_Ky");
            sql.NumberInsert("Veicoli_Ky");
            strSQL = sql.InsertCreate();
        }else{
            strValue=Request["VeicoliVetrina_Titolo"];
            if (strValue!=null && strValue.Length>1){
              sql.StringUpdate("VeicoliVetrina_Titolo", strValue);
            }else{
              sql.NullUpdate("VeicoliVetrina_Titolo");
            }
            strValue=Request["Veicoli_Riferimento"];
            if (strValue!=null && strValue.Length>1){
              sql.StringUpdate("Veicoli_Riferimento", strValue);
            }else{
              sql.NullUpdate("Veicoli_Riferimento");
            }
            sql.NumberUpdate("Utenti_Ky");
            sql.NumberUpdate("UtentiGruppi_Ky");
            sql.NumberUpdate("Veicoli_Ky");
            strVeicoliVetrina_Ky=Smartdesk.Current.Request("VeicoliVetrina_Ky");
            sql.WhereCreate("VeicoliVetrina_Ky", strVeicoliVetrina_Ky);
            strSQL = sql.UpdateCreate();
        }
        //Response.Write(strSQL);
        cm.CommandText = strSQL;
        cm.CommandType = CommandType.Text;
        cm.Connection = cn;

        cm.CommandTimeout = 300;
        da.SelectCommand = cm;
        cn.Open();
        try
        {
            cm.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            Exception err = new Exception("csLoadData->CreateXslInsUpdXls_In: " + ex.Message);
            throw err;
        }
        finally
        {
            cn.Close();
        }
        if (strAzione=="new"){
          strORDERNet = "VeicoliVetrina_Ky DESC";
          strFROMNet = "VeicoliVetrina";
          strWHERENet ="";
          dtVeicoliVetrina = new DataTable("VeicoliVetrina");
          dtVeicoliVetrina = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliVetrina_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strVeicoliVetrina_Ky=dtVeicoliVetrina.Rows[0]["VeicoliVetrina_Ky"].ToString();
        }
        return output;
    }

    
	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
