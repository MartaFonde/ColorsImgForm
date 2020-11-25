using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorsImgForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label8.Text = "";
            try
            {
                //Image i = Image.FromFile(textBox4.Text);
                //label7.Size = new Size(i.Width, i.Height);
                //label7.Image = i;
                label7.Image = new Bitmap(textBox4.Text);
            }
            catch (System.IO.FileNotFoundException)
            {
                label8.Text = "File not found";
            }
            catch(ArgumentException)
            {
                label8.Text = "Invalid";
            }
            catch (NotSupportedException)
            {
                label8.Text = "Not supported file";
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("¿Estás seguro de que quieres salir?", "Confirmación", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) 
                        == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(comprobarRGB(textBox1.Text) && comprobarRGB(textBox2.Text) && comprobarRGB(textBox3.Text))
            {
                int r = Convert.ToInt32(textBox1.Text);
                int g = Convert.ToInt32(textBox2.Text);
                int b = Convert.ToInt32(textBox3.Text);
                this.BackColor = Color.FromArgb(r, g, b);
            }
        }

        private bool comprobarRGB(string col)
        {
            int num = 0;
            bool valid = true;
            label5.Text = "";
            try
            {
                num = Convert.ToInt32(col);
                if(num<0 || num > 255)
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                label5.Text = "Out of range 0-255";
                valid = false;
            }
            catch (FormatException)
            {
                label5.Text = "Enter numbers";
                valid = false;
            }
            catch (OverflowException)
            {
                label5.Text = "Invalid data";
                valid = false;
            }
            return valid;
        }        

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox t = (TextBox)sender;
            if(t == textBox1 || t == textBox2 || t == textBox3)
            {
                label5.Text = "";
                this.AcceptButton = button2;
            }else if(t == textBox4)
            {
                label7.Text = "";
                this.AcceptButton = button3;
            }
        }

        private void mouseMove(object sender, MouseEventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = Color.RosyBrown;
        }

        private void mouseLeave(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            b.BackColor = DefaultBackColor;
        }
    }
}
