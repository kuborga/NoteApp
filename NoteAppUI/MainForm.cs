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

            //Источником данных для списка является перечисление категория заметки
            comboBox1.DataSource = Enum.GetValues(typeof(NoteCategory));
            label1.Text = "";

            //Отображение времени создания и изменения заметки
            textBox3.Text = "";
            textBox4.Text = "";
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
           
            
        }

        /// <summary>
        /// Обработка события нажатия на кнопку Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Note note = new Note();
            //Заносится название заметки
            try
            {
                note.Title = textBox1.Text;
                label1.Text = "";
            }
            catch (ArgumentException exception)
            {
                label1.Text = exception.Message;
                label1.ForeColor = Color.Red;
            }

            //Заносится содержимое заметки
            note.Text = textBox2.Text;

            //Меняет значение категории заметки
            note.Category = (NoteCategory)Enum.Parse(typeof(NoteCategory), comboBox1.Text);

            //Время создания появляется
            textBox3.Text = note.CreatedDate.ToLongTimeString();

            //Время последнего изменения обновляется
            textBox4.Text = note.ModifiedDate.ToLongTimeString();
            project.Notes.Add(note);
            //Сохранение файла
            ProjectManager.SaveToFile(project, ProjectManager.FileName);
        }

        /// <summary>
        /// Обработка события нажатия на кнопку Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Загрузка из файла
                project = ProjectManager.LoadFromFile(ProjectManager.FileName);
                Note note = new Note();

                // Загрузка заметки №1
                note = project.Notes[0];

                comboBox1.SelectedItem = note.Category;

                textBox1.Text = note.Title;
                textBox2.Text = note.Text;
                textBox3.Text = note.CreatedDate.ToLongTimeString();
                textBox4.Text = note.ModifiedDate.ToLongTimeString();
            }
            catch (Exception exception)
            {
                label1.Text = exception.Message;
                label1.ForeColor = Color.Red;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
