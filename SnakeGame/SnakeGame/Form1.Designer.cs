namespace SnakeGame
{
    partial class frmSnake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSnake));
            this.picGameSize = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picGameSize)).BeginInit();
            this.SuspendLayout();
            // 
            // picGameSize
            // 
            this.picGameSize.Location = new System.Drawing.Point(12, 34);
            this.picGameSize.Name = "picGameSize";
            this.picGameSize.Size = new System.Drawing.Size(420, 417);
            this.picGameSize.TabIndex = 0;
            this.picGameSize.TabStop = false;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 250;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "insect.png");
            this.imgList.Images.SetKeyName(1, "rat.png");
            this.imgList.Images.SetKeyName(2, "frog.png");
            this.imgList.Images.SetKeyName(3, "bonus4.png");
            this.imgList.Images.SetKeyName(4, "snake_body.png");
            this.imgList.Images.SetKeyName(5, "snake_head.png");
            this.imgList.Images.SetKeyName(6, "wall.png");
            // 
            // frmSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 463);
            this.Controls.Add(this.picGameSize);
            this.Name = "frmSnake";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game";
            this.Load += new System.EventHandler(this.frmSnake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmSnake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.picGameSize)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picGameSize;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ImageList imgList;
    
    }
}

