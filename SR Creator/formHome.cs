using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SR_Creator
{
    public partial class formHome : Form
    {
        public formHome()
        {
            InitializeComponent();
        }
        #region Events


        private void inputNew_Click(object sender, EventArgs e)
        {
            //Open the new slit ring create form
            formInput formInput = new formInput();
            formInput.ShowDialog();
        }

        private void inputUpdate_Click(object sender, EventArgs e)
        {

        }

        private void formHome_Load(object sender, EventArgs e)
        {
        }

        #endregion Events

        #region Methods



        #endregion Methods
    }
}
