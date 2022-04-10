using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;
public partial class login : System.Web.UI.Page
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
        query = "select * from adminlogin where uname='" + txtusername.Text + "' and pwd='" + txtpassword.Text + "'";
        cmd = new SqlCommand(query, con);
        SqlDataReader red = cmd.ExecuteReader();
        if (red.Read())
        {
            
                Response.Redirect("empty.aspx");
            
        }
        else
        {
            MessageBox.Show("Invalid username & password");
        }
        red.Close();
        con.Close();
    }
}