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
public partial class missingdata : System.Web.UI.Page
{
    SqlConnection con;
    SqlCommand cmdd;
    string query;
    string connstring = WebConfigurationManager.ConnectionStrings["connect"].ConnectionString;
    ArrayList arr = new ArrayList();
    ArrayList testdate = new ArrayList();
    ArrayList missing = new ArrayList();
    ArrayList colour = new ArrayList();
    string WBC, RBC, HGB, HCT, MCV, MCH, MCHC, PLT, RDWSD, DW, MPV, PLCR, PCT, NRBC, NEUT, LYMPH, MONO, EO, BASO, IG;
    int inde;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        GridView1.Visible = true;
        GridView1.DataBind();
        //con.Close();
        Button2.Visible = true;

        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rd = cmdd.ExecuteReader();
        while (rd.Read())
        {
            arr.Add(rd[0].ToString());
        }
        rd.Close();
        con.Close();
        int n = arr.Count;


        con = new SqlConnection(connstring);
        con.Open();
        for (int i = 0; i < n; i++)
        {
            query = "select * from datasetdet where TestDate='" + arr[i].ToString() + "'";
            cmdd = new SqlCommand(query, con);
            SqlDataReader red = cmdd.ExecuteReader();
            if (red.Read())
            {
                WBC = red[4].ToString();
                if (WBC == "")
                {
                    GridView1.Rows[i].Cells[4].BackColor = Color.Red;
                }
                RBC = red[5].ToString();
                if (RBC == "")
                {
                    GridView1.Rows[i].Cells[5].BackColor = Color.Red;
                }
                HGB = red[6].ToString();
                if (HGB == "")
                {
                    GridView1.Rows[i].Cells[6].BackColor = Color.Red;
                }
                HCT = red[7].ToString();
                if (HCT == "")
                {
                    GridView1.Rows[i].Cells[7].BackColor = Color.Red;
                }
                MCV = red[8].ToString();
                if (MCV == "")
                {
                    GridView1.Rows[i].Cells[8].BackColor = Color.Red;
                }
                MCH = red[9].ToString();
                if (MCH == "")
                {
                    GridView1.Rows[i].Cells[9].BackColor = Color.Red;
                }
                MCHC = red[10].ToString();
                if (MCHC == "")
                {
                    GridView1.Rows[i].Cells[10].BackColor = Color.Red;
                }
                PLT = red[11].ToString();
                if (PLT == "")
                {
                    GridView1.Rows[i].Cells[11].BackColor = Color.Red;
                }

                RDWSD = red[12].ToString();
                if (RDWSD == "")
                {
                    GridView1.Rows[i].Cells[12].BackColor = Color.Red;
                }
                DW = red[13].ToString();
                if (DW == "")
                {
                    GridView1.Rows[i].Cells[13].BackColor = Color.Red;
                }
                MPV = red[14].ToString();
                if (MPV == "")
                {
                    GridView1.Rows[i].Cells[14].BackColor = Color.Red;
                }
                PLCR = red[15].ToString();
                if (PLCR == "")
                {
                    GridView1.Rows[i].Cells[15].BackColor = Color.Red;
                }
                PCT = red[16].ToString();
                if (PCT == "")
                {
                    GridView1.Rows[i].Cells[16].BackColor = Color.Red;
                }
                NRBC = red[17].ToString();
                if (NRBC == "")
                {
                    GridView1.Rows[i].Cells[17].BackColor = Color.Red;
                }
                NEUT = red[18].ToString();
                if (NEUT == "")
                {
                    GridView1.Rows[i].Cells[18].BackColor = Color.Red;
                }
                LYMPH = red[19].ToString();
                if (LYMPH == "")
                {
                    GridView1.Rows[i].Cells[19].BackColor = Color.Red;
                }
                MONO = red[20].ToString();
                if (MONO == "")
                {
                    GridView1.Rows[i].Cells[20].BackColor = Color.Red;
                }
                EO = red[21].ToString();
                if (EO == "")
                {
                    GridView1.Rows[i].Cells[21].BackColor = Color.Red;
                }
                BASO = red[22].ToString();
                if (BASO == "")
                {
                    GridView1.Rows[i].Cells[22].BackColor = Color.Red;
                }
                IG = red[23].ToString();
                if (IG == "")
                {
                    GridView1.Rows[i].Cells[23].BackColor = Color.Red;
                }
            }
        }
    }
    protected void gettickvalue(object sender, EventArgs e)
    {
        imgBanner.Visible = false;
        GridView1.Visible = true;
        Timer1.Dispose();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Timer1.Enabled = true;
        imgBanner.Visible = true;
        GridView1.Visible = false;
        Button3.Visible = true;
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,IG from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdIG = cmdd.ExecuteReader();
        while (rdIG.Read())
        {
            testdate.Add(rdIG[0].ToString());
            missing.Add(rdIG[1].ToString());
        }
        rdIG.Close();
        con.Close();

        int mIG = testdate.Count;
        int nIG = missing.Count;
        int numofnullIG = 0;
        //finding number of null values
        for (int j = 0; j < nIG; j++)
        {
            if (missing[j] == "")
            {
                numofnullIG = numofnullIG + 1;
            }

        }
        if (numofnullIG == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullIG; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nIG; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nIG - numofnullIG;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set IG='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select IG from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for EO
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,EO from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdEO = cmdd.ExecuteReader();
        while (rdEO.Read())
        {
            testdate.Add(rdEO[0].ToString());
            missing.Add(rdEO[1].ToString());
        }
        rdEO.Close();
        con.Close();

        int mEO = testdate.Count;
        int nEO = missing.Count;
        int numofnullEO = 0;
        //finding number of null values
        for (int j = 0; j < nEO; j++)
        {
            if (missing[j] == "")
            {
                numofnullEO = numofnullEO + 1;
            }

        }
        if (numofnullEO == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullEO; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nEO; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nEO - numofnullEO;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set EO='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select EO from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for LYMPH
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,LYMPH from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdLYMPH = cmdd.ExecuteReader();
        while (rdLYMPH.Read())
        {
            testdate.Add(rdLYMPH[0].ToString());
            missing.Add(rdLYMPH[1].ToString());
        }
        rdLYMPH.Close();
        con.Close();

        int mLYMPH = testdate.Count;
        int nLYMPH = missing.Count;
        int numofnullLYMPH = 0;
        //finding number of null values
        for (int j = 0; j < nLYMPH; j++)
        {
            if (missing[j] == "")
            {
                numofnullLYMPH = numofnullLYMPH + 1;
            }

        }
        if (numofnullLYMPH == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullLYMPH; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nLYMPH; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nLYMPH - numofnullLYMPH;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set LYMPH='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select LYMPH from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for NEUT
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,NEUT from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdNEUT = cmdd.ExecuteReader();
        while (rdNEUT.Read())
        {
            testdate.Add(rdNEUT[0].ToString());
            missing.Add(rdNEUT[1].ToString());
        }
        rdNEUT.Close();
        con.Close();

        int mNEUT = testdate.Count;
        int nNEUT = missing.Count;
        int numofnullNEUT = 0;
        //finding number of null values
        for (int j = 0; j < nNEUT; j++)
        {
            if (missing[j] == "")
            {
                numofnullNEUT = numofnullNEUT + 1;
            }

        }
        if (numofnullNEUT == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullNEUT; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nNEUT; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nNEUT - numofnullNEUT;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set NEUT='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select NEUT from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for NRBC
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,NRBC from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdNRBC = cmdd.ExecuteReader();
        while (rdNRBC.Read())
        {
            testdate.Add(rdNRBC[0].ToString());
            missing.Add(rdNRBC[1].ToString());
        }
        rdNRBC.Close();
        con.Close();

        int mNRBC = testdate.Count;
        int nNRBC = missing.Count;
        int numofnullNRBC = 0;
        //finding number of null values
        for (int j = 0; j < nNRBC; j++)
        {
            if (missing[j] == "")
            {
                numofnullNRBC = numofnullNRBC + 1;
            }

        }
        if (numofnullNRBC == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullNRBC; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nNRBC; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nNRBC - numofnullNRBC;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set NRBC='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select NRBC from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for PCT
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,PCT from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdPCT = cmdd.ExecuteReader();
        while (rdPCT.Read())
        {
            testdate.Add(rdPCT[0].ToString());
            missing.Add(rdPCT[1].ToString());
        }
        rdPCT.Close();
        con.Close();

        int mPCT = testdate.Count;
        int nPCT = missing.Count;
        int numofnullPCT = 0;
        //finding number of null values
        for (int j = 0; j < nPCT; j++)
        {
            if (missing[j] == "")
            {
                numofnullPCT = numofnullPCT + 1;
            }

        }
        if (numofnullPCT == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullPCT; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nPCT; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nPCT - numofnullPCT;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set PCT='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select PCT from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for PLCR
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,PLCR from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdPLCR = cmdd.ExecuteReader();
        while (rdPLCR.Read())
        {
            testdate.Add(rdPLCR[0].ToString());
            missing.Add(rdPLCR[1].ToString());
        }
        rdPLCR.Close();
        con.Close();

        int mPLCR = testdate.Count;
        int nPLCR = missing.Count;
        int numofnullPLCR = 0;
        //finding number of null values
        for (int j = 0; j < nPLCR; j++)
        {
            if (missing[j] == "")
            {
                numofnullPLCR = numofnullPLCR + 1;
            }

        }
        if (numofnullPLCR == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullPLCR; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nPLCR; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nPLCR - numofnullPLCR;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set PLCR='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select PLCR from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for MPV
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,MPV from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdMPV = cmdd.ExecuteReader();
        while (rdMPV.Read())
        {
            testdate.Add(rdMPV[0].ToString());
            missing.Add(rdMPV[1].ToString());
        }
        rdMPV.Close();
        con.Close();

        int mMPV = testdate.Count;
        int nMPV = missing.Count;
        int numofnullMPV = 0;
        //finding number of null values
        for (int j = 0; j < nMPV; j++)
        {
            if (missing[j] == "")
            {
                numofnullMPV = numofnullMPV + 1;
            }

        }
        if (numofnullMPV == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullMPV; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nMPV; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nMPV - numofnullMPV;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set MPV='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select MPV from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for DW
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,DW from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdDW = cmdd.ExecuteReader();
        while (rdDW.Read())
        {
            testdate.Add(rdDW[0].ToString());
            missing.Add(rdDW[1].ToString());
        }
        rdDW.Close();
        con.Close();

        int mDW = testdate.Count;
        int nDW = missing.Count;
        int numofnullDW = 0;
        //finding number of null values
        for (int j = 0; j < nDW; j++)
        {
            if (missing[j] == "")
            {
                numofnullDW = numofnullDW + 1;
            }

        }
        if (numofnullDW == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullDW; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nDW; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nDW - numofnullDW;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set DW='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select DW from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for RDWSD
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,RDWSD from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdRDWSD = cmdd.ExecuteReader();
        while (rdRDWSD.Read())
        {
            testdate.Add(rdRDWSD[0].ToString());
            missing.Add(rdRDWSD[1].ToString());
        }
        rdRDWSD.Close();
        con.Close();

        int mRDWSD = testdate.Count;
        int nRDWSD = missing.Count;
        int numofnullRDWSD = 0;
        //finding number of null values
        for (int j = 0; j < nRDWSD; j++)
        {
            if (missing[j] == "")
            {
                numofnullRDWSD = numofnullRDWSD + 1;
            }

        }
        if (numofnullRDWSD == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullRDWSD; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nRDWSD; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nRDWSD - numofnullRDWSD;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set RDWSD='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select RDWSD from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for PLT
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,PLT from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdPLT = cmdd.ExecuteReader();
        while (rdPLT.Read())
        {
            testdate.Add(rdPLT[0].ToString());
            missing.Add(rdPLT[1].ToString());
        }
        rdPLT.Close();
        con.Close();

        int mPLT = testdate.Count;
        int nPLT = missing.Count;
        int numofnullPLT = 0;
        //finding number of null values
        for (int j = 0; j < nPLT; j++)
        {
            if (missing[j] == "")
            {
                numofnullPLT = numofnullPLT + 1;
            }

        }
        if (numofnullPLT == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullPLT; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nPLT; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nPLT - numofnullPLT;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set PLT='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select PLT from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*********************************************************************
        //for MCHC
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,MCHC from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdMCHC = cmdd.ExecuteReader();
        while (rdMCHC.Read())
        {
            testdate.Add(rdMCHC[0].ToString());
            missing.Add(rdMCHC[1].ToString());
        }
        rdMCHC.Close();
        con.Close();

        int mMCHC = testdate.Count;
        int nMCHC = missing.Count;
        int numofnullMCHC = 0;
        //finding number of null values
        for (int j = 0; j < nMCHC; j++)
        {
            if (missing[j] == "")
            {
                numofnullMCHC = numofnullMCHC + 1;
            }

        }
        if (numofnullMCHC == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullMCHC; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nMCHC; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nMCHC - numofnullMCHC;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set MCHC='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select MCHC from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //************************************************
        //for MCH
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,MCH from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdMCH = cmdd.ExecuteReader();
        while (rdMCH.Read())
        {
            testdate.Add(rdMCH[0].ToString());
            missing.Add(rdMCH[1].ToString());
        }
        rdMCH.Close();
        con.Close();

        int mMCH = testdate.Count;
        int nMCH = missing.Count;
        int numofnullMCH = 0;
        //finding number of null values
        for (int j = 0; j < nMCH; j++)
        {
            if (missing[j] == "")
            {
                numofnullMCH = numofnullMCH + 1;
            }

        }
        if (numofnullMCH == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullMCH; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nMCH; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nMCH - numofnullMCH;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set MCH='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select MCH from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }



        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //************************************************
        //for MCV
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,MCV from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdMCV = cmdd.ExecuteReader();
        while (rdMCV.Read())
        {
            testdate.Add(rdMCV[0].ToString());
            missing.Add(rdMCV[1].ToString());
        }
        rdMCV.Close();
        con.Close();

        int mMCV = testdate.Count;
        int nMCV = missing.Count;
        int numofnullMCV = 0;
        //finding number of null values
        for (int j = 0; j < nMCV; j++)
        {
            if (missing[j] == "")
            {
                numofnullMCV = numofnullMCV + 1;
            }

        }
        if (numofnullMCV == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullMCV; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nMCV; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nMCV - numofnullMCV;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set MCV='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select MCV from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }

            //changing green color
            //  GridView1.DataBind();
            int col;
            col = colour.Count;
            for (int c = 0; c < col; c++)
            {
                int trick = Convert.ToInt32(colour[c]);
                GridView1.Rows[trick].Cells[22].BackColor = Color.Green;
            }

        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //************************************************
        //for HCT
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,HCT from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdHCT = cmdd.ExecuteReader();
        while (rdHCT.Read())
        {
            testdate.Add(rdHCT[0].ToString());
            missing.Add(rdHCT[1].ToString());
        }
        rdHCT.Close();
        con.Close();

        int mHCT = testdate.Count;
        int nHCT = missing.Count;
        int numofnullHCT = 0;
        //finding number of null values
        for (int j = 0; j < nHCT; j++)
        {
            if (missing[j] == "")
            {
                numofnullHCT = numofnullHCT + 1;
            }

        }
        if (numofnullHCT == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullHCT; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nHCT; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nHCT - numofnullHCT;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set HCT='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select HCT from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }

            //changing green color
            //  GridView1.DataBind();
            int col;
            col = colour.Count;
            for (int c = 0; c < col; c++)
            {
                int trick = Convert.ToInt32(colour[c]);
                GridView1.Rows[trick].Cells[22].BackColor = Color.Green;
            }

        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //************************************************
        //for HGB
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,HGB from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdHGB = cmdd.ExecuteReader();
        while (rdHGB.Read())
        {
            testdate.Add(rdHGB[0].ToString());
            missing.Add(rdHGB[1].ToString());
        }
        rdHGB.Close();
        con.Close();

        int mHGB = testdate.Count;
        int nHGB = missing.Count;
        int numofnullHGB = 0;
        //finding number of null values
        for (int j = 0; j < nHGB; j++)
        {
            if (missing[j] == "")
            {
                numofnullHGB = numofnullHGB + 1;
            }

        }
        if (numofnullHGB == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnullHGB; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nHGB; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nHGB - numofnullHGB;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set HGB='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select HGB from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }

            //changing green color
            //  GridView1.DataBind();
            int col;
            col = colour.Count;
            for (int c = 0; c < col; c++)
            {
                int trick = Convert.ToInt32(colour[c]);
                GridView1.Rows[trick].Cells[22].BackColor = Color.Green;
            }

        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //************************************************
        //for RBC
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,RBC from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdR = cmdd.ExecuteReader();
        while (rdR.Read())
        {
            testdate.Add(rdR[0].ToString());
            missing.Add(rdR[1].ToString());
        }
        rdR.Close();
        con.Close();

        int mr = testdate.Count;
        int nr = missing.Count;
        int numofnull3 = 0;
        //finding number of null values
        for (int j = 0; j < nr; j++)
        {
            if (missing[j] == "")
            {
                numofnull3 = numofnull3 + 1;
            }

        }
        if (numofnull3 == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnull3; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nr; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nr - numofnull3;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set RBC='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select RBC from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }

            //changing green color
            //  GridView1.DataBind();
            int col;
            col = colour.Count;
            for (int c = 0; c < col; c++)
            {
                int trick = Convert.ToInt32(colour[c]);
                GridView1.Rows[trick].Cells[22].BackColor = Color.Green;
            }

        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //************************************************
        //for WBC
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,WBC from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdW = cmdd.ExecuteReader();
        while (rdW.Read())
        {
            testdate.Add(rdW[0].ToString());
            missing.Add(rdW[1].ToString());
        }
        rdW.Close();
        con.Close();

        int mw = testdate.Count;
        int nw = missing.Count;
        int numofnull2 = 0;
        //finding number of null values
        for (int j = 0; j < nw; j++)
        {
            if (missing[j] == "")
            {
                numofnull2 = numofnull2 + 1;
            }

        }
        if (numofnull2 == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnull2; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < nw; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = nw - numofnull2;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set WBC='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select WBC from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }

            //changing green color
            //  GridView1.DataBind();
            int col;
            col = colour.Count;
            for (int c = 0; c < col; c++)
            {
                int trick = Convert.ToInt32(colour[c]);
                GridView1.Rows[trick].Cells[22].BackColor = Color.Green;
            }

        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //************************************************
        //for BASO
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,BASO from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rd = cmdd.ExecuteReader();
        while (rd.Read())
        {
            testdate.Add(rd[0].ToString());
            missing.Add(rd[1].ToString());
        }
        rd.Close();
        con.Close();

        int m = testdate.Count;
        int n = missing.Count;
        int numofnull = 0;
        //finding number of null values
        for (int j = 0; j < n; j++)
        {
            if (missing[j] == "")
            {
                numofnull = numofnull + 1;
            }

        }
        if (numofnull == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnull; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < n; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = n - numofnull;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set BASO='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select BASO from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }

            //changing green color
            //  GridView1.DataBind();
            int col;
            col = colour.Count;
            for (int c = 0; c < col; c++)
            {
                int trick = Convert.ToInt32(colour[c]);
                GridView1.Rows[trick].Cells[22].BackColor = Color.Green;
            }

        }
        testdate.Clear();
        missing.Clear();
        colour.Clear();
        //*************************************
        //For MONO
        con = new SqlConnection(connstring);
        con.Open();
        query = "select TestDate,MONO from datasetdet";
        cmdd = new SqlCommand(query, con);
        SqlDataReader rdm = cmdd.ExecuteReader();
        while (rdm.Read())
        {
            testdate.Add(rdm[0].ToString());
            missing.Add(rdm[1].ToString());
        }
        rdm.Close();
        con.Close();

        int m1 = testdate.Count;
        int n1 = missing.Count;
        int numofnull1 = 0;
        //finding number of null values
        for (int j = 0; j < n1; j++)
        {
            if (missing[j] == "")
            {
                numofnull1 = numofnull1 + 1;
            }

        }

        if (numofnull1 == 0)
        {

        }
        else
        {
            for (int k = 0; k < numofnull1; k++)
            {


                Double val = 0.0;
                Double finalvalue;

                //addding and getting avg
                for (int i = 0; i < n1; i++)
                {
                    if (missing[i] == "")
                    {
                        inde = i;
                        colour.Add(i);
                    }
                    else
                    {
                        val = val + Convert.ToDouble(missing[i].ToString());
                    }
                }
                finalvalue = n1 - numofnull1;
                finalvalue = val / finalvalue;
                finalvalue = Math.Round(finalvalue, 2);
                //finding index for null value

                con = new SqlConnection(connstring);
                con.Open();
                query = "update datasetdet set MONO='" + finalvalue.ToString() + "' where TestDate='" + testdate[inde].ToString() + "'";
                cmdd = new SqlCommand(query, con);
                cmdd.ExecuteNonQuery();
                con.Close();


                //filling array again for finding missing value
                //  numofnull = numofnull - 1;
                missing.Clear();
                con = new SqlConnection(connstring);
                con.Open();
                query = "select MONO from datasetdet";
                cmdd = new SqlCommand(query, con);
                SqlDataReader rd8 = cmdd.ExecuteReader();
                while (rd8.Read())
                {

                    missing.Add(rd8[0].ToString());
                }
                rd8.Close();
                con.Close();
            }

            //changing green color
            if (Page.IsPostBack)
            {
                int col;
                col = colour.Count;
                for (int c = 0; c < col; c++)
                {
                    int trick = Convert.ToInt32(colour[c]);
                    GridView1.Rows[trick].Cells[20].BackColor = Color.Green;
                }
            }

        }

        GridView1.DataBind();
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            for (int j = 0; j < GridView2.Columns.Count; j++)
            {
                //if (string.IsNullOrEmpty(GridView2.Rows[i].Cells[j].ToString()))
                if (GridView2.Rows[i].Cells[j].Text == "&nbsp;")
                {
                    // Write your Custom Code
                    GridView1.Rows[i].Cells[j].BackColor = Color.Green;
                }
            }
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        string a = System.DateTime.Today.ToShortDateString();
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment;filename=" + a + ".xls");
        //   Response.AddHeader("content-disposition", "attachment;filename=FileName.xls");
        Response.Charset = "";
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.ContentType = "application/vnd.xls";
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
        GridView1.RenderControl(htmlWrite);
        Response.Write(stringWrite.ToString());
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {  // Confirms that an HtmlForm control is rendered for the85.  
        // specified ASP.NET server control at run time.86.87.    
    }
}