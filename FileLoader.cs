using System.IO;
using System.Windows;
using System.ComponentModel;

namespace candidatetest
{
    internal class FileLoader : ILoadable
    {
        private string path;
        public string Path { get { return path; } }

        public FileLoader(string path)
        {
            this.path = path;
        }

        /// <summary>
        /// Загружает строки из файла и возвращает список объектов InputData
        /// </summary>
        public BindingList<InputData> Load() {
            BindingList<InputData> data = new BindingList<InputData>();
            string[] strings = File.ReadAllLines(path);
            SplitData(ref data, strings);
            return data;
        }

        /// <summary>
        /// Разделяет строки на 
        /// </summary>
        /// <param name="data">Хранилище, куда записываем полученные данные</param>
        /// <param name="strings">Исходный массив строк</param>
        /// <returns></returns>
        private BindingList<InputData> SplitData(ref BindingList<InputData> data, string[] strings)
        {
            try
            {
                for (int i = 0; i < strings.Length - 1; i++)
                {
                    string[] str = strings[i + 1].Split(';');
                    data.Add(new InputData(str[0], str[1]));
                }
                return data;
            }
            catch
            {
                MessageBox.Show("Кривой файл", MainWindow.ProgramTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }
    }
}
