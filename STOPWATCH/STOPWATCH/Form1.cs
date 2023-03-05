using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOPWATCH
{
    public partial class Form1 : Form
    {
        private Label lblStopwatch;
        private Button btnStart;
        private Button btnStop;
        private Button btnReset;

        private bool isRunning = false;
        private TimeSpan elapsedTime = TimeSpan.Zero;
        private DateTime startTime;
        private Timer timer;

        public Form1()
        {
            InitializeComponent();
            // Khởi tạo Timer
            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            // Tạo label để hiển thị thời gian
            lblStopwatch = new Label();
            lblStopwatch.Text = "00:00:00";
            lblStopwatch.Font = new Font("Arial", 24);
            lblStopwatch.AutoSize = true;
            lblStopwatch.Location = new Point(10, 10);

            // Tạo button Start
            btnStart = new Button();
            btnStart.Text = "Start";
            btnStart.Location = new Point(10, 50);
            btnStart.Click += BtnStart_Click;

            // Tạo button Stop
            btnStop = new Button();
            btnStop.Text = "Stop";
            btnStop.Location = new Point(110, 50);
            btnStop.Click += BtnStop_Click;

            // Tạo button Reset
            btnReset = new Button();
            btnReset.Text = "Reset";
            btnReset.Location = new Point(210, 50);
            btnReset.Click += BtnReset_Click;

            // Thêm control vào form
            this.Controls.Add(lblStopwatch);
            this.Controls.Add(btnStart);
            this.Controls.Add(btnStop);
            this.Controls.Add(btnReset);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void UpdateTime()
        {
            TimeSpan currentTime = DateTime.Now - startTime + elapsedTime;
            string timeString = string.Format("{0:00}:{1:00}:{2:00}",
                currentTime.Hours, currentTime.Minutes, currentTime.Seconds);
            lblStopwatch.Text = timeString;
        }
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!isRunning)
            {
                isRunning = true;
                startTime = DateTime.Now;
                timer.Start();
            }
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                isRunning = false;
                elapsedTime += DateTime.Now - startTime;
                timer.Stop();
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            isRunning = false;
            elapsedTime = TimeSpan.Zero;
            UpdateTime();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            UpdateTime();
        }
    }
}
