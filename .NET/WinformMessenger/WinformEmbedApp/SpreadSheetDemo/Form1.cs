using unvell.ReoGrid.IO;
using unvell.ReoGrid;

namespace SpreadSheetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            var xlsFilePath = Path.Combine(Environment.CurrentDirectory, "CommonConfigTest.xls");
            //using var stream = new FileStream(xlsFilePath, FileMode.Open, FileAccess.ReadWrite);
            //var workbook = reoGridControl1.CreateWorksheet();
            //workbook.Save(stream, FileFormat.Excel2007);

            reoGridControl1.Load(xlsFilePath, unvell.ReoGrid.IO.FileFormat.Excel2007);
        }
    }
}
