namespace SimpleDJ2
{
    partial class DJForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.deckAOsc = new System.Windows.Forms.PictureBox();
            this.faderDeckA = new System.Windows.Forms.TrackBar();
            this.faderDeckB = new System.Windows.Forms.TrackBar();
            this.deckBOsc = new System.Windows.Forms.PictureBox();
            this.crossFader = new System.Windows.Forms.TrackBar();
            this.playlistBox = new System.Windows.Forms.ListBox();
            this.loadDeckA = new System.Windows.Forms.Button();
            this.loadDeckB = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.playDeckA = new System.Windows.Forms.Button();
            this.playDeckB = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.deckALabel = new System.Windows.Forms.Label();
            this.deckBLabel = new System.Windows.Forms.Label();
            this.dlg = new System.Windows.Forms.OpenFileDialog();
            this.slg = new System.Windows.Forms.SaveFileDialog();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeDeckA = new System.Windows.Forms.Label();
            this.timeDeckB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.deckAOsc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faderDeckA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.faderDeckB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckBOsc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossFader)).BeginInit();
            this.SuspendLayout();
            // 
            // deckAOsc
            // 
            this.deckAOsc.BackColor = System.Drawing.Color.Black;
            this.deckAOsc.Location = new System.Drawing.Point(9, 44);
            this.deckAOsc.Name = "deckAOsc";
            this.deckAOsc.Size = new System.Drawing.Size(320, 116);
            this.deckAOsc.TabIndex = 0;
            this.deckAOsc.TabStop = false;
            this.deckAOsc.Click += new System.EventHandler(this.deckAOsc_Click);
            // 
            // faderDeckA
            // 
            this.faderDeckA.CausesValidation = false;
            this.faderDeckA.LargeChange = 100;
            this.faderDeckA.Location = new System.Drawing.Point(350, 44);
            this.faderDeckA.Maximum = 1000;
            this.faderDeckA.Name = "faderDeckA";
            this.faderDeckA.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.faderDeckA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.faderDeckA.Size = new System.Drawing.Size(45, 160);
            this.faderDeckA.SmallChange = 0;
            this.faderDeckA.TabIndex = 1;
            this.faderDeckA.TickFrequency = 100;
            this.faderDeckA.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.faderDeckA.Scroll += new System.EventHandler(this.faderDeckA_Scroll);
            this.faderDeckA.ValueChanged += new System.EventHandler(this.faderDeckA_ValueChanged);
            // 
            // faderDeckB
            // 
            this.faderDeckB.CausesValidation = false;
            this.faderDeckB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.faderDeckB.LargeChange = 100;
            this.faderDeckB.Location = new System.Drawing.Point(405, 44);
            this.faderDeckB.Maximum = 1000;
            this.faderDeckB.Name = "faderDeckB";
            this.faderDeckB.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.faderDeckB.Size = new System.Drawing.Size(45, 160);
            this.faderDeckB.SmallChange = 0;
            this.faderDeckB.TabIndex = 2;
            this.faderDeckB.TabStop = false;
            this.faderDeckB.TickFrequency = 100;
            this.faderDeckB.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.faderDeckB.Scroll += new System.EventHandler(this.faderDeckB_Scroll);
            this.faderDeckB.ValueChanged += new System.EventHandler(this.faderDeckB_ValueChanged);
            // 
            // deckBOsc
            // 
            this.deckBOsc.BackColor = System.Drawing.Color.Black;
            this.deckBOsc.Location = new System.Drawing.Point(456, 44);
            this.deckBOsc.Name = "deckBOsc";
            this.deckBOsc.Size = new System.Drawing.Size(320, 116);
            this.deckBOsc.TabIndex = 3;
            this.deckBOsc.TabStop = false;
            this.deckBOsc.Click += new System.EventHandler(this.deckBOsc_Click);
            // 
            // crossFader
            // 
            this.crossFader.Location = new System.Drawing.Point(350, 210);
            this.crossFader.Maximum = 1000;
            this.crossFader.Name = "crossFader";
            this.crossFader.Size = new System.Drawing.Size(104, 45);
            this.crossFader.TabIndex = 4;
            this.crossFader.TickFrequency = 100;
            this.crossFader.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.crossFader.Scroll += new System.EventHandler(this.crossFader_Scroll);
            this.crossFader.ValueChanged += new System.EventHandler(this.crossFader_ValueChanged);
            // 
            // playlistBox
            // 
            this.playlistBox.AllowDrop = true;
            this.playlistBox.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.playlistBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlistBox.FormattingEnabled = true;
            this.playlistBox.Location = new System.Drawing.Point(12, 253);
            this.playlistBox.Name = "playlistBox";
            this.playlistBox.Size = new System.Drawing.Size(760, 117);
            this.playlistBox.TabIndex = 5;
            this.playlistBox.SelectedIndexChanged += new System.EventHandler(this.playlistBox_SelectedIndexChanged);
            // 
            // loadDeckA
            // 
            this.loadDeckA.Location = new System.Drawing.Point(12, 379);
            this.loadDeckA.Name = "loadDeckA";
            this.loadDeckA.Size = new System.Drawing.Size(75, 23);
            this.loadDeckA.TabIndex = 6;
            this.loadDeckA.Text = "Deck A";
            this.loadDeckA.UseVisualStyleBackColor = true;
            this.loadDeckA.Click += new System.EventHandler(this.loadDeckA_Click);
            // 
            // loadDeckB
            // 
            this.loadDeckB.Location = new System.Drawing.Point(93, 379);
            this.loadDeckB.Name = "loadDeckB";
            this.loadDeckB.Size = new System.Drawing.Size(75, 23);
            this.loadDeckB.TabIndex = 7;
            this.loadDeckB.Text = "Deck B";
            this.loadDeckB.UseVisualStyleBackColor = true;
            this.loadDeckB.Click += new System.EventHandler(this.loadDeckB_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(205, 379);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(75, 23);
            this.importButton.TabIndex = 8;
            this.importButton.Text = "Import";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(674, 377);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(44, 23);
            this.saveButton.TabIndex = 9;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(615, 377);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(53, 23);
            this.deleteButton.TabIndex = 10;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // playDeckA
            // 
            this.playDeckA.Location = new System.Drawing.Point(9, 166);
            this.playDeckA.Name = "playDeckA";
            this.playDeckA.Size = new System.Drawing.Size(75, 23);
            this.playDeckA.TabIndex = 11;
            this.playDeckA.Text = "Play";
            this.playDeckA.UseVisualStyleBackColor = true;
            this.playDeckA.Click += new System.EventHandler(this.playDeckA_Click);
            // 
            // playDeckB
            // 
            this.playDeckB.Location = new System.Drawing.Point(461, 166);
            this.playDeckB.Name = "playDeckB";
            this.playDeckB.Size = new System.Drawing.Size(75, 23);
            this.playDeckB.TabIndex = 12;
            this.playDeckB.Text = "Play";
            this.playDeckB.UseVisualStyleBackColor = true;
            this.playDeckB.Click += new System.EventHandler(this.playDeckB_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(725, 377);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(47, 23);
            this.loadButton.TabIndex = 13;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 37);
            this.label1.TabIndex = 14;
            this.label1.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(738, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 37);
            this.label2.TabIndex = 15;
            this.label2.Text = "B";
            // 
            // deckALabel
            // 
            this.deckALabel.BackColor = System.Drawing.Color.Black;
            this.deckALabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deckALabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.deckALabel.Location = new System.Drawing.Point(54, 9);
            this.deckALabel.Name = "deckALabel";
            this.deckALabel.Size = new System.Drawing.Size(350, 23);
            this.deckALabel.TabIndex = 16;
            this.deckALabel.Text = "None";
            // 
            // deckBLabel
            // 
            this.deckBLabel.BackColor = System.Drawing.Color.Black;
            this.deckBLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deckBLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.deckBLabel.Location = new System.Drawing.Point(410, 9);
            this.deckBLabel.Name = "deckBLabel";
            this.deckBLabel.Size = new System.Drawing.Size(322, 23);
            this.deckBLabel.TabIndex = 17;
            this.deckBLabel.Text = "None";
            this.deckBLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlg
            // 
            this.dlg.FileName = "openFileDialog1";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timeDeckA
            // 
            this.timeDeckA.AutoSize = true;
            this.timeDeckA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.timeDeckA.Location = new System.Drawing.Point(93, 171);
            this.timeDeckA.Name = "timeDeckA";
            this.timeDeckA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeDeckA.Size = new System.Drawing.Size(82, 13);
            this.timeDeckA.TabIndex = 18;
            this.timeDeckA.Text = "No song loaded";
            this.timeDeckA.Click += new System.EventHandler(this.timeDeckA_Click);
            // 
            // timeDeckB
            // 
            this.timeDeckB.AutoSize = true;
            this.timeDeckB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.timeDeckB.Location = new System.Drawing.Point(542, 171);
            this.timeDeckB.Name = "timeDeckB";
            this.timeDeckB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeDeckB.Size = new System.Drawing.Size(82, 13);
            this.timeDeckB.TabIndex = 19;
            this.timeDeckB.Text = "No song loaded";
            this.timeDeckB.Click += new System.EventHandler(this.timeDeckB_Click);
            // 
            // DJForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(784, 412);
            this.Controls.Add(this.timeDeckB);
            this.Controls.Add(this.timeDeckA);
            this.Controls.Add(this.deckBLabel);
            this.Controls.Add(this.deckALabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.playDeckB);
            this.Controls.Add(this.playDeckA);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.importButton);
            this.Controls.Add(this.loadDeckB);
            this.Controls.Add(this.loadDeckA);
            this.Controls.Add(this.playlistBox);
            this.Controls.Add(this.crossFader);
            this.Controls.Add(this.deckBOsc);
            this.Controls.Add(this.faderDeckB);
            this.Controls.Add(this.faderDeckA);
            this.Controls.Add(this.deckAOsc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DJForm";
            this.Text = "SimpleDJ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DJForm_FormClosing);
            this.Load += new System.EventHandler(this.DJForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.DJForm_DragDrop);
            ((System.ComponentModel.ISupportInitialize)(this.deckAOsc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faderDeckA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.faderDeckB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deckBOsc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crossFader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox deckAOsc;
        private System.Windows.Forms.TrackBar faderDeckA;
        private System.Windows.Forms.TrackBar faderDeckB;
        private System.Windows.Forms.PictureBox deckBOsc;
        private System.Windows.Forms.TrackBar crossFader;
        private System.Windows.Forms.ListBox playlistBox;
        private System.Windows.Forms.Button loadDeckA;
        private System.Windows.Forms.Button loadDeckB;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button playDeckA;
        private System.Windows.Forms.Button playDeckB;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label deckALabel;
        private System.Windows.Forms.Label deckBLabel;
        private System.Windows.Forms.OpenFileDialog dlg;
        private System.Windows.Forms.SaveFileDialog slg;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timeDeckA;
        private System.Windows.Forms.Label timeDeckB;
    }
}

