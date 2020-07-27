using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.IO;
using System.Collections.Generic;

namespace TestApp_Infostroy
{
	
	public partial class Form1 : Form
	{
		bool filterDB = false;

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{			
			СomboBoxBool.SelectedIndex = 0;

			//Проверка подключения к БД

			if (ConnectionDB.CheckConnection())
			{
				try { DB.ToTreeView(ref treeViewDB); }
				catch (Exception h) { Console.WriteLine("Error: " + h.Message); }
			}
			else
			{
				MessageBox.Show("Настройте файл settings.ini и повторите попытку", "Нет доступа к базе данных!", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(0);
			}
		}

		private void ButtonExport_Click(object sender, EventArgs e) 
		{
			//Подключение библиотеки и экспорт данных в CSV 
			File.Delete("DB.csv");
			Assembly asm = Assembly.LoadFrom("MyClassLibrary.dll");
			Type t = asm.GetType("MyClassLibrary.ExportDB", true, true);
			MethodInfo method = t.GetMethod("ToCSV");
			method.Invoke(t, new object[] {ConnectionDB.myConn});
			ConnectionDB.Close();
		}

		private void ButtonChange_Click(object sender, EventArgs e) 
		{
			//Перезаполнение Treeview со сменой столбцов первых двух уровней 
			treeViewDB.Nodes.Clear();
			DB.ChangeTopTag();
			DB.ToTreeView(ref treeViewDB);
			ConnectionDB.Close();
		}

		private string AdressNode(TreeNode SNode) // возвращает адрес в TreeView до выбранного элементы дерева 
		{
			if (SNode.Parent == null)
			{
				return SNode.Text;				
			}
			else
			{
				return AdressNode(SNode.Parent) + " | " + SNode.Text;
			}
		}


		private void treeViewDB_AfterSelect(object sender, TreeViewEventArgs e)
		{
			//Заполнение формы статуса адреcом выбранного элемента 
			StatusLabel.Text = AdressNode(treeViewDB.SelectedNode);
		}

		

		private void ButtonChekFilter_Click(object sender, EventArgs e)
		{
			//Активация и деактивация фильтра по году
			filterDB = !filterDB;
			if (filterDB)
			{
				ButtonChekFilter.BackColor = SystemColors.ControlLightLight;
				treeViewDB.Nodes.Clear();
				DB.ToTreeView(ref treeViewDB, СomboBoxBool.Text + " " + TextBoxFilter.Text);
				TextBoxFilter.Enabled = false;
				СomboBoxBool.Enabled = false;
			}
			else
			{
				ButtonChekFilter.BackColor = SystemColors.Control;
				treeViewDB.Nodes.Clear();
				DB.ToTreeView(ref treeViewDB, "*");
				TextBoxFilter.Enabled = true;
				СomboBoxBool.Enabled = true;
			}
		}
	}
}
