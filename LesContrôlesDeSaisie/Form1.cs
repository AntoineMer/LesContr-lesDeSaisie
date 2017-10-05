using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace LesContrôlesDeSaisie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_Valider_Click(object sender, EventArgs e)
        {
            MessageBox.Show(textBoxNom.Text + textBoxDate.Text + textBoxMt.Text + textBoxCP.Text);
        }

        private void Btn_Effacer_Click(object sender, EventArgs e)
        {
            textBoxCP.Clear();
            textBoxDate.Clear();
            textBoxMt.Clear();
            textBoxNom.Clear();
        }

        private void textBoxNom_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^([a-zA-Z\\s-])+$");
            if (!reg.IsMatch(textBoxNom.Text))
            {
                errorProvider1.SetError(textBoxNom, "Erreur");
                textBoxNom.BackColor = Color.Red;
                textBoxNom.Focus();
            }
            else
            {
                textBoxNom.BackColor = Color.GreenYellow;
                
            }
    
        }

        private void textBoxDate_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^([0-9]{2}(/|-)[0-9]{2}(/|-)[0-9]{4})$");
            DateTime test = new DateTime();
            if ((!reg.IsMatch(textBoxDate.Text))
                || (!DateTime.TryParse(textBoxDate.Text, out test))
                || (DateTime.Today > test)
                )
            {
                errorProvider2.SetError(textBoxDate, "Erreur de format ! Date incorrecte !");
                textBoxDate.BackColor = Color.Red;
                textBoxDate.Focus();
            }
            else
            {
                errorProvider2.Clear();
                textBoxDate.BackColor = Color.GreenYellow;
            }
        }

        private void textBoxMt_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^([0-9]+)([(\\.|\\,)]?)([0-9]+)$");
            if (!reg.IsMatch(textBoxMt.Text))
            {
                errorProvider3.SetError(textBoxMt, "Montant non valide");
                textBoxMt.BackColor = Color.Red;
                textBoxMt.Focus();
            }
            else
            {
                errorProvider3.Clear();
                textBoxMt.BackColor = Color.GreenYellow;
            }
        }

        private void textBoxCP_TextChanged(object sender, EventArgs e)
        {
            Regex reg = new Regex("^([0-9]{5})$");
            if (!reg.IsMatch(textBoxCP.Text))
            {
                errorProvider4.SetError(textBoxCP, "Format du code postal non valide !");
                textBoxCP.BackColor = Color.Red;
                textBoxCP.Focus();
            }
            else
            {
                errorProvider4.Clear();
                textBoxCP.BackColor = Color.GreenYellow;
            }
        }
    }
}
