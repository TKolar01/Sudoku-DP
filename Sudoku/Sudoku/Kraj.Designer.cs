
namespace Sudoku
{
    partial class Kraj
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
            this.labelCestitka = new System.Windows.Forms.Label();
            this.labelVrijeme = new System.Windows.Forms.Label();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.labelVrijemeProlaza = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelCestitka
            // 
            this.labelCestitka.AutoSize = true;
            this.labelCestitka.Font = new System.Drawing.Font("Arial", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCestitka.Location = new System.Drawing.Point(70, 50);
            this.labelCestitka.Name = "labelCestitka";
            this.labelCestitka.Size = new System.Drawing.Size(420, 40);
            this.labelCestitka.TabIndex = 0;
            this.labelCestitka.Text = "Uspješno ste riješili igru!";
            this.labelCestitka.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVrijeme
            // 
            this.labelVrijeme.AutoSize = true;
            this.labelVrijeme.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelVrijeme.Location = new System.Drawing.Point(158, 140);
            this.labelVrijeme.Name = "labelVrijeme";
            this.labelVrijeme.Size = new System.Drawing.Size(102, 29);
            this.labelVrijeme.TabIndex = 1;
            this.labelVrijeme.Text = "Vrijeme:";
            this.labelVrijeme.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPovratak
            // 
            this.btnPovratak.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPovratak.Location = new System.Drawing.Point(197, 223);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(159, 33);
            this.btnPovratak.TabIndex = 2;
            this.btnPovratak.Text = "U redu!";
            this.btnPovratak.UseVisualStyleBackColor = true;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // labelVrijemeProlaza
            // 
            this.labelVrijemeProlaza.AutoSize = true;
            this.labelVrijemeProlaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVrijemeProlaza.Location = new System.Drawing.Point(266, 143);
            this.labelVrijemeProlaza.Name = "labelVrijemeProlaza";
            this.labelVrijemeProlaza.Size = new System.Drawing.Size(0, 25);
            this.labelVrijemeProlaza.TabIndex = 3;
            // 
            // Kraj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 280);
            this.Controls.Add(this.labelVrijemeProlaza);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.labelVrijeme);
            this.Controls.Add(this.labelCestitka);
            this.Name = "Kraj";
            this.Text = "Kraj";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Kraj_FormClosing);
            this.Load += new System.EventHandler(this.Kraj_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCestitka;
        private System.Windows.Forms.Label labelVrijeme;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.Label labelVrijemeProlaza;
    }
}