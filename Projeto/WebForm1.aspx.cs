using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace Projeto
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridView1.DataSource = getDados_();
                GridView1.DataBind();
            }
        }

        private DataTable getDados_()
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("categoria");
            dt.Columns.Add("numCC");

            DataRow data = dt.NewRow();
            data["categoria"] = "Agência de publicidade";
            data["numCC"] = 7000;

            DataRow data2 = dt.NewRow();
            data2["categoria"] = "Clínica de Psicologia";
            data2["numCC"] = 7000;

            dt.Rows.Add(data);
            dt.Rows.Add(data2);

            return dt;
        }

        private void capturaDados()
        {
            foreach (GridViewRow gridView in GridView1.Rows)
            {
                CheckBox CheckBox0 = (CheckBox)gridView.FindControl("CheckBox0"); //pub
                CheckBox CheckBox1 = (CheckBox)gridView.FindControl("CheckBox1"); //dir
                CheckBox CheckBox2 = (CheckBox)gridView.FindControl("CheckBox2"); //adm
                CheckBox CheckBox3 = (CheckBox)gridView.FindControl("CheckBox3"); //enf
                CheckBox CheckBox4 = (CheckBox)gridView.FindControl("CheckBox4"); //fis
                CheckBox CheckBox5 = (CheckBox)gridView.FindControl("CheckBox5"); //psi
                CheckBox CheckBox6 = (CheckBox)gridView.FindControl("CheckBox6"); //con
                CheckBox CheckBox7 = (CheckBox)gridView.FindControl("CheckBox7"); //med
                CheckBox CheckBox8 = (CheckBox)gridView.FindControl("CheckBox8"); //pos
                CheckBox CheckBox9 = (CheckBox)gridView.FindControl("CheckBox9"); //comite ética
                CheckBox CheckBox10 = (CheckBox)gridView.FindControl("CheckBox10"); //disciplinas digitais
                CheckBox CheckBox11 = (CheckBox)gridView.FindControl("CheckBox11"); //bioenergia
                CheckBox CheckBox12 = (CheckBox)gridView.FindControl("CheckBox12"); //nqa

                DropDownList dropDownList1 = (DropDownList)gridView.FindControl("dropDownList1"); //cc
                DropDownList dropDownList2 = (DropDownList)gridView.FindControl("dropDownList2"); //qtde
                DropDownList dropDownList3 = (DropDownList)gridView.FindControl("dropDownList3"); //regra de calc

                int cc;
                int qtde;
                int regraCal;

                //coluna dropdown CC
                if (Convert.ToInt32(dropDownList1.SelectedValue) == 1)
                {
                    cc = 1; //nao
                }
                else if (Convert.ToInt32(dropDownList1.SelectedValue) == 2)
                {
                    cc = 2; //sim
                }
                else
                {
                    cc = 0; // nao selecionado
                }

                //coluna dropdown qtde
                switch (Convert.ToInt32(dropDownList2.SelectedValue))
                {
                    case 0:
                        qtde = 0;
                        break;
                    case 1:
                        qtde = 1;
                        break;
                    case 2:
                        qtde = 2;
                        break;
                    case 3:
                        qtde = 3;
                        break;
                    case 4:
                        qtde = 4;
                        break;
                    case 5:
                        qtde = 5;
                        break;
                    case 6:
                        qtde = 6;
                        break;
                    case 7:
                        qtde = 7;
                        break;
                    case 8:
                        qtde = 8;
                        break;
                    case 9:
                        qtde = 9;
                        break;
                    case 10:
                        qtde = 10;
                        break;
                }

                //coluna dropdown regra de calculo 
                if (Convert.ToInt32(dropDownList3.SelectedValue) == 1)
                {
                    regraCal = 1; //único curso
                }
                else if (Convert.ToInt32(dropDownList3.SelectedValue) == 2)
                {
                    regraCal = 2; //ch proporcional
                }
                else
                {
                    regraCal = 0; //nao selecionado
                }

                //coluna checkbox pub
                int pub;
                if (CheckBox0.Checked)
                {
                    pub = 1; //check
                }
                else
                {
                    pub = 0; // nao check
                }

                //coluna checkbox dir
                int dir;
                if (CheckBox1.Checked)
                {
                    dir = 1; //check
                }
                else
                {
                    dir = 0; //nao check
                }

                //coluna checkbox adm
                int adm;
                if (CheckBox2.Checked)
                {
                    adm = 1; //check
                }
                else
                {
                    adm = 0; //nao check
                }

                //coluna checkbox enf
                int enf;
                if (CheckBox3.Checked)
                {
                    enf = 1; //check
                }
                else
                {
                    enf = 0; //nao check
                }

                //coluna checkbox fis
                int fis;
                if (CheckBox4.Checked)
                {
                    fis = 1; //check
                }
                else
                {
                    fis = 0; // nao check
                }

                //coluna checkbox psi
                int psi;
                if (CheckBox5.Checked)
                {
                    psi = 1; //check
                }
                else
                {
                    psi = 0; //nao check
                }

                //coluna checkbox con
                int con;
                if (CheckBox6.Checked)
                {
                    con = 1; //check   
                }
                else
                {
                    con = 0; //nao check
                }

                //coluna checkbox med
                int med;
                if (CheckBox7.Checked)
                {
                    med = 1; //check
                }
                else
                {
                    med = 0; //nao check
                }

                //coluna checkbox pos
                int pos;
                if (CheckBox8.Checked)
                {
                    pos = 1; //check
                }
                else
                {
                    pos = 0; //nao check
                }

                //coluna checkbox comitê de ética
                int comEtica;
                if (CheckBox9.Checked)
                {
                    comEtica = 1; //check
                }
                else
                {
                    comEtica = 0; //nao check
                }

                //coluna checkbox disciplinas digitais
                int disDigitais;
                if (CheckBox10.Checked)
                {
                    disDigitais = 1; //check
                }
                else
                {
                    disDigitais = 0; //nao check
                }

                //coluna checkbox bioenergia
                int bio;
                if (CheckBox11.Checked)
                {
                    bio = 1; //check
                }
                else
                {
                    bio = 0; //nao check
                }

                //coluna checkbox nqa
                int nqa;
                if (CheckBox12.Checked)
                {
                    nqa = 1; //check
                }
                else
                {
                    nqa = 0; //nao check
                }
            }

            Panel1.Visible = true;
            form1.Visible = false;
        }

        protected void btnEnvia_Click(object sender, EventArgs e)
        {
            capturaDados();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* metodo para evitar o erro de runat não esta executando no server */
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Tabela.xls");
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("Windows-1252");
            Response.Charset = "ISO-8859-1";
            Response.ContentType = "application/vnd.ms-excel";

            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                GridView1.AllowPaging = false;
                this.getDados_();

                GridView1.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        [Obsolete]
        protected void btnPDF_Click(object sender, EventArgs e)
        {
            //necessario instalar biblioteca iTextSharp

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Tabela.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            GridView1.AllowPaging = false;
            GridView1.HeaderRow.Style.Add("width", "5%");
            GridView1.HeaderRow.Style.Add("font-size", "8px");
            GridView1.Style.Add("font-size", "8px");
            GridView1.HeaderRow.Style.Add("text-align", "center");

            foreach (GridViewRow row in GridView1.Rows)
            {
                int i = row.DataItemIndex;
                CheckBox CheckBox0 = (CheckBox)row.FindControl("CheckBox0"); //pub
                if (CheckBox0.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[5].Text = "X";
                }
                CheckBox CheckBox1 = (CheckBox)row.FindControl("CheckBox1"); //pub
                if (CheckBox1.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[6].Text = "X";
                }
                CheckBox CheckBox2 = (CheckBox)row.FindControl("CheckBox2"); //pub
                if (CheckBox2.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[7].Text = "X";
                }
                CheckBox CheckBox3 = (CheckBox)row.FindControl("CheckBox3"); //pub
                if (CheckBox3.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[8].Text = "X";
                }
                CheckBox CheckBox4 = (CheckBox)row.FindControl("CheckBox4"); //pub
                if (CheckBox4.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[9].Text = "X";
                }
                CheckBox CheckBox5 = (CheckBox)row.FindControl("CheckBox5"); //pub
                if (CheckBox5.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[10].Text = "X";
                }
                CheckBox CheckBox6 = (CheckBox)row.FindControl("CheckBox6"); //pub
                if (CheckBox6.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[11].Text = "X";
                }
                CheckBox CheckBox7 = (CheckBox)row.FindControl("CheckBox7"); //pub
                if (CheckBox7.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[12].Text = "X";
                }
                CheckBox CheckBox8 = (CheckBox)row.FindControl("CheckBox8"); //pub
                if (CheckBox8.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[13].Text = "X";
                }
                CheckBox CheckBox9 = (CheckBox)row.FindControl("CheckBox9"); //pub
                if (CheckBox9.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[14].Text = "X";
                }
                CheckBox CheckBox10 = (CheckBox)row.FindControl("CheckBox10"); //pub
                if (CheckBox10.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[15].Text = "X";
                }
                CheckBox CheckBox11 = (CheckBox)row.FindControl("CheckBox11"); //pub
                if (CheckBox11.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[16].Text = "X";
                }
                CheckBox CheckBox12 = (CheckBox)row.FindControl("CheckBox12"); //pub
                if (CheckBox12.Checked)
                {
                    GridView1.Rows[row.DataItemIndex].Cells[17].Text = "X";
                }
            }

            for (int i = 0; i <= 17; i++)
            {
                GridView1.Columns[i].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns[i].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            }

            GridView1.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());
            Document document = new Document(new RectangleReadOnly(900, 600), 30f, 30f, 10f, 10f);
            document.SetMargins(5, 5, 10, 10);
            document.AddCreationDate();
            HTMLWorker htmlparser = new HTMLWorker(document);
            PdfWriter.GetInstance(document, Response.OutputStream);

            document.Open();
            htmlparser.Parse(sr);
            document.Close();

            Response.Write(document);
            Response.End();
        }
    }
}