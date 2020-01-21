using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LockTimer
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Help_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        public string ChangeLabel3Text
        {
            get
    {
                return this.label3.Text;
            }
            set
    {
                this.label3.Text = value;
            }
        }
        public Label HelpLabel3
        {
            get
            {
                return this.label3;
            }

            set
            {
                this.label3 = value;
            }
        }

    }
}
