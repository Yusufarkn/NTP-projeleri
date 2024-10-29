using System;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipespeed = 5;
        int gravity = 0;
        int score = 0;
        int highScore = 0; // En yüksek skor
        int pipeGap = 150;  // Borular arasındaki boşluk
        bool isGameStarted = false; // Oyun başlama durumu
        bool isGameOver = false;    // Oyun bitme durumu
        bool isPaused = false;      // Oyun duraklatıldı mı?
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();

            // Skor göstermek için label kontrolleri ekliyoruz
            labelScore.Text = "Score: 0";  // Skoru göstermek için
            labelHighScore.Text = "High Score: 0";  // En yüksek skoru göstermek için
        }

        private void GameTimerEvent(object sender, EventArgs e)
        {
            if (!isGameStarted || isPaused) return;

            pictureBox_flappyBird.Top += gravity;

            // Boruların hareketi
            pictureBox_pipeBottom.Left -= pipespeed;
            pictureBox_pipeTop.Left -= pipespeed;

            // Borular ekrandan çıktıktan sonra yeniden yerleştir
            if (pictureBox_pipeBottom.Left < -100)
            {
                NewPipe();
                score++;
                labelScore.Text = "Score: " + score.ToString();

                // En yüksek skoru güncelle ve görünürlüğü koru
                if (score > highScore)
                {
                    highScore = score;
                    labelHighScore.Text = "High Score: " + highScore.ToString();
                    labelHighScore.Visible = true;
                    labelHighScore.Refresh();  // Görünümünü güncelle
                }

                if (score % 5 == 0)
                {
                    pipespeed += 2;
                }
            }

            // Çarpma kontrolleri
            if (pictureBox_flappyBird.Bounds.IntersectsWith(pictureBox_pipeBottom.Bounds) ||
                pictureBox_flappyBird.Bounds.IntersectsWith(pictureBox_pipeTop.Bounds) ||
                pictureBox_flappyBird.Bounds.IntersectsWith(pictureBox_Ground.Bounds))
            {
                gameOver();
            }

            if (pictureBox_flappyBird.Top < -25)
            {
                gameOver();
            }
        }

        private void gameOver()
        {
            gameTimer.Stop();
            isGameStarted = false;
            isGameOver = true;
            gravity = 0;

            // En yüksek skor görünümünü koru
            if (score > highScore)
            {
                highScore = score;
                labelHighScore.Text = "High Score: " + highScore.ToString();
                labelHighScore.Visible = true;
            }

            MessageBox.Show("Game Over!\nYour Score: " + score.ToString() + "\nHigh Score: " + highScore.ToString(), "Game Over");
        }

        private void restartGame()
        {
            isGameStarted = false;
            isGameOver = false;
            score = 0;
            labelScore.Text = "Score: 0";
            labelHighScore.Text = "High Score: " + highScore.ToString();
            labelHighScore.Visible = true;
            labelHighScore.Refresh(); // Yenile

            pictureBox_flappyBird.Top = 250;
            pictureBox_pipeBottom.Left = 450;
            pictureBox_pipeTop.Left = 450;

            gravity = 0;
            pipespeed = 5;
            gameTimer.Start();
        }


        private void NewPipe()
        {
            int randomPipeHeight = rnd.Next(100, 250); // Üst borunun yüksekliği rastgele, ancak alt boruya boşluk kalmalı
            pictureBox_pipeTop.Height = randomPipeHeight;

            pictureBox_pipeTop.Left = 450;
            pictureBox_pipeTop.Top = 0;

            pictureBox_pipeBottom.Left = 450;
            pictureBox_pipeBottom.Top = randomPipeHeight + pipeGap;
            pictureBox_pipeBottom.Height = 500 - pictureBox_pipeBottom.Top;
        }

       
        private void game_Down(object sender, KeyEventArgs e)
        {
            if (isGameOver)
            {
                restartGame();
            }

            if (!isGameStarted && !isGameOver)
            {
                isGameStarted = true;
            }

            if (e.KeyCode == Keys.Space && isGameStarted && !isPaused)
            {
                gravity = -5;
            }

            if (e.KeyCode == Keys.Escape) // ESC tuşu basıldığında duraklat veya devam ettir
            {
                if (!isPaused)
                {
                    gameTimer.Stop();
                    isPaused = true;
                }
                else
                {
                    gameTimer.Start();
                    isPaused = false;
                }
            }
        }

        private void game_Up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && isGameStarted && !isPaused)
            {
                gravity = 5;
            }
        }
    }
}
