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
            this.ComputeResult = new System.Windows.Forms.TextBox();
            this.fName = new System.Windows.Forms.TextBox();
            this.Compute = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ChargeButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComputeResult
            // 
            this.ComputeResult.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ComputeResult.Location = new System.Drawing.Point(12, 12);
            this.ComputeResult.Multiline = true;
            this.ComputeResult.Name = "ComputeResult";
            this.ComputeResult.ReadOnly = true;
            this.ComputeResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ComputeResult.Size = new System.Drawing.Size(425, 384);
            this.ComputeResult.TabIndex = 0;
            // 
            // fName
            // 
            this.fName.Location = new System.Drawing.Point(59, 423);
            this.fName.Name = "fName";
            this.fName.ReadOnly = true;
            this.fName.Size = new System.Drawing.Size(315, 26);
            this.fName.TabIndex = 1;
            this.fName.Text = "Selected Function";
            this.fName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Compute
            // 
            this.Compute.Location = new System.Drawing.Point(3, 3);
            this.Compute.Name = "Compute";
            this.Compute.Size = new System.Drawing.Size(92, 35);
            this.Compute.TabIndex = 2;
            this.Compute.Text = "Compute";
            this.Compute.UseVisualStyleBackColor = true;
            this.Compute.Click += new System.EventHandler(this.Compute_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(101, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(96, 35);
            this.SaveButton.TabIndex = 3;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ChargeButton
            // 
            this.ChargeButton.AutoSize = true;
            this.ChargeButton.Location = new System.Drawing.Point(3, 44);
            this.ChargeButton.Name = "ChargeButton";
            this.ChargeButton.Size = new System.Drawing.Size(197, 56);
            this.ChargeButton.TabIndex = 4;
            this.ChargeButton.Text = "Charge a .dll";
            this.ChargeButton.UseVisualStyleBackColor = true;
            this.ChargeButton.Click += new System.EventHandler(this.ChargeButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.Compute);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Controls.Add(this.ChargeButton);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(456, 397);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(668, 509);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.fName);
            this.Controls.Add(this.ComputeResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Calculator_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ComputeResult;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Button Compute;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ChargeButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

