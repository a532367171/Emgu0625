using Emgu.CV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Emgu0625
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Capture cap;
        private bool isProcess = false;

        void button1_Click(object sender, EventArgs e)
        {
            if (cap != null)
            {
                if (isProcess)
                {
                    Application.Idle -= new EventHandler(ProcessFram);
                    button1.Text = "stop!";
                }
                else
                {
                    Application.Idle += new EventHandler(ProcessFram);
                    button1.Text = "start!";
                }
                isProcess = !isProcess;
            }
            else
            {
                try
                {
                    cap = new Emgu.CV.Capture();
                }
                catch (NullReferenceException expt)
                {
                    MessageBox.Show(expt.Message);
                }
            }
        }

        private void ProcessFram(object sender, EventArgs arg)
        {
            imageBox1.Image = cap.QueryFrame();
        }
    }
}
