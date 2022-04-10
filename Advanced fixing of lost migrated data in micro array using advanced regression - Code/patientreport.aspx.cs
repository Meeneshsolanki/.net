using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Collections;
using System.Data.OleDb;
public partial class patientreport : System.Web.UI.Page
{
    SqlConnection con,con1,con2;
    SqlCommand cmdd;
    string query;
 
  
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    public void data()
    {
        string connstring = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
        con = new SqlConnection(connstring);
        con.Open();
        con1 = new SqlConnection(connstring);
        con1.Open();
        con2 = new SqlConnection(connstring);
        con2.Open();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = true;
        imgBanner.Visible = true;
        data();
        query = "delete from datasetdet";
        cmdd = new SqlCommand(query, con1);
        cmdd.ExecuteNonQuery();
        con1.Close();


        if ((FileUpload1.HasFile))
        {

            if (!Convert.IsDBNull(FileUpload1.PostedFile) &
                FileUpload1.PostedFile.ContentLength > 0)
            {

                //FIRST, SAVE THE SELECTED FILE IN THE ROOT DIRECTORY.
                FileUpload1.SaveAs(Server.MapPath(".") + "\\" + FileUpload1.FileName);

                SqlBulkCopy oSqlBulk = null;

                // SET A CONNECTION WITH THE EXCEL FILE.
                OleDbConnection myExcelConn = new OleDbConnection
                    ("Provider=Microsoft.ACE.OLEDB.12.0; " +
                        "Data Source=" + Server.MapPath(".") + "\\" + FileUpload1.FileName +
                        ";Extended Properties=Excel 12.0;");
                try
                {
                    myExcelConn.Open();

                    // GET DATA FROM EXCEL SHEET.
                    OleDbCommand objOleDB =
                        new OleDbCommand("SELECT *FROM [Sheet1$]", myExcelConn);

                    // READ THE DATA EXTRACTED FROM THE EXCEL FILE.
                    OleDbDataReader objBulkReader = null;
                    objBulkReader = objOleDB.ExecuteReader();

                    // SET THE CONNECTION STRING.
                    string sCon = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;

                    using (SqlConnection con = new SqlConnection(sCon))
                    {
                        con.Open();

                        // FINALLY, LOAD DATA INTO THE DATABASE TABLE.
                        oSqlBulk = new SqlBulkCopy(con);
                        oSqlBulk.DestinationTableName = "datasetdet"; // TABLE NAME.
                        oSqlBulk.WriteToServer(objBulkReader);
                    }
                    //lblack.Visible = true;
                }
                catch (Exception ex)
                {
                  //  lblack.Visible = true;
                 //   lblack.Text = ex.Message;
                    //lblConfirm.Attributes.Add("style", "color:red");
                }
                finally
                {
                    // CLEAR.
                    oSqlBulk.Close();
                    oSqlBulk = null;
                    myExcelConn.Close();
                    myExcelConn = null;
                }
            }
        }
    }

    protected void gettickvalue(object sender, EventArgs e)
    {
        imgBanner.Visible = false;
        lblack.Visible = true;
        Timer1.Dispose();
    }
}