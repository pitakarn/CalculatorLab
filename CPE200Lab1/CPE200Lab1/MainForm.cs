﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPE200Lab1
{
    public partial class MainForm : Form
    {
        private bool containsDot;
        private bool isAllowBack;
        private bool isAfterOperater;
        private bool isAfterEqual;
        private bool isfirstOperater;
        private string firstOperand;
        private string secondOperand;
        private string operate;
        private CalculatorEngine engine;
        
        private double memory;


        private void resetAll()
        {
            lblDisplay.Text = "0";
            isAllowBack = true;
            containsDot = false;
            isAfterOperater = false;
            isAfterEqual = false;
            isfirstOperater = false;
        }
             
        public MainForm()
        {
            InitializeComponent();
            engine = new CalculatorEngine();
            resetAll();
        }

        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (isAfterOperater)
            {
                lblDisplay.Text = "0";
            }
            if(lblDisplay.Text.Length is 8)
            {
                return;
            }
            isAllowBack = true;
            string digit = ((Button)sender).Text;
            if(lblDisplay.Text is "0")
            {
                lblDisplay.Text = "";
            }
            lblDisplay.Text += digit;
            isAfterOperater = false;
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterOperater)
            {
                return;
            }
            operate = ((Button)sender).Text;
            if (isfirstOperater)
            {
                if (lblDisplay.Text is "Error")
                {
                    return;
                }
                secondOperand = lblDisplay.Text;
                string result = engine.calculate(operate, firstOperand, secondOperand);
                if (result is "E" || result.Length > 8)
                {
                    lblDisplay.Text = "Error";
                }
                else
                {
                    lblDisplay.Text = result;
                }
                
            }
            string temp = operate;
            operate = ((Button)sender).Text;
            switch (operate)
            {
                case "+":
                case "-":
                case "X":
                case "÷":
                    firstOperand = lblDisplay.Text;
                    isAfterOperater = true;
                    break;
                

                                  
            }
            isAllowBack = false;
            isfirstOperater = true;
            containsDot = false;

        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            string secondOperand = lblDisplay.Text;
            string result = engine.calculate(operate, firstOperand, secondOperand);
            if (result is "E" || result.Length > 8)
            {
                lblDisplay.Text = "Error";
            }
            else
            {
                lblDisplay.Text = result;
            }
            isfirstOperater = false;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if (!containsDot)
            {
                lblDisplay.Text += ".";
                containsDot = true;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                resetAll();
            }
            // already contain negative sign
            if (lblDisplay.Text.Length is 8)
            {
                return;
            }
            if(lblDisplay.Text[0] is '-')
            {
                lblDisplay.Text = lblDisplay.Text.Substring(1, lblDisplay.Text.Length - 1);
            } else
            {
                lblDisplay.Text = "-" + lblDisplay.Text;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            resetAll();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            if (isAfterEqual)
            {
                return;
            }
            if (!isAllowBack)
            {
                return;
            }
            if(lblDisplay.Text != "0")
            {
                string current = lblDisplay.Text;
                char rightMost = current[current.Length - 1];
                if(rightMost is '.')
                {
                    containsDot = false;
                }
                lblDisplay.Text = current.Substring(0, current.Length - 1);
                if(lblDisplay.Text is "" || lblDisplay.Text is "-")
                {
                    lblDisplay.Text = "0";
                }
            }
        }

        private void MC_Click(object sender, EventArgs e)
        {
            memory = 0;
        }

        private void MR_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "error")
            {
                return;
            }
            lblDisplay.Text = memory.ToString();
        }

        private void MS_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            memory = Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }

        private void mPlus_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            memory += Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }

        private void mMinus_Click(object sender, EventArgs e)
        {
            if (lblDisplay.Text is "Error")
            {
                return;
            }
            memory -= Convert.ToDouble(lblDisplay.Text);
            isAfterOperater = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double result2;
            string[] parts2;
            int remainLength1 = 8;
            firstOperand = lblDisplay.Text;
            result2 = (1/Convert.ToDouble(firstOperand));
            parts2 = lblDisplay.Text.Split('.');
            if (parts2[0].Length > 8)
            {
                lblDisplay.Text = "Errorr";
            }
            
            remainLength1 = 8 - parts2[0].Length - 1;
            lblDisplay.Text = result2.ToString("N" + remainLength1);
            isAfterOperater = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            double result2;
            string[] parts2;
            int remainLength1 = 8;
            firstOperand = lblDisplay.Text;
            result2 = (Math.Pow(Convert.ToDouble(firstOperand), 0.5));
            parts2 = lblDisplay.Text.Split('.');
            if (parts2[0].Length > 8)
            {
                lblDisplay.Text = "Errorr";
            }

            remainLength1 = 8 - parts2[0].Length - 1;
            lblDisplay.Text = result2.ToString("N" + remainLength1);
            isAfterOperater = true;
        }

        private void btnPercent_Click(object sender, EventArgs e)
        {
            double result2;
            string[] parts2;
            int remainLength1 = 8;
            
            result2 = (Convert.ToDouble(firstOperand) * Convert.ToDouble(lblDisplay.Text) / 100);
            parts2 = lblDisplay.Text.Split('.');
            if (parts2[0].Length > 8)
            {
                lblDisplay.Text = "Errorr";
            }

            remainLength1 = 8 - parts2[0].Length - 1;
            lblDisplay.Text = result2.ToString("N" + remainLength1);
            isAfterOperater = true;
        }
    }
}
