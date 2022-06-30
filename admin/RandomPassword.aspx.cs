using System;
using System.Data;

public partial class RandomPassword : System.Web.UI.Page
{
    public string strPassword1 = "";
    public string strPassword2 = "";
    public string strPassword3 = "";
    public string strPassword4 = "";
    public string strPassword5 = "";
    public string strPassword6 = "";
    public string strPassword7 = "";
    public string strPassword8 = "";
    public string strPassword9 = "";
    public string strPassword10 = "";
    public string strPassword11 = "";
    public string strPassword12 = "";
    public string allowedChars = "";
    public char[] sep = { ',' };
    public string[] arr;
    
    public int intNumRecords = 0;
    public string strLogin="";
    public DataTable dtLogin;
    public bool boolAdmin = false;
    
    public string strH1 = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        
      strH1="Generatore di password";
      if (Smartdesk.Login.Verify){
          dtLogin = Smartdesk.Data.Read("Utenti_Vw","Utenti_Ky", Smartdesk.Session.CurrentUser.ToString());
			      if (dtLogin.Rows.Count>0){
			        
			        boolAdmin=(dtLogin.Rows[0]["Utenti_Admin"]).Equals(true);
						}
			
			      allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
			      allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
			      allowedChars += "1,2,3,4,5,6,7,8,9,0";
			      //allowedChars += "@,!,#,$,&,%,?,^,£,[";
			      arr = allowedChars.Split(sep);
			
			      DateTime centuryBegin = new DateTime(2001, 1, 1);
			      long lngElapsedTicks = DateTime.Now.Ticks - centuryBegin.Ticks;
			      //Response.Write(lngElapsedTicks);
			      strPassword1=getNewPassword(lngElapsedTicks+100) + "#";
			      strPassword2=getNewPassword(lngElapsedTicks+200) + "@";
			      strPassword3=getNewPassword(lngElapsedTicks+300) + "!";
			      strPassword4=getNewPassword(lngElapsedTicks+400) + "$";
			      strPassword5=getNewPassword(lngElapsedTicks+500) + "&";
			      strPassword6=getNewPassword(lngElapsedTicks+600) + "@";
			      strPassword7=getNewPassword(lngElapsedTicks+700) + "?";
			      strPassword8=getNewPassword(lngElapsedTicks+800) + "^";
			      strPassword9=getNewPassword(lngElapsedTicks+900) + "£";
			      strPassword10=getNewPassword(lngElapsedTicks+1000) + "[";
			      strPassword11=getNewPassword(lngElapsedTicks+1100) + "-";
			      strPassword12=getNewPassword(lngElapsedTicks+1200) + "_";
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}    
    public string getNewPassword(long lngNumero){
        string passwordString = "";
        string temp = "";
        Random rand = new Random(unchecked((int)lngNumero));
        for (int i = 0; i < 12 ; i++)
        {
            temp = arr[rand.Next(0, arr.Length)];
            passwordString += temp;
        }
        return passwordString;
    }
    
}
