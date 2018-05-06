namespace LoginPanel
{
    partial class UserWindow
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
            this.labelWelcome = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.agendaTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.eventComboBox = new System.Windows.Forms.ComboBox();
            this.EventUserType = new System.Windows.Forms.ComboBox();
            this.PreferredFood = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.saveEvent = new System.Windows.Forms.Button();
            this.eventDate = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWelcome.Location = new System.Drawing.Point(56, 56);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(108, 23);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome!";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(61, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(679, 2);
            this.label2.TabIndex = 4;
            // 
            // agendaTextBox
            // 
            this.agendaTextBox.Location = new System.Drawing.Point(313, 135);
            this.agendaTextBox.Name = "agendaTextBox";
            this.agendaTextBox.Size = new System.Drawing.Size(427, 232);
            this.agendaTextBox.TabIndex = 5;
            this.agendaTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(313, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Agenda:";
            // 
            // eventComboBox
            // 
            this.eventComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.eventComboBox.FormattingEnabled = true;
            this.eventComboBox.Location = new System.Drawing.Point(60, 135);
            this.eventComboBox.Name = "eventComboBox";
            this.eventComboBox.Size = new System.Drawing.Size(224, 24);
            this.eventComboBox.TabIndex = 9;
            this.eventComboBox.DropDown += new System.EventHandler(this.eventComboBox_DropDown);
            this.eventComboBox.SelectedValueChanged += new System.EventHandler(this.eventComboBox_SelectedValueChanged);
            // 
            // EventUserType
            // 
            this.EventUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventUserType.FormattingEnabled = true;
            this.EventUserType.Items.AddRange(new object[] {
            "Sluchacz",
            "Autor",
            "Sponsor",
            "Organizator"});
            this.EventUserType.Location = new System.Drawing.Point(60, 267);
            this.EventUserType.Name = "EventUserType";
            this.EventUserType.Size = new System.Drawing.Size(224, 24);
            this.EventUserType.TabIndex = 10;
            // 
            // PreferredFood
            // 
            this.PreferredFood.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PreferredFood.FormattingEnabled = true;
            this.PreferredFood.Items.AddRange(new object[] {
            "Bez preferencji",
            "Wegetarianskie",
            "Bez glutenu"});
            this.PreferredFood.Location = new System.Drawing.Point(60, 343);
            this.PreferredFood.Name = "PreferredFood";
            this.PreferredFood.Size = new System.Drawing.Size(224, 24);
            this.PreferredFood.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Wydarzenia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 238);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Typ uczestnictwa:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(58, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(152, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Preferowanie jedzenie:";
            // 
            // saveEvent
            // 
            this.saveEvent.Location = new System.Drawing.Point(60, 398);
            this.saveEvent.Name = "saveEvent";
            this.saveEvent.Size = new System.Drawing.Size(104, 27);
            this.saveEvent.TabIndex = 15;
            this.saveEvent.Text = "Zapisz się";
            this.saveEvent.UseVisualStyleBackColor = true;
            this.saveEvent.Click += new System.EventHandler(this.saveEvent_Click);
            // 
            // eventDate
            // 
            this.eventDate.AutoSize = true;
            this.eventDate.Location = new System.Drawing.Point(60, 175);
            this.eventDate.Name = "eventDate";
            this.eventDate.Size = new System.Drawing.Size(131, 17);
            this.eventDate.TabIndex = 17;
            this.eventDate.Text = "Termin wydarzenia:";
            // 
            // UserWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 445);
            this.Controls.Add(this.eventDate);
            this.Controls.Add(this.saveEvent);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PreferredFood);
            this.Controls.Add(this.EventUserType);
            this.Controls.Add(this.eventComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.agendaTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelWelcome);
            this.Name = "UserWindow";
            this.Text = "UserWindow";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox agendaTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox eventComboBox;
        private System.Windows.Forms.ComboBox EventUserType;
        private System.Windows.Forms.ComboBox PreferredFood;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button saveEvent;
        private System.Windows.Forms.Label eventDate;
    }
}