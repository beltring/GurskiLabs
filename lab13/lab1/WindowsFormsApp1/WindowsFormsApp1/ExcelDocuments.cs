using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApp1
{
    class ExcelDocuments
    {
        private string method, data;
        private Form1 form;

        public ExcelDocuments(Form1 form)
        {
            this.form = form;
        }

        public string Method { get => method; set => method = value; }
        public string Data { get => data; set => data = value; }

        public void SaveData()
        {
            // Получить объект приложения Excel.
            Excel.Application excel_app = new Excel.Application();

            // Сделать Excel видимым.
            excel_app.Visible = true;

            // Откройте книгу.
            Excel.Workbook workbook = excel_app.Workbooks.Add();

            // Посмотрим, существует ли рабочий лист.
            string sheet_name = DateTime.Now.ToString("MM -dd-yy");

            Excel.Worksheet sheet = FindSheet(workbook, sheet_name);

            if (sheet == null)
            {
                // Добавить лист в конце.
                sheet = (Excel.Worksheet)workbook.Sheets.Add(
                    Type.Missing, workbook.Sheets[workbook.Sheets.Count],
                    1, Excel.XlSheetType.xlWorksheet);
                sheet.Name = DateTime.Now.ToString("MM-dd-yy");
            }

            sheet.Shapes.AddPicture(@"d:\Study\COURSE_TWO\visual enviroment\4sem\labs\lab13\lab1\WindowsFormsApp1\WindowsFormsApp1\Resources\Chart.jpeg",
                MsoTriState.msoFalse, MsoTriState.msoCTrue, 200, 20, 400, 200);

            // Добавить некоторые данные в отдельные ячейки.
            sheet.Cells[1, 1] = "a";
            sheet.Cells[1, 2] = "b";
            sheet.Cells[1, 3] = "step";
            sheet.Cells[1, 4] = "result";

            Excel.Range res = sheet.get_Range("E1");
            res.Font.Bold = true;
            // Делаем этот диапазон ячеек жирным и красным.
            Excel.Range header_range = sheet.get_Range("A1", "D1");
            header_range.Font.Bold = true;
            header_range.Font.Color =
                System.Drawing.ColorTranslator.ToOle(
                    System.Drawing.Color.Black);
            header_range.Interior.Color =
                System.Drawing.ColorTranslator.ToOle(
                    System.Drawing.Color.BlueViolet);

            sheet.Cells[2, 1] = form.textBox1.Text;
            sheet.Cells[2, 2] = form.textBox2.Text;
            sheet.Cells[2, 3] = form.textBox3.Text;
            double result = Convert.ToDouble(form.label6.Text);
            //string formatted = String.Format("{0:F6}", result);
            string text = result.ToString().Substring(0, result.ToString().Length - 8).Insert(1,",");
            sheet.Cells[2, 4] = text;

            MethodDef();
            sheet.Cells[1, 5] = method;
            // Сохраните изменения и закройте книгу.
            workbook.Close(true, Type.Missing, Type.Missing);

            // Закройте сервер Excel.
            excel_app.Quit();
        }

        private static Excel.Worksheet FindSheet(Excel.Workbook workbook, string sheet_name)
        {
            foreach (Excel.Worksheet sheet in workbook.Sheets)
            {
                if (sheet.Name == sheet_name) return sheet;
            }

            return null;
        }

        private void MethodDef()
        {
            if (form.radioButton1.Checked == true)
            {
                method = "Метод трапеций";
            }
            else if (form.radioButton2.Checked == true)
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
