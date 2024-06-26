﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace candidatetest
{
    public partial class MainWindow : Window
    {
        public static string ProgramTitle { get; private set; }

        private BindingList<InputData> DataIn;
        private BindingList<OutputData> DataOut = new BindingList<OutputData>();
        private Dictionary<string, Dictionary<string, string>> TypeInfosDict;

        public MainWindow()
        {
            InitializeComponent();
            ProgramTitle = this.Title;
            TypeInfosDict = Deserialize(new JsonDeserializer());
            Menu.Width = SystemParameters.MaximizedPrimaryScreenWidth;
        }

        private Dictionary<string, Dictionary<string, string>> Deserialize(IDeserializable deserializer)
        {
            string path = Environment.CurrentDirectory + "\\TypeInfos.json";
            return deserializer.Deserialize(path);
        }

        private void ShowInputData(BindingList<InputData> data)
        {
            MainTable.ItemsSource = DataIn;
        }

        private void LoadFile(ILoadable loader)
        {
            DataIn = loader.Load();
            if (DataIn == null)
            {
                MessageBox.Show("Данные не загружены", MainWindow.ProgramTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            ShowInputData(DataIn);
        }

        /// <summary>
        /// Открывает окно выбора файла. Если файл выбран, начинает загрузку строк из файла в массив.
        /// </summary>
        private void OpenDialog(object sender, RoutedEventArgs e)
        {
            var dialogWindow = new Microsoft.Win32.OpenFileDialog();
            dialogWindow.InitialDirectory = Environment.CurrentDirectory;
            dialogWindow.Filter = "Файлы .csv|*.csv";
            bool? res = dialogWindow.ShowDialog();

            if (res == true)
            {
                LoadFile(new FileLoader(dialogWindow.FileName));
                ConvertButton.IsEnabled = true;
            }
        }

        private void ConvertStrings()
        {
            if (DataIn is null)
            {
                MessageBox.Show("Загрузите файл с данными", MainWindow.ProgramTitle, MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            ConvertModel cm = new ConvertModel();
            cm.Convert(DataIn, ref DataOut, TypeInfosDict);
        }

        private void ShowResult()        {
            ResTable.ItemsSource = DataOut;
        }

        private void ExportData(ISerializable serializer, string path)        {
            serializer.Serilize(DataOut, path);
        }

        private void SelectAll(object sender, RoutedEventArgs e)        {
            SetSelectionForAllItems(true);
        }

        private void DeselectAll(object sender, RoutedEventArgs e)        {
            SetSelectionForAllItems(false);
        }

        private void SaveResult(object sender, RoutedEventArgs e)
        {
            string path = Environment.CurrentDirectory + "\\result.xml";
            XmlSerializer serializer = new XmlSerializer();
            ExportData(serializer, path);
        }

        /// <summary>
        /// Выбирает/отменяет выбор всех элементов входящих данных
        /// </summary>
        /// <param name="b">true - выбрать всё, false - ничего</param>
        private void SetSelectionForAllItems(bool b)
        {
            if (DataIn is not null) foreach (var item in DataIn) item.IsSelected = b;
            MainTable.Items.Refresh();
        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            ConvertStrings();
            ShowResult();
        }

        private void Exit(object sender, RoutedEventArgs e)        {
            Application.Current.Shutdown();
        }
    }
}
