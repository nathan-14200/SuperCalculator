namespace SuperCalculator
{
    partial class Calculator
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.Result = new System.Windows.Forms.TextBox();
            this.Input = new System.Windows.Forms.TextBox();
            this.Compute = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Result
            // 
            this.Result.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Result.Location = new System.Drawing.Point(12, 12);
            this.Result.Multiline = true;
            this.Result.Name = "Result";
            this.Result.ReadOnly = true;
            this.Result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Result.Size = new System.Drawing.Size(425, 384);
            this.Result.TabIndex = 0;
            this.Result.TextChanged += new System.EventHandler(this.historic_TextChanged);
            // 
            // Input
            // 
            this.Input.Location = new System.Drawing.Point(13, 423);
            this.Input.Name = "Input";
            this.Input.Size = new System.Drawing.Size(424, 26);
            this.Input.TabIndex = 1;
            // 
            // Compute
            // 
            this.Compute.Location = new System.Drawing.Point(443, 419);
            this.Compute.Name = "Compute";
            this.Compute.Size = new System.Drawing.Size(92, 35);
            this.Compute.TabIndex = 2;
            this.Compute.Text = "Compute";
            this.Compute.UseVisualStyleBackColor = true;
            this.Compute.Click += new System.EventHandler(this.Compute_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(541, 419);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 35);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(686, 509);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.Compute);
            this.Controls.Add(this.Input);
            this.Controls.Add(this.Result);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Result;
        private System.Windows.Forms.TextBox Input;
        private System.Windows.Forms.Button Compute;
        private System.Windows.Forms.Button SaveButton;
    }
}

