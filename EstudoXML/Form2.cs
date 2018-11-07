using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace EstudoXML
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            lblTitulo.Text = CarregarTitulo();
        }

        private string CarregarTitulo()
        {
            XmlDocument documentoXML = new XmlDocument();

            documentoXML.Load(@"C:\Users\Patty\Google Drive\Treinamento C#\TelasProjeto02\EstudoXML\Agenda.xml");

            XmlNode noTitulo = documentoXML.SelectSingleNode("/agenda/titulo");

            return noTitulo.InnerText;
        }
    }
}
