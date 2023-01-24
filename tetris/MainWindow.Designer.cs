namespace tetris
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.heightL = new System.Windows.Forms.Label();
            this.widthL = new System.Windows.Forms.Label();
            this.heightTB = new System.Windows.Forms.TextBox();
            this.widthTB = new System.Windows.Forms.TextBox();
            this.playB = new System.Windows.Forms.Button();
            this.createFigureB = new System.Windows.Forms.Button();
            this.stopBT = new System.Windows.Forms.Button();
            this.saveFigureB = new System.Windows.Forms.Button();
            this.RecL = new System.Windows.Forms.Label();
            this.RecP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(510, 492);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // heightL
            // 
            this.heightL.AutoSize = true;
            this.heightL.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.heightL.Location = new System.Drawing.Point(215, 72);
            this.heightL.Name = "heightL";
            this.heightL.Size = new System.Drawing.Size(58, 17);
            this.heightL.TabIndex = 1;
            this.heightL.Text = "Height";
            // 
            // widthL
            // 
            this.widthL.AutoSize = true;
            this.widthL.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.widthL.Location = new System.Drawing.Point(217, 114);
            this.widthL.Name = "widthL";
            this.widthL.Size = new System.Drawing.Size(56, 17);
            this.widthL.TabIndex = 2;
            this.widthL.Text = "Width";
            // 
            // heightTB
            // 
            this.heightTB.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.heightTB.Location = new System.Drawing.Point(273, 69);
            this.heightTB.Name = "heightTB";
            this.heightTB.Size = new System.Drawing.Size(37, 24);
            this.heightTB.TabIndex = 3;
            this.heightTB.Text = "20";
            this.heightTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.heightTB_KeyPress);
            // 
            // widthTB
            // 
            this.widthTB.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.widthTB.Location = new System.Drawing.Point(273, 111);
            this.widthTB.Name = "widthTB";
            this.widthTB.Size = new System.Drawing.Size(37, 24);
            this.widthTB.TabIndex = 4;
            this.widthTB.Text = "15";
            this.widthTB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.widthTB_KeyPress);
            // 
            // playB
            // 
            this.playB.BackColor = System.Drawing.Color.Yellow;
            this.playB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playB.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playB.Location = new System.Drawing.Point(215, 204);
            this.playB.Name = "playB";
            this.playB.Size = new System.Drawing.Size(95, 41);
            this.playB.TabIndex = 5;
            this.playB.Text = "Play";
            this.playB.UseVisualStyleBackColor = false;
            this.playB.Click += new System.EventHandler(this.playB_Click);
            // 
            // createFigureB
            // 
            this.createFigureB.BackColor = System.Drawing.Color.Yellow;
            this.createFigureB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createFigureB.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createFigureB.Location = new System.Drawing.Point(194, 275);
            this.createFigureB.Name = "createFigureB";
            this.createFigureB.Size = new System.Drawing.Size(139, 41);
            this.createFigureB.TabIndex = 6;
            this.createFigureB.Text = "Create figure";
            this.createFigureB.UseVisualStyleBackColor = false;
            this.createFigureB.Click += new System.EventHandler(this.createFigureB_Click);
            // 
            // stopBT
            // 
            this.stopBT.BackColor = System.Drawing.Color.Yellow;
            this.stopBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopBT.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.stopBT.Location = new System.Drawing.Point(194, 10);
            this.stopBT.Name = "stopBT";
            this.stopBT.Size = new System.Drawing.Size(139, 41);
            this.stopBT.TabIndex = 7;
            this.stopBT.Text = "Back";
            this.stopBT.UseVisualStyleBackColor = false;
            this.stopBT.Visible = false;
            this.stopBT.Click += new System.EventHandler(this.stopBT_Click);
            // 
            // saveFigureB
            // 
            this.saveFigureB.BackColor = System.Drawing.Color.Yellow;
            this.saveFigureB.Enabled = false;
            this.saveFigureB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveFigureB.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveFigureB.Location = new System.Drawing.Point(194, 449);
            this.saveFigureB.Name = "saveFigureB";
            this.saveFigureB.Size = new System.Drawing.Size(139, 41);
            this.saveFigureB.TabIndex = 8;
            this.saveFigureB.Text = "Save figure";
            this.saveFigureB.UseVisualStyleBackColor = false;
            this.saveFigureB.Visible = false;
            this.saveFigureB.Click += new System.EventHandler(this.saveFigureB_Click);
            // 
            // RecL
            // 
            this.RecL.AutoSize = true;
            this.RecL.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RecL.Location = new System.Drawing.Point(194, 429);
            this.RecL.Name = "RecL";
            this.RecL.Size = new System.Drawing.Size(95, 17);
            this.RecL.TabIndex = 9;
            this.RecL.Text = "Rectangles: ";
            this.RecL.Visible = false;
            // 
            // RecP
            // 
            this.RecP.AutoSize = true;
            this.RecP.Font = new System.Drawing.Font("Showcard Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.RecP.Location = new System.Drawing.Point(295, 429);
            this.RecP.Name = "RecP";
            this.RecP.Size = new System.Drawing.Size(30, 17);
            this.RecP.TabIndex = 10;
            this.RecP.Text = "0/8";
            this.RecP.Visible = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(534, 561);
            this.Controls.Add(this.RecP);
            this.Controls.Add(this.RecL);
            this.Controls.Add(this.saveFigureB);
            this.Controls.Add(this.stopBT);
            this.Controls.Add(this.createFigureB);
            this.Controls.Add(this.playB);
            this.Controls.Add(this.widthTB);
            this.Controls.Add(this.heightTB);
            this.Controls.Add(this.widthL);
            this.Controls.Add(this.heightL);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private Label heightL;
        private Label widthL;
        private TextBox heightTB;
        private TextBox widthTB;
        private Button playB;
        private Button createFigureB;
        private Button stopBT;
        private Button saveFigureB;
        private Label RecL;
        private Label RecP;
    }
}