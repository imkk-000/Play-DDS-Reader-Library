using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GDImageLibrary;
using System.Drawing.Imaging;

namespace Play_DDS_Reader_Library
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Yummy PC\Downloads\ygLight_4_0_6\Image\";
            //string[] dirs = { "ITEM", "MAP", "MUGONG", "SKILL" };
            //foreach (string dir in dirs)
            //{
            //MessageBox.Show(path + dir);
            //Convert(path, dir);
            //}
            Convert(path, @"ITEM\Random");
        }

        static void Convert(string path, string directoryName)
        {
            string outputPath = Path.Combine(Environment.CurrentDirectory, directoryName + "_PNG");
            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }
            DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(path, directoryName));
            foreach (var fileInfo in directoryInfo.GetFiles("*.d2s"))
            {
                try
                {
                    Bitmap bitmap = _DDS.LoadImage(fileInfo.FullName);
                    string resultPath = Path.Combine(outputPath, fileInfo.Name.ToLower().Replace(".d2s", ".png"));
                    bitmap.Save(resultPath, ImageFormat.Png);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
