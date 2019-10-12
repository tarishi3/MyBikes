using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using System.Xml;
using System.Xml.Serialization;
using MyBikes_1830508.Bus;

namespace MyBikes_1830508
{
    public partial class Form1 : Form
    {
        List<Bicycle> myBicycleList = new List<Bicycle>();       
        List<Bicycle> roadBicycleList = new List<Bicycle>();
        List<Bicycle> mountainBicycleList = new List<Bicycle>();
        List<Bicycle> xmlBicycleList = new List<Bicycle>();
        int index;
        int mountainindex;
        int roadindex;
       
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (EnumRimType element in Enum.GetValues(typeof(EnumRimType)))
            {
                comboBoxRimType.Items.Add(element);
            }
            comboBoxRimType.Text = Convert.ToString(comboBoxRimType.Items[0]);

            foreach (EnumSusType element in Enum.GetValues(typeof(EnumSusType)))
            {
                comboBoxSusType.Items.Add(element);
            }
            comboBoxSusType.Text = Convert.ToString(comboBoxSusType.Items[0]);

            foreach (EnumModelType element in Enum.GetValues(typeof(EnumModelType)))
            {
                comboBoxModelType.Items.Add(element);
            }
            comboBoxModelType.Text = Convert.ToString(comboBoxModelType.Items[0]);

            foreach (EnumColor element in Enum.GetValues(typeof(EnumColor)))
            {
                comboBoxColor.Items.Add(element);
            }
            comboBoxColor.Text = Convert.ToString(comboBoxColor.Items[0]);
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonWrteXML_Click(object sender, EventArgs e)
        {
            FileHandler fh = new FileHandler();
            FileHandler.WriteToXmlFile(this.myBicycleList);
        }

        private void buttonReadXML_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Enabled = false;
            xmlBicycleList.Clear();            
            this.xmlBicycleList = FileHandler.ReadFromXmlFile();
            foreach (Bicycle item in xmlBicycleList)
            {
                this.listBox1.Items.Add(item);
            }           
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Bicycle cycle = new Bicycle();

            if (comboBoxModelType.Text == "Mountain_Bikes")
            {                
                cycle.Serial = Convert.ToInt32(textBoxSerialNo.Text);
                cycle.Madeby = textBoxMadeBy.Text;
                cycle.Price = Convert.ToDouble(textBoxPrice.Text);
                cycle.Speed = Convert.ToInt32(textBoxSpeed.Text);
                cycle.Color = (EnumColor)comboBoxColor.SelectedIndex;
                Date dt = new Date();
                dt.Day = Convert.ToInt32(this.textBoxDay.Text);
                dt.Month = Convert.ToInt32(this.textBoxMonth.Text);
                dt.Year = Convert.ToInt32(this.textBoxYear.Text);
                cycle.MadeDate = dt;
                cycle.RimType = (EnumRimType)comboBoxRimType.SelectedIndex;
                cycle.SuspType = (EnumSusType)comboBoxSusType.SelectedIndex;
                cycle.Model = (EnumModelType)comboBoxModelType.SelectedIndex;                
                cycle.GroundClearance = Convert.ToDouble(textBoxGroundCl.Text);
                this.myBicycleList.Add(cycle);                
                this.mountainBicycleList.Add(cycle);
                
            }           
            
            if (comboBoxModelType.Text == "Road_Bikes")
            {                
                cycle.Serial = Convert.ToInt32(textBoxSerialNo.Text);
                cycle.Madeby = textBoxMadeBy.Text;
                cycle.Price = Convert.ToDouble(textBoxPrice.Text);
                cycle.Speed = Convert.ToInt32(textBoxSpeed.Text);
                cycle.Color = (EnumColor)comboBoxColor.SelectedIndex;
                Date dt = new Date();
                dt.Day = Convert.ToInt32(this.textBoxDay.Text);
                dt.Month = Convert.ToInt32(this.textBoxMonth.Text);
                dt.Year = Convert.ToInt32(this.textBoxYear.Text);
                cycle.MadeDate = dt;
                cycle.RimType = (EnumRimType)comboBoxRimType.SelectedIndex;               
                cycle.Model = (EnumModelType)comboBoxModelType.SelectedIndex;
                cycle.SeatHeight = Convert.ToDouble(textBoxSeatHeight.Text);
                cycle.GroundClearance = Convert.ToDouble(textBoxGroundCl.Text);
                this.myBicycleList.Add(cycle);              
                this.roadBicycleList.Add(cycle);
            }
            this.buttonAdd.Enabled = false;
        }


