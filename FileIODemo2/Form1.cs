﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FileIODemo2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        FileStream fs;
        BinaryWriter bw;
        BinaryReader br;


        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {

            try
            {
                fs = new FileStream(@"D:\Tesla\emp.dat", FileMode.Create, FileAccess.Write);
                bw = new BinaryWriter(fs);
                bw.Write(Convert.ToInt32(txtId.Text));
                bw.Write(txtName.Text);
                bw.Write(Convert.ToDouble(txtSalary.Text));
                MessageBox.Show("Data added to file");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                bw.Close();
                fs.Close();
            }

        }

        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\emp.dat", FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                txtId.Text = br.ReadInt32().ToString();
                txtName.Text = br.ReadString();
                txtSalary.Text = br.ReadDouble().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                br.Close();
                fs.Close();
            }

        }

        private void btnCreateFloder_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\Tesla";
                if (Directory.Exists(path))
                {
                    MessageBox.Show("Folder exists");
                }
                else
                {
                    Directory.CreateDirectory(path);
                    MessageBox.Show("Folder created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCreateFile_Click(object sender, EventArgs e)
        {
            try
            {
                string path = @"D:\Tesla\sample.txt";
                if (File.Exists(path))
                {
                    MessageBox.Show("File exits");
                }
                else
                {
                    File.Create(path);
                    MessageBox.Show("File created");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        StreamWriter sw;
        StreamReader sr;

        private void btnStreamWrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\testFile.txt", FileMode.Create, FileAccess.Write);
                sw = new StreamWriter(fs);
                sw.WriteLine(richTextBox1.Text);
                MessageBox.Show("Done !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }

        }

        private void btnStreamRead_Click(object sender, EventArgs e)
        {

            try
            {
                fs = new FileStream(@"D:\Tesla\testFile.txt", FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                richTextBox1.Text = sr.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sr.Close();
                fs.Close();
            }

        }
    }
}
