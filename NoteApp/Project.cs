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
        public List<Note> Notes { get; private set; } = new List<Note>();

        /// <summary>
        /// Возвращает или задает индекс последней просматреваемой заметки
        /// </summary>
        public int SelectedNoteIndex { get; set; } = -1;

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
    }
}
