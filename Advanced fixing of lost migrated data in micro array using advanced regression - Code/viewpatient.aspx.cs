using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
public partial class viewpatient : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmdd;
    string query;
    string connstring = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(connstring);
        con.Open();
        query = "select ID,Name from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rd = cmdd.ExecuteReader();
        if (rd.Read())
        {
            lblid.Text = rd[0].ToString();
            lblname.Text = rd[1].ToString();
        }
        rd.Close();
        con.Close();
    }
}