        private void comboBoxModelType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxModelType.Text == "Mountain_Bikes")
            {
                textBoxSeatHeight.Enabled = false;
                comboBoxSusType.Enabled = true;
                buttonRoadBikes.Enabled = false;
                buttonDispMountBikes.Enabled = true;
            }
            if (comboBoxModelType.Text == "Road_Bikes")
            {
                comboBoxSusType.Enabled = false;
                textBoxSeatHeight.Enabled = true;
                buttonRoadBikes.Enabled = true;
                buttonDispMountBikes.Enabled = false;
            }
        }

        private void buttonDisplay_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Enabled = true;
            buttonAdd.Enabled = false;
            if (this.myBicycleList.Capacity != 0)
            {
                foreach (Bicycle item in this.myBicycleList)
                {
                    this.listBox1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("...NO DATA.....");
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            textBoxSerialNo.Text = "";
            textBoxMadeBy.Text = "";
            textBoxPrice.Text = "";
            textBoxSpeed.Text = "";
            comboBoxModelType.Text = Convert.ToString(EnumModelType.Undefined);
            comboBoxSusType.Text = Convert.ToString(EnumSusType.Not_Applicable);
            comboBoxColor.Text = Convert.ToString(EnumColor.Undefined);
            comboBoxRimType.Text = Convert.ToString(EnumRimType.Undefined);
            textBoxDay.Text = "";
            textBoxMonth.Text = "";
            textBoxYear.Text = "";
            textBoxSeatHeight.Text = "";
            textBoxGroundCl.Text = "";
            listBox1.Items.Clear();
            this.buttonAdd.Enabled = true;
            comboBoxSusType.Enabled = true;
            textBoxSeatHeight.Enabled = true;
            textBoxSerialNo.Enabled = true;
            comboBoxModelType.Enabled = true;
            buttonRoadBikes.Enabled = true;
            buttonDispMountBikes.Enabled = true;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hi!.. We are updating the record : " + index);
           
            this.myBicycleList[index].Serial = Convert.ToInt32(textBoxSerialNo.Text);
            this.myBicycleList[index].Madeby = textBoxMadeBy.Text;
            this.myBicycleList[index].Price = Convert.ToDouble(textBoxPrice.Text);
            this.myBicycleList[index].Speed = Convert.ToInt32(textBoxSpeed.Text);
            this.myBicycleList[index].Color = (EnumColor)comboBoxColor.SelectedIndex;
            this.myBicycleList[index].MadeDate.Day = Convert.ToInt32(this.textBoxDay.Text);
            this.myBicycleList[index].MadeDate.Month = Convert.ToInt32(this.textBoxMonth.Text);
            this.myBicycleList[index].MadeDate.Year = Convert.ToInt32(this.textBoxYear.Text);
            this.myBicycleList[index].RimType = (EnumRimType)comboBoxRimType.SelectedIndex;
            this.myBicycleList[index].SuspType = (EnumSusType)comboBoxSusType.SelectedIndex;
            this.myBicycleList[index].Model = (EnumModelType)comboBoxModelType.SelectedIndex;
            this.myBicycleList[index].GroundClearance = Convert.ToDouble(textBoxGroundCl.Text);
            this.myBicycleList[index].SeatHeight = Convert.ToDouble(textBoxSeatHeight.Text);
            MessageBox.Show("Bi-Cycle Record is now Updated.");              

                foreach (Bicycle cycle in this.myBicycleList)
                {
                    this.listBox1.Items.Add(cycle);
                }
                buttonWrteXML_Click(sender, e);
           
            this.listBox1.Items.Clear();            
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.myBicycleList.RemoveAt(index);

            MessageBox.Show("The entry deleted can be still found in their respective type of lists.");
            this.listBox1.Items.Clear();
            foreach (Bicycle cycle in this.myBicycleList)
            {
                this.listBox1.Items.Add(cycle);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            index = listBox1.SelectedIndex;
            //mountainindex = listBox1.SelectedIndex;
            //roadindex = listBox1.SelectedIndex;
            MessageBox.Show("selected index: " + index);
            textBoxSerialNo.Text = Convert.ToString(this.myBicycleList[index].Serial);
            textBoxMadeBy.Text = this.myBicycleList[index].Madeby;
            textBoxPrice.Text = Convert.ToString(this.myBicycleList[index].Price);
            textBoxSpeed.Text = Convert.ToString(this.myBicycleList[index].Speed);
            comboBoxModelType.Text = Convert.ToString(this.myBicycleList[index].Model);
            comboBoxSusType.Text = Convert.ToString(this.myBicycleList[index].SuspType);
            comboBoxColor.Text = Convert.ToString(this.myBicycleList[index].Color);
            comboBoxRimType.Text = Convert.ToString(this.myBicycleList[index].RimType);
            textBoxDay.Text = Convert.ToString(this.myBicycleList[index].MadeDate.Day);
            textBoxMonth.Text = Convert.ToString(this.myBicycleList[index].MadeDate.Month);
            textBoxYear.Text = Convert.ToString(this.myBicycleList[index].MadeDate.Year);
            textBoxSeatHeight.Text = Convert.ToString(this.myBicycleList[index].SeatHeight);
            textBoxGroundCl.Text = Convert.ToString(this.myBicycleList[index].GroundClearance);
            textBoxSerialNo.Enabled = false;
            comboBoxModelType.Enabled = false;           
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            bool found = false;
            Bicycle thecycle = new Bicycle();

            foreach (Bicycle element in this.myBicycleList)
            {
                if (element.Serial == Convert.ToInt32(textBoxSearch.Text))
                {
                    found = true;
                    thecycle = element;
                }
            }
            if (found)
            {
                MessageBox.Show("..Bi-Cycle Found..." + thecycle);
            }
            else
            {
                MessageBox.Show("..Bi-Cycle NOT Found...");
            }
        }

        private void buttonDispMountBikes_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Enabled = false;
            if (this.mountainBicycleList.Capacity != 0)
            {
                foreach (Bicycle item in this.mountainBicycleList)
                {
                    this.listBox1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("...NO DATA.....");
            }
        }

        private void buttonRoadBikes_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Enabled = false;
            if (this.roadBicycleList.Capacity != 0)
            {
                foreach (Bicycle item in this.roadBicycleList)
                {
                    this.listBox1.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("...NO DATA.....");
            }
        }

        private void textBoxSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxMadeBy_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back);
        }

        private void textBoxPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxDay_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxMonth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxGroundCl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxSeatHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
           (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
          (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}
