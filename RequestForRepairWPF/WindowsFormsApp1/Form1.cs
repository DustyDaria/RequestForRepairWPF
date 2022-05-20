using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.entities;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static readonly DB_RequestForRepairEntities Context = new DB_RequestForRepairEntities();

        private void Form1_Load(object sender, EventArgs e)
        {
            var user = Context.Executors
                 .ToList();

            MessageBox.Show(user.Count.ToString());
        }
    }
}
