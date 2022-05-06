using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word_Eklenti.Properties;
using Word_Eklenti.Summarizer;
using wordeaktar = Microsoft.Office.Interop.Word;


namespace Word_Eklenti
{
    public partial class UserControl1 : UserControl
    {

        public UserControl1()
        {
            InitializeComponent();
        }
        

        public void seciliMetniPaneldeGoster(string seciliMetin)
        {
            this.textBox1.Text = seciliMetin;

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            
            textBox3.Text = new SimpleSummarizer().Summarize(textBox1.Text, Convert.ToInt32(textBox2.Text));

        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            textBox2.Text = "5";
         
        }

 
        private void button2_Click(object sender, EventArgs e)
        {
            wordeaktar.Application wordapp = new wordeaktar.Application(); //word uygulamasını açar
            wordapp.Visible = true;  // uygulama görünür hale gelir
            wordeaktar.Document worddoc;  // word dosyasına aktarılır
            object wordobj = System.Reflection.Missing.Value;
            worddoc = wordapp.Documents.Add(ref wordobj);
            wordapp.Selection.TypeText(textBox3.Text);
            wordapp = null;



        }

       
    }
}
