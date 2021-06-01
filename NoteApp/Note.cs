using System;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Хранит название,категорию и текст заметки,
    /// время создания и изменения заметки.
    /// </summary>
   public class Note
    {
        /// <summary>
        /// Название заметки.
        /// </summary>
        private string _title = "Untitled";

        /// <summary>
        /// Категория заметки.
        /// </summary>
        private NoteCategory _category = NoteCategory.Other;

        /// <summary>
        /// Текст заметки.
        /// </summary>
        private string _text;

        /// <summary>
        /// Возвращает или задает название заметки.
        /// Имя не больше 50 символов.
        /// </summary>
        public string Title
        {
            get => _title;

            set
            {
                if (value.Length > 50)
                {
                    throw new ArgumentException
                        ("Note name is too large: more than 50 characters");
                }
                else if (value == "")
                {
                    _title = "Untitled";
                    ModifiedDate = DateTime.Now;
                }
                else
                {
                    _title = value;
                    ModifiedDate = DateTime.Now;
                }
            }
        }

        ///<summary>
        ///Возвращает или задает категорию заметки.
        ///</summary>
        public NoteCategory Category
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                ModifiedDate = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает или задает текст заметки.
        /// </summary>
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                ModifiedDate = DateTime.Now;
            }
        }

        /// <summary>
        /// Возвращает  время создания заметки.
        /// </summary>
        public DateTime CreatedDate { get; private set; } = DateTime.Now;

        /// <summary>
        /// Возвращает или задает время последнего изменения.
        /// </summary>
        public DateTime ModifiedDate { get; private set; } = DateTime.Now;

        /// <summary>
        /// Конструктор класса Note.
        /// </summary>
        public Note()
        {

        }

        /// <summary>
        /// Конструктор класса Note для сериализации.
        /// </summary>
        /// <param name="title">Не более 50 символов</param>
        /// <param name="category"></param>
        /// <param name="text"></param>
        /// <param name="createdDate"></param>
        /// <param name="modifiedDate"></param>
        [JsonConstructor]
        public Note(string title, NoteCategory category, string text, DateTime createdDate, DateTime modifiedDate)
        {
            Title = title;
            Category = category;
            Text = text;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
        }

        /// <summary>
        /// Конструктор с пользовательскими значениями 
        /// даты создания и последнего редактирования.
        ///  Используется только для проведения тестов.
        /// </summary>
        /// <param name="testTime">Время создания</param>
        public Note(DateTime testTime)
        {
            CreatedDate = testTime;
            ModifiedDate = testTime;
        }

        /// <summary>
        /// Реализация интерфейса IClonable
        /// </summary>
        /// <returns>Клон заметки</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }

   
}
