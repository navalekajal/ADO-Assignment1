using System;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;


namespace FileIODemo2
{
    public partial class Form3 : Form
    {
        FileStream fs;
        public Form3()
        {
            InitializeComponent();
        }
        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.txt", FileMode.Create, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Student stud = new Student();
                stud.StudRollno = Convert.ToInt32(txtRollno.Text);
                stud.StudName = txtName.Text;
                stud.Percentage = txtPercentage.Text;
                binaryFormatter.Serialize(fs, stud);
                MessageBox.Show("Done !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnBinaryRead_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Student stud = new Student();
                stud = (Student)binaryFormatter.Deserialize(fs);
                txtRollno.Text = stud.StudRollno.ToString();
                txtName.Text = stud.StudName;
                txtPercentage.Text = stud.Percentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnXMLWrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
                Student stud = new Student();
                stud.StudRollno = Convert.ToInt32(txtRollno.Text);
                stud.StudName = txtName.Text;
                stud.Percentage = txtPercentage.Text;
                xmlSerializer.Serialize(fs, stud);
                MessageBox.Show("Done !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnXMLRead_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Student));
                Student stud = new Student();
                stud = (Student)xmlSerializer.Deserialize(fs);
                txtRollno.Text = stud.StudRollno.ToString();
                txtName.Text = stud.StudName;
                txtPercentage.Text = stud.Percentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnSOAPWrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.soap", FileMode.Create, FileAccess.Write);
                SoapFormatter soapFormatter = new SoapFormatter();
                Student stud = new Student();
                stud.StudRollno = Convert.ToInt32(txtRollno.Text);
                stud.StudName = txtName.Text;
                stud.Percentage = txtPercentage.Text;
                soapFormatter.Serialize(fs, stud);
                MessageBox.Show("Done !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnSOAPRead_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.soap", FileMode.Open, FileAccess.Read);
                SoapFormatter soapFormatter = new SoapFormatter();
                Student stud = new Student();
                stud = (Student)soapFormatter.Deserialize(fs);
                txtRollno.Text = stud.StudRollno.ToString();
                txtName.Text = stud.StudName;
                txtPercentage.Text = stud.Percentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnJSONWrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.json", FileMode.Create, FileAccess.Write);
                Student stud = new Student();
                stud.StudRollno = Convert.ToInt32(txtRollno.Text);
                stud.StudName = txtName.Text;
                stud.Percentage = txtPercentage.Text;
                JsonSerializer.Serialize<Student>(fs, stud);
                MessageBox.Show("Done !");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
        private void btnJSONRead_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\stud.json", FileMode.Open, FileAccess.Read);
                Student stud = new Student();
                stud = JsonSerializer.Deserialize<Student>(fs);
                txtRollno.Text = stud.StudRollno.ToString();
                txtName.Text = stud.StudName;
                txtPercentage.Text = stud.Percentage;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
            }
        }
    }
}
