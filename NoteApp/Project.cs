using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    /// <summary>
    /// Хранит список всех заметок.
    /// </summary>
   public class Project
    {
        /// <summary>
        /// Возвращает список текущих заметок.
        /// </summary>
        public List<Note> Notes { get; set; } = new List<Note>();

        /// <summary>
        /// Сортирует список заметок по дате последнего редактирования
        /// </summary>
        /// <param name="notes">Список заметок</param>
        /// <returns>Отсортированный по дате редактирования список заметок</returns>
        public List<Note> SortNotes(List<Note> notes)
        {
            var sortedNotes = notes.OrderByDescending(note => note.ModifiedDate).ToList();
            return sortedNotes;
        }

        /// <summary>
        /// Сортирует список заметок по дате редактирования, 
        /// оставляя заметки выбранный категории
        /// </summary>
        /// <param name="notes">Список заметок</param>
        /// <param name="category">Категория заметок</param>
        /// <returns>Отсортированный по дате редактирования 
        /// Список заметок конкретной категории</returns>
        public List<Note> SortNotes(List<Note> notes, NoteCategory category)
        {
            var categoryNotes = notes.Where(note => note.Category == category).ToList();
            var sortedNotes = categoryNotes.OrderByDescending(note => note.ModifiedDate).ToList();
            return sortedNotes;
        }
    }
}
