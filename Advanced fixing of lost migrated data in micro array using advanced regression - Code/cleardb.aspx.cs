using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;
public partial class cleardb : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmd;
    string query;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        data();
        query = "delete from consoldateddet";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        data();
        query = "delete from datasetdet";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        data();
        query = "delete from occurenceper";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        data();
        query = "delete from existingtab";
        cmd = new SqlCommand(query, con);
        cmd.ExecuteNonQuery();
        con.Close();
        MessageBox.Show("DataBase Cleared Successfully!!!");

    }
}