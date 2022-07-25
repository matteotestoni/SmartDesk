using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    public bool fCaricato = false;
    public string strAzione = "";
    public string strProdotti_Ky = "";
    public string strCheck = "";
    public string strProdotti_Foto1 = "";
    public string strProdotti_Foto1s = "";
    public string strParametro = "";
    public string strKy = "";
    public string strDispobilita = "";
    public string strCategoria = "";
    public int intNumeroFoto = 0;
    public string strConnNet = "";
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtProdotto;
    public int intNumRecords = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
      strConnNet = Smartdesk.Config.Sql.ConnectionReadOnly;
      strKy=Smartdesk.Current.Request("Prodotti_Ky");
      strAzione=Smartdesk.Current.Request("azione");
      strProdotti_Ky=Smartdesk.Current.Request("Prodotti_Ky");
      if (Request["NumeroFoto"]!=null && Request["NumeroFoto"].ToString()!="" && Request["NumeroFoto"].ToString()!="0"){
        intNumeroFoto=Convert.ToInt32(Request["NumeroFoto"]);
      }else{
        intNumeroFoto=1;
      }
      aggiornaAnnuncio();
      caricafiles();
      Response.Redirect("/area-clienti/scheda-prodotto.aspx?Prodotti_Ky=" + strProdotti_Ky);
    }

    public void caricafiles()
    {
      string strFileName;
      string [ ] myFiles = Request.Files.AllKeys;
      if (myFiles.Length>0){
            for ( int i = 0; i < myFiles.Length; i++ ) {
              if (Request.Files[i].FileName !=""){
                strFileName=Server.MapPath("../uploads/foto-prodotti/" + strProdotti_Ky + "-" + intNumeroFoto + ".jpg");
                Request.Files.Get(i).SaveAs(strFileName);
                strProdotti_Foto1="/uploads/foto-prodotti/" + strProdotti_Ky + "-" + intNumeroFoto + ".jpg";
                strProdotti_Foto1s="/uploads/foto-prodotti/" + strProdotti_Ky + "-" + intNumeroFoto + ".jpg";
                aggiornaFoto(intNumeroFoto);
              }      
            }
      }
    }


    public bool aggiornaFoto(int intNumeroFotoPar)
    {
        string strSQL="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        SqlCommand cm = new SqlCommand();
        strSQL = "UPDATE Prodotti SET ";
        strSQL+= " Prodotti_Foto" + intNumeroFotoPar + "s='" + strProdotti_Foto1s + "',";
        strSQL+= " Prodotti_Foto" + intNumeroFotoPar + "='" + strProdotti_Foto1 + "'";
        strSQL+= " WHERE Prodotti_Ky = " + strProdotti_Ky;
        Response.Write(strSQL);
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
        return output;
    }

    public char Chr(int n) {
      return (char) n;
    }
    
    public string dta2EN(string strData){
    string strReturn=strData;
      if(strReturn!=null && strReturn.Length==10){
      	strReturn=strReturn.Substring(3, 2) + "/" + strReturn.Substring(0, 2) + "/" + strReturn.Substring(6, 4);
      } 
      return strReturn;
    }
    
    public string sistemaCaratteri(string sT){
    string Tx=sT;
      if(Tx.Length>0){
      	Tx=Tx.Replace(Chr(224).ToString(),"&agrave;");
        Tx=Tx.Replace(Chr(225).ToString(),"&aacute;");
      	Tx=Tx.Replace(Chr(232).ToString(),"&egrave;");
      	Tx=Tx.Replace(Chr(233).ToString(),"&eacute;");
      	Tx=Tx.Replace(Chr(242).ToString(),"&ograve;");
      	Tx=Tx.Replace(Chr(236).ToString(),"&grave;");
      	Tx=Tx.Replace(Chr(249).ToString(),"&ugrave;");
      	Tx=Tx.Replace(Chr(145).ToString(),"&lsquo;");
      	Tx=Tx.Replace(Chr(146).ToString(),"&rsquo;");
      	Tx=Tx.Replace(Chr(147).ToString(),"&ldquo;");
      	Tx=Tx.Replace(Chr(148).ToString(),"&rdquo;");
      	Tx=Tx.Replace("°","&deg;");
      } 
      return Tx;
    }
    
    public bool aggiornaAnnuncio()
    {
        string strSQL="";
        string strValue="";
        bool output = false;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable("getTable");

        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionReadOnly);
        SqlCommand cm = new SqlCommand();
        csSql sql = new csSql();
        sql.hrRequest = Request;     
        sql.Table = "Prodotti";
        if (strAzione=="new"){
            sql.NumberInsert("Utenti_Ky");
            sql.CheckInsert("Prodotti_PubblicaWEB");
            sql.NumberInsert("Prodotti_Prezzo");
            sql.NumberInsert("Prodotti_PrezzoSpeciale");
            strValue=dta2EN(Request["Prodotti_PrezzoSpecialeDal"]);
            if (strValue!=null && strValue.Length>1){
              sql.StringInsert("Prodotti_PrezzoSpecialeDal", strValue);
            }else{
              sql.NullInsert("Prodotti_PrezzoSpecialeDal");
            }
            strValue=dta2EN(Request["Prodotti_PrezzoSpecialeAl"]);
            if (strValue!=null && strValue.Length>1){
              sql.StringInsert("Prodotti_PrezzoSpecialeAl", strValue);
            }else{
              sql.NullInsert("Prodotti_PrezzoSpecialeAl");
            }
            sql.StringInsert("Prodotti_Codice", Request["Prodotti_Codice"]);
            //sql.StringInsert("Prodotti_CodicePadre", Request["Prodotti_CodicePadre"]);
            sql.StringInsert("Prodotti_Titolo", Request["Prodotti_Titolo"]);
            sql.StringInsert("Prodotti_Sottotitolo", Request["Prodotti_Sottotitolo"]);
            sql.StringInsert("Prodotti_Descrizione", Request["Prodotti_Descrizione"]);
            sql.NumberInsert("ProdottiCategorie_Ky");
            sql.NumberInsert("AnagraficheCategorie_Ky");
            sql.NumberInsert("ProdottiDisponibilita_Ky");
            sql.NumberInsert("AliquoteIVA_Ky");
            sql.NumberInsert("Prodotti_Qta");
            sql.NumberInsert("Anagrafiche_Ky");
            sql.NumberInsert("Produttori_Ky");
            sql.NumberInsert("ProdottiMontaggio_Ky");
            sql.NumberInsert("ProdottiConsegna_Ky");
            sql.NumberInsert("Prodotti_Peso");
            sql.NumberInsert("Nazioni_Ky");
            strSQL = sql.InsertCreate();
        }else{
            sql.NumberUpdate("Utenti_Ky");
            sql.CheckUpdate("Prodotti_PubblicaWEB");
            sql.NumberUpdate("Prodotti_Prezzo");
            sql.NumberUpdate("Prodotti_PrezzoSpeciale");
            strValue=dta2EN(Request["Prodotti_PrezzoSpecialeDal"]);
            if (strValue!=null && strValue.Length>1){
              sql.StringUpdate("Prodotti_PrezzoSpecialeDal", strValue);
            }else{
              sql.NullUpdate("Prodotti_PrezzoSpecialeDal");
            }
            strValue=dta2EN(Request["Prodotti_PrezzoSpecialeAl"]);
            if (strValue!=null && strValue.Length>1){
              sql.StringUpdate("Prodotti_PrezzoSpecialeAl", strValue);
            }else{
              sql.NullUpdate("Prodotti_PrezzoSpecialeAl");
            }
            sql.StringUpdate("Prodotti_Codice", Request["Prodotti_Codice"]);
            //sql.StringUpdate("Prodotti_CodicePadre", Request["Prodotti_CodicePadre"]);
            sql.StringUpdate("Prodotti_Titolo", Request["Prodotti_Titolo"]);
            sql.StringUpdate("Prodotti_Sottotitolo", Request["Prodotti_Sottotitolo"]);
            sql.StringUpdate("Prodotti_Descrizione", Request["Prodotti_Descrizione"]);
            sql.NumberUpdate("ProdottiCategorie_Ky");
            sql.NumberUpdate("AnagraficheCategorie_Ky");
            sql.NumberUpdate("ProdottiDisponibilita_Ky");
            sql.NumberUpdate("AliquoteIVA_Ky");
            sql.NumberUpdate("Prodotti_Qta");
            sql.NumberUpdate("Anagrafiche_Ky");
            sql.NumberUpdate("Produttori_Ky");
            sql.NumberUpdate("ProdottiMontaggio_Ky");
            sql.NumberUpdate("ProdottiConsegna_Ky");
            sql.NumberUpdate("Prodotti_Peso");
            sql.NumberUpdate("Nazioni_Ky");
            strProdotti_Ky=Smartdesk.Current.Request("Prodotti_Ky");
            sql.WhereCreate("Prodotti_Ky", strProdotti_Ky);
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
        strORDERNet = "Prodotti_Ky DESC";
        strFROMNet = "Prodotti";
		if (strAzione=="new"){
          strWHERENet = "Utenti_Ky = " + strKy;
          strWHERENet = "";
          dtProdotto = new DataTable("Prodotti");
          dtProdotto = Smartdesk.Sql.getTablePage(strFROMNet, null, "Prodotti_Ky", strWHERENet, strORDERNet, 1, 1, strConnNet);
          strProdotti_Ky=dtProdotto.Rows[0]["Prodotti_Ky"].ToString();
        }
        return output;
    }

    public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App) //#bp
    {
        DataTable dt = Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App, out this.intNumRecords);
        return dt;
    }

}
