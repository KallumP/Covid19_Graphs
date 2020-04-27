namespace Covid19Graphs {
    partial class CountrySelect {
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
            this.back_btn = new System.Windows.Forms.Button();
            this.allCountries_pnl = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // back_btn
            // 
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.Location = new System.Drawing.Point(199, 498);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(75, 37);
            this.back_btn.TabIndex = 1;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // allCountries_pnl
            // 
            this.allCountries_pnl.AutoScroll = true;
            this.allCountries_pnl.Location = new System.Drawing.Point(13, 13);
            this.allCountries_pnl.Name = "allCountries_pnl";
            this.allCountries_pnl.Size = new System.Drawing.Size(478, 468);
            this.allCountries_pnl.TabIndex = 2;
            // 
            // CountrySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 559);
            this.Controls.Add(this.allCountries_pnl);
            this.Controls.Add(this.back_btn);
            this.Name = "CountrySelect";
            this.Text = "CountrySelect";
            this.Load += new System.EventHandler(this.CountrySelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Panel allCountries_pnl;
    }
}