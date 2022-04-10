using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Collections;
public partial class comparechart : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmdd;
    string query;
    ArrayList arr = new ArrayList();
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        con = new SqlConnection(connstring);
        con.Open();
        query = "delete from consoldateddet";
        cmdd = new SqlCommand(query, con);
        cmdd.ExecuteNonQuery();
        con.Close();


        Chart1.Visible = true;
        con = new SqlConnection(connstring);
        con.Open();
        query = "select per from occurenceper where ID='" + lblid.Text + "' and Name='" + lblname.Text + "'";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rd = cmdd.ExecuteReader();
        while (rd.Read())
        {
            arr.Add(rd[0].ToString());
        }
        rd.Close();
        con.Close();

        int n, finalval = 0;
        n = arr.Count;
        for (int i = 0; i < n; i++)
        {
            finalval = finalval + Convert.ToInt32(arr[i].ToString());

        }
        finalval = finalval / n;
        con = new SqlConnection(connstring);
        con.Open();
        query = "insert into consoldateddet(id,Name,conchart,per)values('" + lblid.Text + "','" + lblname.Text + "','Consolidated Chart','" + finalval.ToString() + "')";
        cmdd = new SqlCommand(query, con);
        cmdd.ExecuteNonQuery();
        con.Close();
        Chart1.DataBind();

    }
}