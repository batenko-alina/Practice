using System;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            getCurrenciesToday();
        }

        private void getCurrenciesToday()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange");
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                string currency="";
                string rate="";
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел -text
                    if (childnode.Name == "txt")
                    {
                        currency=childnode.InnerText;
                    }
                    // если узел rate
                    if (childnode.Name == "rate")
                    {
                        rate=childnode.InnerText;                    }
                }
                dataGridView1.Rows.Add(currency, rate);


            }
        }
        private void getCurrenciesForDate()
        {
            string url = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date=";
            var date = dateTimePicker1.Value;
            string day = date.Day.ToString();
            string month = date.Month.ToString();
            if (date.Day < 10)
                day = "0" + date.Day.ToString();
            if (date.Month < 10)
                month = "0" + date.Month.ToString();
            url += date.Year.ToString()+ month + day;
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(url);
            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;
            // обход всех узлов в корневом элементе
            foreach (XmlNode xnode in xRoot)
            {
                string currency = "";
                string rate = "";
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    // если узел -text
                    if (childnode.Name == "txt")
                    {
                        currency = childnode.InnerText;
                    }
                    // если узел rate
                    if (childnode.Name == "rate")
                    {
                        rate = childnode.InnerText;
                    }
                }
                dataGridView1.Rows.Add(currency, rate);


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            getCurrenciesForDate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            getCurrenciesToday();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
