using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;

namespace TestApp_Infostroy
{
	public static class DB //Класс для работы с БД
	{
		private static Dictionary<string, string> OperDictionary = new Dictionary<string, string>(23) 
	{
		{ "0", "1 Редактирование сметных/системных данных" },
		{ "1", "2 Удаление сметных/системных данных" },
		{ "2", "3 Экспорт (выгрузка) сметных данных" },
		{ "3", "4 Импорт (загрузка) сметных данных" },
		{ "4", "5 Переключение бизнес-этапа для сметных данных" },
		{ "5", "6 Предоставление группе доступа к сметному объекту" },
		{ "6", "7 Запрет доступа к сметному объекту для группы" },
		{ "7", "8 Изменение собственника сметного объекта" },
		{ "8", "9 Включение разделения доступа" },
		{ "9", "10 Выключение разделения доступа" },
		{ "10", "11 Создание пользователя" },
		{ "11", "12 Удаление пользователя" },
		{ "12", "13 Привязка пользователя к группе" },
		{ "13", "14 Исключение пользователя из группы" },
		{ "14", "15 Назначение роли пользователю" },
		{ "15", "16 Снятие роли с пользователя" },
		{ "16", "17 Редактирование роли" },
		{ "17", "18 Очистка протокола (вручную)" },
		{ "18", "19 Изменение списка протоколируемых операций" },
		{ "19", "20 Выгрузка данных административного доступа" },
		{ "20", "21 Загрузка данных административного доступа" },
		{ "21", "22 Добавление подчиненной группы" },
		{ "22", "23 Удаление подчиненной группы" }
	}; // Словарь столбца Oper
		private static Dictionary<string, string> SmTypeDictionary = new Dictionary<string, string>(13)
	{
		{"0", "1 Проект"},
		{"1", "2 ОС"},
		{"2", "3 ЛС"},
		{"3", "4 ПС (проектная смета)"},
		{"4", "5 Акт"},
		{"5", "6 Пользователь"},
		{"6", "7 Роль"},
		{"7", "8 Операции с протоколом"},
		{"8", "9 Операции с разделением доступа"},
		{"9", "10 Справочник"},
		{"10", "11 Группа"},
		{"11", "12 Системные объекты"},
		{"12", "13 Справочники индексов"}
	}; // Словарь столбца SmType
		private static Dictionary<int, Font> FontDictionary = new Dictionary<int, Font>(4)
	{
		{0, new Font(FontFamily.GenericSansSerif,12.0F, FontStyle.Bold)},
		{1, new Font(FontFamily.GenericSansSerif,12.0F)},
		{2, new Font(FontFamily.GenericSansSerif,12.0F, FontStyle.Underline)},
		{3, new Font(FontFamily.GenericSansSerif,12.0F, FontStyle.Italic)},
	}; // Словарь шрифтов TreeView
		private static string NameFirstTag = "Login"; // Наименование столбца для первого уровня в TreeView
		private static string NameSecondTag = "SmType"; // Наименование столбца для второго уровня в TreeView
		public static void ChangeTopTag() // Метод меняет столбцы для первого и второго уровня TreeView местами  
		{
			string key = NameFirstTag;
			NameFirstTag = NameSecondTag;
			NameSecondTag = key;
		} 
		public static void ToTreeView(ref TreeView treeViewDB, string SortCriterion = "*") //Заполнения TreeView 
		{
			try
			{
				//Очистка стобца LogText и получение таблицы с сортировкой
				SqlCommand cmd = new SqlCommand(" ", ConnectionDB.myConn);
			
				cmd.CommandText = "UPDATE  A0Protocol SET LogText = replace(LogText, '\r', ' ')";
				cmd.CommandText = "UPDATE  A0Protocol SET LogText = replace(LogText, '\n', ' ')";
				cmd.CommandText = "UPDATE  A0Protocol SET LogText = replace(LogText, '\t', ' ')";
				cmd.ExecuteNonQuery();

				if (SortCriterion == "*") { SortCriterion = ""; }
				else { SortCriterion = " WHERE DATEPART(yy,EvDate) " + SortCriterion; }
				cmd.CommandText = "SELECT * FROM A0Protocol" + SortCriterion + " ORDER BY " + NameFirstTag + ", " + NameSecondTag + ", Oper, EvDate, ProjID, SmObjID, LogText ";

				//Построчное получение ячеек БД и запись значений ячеек в соответствующие переменные. Заполнение TreeView
				
				string EvDate, FirstTag, Oper, ProjID, SmObjID, SecondTag, LogText;

				using (DbDataReader reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							EvDate = Convert.ToString(reader.GetValue(reader.GetOrdinal("EvDate")));
							FirstTag = Convert.ToString(reader.GetValue(reader.GetOrdinal(NameFirstTag)));
							Oper = Convert.ToString(reader.GetValue(reader.GetOrdinal("Oper")));
							ProjID = Convert.ToString(reader.GetValue(reader.GetOrdinal("ProjID")));
							SmObjID = Convert.ToString(reader.GetValue(reader.GetOrdinal("SmObjID")));
							SecondTag = Convert.ToString(reader.GetValue(reader.GetOrdinal(NameSecondTag)));
							LogText = reader.GetString(reader.GetOrdinal("LogText"));

							if (OperDictionary.ContainsKey(Oper)) { Oper = OperDictionary[Oper].ToString(); }
							if (SmTypeDictionary.ContainsKey(FirstTag)) { FirstTag = SmTypeDictionary[FirstTag].ToString(); }
							if (SmTypeDictionary.ContainsKey(SecondTag)) { SecondTag = SmTypeDictionary[SecondTag].ToString(); }

							//Запись переменных в соотвествующее место в TreeView

							TreeNodeCollection NC = treeViewDB.Nodes;
							if (NC.Count == 0 || FirstTag != NC[NC.Count - 1].Text)
							{
								NC.Add(new TreeNode(FirstTag));
								NC[NC.Count - 1].NodeFont = FontDictionary[0];
							}

							NC = NC[NC.Count - 1].Nodes;
							if (NC.Count == 0 || SecondTag != NC[NC.Count - 1].Text)
							{
								NC.Add(new TreeNode(SecondTag));
								NC[NC.Count - 1].NodeFont = FontDictionary[1];
							}

							NC = NC[NC.Count - 1].Nodes;
							if (NC.Count == 0 || Oper != NC[NC.Count - 1].Text)
							{
								NC.Add(new TreeNode(Oper));
								NC[NC.Count - 1].NodeFont = FontDictionary[2];
							}

							NC = NC[NC.Count - 1].Nodes;
							NC.Add(new TreeNode(EvDate + " | " + ProjID + " | " + SmObjID + " | " + LogText));
							NC[NC.Count - 1].NodeFont = FontDictionary[3];
						}

					}
				}
			}
			catch (Exception h)
			{
				Console.WriteLine("Error: " + h.Message);
			}
			finally
			{
				ConnectionDB.Close();
			}
		}
	}
	
}
