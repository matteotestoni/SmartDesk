using System;
using System.Web;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e){
      HttpCookie aCookie;
      string cookieName;
      int limit = Request.Cookies.Count;
      for (int i=0; i<limit; i++){
          cookieName = Request.Cookies[i].Name;
          if (cookieName=="rswcrm-cliente"){
	          aCookie = new HttpCookie(cookieName);
	          aCookie.Expires = DateTime.Now.AddDays(-1);
	          Response.Cookies.Add(aCookie);
	      }
      }
      Response.Redirect("/area-clienti");
    }
 }
