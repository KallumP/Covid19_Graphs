namespace Covid19Graphs {
    partial class Covid19Graphs {
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
            this.normalise_btn = new System.Windows.Forms.Button();
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
            this.graph.Size = new System.Drawing.Size(350, 437);
            this.graph.TabIndex = 0;
            this.graph.TabStop = false;
            this.graph.Paint += new System.Windows.Forms.PaintEventHandler(this.graph_Paint);
            // 
            // normalise_btn
            // 
            this.normalise_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.normalise_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.normalise_btn.Location = new System.Drawing.Point(369, 12);
            this.normalise_btn.Name = "normalise_btn";
            this.normalise_btn.Size = new System.Drawing.Size(104, 42);
            this.normalise_btn.TabIndex = 1;
            this.normalise_btn.Text = "Normalise";
            this.normalise_btn.UseVisualStyleBackColor = true;
            this.normalise_btn.Click += new System.EventHandler(this.normalise_btn_Click);
            // 
            // Covid19Graphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.normalise_btn);
            this.Controls.Add(this.graph);
            this.Name = "Covid19Graphs";
            this.Text = "Covid19 Graphs";
            this.Load += new System.EventHandler(this.Covid19Graphs_Load);
            this.Resize += new System.EventHandler(this.Covid19Graphs_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.graph)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox graph;
        private System.Windows.Forms.Button normalise_btn;
    }
}

