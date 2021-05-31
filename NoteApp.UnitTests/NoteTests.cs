using System;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {

        /// <summary>
        /// Переменная, хранящая время создания заметки
        /// </summary>
        private readonly DateTime _createdDate = new DateTime(2021, 05, 31, 12, 00, 00);

        /// <summary>
        /// Переменная, хранящая время изменения заметки
        /// </summary>
        private readonly DateTime _modifiedDate = new DateTime(2021, 05, 31, 12, 05, 00);

        /// <summary>
        /// Метод создает один экземпляр заметки
        /// </summary>
        public Note GetOriginalNote()
        {
            var originalNote = new Note
            {
                Title = "Заметка №1 для теста",
                Category = NoteCategory.Home,
                Text = "Какой-то текст заметки",
                CreatedDate = _createdDate,
                ModifiedDate = _modifiedDate
            };

            return originalNote;
        }

        [Test(Description = "Позитивный тест геттера Title")]
        public void Title_GetCorrectValue()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = "Заметка №1 для теста";

            //Act
            var actual = originalNote.Title;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест сеттера Title")]
        public void Title_SetCorrectValue()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = originalNote.Title;

            //Act
            originalNote.Title = expected;
            var actual = originalNote.Title;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Title с пустым значением")]
        public void Title_SetEmptyValue()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = "Untitled";

            //Act
            originalNote.Title = "";
            var actual = originalNote.Title;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Title с длиной значения" +
                           "поля, превышающего 50 символов")]
        public void Title_SetTooLongValue()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var source = "Какой-то текст заметки" +
                         "Какой-то текст заметки" +
                         "Какой-то текст заметки";

            //Assert
            Assert.Throws<ArgumentException>(
                () =>
                {
                    // Act
                    originalNote.Title = source;
                });
        }

        [Test(Description = "Тест геттера Category")]
        public void Category_GetCorrectCategory()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = NoteCategory.Home;

            //Act
            var actual = originalNote.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Category")]
        public void Category_SetCorrectValue()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = originalNote.Category;

            //Act
            originalNote.Category = expected;
            var actual = originalNote.Category;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера Text")]
        public void Text_GetCorrectText()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = "Какой-то текст заметки";

            //Act
            var actual = originalNote.Text;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера Text")]
        public void Text_SetCorrectValue()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = originalNote.Text;

            //Act
            originalNote.Text = expected;
            var actual = originalNote.Text;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера CreatedDate")]
        public void IsCreated_GetCorrectCreatedTime()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = _createdDate;

            //Act
            var actual = originalNote.CreatedDate;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера CreatedDate")]
        public void IsCreated_SetCorrectCreatedTime()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = originalNote.CreatedDate;

            //Act
            originalNote.CreatedDate = expected;
            var actual = originalNote.CreatedDate;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест геттера ModifiedDate")]
        public void IsChanged_GetCorrectChangedTime()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = _modifiedDate;

            //Act
            var actual = originalNote.ModifiedDate;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Тест сеттера ModifiedDate")]
        public void IsChanged_SetCorrectChangedTime()
        {
            //Setup
            var originalNote = GetOriginalNote();
            var expected = originalNote.ModifiedDate;

            //Act
            originalNote.ModifiedDate = expected;
            var actual = originalNote.ModifiedDate;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [Test(Description = "Позитивный тест стандартного конструктора класса Note")]
        public void NoteConstructor_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var expectedTitle = "Untitled";
            string expectedText = null;
            var expectedCategory = NoteCategory.Other;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;

            Note _note = new Note();
            //Act
            var actual = _note;

            //Assert
            Assert.AreEqual(expectedTitle, actual.Title,
                "Стандартный конструктор возвращает неправильное имя заметки");
            Assert.AreEqual(expectedText, actual.Text,
                "Стандартный конструктор возвращает неправильный текст заметки");
            Assert.AreEqual(expectedCategory, actual.Category,
                "Стандартный конструктор возвращает неправильную категорию заметки");
            Assert.AreEqual(expectedCreated.Minute, actual.CreatedDate.Minute,
                "Стандартный конструктор возвращает неправильное время создания заметки");
            Assert.AreEqual(expectedModified.Minute, actual.ModifiedDate.Minute,
                "Стандартный конструктор возвращает неправильное время" +
                 "последнего редактирования заметки");
        }

        [Test(Description = "Позитивный тест Json конструктора класса Note")]
        public void NoteJsoneConstructor_CorrectValue_ReturnsSameValue()
        {
            //Setup 
            var expectedTitle = "TestTitle";
            var expectedText = "TestText";
            var expectedCategory = NoteCategory.Finance;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;

            //Act
            var actual = new Note(expectedTitle, expectedCategory, expectedText,
            expectedCreated, expectedModified);

            //Assert
            Assert.AreEqual(expectedTitle, actual.Title,
                "Json конструктор возвращает неправильное имя заметки");
            Assert.AreEqual(expectedText, actual.Text,
                "Json конструктор возвращает неправильный текст заметки");
            Assert.AreEqual(expectedCategory, actual.Category,
                "Json конструктор возвращает неправильную категорию заметки");
            Assert.AreEqual(expectedCreated.Minute, actual.CreatedDate.Minute,
                "Json конструктор возвращает неправильное время создания заметки");
            Assert.AreEqual(expectedModified.Minute, actual.ModifiedDate.Minute,
                "Json конструктор возвращает неправильное время" +
                 "последнего редактирования заметки");
        }

        [Test(Description = "Позитивный тест метода Clone")]
        public void Clone_CorrectValue_ReturnsSameValue()
        {
            Note _note = new Note();
            //Setup 
            Note expected = _note;

            //Act
            var actual = (Note)_note.Clone();

            //Assert
            Assert.AreEqual(expected.Title, actual.Title, "Метод Clone устанавливает " +
            "неправильное значение Title");
            Assert.AreEqual(expected.Text, actual.Text, "Метод Clone устанавливает " +
           "неправильное значение Text");
            Assert.AreEqual(expected.Category, actual.Category, "Метод Clone устанавливает " +
           "неправильное значение Category");
            Assert.AreEqual(expected.CreatedDate, actual.CreatedDate, "Метод Clone устанавливает " +
           "неправильное значение Created");
            Assert.AreEqual(expected.ModifiedDate, actual.ModifiedDate, "Метод Clone устанавливает " +
           "неправильное значение Modified");
        }
    }
}
