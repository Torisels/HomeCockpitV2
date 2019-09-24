namespace HomeCockpitV2
{
    partial class MainForm
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
            this.dataGridViewPins = new System.Windows.Forms.DataGridView();
            this.Pin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MCU_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MCU_bit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Register_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPins)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewPins
            // 
            this.dataGridViewPins.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPins.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Pin,
            this.MCU_id,
            this.MCU_bit,
            this.Register_id});
            this.dataGridViewPins.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewPins.Name = "dataGridViewPins";
            this.dataGridViewPins.RowHeadersVisible = false;
            this.dataGridViewPins.Size = new System.Drawing.Size(416, 426);
            this.dataGridViewPins.TabIndex = 0;
            // 
            // Pin
            // 
            this.Pin.HeaderText = "Pin";
            this.Pin.Name = "Pin";
            this.Pin.ReadOnly = true;
            // 
            // MCU_id
            // 
            this.MCU_id.HeaderText = "MCU";
            this.MCU_id.Name = "MCU_id";
            this.MCU_id.ReadOnly = true;
            // 
            // MCU_bit
            // 
            this.MCU_bit.HeaderText = "MCU_bit";
            this.MCU_bit.Name = "MCU_bit";
            this.MCU_bit.ReadOnly = true;
            // 
            // Register_id
            // 
            this.Register_id.HeaderText = "Master Index";
            this.Register_id.Name = "Register_id";
            this.Register_id.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewPins);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPins)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewPins;
        private System.Windows.Forms.DataGridViewTextBoxColumn Pin;
        private System.Windows.Forms.DataGridViewTextBoxColumn MCU_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn MCU_bit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Register_id;
    }
}

