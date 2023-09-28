using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace opakovani2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.CenterToScreen();
            this.ShowIcon = false;
            this.Text = "Ukol 2";
        }
        int[] pole;
        private void button1_Click(object sender, EventArgs e)
        {

           
            try
            {
                Random rng = new Random();
                int n = int.Parse(textBox1.Text);
                pole = new int[n];
                for (int i = 0; i < n; i++)
                {
                    pole[i] = rng.Next(1,26);                    
                }

               
                Vypis(listBox1, pole);
                
                int pozice = 0;
                string s;

                Array.Reverse(pole);
                //int prvocislo = PoslPrvocilo(ref pozice);
                // MessageBox.Show("Posledni prvocislo je: " + prvocislo + " na indexu: " + pozice);
                _ = PoslPrvocilo(ref pozice) == 0 ? s = "V poli se nenachazi zadne prvocislo" : s = String.Format("Posledni prvnocislo je {0} a je na indexu {1}", PoslPrvocilo(ref pozice),pozice);
                Array.Reverse(pole);

                MessageBox.Show(s);
                Vymen();

            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        void Vypis(ListBox listbox, int[] pole)
        {
            listbox.Items.Clear();
            foreach (int i in pole)
            {
                listbox.Items.Add(i);
            }
        }

        void Vymen()
        {
            int prvni = pole[0];
            int posledni = pole[pole.Length-1];
            pole[0] = posledni;
            pole[pole.Length - 1] = prvni;
            Vypis(listBox2, pole);
        }

        int PoslPrvocilo(ref int pozice)
        {
            
            for (int i = 0; i < pole.Length;i++)
            {
                bool skip = false;
                pozice = pole.Length-1-i;
                int cislo = pole[i];
                if (cislo == 2) return cislo;
                else if (cislo % 2 == 0 || cislo == 1) continue;
                else
                {
                    for (int j = 3; j <= (cislo)/2; j += 2)
                    {
                        if (cislo % j == 0)
                        {                            
                            skip = true;
                            break;
                        }
                    }

                }
                if (skip) continue;
                return cislo;                 
            }
            return 0;
            
        }

        string Maximalni(string s)
        {
            while (s.Contains("  ")) s = s.Replace("  ", " ");
            if (s == " " || s== "") return "Špatný vstup";
            string[] pole = s.Split(' ');

            return "Nejdelsi prvek: "+ pole.OrderByDescending(x => x.Length).First();
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
             MessageBox.Show(Maximalni(textBox2.Text));
        
        }
    }
}
