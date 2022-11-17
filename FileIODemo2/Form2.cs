using System;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.IO;
using System.Xml.Serialization;



namespace FileIODemo2
{
    public partial class Form2 : Form
    {
        FileStream fs; 

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

       
        private void btnBinaryWrite_Click(object sender, EventArgs e)
        {
            try
            {
                fs = new FileStream(@"D:\Tesla\dept.dat", FileMode.Create, FileAccess.Write);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Department dept = new Department();
                dept.DeptId = Convert.ToInt32(txtId.Text);
                dept.DeptName = txtName.Text;
                dept.Location = txtLocation.Text;
                binaryFormatter.Serialize(fs, dept);
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
                fs = new FileStream(@"D:\Tesla\dept.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Department dept = new Department();
                dept = (Department)binaryFormatter.Deserialize(fs);
                txtId.Text = dept.DeptId.ToString();
                txtName.Text = dept.DeptName;
                txtLocation.Text = dept.Location;
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
                fs = new FileStream(@"D:\Tesla\dept.xml", FileMode.Create, FileAccess.Write);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));
                Department dept = new Department();
                dept.DeptId = Convert.ToInt32(txtId.Text);
                dept.DeptName = txtName.Text;
                dept.Location = txtLocation.Text;
                xmlSerializer.Serialize(fs, dept);
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
                fs = new FileStream(@"D:\Tesla\dept.xml", FileMode.Open, FileAccess.Read);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));
                Department dept = new Department();
                dept = (Department)xmlSerializer.Deserialize(fs);
                txtId.Text = dept.DeptId.ToString();
                txtName.Text = dept.DeptName;
                txtLocation.Text = dept.Location;
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
                fs = new FileStream(@"D:\Tesla\dept.soap", FileMode.Create, FileAccess.Write);
                SoapFormatter soapFormatter = new SoapFormatter();
                Department dept = new Department();
                dept.DeptId = Convert.ToInt32(txtId.Text);
                dept.DeptName = txtName.Text;
                dept.Location = txtLocation.Text;
                soapFormatter.Serialize(fs, dept);
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
                fs = new FileStream(@"D:\Tesla\dept.soap", FileMode.Open, FileAccess.Read);
                SoapFormatter soapFormatter = new SoapFormatter();
                Department dept = new Department();
                dept = (Department)soapFormatter.Deserialize(fs);
                txtId.Text = dept.DeptId.ToString();
                txtName.Text = dept.DeptName;
                txtLocation.Text = dept.Location;
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
                fs = new FileStream(@"D:\Tesla\dept.json", FileMode.Create, FileAccess.Write);
                Department dept = new Department();
                dept.DeptId = Convert.ToInt32(txtId.Text);
                dept.DeptName = txtName.Text;
                dept.Location = txtLocation.Text;
                JsonSerializer.Serialize<Department>(fs, dept);
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
                fs = new FileStream(@"D:\Tesla\dept.json", FileMode.Open, FileAccess.Read);
                Department dept = new Department();
                dept = JsonSerializer.Deserialize<Department>(fs);
                txtId.Text = dept.DeptId.ToString();
                txtName.Text = dept.DeptName;
                txtLocation.Text = dept.Location;
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
