﻿namespace EmpanadasApp
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.label1 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAdd = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.linkReset = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(-2, -5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 256);
            this.label1.TabIndex = 17;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(316, 112);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(152, 20);
            this.txtUsuario.TabIndex = 47;
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(316, 149);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(152, 20);
            this.txtClave.TabIndex = 48;
            this.txtClave.TextChanged += new System.EventHandler(this.txtClave_TextChanged);
            this.txtClave.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtClave_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(266, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Usuario";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(249, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Font = new System.Drawing.Font("Magneto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label3.Location = new System.Drawing.Point(336, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 32);
            this.label3.TabIndex = 51;
            this.label3.Text = "Login";
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnAdd.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdd.IconSize = 20;
            this.btnAdd.Location = new System.Drawing.Point(298, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(84, 20);
            this.btnAdd.TabIndex = 52;
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Red;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnCancelar.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 20;
            this.btnCancelar.Location = new System.Drawing.Point(400, 188);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 20);
            this.btnCancelar.TabIndex = 53;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // linkReset
            // 
            this.linkReset.AutoSize = true;
            this.linkReset.Location = new System.Drawing.Point(440, 228);
            this.linkReset.Name = "linkReset";
            this.linkReset.Size = new System.Drawing.Size(53, 13);
            this.linkReset.TabIndex = 54;
            this.linkReset.TabStop = true;
            this.linkReset.Text = "Click aqui";
            this.linkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkReset_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label6.Location = new System.Drawing.Point(314, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 13);
            this.label6.TabIndex = 56;
            this.label6.Text = "Olvidaste tu contraseña?";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 72);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(524, 250);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkReset);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtClave);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLogin";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnAdd;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.LinkLabel linkReset;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}