using System;
using NUnit.Framework;

namespace NoteApp.UnitTests
{
    [TestFixture]
    public class NoteTests
    {
        /// <summary>
        /// Экземпляр класса <see cref="Note"/> для проведения тестов
        /// </summary>
        private Note _note;

        /// <summary>
        /// Метод создания пустой заметки
        /// </summary>
        public Note Note_Init()
        {
            _note = new Note();
            return _note;
        }

        [Test(Description = "Позитивный тест геттера и сеттера Title")]
        public void Title_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = "Test title for note";

            //Act
            note.Title = expected;
            var actual = note.Title;

            //Assert
            Assert.AreEqual(actual, expected,
                "Геттер или сеттер Title возвращает неправильный текст");
        }

        [Test(Description = "Присвоение слишком большого значения Title: " +
            "больше 50 символов")]
        public void Title_TooLongTitle_ThrowsException()
        {
            //Setup
            var note = Note_Init();

            //Act
            var wrongTitle = "Title_2021Title_2021Title_2021Title_2021Title_2021Title";

            //Assert
            Assert.Throws<ArgumentException>(
                () => { note.Title = wrongTitle; },
                    "Должно возникать исключение, если название длиннее 50 символов");
        }

        [Test(Description = "Присвоение пустой строки в качестве Title." +
            "Должно быть заменено на Без названия")]
        public void Title_EmptyString_ReturnsUntitled()
        {
            //Setup
            var note = Note_Init();
            var expected = "Untitled";

            //Act
            note.Title = "";
            var actual = note.Title;

            //Assert
            Assert.AreEqual(actual, expected,
                "Сеттер устанавливает неправильное название заметки");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Category")]
        public void Category_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = NoteCategory.Home;

            //Act
            note.Category = expected;
            var actual = note.Category;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Category возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Text")]
        public void Text_CorrectValue_ReturnsSameValue()
        {
            //Setup - инициализация заметки вынесена в атрибут [SetUp]
            var note = Note_Init();
            var expected = "Good weather";

            //Act
            note.Text = expected;
            var actual = note.Text;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Text возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Created")]
        public void Created_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = DateTime.Now;

            //Act
            var actual = note.CreatedDate;

            //Assert
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Created возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Modified")]
        public void Modified_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expected = DateTime.Now;

            //Act
            var actual = note.ModifiedDate;

            //Assert
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Modified возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест стандартного конструктора класса Note")]
        public void NoteConstructor_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expectedTitle = "Untitled";
            string expectedText = null;
            var expectedCategory = NoteCategory.Other;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;

            //Act
            var actual = note;

            //Assert
            Assert.Multiple(() =>
            {
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
            });
        }

        [Test(Description = "Позитивный тест Json конструктора класса Note")]
        public void NoteJsoneConstructor_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            var expectedTitle = "TestTitle";
            var expectedText = "TestText";
            var expectedCategory = NoteCategory.Job;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;


            //Act
            var actual = new Note(expectedTitle, expectedCategory, expectedText,
            expectedCreated, expectedModified);

            //Assert
            Assert.Multiple(() =>
            {
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
            });
        }

        [Test(Description = "Позитивный тест конструктора с пользовательким значением времени")]
        public void NoteTestConstructor_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var expectedTitle = "Untitled";
            string expectedText = null;
            var expectedCategory = NoteCategory.Other;
            var expectedCreated = new DateTime(2021, 01, 01);
            var expectedModified = expectedCreated;

            //Act
            var actual = new Note(new DateTime(2021, 01, 01));

            //Assert
            Assert.Multiple(() =>
            {
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
             });
        }

        [Test(Description = "Позитивный тест метода Clone")]
        public void Clone_CorrectValue_ReturnsSameValue()
        {
            //Setup
            var note = Note_Init();
            Note expected = note;

            //Act
            var actual = (Note)note.Clone();

            //Assert
            Assert.Multiple(() =>
            {
                 Assert.AreEqual(expected.Title, actual.Title, "Метод Clone устанавливает " +
                 "неправильное значение Title");
                 Assert.AreEqual(expected.Text, actual.Text, "Метод Clone устанавливает " +
                "неправильное значение Text");
                 Assert.AreEqual(expected.Category, actual.Category, "Метод Clone устанавливает " +
                "неправильное значение Category");
                 Assert.AreEqual(expected.CreatedDate, actual.CreatedDate, "Метод Clone устанавливает " +
                "неправильное значение Created");
                 Assert.AreEqual(expected.ModifiedDate, actual.ModifiedDate, "Метод Clone устанавливает " +
                " неправильное значение Modified");
            });


        }


}
}
