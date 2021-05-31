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
        /// Возвращает путь по умолчанию
        /// </summary>
        public static  string  DefaultPath { get; private set; } =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\Robkanov\NoteApp\NoteApp.notes";

        /// <summary>
        /// Сериализация (сохранение файла).
        /// </summary>
        /// <param name="project">сериализуемый объект</param>
        /// <param name="filename">Название файла</param>
        public static void SaveToFile(Project project, string fileName)
        {
            //Если папка отсутствует - создать
            var folder = Path.GetDirectoryName(fileName);
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            //Сериализовать
            var serializer = new JsonSerializer();
            using (var sw = new StreamWriter(fileName))
            using (var writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, project);
            }
        }

        /// <summary>
        /// Десериализация (загрузка файла).
        /// </summary>
        /// <param name="filename">Название файла</param>
        /// <returns></returns>
        public static Project LoadFromFile(string filename)
        {
            var readProject = new Project();
            //Загрузить файл, если найден.
            // В противном случае вернуть пустой проект
            if (File.Exists(filename))
            {
                //Если файл поврежден,то возвращает пустой проект
                try
                {
                    var serializer = new JsonSerializer();
                    using (var sr = new StreamReader(filename))
                    using (var reader = new JsonTextReader(sr))
                    readProject = (Project)serializer.Deserialize<Project>(reader);
                }
                catch
                {
                    return new Project();
                }
                if (readProject != null)
                {
                    return readProject;
                }
            }
            return new Project();
        }
    }

    
}
