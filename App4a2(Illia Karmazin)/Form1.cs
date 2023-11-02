namespace App4a2_Illia_Karmazin_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string sourceDirectory = textBox1.Text;
            string targetDirectory = textBox2.Text;
            string[] dirs = Directory.GetDirectories(sourceDirectory);
            foreach (string dir in dirs)
            {
                string sourceDirectory2 = "";
                int i = dir.Length - 1;
                for (; dir[i] != '\\'; --i) { }
                for (int j = i + 1; j < dir.Length; ++j)
                {
                    sourceDirectory2 += dir[j];
                }
                string[] files = Directory.GetFiles(dir);
                foreach (string file in files)
                {
                    DateTime creationTime = File.GetCreationTime(file);
                    string formattedCreationTime = creationTime.ToString("yyyyMMddHHmmss");
                    string fileName = formattedCreationTime + "_" + sourceDirectory2 + "_" + Path.GetFileName(file);
                    string targetPath = Path.Combine(targetDirectory, fileName);
                    File.Copy(file, targetPath);
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog2.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = folderBrowserDialog2.SelectedPath;
            }
        }
    }
}