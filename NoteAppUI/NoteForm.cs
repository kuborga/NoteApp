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
        /// Копия класса Note.
        /// </summary>
        private Note _note;

        /// <summary>
        /// Возвращает или задает данные извне.
        /// Использует клон заметки.
        /// </summary>
        public Note Note
        {
            get
            {
                return _note;
            }
            set
            {
                _note = (Note)value.Clone();

                if (_note.Text == null)
                {
                    TitleTextBox.Text = "Untitled";
                    _note.Title = TitleTextBox.Text;
                    CreatedDateTimePicker.Text = DateTime.Now.ToLongDateString();
                    ModifiedDateTimePicker.Text = DateTime.Now.ToLongDateString();
                }

                TitleTextBox.Text = _note.Title;
                CategoryComboBox.SelectedItem = _note.Category;
                CreatedDateTimePicker.Value = _note.CreatedDate;
                ModifiedDateTimePicker.Value = _note.ModifiedDate;
                MainTextBox.Text = _note.Text;
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
        /// Событие вызывающееся при нажатии на кнопку OK.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Событие вызывающееся при выборе категории заметок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _note.Category = (NoteCategory)CategoryComboBox.SelectedItem;
        }

        /// <summary>
        /// Событие вызывающееся при нажатии на кнопку Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Событие вызывающееся при изменени в поле MainTextBox
        /// (Текста заметки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainTextBox_TextChanged(object sender, EventArgs e)
        {
            _note.Text = MainTextBox.Text;
        }

        /// <summary>
        /// Событие вызывающееся при изменени в поле TextBox
        /// (Заголовка заметки)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
