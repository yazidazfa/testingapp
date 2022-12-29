using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CollectionOfTestingApp
{
    public partial class FormControl : Form
    {
        public FormControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var formgroup1 = new FormGroup1();
            formgroup1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var formgroup2 = new FormGroup2();
            formgroup2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var formgroup3 = new FormGroup3();
            formgroup3.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var formgroup7 = new FormGroup7();
            formgroup7.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var formgroup6 = new FormGroup6();
            formgroup6.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var formgroup5 = new FormGroup5();
            formgroup5.Show();
        }
    }
}
