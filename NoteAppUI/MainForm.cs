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
        private Project _project = new Project();
        private Note _note = new Note();

        public MainForm()
        {
            InitializeComponent();

            //Источником данных для списка является перечисление категория заметки
            comboBox1.DataSource = Enum.GetValues(typeof(NoteCategory));
            label1.Text = "";

            //Отображение времени создания и изменения заметки
            textBox3.Text = "";
            textBox4.Text = "";

            //Добавляем созданный объект в конец списка Notes
            _project.Notes.Add(_note);
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
            //Заносится название заметки
            try
            {
                _note.Title = textBox1.Text;
                label1.Text = "";
            }
            catch (ArgumentException exception)
            {
                label1.Text = exception.Message;
                label1.ForeColor = Color.Red;
            }

            //Заносится содержимое заметки
            _note.Text = textBox2.Text;

            //Меняет значение категории заметки
            _note.Category = (NoteCategory)Enum.Parse(typeof(NoteCategory), comboBox1.Text);

            //Время создания появляется
            textBox3.Text = _note.IsCreated.ToLongTimeString();

            //Время последнего изменения обновляется
            textBox4.Text = _note.IsChanged.ToLongTimeString();

            //Сохранение файла
            ProjectManager.SaveToFile(_project, ProjectManager.FileName);
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
                _project = ProjectManager.LoadFromFile(ProjectManager.FileName);

                _note = _project.Notes[0];

                comboBox1.SelectedItem = _note.Category;

                textBox1.Text = _note.Title;
                textBox2.Text = _note.Text;
                textBox3.Text = _note.IsCreated.ToLongTimeString();
                textBox4.Text = _note.IsChanged.ToLongTimeString();
            }
            catch (Exception exception)
            {
                label1.Text = exception.Message;
                label1.ForeColor = Color.Red;
            }
        }

    }
}
