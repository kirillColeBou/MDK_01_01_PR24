using ClassModules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.ComponentModel;
using System.IO;
using OfficeOpenXml;
using Microsoft.Win32;

namespace ClassConnection
{
    public class Connection
    {
        #region Connection
        public static string Path_connection;
        #endregion

        #region All_Lists
        public static List<Companies> companies = new List<Companies>();
        public static List<Locations> locations = new List<Locations>();
        public static List<Parts> parts = new List<Parts>();
        public static List<Technique> technique = new List<Technique>();
        public static List<Type_of_troops> type_of_troops = new List<Type_of_troops>();
        public static List<Weapons> weapons = new List<Weapons>();
        public List<Users> users = new List<Users>();
        #endregion

        public enum Tables
        {
            companies, locations, parts, technique, type_of_troops, weapons, users
        }

        public bool Connect()
        {
            string Path = $@"Server=USER\SQLEXPRESS;Database=military_district;User Id=sa;Password=Asdfg123";
            //string Path = $@"Server=student.permaviat.ru;Database=base1_ISP_21_2_23;User Id=ISP_21_2_23;Password=3frQxZ83o#";
            SqlConnection connection = new SqlConnection(Path);
            try
            {
                connection.Open();
                Path_connection = Path;
                return true;
            }
            catch
            {
                return false;
            }
        }        

        public SqlDataReader Query(string query)
        {
            try
            {
                SqlConnection connect = new SqlConnection(Path_connection);
                connect.Open();
                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;
            }
        }

