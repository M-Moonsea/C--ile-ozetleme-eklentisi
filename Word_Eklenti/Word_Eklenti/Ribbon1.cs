using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Office.Tools.Ribbon;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Word;


//----</ Word Addin >----

namespace Word_Eklenti
{
    public partial class Ribbon1
    {


        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            
            Word.Document doc = Globals.ThisAddIn.Application.ActiveDocument;
            string selectText = string.Empty;  //selectext i boş string e atadık
            Word.Selection wordSelection = doc.Application.Selection;

            if (wordSelection != null && wordSelection.Range != null)
            {
                selectText = wordSelection.Text;

               Globals.ThisAddIn.myUserControl2.seciliMetniPaneldeGoster(selectText);

            }




            // seçilen metni panelde göster 

            // seçilen metnin özetini çıkart

            // özeti panelde göster

            // bir butonla özeti clipboaarda kopyala

        }

        

    }
}
