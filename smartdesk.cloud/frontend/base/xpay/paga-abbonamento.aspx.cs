using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    
    public int intNumRecords = 0;
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolLogin = false;
    public bool boolAdmin = false;
    public string strUtentiLogin="";
    public bool boolSSL = false;
    public string strCausale="";
    public string strUri="";
    public string strValue="";
    public string strKey="";

    protected void Page_Load(object sender, EventArgs e)
    {
      string strWHERENet="";
      string strFROMNet = "";
      string strORDERNet = "";
      string strUrlPerPagare = "";

      boolSSL=Request.IsSecureConnection;
	  System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
      
      if (Request.Cookies["rswcrm-az"] != null){
          strUtentiLogin = (FormsAuthentication.Decrypt(Context.Request.Cookies["rswcrm-az"].Value)).UserData;
          strWHERENet = "Anagrafiche_Ky =" + strUtentiLogin;
          strORDERNet = "Anagrafiche_Ky";
          strFROMNet = "Anagrafiche";
          dtLogin = new DataTable("Login");
          dtLogin = Smartdesk.Sql.getTablePage(strFROMNet, null, "Anagrafiche_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            if (dtLogin.Rows.Count>0){
                // Alias e chiave segreta
                string ALIAS = "payment_3500136"; // Sostituire con il valore fornito da CartaSi
                string CHIAVESEGRETA = "62P85xUC3237cJCtXU17TpK3KFIJWNFQKErx3vL5"; // Sostituire con il valore fornito da CartaSi
    
                string requestUrl = "https://ecommerce.cartasi.it/ecomm/ecomm/DispatcherServlet";
                string merchantServerUrl = "https://www.astebusiness.it/";
    
                DateTime data = DateTime.Now;
                string codTrans = "ABBONAMENTO_" + data.ToString("yyyyMMddHHmmss");
                string divisa = "EUR";
                string importo = Request["importo"];
                
                string numContratto = strUtentiLogin;
                string tipoRichiesta = "PP";
    
                // Calcolo MAC
                string mac = HashMac("codTrans=" + codTrans + "divisa=" + divisa + "importo=" + importo + "00" + CHIAVESEGRETA);
    
                var requestParams = new Dictionary<string, string>();
                // Parametri obbligatori
                requestParams["alias"] = ALIAS;
                requestParams["importo"] = importo + "00";
                requestParams["divisa"] = divisa;
                requestParams["codTrans"] = codTrans;
                requestParams["url"] = merchantServerUrl + "xpay/esito.aspx";
                requestParams["url_back"] = merchantServerUrl + "xpay/annullo.aspx";
                requestParams["mac"] = mac;
                requestParams["urlpost"] = merchantServerUrl + "xpay/notifica.aspx";
                requestParams["num_contratto"] = numContratto;
                //requestParams["tipo_servizio"] = "paga_multi";
                requestParams["tipo_richiesta"] = tipoRichiesta;
                requestParams["gruppo"] = "ASTEBUSI";
    
                // Parametri facoltativi
                requestParams["mail"] = dtLogin.Rows[0]["Anagrafiche_EmailContatti"].ToString();
                requestParams["languageId"] = "ITA";
                strCausale="Pagamento-abbonamento-" + importo;
                requestParams["descrizione"] = strCausale;
                requestParams["session_id"] = strUtentiLogin;
                if (dtLogin.Rows[0]["Anagrafiche_CodiceFiscale"].ToString().Length>0){
                    requestParams["OPTION_CF"] = dtLogin.Rows[0]["Anagrafiche_CodiceFiscale"].ToString();
                }
                //requestParams["selectedcard"] = "VISA";
                requestParams["TCONTAB"] = "D";
                requestParams["infoc"] = strCausale;
                requestParams["infob"] = strCausale;
                requestParams["modo_gestione_consegna"] = "completo";
                strUri="?";
                foreach (KeyValuePair<string, string> param in requestParams)
                {
                    strValue=param.Value.Replace(Environment.NewLine,"");
                    strKey=param.Key.Replace(Environment.NewLine,"");
                    strUri+=strKey + "=" + strValue + "&";
                }
                //Response.Write(strUri + "<hr>");
                strUrlPerPagare=requestUrl + strUri;
                Response.Write(strUrlPerPagare + "<hr>");
                Response.Redirect(strUrlPerPagare);
              }else{
                Response.Redirect("/login.aspx");
                strLogin="<a href=\"/account/login.html\"><i class=\"fa fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa fa-user-plus fa-lg fa-fw\"></i>Registrati</a>";
                boolLogin=false;
              }
          }else{
            Response.Redirect("/login.aspx");
            strLogin="<a href=\"/account/login.html\"><i class=\"fa fa-key fa-lg fa-fw\"></i>Accedi</a> | <a href=\"/registrazione.aspx\"><i class=\"fa fa-user-plus fa-lg fa-fw\"></i>Registrati</a>";
            boolLogin=false;
          }
        }

        public string HashMac(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }

        public static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
}


