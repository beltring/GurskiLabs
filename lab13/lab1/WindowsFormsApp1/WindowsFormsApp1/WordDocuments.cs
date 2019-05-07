using System;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    class WordDocuments
    {
        private string method, data;
        private Form1 form;

        public WordDocuments(Form1 form)
        {
            this.form = form;
        }

        public string Method { get => method; set => method = value; }
        public string Data { get => data; set => data = value; }

        public void SaveData()
        {

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";
            object picture = "\\picture";

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);

            MethodDef();
            oDoc.Range().FormattedText.Font.Bold = 30;
            oDoc.Range().Text = method;
            

            Word.Table oTable;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            
            oTable = oDoc.Tables.Add(wrdRng,  2, 4, ref oMissing, ref oMissing);
            oTable.Range.ParagraphFormat.SpaceAfter = 6;
            oTable.Borders.Enable = 5;

            oTable.Cell(1, 1).Range.Text = "a";
            oTable.Cell(1, 2).Range.Text = "b";
            oTable.Cell(1, 3).Range.Text = "step";
            oTable.Cell(1, 4).Range.Text = "result";

            oTable.Cell(2, 1).Range.Text = form.textBox1.Text;
            oTable.Cell(2, 2).Range.Text = form.textBox2.Text;
            oTable.Cell(2, 3).Range.Text = form.textBox3.Text;
            oTable.Cell(2, 4).Range.Text = form.label6.Text;

            oTable.Rows[1].Range.Font.Bold = 1;
            oTable.Rows[1].Range.Font.Italic = 1;

            oDoc.Shapes.AddPicture(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab13\lab1\WindowsFormsApp1\WindowsFormsApp1\Resources\Chart.jpeg",
                    false, true, Type.Missing, 80, 450, 200, Type.Missing);
        }

        private void MethodDef()
        {
            if(form.radioButton1.Checked == true)
            {
                method = "Метод трапеций";
            }
            else if(form.radioButton2.Checked == true)
            {
                method = "Метод левых прямоугольников";
            }
            else if (form.radioButton3.Checked == true)
            {
                method = "Метод правых прямоугольников";
            }
            else if (form.radioButton4.Checked == true)
            {
                method = "Метод средних прямоугольников";
            }
        }
    }
}
