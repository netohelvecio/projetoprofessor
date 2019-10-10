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

            DataRow data = dt.NewRow();
            data["categoria"] = "Agência de publicidade";

            DataRow data2 = dt.NewRow();
            data2["categoria"] = "Clínica de Psicologia";

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

                Label labelQTDE = (Label)gridView.FindControl("LabelQTDE");
                Label LabelRegraCalc = (Label)gridView.FindControl("LabelRegraCalc");
                Label LabelCC = (Label)gridView.FindControl("LabelCC");

                TextBox TextBoxCC = (TextBox)gridView.FindControl("TextBoxCC");

                int check = 0;

                //coluna checkbox pub
                int pub;
                if (CheckBox0.Checked)
                {
                    pub = 1; //check
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
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
                    check += 1;
                }
                else
                {
                    nqa = 0; //nao check
                }

                if (check > 1)
                {
                    LabelRegraCalc.Text = "CH Proporcional";
                }
                else if (check == 0)
                {
                    LabelRegraCalc.Text = "";
                }
                else
                {
                    LabelRegraCalc.Text = "Único Curso";
                }

                if (TextBoxCC.Text == "")
                {
                    LabelCC.Text = "Não";
                }
                else
                {
                    LabelCC.Text = "Sim";
                }

                labelQTDE.Text = check.ToString();
            }
        }

        protected void btnEnvia_Click(object sender, EventArgs e)
        {
            capturaDados();
            Panel1.Visible = true;
            form1.Visible = false;
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

            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            this.getDados_();

            foreach (GridViewRow row in GridView1.Rows)
            {
                int i = row.DataItemIndex;
                CheckBox CheckBox0 = (CheckBox)row.FindControl("CheckBox0"); //pub
                if (CheckBox0.Checked)
                {
                    GridView1.Rows[i].Cells[5].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[5].Text = "";
                }
                CheckBox CheckBox1 = (CheckBox)row.FindControl("CheckBox1"); //pub
                if (CheckBox1.Checked)
                {
                    GridView1.Rows[i].Cells[6].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[6].Text = "";
                }
                CheckBox CheckBox2 = (CheckBox)row.FindControl("CheckBox2"); //pub
                if (CheckBox2.Checked)
                {
                    GridView1.Rows[i].Cells[7].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[7].Text = "";
                }
                CheckBox CheckBox3 = (CheckBox)row.FindControl("CheckBox3"); //pub
                if (CheckBox3.Checked)
                {
                    GridView1.Rows[i].Cells[8].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[8].Text = "";
                }
                CheckBox CheckBox4 = (CheckBox)row.FindControl("CheckBox4"); //pub
                if (CheckBox4.Checked)
                {
                    GridView1.Rows[i].Cells[9].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[9].Text = "";
                }
                CheckBox CheckBox5 = (CheckBox)row.FindControl("CheckBox5"); //pub
                if (CheckBox5.Checked)
                {
                    GridView1.Rows[i].Cells[10].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[10].Text = "";
                }
                CheckBox CheckBox6 = (CheckBox)row.FindControl("CheckBox6"); //pub
                if (CheckBox6.Checked)
                {
                    GridView1.Rows[i].Cells[11].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[11].Text = "";
                }
                CheckBox CheckBox7 = (CheckBox)row.FindControl("CheckBox7"); //pub
                if (CheckBox7.Checked)
                {
                    GridView1.Rows[i].Cells[12].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[12].Text = "";
                }
                CheckBox CheckBox8 = (CheckBox)row.FindControl("CheckBox8"); //pub
                if (CheckBox8.Checked)
                {
                    GridView1.Rows[i].Cells[13].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[13].Text = "";
                }
                CheckBox CheckBox9 = (CheckBox)row.FindControl("CheckBox9"); //pub
                if (CheckBox9.Checked)
                {
                    GridView1.Rows[i].Cells[14].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[14].Text = "";
                }
                CheckBox CheckBox10 = (CheckBox)row.FindControl("CheckBox10"); //pub
                if (CheckBox10.Checked)
                {
                    GridView1.Rows[i].Cells[15].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[15].Text = "";
                }
                CheckBox CheckBox11 = (CheckBox)row.FindControl("CheckBox11"); //pub
                if (CheckBox11.Checked)
                {
                    GridView1.Rows[i].Cells[16].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[16].Text = "";
                }
                CheckBox CheckBox12 = (CheckBox)row.FindControl("CheckBox12"); //pub
                if (CheckBox12.Checked)
                {
                    GridView1.Rows[i].Cells[17].Text = "x";
                }
                else
                {
                    GridView1.Rows[i].Cells[17].Text = "";
                }

                TextBox TextBoxCC = (TextBox)row.FindControl("TextBoxCC");
                if (TextBoxCC.Text == "")
                {
                    GridView1.Rows[i].Cells[4].Text = "S/N";
                }
                else
                {
                    GridView1.Rows[i].Cells[4].Text = TextBoxCC.Text;
                }

                Label LabelRegraCalc = (Label)row.FindControl("LabelRegraCalc");
                if (LabelRegraCalc.Text == "")
                {
                    LabelRegraCalc.Text = "Nenhum";
                }
            }

            GridView1.RenderControl(hw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
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
            GridView1.HeaderRow.Style.Add("width", "10%");
            GridView1.HeaderRow.Style.Add("font-size", "10px");
            GridView1.Style.Add("font-size", "10px");
            GridView1.HeaderRow.Style.Add("text-align", "center");

            foreach (GridViewRow row in GridView1.Rows)
            {
                int i = row.DataItemIndex;
                CheckBox CheckBox0 = (CheckBox)row.FindControl("CheckBox0"); //pub
                if (CheckBox0.Checked)
                {
                    GridView1.Rows[i].Cells[5].Text = "X";
                }
                CheckBox CheckBox1 = (CheckBox)row.FindControl("CheckBox1"); //pub
                if (CheckBox1.Checked)
                {
                    GridView1.Rows[i].Cells[6].Text = "X";
                }
                CheckBox CheckBox2 = (CheckBox)row.FindControl("CheckBox2"); //pub
                if (CheckBox2.Checked)
                {
                    GridView1.Rows[i].Cells[7].Text = "X";
                }
                CheckBox CheckBox3 = (CheckBox)row.FindControl("CheckBox3"); //pub
                if (CheckBox3.Checked)
                {
                    GridView1.Rows[i].Cells[8].Text = "X";
                }
                CheckBox CheckBox4 = (CheckBox)row.FindControl("CheckBox4"); //pub
                if (CheckBox4.Checked)
                {
                    GridView1.Rows[i].Cells[9].Text = "X";
                }
                CheckBox CheckBox5 = (CheckBox)row.FindControl("CheckBox5"); //pub
                if (CheckBox5.Checked)
                {
                    GridView1.Rows[i].Cells[10].Text = "X";
                }
                CheckBox CheckBox6 = (CheckBox)row.FindControl("CheckBox6"); //pub
                if (CheckBox6.Checked)
                {
                    GridView1.Rows[i].Cells[11].Text = "X";
                }
                CheckBox CheckBox7 = (CheckBox)row.FindControl("CheckBox7"); //pub
                if (CheckBox7.Checked)
                {
                    GridView1.Rows[i].Cells[12].Text = "X";
                }
                CheckBox CheckBox8 = (CheckBox)row.FindControl("CheckBox8"); //pub
                if (CheckBox8.Checked)
                {
                    GridView1.Rows[i].Cells[13].Text = "X";
                }
                CheckBox CheckBox9 = (CheckBox)row.FindControl("CheckBox9"); //pub
                if (CheckBox9.Checked)
                {
                    GridView1.Rows[i].Cells[14].Text = "X";
                }
                CheckBox CheckBox10 = (CheckBox)row.FindControl("CheckBox10"); //pub
                if (CheckBox10.Checked)
                {
                    GridView1.Rows[i].Cells[15].Text = "X";
                }
                CheckBox CheckBox11 = (CheckBox)row.FindControl("CheckBox11"); //pub
                if (CheckBox11.Checked)
                {
                    GridView1.Rows[i].Cells[16].Text = "X";
                }
                CheckBox CheckBox12 = (CheckBox)row.FindControl("CheckBox12"); //pub
                if (CheckBox12.Checked)
                {
                    GridView1.Rows[i].Cells[17].Text = "X";
                }

                Label LabelRegraCalc = (Label)row.FindControl("LabelRegraCalc");
                if (LabelRegraCalc.Text == "")
                {
                    LabelRegraCalc.Text = "Nenhum";
                }

                Label LabelCC2 = (Label)row.FindControl("LabelCC2");
                TextBox TextBoxCC = (TextBox)row.FindControl("TextBoxCC");
                if (TextBoxCC.Text != "")
                {
                    LabelCC2.Visible = true;
                    LabelCC2.Text = TextBoxCC.Text;
                }
                else
                {
                    LabelCC2.Visible = true;
                    LabelCC2.Text = "S/N";
                }
            }

            for (int i = 0; i <= 17; i++)
            {
                GridView1.Columns[i].ItemStyle.HorizontalAlign = HorizontalAlign.Center;
                GridView1.Columns[i].ItemStyle.VerticalAlign = VerticalAlign.Middle;
            }

            GridView1.RenderControl(hw);

            StringReader sr = new StringReader(sw.ToString());
            Document document = new Document(new RectangleReadOnly(1200, 600), 30f, 30f, 10f, 10f);
            document.SetMargins(5, 5, 30, 10);
            document.AddCreationDate();
            HTMLWorker htmlparser = new HTMLWorker(document);
            PdfWriter.GetInstance(document, Response.OutputStream);

            Font fonteTitulo = FontFactory.GetFont("Verdana", 28, iTextSharp.text.Font.BOLD);
            fonteTitulo.SetColor(0, 0, 0);
            Chunk titulo = new Chunk("Rateio", fonteTitulo);
            Phrase frase = new Phrase(titulo);
            Paragraph p = new Paragraph();
            p.Alignment = 1;
            p.SpacingAfter = 20;

            document.Open();
            p.Add(frase);
            document.Add(p);
            htmlparser.Parse(sr);
            document.Close();

            Response.Write(document);
            Response.End();
        }

        protected void checkboxVerifica(object sender, EventArgs e)
        {
            capturaDados();
        }
    }
}