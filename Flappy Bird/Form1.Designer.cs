namespace Flappy_Bird
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox_Ground = new System.Windows.Forms.PictureBox();
            this.pictureBox_pipeBottom = new System.Windows.Forms.PictureBox();
            this.pictureBox_flappyBird = new System.Windows.Forms.PictureBox();
            this.pictureBox_pipeTop = new System.Windows.Forms.PictureBox();
            this.labelScore = new System.Windows.Forms.Label();
            this.labelHighScore = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Ground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pipeBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_flappyBird)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pipeTop)).BeginInit();
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimerEvent);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Flappy_Bird.Properties.Resources.GroundTop;
            this.pictureBox2.Location = new System.Drawing.Point(0, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(584, 500);
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox_Ground
            // 
            this.pictureBox_Ground.Image = global::Flappy_Bird.Properties.Resources.Groundd;
            this.pictureBox_Ground.Location = new System.Drawing.Point(0, 498);
            this.pictureBox_Ground.Name = "pictureBox_Ground";
            this.pictureBox_Ground.Size = new System.Drawing.Size(584, 54);
            this.pictureBox_Ground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Ground.TabIndex = 14;
            this.pictureBox_Ground.TabStop = false;
            // 
            // pictureBox_pipeBottom
            // 
            this.pictureBox_pipeBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pictureBox_pipeBottom.Image = global::Flappy_Bird.Properties.Resources.pipeeDown1;
            this.pictureBox_pipeBottom.Location = new System.Drawing.Point(362, 372);
            this.pictureBox_pipeBottom.Name = "pictureBox_pipeBottom";
            this.pictureBox_pipeBottom.Size = new System.Drawing.Size(100, 180);
            this.pictureBox_pipeBottom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_pipeBottom.TabIndex = 15;
            this.pictureBox_pipeBottom.TabStop = false;
            // 
            // pictureBox_flappyBird
            // 
            this.pictureBox_flappyBird.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_flappyBird.Image = global::Flappy_Bird.Properties.Resources.Flappyy_Bird1;
            this.pictureBox_flappyBird.Location = new System.Drawing.Point(30, 250);
            this.pictureBox_flappyBird.Name = "pictureBox_flappyBird";
            this.pictureBox_flappyBird.Size = new System.Drawing.Size(50, 50);
            this.pictureBox_flappyBird.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_flappyBird.TabIndex = 16;
            this.pictureBox_flappyBird.TabStop = false;
            // 
            // pictureBox_pipeTop
            // 
            this.pictureBox_pipeTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.pictureBox_pipeTop.Image = global::Flappy_Bird.Properties.Resources.pipeTopp1;
            this.pictureBox_pipeTop.Location = new System.Drawing.Point(362, 1);
            this.pictureBox_pipeTop.Name = "pictureBox_pipeTop";
            this.pictureBox_pipeTop.Size = new System.Drawing.Size(100, 200);
            this.pictureBox_pipeTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_pipeTop.TabIndex = 17;
            this.pictureBox_pipeTop.TabStop = false;
            // 
            // labelScore
            // 
            this.labelScore.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelScore.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelScore.Location = new System.Drawing.Point(27, 9);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(100, 23);
            this.labelScore.TabIndex = 11;
            // 
            // labelHighScore
            // 
            this.labelHighScore.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.labelHighScore.Font = new System.Drawing.Font("Arial Narrow", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHighScore.Location = new System.Drawing.Point(27, 52);
            this.labelHighScore.Name = "labelHighScore";
            this.labelHighScore.Size = new System.Drawing.Size(100, 23);
            this.labelHighScore.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.labelHighScore);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBox_pipeTop);
            this.Controls.Add(this.pictureBox_flappyBird);
            this.Controls.Add(this.pictureBox_pipeBottom);
            this.Controls.Add(this.pictureBox_Ground);
            this.Controls.Add(this.pictureBox2);
            this.Name = "Form1";
            this.Text = "Flappy Bird";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.game_Down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.game_Up);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Ground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pipeBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_flappyBird)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_pipeTop)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox_Ground;
        private System.Windows.Forms.PictureBox pictureBox_pipeBottom;
        private System.Windows.Forms.PictureBox pictureBox_flappyBird;
        private System.Windows.Forms.PictureBox pictureBox_pipeTop;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Label labelHighScore;
    }
}

