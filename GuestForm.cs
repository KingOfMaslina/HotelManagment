using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace отель_администрирование
{
    public partial class GuestForm : Form
    {
        GuestClass guest = new GuestClass();
        public GuestForm()
        {
            InitializeComponent();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите полную информацию", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    string id = textBox1.Text;
                    string fname = textBox2.Text;
                    string lname = textBox3.Text;
                    string phone = textBox4.Text;
                    string comm = textBox5.Text;
                    string comp = textBox6.Text;

                    Boolean insertGuest = guest.InsertGuest(id, fname, lname, phone, comm,comp);
                    if (insertGuest)
                    {
                        MessageBox.Show("Гость добавлен", "Guest Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTable();
                        deleteData();
                    }
                    else
                    {
                        MessageBox.Show("Гость не добавлен", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void GuestForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            getTable();
        }
        private void getTable()
        {
        dataGridView1.DataSource = guest.getGuest();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                try
                {
                    string id = textBox1.Text;
                    string fname = textBox2.Text;
                    string lname = textBox3.Text;
                    string phone = textBox4.Text;
                    string comm = textBox5.Text;
                    string comp = textBox6.Text;

                Boolean EditGuest = guest.EditGuest(id, fname, lname, phone, comm,comp);
                    if (EditGuest)
                    {
                        MessageBox.Show("Информация обновлена", "Guest Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTable();
                        deleteData();
                    }
                    else
                    {
                        MessageBox.Show("Информация не обновлена", "Error Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                try
                {
                    string id = textBox1.Text;
                    Boolean deleteGuest = guest.removeGuest(id);
                    if (deleteGuest)
                    {
                        MessageBox.Show("Информация удалена", "Guest Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getTable();
                        deleteData();
                    }
                    else
                    {
                        MessageBox.Show("Информация не удалена", "Error delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        }
        private void deleteData()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char Letter = e.KeyChar;

            if (!Char.IsLetter(Letter))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char Letter = e.KeyChar;

            if (!Char.IsLetter(Letter))
            {
                e.Handled = true;
            }
        }
    }
}
