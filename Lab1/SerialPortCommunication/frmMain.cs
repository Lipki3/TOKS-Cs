using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PCComm;
namespace PCComm
{
    public partial class FrmMain : Form
    {
        readonly CommunicationManager comm = new CommunicationManager();
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
           LoadValues();
           SetDefaults();
           SetControlState();
        }

        private void CmdOpen_Click(object sender, EventArgs e)
        {
            comm.PortName = cboPort.Text;
            comm.Parity = cboParity.Text;
            comm.StopBits = cboStop.Text;
            comm.DataBits = cboData.Text;
            comm.BaudRate = cboBaud.Text;
            comm.DisplayWindow = rtbDisplay;
            comm.OpenPort();

            cmdOpen.Enabled = false;
            cmdClose.Enabled = true;
            cmdSend.Enabled = true;
        }

        private void SetDefaults()
        {
            try
            {
                cboPort.SelectedIndex = 0;
                cboBaud.SelectedText = "9600";
                cboParity.SelectedIndex = 0;
                cboStop.SelectedIndex = 1;
                cboData.SelectedIndex = 1;
            }
            catch
            {
                rtbDisplay.Text = "���� �� ������!";
                cmdSend.Enabled = false;
                cmdClose.Enabled = false;
                cmdOpen.Enabled = false;
            }

        }

        private void LoadValues()
        {
            comm.SetPortNameValues(cboPort);
            comm.SetParityValues(cboParity);
            comm.SetStopBitValues(cboStop);
        }

        private void SetControlState()
        {
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
        }

        private void CmdSend_Click(object sender, EventArgs e)
        {
            comm.WriteData(txtSend.Text);
        }

        private void CmdClose_Click(object sender, EventArgs e)
        {
            comm.ClosePort();
            cmdSend.Enabled = false;
            cmdClose.Enabled = false;
            cmdOpen.Enabled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            rtbDisplay.Clear();
        }

        private void CboBaud_SelectedIndexChanged(object sender, EventArgs e)
        {
            comm.BaudRate = cboBaud.Text;
        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {

        }
    }
}