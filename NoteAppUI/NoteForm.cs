using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NoteApp;

namespace NoteAppUI
{
    /// <summary>
    /// Пользовательский интерфейс для создания и редактирования заметок
    /// </summary>
    public partial class NoteForm : Form
    {
        /// <summary>
        /// Поле для временного хранения переданных данных
        /// </summary>
        private Note _note;

        /// <summary>
        /// Возвращает или задает данные извне
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = value;
                RefreshNoteForm();
            }
        }


        /// <summary>
        /// Создаёт экземпляр формы <see cref="NoteForm">
        /// </summary>
        public NoteForm()
        {
            InitializeComponent();

            var categories = Enum.GetValues(typeof(NoteCategory)).Cast<object>().ToArray();
            CategoryComboBox.Items.AddRange(categories);
        }

        /// <summary>
        /// Выводит значения при загрузке данных
        /// </summary>
        private void RefreshNoteForm()
        {
            TitleTextBox.Text = _note.Title;
            CategoryComboBox.SelectedItem = _note.Category;
            CreatedDateTimePicker.Value = _note.CreatedDate;
            ModifiedDateTimePicker.Value = _note.ModifiedDate;
            MainTextBox.Text = _note.Text;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.BackColor == Color.LightSalmon)
            {
                MessageBox.Show("Note name is too large: more than 50 characters", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            _note.Text = MainTextBox.Text;
        }

        private void TitleTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                _note.Title = TitleTextBox.Text;

                TitleTextBox.BackColor = Color.White;
            }
            catch
            {
                TitleTextBox.BackColor = Color.LightSalmon;
            }
        }
    }
}
