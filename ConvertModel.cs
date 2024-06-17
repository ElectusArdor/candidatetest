using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace candidatetest
{
    /// <summary>
    /// Конвертирует входные данные, сохраняя их в хранилище исходящих данных, передаваемое по ссылке.
    /// </summary>
    internal class ConvertModel : IConvertable
    {
        private Dictionary<string, int> types = new Dictionary<string, int>() { { "bool", 2 }, { "int", 4 }, { "double", 8 } };

        public void Convert(BindingList<InputData> dataIn, ref BindingList<OutputData> dataOut, Dictionary<string, Dictionary<string, string>> typeInfosDict)
        {
            foreach (var item in dataIn)
            {
                if (!item.IsSelected) continue;
                int offset = 0;
                foreach (var prop in typeInfosDict[item.Type])
                {
                    string tag = item.Tag + "." + prop.Key;
                    try
                    {
                        dataOut.Add(new OutputData(tag, offset));
                        offset += types[prop.Value];
                    }
                    catch (Exception ex)    {
                        MessageBox.Show(ex.Message, MainWindow.ProgramTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
    }
}
