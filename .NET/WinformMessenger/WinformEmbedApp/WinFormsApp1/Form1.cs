
namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            double[] dataX = GetRandomNum(20).Distinct().OrderByDescending(x => x).ToArray();
            double[] dataY = GetRandomNum(19).Distinct().OrderByDescending(x => x).ToArray();
            formsPlot1.Plot.Add.Scatter(dataX, dataY);
        }

        private double[] GetRandomNum(int length)
        {
            double[] getDate = new double[length];
            Random random = new Random(); //创建一个Random实例
            for (int i = 0; i < length; i++)
            {
                getDate[i] = random.Next(1, 100); //使用同一个Random实例生成随机数
            }
            return getDate;
        }
    }
}
