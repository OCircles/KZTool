namespace KZTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonRoomList = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.hotkeyHardReset = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.hotkeySetRoom = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.hotkeyPreviousRoom = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.hotkeyNextRoom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonSetRoom = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer_read = new System.Windows.Forms.Timer(this.components);
            this.timer_switchLock = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer_findgame_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonRoomList);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.buttonSetRoom);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 227);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Katana ZERO";
            // 
            // buttonRoomList
            // 
            this.buttonRoomList.Location = new System.Drawing.Point(222, 51);
            this.buttonRoomList.Name = "buttonRoomList";
            this.buttonRoomList.Size = new System.Drawing.Size(25, 23);
            this.buttonRoomList.TabIndex = 6;
            this.buttonRoomList.Text = "+";
            this.buttonRoomList.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.hotkeyHardReset);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.hotkeySetRoom);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.hotkeyPreviousRoom);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.hotkeyNextRoom);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(35, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 131);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Hotkeys";
            // 
            // hotkeyHardReset
            // 
            this.hotkeyHardReset.Location = new System.Drawing.Point(16, 97);
            this.hotkeyHardReset.Name = "hotkeyHardReset";
            this.hotkeyHardReset.ReadOnly = true;
            this.hotkeyHardReset.Size = new System.Drawing.Size(100, 20);
            this.hotkeyHardReset.TabIndex = 9;
            this.hotkeyHardReset.Tag = "";
            this.hotkeyHardReset.Text = "R";
            this.hotkeyHardReset.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey_KeyDown);
            this.hotkeyHardReset.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hotkey_MouseDown);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hard Reset";
            // 
            // hotkeySetRoom
            // 
            this.hotkeySetRoom.Location = new System.Drawing.Point(16, 71);
            this.hotkeySetRoom.Name = "hotkeySetRoom";
            this.hotkeySetRoom.ReadOnly = true;
            this.hotkeySetRoom.Size = new System.Drawing.Size(100, 20);
            this.hotkeySetRoom.TabIndex = 7;
            this.hotkeySetRoom.Tag = "";
            this.hotkeySetRoom.Text = "F5";
            this.hotkeySetRoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey_KeyDown);
            this.hotkeySetRoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hotkey_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(123, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Set Room ";
            // 
            // hotkeyPreviousRoom
            // 
            this.hotkeyPreviousRoom.Location = new System.Drawing.Point(16, 45);
            this.hotkeyPreviousRoom.Name = "hotkeyPreviousRoom";
            this.hotkeyPreviousRoom.ReadOnly = true;
            this.hotkeyPreviousRoom.Size = new System.Drawing.Size(100, 20);
            this.hotkeyPreviousRoom.TabIndex = 5;
            this.hotkeyPreviousRoom.Tag = "";
            this.hotkeyPreviousRoom.Text = "F1";
            this.hotkeyPreviousRoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey_KeyDown);
            this.hotkeyPreviousRoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hotkey_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(123, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Previous Room ";
            // 
            // hotkeyNextRoom
            // 
            this.hotkeyNextRoom.Location = new System.Drawing.Point(16, 19);
            this.hotkeyNextRoom.Name = "hotkeyNextRoom";
            this.hotkeyNextRoom.ReadOnly = true;
            this.hotkeyNextRoom.Size = new System.Drawing.Size(100, 20);
            this.hotkeyNextRoom.TabIndex = 3;
            this.hotkeyNextRoom.Tag = "";
            this.hotkeyNextRoom.Text = "F2";
            this.hotkeyNextRoom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Hotkey_KeyDown);
            this.hotkeyNextRoom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Hotkey_MouseDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Next Room ";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(35, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "4";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // buttonSetRoom
            // 
            this.buttonSetRoom.Location = new System.Drawing.Point(141, 51);
            this.buttonSetRoom.Name = "buttonSetRoom";
            this.buttonSetRoom.Size = new System.Drawing.Size(75, 23);
            this.buttonSetRoom.TabIndex = 1;
            this.buttonSetRoom.Text = "Set Room";
            this.buttonSetRoom.UseVisualStyleBackColor = true;
            this.buttonSetRoom.Click += new System.EventHandler(this.buttonSetRoom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Room: -----";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 242);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(140, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Katana ZERO is not running";
            // 
            // timer_read
            // 
            this.timer_read.Interval = 1000;
            this.timer_read.Tick += new System.EventHandler(this.timer_read_Tick);
            // 
            // timer_switchLock
            // 
            this.timer_switchLock.Interval = 1000;
            this.timer_switchLock.Tick += new System.EventHandler(this.Timer_switchLock_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 264);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "KZ Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSetRoom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer_read;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox hotkeyNextRoom;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox hotkeyPreviousRoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hotkeySetRoom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Timer timer_switchLock;
        private System.Windows.Forms.TextBox hotkeyHardReset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonRoomList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