        public int SetLastId(Tables tables)
        {
            try
            {
                LoadData(tables);
                switch (tables.ToString())
                {
                    case "companies":
                        if (companies.Count >= 1)
                        {
                            int max_status = companies[0].Id_companies;
                            max_status = companies.Max(x => x.Id_companies);
                            return max_status + 1;
                        }
                        else return 1;
                    case "locations":
                        if (locations.Count >= 1)
                        {
                            int max_status = locations[0].Id_locations;
                            max_status = locations.Max(x => x.Id_locations);
                            return max_status + 1;
                        }
                        else return 1;
                    case "parts":
                        if (parts.Count >= 1)
                        {
                            int max_status = parts[0].Id_part;
                            max_status = parts.Max(x => x.Id_part);
                            return max_status + 1;
                        }
                        else return 1;
                    case "technique":
                        if (technique.Count >= 1)
                        {
                            int max_status = technique[0].Id_technique;
                            max_status = technique.Max(x => x.Id_technique);
                            return max_status + 1;
                        }
                        else return 1;
                    case "type_of_troops":
                        if (type_of_troops.Count >= 1)
                        {
                            int max_status = type_of_troops[0].Id_type_of_troops;
                            max_status = type_of_troops.Max(x => x.Id_type_of_troops);
                            return max_status + 1;
                        }
                        else return 1;
                    case "weapons":
                        if (weapons.Count >= 1)
                        {
                            int max_status = weapons[0].Id_weapons;
                            max_status = weapons.Max(x => x.Id_weapons);
                            return max_status + 1;
                        }
                        else return 1;
                    case "users":
                        if (users.Count >= 1)
                        {
                            int max_status = users[0].Id;
                            max_status = users.Max(x => x.Id);
                            return max_status + 1;
                        }
                        else return 1;
                }
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public void LoadData(Tables tables)
        {
            try
            {
                if (tables.ToString() == "companies")
                {
                    SqlDataReader itemsCompanies = Query("Select * From " + tables.ToString() + " Order By [Id_companies]");
                    companies.Clear();
                    while (itemsCompanies.Read())
                    {
                        Companies newCompanies = new Companies
                        {
                            Id_companies = Convert.ToInt32(itemsCompanies.GetValue(0)),
                            Name_companies = Convert.ToString(itemsCompanies.GetValue(1)),
                            Commander = Convert.ToString(itemsCompanies.GetValue(2)),
                            Date_foundation = Convert.ToDateTime(itemsCompanies.GetValue(3)),
                            Date_update_information = Convert.ToDateTime(itemsCompanies.GetValue(4))
                        };
                        companies.Add(newCompanies);
                    }
                    itemsCompanies.Close();
                }
                if (tables.ToString() == "locations")
                {
                    SqlDataReader itemsLocations = Query("Select * From " + tables.ToString() + " Order By [Id_locations]");
                    locations.Clear();
                    while (itemsLocations.Read())
                    {
                        Locations newLocations = new Locations
                        {
                            Id_locations = Convert.ToInt32(itemsLocations.GetValue(0)),
                            Country = Convert.ToString(itemsLocations.GetValue(1)),
                            City = Convert.ToString(itemsLocations.GetValue(2)),
                            Address = Convert.ToString(itemsLocations.GetValue(3)),
                            Square = Convert.ToInt32(itemsLocations.GetValue(4)),
                            Count_structures = Convert.ToInt32(itemsLocations.GetValue(5))
                        };
                        locations.Add(newLocations);
                    }
                    itemsLocations.Close();
                }
                if (tables.ToString() == "parts")
                {
                    SqlDataReader itemsParts = Query("Select * From " + tables.ToString() + " Order By [Id_part]");
                    parts.Clear();
                    while (itemsParts.Read())
                    {
                        Parts newParts = new Parts
                        {
                            Id_part = Convert.ToInt32(itemsParts.GetValue(0)),
                            Locations = Convert.ToInt32(itemsParts.GetValue(1)),
                            Type_of_troops = Convert.ToInt32(itemsParts.GetValue(2)),
                            Weapons = Convert.ToInt32(itemsParts.GetValue(3)),
                            Companies = Convert.ToInt32(itemsParts.GetValue(4)),
                            Count_companies = Convert.ToString(itemsParts.GetValue(5)),
                            Count_technique = Convert.ToString(itemsParts.GetValue(6)),
                            Count_weapons = Convert.ToString(itemsParts.GetValue(7)),
                            Date_of_foundation = Convert.ToDateTime(itemsParts.GetValue(8))
                        };
                        parts.Add(newParts);
                    }
                    itemsParts.Close();
                }
                if (tables.ToString() == "technique")
                {
                    SqlDataReader itemsTechnique = Query("Select * From " + tables.ToString() + " Order By [Id_technique]");
                    technique.Clear();
                    while (itemsTechnique.Read())
                    {
                        Technique newTechnique = new Technique
                        {
                            Id_technique = Convert.ToInt32(itemsTechnique.GetValue(0)),
                            Name_technique = Convert.ToString(itemsTechnique.GetValue(1)),
                            Parts = Convert.ToInt32(itemsTechnique.GetValue(2)),
                            Characteristics = Convert.ToString(itemsTechnique.GetValue(3))
                        };
                        technique.Add(newTechnique);
                    }
                    itemsTechnique.Close();
                }
                if (tables.ToString() == "type_of_troops")
                {
                    SqlDataReader itemsType_of_troops = Query("Select * From " + tables.ToString() + " Order By [Id_type_of_troops]");
                    type_of_troops.Clear();
                    while (itemsType_of_troops.Read())
                    {
                        Type_of_troops newType_of_troops = new Type_of_troops
                        {
                            Id_type_of_troops = Convert.ToInt32(itemsType_of_troops.GetValue(0)),
                            Name_type_of_troops = Convert.ToString(itemsType_of_troops.GetValue(1)),
                            Description = Convert.ToString(itemsType_of_troops.GetValue(2)),
                            Count_serviceman = Convert.ToInt32(itemsType_of_troops.GetValue(3)),
                            Date_foundation = Convert.ToDateTime(itemsType_of_troops.GetValue(4))
                        };
                        type_of_troops.Add(newType_of_troops);
                    }
                    itemsType_of_troops.Close();
                }
                if (tables.ToString() == "weapons")
                {
                    SqlDataReader itemsWeapons = Query("Select * From " + tables.ToString() + " Order By [Id_weapons]");
                    weapons.Clear();
                    while (itemsWeapons.Read())
                    {
                        Weapons newWeapons = new Weapons
                        {
                            Id_weapons = Convert.ToInt32(itemsWeapons.GetValue(0)),
                            Name_weapons = Convert.ToString(itemsWeapons.GetValue(1)),
                            Description = Convert.ToString(itemsWeapons.GetValue(2)),
                            Date_update_information = Convert.ToDateTime(itemsWeapons.GetValue(3))
                        };
                        weapons.Add(newWeapons);
                    }
                    itemsWeapons.Close();
                }
                if (tables.ToString() == "users")
                {
                    SqlDataReader itemsUsers = Query("Select * From " + tables.ToString() + " Order By [Id]");
                    users.Clear();
                    while (itemsUsers.Read())
                    {
                        Users newUsers = new Users
                        {
                            Id = Convert.ToInt32(itemsUsers.GetValue(0)),
                            Login = Convert.ToString(itemsUsers.GetValue(1)),
                            Password = Convert.ToString(itemsUsers.GetValue(2)),
                            Role = Convert.ToString(itemsUsers.GetValue(3))
                        };
                        users.Add(newUsers);
                    }
                    itemsUsers.Close();
                }
            }
            catch
            {
                Console.WriteLine("null");
            }
        }

        public static void Export(string[] nameTable, string filePath)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                if (nameTable[0] == "parts")
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Записи (части)");
                    worksheet.Cells[1, 1].Value = "Код части";
                    worksheet.Cells[1, 2].Value = "Место дислокации";
                    worksheet.Cells[1, 3].Value = "Вид войск";
                    worksheet.Cells[1, 4].Value = "Вооружение";
                    worksheet.Cells[1, 5].Value = "Рота";
                    worksheet.Cells[1, 6].Value = "Количество рот";
                    worksheet.Cells[1, 7].Value = "Количество техники";
                    worksheet.Cells[1, 8].Value = "Количество вооружений";
                    worksheet.Cells[1, 9].Value = "Дата основания";
                    int row = 2;
                    foreach (var record in parts)
                    {
                        worksheet.Cells[row, 1].Value = record.Id_part;
                        worksheet.Cells[row, 2].Value = locations.First(x => x.Id_locations == record.Locations).Country;
                        worksheet.Cells[row, 3].Value = type_of_troops.First(x => x.Id_type_of_troops == record.Type_of_troops).Name_type_of_troops;
                        worksheet.Cells[row, 4].Value = weapons.First(x => x.Id_weapons == record.Weapons).Name_weapons;
                        worksheet.Cells[row, 5].Value = companies.First(x => x.Id_companies == record.Companies).Name_companies;
                        worksheet.Cells[row, 6].Value = record.Count_companies;
                        worksheet.Cells[row, 7].Value = record.Count_technique;
                        worksheet.Cells[row, 8].Value = record.Count_weapons;
                        worksheet.Cells[row, 9].Value = record.Date_of_foundation.ToString("dd.MM.yyyy");
                        row++;
                    }
                }
                if (nameTable[1] == "locations")
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Записи (места дислокации)");
                    worksheet.Cells[1, 1].Value = "Код места дислокации";
                    worksheet.Cells[1, 2].Value = "Страна";
                    worksheet.Cells[1, 3].Value = "Город";
                    worksheet.Cells[1, 4].Value = "Адрес";
                    worksheet.Cells[1, 5].Value = "Занимаемая площадь";
                    worksheet.Cells[1, 6].Value = "Количество строений";
                    int row = 2;
                    foreach (var record in locations)
                    {
                        worksheet.Cells[row, 1].Value = record.Id_locations;
                        worksheet.Cells[row, 2].Value = record.Country;
                        worksheet.Cells[row, 3].Value = record.City;
                        worksheet.Cells[row, 4].Value = record.Address;
                        worksheet.Cells[row, 5].Value = record.Square;
                        worksheet.Cells[row, 6].Value = record.Count_structures;
                        row++;
                    }
                }
                if (nameTable[2] == "companies")
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Записи (роты)");
                    worksheet.Cells[1, 1].Value = "Код роты";
                    worksheet.Cells[1, 2].Value = "Название роты";
                    worksheet.Cells[1, 3].Value = "ФИО главнокомандующего";
                    worksheet.Cells[1, 4].Value = "Дата создания";
                    worksheet.Cells[1, 5].Value = "Дата обновления информации";
                    int row = 2;
                    foreach (var record in companies)
                    {
                        worksheet.Cells[row, 1].Value = record.Id_companies;
                        worksheet.Cells[row, 2].Value = record.Name_companies;
                        worksheet.Cells[row, 3].Value = record.Commander;
                        worksheet.Cells[row, 4].Value = record.Date_foundation.ToString("dd.MM.yyyy");
                        worksheet.Cells[row, 5].Value = record.Date_update_information.ToString("dd.MM.yyyy");
                        row++;
                    }
                }
                if (nameTable[3] == "technique")
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Записи (техника)");
                    worksheet.Cells[1, 1].Value = "Код техники";
                    worksheet.Cells[1, 2].Value = "Название техники";
                    worksheet.Cells[1, 3].Value = "Номер части";
                    worksheet.Cells[1, 4].Value = "Характеристики";
                    int row = 2;
                    foreach (var record in technique)
                    {
                        worksheet.Cells[row, 1].Value = record.Id_technique;
                        worksheet.Cells[row, 2].Value = record.Name_technique;
                        worksheet.Cells[row, 3].Value = parts.First(x => x.Id_part == record.Parts).Id_part;
                        worksheet.Cells[row, 4].Value = record.Characteristics;
                        row++;
                    }
                }
                if (nameTable[4] == "typeOfTroops")
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Записи (виды войск)");
                    worksheet.Cells[1, 1].Value = "Код вида войск";
                    worksheet.Cells[1, 2].Value = "Название вида войск";
                    worksheet.Cells[1, 3].Value = "Описание";
                    worksheet.Cells[1, 4].Value = "Количество военнослужащих";
                    worksheet.Cells[1, 5].Value = "Дата создания";
                    int row = 2;
                    foreach (var record in type_of_troops)
                    {
                        worksheet.Cells[row, 1].Value = record.Id_type_of_troops;
                        worksheet.Cells[row, 2].Value = record.Name_type_of_troops;
                        worksheet.Cells[row, 3].Value = record.Description;
                        worksheet.Cells[row, 4].Value = record.Count_serviceman;
                        worksheet.Cells[row, 5].Value = record.Date_foundation.ToString("dd.MM.yyyy");
                        row++;
                    }
                }
                if (nameTable[5] == "weapons")
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Записи (вооружения)");
                    worksheet.Cells[1, 1].Value = "Код вооружения";
                    worksheet.Cells[1, 2].Value = "Название вооружения";
                    worksheet.Cells[1, 3].Value = "Описание";
                    worksheet.Cells[1, 4].Value = "Дата обновления информации";
                    int row = 2;
                    foreach (var record in weapons)
                    {
                        worksheet.Cells[row, 1].Value = record.Id_weapons;
                        worksheet.Cells[row, 2].Value = record.Name_weapons;
                        worksheet.Cells[row, 3].Value = record.Description;
                        worksheet.Cells[row, 4].Value = record.Date_update_information.ToString("dd.MM.yyyy");
                        row++;
                    }
                }
                FileInfo fileInfo = new FileInfo(filePath);
                package.SaveAs(fileInfo);
            }
        }
    }
}
