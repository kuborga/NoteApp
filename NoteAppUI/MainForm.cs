using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NoteApp;
using Enum = System.Enum;

namespace NoteAppUI
{
    public partial class MainForm : Form
    {
        Project project = ProjectManager.LoadFromFile(ProjectManager.FileName);
        public MainForm()
        {
            InitializeComponent();

          
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }



        /// <summary>
        /// Обработка события нажатия на кнопку Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
     

        
    }
}
