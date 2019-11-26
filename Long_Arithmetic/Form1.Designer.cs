namespace Long_Arithmetic
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.textBoxFirstOperand = new System.Windows.Forms.TextBox();
            this.textBoxSecondOperand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxOperation = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelRest = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxUseModule = new System.Windows.Forms.CheckBox();
            this.textBoxModule = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonAddEquation = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 290);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Result:";
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(80, 290);
            this.labelResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(18, 20);
            this.labelResult.TabIndex = 1;
            this.labelResult.Text = "0";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(12, 387);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(94, 35);
            this.buttonCalculate.TabIndex = 2;
            this.buttonCalculate.Text = "Calcualte";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.ButtonCalculate_Click);
            // 
            // textBoxFirstOperand
            // 
            this.textBoxFirstOperand.Location = new System.Drawing.Point(145, 15);
            this.textBoxFirstOperand.Name = "textBoxFirstOperand";
            this.textBoxFirstOperand.Size = new System.Drawing.Size(516, 26);
            this.textBoxFirstOperand.TabIndex = 3;
            // 
            // textBoxSecondOperand
            // 
            this.textBoxSecondOperand.Location = new System.Drawing.Point(145, 69);
            this.textBoxSecondOperand.Name = "textBoxSecondOperand";
            this.textBoxSecondOperand.Size = new System.Drawing.Size(516, 26);
            this.textBoxSecondOperand.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 75);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Second Operand";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(13, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "First Operand";
            // 
            // comboBoxOperation
            // 
            this.comboBoxOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxOperation.FormattingEnabled = true;
            this.comboBoxOperation.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBoxOperation.Location = new System.Drawing.Point(144, 120);
            this.comboBoxOperation.Name = "comboBoxOperation";
            this.comboBoxOperation.Size = new System.Drawing.Size(516, 28);
            this.comboBoxOperation.TabIndex = 7;
            this.comboBoxOperation.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOperation_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(13, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Operation";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(13, 340);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Rest (for divide):";
            // 
            // labelRest
            // 
            this.labelRest.AutoSize = true;
            this.labelRest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelRest.Location = new System.Drawing.Point(145, 340);
            this.labelRest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelRest.Name = "labelRest";
            this.labelRest.Size = new System.Drawing.Size(18, 20);
            this.labelRest.TabIndex = 10;
            this.labelRest.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(140, 183);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Module";
            // 
            // checkBoxUseModule
            // 
            this.checkBoxUseModule.AutoSize = true;
            this.checkBoxUseModule.Location = new System.Drawing.Point(13, 185);
            this.checkBoxUseModule.Name = "checkBoxUseModule";
            this.checkBoxUseModule.Size = new System.Drawing.Size(113, 24);
            this.checkBoxUseModule.TabIndex = 12;
            this.checkBoxUseModule.Text = "Use module";
            this.checkBoxUseModule.UseVisualStyleBackColor = true;
            this.checkBoxUseModule.CheckedChanged += new System.EventHandler(this.CheckBoxUseModule_CheckedChanged);
            // 
            // textBoxModule
            // 
            this.textBoxModule.Enabled = false;
            this.textBoxModule.Location = new System.Drawing.Point(208, 183);
            this.textBoxModule.Name = "textBoxModule";
            this.textBoxModule.Size = new System.Drawing.Size(453, 26);
            this.textBoxModule.TabIndex = 13;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.AutoSize = true;
            this.timeLabel.Location = new System.Drawing.Point(893, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(94, 20);
            this.timeLabel.TabIndex = 15;
            this.timeLabel.Text = "0 h, 0 m, 0 s";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(699, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(460, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Click \"add\" to add the equation and click \"delete\" for remove last\r\n";
            // 
            // buttonAddEquation
            // 
            this.buttonAddEquation.Location = new System.Drawing.Point(703, 162);
            this.buttonAddEquation.Name = "buttonAddEquation";
            this.buttonAddEquation.Size = new System.Drawing.Size(68, 41);
            this.buttonAddEquation.TabIndex = 17;
            this.buttonAddEquation.Text = "add";
            this.buttonAddEquation.UseVisualStyleBackColor = true;
            this.buttonAddEquation.Click += new System.EventHandler(this.ButtonAddEquation_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1091, 162);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 41);
            this.button2.TabIndex = 18;
            this.button2.Text = "delete";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1236, 512);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonAddEquation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.textBoxModule);
            this.Controls.Add(this.checkBoxUseModule);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelRest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxOperation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSecondOperand);
            this.Controls.Add(this.textBoxFirstOperand);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.TextBox textBoxFirstOperand;
        private System.Windows.Forms.TextBox textBoxSecondOperand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxOperation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelRest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox checkBoxUseModule;
        private System.Windows.Forms.TextBox textBoxModule;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonAddEquation;
        private System.Windows.Forms.Button button2;
    }
}

