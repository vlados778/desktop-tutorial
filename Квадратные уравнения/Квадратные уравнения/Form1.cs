using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SQLite;

namespace Квадратные_уравнения
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "" && textBoxPass.Text == "")
            {
                MessageBox.Show("Ошибка! Данные не введены!");
                textBoxLogin.Text = string.Empty;
                textBoxPass.Text = string.Empty;
            }
            else
            {
                SQLiteCommand CMD = db.CreateCommand();// переменая, которая будет инициировать команды
                CMD.CommandText = "SELECT * FROM users where Login=" + "'" + textBoxLogin.Text + "'" + ";";
                SQLiteCommand CMD2 = db.CreateCommand();
                CMD2.CommandText = "SELECT * FROM users where Password=" + "'" + Hash(textBoxPass.Text) + "'" + ";";
                if (string.IsNullOrEmpty((string)CMD.ExecuteScalar()))
                {
                    MessageBox.Show("Ошибка! Неверно введены логин или пароль!");
                    textBoxLogin.Text = string.Empty;
                    textBoxPass.Text = string.Empty;
                }
                else
                {
                    if (string.IsNullOrEmpty((string)CMD2.ExecuteScalar()))
                    {
                        MessageBox.Show("Ошибка! Неверно введены логин или пароль!");
                        textBoxLogin.Text = string.Empty;
                        textBoxPass.Text = string.Empty;
                    }
                    else
                    {
                        MessageBox.Show("Успешная авторизация! Добро пожаловать!");
                        this.Hide();
                        var formMain = new Form2();
                        formMain.Closed += (s, args) => this.Close();
                        formMain.Show();
                    }
                }
            }

        }
        private SQLiteConnection db; //переменная, которая будет узлом между проектом и бд

        private string Hash(string input)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(input));
                var sb = new StringBuilder(hash.Length * 2);
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            db = new SQLiteConnection("Data Source = DataBase.db; Version=3");//инициализация бд
            db.Open();
        }
    }
}
