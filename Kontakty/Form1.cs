using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;

namespace Kontakty
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection ABC = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jacek\Desktop\PROJEKTY\C#\Kontakty\Kontakty\DatabaseTest.mdf;Integrated Security=True");

        // Server=tcp:pierwszyserwerazure.database.windows.net,1433;Initial Catalog=BazaDanych;Persist Security Info=False;User ID={your_username};Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
        // Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Jacek\Desktop\PROJEKTY\C#\Kontakty\Kontakty\DatabaseTest.mdf;Integrated Security=True
       
        SqlCommand command = new SqlCommand();
        SqlDataReader dataSearch;


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & comboBox1.Text!="")
            { 
            ABC.Open();
            command.CommandText = "insert into tablica(id,imie,nazwisko,telefon,data,plec) Values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + dateTimePicker1.Text + "', '" + comboBox1.Text + "')";//dateTimePicker1.Value.ToShortDateString() 
                command.ExecuteNonQuery();
            ABC.Close();
            MessageBox.Show("Dane zostały zapisane pomyślnie.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear(); 
            dateTimePicker1.Value = DateTime.Now;
            comboBox1.SelectedIndex = 1;
        }
        }

        private void Search()
        {
            ABC.Open();
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            listBox5.Items.Clear();
            listBox6.Items.Clear();
            command.CommandText = "Select * from tablica";
            dataSearch = command.ExecuteReader();

            if (dataSearch.HasRows)
            {
                while (dataSearch.Read())
                {
                    listBox1.Items.Add(dataSearch["id"].ToString());
                    listBox2.Items.Add(dataSearch["imie"].ToString());
                    listBox3.Items.Add(dataSearch["nazwisko"].ToString());
                    listBox4.Items.Add(dataSearch["telefon"].ToString());
                    listBox5.Items.Add(dataSearch["data"].ToString());//.Value.ToShortDateString()
                    listBox6.Items.Add(dataSearch["plec"].ToString());
                } 
            }
            ABC.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'testDataSet.tablica' . Możesz go przenieść lub usunąć.
            this.tableTableAdapter.Fill(this.testDataSet.Table);
            command.Connection = ABC;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox list = sender as ListBox;
            if(list.SelectedIndex !=1)
            {
                listBox1.SelectedIndex = list.SelectedIndex;
                listBox2.SelectedIndex = list.SelectedIndex;
                listBox3.SelectedIndex = list.SelectedIndex;
                listBox4.SelectedIndex = list.SelectedIndex;
                listBox5.SelectedIndex = list.SelectedIndex;
                listBox6.SelectedIndex = list.SelectedIndex;
                //retrieve to TextBox fo AllowDrop Events
                textBox1.Text = listBox1.SelectedItem.ToString();
                textBox2.Text = listBox2.SelectedItem.ToString();
                textBox3.Text = listBox3.SelectedItem.ToString();
                textBox4.Text = listBox4.SelectedItem.ToString();
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.Text = listBox1.SelectedItem.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox3.Text != "" & textBox4.Text != "" & comboBox1.Text != "")
            {
                ABC.Open();
                command.CommandText = "Update tablica set id='"+textBox1.Text+"',imie='" +  textBox2.Text+"',nazwisko ='"+textBox3.Text+"',telefon='"+textBox4.Text+"',data='"+dateTimePicker1.Text+"',plec='"+comboBox1.Text+"' where id ='"+listBox1.SelectedItem.ToString()+"' and imie= '"+listBox2.SelectedItem.ToString()+"'and nazwisko='"+listBox3.SelectedItem.ToString()+"'telefon ='"+listBox4.SelectedItem.ToString()+"'and date='"+listBox5.SelectedItem.ToString()+"' and plec='"+listBox6.SelectedItem.ToString()+"'";
                command.ExecuteNonQuery();
                ABC.Close();
                MessageBox.Show("Dane zostały zaktualizowane pomyślnie.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = 1;
                Search();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                ABC.Open();
                command.CommandText = "delete from tablica where id='"+textBox1.Text+"'";
                command.ExecuteNonQuery();
                ABC.Close();
                MessageBox.Show("Dane zostały usunięte pomyślnie.");
                Search();
            }
        }

        private void linkedin_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/jacek-flak/");
        }
    }
} 
