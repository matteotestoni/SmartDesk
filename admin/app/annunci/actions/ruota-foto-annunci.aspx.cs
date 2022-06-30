using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class _Default : System.Web.UI.Page {
    
	public int intNumRecords = 0;
    public DataTable dtAnnunci;
    
    
   	public string strAnnunci_Ky="";
   	public string strFoto="";

    protected void Page_Load(object sender, EventArgs e)
    {
	  string strWHERENet="";
	  string strFROMNet = "";
	  string strORDERNet = "";
	 
	  
	  

      if (Smartdesk.Login.Verify){
          	strAnnunci_Ky = Request["Annunci_Ky"];
          	strFoto = Request["foto"];
            strWHERENet = "Annunci_Ky=" + strAnnunci_Ky;
            strORDERNet = "Annunci_Ky";
            strFROMNet = "Annunci";
            dtAnnunci = new DataTable("Annunci");
            dtAnnunci = Smartdesk.Sql.getTablePage(strFROMNet, null, "Annunci_Ky", strWHERENet, strORDERNet, 1, 1,Smartdesk.Config.Sql.ConnectionReadOnly, out this.intNumRecords);
            ruotaFoto();
            Response.Redirect("/admin/app/annunci/scheda-annunci.aspx?Annunci_Ky=" + strAnnunci_Ky);
      }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
      }
    }

    public bool ruotaFoto()
    {
        string strTemp="";
        string strPath="";
        bool output = false;
        
		strTemp="Annunci_Foto" + strFoto;
		strPath=dtAnnunci.Rows[0][strTemp].ToString();
		strPath=Server.MapPath(strPath);
		//Response.Write(strPath);
  		System.Drawing.Image myImage = System.Drawing.Image.FromFile(strPath);
		myImage.RotateFlip(RotateFlipType.Rotate90FlipNone);
		myImage.Save(strPath,System.Drawing.Imaging.ImageFormat.Jpeg);
        output=true;
        return output;
    }

	public DataTable getTablePage(string table, string tableout, string key, string where, string orderby, int pagina, int paginamax, string App){
	  DataTable dt= Smartdesk.Sql.getTablePage(table, tableout, key, where, orderby, pagina, paginamax, App,out this.intNumRecords);
	  return dt;
	}
}
