using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.IO;

namespace candidatetest
{
    /// <summary>
    /// Преобразует строку Json в словарь.
    /// </summary>
    internal class JsonDeserializer
    {
        public Dictionary<string, Dictionary<string, string>> Deserialize(string path)
        {
            try
            {
                string jsonString = File.ReadAllText(path);
                var typeInfos = JObject.Parse(jsonString)["TypeInfos"].ToArray();
                Dictionary<string, Dictionary<string, string>> typeInfosDict = new Dictionary<string, Dictionary<string, string>>();
                foreach (var typeInfo in typeInfos)
                {
                    string typeName = typeInfo["TypeName"].ToString();
                    Dictionary<string, string> properties = typeInfo["Propertys"].ToObject<Dictionary<string, string>>();
                    typeInfosDict.Add(typeName, properties);
                }
                return typeInfosDict;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, MainWindow.ProgramTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }
    }
}
