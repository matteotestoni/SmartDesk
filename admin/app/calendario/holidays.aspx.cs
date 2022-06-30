using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Data;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
      Response.ContentType = "application/json";
      Response.Clear();
      Response.WriteFile("holidays-italy.json");
	  }
}
