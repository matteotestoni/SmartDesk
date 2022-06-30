using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string strRedirect = Smartdesk.Current.LoginPageRoot;
        string strSorgente = Smartdesk.Current.Request("sorgente");
        string strDeletemultiplo = Smartdesk.Current.Request("deletemultiplo");
        string strIds = Smartdesk.Current.Request("azionidigruppo-ids");
        bool boolAjax = false;
        DataTable dtCoreGrids;
        DataTable dtCoreGridsSorgente;
        DataTable dtCoreFormsSorgente;
        int intCoreGrids_Ky = 0;
        string strJson = "";
        string strSorgenteTipo="";
        string strSorgenteKy="";

        if (Request["ajax"]!=null && Request["ajax"].ToString().Length>0){
          boolAjax = Convert.ToBoolean(Request["ajax"]);
        }
        if (Smartdesk.Login.Verify){
          intCoreGrids_Ky=Convert.ToInt32(Smartdesk.Current.Request("CoreGrids_Ky"));
          dtCoreGrids = Smartdesk.Data.Read("CoreGrids_Vw", "CoreGrids_Ky", intCoreGrids_Ky.ToString());
          if (strDeletemultiplo=="deletemultiplo"){
              Smartdesk.Functions.SqlDeleteKeyIn(dtCoreGrids.Rows[0]["CoreEntities_Code"].ToString(),strIds);
          }else{
              Smartdesk.Functions.SqlDeleteKey(dtCoreGrids.Rows[0]["CoreEntities_Code"].ToString());
          }
          if (boolAjax==true){
            Response.Write("ok");
          }else{
            if (strSorgente.Length>0){
              //c'è un sorgente e devo ritornare al sorgente dopo la cancellazione
              //sorgente tipo form-213
              //se è un form vado a prendere l'id del form
              string[] tokens = strSorgente.Split('-');
              strSorgenteTipo=tokens[0];
              strSorgenteKy=tokens[1];
              switch (strSorgenteTipo){
                case "form":
                  dtCoreFormsSorgente=Smartdesk.Data.Read("CoreForms_Vw", "CoreForms_Ky", strSorgenteKy);
                  if (dtCoreFormsSorgente.Rows[0]["CoreForms_Custom"].Equals(true)){
                    strRedirect="/admin/app/" + dtCoreFormsSorgente.Rows[0]["CoreModules_Code"].ToString() + "/scheda-" + dtCoreFormsSorgente.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreForms_Ky=" + dtCoreFormsSorgente.Rows[0]["CoreForms_Ky"].ToString();
                  }else{
                    strRedirect="/admin/form.aspx?CoreForms_Ky=" + dtCoreFormsSorgente.Rows[0]["CoreForms_Ky"].ToString();
                  }     
                  strRedirect = strRedirect + "&" + dtCoreFormsSorgente.Rows[0]["CoreEntities_Key"].ToString()  + "=" + Smartdesk.Current.Request(dtCoreFormsSorgente.Rows[0]["CoreEntities_Key"].ToString());
                         
                  break;
                case "view":
                  dtCoreGridsSorgente=Smartdesk.Data.Read("CoreGrids_Vw", "CoreGrids_Ky", strSorgenteKy);
                  if (dtCoreGridsSorgente.Rows[0]["CoreGrids_Custom"].Equals(true)){
                    strRedirect="/admin/app/" + dtCoreGridsSorgente.Rows[0]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreGridsSorgente.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreGrids_Ky=" + dtCoreGridsSorgente.Rows[0]["CoreGrids_Ky"].ToString();
                  }else{
                    strRedirect="/admin/view.aspx?CoreGrids_Ky=" + dtCoreGridsSorgente.Rows[0]["CoreGrids_Ky"].ToString();
                  }            
                  break;
              }
        	    Response.Redirect(strRedirect);
            }else{
              if (dtCoreGrids.Rows[0]["CoreGrids_Custom"].Equals(true)){
                strRedirect="/admin/app/" + dtCoreGrids.Rows[0]["CoreModules_Code"].ToString() + "/elenco-" + dtCoreGrids.Rows[0]["CoreEntities_Code"].ToString() + ".aspx?custom=1&CoreGrids_Ky=" + dtCoreGrids.Rows[0]["CoreGrids_Ky"].ToString();
              }else{
                strRedirect="/admin/view.aspx?CoreGrids_Ky=" + intCoreGrids_Ky;
              }            
            }
        	  Response.Redirect(strRedirect);
          }
        }else{
          if (boolAjax==true){
            strJson="{\"error\": \"not authorized\"}";
            Response.Write(strJson);
          }else{
            Response.Redirect(Smartdesk.Current.LoginPageRoot);
          }
        }
    }
}
