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
    public partial class ReservationForm : Form
    {
        RoomClass room = new  RoomClass();
        ReservationClass reservation = new ReservationClass();
        public ReservationForm()
        {
            InitializeComponent();
        }
        private void deleteData()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedValue = 1;
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker1.Value = DateTime.Now;
        }
        private void ReservationForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = room.getRoomType();
            comboBox1.DisplayMember = "Lable";
            comboBox1.ValueMember = "CategoryId";

            int type = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            comboBox2.DataSource = reservation.roomByType(type);
            comboBox2.DisplayMember = "RoomId";
            comboBox2.ValueMember = "RoomId";

            getReservTable();
        }

        public void getReservTable()
        {
            dataGridView1.DataSource = reservation.getReserv();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int type = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                comboBox2.DataSource = reservation.roomByType(type);
                comboBox2.DisplayMember = "RoomId";
                comboBox2.ValueMember = "RoomId";

            }
            catch (Exception)
            {
                //Nothing
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || comboBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Введите полную информацию", "Required Field", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            try
            {
                string guestId = textBox2.Text;
                string roomNo = comboBox2.SelectedValue.ToString();
                DateTime Din = dateTimePicker1.Value;
                DateTime Dout = dateTimePicker2.Value;

                if (Din < DateTime.Today)
                {
                    MessageBox.Show("Дата входа в номер должна быть сегодняшней", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Dout < Din)
                {
                    MessageBox.Show("Даты не должны быть одинаковыми", "invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (reservation.addReserv(guestId, roomNo, Din, Dout) && reservation.setReservRoom(roomNo, "Busy"))
                    {    
                        MessageBox.Show("Регистрация добавлена", "Add Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        getReservTable();
                        deleteData();

                    }
                    else
                    {
                        MessageBox.Show("Регистрация не добавлена", "Error Reservation", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error reservation");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ReservId = Convert.ToInt32(textBox1.Text);
            string rno = comboBox2.Text;

            try
            {
                if (reservation.removeReserv(ReservId) && reservation.setReservRoom(rno, "Free"))
                {
                    MessageBox.Show("Delete Reservatoin Successfuly", "Deleted Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    deleteData();
                    getReservTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            string rno = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.SelectedValue = reservation.typeByRoomNo(rno);
            comboBox2.Text = rno;
            //comboBox_roomType
            dateTimePicker1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ReservId = Convert.ToInt32(textBox1.Text);
                string guestId = textBox2.Text;
                string roomNo = comboBox2.SelectedValue.ToString();
                DateTime Din = dateTimePicker1.Value;
                DateTime Dout = dateTimePicker2.Value;

                if (Din < DateTime.Today)
                {
                    MessageBox.Show("Reservation Date In must be Today Or After", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (Dout < Din)
                {
                    MessageBox.Show("Reservation Date Out must be same Date In and After", "invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (reservation.editReserv(ReservId, guestId, roomNo, Din, Dout) && reservation.setReservRoom(roomNo, "Busy"))
                    {
                        MessageBox.Show("Reservation edit Successfuly", "Update Reservation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        deleteData();
                        getReservTable();
                    }
                    else
                    {
                        MessageBox.Show("Reservation Not edit Successfuly", "Error Update", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Reservation Edit Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
    }
}
