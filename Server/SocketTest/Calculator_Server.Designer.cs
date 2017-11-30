namespace SocketTest
{
    partial class Calculator_Server
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calculator_Server));
            this.txt_IP = new System.Windows.Forms.TextBox();
            this.txt_Port = new System.Windows.Forms.TextBox();
            this.lb_Port = new System.Windows.Forms.Label();
            this.lb_IP = new System.Windows.Forms.Label();
            this.txt_history = new System.Windows.Forms.TextBox();
            this.start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_IP
            // 
            this.txt_IP.Location = new System.Drawing.Point(75, 14);
            this.txt_IP.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_IP.Name = "txt_IP";
            this.txt_IP.Size = new System.Drawing.Size(154, 21);
            this.txt_IP.TabIndex = 0;
            // 
            // txt_Port
            // 
            this.txt_Port.Location = new System.Drawing.Point(277, 14);
            this.txt_Port.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Port.Name = "txt_Port";
            this.txt_Port.Size = new System.Drawing.Size(154, 21);
            this.txt_Port.TabIndex = 0;
            this.txt_Port.Text = "50000";
            // 
            // lb_Port
            // 
            this.lb_Port.AutoSize = true;
            this.lb_Port.Location = new System.Drawing.Point(242, 17);
            this.lb_Port.Name = "lb_Port";
            this.lb_Port.Size = new System.Drawing.Size(27, 12);
            this.lb_Port.TabIndex = 1;
            this.lb_Port.Text = "Port";
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(10, 17);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(56, 12);
            this.lb_IP.TabIndex = 1;
            this.lb_IP.Text = "IPAdress";
            // 
            // txt_history
            // 
            this.txt_history.BackColor = System.Drawing.Color.White;
            this.txt_history.Enabled = false;
            this.txt_history.Location = new System.Drawing.Point(13, 46);
            this.txt_history.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_history.Multiline = true;
            this.txt_history.Name = "txt_history";
            this.txt_history.ReadOnly = true;
            this.txt_history.Size = new System.Drawing.Size(534, 267);
            this.txt_history.TabIndex = 2;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(448, 14);
            this.start.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(99, 20);
            this.start.TabIndex = 3;
            this.start.Text = "시작";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // Calculator_Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 322);
            this.Controls.Add(this.start);
            this.Controls.Add(this.txt_history);
            this.Controls.Add(this.lb_IP);
            this.Controls.Add(this.lb_Port);
            this.Controls.Add(this.txt_Port);
            this.Controls.Add(this.txt_IP);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Calculator_Server";
            this.Text = "Calculator Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_IP;
        private System.Windows.Forms.TextBox txt_Port;
        private System.Windows.Forms.Label lb_Port;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.TextBox txt_history;
        private System.Windows.Forms.Button start;
    }
}

