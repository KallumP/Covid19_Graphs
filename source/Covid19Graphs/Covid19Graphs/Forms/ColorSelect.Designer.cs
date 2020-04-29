namespace Covid19Graphs {
    partial class ColorSelect {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.red_btn = new System.Windows.Forms.Button();
            this.orange_btn = new System.Windows.Forms.Button();
            this.darkBlue_btn = new System.Windows.Forms.Button();
            this.cyan_btn = new System.Windows.Forms.Button();
            this.grey_btn = new System.Windows.Forms.Button();
            this.pink_btn = new System.Windows.Forms.Button();
            this.green_btn = new System.Windows.Forms.Button();
            this.yellow_btn = new System.Windows.Forms.Button();
            this.select_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // red_btn
            // 
            this.red_btn.BackColor = System.Drawing.Color.Red;
            this.red_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.red_btn.Location = new System.Drawing.Point(11, 11);
            this.red_btn.Name = "red_btn";
            this.red_btn.Size = new System.Drawing.Size(50, 50);
            this.red_btn.TabIndex = 0;
            this.red_btn.UseVisualStyleBackColor = false;
            // 
            // orange_btn
            // 
            this.orange_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.orange_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orange_btn.Location = new System.Drawing.Point(67, 11);
            this.orange_btn.Name = "orange_btn";
            this.orange_btn.Size = new System.Drawing.Size(50, 50);
            this.orange_btn.TabIndex = 1;
            this.orange_btn.UseVisualStyleBackColor = false;
            this.orange_btn.Click += new System.EventHandler(this.orange_btn_Click);
            // 
            // darkBlue_btn
            // 
            this.darkBlue_btn.BackColor = System.Drawing.Color.Blue;
            this.darkBlue_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.darkBlue_btn.Location = new System.Drawing.Point(67, 67);
            this.darkBlue_btn.Name = "darkBlue_btn";
            this.darkBlue_btn.Size = new System.Drawing.Size(50, 50);
            this.darkBlue_btn.TabIndex = 3;
            this.darkBlue_btn.UseVisualStyleBackColor = false;
            // 
            // cyan_btn
            // 
            this.cyan_btn.BackColor = System.Drawing.Color.Aqua;
            this.cyan_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cyan_btn.Location = new System.Drawing.Point(11, 67);
            this.cyan_btn.Name = "cyan_btn";
            this.cyan_btn.Size = new System.Drawing.Size(50, 50);
            this.cyan_btn.TabIndex = 2;
            this.cyan_btn.UseVisualStyleBackColor = false;
            // 
            // grey_btn
            // 
            this.grey_btn.BackColor = System.Drawing.Color.Gray;
            this.grey_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grey_btn.Location = new System.Drawing.Point(177, 67);
            this.grey_btn.Name = "grey_btn";
            this.grey_btn.Size = new System.Drawing.Size(50, 50);
            this.grey_btn.TabIndex = 7;
            this.grey_btn.UseVisualStyleBackColor = false;
            // 
            // pink_btn
            // 
            this.pink_btn.BackColor = System.Drawing.Color.Fuchsia;
            this.pink_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pink_btn.Location = new System.Drawing.Point(122, 67);
            this.pink_btn.Name = "pink_btn";
            this.pink_btn.Size = new System.Drawing.Size(50, 50);
            this.pink_btn.TabIndex = 6;
            this.pink_btn.UseVisualStyleBackColor = false;
            // 
            // green_btn
            // 
            this.green_btn.BackColor = System.Drawing.Color.Lime;
            this.green_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.green_btn.Location = new System.Drawing.Point(177, 11);
            this.green_btn.Name = "green_btn";
            this.green_btn.Size = new System.Drawing.Size(50, 50);
            this.green_btn.TabIndex = 5;
            this.green_btn.UseVisualStyleBackColor = false;
            // 
            // yellow_btn
            // 
            this.yellow_btn.BackColor = System.Drawing.Color.Yellow;
            this.yellow_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yellow_btn.Location = new System.Drawing.Point(122, 11);
            this.yellow_btn.Name = "yellow_btn";
            this.yellow_btn.Size = new System.Drawing.Size(50, 50);
            this.yellow_btn.TabIndex = 4;
            this.yellow_btn.UseVisualStyleBackColor = false;
            this.yellow_btn.Click += new System.EventHandler(this.yellow_btn_Click);
            // 
            // select_btn
            // 
            this.select_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.select_btn.Location = new System.Drawing.Point(12, 123);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(212, 68);
            this.select_btn.TabIndex = 8;
            this.select_btn.Text = "Select";
            this.select_btn.UseVisualStyleBackColor = true;
            this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
            // 
            // ColorSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 203);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.grey_btn);
            this.Controls.Add(this.pink_btn);
            this.Controls.Add(this.green_btn);
            this.Controls.Add(this.yellow_btn);
            this.Controls.Add(this.darkBlue_btn);
            this.Controls.Add(this.cyan_btn);
            this.Controls.Add(this.orange_btn);
            this.Controls.Add(this.red_btn);
            this.Name = "ColorSelect";
            this.Text = "ColorSelect";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button red_btn;
        private System.Windows.Forms.Button orange_btn;
        private System.Windows.Forms.Button darkBlue_btn;
        private System.Windows.Forms.Button cyan_btn;
        private System.Windows.Forms.Button grey_btn;
        private System.Windows.Forms.Button pink_btn;
        private System.Windows.Forms.Button green_btn;
        private System.Windows.Forms.Button yellow_btn;
        private System.Windows.Forms.Button select_btn;
    }
}