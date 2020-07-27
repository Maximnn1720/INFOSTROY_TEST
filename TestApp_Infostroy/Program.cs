using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.IO;




namespace TestApp_Infostroy
{

	static class Program
	{
				
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
	
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Form1());
		}
		
	}
}
