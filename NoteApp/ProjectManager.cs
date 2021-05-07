using System;
using System.IO;
using Newtonsoft.Json;

namespace NoteApp
{
    /// <summary>
    /// Класс менеджер проектов.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Название файла для сохранений и загрузки.
        /// </summary>
        public static readonly string FileName =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\Robkanov\NoteApp\NoteApp.txt";

        /// <summary>
        /// Сериализация (сохранение файла).
        /// </summary>
        /// <param name="project">сериализуемый объект</param>
        /// <param name="filename">Название файла</param>
        public static void SaveToFile(Project project, string filename)
        {
            //Создается экземпляр сериализатора
            var serializer = new JsonSerializer();

            if (!Directory.Exists(Path.GetDirectoryName(filename)))
            {
                var path = Path.GetDirectoryName(filename) ??
                           throw new InvalidOperationException();
                Directory.CreateDirectory(path);
            }

            //Открывается поток для записи в файл с указанием пути
            using (var writer = new StreamWriter(filename))
            {
                using (var textWriter = new JsonTextWriter(writer))
                {
                    //Вызывается сериализация и передается файл, 
                    //который нужно сериализовать
                    serializer.Serialize(textWriter, project);
                }
            }
        }

        /// <summary>
        /// Десериализация (загрузка файла).
        /// </summary>
        /// <param name="filename">Название файла</param>
        /// <returns></returns>
        public static Project LoadFromFile(string filename)
        {
            //Создается переменная, которая будет хранить
            //результат десериализации
            Project project;

            if (File.Exists(filename))
            {
                //Создается экземпляр сериализатора
                var serializer = new JsonSerializer();

                //Открывается поток для чтения из файла с указанием пути
                using (var reader = new StreamReader(filename))
                {
                    using (var textReader = new JsonTextReader(reader))
                    {
                        //Вызывается десериализация
                        //и явно преобразуется результат в целевой тип данных
                        project = serializer.Deserialize<Project>(textReader);

                        if (project == null)
                        {
                            return new Project();
                        }
                    }
                }
            }
            else
            {
                return new Project();
            }

            return project;
        }

    }
}
