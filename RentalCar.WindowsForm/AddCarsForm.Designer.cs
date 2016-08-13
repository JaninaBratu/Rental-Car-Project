namespace RentalCar.WindowsForm
{
    partial class AddCarsForm
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
            this.registrationTextBox = new System.Windows.Forms.TextBox();
            this.RegistNrLabel = new System.Windows.Forms.Label();
            this.locationComboBox = new System.Windows.Forms.ComboBox();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.brandComboBox = new System.Windows.Forms.ComboBox();
            this.BrandLabel = new System.Windows.Forms.Label();
            this.modelComboBox = new System.Windows.Forms.ComboBox();
            this.ModelLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.messageLabelRegistNr = new System.Windows.Forms.Label();
            this.messageLocationLabel = new System.Windows.Forms.Label();
            this.messageBrandLabel = new System.Windows.Forms.Label();
            this.messageModelLabel = new System.Windows.Forms.Label();
            this.messageSaveLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // registrationTextBox
            // 
            this.registrationTextBox.Location = new System.Drawing.Point(234, 37);
            this.registrationTextBox.Name = "registrationTextBox";
            this.registrationTextBox.Size = new System.Drawing.Size(100, 20);
            this.registrationTextBox.TabIndex = 0;
            // 
            // RegistNrLabel
            // 
            this.RegistNrLabel.AutoSize = true;
            this.RegistNrLabel.Location = new System.Drawing.Point(116, 37);
            this.RegistNrLabel.Name = "RegistNrLabel";
            this.RegistNrLabel.Size = new System.Drawing.Size(103, 13);
            this.RegistNrLabel.TabIndex = 1;
            this.RegistNrLabel.Text = "Registration Number";
            // 
            // locationComboBox
            // 
            this.locationComboBox.FormattingEnabled = true;
            this.locationComboBox.Location = new System.Drawing.Point(234, 72);
            this.locationComboBox.Name = "locationComboBox";
            this.locationComboBox.Size = new System.Drawing.Size(121, 21);
            this.locationComboBox.TabIndex = 2;
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(142, 80);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(48, 13);
            this.LocationLabel.TabIndex = 3;
            this.LocationLabel.Text = "Location";
            // 
            // brandComboBox
            // 
            this.brandComboBox.FormattingEnabled = true;
            this.brandComboBox.Location = new System.Drawing.Point(234, 110);
            this.brandComboBox.Name = "brandComboBox";
            this.brandComboBox.Size = new System.Drawing.Size(121, 21);
            this.brandComboBox.TabIndex = 4;
            // 
            // BrandLabel
            // 
            this.BrandLabel.AutoSize = true;
            this.BrandLabel.Location = new System.Drawing.Point(142, 118);
            this.BrandLabel.Name = "BrandLabel";
            this.BrandLabel.Size = new System.Drawing.Size(35, 13);
            this.BrandLabel.TabIndex = 5;
            this.BrandLabel.Text = "Brand";
            this.BrandLabel.Click += new System.EventHandler(this.backButtonOnClick);
            // 
            // modelComboBox
            // 
            this.modelComboBox.FormattingEnabled = true;
            this.modelComboBox.Location = new System.Drawing.Point(234, 145);
            this.modelComboBox.Name = "modelComboBox";
            this.modelComboBox.Size = new System.Drawing.Size(121, 21);
            this.modelComboBox.TabIndex = 6;
            // 
            // ModelLabel
            // 
            this.ModelLabel.AutoSize = true;
            this.ModelLabel.Location = new System.Drawing.Point(142, 148);
            this.ModelLabel.Name = "ModelLabel";
            this.ModelLabel.Size = new System.Drawing.Size(36, 13);
            this.ModelLabel.TabIndex = 7;
            this.ModelLabel.Text = "Model";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(253, 294);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // messageLabelRegistNr
            // 
            this.messageLabelRegistNr.AutoSize = true;
            this.messageLabelRegistNr.Location = new System.Drawing.Point(390, 37);
            this.messageLabelRegistNr.Name = "messageLabelRegistNr";
            this.messageLabelRegistNr.Size = new System.Drawing.Size(35, 13);
            this.messageLabelRegistNr.TabIndex = 9;
            this.messageLabelRegistNr.Text = "label1";
            // 
            // messageLocationLabel
            // 
            this.messageLocationLabel.AutoSize = true;
            this.messageLocationLabel.Location = new System.Drawing.Point(390, 75);
            this.messageLocationLabel.Name = "messageLocationLabel";
            this.messageLocationLabel.Size = new System.Drawing.Size(35, 13);
            this.messageLocationLabel.TabIndex = 11;
            this.messageLocationLabel.Text = "label2";
            // 
            // messageBrandLabel
            // 
            this.messageBrandLabel.AutoSize = true;
            this.messageBrandLabel.Location = new System.Drawing.Point(390, 113);
            this.messageBrandLabel.Name = "messageBrandLabel";
            this.messageBrandLabel.Size = new System.Drawing.Size(35, 13);
            this.messageBrandLabel.TabIndex = 12;
            this.messageBrandLabel.Text = "label3";
            // 
            // messageModelLabel
            // 
            this.messageModelLabel.AutoSize = true;
            this.messageModelLabel.Location = new System.Drawing.Point(390, 148);
            this.messageModelLabel.Name = "messageModelLabel";
            this.messageModelLabel.Size = new System.Drawing.Size(35, 13);
            this.messageModelLabel.TabIndex = 13;
            this.messageModelLabel.Text = "label4";
            // 
            // messageSaveLabel
            // 
            this.messageSaveLabel.AutoSize = true;
            this.messageSaveLabel.Location = new System.Drawing.Point(274, 236);
            this.messageSaveLabel.Name = "messageSaveLabel";
            this.messageSaveLabel.Size = new System.Drawing.Size(35, 13);
            this.messageSaveLabel.TabIndex = 14;
            this.messageSaveLabel.Text = "label5";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 25);
            this.button1.TabIndex = 15;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.backButtonOnClick);
            // 
            // AddCarsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(625, 367);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.messageSaveLabel);
            this.Controls.Add(this.messageModelLabel);
            this.Controls.Add(this.messageBrandLabel);
            this.Controls.Add(this.messageLocationLabel);
            this.Controls.Add(this.messageLabelRegistNr);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ModelLabel);
            this.Controls.Add(this.modelComboBox);
            this.Controls.Add(this.BrandLabel);
            this.Controls.Add(this.brandComboBox);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.locationComboBox);
            this.Controls.Add(this.RegistNrLabel);
            this.Controls.Add(this.registrationTextBox);
            this.Name = "AddCarsForm";
            this.Text = "AddCarsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox registrationTextBox;
        private System.Windows.Forms.Label RegistNrLabel;
        private System.Windows.Forms.ComboBox locationComboBox;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.ComboBox brandComboBox;
        private System.Windows.Forms.Label BrandLabel;
        private System.Windows.Forms.ComboBox modelComboBox;
        private System.Windows.Forms.Label ModelLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label messageLabelRegistNr;
        private System.Windows.Forms.Label messageLocationLabel;
        private System.Windows.Forms.Label messageBrandLabel;
        private System.Windows.Forms.Label messageModelLabel;
        private System.Windows.Forms.Label messageSaveLabel;
        private System.Windows.Forms.Button button1;
    }
}