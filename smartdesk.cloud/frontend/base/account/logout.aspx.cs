using System;
using System.Web;
using System.Web.Security;

public partial class _Default : System.Web.UI.Page 
{
    public string strLogin="";

    protected void Page_Load(object sender, EventArgs e){
      HttpCookie aCookie;
      string cookieName;
      int limit = Request.Cookies.Count;
      for (int i=0; i<limit; i++)
      {
          cookieName = Request.Cookies[i].Name;
          if (cookieName=="rswcrm-az"){
            aCookie = new HttpCookie(cookieName);
            aCookie.Expires = DateTime.Now.AddDays(-1);			    
            FormsAuthentication.SignOut();
            Response.Cookies.Add(aCookie);
          }
      }
      Response.Redirect("/home.aspx");
    }

 }
