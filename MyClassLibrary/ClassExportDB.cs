using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Data.SqlClient;

namespace MyClassLibrary
{
    public static class ExportDB
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
		};  // Словарь столбца Oper
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
		public static void ToCSV(SqlConnection myConn) //Метод экспорта БД в csv формат 
		{
			try
			{							
				//Очистка стобца LogText и получение таблицы 
				SqlCommand cmd = new SqlCommand(" ", myConn);
				cmd.CommandText = @"
				UPDATE  A0Protocol SET LogText = replace(LogText, '\r', ' ')
				UPDATE  A0Protocol SET LogText = replace(LogText, '\n', ' ')
				UPDATE  A0Protocol SET LogText = replace(LogText, '\t', ' ')
				";
				cmd.ExecuteNonQuery();
				cmd.CommandText = "SELECT * FROM A0Protocol ORDER BY Login, SmType, Oper, EvDate, ProjID, SmObjID, LogText";

				//Построчное считывание таблицы с заменой значений столбцов Oper и SmType и построчная запись в созданный файл
				StreamWriter sw = new StreamWriter("DB.csv", false, System.Text.Encoding.Default); //подключение к файлу
				Object[] line = new object[8]; //Массив значений строки
				string str = ""; //Строка записи в файл

				using (DbDataReader reader = cmd.ExecuteReader())
				{
					if (reader.HasRows)
					{
						while (reader.Read())
						{
							reader.GetValues(line);
							for (int i = 0; i < reader.FieldCount; i++)
							{
								if (reader.GetName(i) == "Oper")
								{
									str = OperDictionary.ContainsKey(reader.GetValue(i).ToString()) ? OperDictionary[reader.GetValue(i).ToString()] : reader.GetValue(i).ToString();
								}
								else if (reader.GetName(i) == "SmType")
								{
									str = SmTypeDictionary.ContainsKey(reader.GetValue(i).ToString()) ? SmTypeDictionary[reader.GetValue(i).ToString()] : reader.GetValue(i).ToString();
								}
								else { str = reader.GetValue(i).ToString(); }
								sw.Write((i != 0) ? (" ; " + str) : str);
							}
							sw.WriteLine();
						}
						sw.Close();
					}
				}
			}
			catch (Exception h)
			{
				Console.WriteLine("Error: " + h.Message);
			}
		} 
	}
}
