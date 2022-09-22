using System;
using System.Collections.Generic;

  public partial class _Default : System.Web.UI.Page 
	{

    protected void Page_Load(object sender, EventArgs e)
    {
    	string strKy="";
      string strSQL = "";
      bool boolAjax = false;

      if (Smartdesk.Login.Verify){
        if (Smartdesk.Current.Request("ajax").Length>0){
          boolAjax =Convert.ToBoolean(Smartdesk.Current.Request("ajax"));
        }else{
          boolAjax=false;
        }
        //Response.Write(boolAjax);
        //Response.Write(Smartdesk.Current.Request("CoreAttributes_Ky"));
        //Response.Write(Smartdesk.Current.Request("CoreAttributes_Order"));
        Dictionary<string, object> frm = new Dictionary<string, object>();
        if (Smartdesk.Current.Request("CoreAttributes_Search") == "") frm.Add("CoreAttributes_Search", false);
        if (Smartdesk.Current.Request("CoreAttributes_System") == "") frm.Add("CoreAttributes_System", false);
        if (Smartdesk.Current.Request("CoreAttributes_Key") == "") frm.Add("CoreAttributes_Key", false);
        strKy = Smartdesk.Functions.SqlWriteKey("CoreAttributes", frm);
  			if (Smartdesk.Current.Request("CoreAttributes_Key")=="True" || Smartdesk.Current.Request("CoreAttributes_Key").Equals(true)){
	        strSQL = "UPDATE CoreAttributes SET CoreAttributes_Key=0 WHERE CoreAttributes_Ky<>" + strKy;
	        new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
  			}
        if (boolAjax){
          Response.Write("ok");
        }else{
  				Response.Redirect("/admin/app/sdk/scheda-coreattributes.aspx?salvato=salvato&CoreAttributes_Ky=" + strKy);
        }
      }else{
        Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }
    

    public string createField()
    {
      string strSQL="";
      
      strSQL="ALTER TABLE " +  Smartdesk.Current.Request("CoreAttributes_Table") + " ADD "  + Smartdesk.Current.Request("CoreAttributes_Code");
	    new Smartdesk.Sql().SQLScriptExecuteNonQuery(strSQL);
      return "ok";
    }
    

}
