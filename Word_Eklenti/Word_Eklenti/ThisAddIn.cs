using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Word = Microsoft.Office.Interop.Word;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Word;
using System.Windows.Forms;

namespace Word_Eklenti
{
    public partial class ThisAddIn_Startup
    {
        
        public UserControl1 myUserControl2 = null;
        public Microsoft.Office.Tools.CustomTaskPane myCustomTaskPane = null;

 

        private void ThisAddIn_Startup1(object sender, System.EventArgs e)
        {
            myUserControl2 = new UserControl1();
            myCustomTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(myUserControl2, "Özetleme Paneli");
            myCustomTaskPane.Width = 400;
            myCustomTaskPane.Visible = true;

        }

        private void ThisAddIn_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region VSTO generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisAddIn_Startup1);
            this.Shutdown += new System.EventHandler(ThisAddIn_Shutdown);
        }

        #endregion
    }
}
