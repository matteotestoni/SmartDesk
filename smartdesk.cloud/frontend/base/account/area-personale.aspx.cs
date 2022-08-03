using System;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public string strUtentiLogin="";
    
    
    public int intNumRecords = 0;
    public int i = 0;
    public string strH1="Area personale";
    public DataTable dtAsteCategorie;
    public DataTable dtAnnunciCategorie;
    public DataTable dtAsteEsperimenti;
    public DataTable dtAsteCauzioni;
    public DataTable dtAsteEsperimentiWishlist;
    public DataTable dtAnnunciWishlist;
    public DataTable dtLottiWishlist;
    public DataTable dtAnnunci;
    public DataTable dtAnnunciOfferteLotto;
    public DataTable dtWishlist;
    public string strTemp="";
    public DataTable dtAttributi;
    public DataTable dtAnagraficheServizi;
    public string strInAste="";
    public string strInAnnunci="";
    public string strWHERENet="";
    public string strFROMNet = "";
    public string strORDERNet = "";
    public bool boolCauzione = false;

    protected void Page_Load(object sender, EventArgs e)
    {

	  
	  
      
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche_Vw";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          if (dtLogin.Rows.Count>0){
            boolLogin=true;
            strLogin="<a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>" + dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString() + "</a> | <a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a>";

            strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin + " AND AnagraficheServizi_Inizio<=GETDATE() AND AnagraficheServizi_Termine>=GETDATE()";
            dtAnagraficheServizi = new DataTable("AnagraficheServizi");
            dtAnagraficheServizi = Smartdesk.Sql.getTablePage("AnagraficheServizi_Vw", null, "AnagraficheServizi_Ky", strWHERENet, "AnagraficheServizi_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

          }else{
            boolLogin=false;
			Response.Redirect("/account/login.html");
          }
      }else{
        boolLogin=false;
	    Response.Redirect("/account/login.html");
      }

      strWHERENet = "AnnunciCategorie_Padre=0";
      dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

	    strWHERENet = "";
      dtAsteCategorie = new DataTable("AsteCategorie");
      dtAsteCategorie = Smartdesk.Sql.getTablePage("AsteCategorie", null, "AsteCategorie_Ky", strWHERENet, "AsteCategorie_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

  	  strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin;
      dtAsteCauzioni = new DataTable("AsteCauzioni");
      dtAsteCauzioni = Smartdesk.Sql.getTablePage("AsteCauzioni_Vw", null, "AsteCauzioni_Ky", strWHERENet, "AsteCauzioni_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

  	  strWHERENet = "Anagrafiche_Ky=" + strUtentiLogin;
      dtWishlist = new DataTable("Wishlist");
      dtWishlist = Smartdesk.Sql.getTablePage("Wishlist", null, "Wishlist_Ky", strWHERENet, "Wishlist_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
	    for (int i = 0; i < dtWishlist.Rows.Count; i++){
        if (dtWishlist.Rows[i]["Aste_Ky"].ToString().Length>0 && dtWishlist.Rows[i]["Aste_Ky"].ToString()!="0"){
            if (strInAste.Length>0){
              strInAste+=","+ dtWishlist.Rows[i]["Aste_Ky"].ToString();
            }else{
              strInAste=dtWishlist.Rows[i]["Aste_Ky"].ToString();
            }
        }
        if (dtWishlist.Rows[i]["Annunci_Ky"].ToString().Length>0){
            if (strInAnnunci.Length>0){
              strInAnnunci+=","+ dtWishlist.Rows[i]["Annunci_Ky"].ToString();
            }else{
              strInAnnunci=dtWishlist.Rows[i]["Annunci_Ky"].ToString();
            }
        }
      }
  	  if (strInAnnunci!=null && strInAnnunci.Length>0){
          strWHERENet = "AnnunciTipo_Ky=1 AND Annunci_Ky IN (" + strInAnnunci + ")";
      }else{
          strWHERENet = "AnnunciTipo_Ky=1 AND Annunci_Ky=0";
      }
  	  dtAnnunciWishlist = new DataTable("AnnunciWishlist");
  	  dtAnnunciWishlist = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 20,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
  	  //Response.Write(strInAste);
      if (strInAnnunci!=null && strInAnnunci.Length>0){
          strWHERENet = "AnnunciTipo_Ky=2 AND Annunci_Ky IN (" + strInAnnunci + ")";
      }else{
          strWHERENet = "AnnunciTipo_Ky=2 AND Annunci_Ky=0";
      }
  	  dtLottiWishlist = new DataTable("LottiWishlist");
  	  dtLottiWishlist = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 20,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
      
  	  if (strInAste!=null && strInAste.Length>0){
  	       strWHERENet = "AsteEsperimentiEsiti_Ky=3 AND Aste_Ky IN (" + strInAste + ")";
      }else{
          strWHERENet = "Aste_Ky=0";
      }
      dtAsteEsperimentiWishlist = new DataTable("AsteEsperimentiWishlist");
      dtAsteEsperimentiWishlist = Smartdesk.Sql.getTablePage("AsteEsperimenti_Web_Vw", null, "AsteEsperimenti_Ky", strWHERENet, "AsteEsperimenti_DataTermine", 1, 20,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

  	  strWHERENet = "AnnunciTipo_Ky=1 AND Anagrafiche_Ky=" + strUtentiLogin;
  	  dtAnnunci = new DataTable("Annunci");
  	  dtAnnunci = Smartdesk.Sql.getTablePage("Annunci_Vw", null, "Annunci_Ky", strWHERENet, "Annunci_Ky", 1, 20,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        
      strWHERENet = "Attributi_Annunci=1";
      strORDERNet = "Attributi_Ky";
      strFROMNet = "Attributi_Vw";
      dtAttributi = Smartdesk.Sql.getTablePage(strFROMNet, null, "Attributi_Ky", strWHERENet, strORDERNet, 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

    }    

    public string getAttributiLotti(int indiceRecord)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";

        strOutput="";   
        strAttributi=dtLottiWishlist.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           if (dtLottiWishlist.Rows[indiceRecord][strCodice].ToString().Length>0 && dtLottiWishlist.Rows[indiceRecord][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtLottiWishlist.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "2":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtLottiWishlist.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "3":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtLottiWishlist.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    if (dtLottiWishlist.Rows[indiceRecord][strCodice].Equals(true)){
                        strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-check-square-o fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                    }
                    break;  
                case "5":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtLottiWishlist.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "6":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtLottiWishlist.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;                  
              }
           }

          }
        }
        return strOutput;
    }

    public string getAttributi(int indiceRecord)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";

        strOutput="";   
        strAttributi=dtAnnunci.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           if (dtAnnunci.Rows[indiceRecord][strCodice].ToString().Length>0 && dtAnnunci.Rows[indiceRecord][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "2":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "3":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-check-square-o fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                    break;  
                case "5":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "6":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;                  
              }
           }

          }
        }

        return strOutput;
    }

    public string getAttributiAnnunci(DataTable dtTabella, int indiceRecord)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";

        strOutput="";   
        strAttributi=dtTabella.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           if (dtTabella.Rows[indiceRecord][strCodice].ToString().Length>0 && dtTabella.Rows[indiceRecord][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtTabella.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "2":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtTabella.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "3":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtTabella.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-check-square-o fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                    break;  
                case "5":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtTabella.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "6":
                    strOutput+="<span class=\"secondary\">" + strTitolo + ":&nbsp;<strong>" + dtTabella.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;                  
              }
           }

          }
        }

        return strOutput;
    }
}
