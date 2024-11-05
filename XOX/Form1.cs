using System;
using System.Windows.Forms;

namespace XOX
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X, false = O
        int turnCount = 0; // hamle sayısı

        public Form1()
        {
            InitializeComponent();
            label_SıraKimde.Text = "Sıra: X";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ButtonClick(btn1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ButtonClick(btn2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ButtonClick(btn3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ButtonClick(btn4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ButtonClick(btn5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ButtonClick(btn6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ButtonClick(btn7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ButtonClick(btn8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ButtonClick(btn9);
        }

        private void ButtonClick(Button button)
        {
            // X veya O yerleştirme
            if (turn)
                button.Text = "X";
            else
                button.Text = "O";

            // Sıra değişimi ve hamle sayısını arttırma
            turn = !turn;
            button.Enabled = false;
            turnCount++;

            label_SıraKimde.Text = turn ? "Sıra: X" : "Sıra: O";

            // Kazanan kontrolü
            CheckForWinner();
        }

        private void CheckForWinner()
        {
            bool thereIsAWinner = false;
            string currentPlayer = turn ? "O" : "X"; // Çünkü hamleden sonra sıradaki oyuncu değişir

            // Kazanma kombinasyonları
            if ((btn1.Text == currentPlayer && btn2.Text == currentPlayer && btn3.Text == currentPlayer) ||
                (btn4.Text == currentPlayer && btn5.Text == currentPlayer && btn6.Text == currentPlayer) ||
                (btn7.Text == currentPlayer && btn8.Text == currentPlayer && btn9.Text == currentPlayer) ||
                (btn1.Text == currentPlayer && btn4.Text == currentPlayer && btn7.Text == currentPlayer) ||
                (btn2.Text == currentPlayer && btn5.Text == currentPlayer && btn8.Text == currentPlayer) ||
                (btn3.Text == currentPlayer && btn6.Text == currentPlayer && btn9.Text == currentPlayer) ||
                (btn1.Text == currentPlayer && btn5.Text == currentPlayer && btn9.Text == currentPlayer) ||
                (btn3.Text == currentPlayer && btn5.Text == currentPlayer && btn7.Text == currentPlayer))
            {
                thereIsAWinner = true;
            }

            if (thereIsAWinner)
            {
                DisableButtons();
                MessageBox.Show(currentPlayer + " Kazandı!", "Oyun Bitti");
            }
            else if (turnCount == 9)
            {
                MessageBox.Show("Berabere!", "Oyun Bitti");
            }
        }

        private void DisableButtons()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
        }

        private void ResetGame()
        {
            turn = true;
            turnCount = 0;
            label_SıraKimde.Text = "Sıra: X";

            btn1.Enabled = true; btn1.Text = "";
            btn2.Enabled = true; btn2.Text = "";
            btn3.Enabled = true; btn3.Text = "";
            btn4.Enabled = true; btn4.Text = "";
            btn5.Enabled = true; btn5.Text = "";
            btn6.Enabled = true; btn6.Text = "";
            btn7.Enabled = true; btn7.Text = "";
            btn8.Enabled = true; btn8.Text = "";
            btn9.Enabled = true; btn9.Text = "";
        }

        private void Button_YndnBşlt_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
    }
}
