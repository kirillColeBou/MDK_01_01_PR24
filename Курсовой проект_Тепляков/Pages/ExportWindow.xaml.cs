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

        private void DialogExcel(string table, IEnumerable temp)
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            saveFileDialog.Filter = "Excel (*.xlsx)|*.xlsx";
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                if (temp != null)
                {
                    if (table == "parts")
                    {
                        if (temp is IEnumerable<ClassModules.Parts> parts)
                            ClassConnection.Connection.PartsExport(saveFileDialog.FileName, parts);
                        return;
                    }
                    else if (table == "locations")
                    {
                        if (temp is IEnumerable<ClassModules.Locations> locations)
                            ClassConnection.Connection.LocationsExport(saveFileDialog.FileName, locations);
                        return;
                    }
                    else if (table == "companies")
                    {
                        if (temp is IEnumerable<ClassModules.Companies> companies)
                            ClassConnection.Connection.CompaniesExport(saveFileDialog.FileName, companies);
                        return;
                    }
                    else if (table == "technique")
                    {
                        if (temp is IEnumerable<ClassModules.Technique> technique)
                            ClassConnection.Connection.TechniqueExport(saveFileDialog.FileName, technique);
                        return;
                    }
                    else  if (table == "typeOfTroops")
                    {
                        if (temp is IEnumerable<ClassModules.Type_of_troops> typeOfTroops)
                            ClassConnection.Connection.TypeOfTroopsExport(saveFileDialog.FileName, typeOfTroops);
                        return;
                    }
                    else if (table == "weapons")
                    {
                        if (temp is IEnumerable<ClassModules.Weapons> weapons)
                            ClassConnection.Connection.WeaponsExport(saveFileDialog.FileName, weapons);
                        return;
                    }
                }
            }
        }

        private void ExportAccept(object sender, MouseButtonEventArgs e)
        {
            if (PartsExport.IsChecked == true)
            {
                IEnumerable<ClassModules.Parts> parts = ClassConnection.Connection.parts;
                DialogExcel("parts", parts);
            }
            else if (LocationsExport.IsChecked == true)
            {
                IEnumerable<ClassModules.Locations> locations = ClassConnection.Connection.locations;
                DialogExcel("locations", locations);
            }
            else if (CompaniesExport.IsChecked == true)
            {
                IEnumerable<ClassModules.Companies> companies = ClassConnection.Connection.companies;
                DialogExcel("companies", companies);
            }
            else if (TechniqueExport.IsChecked == true)
            {
                IEnumerable<ClassModules.Technique> technique = ClassConnection.Connection.technique;
                DialogExcel("technique", technique);
            }
            else if (TypeOfTroopsExport.IsChecked == true)
            {
                IEnumerable<ClassModules.Type_of_troops> typeOfTroops = ClassConnection.Connection.type_of_troops;
                DialogExcel("typeOfTroops", typeOfTroops);
            }
            else if (WeaponsExport.IsChecked == true)
            {
                IEnumerable<ClassModules.Weapons> weapons = ClassConnection.Connection.weapons;
                DialogExcel("weapons", weapons);
            }
            this.Close();
        }
    }
}
