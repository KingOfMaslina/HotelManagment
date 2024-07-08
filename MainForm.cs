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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel_slide.Height = button1.Height;
            panel_slide.Top = button1.Top;

            panel_main.Controls.Clear();
            panel_main.Controls.Add(panel_cover);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel_slide.Height = button2.Height;
            panel_slide.Top = button2.Top;

            panel_main.Controls.Clear();
            GuestForm guest = new GuestForm();
            guest.TopLevel = false;
            guest.Dock = DockStyle.Fill;
            guest.FormBorderStyle = FormBorderStyle.None;
            panel_main.Controls.Add(guest);
            guest.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel_slide.Height = button3.Height;
            panel_slide.Top = button3.Top;

            panel_main.Controls.Clear();
            ReservationForm reservation = new ReservationForm();
            reservation.TopLevel = false;
            reservation.Dock = DockStyle.Fill;
            reservation.FormBorderStyle = FormBorderStyle.None;
            panel_main.Controls.Add(reservation);
            reservation.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel_slide.Height = button4.Height;
            panel_slide.Top = button4.Top;

            panel_main.Controls.Clear();
            RoomForm room = new RoomForm();
            room.TopLevel = false;
            room.Dock = DockStyle.Fill;
            room.FormBorderStyle = FormBorderStyle.None;
            panel_main.Controls.Add(room);
            room.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel_slide.Height = button5.Height;
            panel_slide.Top = button5.Top;

            Form1 login = new Form1();
            this.Hide();
            login.Show();   
        }

    }
}
