  using System;
  using System.Linq;
  using System.Configuration;
  using System.Globalization;
  using System.Data;
  using System.Data.SqlClient;
  using System.Collections.Specialized;
  using System.Net.Mail;
  using System.ComponentModel;
  using System.Drawing;
  using System.Text;
  using System.Net;
  using System.Net.Mail;
  using System.Collections.Generic;
  using System.Security.Cryptography;

  public partial class _Default : System.Web.UI.Page 
  {
    public string strWHERENet = "";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public DataTable dtAnagrafiche;
    public DataTable dtVeicoliMarca;
    public DataTable dtVeicoliModello;
    public DataTable dtLeadSorgenti;
    public DataTable dtLeadCategorie;
    public DataTable dtLeadStato;
    public DataTable dtLeadTipo;
    public int intNumRecords = 0;
    public int intRecxPag = 1;
    public string strAnagrafiche_Ky = "";
    public string strVeicoliMarca_Ky = "";
    public string strVeicoliModello_Ky = "";
    public string strLeadTipo_Ky = "";
    public string strLeadSedi_Ky = "1";
    public string strLeadCategorie_Ky = "1";
    public string strLeadSorgenti_Ky = "1";
    public string strLeadStato_Ky = "1";
    public string strCampagne_Ky = "";    
    public string strUtm_source="";
    public string strUtm_medium="";
    public string strUtm_campaign="";
    public string strBrand="";
    public string strModel="";
    public string strType_vehicle="";
    public string strContact_type="";
    public string strLink="";
    public string strName="";
    public string strEmail="";
    public string strTel="";
    public string strMessage="";       
    public string strDomain="";       
    public bool boolInvia=true;    
    public string strLead_Titolo="Contatto";     

    protected void Page_Load(object sender, EventArgs e){
        strLink=Request["link"];
        if (strLink!=null && strLink.Length>0){
          Uri myUri = new Uri(strLink);   
          strDomain = myUri.Host;     
          //Response.Write("Dominio:" + strDomain + "<br>");   
          if (strLink.Contains("area-job")){
            boolInvia=false;
          }
        }else{
          strLink=Request.UrlReferrer.ToString();
        }
        
        if (boolInvia==true){
              strUtm_source=Request["utm_source"];
              strUtm_medium=Request["utm_medium"];
              strUtm_campaign=Request["utm_campaign"];
              strBrand=Request["brand"];
              strModel=Request["model"];
              strType_vehicle=Request["type_vehicle"];
              strContact_type=Request["contact_type"];
              strLeadSedi_Ky = "1";
              strName=Request["name"];
              if (strName!=null && strName.Length>0){
                strName.Replace("'","");   
              }      
              strEmail=Request["email"];
              strTel=Request["tel"];
              strMessage=Request["message"]; 
              if (strMessage!=null && strMessage.Length>0){
                strMessage.Replace("'","");   
              }     
              
              //LeadSorgenti - LeadTipo
              strORDERNet = "LeadSorgenti_Ky";
              strFROMNet = "LeadSorgenti";
              strWHERENet = "LeadSorgenti_Titolo = '" + strDomain + "'";
              dtLeadSorgenti = new DataTable("LeadSorgenti");
              dtLeadSorgenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadSorgenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtLeadSorgenti.Rows.Count>0){
                strLeadSorgenti_Ky=dtLeadSorgenti.Rows[0]["LeadSorgenti_Ky"].ToString();
                strLeadTipo_Ky = dtLeadSorgenti.Rows[0]["LeadTipo_Ky"].ToString();
              }else{
                strORDERNet = "LeadSorgenti_Ky";
                strFROMNet = "LeadSorgenti";
                strWHERENet = "LeadSorgenti_Default=1";
                dtLeadSorgenti = new DataTable("LeadSorgenti");
                dtLeadSorgenti = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadSorgenti_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                if (dtLeadSorgenti.Rows.Count>0){
                  strLeadSorgenti_Ky=dtLeadSorgenti.Rows[0]["LeadSorgenti_Ky"].ToString();
                  strLeadTipo_Ky = dtLeadSorgenti.Rows[0]["LeadTipo_Ky"].ToString();
                }else{
                  strLeadSorgenti_Ky="1";
                  strORDERNet = "LeadTipo_Ky";
                  strFROMNet = "LeadTipo";
                  strWHERENet = "LeadTipo_Default=1";
                  dtLeadTipo = new DataTable("LeadTipo");
                  dtLeadTipo = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadTipo_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtLeadTipo.Rows.Count>0){
                    strLeadTipo_Ky= dtLeadTipo.Rows[0]["LeadTipo_Ky"].ToString();
                  }else{
                    strLeadTipo_Ky= "1";
                  }
                }
              }      
              
              //LeadStato
              strORDERNet = "LeadStato_Ky";
              strFROMNet = "LeadStato";
              strWHERENet = "LeadStato_Default=1";
              dtLeadStato = new DataTable("LeadStato");
              dtLeadStato = Smartdesk.Sql.getTablePage(strFROMNet, null, "LeadStato_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtLeadStato.Rows.Count>0){
                strLeadStato_Ky=dtLeadStato.Rows[0]["LeadStato_Ky"].ToString();
              }else{
                strLeadStato_Ky="1";
              }
              /*
              Response.Write("Sorgente:" + strLeadSorgenti_Ky + "<br>"); 
              Response.Write("Tipo:" + strLeadTipo_Ky + "<br>"); 
              Response.Write("Stato:" + strLeadStato_Ky + "<br>"); 
             */ 
              switch(strContact_type){
                  case "Preventivo":
                      strLeadTipo_Ky="5";
                      break;
                  case "Test Drive":
                      strLeadTipo_Ky="3";
                      break;
              }
              
              switch(strType_vehicle){
                  case "Nuovo":
                      strLead_Titolo="Nuovo";
                      strLeadCategorie_Ky="1";
                      break;
                  case "Usato":
                      strLead_Titolo="Usato";
                      strLeadCategorie_Ky="2";
                      break;
                  case "Km0":
                      strLead_Titolo="Km0";
                      strLeadCategorie_Ky="3";
                      break;
              }              

              if (strLink!=null && strLink.Length>0){
                  if (strLink.Contains("officina")){
                    strLead_Titolo="Officina";
                    strLeadCategorie_Ky="5";
                  }
                  if (strLink.Contains("assistenza")){
                    strLead_Titolo="Assistenza";
                    strLeadCategorie_Ky="4";
                  }
                  if (strLink.Contains("promo-questionario-auto")){
                    strLead_Titolo="Questionario";
                    strLeadCategorie_Ky="6";
                  }
                  if (strLink.Contains("spazio-online")){
                    strLead_Titolo="SpazioOnline";
                    strLeadCategorie_Ky="8";
                  }
                  if (strLink.Contains("test-drive")){
                    strLead_Titolo="Test Drive";
                    strLeadCategorie_Ky="9";
                  }
              }
              
              if (strUtm_source!=null && strUtm_source.Length>0){
                  inserisciCampagna();            
              }else{
                  strCampagne_Ky="Null";
              }
              if (strEmail!=null && strEmail.Length>0){
                  inserisciAnagrafica();            
              }else{
                  strAnagrafiche_Ky="Null";
              }
              
              //cerco marca e modello
              strORDERNet = "VeicoliMarca_Ky";
              strFROMNet = "VeicoliMarca";
              strWHERENet = "VeicoliTipo_Ky=1 AND VeicoliMarca_Titolo = '" + strBrand + "'";
              dtVeicoliMarca = new DataTable("VeicoliMarca");
              dtVeicoliMarca = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
              if (dtVeicoliMarca.Rows.Count>0){
                  strVeicoliMarca_Ky=dtVeicoliMarca.Rows[0]["VeicoliMarca_Ky"].ToString();
              }else{
                  strORDERNet = "VeicoliMarcaConversione_Ky";
                  strFROMNet = "VeicoliMarcaConversione";
                  strWHERENet = "VeicoliTipo_Ky=1 AND Marca = '" + strBrand + "'";
                  dtVeicoliMarca = new DataTable("VeicoliMarca");
                  dtVeicoliMarca = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliMarca_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtVeicoliMarca.Rows.Count>0){
                    strVeicoliMarca_Ky=dtVeicoliMarca.Rows[0]["VeicoliMarca_Ky"].ToString();
                  }else{
                    strVeicoliMarca_Ky="";
                  }
              }
              if (strVeicoliMarca_Ky!=null && strVeicoliMarca_Ky.Length>0){
                  //se ho la marca allora cerco anche il modello
                  strORDERNet = "VeicoliModello_Ky";
                  strFROMNet = "VeicoliModello";
                  strWHERENet = "VeicoliTipo_Ky=1 AND VeicoliMarca_Ky=" + strVeicoliMarca_Ky + " AND VeicoliModello_Titolo = '" + strModel + "'";
                  //Response.Write(strWHERENet);
                  dtVeicoliModello = new DataTable("VeicoliModello");
                  dtVeicoliModello = Smartdesk.Sql.getTablePage(strFROMNet, null, "VeicoliModello_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
                  if (dtVeicoliModello.Rows.Count>0){
                      strVeicoliModello_Ky=dtVeicoliModello.Rows[0]["VeicoliModello_Ky"].ToString();
                  }else{
                      strVeicoliModello_Ky="Null";
                  }
              }else{
                  strVeicoliMarca_Ky="Null";
                  strVeicoliModello_Ky="Null";
              }
              
              if (strBrand!=null && strBrand.Length>0){
                strLead_Titolo+=" " + strBrand;
              }
              if (strModel!=null && strModel.Length>0){
                strLead_Titolo+=" " + strModel;
              }
                  
              //ho tutti dati e inserisco il lead
              switch (strLeadCategorie_Ky){
                case "1":
                  inserisciLead();
                  break;
                case "2":
                  inserisciLead();
                  break;
                case "3":
                  inserisciLead();
                  break;
                case "4":
                  inserisciTicket();
                  break;
                case "5":
                  inserisciOfficina();
                  break;
                case "6":
                  inserisciLead();
                  break;
                case "7":
                  inserisciLead();
                  break;
                case "8":
                  inserisciLead();
                  break;
              }
        }
        Response.Write("ok");
    }

    public bool inserisciCampagna(){
    string strSQL;   
    DataTable dtCampagne;

      strORDERNet = "Campagne_Ky";
      strFROMNet = "Campagne";
      strWHERENet = "utm_campaign = '" + strUtm_campaign + "'";
      dtCampagne = new DataTable("Campagne");
      dtCampagne = Smartdesk.Sql.getTablePage(strFROMNet, null, "Campagne_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      if (dtCampagne.Rows.Count<1){
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        cn.Open();
        strSQL="INSERT INTO Campagne (";
           strSQL+="  Campagne_Titolo";
           strSQL+=", CampagneTipo_Ky";
           strSQL+=", Campagne_Link";
           strSQL+=", utm_campaign";
           strSQL+=", utm_source";
           strSQL+=", Campagne_UserInsert";
           strSQL+=", Campagne_DateInsert";
           strSQL+=", Campagne_DataInizio";
           strSQL+=", Campagne_Budget";
           strSQL+=", Campagne_Strategie";
           strSQL+=", Lingue_Ky";
           strSQL+=")";
           strSQL+=" VALUES (";
           strSQL+="'" + strUtm_campaign + "'";
           strSQL+=",1";
           strSQL+=",'" + strLink + "'";
           strSQL+=",'" + strUtm_campaign + "'";
           strSQL+=",'" + strUtm_source + "'";
           strSQL+=",0";
           strSQL+=", GETDATE()";
           strSQL+=", GETDATE()";
           strSQL+=", 200";
           strSQL+=", '1,2,4,5'";
           strSQL+=", 1";
           strSQL+=")";
           //Response.Write(strSQL);
           new SqlCommand(strSQL, cn).ExecuteNonQuery();
           cn.Close();
          strORDERNet = "Campagne_Ky";
          strFROMNet = "Campagne";
          strWHERENet = "utm_campaign = '" + strUtm_campaign + "'";
          dtCampagne = new DataTable("Campagne");
          dtCampagne = Smartdesk.Sql.getTablePage(strFROMNet, null, "Campagne_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strCampagne_Ky=dtCampagne.Rows[0]["Campagne_Ky"].ToString();
      }else{
        strCampagne_Ky=dtCampagne.Rows[0]["Campagne_Ky"].ToString();
      }
      return true;
    }

    public bool inserisciTicket(){
    string strSQL;   
    SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
    cn.Open();
      strSQL="INSERT INTO Ticket (Ticket_Data,TicketStati_Ky,TicketCategorie_Ky,Ticket_Titolo, Anagrafiche_Ky,VeicoliMarca_Ky,VeicoliModello_Ky, utm_source, utm_medium, utm_campaign,Ticket_Link,Utenti_Ky,Ticket_UserInsert,Ticket_DateInsert,Lingue_Ky)";
           strSQL+=" VALUES (";
           strSQL+="GETDATE()";
           strSQL+=",1";
           strSQL+=",1";
           strSQL+=",'Richiesta da web'";
           strSQL+="," + strAnagrafiche_Ky;
           strSQL+="," + strVeicoliMarca_Ky;
           strSQL+="," + strVeicoliModello_Ky;
           strSQL+=",'" + strUtm_source + "'";
           strSQL+=",'" + strUtm_medium + "'";
           strSQL+=",'" + strUtm_campaign + "'";
           strSQL+=",'" + strLink + "'";
           strSQL+=",0";
           strSQL+=",0";
           strSQL+=", GETDATE()";
           strSQL+=", 1";
           strSQL+=")";
           //Response.Write(strSQL);
		   new SqlCommand(strSQL, cn).ExecuteNonQuery();
      cn.Close();
      return true;
    }

    public bool inserisciOfficina(){
    string strSQL;   
    SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
    cn.Open();
      strSQL="INSERT INTO Officina ( Officina_Nominativo, Officina_Vettura, Officina_Email, Officina_Telefono, Anagrafiche_Ky,VeicoliMarca_Ky,VeicoliModello_Ky, utm_source, utm_medium, utm_campaign,Officina_Link,Officina_UserInsert,Officina_DateInsert,Officina_DataAccettazione, OfficinaTipoauto_Ky, Priorita_Ky, OfficinaStati_Ky)";
           strSQL+=" VALUES (";
           strSQL+="'" + strName + "'";
           strSQL+=",'" + strBrand + " " + strModel + "'";
           strSQL+=",'" + strEmail + "'";
           strSQL+=",'" + strTel + "'";
           strSQL+="," + strAnagrafiche_Ky;
           strSQL+="," + strVeicoliMarca_Ky;
           strSQL+="," + strVeicoliModello_Ky;
           strSQL+=",'" + strUtm_source + "'";
           strSQL+=",'" + strUtm_medium + "'";
           strSQL+=",'" + strUtm_campaign + "'";
           strSQL+=",'" + strLink + "'";
           strSQL+=",0";
           strSQL+=", GETDATE()";
           strSQL+=", GETDATE()";
           strSQL+=",2";
           strSQL+=",10";
           strSQL+=",1";
           strSQL+=")";
           //Response.Write(strSQL);
		   new SqlCommand(strSQL, cn).ExecuteNonQuery();
      cn.Close();
      return true;
    }

    public bool inserisciLead(){
    string strSQL;   
    SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
    cn.Open();
      strSQL="INSERT INTO Lead (";
           strSQL+="  Lead_Titolo";
           strSQL+=", LeadTipo_Ky";
           strSQL+=", LeadSedi_Ky";
           strSQL+=", LeadCategorie_Ky";
           strSQL+=", LeadFormulaAcquisto_Ky";
           strSQL+=", Anagrafiche_Ky";
           strSQL+=", Campagne_Ky";
           strSQL+=", VeicoliMarca_Ky";
           strSQL+=", VeicoliModello_Ky";
           strSQL+=", Utenti_Ky";
           strSQL+=", Lead_Data";
           strSQL+=", LeadStato_Ky";
           strSQL+=", LeadSorgenti_Ky";
           strSQL+=", Lead_UserInsert";
           strSQL+=", Lead_DateInsert";
           strSQL+=", utm_source";
           strSQL+=", utm_medium";
           strSQL+=", utm_campaign";
           strSQL+=", Lead_Note";
           strSQL+=", Lead_Link";
           strSQL+=")";
           strSQL+=" VALUES (";
           strSQL+="'" + strLead_Titolo + "'";
           strSQL+="," + strLeadTipo_Ky;
           strSQL+="," + strLeadSedi_Ky;
           strSQL+="," + strLeadCategorie_Ky;
           strSQL+=", 5";
           strSQL+="," + strAnagrafiche_Ky;
           strSQL+="," + strCampagne_Ky;
           strSQL+="," + strVeicoliMarca_Ky;
           strSQL+="," + strVeicoliModello_Ky;
           strSQL+=",0";
           strSQL+=", GETDATE()";
           strSQL+="," + strLeadStato_Ky;
           strSQL+="," + strLeadSorgenti_Ky;
           strSQL+=",0";
           strSQL+=", GETDATE()";
           strSQL+=",'" + strUtm_source + "'";
           strSQL+=",'" + strUtm_medium + "'";
           strSQL+=",'" + strUtm_campaign + "'";
           strSQL+=",'" + strMessage + "'";
           strSQL+=",'" + strLink + "'";
           strSQL+=")";
           //Response.Write(strSQL);
		   new SqlCommand(strSQL, cn).ExecuteNonQuery();
      cn.Close();
      return true;
    }

    public bool inserisciAnagrafica(){
      string strSQL;   
      DataTable dtAnagrafiche;
      
      dtAnagrafiche = new DataTable("Anagrafiche");
      strORDERNet = "Anagrafiche_Ky";
      strFROMNet = "Anagrafiche";
      strWHERENet = "Anagrafiche_EmailContatti = '" + strEmail + "'";
      dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      if (dtAnagrafiche.Rows.Count > 0){
          strAnagrafiche_Ky=dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString();
      }else{
        SqlConnection cn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
        cn.Open();
        strSQL="INSERT INTO Anagrafiche (";
          strSQL+="Anagrafiche_EmailContatti";
          strSQL+=", Anagrafiche_EmailAmministrazione";
          strSQL+=", Anagrafiche_Password";
          strSQL+=", AnagraficheTipo_Ky";
          strSQL+=", AnagraficheTipologia_Ky";
          strSQL+=", Anagrafiche_RagioneSociale";
          strSQL+=", Anagrafiche_Nome";
          strSQL+=", Anagrafiche_Attivo";
          strSQL+=", Province_Ky";
          strSQL+=", Regioni_Ky";
          strSQL+=", Comuni_Ky";
          strSQL+=", Nazioni_Ky";
          strSQL+=", Anagrafiche_Indirizzo";
          strSQL+=", Anagrafiche_Telefono";
          strSQL+=", Anagrafiche_DateUpdate";
          strSQL+=", Anagrafiche_DateInsert";
          strSQL+=", Anagrafiche_Note";
          strSQL+=", Anagrafiche_Origine)";
          strSQL+=" VALUES (";
          strSQL+="'" + strEmail + "'";
          strSQL+=",'" + strEmail + "'";
          strSQL+=",'" + GetRandomAlphanumericString(8) + "'";
          strSQL+=", 3";
          strSQL+=", 1";
          strSQL+=", '" + strName + "'";
          strSQL+=", '" + strName + "'";
          strSQL+=", 1";
          strSQL+=", NULL";
          strSQL+=", NULL";
          strSQL+=", NULL";
          strSQL+=", 105";
          strSQL+=", NULL";
          strSQL+=", '" + strTel + "'";
          strSQL+=", GETDATE()";
          strSQL+=", GETDATE()";
          strSQL+=", '" + strMessage + "'";
          strSQL+=", '" + strUtm_source + "'";
          strSQL+=")";
          //Response.Write(strSQL);
          new SqlCommand(strSQL, cn).ExecuteNonQuery();
          cn.Close();
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          strWHERENet = "Anagrafiche_EmailContatti = '" + strEmail + "'";
          dtAnagrafiche = new DataTable("Anagrafiche");
          dtAnagrafiche = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strAnagrafiche_Ky=dtAnagrafiche.Rows[0]["Anagrafiche_Ky"].ToString();
      }
      return true;
    }
    
	public static string GetRandomAlphanumericString(int length)
	{
	    const string alphanumericCharacters =
	        "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
	        "abcdefghijklmnopqrstuvwxyz" +
	        "0123456789";
	    return GetRandomString(length, alphanumericCharacters);
	}
	
	public static string GetRandomString(int length, IEnumerable<char> characterSet)
	{
	    if (length < 0)
	        throw new ArgumentException("length must not be negative", "length");
	    if (length > int.MaxValue / 8) // 250 million chars ought to be enough for anybody
	        throw new ArgumentException("length is too big", "length");
	    if (characterSet == null)
	        throw new ArgumentNullException("characterSet");
	    var characterArray = characterSet.Distinct().ToArray();
	    if (characterArray.Length == 0)
	        throw new ArgumentException("characterSet must not be empty", "characterSet");
	
	    var bytes = new byte[length * 8];
	    new RNGCryptoServiceProvider().GetBytes(bytes);
	    var result = new char[length];
	    for (int i = 0; i < length; i++)
	    {
	        ulong value = BitConverter.ToUInt64(bytes, i * 8);
	        result[i] = characterArray[value % (uint)characterArray.Length];
	    }
	    return new string(result);
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
            string msg = "<br>Table: " + table + "<br>Tableout:" + tableout + "<br>Where:" + where + "<br>Orderby:" + orderby;
            Exception err = new Exception("csLoadData->getTablePage: " + ex.Message + msg);
            throw err;
        }
        finally
        {
            cn.Close();
        }

        System.Data.IDataParameter[] id;
        id = da.GetFillParameters();
        this.intNumRecords = Convert.ToInt32(id[7].Value.ToString());
        return dt;
    }
    
    public static bool isInteger(string theValue)
    {
        try
        {
            Convert.ToInt32(theValue);
            return true;
        } 
        catch 
        {
            return false;
        }
    } 
  }
