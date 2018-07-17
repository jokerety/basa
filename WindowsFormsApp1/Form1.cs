using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
	public partial class Notebook : Form
	{
		PeopleContext db;
		public Notebook()
		{
			InitializeComponent();
			db = new PeopleContext();
			db.People.Load();
			dataGridView1.DataSource = db.People.Local.ToBindingList();
		}
		//добавление 
		private void button1_Click(object sender, EventArgs e)
		{
			AddForm addForm = new AddForm();
			DialogResult result = addForm.ShowDialog(this);

			if (result == DialogResult.Cancel)
				return;


			Regex regexPhone = new Regex(@"((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}");

			List<Phone> list = new List<Phone>();

			string Firstname = addForm.textBox1.Text;
			string Secondname = addForm.textBox2.Text;
			string Patronymic = addForm.textBox3.Text;
			string Info = addForm.textBox4.Text;

			MatchCollection matchesPhone = regexPhone.Matches(addForm.textBox5.Text);
			if (matchesPhone.Count > 0)
			{
				int i = 0;
				foreach (Match match in matchesPhone)
				{
					list.Add(new Phone(match.Value, i));
					i++;
				}
			}
			else
			{
				Console.WriteLine("Некорректный ввод телефона");
			}

			Person p = new Person(Firstname, Secondname, Patronymic, Info);
			foreach (Phone phone in list)
			{
				p.Phones.Add(phone);
			}

			db.People.Add(p);
			db.SaveChanges();
			MessageBox.Show("Новый объект добавлен");
		}
		//редактирование
		private void button3_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int index = dataGridView1.SelectedRows[0].Index;
				int id = 0;
				bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
				if (converted == false)
					return;

				Person person = db.People.Find(id);
				AddForm addForm = new AddForm();

				addForm.textBox1.Text = person.FirstName;
				addForm.textBox2.Text = person.SecondName;
				addForm.textBox3.Text = person.Patronymic;
				addForm.textBox4.Text = person.Info;
				string phones = "";
				foreach (Phone number in person.Phones)
				{
					phones += number.Number;
				}
				addForm.textBox5.Text = phones;

				DialogResult result = addForm.ShowDialog(this);

				if (result == DialogResult.Cancel)
					return;

				person.FirstName = addForm.textBox1.Text;
				person.SecondName = addForm.textBox2.Text;
				person.Patronymic = addForm.textBox3.Text;
				person.Info = addForm.textBox4.Text;

				Regex regexPhone = new Regex(@"((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}");
				List<Phone> list = new List<Phone>();
				MatchCollection matchesPhone = regexPhone.Matches(addForm.textBox5.Text);
				if (matchesPhone.Count > 0)
				{
					int i = 0;
					foreach (Match match in matchesPhone)
					{
						list.Add(new Phone(match.Value, i));
						i++;
					}
				}
				else
				{
					Console.WriteLine("Некорректный ввод телефона");
				}
				person.Phones = new List<Phone>();
				foreach (Phone phone in list)
				{
					person.Phones.Add(phone);
				}

				db.SaveChanges();
				dataGridView1.Refresh();
				MessageBox.Show("Объект обновлен");

			}


		}
		//удаление
		private void button2_Click(object sender, EventArgs e)
		{
			if (dataGridView1.SelectedRows.Count > 0)
			{
				int index = dataGridView1.SelectedRows[0].Index;
				int id = 0;
				bool converted = Int32.TryParse(dataGridView1[0, index].Value.ToString(), out id);
				if (converted == false)
					return;

				Person person = db.People.Find(id);
				db.People.Remove(person);
				db.SaveChanges();

				MessageBox.Show("Объект удален");
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}


	}
}


