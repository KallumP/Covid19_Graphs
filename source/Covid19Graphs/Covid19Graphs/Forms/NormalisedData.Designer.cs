﻿namespace Covid19Graphs {
    partial class NormalisedData {
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
            this.graph = new System.Windows.Forms.PictureBox();
            this.back_btn = new System.Windows.Forms.Button();
            this.countryTitles_pnl = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.graph)).BeginInit();
            this.SuspendLayout();
            // 
            // graph
            // 
            this.graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.graph.Location = new System.Drawing.Point(13, 13);
            this.graph.Name = "graph";
            this.graph.Size = new System.Drawing.Size(378, 437);
            this.graph.TabIndex = 0;
            this.graph.TabStop = false;
            this.graph.Paint += new System.Windows.Forms.PaintEventHandler(this.graph_Paint);
            // 
            // back_btn
            // 
            this.back_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.back_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.Location = new System.Drawing.Point(397, 12);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(173, 42);
            this.back_btn.TabIndex = 1;
            this.back_btn.Text = "Back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // countryTitles_pnl
            // 
            this.countryTitles_pnl.Location = new System.Drawing.Point(397, 60);
            this.countryTitles_pnl.Name = "countryTitles_pnl";
            this.countryTitles_pnl.Size = new System.Drawing.Size(172, 390);
            this.countryTitles_pnl.TabIndex = 2;
            // 
            // NormalisedData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 461);
            this.Controls.Add(this.countryTitles_pnl);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.graph);
            this.Name = "NormalisedData";
            this.Text = "NormalisedData";
            this.Resize += new System.EventHandler(this.NormalisedData_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox graph;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.Panel countryTitles_pnl;
    }
}