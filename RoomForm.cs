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
    public partial class RoomForm : Form
    {
        RoomClass room = new RoomClass();
        public RoomForm()
        {
            InitializeComponent();
        }
        private void deleteData()
        {
            textBox1.Clear();
            textBox3.Clear();
        }
        private void RoomForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = room.getRoomType();
            comboBox1.DisplayMember = "Lable";
            comboBox1.ValueMember = "CategoryId";
            getRoomList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            int type = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            string ph = textBox3.Text;
            string status = radioButton1.Checked ? "Свободна" : "Занята";
            if (textBox1.Text == "" || comboBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Введите полную информацию", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                if (room.InsertRoom(id, type, ph, status))
                {
                    MessageBox.Show("Комната добавлена", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getRoomList();
                    deleteData();
                }
                else
                {
                    MessageBox.Show("Комната не добавлена", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void getRoomList()
        {
            dataGridView1.DataSource = room.getRoomList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            int type = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            string ph = textBox3.Text;
            string status = radioButton1.Checked ? "Свободна" : "Занята";

            try
            {
                if (room.EditRoom(id, type, ph, status))
                {
                    MessageBox.Show("Комната изменена", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getRoomList();
                    deleteData();
                }
                else
                {
                    MessageBox.Show("Комната не изменена", "Add Room", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
            comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

            string rButton = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            if (rButton.Equals("Свободна"))
            {
                radioButton1.Checked = true;
            }
            else
            {
                radioButton2.Checked = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
                try
                {
                    string id = textBox1.Text;
                    Boolean deleteGuest = room.removeRoom(id);
                    if (deleteGuest)
                    {
                        MessageBox.Show("Информация удалена", "Room Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getRoomList();
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


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                bool isVisible = false;
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1[j, i].Value.ToString() == comboBox3.SelectedItem.ToString())
                    {
                        isVisible = true;
                    }
                }
                dataGridView1.Rows[i].Visible = isVisible;
            }
        }
    }
}
