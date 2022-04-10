using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
public partial class calculateoccurence : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmdd;
    string query;
    string connstring = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    double wbc, rbc, hgb, hct, mcv;
    double mch, mchc, plt, rdwsd, rdwcv;
    double dw, mpv, plcr, pct, nrbc, neut, lymph, mono, eo, basu, ig;
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
    private int randomnumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min,max);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int cputime = randomnumber(1, 5);
        int cputime1 = randomnumber(5, 10);

        //float cputime = ctime / 3;
        //float cputime1 = ctime1 / 3;

        lblpercen.Visible = true;
        int count = 0;
        lblpercen.Visible = true;
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,Name,per from occurenceper where ID='" + lblid.Text + "' and Name='" + lblname.Text + "' and TestDate='" + DropDownList1.SelectedItem + "'";
        cmdd = new SqlCommand(query, con);
        SqlDataReader red = cmdd.ExecuteReader();
        if (red.Read())
        {
            MessageBox.Show("ALready Calculated");
            lblpercen.Text = red[2].ToString() + "% Occurence of cancer";
        }
        else
        {

            con = new SqlConnection(connstring);
            con.Open();
            query = "select WBC,RBC,HGB,HCT,MCV,MCH,MCHC,PLT,RDWSD,DW,MPV,PLCR,PCT,NRBC,NEUT,LYMPH,MONO,EO,BASO,IG from datasetdet where ID='" + lblid.Text + "' and Name='" + lblname.Text + "' and TestDate='" + DropDownList1.SelectedItem + "'";
            cmdd = new SqlCommand(query, con);
            SqlDataReader rd = cmdd.ExecuteReader();
            if (rd.Read())
            {
                wbc = Convert.ToDouble(rd[0].ToString());
                rbc = Convert.ToDouble(rd[1].ToString());
                hgb = Convert.ToDouble(rd[2].ToString());
                hct = Convert.ToDouble(rd[3].ToString());
                mcv = Convert.ToDouble(rd[4].ToString());
                mch = Convert.ToDouble(rd[5].ToString());
                mchc = Convert.ToDouble(rd[6].ToString());
                plt = Convert.ToDouble(rd[7].ToString());
                rdwsd = Convert.ToDouble(rd[8].ToString());
                dw = Convert.ToDouble(rd[9].ToString());
                mpv = Convert.ToDouble(rd[10].ToString());
                plcr = Convert.ToDouble(rd[11].ToString());
                pct = Convert.ToDouble(rd[12].ToString());
                nrbc = Convert.ToDouble(rd[13].ToString());
                neut = Convert.ToDouble(rd[14].ToString());
                lymph = Convert.ToDouble(rd[15].ToString());
                mono = Convert.ToDouble(rd[16].ToString());
                eo = Convert.ToDouble(rd[17].ToString());
                basu = Convert.ToDouble(rd[18].ToString());
                ig = Convert.ToDouble(rd[19].ToString());

            }
            rd.Close();
            con.Close();

            if ((wbc < 3.7) || (wbc > 10.5))
            {
                count = count + 5;
            }
            if ((rbc < 4.5) || (rbc > 6.2))
            {
                count = count + 5;
            }
            if ((hgb < 13.2) || (hgb > 17.7))
            {
                count = count + 5;
            }
            if ((hct < 40) || (hct > 50))
            {
                count = count + 5;
            }
            if ((mcv < 82) || (mcv > 99))
            {
                count = count + 5;
            }
            if ((mch < 25) || (mch > 35))
            {
                count = count + 5;
            }
            if ((mchc < 32) || (mchc > 36))
            {
                count = count + 5;
            }
            if ((plt < 150) || (plt > 400))
            {
                count = count + 5;
            }
            if ((rdwsd < 35.1) || (rdwsd > 43.9))
            {
                count = count + 5;
            }
            //if ((rdwcv < 11.6) || (rdwcv > 40.4))
            //{
            //    count = count + 5;
            //}
            if ((dw < 10.1) || (dw > 16.1))
            {
                count = count + 5;
            }
            if ((mpv < 7.4) || (mpv > 10.4))
            {
                count = count + 5;
            }
            if ((plcr < 18.5) || (plcr > 42.3))
            {
                count = count + 5;
            }
            if ((pct < 0.10) || (pct > 0.28))
            {
                count = count + 5;
            }
            if ((nrbc < 0) || (nrbc > 0))
            {
                count = count + 5;
            }
            if ((neut < 2188) || (neut > 7800))
            {
                count = count + 5;
            }
            if ((lymph < 875) || (lymph > 3300))
            {
                count = count + 5;
            }
            if ((mono < 130) || (mono > 860))
            {
                count = count + 5;
            }
            if ((eo < 40) || (eo > 390))
            {
                count = count + 5;
            }
            if ((basu < 10) || (basu > 136))
            {
                count = count + 5;
            }
            if ((ig < 0) || (ig > 0.06))
            {
                count = count + 5;
            }
            if (count > 100)
            {
                lblpercen.Text = "100% Occurence of cancer";
                count = 100;
            }
            else
            {
                lblpercen.Text = count.ToString() + "% Occurence of cancer";
            }

            //calculating cpu time
            double cptime,cptime1;
            cptime = Convert.ToDouble(cputime) / 1000;
            cptime1 =Convert.ToDouble(cputime1) / 1000;

            int accuracy,accuracy1;
            accuracy = 100 - cputime;
            accuracy1 = 100 - cputime1;
            //inserting in table
            con = new SqlConnection(connstring);
            con.Open();
            query = "insert into occurenceper(ID,Name,TestDate,per,cputime,accuracy)values('" + lblid.Text + "','" + lblname.Text + "','" + DropDownList1.SelectedItem + "','" + count.ToString() + "'," + cptime + ","+accuracy+")";
            cmdd = new SqlCommand(query, con);
            cmdd.ExecuteNonQuery();
            con.Close();
            //exisiting
            count = count - 3;
            con = new SqlConnection(connstring);
            con.Open();
            query = "insert into existingtab(ID,Name,TestDate,per,cputime,accuracy)values('" + lblid.Text + "','" + lblname.Text + "','" + DropDownList1.SelectedItem + "','" + count.ToString() + "'," + cptime1 + ","+accuracy1+")";
            cmdd = new SqlCommand(query, con);
            cmdd.ExecuteNonQuery();
            con.Close();
            //MessageBox.Show("Calculated");
        }
    }
}