using System;
using System.Data;
using System.Data.SqlClient;

  public partial class _Default : System.Web.UI.Page 
	{
    
    public System.Globalization.CultureInfo ci = new System.Globalization.CultureInfo("it-IT");
    public System.Globalization.CultureInfo ciEn = new System.Globalization.CultureInfo("en-US");
    public string strCMSAds_Ky="";
 
    protected void Page_Load(object sender, EventArgs e)
    {
      string strSQL="";
      SqlConnection conn;
      SqlCommand cmd1;
      SqlCommand cmd2;

      
	  conn = new SqlConnection(Smartdesk.Config.Sql.ConnectionWrite);
	  conn.Open();
		strCMSAds_Ky = Smartdesk.Current.Request("CMSAds_Ky");
		strSQL = "INSERT INTO CMSAdsStatistiche (CMSAdsStatistiche_Data, CMSAdsStatistiche_Tipo, CMSAds_Ky, CMSAdsStatistiche_UserInsert, CMSAdsStatistiche_DateInsert)";
		strSQL += "VALUES (GETDATE(),1," + strCMSAds_Ky + ",0,GETDATE())";
		//Response.Write(strSQL);
		cmd1 = new SqlCommand(strSQL, conn);
		cmd1.CommandTimeout = 0;
		cmd1.ExecuteNonQuery();

        strSQL = "UPDATE CMSAds SET CMSAds_Click=CMSAds_Click+1 WHERE CMSAds_Ky=" + strCMSAds_Ky;
        //Response.Write(strSQL);
        cmd2 = new SqlCommand(strSQL, conn);
        cmd2.CommandTimeout = 0;
        cmd2.ExecuteNonQuery();
        conn.Close();

		Response.Write("ok");

    }
}
