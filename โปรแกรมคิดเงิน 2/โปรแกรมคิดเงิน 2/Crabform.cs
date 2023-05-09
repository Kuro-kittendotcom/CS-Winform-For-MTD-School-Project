﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace โปรแกรมคิดเงิน_2
{
    public partial class Crabform : Form
    {
        public Crabform()
        {
            InitializeComponent();
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ประกาศตัวแปร
        public double item1, item2, result, getMoney;
        public bool keyOP = true;

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //เมธอดที่ไว้สำหรับเคลียร์ textBox
        private void clearItems()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox1.Focus();
        }

        //เมธอดที่ไว้สำหรับแสดงหน้า Error
        public void err()
        {
            MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่ตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            keyOP = false;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตั้งแต่ส่วนนี้จะเป็นส่วนที่ได้จากการที่เราดับเบิลคลิกตรงออบเจ็กท์ที่หน้าฟอร์ม
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("คุณต้องการออกจากโปรแกรมหรือไม่", "EXIT", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clearItems(); //เรียกใช้เมธอด
            keyOP = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    err(); //เรียกใช้เมธอด
                    textBox1.Focus();
                }
                else if (textBox2.Text == "" || textBox2.Text == null)
                {
                    err(); //เรียกใช้เมธอด
                    textBox2.Focus();
                }
                else 
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ item1, item2
                    item1 = double.Parse(textBox1.Text);
                    item2 = double.Parse(textBox2.Text);
                    result = item1 + item2; //ตัวแปร result มีค่าเป็น item1 + item2

                    textBox3.Text = result.ToString();
                    //นำค่าจากที่ได้จาก result ไปแสดงผลไปที่ textBox3
                }
            }
            catch(Exception) 
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearItems(); //เรียกใช้เมธอด
                keyOP = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try 
            {
                if (textBox4.Text == "" || textBox4.Text == null)
                {
                    err(); //เรียกใช้เมธอด
                    textBox4.Focus();
                }
                else
                {
                    //แปลงชนิดข้อมูลจาก string ไปหา double โดยรับค่าจาก textBox และส่งค่าที่แปลงได้ไปเก็บที่ getMoney
                    getMoney = double.Parse(textBox4.Text);

                    textBox5.Text = (getMoney - result).ToString();
                    //นำค่าจากที่ได้จาก getMoney - result ไปแสดงผลไปที่ textBox5
                }
            }
            catch (Exception)
            {
                MessageBox.Show("เกิดข้อผิดพลาดกรุณาใส่เฉพาะตัวเลข", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox4.Clear();
                textBox4.Focus();
                keyOP = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            keyOP = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            keyOP = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            keyOP = true;
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //ตรงส่วนนี้จะเป็นอีเว้นท์ KeyUp ได้จากการที่เราไปที่หน้า Events (รูปสายฟ้า) ในเมนู Properties
        //แต่เราจำเป็นคลิกตรงออบเจ็กท์ที่ต้องการจัดการอีเว้นท์ในหน้าฟอร์มหนึ่งครั้งก่อน
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                button1.Focus();
            }
        }

        private void button1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                textBox4.Focus();
            }
        }

        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                button2.Focus();
            }
        }

        private void button2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && keyOP == true)
            {
                button3.Focus();
            }
        }
    }
}
