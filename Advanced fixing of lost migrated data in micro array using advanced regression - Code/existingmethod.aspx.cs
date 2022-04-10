using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
public partial class existingmethod : System.Web.UI.Page
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
    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    con = new SqlConnection(connstring);
    //    con.Open();
    //    query = "delete from performance";
    //    cmdd = new SqlCommand(query, con);
    //    cmdd.ExecuteNonQuery();
    //    con.Close();

    //    for (int i = 0; i < GridView1.Rows.Count; i++)
    //    {
    //        string dat = GridView1.Rows[i].Cells[0].Text.ToString();
    //        string  a = GridView2.Rows[i].Cells[2].Text.ToString();
    //        string b = GridView1.Rows[i].Cells[2].Text.ToString();
    //        int c = (Convert.ToInt32(a)) - (Convert.ToInt32(b));
    //        con = new SqlConnection(connstring);
    //        con.Open();
    //        query = "insert into performance(tdate,cputime)values('" + dat + "'," + c + ")";
    //        cmdd = new SqlCommand(query, con);
    //        cmdd.ExecuteNonQuery();
    //        con.Close();
            

    //    }
    //    GridView3.DataBind();
    //}
}