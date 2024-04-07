using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Курсовой_проект_Тепляков.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExportWindow.xaml
    /// </summary>
    public partial class ExportWindow : Window
    {
        public static ExportWindow export;
        public ExportWindow()
        {
            InitializeComponent();
            export = this;
        }

        private void ExportAccept(object sender, MouseButtonEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            string[] table = new string [6];
            if (saveFileDialog.FileName != "")
            {
                if (PartsExport.IsChecked == true) table[0] = "parts";
                if (LocationsExport.IsChecked == true) table[1] = "locations";
                if (CompaniesExport.IsChecked == true) table[2] = "companies";
                if (TechniqueExport.IsChecked == true) table[3] = "technique";
                if (TypeOfTroopsExport.IsChecked == true) table[4] = "typeOfTroops";
                if (WeaponsExport.IsChecked == true) table[5] = "weapons";
            }
            ClassConnection.Connection.Export(table, saveFileDialog.FileName);
            System.Windows.MessageBox.Show($"Экспорт выполнен.\nФайл находиться по пути: {saveFileDialog.FileName}.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            this.Close();
        }
    }
}
