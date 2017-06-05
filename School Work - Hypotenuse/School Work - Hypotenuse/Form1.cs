//-----------------------------------------------------------------------
// Created: 7/02/2014 - By Patrick Shaw
// Updated: 7/02/2014
// Program calculates the hypotenuse of a triangle using the Pythagorus Theorum
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_Work___Hypotenuse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void txtSide1_TextChanged(object sender, EventArgs e)
        {
            // Change change lblValue.Text to the hypotenuse value
            ChangeValue();
        }

        private void txtSide2_TextChanged(object sender, EventArgs e)
        {
            ChangeValue();
        }
        private void ChangeValue()
        {
            try
            {
                // Set text as (a^2 + b^2)^0.5, rounded to two decimal places
                lblValue.Text = Math.Round(Math.Sqrt(Square(Convert.ToDouble(txtSide1.Text)) + Square(Convert.ToDouble(txtSide2.Text))),2).ToString();
            }
            catch
            {

            }
        }
        private double Square(double value)
        {
            // Square the given value
            return value * value;
        }
    }
}
