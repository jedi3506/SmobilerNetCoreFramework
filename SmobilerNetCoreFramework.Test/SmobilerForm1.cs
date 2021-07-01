using Smobiler.Core;
using Smobiler.Core.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmobilerNetCoreFramework.Test
{
    partial class SmobilerForm1 : Smobiler.Core.Controls.MobileForm
    {
        public SmobilerForm1() : base()
        {
            InitializeComponent();
        }

        private void button1_Press(object sender, EventArgs e)
        {
            MessageBox.Show("hello,world! - .net framework");
        }
    }
}