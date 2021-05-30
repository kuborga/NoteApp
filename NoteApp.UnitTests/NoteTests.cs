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

        [SetUp]
        public void Note_Initi()
        {
            _note = new Note();
        }

        [Test(Description = "Позитивный тест сеттера и геттера Title")]
        public void Title_CorrectValue_ResultCorrectionValue()
        {
            //Setup
            var expected = "Test title for note";

            //Act
            _note.Title = expected;
            var actual = _note.Title;
            
            //Assert
            Assert.AreEqual(actual, expected,
                "Геттер или сеттер Title возвращает неправильный объект");
        }

        [Test(Description = "Присвоение слишком большого значения Title: " +
          "больше 50 символов")]
        public void Title_TooLongTitle_ThrowsException()
        {
            //Setup - инициализация заметки вынесена в атрибут [SetUp]

            //Act
            var wrongTitle = "Title2021Title2021Title2021Title2021Title2021Title2021Title2021Title2021Title2021";

            //Assert
            Assert.Throws<ArgumentException>(
                () => { _note.Title = wrongTitle; },
                    "Должно возникать исключение, если название длиннее 50 символов");
        }

        [Test(Description = "Тест сеттера Title c пустым значением")]
        public void Title_EmptyString_ReturnsUntitled()
        {
            //Setup
            var expected = "Untitled";

            //Act
            _note.Title = "";
            var actual = _note.Title;

            //Assert
            Assert.AreEqual(actual, expected,
                "Сеттер устанавливает неправильное название заметки");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Category")]
        public void Category_CorrectValue_ResultCorrectionValue()
        {
            //Setup - инициализация заметки вынесена в атрибут [SetUp]
            var expected = NoteCategory.Home;

            //Act
            _note.Category = expected;
            var actual = _note.Category;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Category возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Text")]
        public void Text_CorrectValue_ResultCorrectionValue()
        {
            //Setup
            var expected = "Notes #1";

            //Act
            _note.Text = expected;
            var actual = _note.Text;

            //Assert
            Assert.AreEqual(expected, actual,
                "Геттер или сеттер Text возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Created")]
        public void Created_CorrectValue_ResultCorrectionValue()
        {
            //Setup
            var expected = DateTime.Now;

            //Act
            var actual = _note.CreatedDate;

            //Assert
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Created возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест геттера и сеттера Modified")]
        public void Modified_CorrectValue_ResultCorrectionValue()
        {
            //Setup - инициализация заметки вынесена в атрибут [SetUp]
            var expected = DateTime.Now;

            //Act
            var actual = _note.ModifiedDate;

            //Assert
            Assert.AreEqual(expected.Minute, actual.Minute,
                "Геттер Modified возвращает неправильный объект");
        }

        [Test(Description = "Позитивный тест  конструктора класса Note")]
        public void NoteConstructor_CorrectValue_ResultCorrectionValue()
        {
            //Setup - инициализация заметки вынесена в атрибут [SetUp]
            var expectedTitle = "Untitled";
            string expectedText = null;
            var expectedCategory = NoteCategory.Other;
            var expectedCreated = DateTime.Now;
            var expectedModified = DateTime.Now;

            //Act - стандартный конструктор вызывается в атрибуте [SetUp]
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
            //Setup - инициализация заметки вынесена в атрибут [SetUp]
            var expectedTitle = "TestTitle1";
            var expectedText = "TestTextText";
            var expectedCategory = NoteCategory.Home;
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





    }
}
