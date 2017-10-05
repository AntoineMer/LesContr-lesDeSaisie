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
        bool greenTestName, greenTestDate, greenTestMt, greenTestCp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Verif();
        }

        private void Btn_Valider_Click(object sender, EventArgs e)
        {

            MessageBoxButtons btn = MessageBoxButtons.OK;
            MessageBox.Show("Nom : " + textBoxNom.Text + "\nDate : " + textBoxDate.Text + "\nMontant : " + textBoxMt.Text + "\nCode : " + textBoxCP.Text, "Validation effectuée", btn);

        }

        private void Btn_Effacer_Click(object sender, EventArgs e)
        {
            textBoxCP.Clear();
            textBoxDate.Clear();
            textBoxMt.Clear();
            textBoxNom.Clear();
            Verif();
        }

        private void textBoxNom_TextChanged(object sender, EventArgs e)
        {
            
            Regex reg = new Regex("^([a-zA-Z\\s-])+$");
            if (!reg.IsMatch(textBoxNom.Text))
            {
                greenTestName = false;
                errorProvider1.SetError(textBoxNom, "Erreur");
                textBoxNom.BackColor = Color.Red;
                textBoxNom.Focus();
                
            }
            else
            {
                greenTestName = true;
                textBoxNom.BackColor = Color.GreenYellow;
                
            }
            Verif();
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
                greenTestDate = false;
                errorProvider2.SetError(textBoxDate, "Erreur de format ! Date incorrecte !");
                textBoxDate.BackColor = Color.Red;
                textBoxDate.Focus();
            }
            else
            {
                greenTestDate = true;
                errorProvider2.Clear();
                textBoxDate.BackColor = Color.GreenYellow;
           
            }
            Verif();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {

            MessageBoxButtons btn2 = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Fin de l'application", "FIN", btn2, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void textBoxMt_TextChanged(object sender, EventArgs e)
        {
            
            Regex reg = new Regex("^([0-9]+)([(\\.|\\,)]?)([0-9]+)$");
            if (!reg.IsMatch(textBoxMt.Text))
            {
                greenTestMt = false;
                errorProvider3.SetError(textBoxMt, "Montant non valide");
                textBoxMt.BackColor = Color.Red;
                textBoxMt.Focus();
            }
            else
            {
                greenTestMt = true;
                errorProvider3.Clear();
                textBoxMt.BackColor = Color.GreenYellow;

            }
            Verif();
        }

        private void textBoxCP_TextChanged(object sender, EventArgs e)
        {
            
            Regex reg = new Regex("^([0-9]{5})$");
            if (!reg.IsMatch(textBoxCP.Text))
            {
                greenTestCp = false;
                errorProvider4.SetError(textBoxCP, "Format du code postal non valide !");
                textBoxCP.BackColor = Color.Red;
                textBoxCP.Focus();
            }
            else
            {
                greenTestCp = true;
                errorProvider4.Clear();
                textBoxCP.BackColor = Color.GreenYellow;
            }
            Verif();
        }
        private void Verif()
        {
            Btn_Valider.Enabled = false;
            if (greenTestName
                && greenTestDate
                && greenTestMt
                && greenTestCp
                )
            {
                Btn_Valider.Enabled = true;
            }
            else
                Btn_Valider.Enabled = false;
        }
    }
}
