using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp
{
    /// <summary>
    /// Хранит список всех заметок
    /// </summary>
    class Project
    {
        /// <summary>
        /// Возвращает список текущих заметок
        /// </summary>
        public List<Note> Notes { get; private set; } = new List<Note>();
    }
}
