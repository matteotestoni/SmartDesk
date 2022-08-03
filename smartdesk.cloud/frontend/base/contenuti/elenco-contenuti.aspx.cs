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
    public string strH1="Elenco articoli";
    public DataTable dtAnnunci;
    public DataTable dtCMSContenuti;
    public DataTable dtContenuti;
    public int intRecxPag = 30;
    public int intPage = 0;
    public int intNumPagine = 1;
    public string strPaginazione = "";
    public DataTable dtAnnunciCategorie;
    public DataTable dtAnnunciCategorieFiltri;
    public DataTable dtRegioni;
    public DataTable dtAttributi;
    public string strTemp="";
    public string strAnnunciCategorie_Ky="";
    public DataTable dtBannerTop1;
    public DataTable dtBannerTop2;
    public DataTable dtBannerBottom1;
    public DataTable dtBannerBottom2;
    public DataTable dtBannerSidebar1;
    public DataTable dtBannerSidebar2;
    public DataTable dtBannerSidebar3;
    public DataTable dtBannerSidebar4;
    public string strContenuto = "";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
      string strPage = "";
      string strValue="";

        
	    
	  	
        if (Request.Cookies["rswcrm-az"] != null){
            strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
            strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
            strORDERNet = "Anagrafiche_Ky";
            strFROMNet = "Anagrafiche";
            dtLogin = new DataTable("Login");
            dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtLogin.Rows.Count>0){
              boolLogin=true;
              strLogin="<li><a href=\"/account/area-personale.html\" class=\"login\"><i class=\"fa-duotone fa-envelope fa-fw\"></i>Il mio profilo</a></li><li><a href=\"/logoutanagrafiche.aspx\" class=\"login\"><i class=\"fa-duotone fa-user-times fa-fw\"></i>Esci</a></li>";
            }else{
              strLogin="<li><a href=\"/account/login.html\" rel=\"nofollow\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Accedi</span></a><li></li><a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-plus fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Registrati</span></a><li>";
              boolLogin=false;
            }
        }else{
          strLogin="<li><a href=\"/account/login.html\" rel=\"nofollow\"><i class=\"fa-duotone fa-key fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Accedi</span></a><li></li><a href=\"/registrazione.aspx\"><i class=\"fa-duotone fa-user-plus fa-lg fa-fw\"></i><span class=\"hide-for-small-only\">Registrati</span></a><li>";
          boolLogin=false;
        }
  
        strPage = Request["page"];
        if ((strPage == null) || (strPage == ""))
        {
            intPage = 1;
        }
        else
        {
            intPage = Convert.ToInt32(strPage);
        }
      
	  	strWHERENet = "AnnunciCategorie_Padre=0";
      	dtAnnunciCategorie = new DataTable("AnnunciCategorie");
      	dtAnnunciCategorie = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Ordine, AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

        strAnnunciCategorie_Ky=Request["AnnunciCategorie_Ky"];
        if (strAnnunciCategorie_Ky!=null && strAnnunciCategorie_Ky.Length>0){
          if (strAnnunciCategorie_Ky.Substring(strAnnunciCategorie_Ky.Length-1,1)==","){
            strAnnunciCategorie_Ky=strAnnunciCategorie_Ky.Substring(0,strAnnunciCategorie_Ky.Length-1);              
          } 
          strWHERENet = "AnnunciCategorie_Padre IN (" + strAnnunciCategorie_Ky + ")";
      	  dtAnnunciCategorieFiltri = new DataTable("AnnunciCategorieFiltri");
      	  dtAnnunciCategorieFiltri = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }else{
          strWHERENet = "AnnunciCategorie_Padre=0";
      	  dtAnnunciCategorieFiltri = new DataTable("AnnunciCategorieFiltri");
      	  dtAnnunciCategorieFiltri = Smartdesk.Sql.getTablePage("AnnunciCategorie", null, "AnnunciCategorie_Ky", strWHERENet, "AnnunciCategorie_Titolo", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }

        strWHERENet = "Nazioni_Ky=105";
      	dtRegioni = new DataTable("Regioni");
      	dtRegioni = Smartdesk.Sql.getTablePage("Regioni", null, "Regioni_Ky", strWHERENet, "Regioni_Ky", 1, 100,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);

      	strWHERENet = getWhere();
      	dtCMSContenuti = new DataTable("CMSContenuti");
      	dtCMSContenuti = Smartdesk.Sql.getTablePage("CMSContenuti_Vw", null, "CMSContenuti_Ky", strWHERENet, "CMSContenuti_Ky DESC", intPage, intRecxPag,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        dtContenuti=dtCMSContenuti;
  		  this.PaginaSotto.Text = Smartdesk.Grid.getPagination(dtCMSContenuti,System.IO.Path.GetFileName(Request.Url.AbsolutePath), intRecxPag,intNumRecords, intPage,Request.QueryString);						            
        //Response.Write(strWHERENet);
        
        //banner
        strValue = Request["Province_Ky"];
        if (strValue != null && strValue != "" && strValue.Length>0){
			    strWHERENet = "CMSAds_Zone like '%1%' AND CMSAds_Province like '%" + strValue + "%'";
	        strORDERNet = "CMSAds_Ky DESC";
	        strFROMNet = "CMSAds_Vw";
	        dtBannerTop1 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			    strWHERENet = "CMSAds_Zone like '%2%' AND CMSAds_Province like '%" + strValue + "%'";
	        strORDERNet = "CMSAds_Ky DESC";
	        strFROMNet = "CMSAds_Vw";
	        dtBannerTop2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			    strWHERENet = "CMSAds_Zone like '%3%' AND CMSAds_Province like '%" + strValue + "%'";
	        strORDERNet = "CMSAds_Ky DESC";
	        strFROMNet = "CMSAds_Vw";
	        dtBannerBottom1 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			    strWHERENet = "CMSAds_Zone like '%4%' AND CMSAds_Province like '%" + strValue + "%'";
	        strORDERNet = "CMSAds_Ky DESC";
	        strFROMNet = "CMSAds_Vw";
	        dtBannerBottom2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			    strWHERENet = "CMSAds_Zone like '%5%' AND CMSAds_Province like '%" + strValue + "%'";
	        strORDERNet = "CMSAds_Ky DESC";
	        strFROMNet = "CMSAds_Vw";
	        dtBannerSidebar1 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
			    strWHERENet = "CMSAds_Zone like '%6%' AND CMSAds_Province like '%" + strValue + "%'";
	        strORDERNet = "CMSAds_Ky DESC";
	        strFROMNet = "CMSAds_Vw";
	        dtBannerSidebar2 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%8%' AND CMSAds_Province like '%" + strValue + "%'";
          strORDERNet = "CMSAds_Ky DESC";
          strFROMNet = "CMSAds_Vw";
          dtBannerSidebar3 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
          strWHERENet = "CMSAds_PubblicaWeb=1 AND CMSAds_Zone like '%9%' AND CMSAds_Province like '%" + strValue + "%'";
          strORDERNet = "CMSAds_Ky DESC";
          strFROMNet = "CMSAds_Vw";
          dtBannerSidebar4 = Smartdesk.Sql.getTablePage(strFROMNet, null, "CMSAds_Ky", strWHERENet, strORDERNet, 1, 2,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
        }

    }
    
    public string getWhere()
    {
        string strWHERE="";
        string strWHEREPermessi="";
        string strValue="";

        strWHERE="(CMSContenutiTipo_Ky=2)";
        //Response.Write(strWHERE);
        return strWHERE;
    }

    public string getAttributi(int indiceRecord, DataTable dtDati)
    {
        string strOutput="";
        string strAttributi="";
        string strCodice="";
        string strTitolo="";
        string strTipo="";
        string strIcona="";

        strOutput="";   
        strAttributi=dtAnnunci.Rows[indiceRecord]["AnnunciCategorie_AttributiElenchi"].ToString();
        if (strAttributi.Length>0){
          
          DataRow[] drAttributiElenco=dtAttributi.Select("Attributi_Ky IN(" + strAttributi + ")", "Attributi_Ordine");
          for (int x = 0; x < drAttributiElenco.Length; x++){
           strCodice=drAttributiElenco[x]["Attributi_Codice"].ToString();
           strTitolo=drAttributiElenco[x]["Attributi_Titolo"].ToString();
           strTipo=drAttributiElenco[x]["AttributiTipo_Ky"].ToString();
           strIcona=drAttributiElenco[x]["Attributi_Icona"].ToString();
           if (strIcona!=null && strIcona.Length>0){
            strIcona="<i class=\"" + strIcona + " fa-fw\"></i>";
           }
           if (dtAnnunci.Rows[indiceRecord][strCodice].ToString().Length>0 && dtAnnunci.Rows[indiceRecord][strCodice].ToString()!="0"){
              switch (strTipo){
                case "1":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "2":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "3":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-calendar fa-fw\"></i>" + strTitolo + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "4":
                    strOutput+="<span class=\"secondary\"><i class=\"fa-duotone fa-square-check fa-fw\"></i>" + strTitolo + "&nbsp;&nbsp;</span>";
                    break;  
                case "5":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;  
                case "6":
                    strOutput+="<span class=\"secondary\">" + strTitolo + " " + strIcona + ":&nbsp;<strong>" + dtAnnunci.Rows[indiceRecord][strCodice].ToString() + "</strong>&nbsp;&nbsp;</span>";
                    break;                  
              }
           }

          }
        }

        return strOutput;
    }

    public string StripHTML(string str)
    {
        return System.Text.RegularExpressions.Regex.Replace(str, @"<(.|\n)*?>", string.Empty);
    }
}
