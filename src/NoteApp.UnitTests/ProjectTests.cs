﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    class ProjectTests
    {
        /// <summary>
        /// Экземпляр класса <see cref="Note"/> для проведения тестов
        /// </summary>
        private Note _note;

        /// <summary>
        /// Экземпляр класса <see cref="Project"/> для проведения тестов
        /// </summary>
        private Project _project;

        /// <summary>
        /// Метод создания пустого проекта
        /// </summary>
        public Project Project_Init()
        {
            _project = new Project();
            return _project;
        }

        /// <summary>
        /// Метод создания пустой заметки
        /// </summary>
        public Note Note_Init()
        {
            _note = new Note();
            return _note;
        }

        [Test(Description = "Позитивный тест геттера и сеттера Notes")]
        public void Notes_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var expected = Note_Init();
            var project = Project_Init();

            //Act
            project.Notes.Add(_note);
            var actual = project.Notes[0];

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Notes возвращает неправильный " +
                "экземпляр класса Note");
        }

        [Test(Description = "Позитивный тест геттера и сеттера " +
            "SelectedNoteIndex")]
        public void SelectedNoteIndex_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var project = Project_Init();
            var expected = 20;

            //Act
            project.SelectedNoteIndex = 20;
            var actual = project.SelectedNoteIndex;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер SelectedNoteIndex возвращает " +
                "неправильное значение");
        }


        [Test(Description = "Позитивный тест метода Sort")]
        public void Sort_CorrectValue_ReturnsSortedList()
        {
            //Setup
            var project = Project_Init();
            InsertNote("FirstNote", project, NoteCategory.Other);
            InsertNote("SecondNote", project, NoteCategory.Other);
            InsertNote("ThirdNote", project, NoteCategory.Other);

            var secondProject = new Project();
            InsertNote("ThirdNote", secondProject, NoteCategory.Other);
            InsertNote("SecondNote", secondProject, NoteCategory.Other);
            InsertNote("FirstNote", secondProject, NoteCategory.Other);
            var expected = secondProject.Notes;

            //Act
            var actual = project.SortNotes(project.Notes);

            //Assert
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(expected[i].Title, actual[i].Title,
                    "Метод Sort возвращает Notes " +
                    "в неправильной последовательности");
            }
        }

        [Test(Description = "Позитивный тест метода Sort " +
            "с фильтром по конкретной категории")]
        public void CategorySort_CorrectValue_ReturnsSortedList()
        {
            //Setup
            var project = Project_Init();
            InsertNote("FirstNote", project, NoteCategory.Documents);
            InsertNote("SecondNote", project, NoteCategory.Job);
            InsertNote("ThirdNote", project, NoteCategory.Documents);

            var secondProject = new Project();
            InsertNote("ThirdNote", secondProject, NoteCategory.Documents);
            InsertNote("FirstNote", secondProject, NoteCategory.Documents);
            var expected = secondProject.Notes;

            //Act
            project.Notes = project.SortNotes(project.Notes, NoteCategory.Documents);
            var actual = project.Notes;

            //Assert
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i].Title, actual[i].Title,
                    "Метод Sort возвращает Notes " +
                    "в неправильной последовательности");
            }
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(expected[i].Category, actual[i].Category,
                    "Метод Sort возвращает Notes " +
                    "с неправильным значением категории");
            }
        }

        /// <summary>
        /// Вспомогательный метод заполнения списка
        /// </summary>
        /// <param name="testTitle"></param>
        /// <param name="tempProject"></param>
        private void InsertNote(string testTitle,
            Project testProject, NoteCategory testCategory)
        {
            // Делаем паузу между созданием заметок,
            //Чтобы корректно сравнить время
            System.Threading.Thread.Sleep(20);

            var testNote = new Note();
            testNote.Title = testTitle;
            testNote.Category = testCategory;
            testProject.Notes.Add(testNote);
        }
    }


}
