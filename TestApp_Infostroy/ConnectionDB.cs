using System;
using System.Data.SqlClient;
using System.IO;

namespace TestApp_Infostroy
{
	public static class ConnectionDB // Класс используемый для создания подключения к БД
	{
		private static string connString() // Получение кода подключения из settings.ini
		{
			StreamReader sr = new StreamReader("settings.ini");
			return sr.ReadToEnd();
		}
		private static SqlConnection MyConn = new SqlConnection(connString()); // Создание подключения
		public static SqlConnection myConn //Доступ к подключению 
		{
			get
			{
				MyConn.Open();
				return MyConn;
			}
		} 
		public static void Close() // Закрытие подключения 
		{
			MyConn.Close();
		}
		public static bool CheckConnection() //Проверка подключения 
		{
			try
			{
				MyConn.Open();
				MyConn.Close();
				return true;
			}
			catch (Exception ex) { return false; }
		}

	}


}
