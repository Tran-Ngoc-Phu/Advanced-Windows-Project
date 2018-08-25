using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Threading;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {

        List<Image> ListImage = new List<Image>();
        
        int[] numbers = { 0, 0, 1, 1, 2, 2, 3, 3 };

        int _countReveal = 0;
        Button FirstReveal = new Button();
        Button SecondReveal = new Button();
        int delayRevealingCard = 500;
        int _score = 0;
        int _card_number = 8;

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadListImage()
        {
            ListImage.Add(WindowsFormsApplication2.Properties.Resources.crescent_symbol);
            ListImage.Add(WindowsFormsApplication2.Properties.Resources.diamond_symbol);
            ListImage.Add(WindowsFormsApplication2.Properties.Resources.heart_symbol);
            ListImage.Add(WindowsFormsApplication2.Properties.Resources.square_symbol);
        }

        private void MultiplyButton()
        {
            int _khoang_cach_hang = 190;
            int _khoang_cach_cot = 130;
            int _hang = 100;
            int _cot = 20;
            int _so_hang = 2;
            int _so_cot = 4;

            numbers = ShuffleArray(numbers);
            
            for (int _so_thu_tu_hang = 0; _so_thu_tu_hang < _so_hang; _so_thu_tu_hang++)
            {
                if (_card_number == 0) break;
                for (int _so_thu_tu_cot = 0; _so_thu_tu_cot < _so_cot; _so_thu_tu_cot++)
                {
                    Button card = new System.Windows.Forms.Button();
                    card.Location = new System.Drawing.Point(_cot + _khoang_cach_cot * _so_thu_tu_cot, _hang);

                    card.Name =  (_so_cot * _so_thu_tu_hang + _so_thu_tu_cot).ToString();
                    card.Size = new System.Drawing.Size(111, 151);
                    card.TabIndex = 0;
                    card.UseVisualStyleBackColor = true;

                    card.MouseDown += new System.Windows.Forms.MouseEventHandler(card_MouseDown);
                    card.MouseUp += new System.Windows.Forms.MouseEventHandler(card_MouseUp);
                    card.Image = WindowsFormsApplication2.Properties.Resources.card_back;
                    this.Controls.Add(card);

                    _card_number--;
                }
                _hang += _khoang_cach_hang * (_so_thu_tu_hang + 1);

            }
        }

        private void card_MouseDown(object sender, MouseEventArgs e)
        {
            if (_countReveal != 2)
            {
                int cardNumber = Convert.ToInt32(((Button)sender).Name);
                ((Button)sender).Image = ListImage[numbers[cardNumber]];
                if (_countReveal == 0)
                {
                    FirstReveal.Name = ((Button)sender).Name;
                    FirstReveal.Image = ((Button)sender).Image;
                    _countReveal++;
                }
                else if (_countReveal == 1)
                {
                    SecondReveal.Name = ((Button)sender).Name;
                    SecondReveal.Image = ((Button)sender).Image;
                    _countReveal++;
                }
            }
        }

        private void card_MouseUp(object sender, MouseEventArgs e)
        {
            if (_countReveal == 2)
            {
                Thread.Sleep(delayRevealingCard);

                if (FirstReveal.Image == SecondReveal.Image)
                {
                    _score++;
                    this.Score.Text = "SCORE: " + (_score).ToString();
                    foreach (Control card in Controls)
                    {
                        if (card.Name == FirstReveal.Name) this.Controls.Remove(card);                        
                    }
                    foreach (Control card in Controls)
                    {
                        if (card.Name == SecondReveal.Name) this.Controls.Remove(card);
                    }
                }
                else
                {
                    foreach (Control card in Controls)
                    {
                        if (card.Name == FirstReveal.Name) ((Button)card).Image = WindowsFormsApplication2.Properties.Resources.card_back;
                        if (card.Name == SecondReveal.Name) ((Button)card).Image = WindowsFormsApplication2.Properties.Resources.card_back;
                    }
                }
                _countReveal = 0;
            }
        }

        private int[] ShuffleArray(int[] numbers)
        {
            int[] newArray = numbers.Clone() as int[];
            for (int i = 0; i < newArray.Count(); i++)
            {
                int tmp = newArray[i];
                Random rand = new Random();
                int r = rand.Next(0, newArray.Length);
                newArray[i] = newArray[r];
                newArray[r] = tmp;
            }
            return newArray;
        }        
                
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadListImage();                     
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            foreach (Control card in Controls)
            {
                if (card.Name != "StartButton" && card.Name != "Score") this.Controls.Remove(card);
            }

            MultiplyButton();

            this.Score.Text = "SCORE: ";
            _score = 0;
        }           
    }
}
