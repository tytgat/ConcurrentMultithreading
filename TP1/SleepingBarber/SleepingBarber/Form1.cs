using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SleepingBarber
{
    public partial class formBarberShop : Form
    {

        Semaphore semBarber;
        Semaphore semWaitingRoom;
        Semaphore semClient;
        
        public WaitingRoom room;
        public Chair workingChair;
        public Chair barberChair;

        Thread barber;
        bool close = false;

        public formBarberShop()
        {
            InitializeComponent();

            /*Waiting Room*/
            int nbOfSeat = 0;
            List<Chair> chairs = new List<Chair>();
            Panel wR = (Panel)panelWaitingRoom;
            foreach(Control control in wR.Controls)
            {
                if(control.GetType() == typeof(PictureBox))
                {
                    nbOfSeat++;
                    chairs.Add(new Chair((PictureBox)control));
                }
            }
            room = new WaitingRoom(chairs, nbOfSeat);

            /*Barber Seat*/
            barberChair = new Chair(pbBarberChair);
            barberChair.takeChair(); // On his seat at the begining

            /*Working Seat*/
            workingChair = new Chair(pbWorkingChair);

            /* Semaphore */
            semBarber = new Semaphore(0, nbOfSeat+2);
            semWaitingRoom = new Semaphore(nbOfSeat, nbOfSeat);
            semClient = new Semaphore(0, nbOfSeat+2);

            barber = new Thread(BarberRoutine);
            barber.Start();
        }

        delegate void SetBarberRoutineProgressBarCallback(int value);

        private void SetProgressBar(int value)
        {
            if (this.progressBarWorking.InvokeRequired)
            {
                SetBarberRoutineProgressBarCallback d = new SetBarberRoutineProgressBarCallback(SetProgressBar);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.progressBarWorking.Value = value;
            }
        }

        delegate void SetLabelClientCallback(string value);

        private void SetLabelClient(string value)
        {
            if (this.labelClient.InvokeRequired)
            {
                SetLabelClientCallback d = new SetLabelClientCallback(SetLabelClient);
                this.Invoke(d, new object[] { value });
            }
            else
            {
                this.labelClient.Text = value;
            }
        }

        public void BarberRoutine()
        {
            /*ProgressBar progressBarBarber = new ProgressBar();
            progressBarBarber.Minimum = 0;
            progressBarBarber.Maximum = 100;
            progressBarBarber.Value = 0;
            progressBarBarber.Location = new Point(195, 87);
            progressBarBarber.Size = new Size(50, 23);
            this.Controls.Add(progressBarBarber);*/
            
            while (!close)
            {
                semClient.WaitOne();
                semWaitingRoom.WaitOne();
                room.freeSeat();

                semBarber.Release();
                semWaitingRoom.Release();

                /*Working*/
                barberChair.freeChair();
                workingChair.takeChair();
                for (int i = 0; i < 100; i++)
                {
                    SetProgressBar(i);
                    //progressBarBarber.Value = i;
                    Thread.Sleep(50);
                }
                SetProgressBar(0);
                SetLabelClient("Client left with an haircut ! ");
                barberChair.takeChair();
                workingChair.freeChair();
            }
        }

        public void clientRoutine()
        {
            SetLabelClient("New Client entered");
            semWaitingRoom.WaitOne();
            
            if(room.hasFreeSeat())
            {
                room.takeSeat();
                semClient.Release();
                semWaitingRoom.Release();
                semBarber.WaitOne();
            }
            else
            {
                semWaitingRoom.Release();
                SetLabelClient("Client left without an haircut");
            }
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            Thread client = new Thread(clientRoutine);
            client.Start();
        }

        private void formBarberShop_FormClosing(object sender, FormClosingEventArgs e)
        {
            close = true;
            SetLabelClient("Finishing haircut !!");
            barber.Abort();
            Hide();
           
        }
    }
}
