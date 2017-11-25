namespace Calculator
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MC = new System.Windows.Forms.Button();
            this.M_plus = new System.Windows.Forms.Button();
            this.M_minus = new System.Windows.Forms.Button();
            this.MR = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Negative = new System.Windows.Forms.Button();
            this.Division = new System.Windows.Forms.Button();
            this.Multi = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.Minus = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.Plus = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button0 = new System.Windows.Forms.Button();
            this.ButtonDot = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.resultArrayBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.form1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lb_IP = new System.Windows.Forms.Label();
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.lb_Port = new System.Windows.Forms.Label();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.connected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resultArrayBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // MC
            // 
            this.MC.Location = new System.Drawing.Point(14, 129);
            this.MC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MC.Name = "MC";
            this.MC.Size = new System.Drawing.Size(70, 40);
            this.MC.TabIndex = 0;
            this.MC.Text = "MC";
            this.MC.UseVisualStyleBackColor = true;
            this.MC.Click += new System.EventHandler(this.MC_Click);
            // 
            // M_plus
            // 
            this.M_plus.Location = new System.Drawing.Point(90, 129);
            this.M_plus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.M_plus.Name = "M_plus";
            this.M_plus.Size = new System.Drawing.Size(70, 40);
            this.M_plus.TabIndex = 0;
            this.M_plus.Text = "M+";
            this.M_plus.UseVisualStyleBackColor = true;
            this.M_plus.Click += new System.EventHandler(this.M_plus_Click);
            // 
            // M_minus
            // 
            this.M_minus.Location = new System.Drawing.Point(167, 129);
            this.M_minus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.M_minus.Name = "M_minus";
            this.M_minus.Size = new System.Drawing.Size(70, 40);
            this.M_minus.TabIndex = 0;
            this.M_minus.Text = "M-";
            this.M_minus.UseVisualStyleBackColor = true;
            this.M_minus.Click += new System.EventHandler(this.M_minus_Click);
            // 
            // MR
            // 
            this.MR.Location = new System.Drawing.Point(243, 129);
            this.MR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MR.Name = "MR";
            this.MR.Size = new System.Drawing.Size(70, 40);
            this.MR.TabIndex = 0;
            this.MR.Text = "MR";
            this.MR.UseVisualStyleBackColor = true;
            this.MR.Click += new System.EventHandler(this.MR_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(14, 176);
            this.Cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(70, 40);
            this.Cancel.TabIndex = 0;
            this.Cancel.Text = "C";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Negative
            // 
            this.Negative.Location = new System.Drawing.Point(90, 176);
            this.Negative.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Negative.Name = "Negative";
            this.Negative.Size = new System.Drawing.Size(70, 40);
            this.Negative.TabIndex = 0;
            this.Negative.Text = "±";
            this.Negative.UseVisualStyleBackColor = true;
            this.Negative.Click += new System.EventHandler(this.Negative_Click);
            // 
            // Division
            // 
            this.Division.Location = new System.Drawing.Point(167, 176);
            this.Division.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Division.Name = "Division";
            this.Division.Size = new System.Drawing.Size(70, 40);
            this.Division.TabIndex = 0;
            this.Division.Text = "÷";
            this.Division.UseVisualStyleBackColor = true;
            this.Division.Click += new System.EventHandler(this.Division_Click);
            // 
            // Multi
            // 
            this.Multi.Location = new System.Drawing.Point(243, 176);
            this.Multi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Multi.Name = "Multi";
            this.Multi.Size = new System.Drawing.Size(70, 40);
            this.Multi.TabIndex = 0;
            this.Multi.Text = "×";
            this.Multi.UseVisualStyleBackColor = true;
            this.Multi.Click += new System.EventHandler(this.Multi_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(14, 224);
            this.button7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(70, 40);
            this.button7.TabIndex = 0;
            this.button7.Text = "7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(90, 224);
            this.button8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(70, 40);
            this.button8.TabIndex = 0;
            this.button8.Text = "8";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(167, 224);
            this.button9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(70, 40);
            this.button9.TabIndex = 0;
            this.button9.Text = "9";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Minus
            // 
            this.Minus.Location = new System.Drawing.Point(243, 224);
            this.Minus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Minus.Name = "Minus";
            this.Minus.Size = new System.Drawing.Size(70, 40);
            this.Minus.TabIndex = 0;
            this.Minus.Text = "-";
            this.Minus.UseVisualStyleBackColor = true;
            this.Minus.Click += new System.EventHandler(this.Minus_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(14, 271);
            this.button4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 40);
            this.button4.TabIndex = 0;
            this.button4.Text = "4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(90, 271);
            this.button5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(70, 40);
            this.button5.TabIndex = 0;
            this.button5.Text = "5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(167, 271);
            this.button6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(70, 40);
            this.button6.TabIndex = 0;
            this.button6.Text = "6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Plus
            // 
            this.Plus.Location = new System.Drawing.Point(243, 271);
            this.Plus.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Plus.Name = "Plus";
            this.Plus.Size = new System.Drawing.Size(70, 40);
            this.Plus.TabIndex = 0;
            this.Plus.Text = "+";
            this.Plus.UseVisualStyleBackColor = true;
            this.Plus.Click += new System.EventHandler(this.Plus_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 319);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(90, 319);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(70, 40);
            this.button2.TabIndex = 0;
            this.button2.Text = "2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(167, 319);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(70, 40);
            this.button3.TabIndex = 0;
            this.button3.Text = "3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button0
            // 
            this.button0.Location = new System.Drawing.Point(14, 366);
            this.button0.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button0.Name = "button0";
            this.button0.Size = new System.Drawing.Size(146, 40);
            this.button0.TabIndex = 0;
            this.button0.Text = "0";
            this.button0.UseVisualStyleBackColor = true;
            this.button0.Click += new System.EventHandler(this.button0_Click);
            // 
            // ButtonDot
            // 
            this.ButtonDot.Location = new System.Drawing.Point(167, 366);
            this.ButtonDot.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonDot.Name = "ButtonDot";
            this.ButtonDot.Size = new System.Drawing.Size(70, 40);
            this.ButtonDot.TabIndex = 0;
            this.ButtonDot.Text = ".";
            this.ButtonDot.UseVisualStyleBackColor = true;
            this.ButtonDot.Click += new System.EventHandler(this.ButtonDot_Click);
            // 
            // Result
            // 
            this.Result.Location = new System.Drawing.Point(243, 319);
            this.Result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(70, 88);
            this.Result.TabIndex = 0;
            this.Result.Text = "=";
            this.Result.UseVisualStyleBackColor = true;
            this.Result.Click += new System.EventHandler(this.Result_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("굴림", 15F, System.Drawing.FontStyle.Bold);
            this.textBox1.Location = new System.Drawing.Point(15, 55);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(298, 49);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(339, 46);
            this.listBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(342, 364);
            this.listBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.Enabled = false;
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.textBox2.Location = new System.Drawing.Point(15, 16);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(298, 30);
            this.textBox2.TabIndex = 3;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_IP.Location = new System.Drawing.Point(336, 17);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(26, 17);
            this.lb_IP.TabIndex = 4;
            this.lb_IP.Text = "IP:";
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(368, 15);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(100, 25);
            this.txt_IP.TabIndex = 5;
            // 
            // lb_Port
            // 
            this.lb_Port.AutoSize = true;
            this.lb_Port.Font = new System.Drawing.Font("굴림", 10F);
            this.lb_Port.Location = new System.Drawing.Point(479, 16);
            this.lb_Port.Name = "lb_Port";
            this.lb_Port.Size = new System.Drawing.Size(43, 17);
            this.lb_Port.TabIndex = 4;
            this.lb_Port.Text = "Port:";
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(528, 14);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(100, 25);
            this.txt_Port.TabIndex = 5;
            // 
            // connected
            // 
            this.connected.Location = new System.Drawing.Point(634, 14);
            this.connected.Name = "connected";
            this.connected.Size = new System.Drawing.Size(47, 26);
            this.connected.TabIndex = 6;
            this.connected.Text = "연결";
            this.connected.UseVisualStyleBackColor = true;
            this.connected.Click += new System.EventHandler(this.connected_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 421);
            this.Controls.Add(this.connected);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.lb_Port);
            this.Controls.Add(this.txt_IP);
            this.Controls.Add(this.lb_IP);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Plus);
            this.Controls.Add(this.Minus);
            this.Controls.Add(this.Multi);
            this.Controls.Add(this.MR);
            this.Controls.Add(this.Result);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.Division);
            this.Controls.Add(this.M_minus);
            this.Controls.Add(this.ButtonDot);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button0);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.Negative);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.M_plus);
            this.Controls.Add(this.MC);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resultArrayBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.form1BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button MC;
        private System.Windows.Forms.Button M_plus;
        private System.Windows.Forms.Button M_minus;
        private System.Windows.Forms.Button MR;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button Negative;
        private System.Windows.Forms.Button Division;
        private System.Windows.Forms.Button Multi;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button Minus;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button Plus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Button ButtonDot;
        private System.Windows.Forms.Button Result;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource form1BindingSource;
        private System.Windows.Forms.BindingSource resultArrayBindingSource;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.Label lb_Port;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Button connected;
    }
}

