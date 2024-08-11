namespace EmpanadasApp
{
    partial class Mainfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainfrm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnUsuario = new FontAwesome.Sharp.IconButton();
            this.btnEstable = new FontAwesome.Sharp.IconButton();
            this.btnCompra = new FontAwesome.Sharp.IconButton();
            this.btnProductos = new FontAwesome.Sharp.IconButton();
            this.btnVentas = new FontAwesome.Sharp.IconButton();
            this.bntReporte = new FontAwesome.Sharp.IconButton();
            this.btnTrending = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnhistorial = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Orange;
            this.label1.Location = new System.Drawing.Point(-3, -1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1013, 120);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Orange;
            this.label2.Font = new System.Drawing.Font("Magneto", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(361, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Asistente de ventas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Orange;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(786, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bienvenido:";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.BackColor = System.Drawing.Color.Orange;
            this.lblNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblNombre.Location = new System.Drawing.Point(877, 90);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(23, 18);
            this.lblNombre.TabIndex = 4;
            this.lblNombre.Text = "Bi";
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuario.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUsuario.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnUsuario.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuario.IconSize = 80;
            this.btnUsuario.Location = new System.Drawing.Point(100, 213);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(141, 119);
            this.btnUsuario.TabIndex = 6;
            this.btnUsuario.Text = "Configuracion";
            this.btnUsuario.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnEstable
            // 
            this.btnEstable.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnEstable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEstable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstable.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEstable.IconChar = FontAwesome.Sharp.IconChar.BuildingUser;
            this.btnEstable.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEstable.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEstable.IconSize = 75;
            this.btnEstable.Location = new System.Drawing.Point(322, 213);
            this.btnEstable.Name = "btnEstable";
            this.btnEstable.Size = new System.Drawing.Size(141, 119);
            this.btnEstable.TabIndex = 8;
            this.btnEstable.Text = "Informacion de establecimiento";
            this.btnEstable.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEstable.UseVisualStyleBackColor = false;
            this.btnEstable.Click += new System.EventHandler(this.btnEstable_Click);
            // 
            // btnCompra
            // 
            this.btnCompra.BackColor = System.Drawing.Color.Red;
            this.btnCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompra.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCompra.IconChar = FontAwesome.Sharp.IconChar.CartArrowDown;
            this.btnCompra.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnCompra.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCompra.IconSize = 80;
            this.btnCompra.Location = new System.Drawing.Point(558, 213);
            this.btnCompra.Name = "btnCompra";
            this.btnCompra.Size = new System.Drawing.Size(141, 119);
            this.btnCompra.TabIndex = 9;
            this.btnCompra.Text = "Compras";
            this.btnCompra.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCompra.UseVisualStyleBackColor = false;
            this.btnCompra.Click += new System.EventHandler(this.btnCompra_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProductos.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProductos.IconChar = FontAwesome.Sharp.IconChar.Warehouse;
            this.btnProductos.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProductos.IconSize = 80;
            this.btnProductos.Location = new System.Drawing.Point(100, 394);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(141, 119);
            this.btnProductos.TabIndex = 10;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnVentas
            // 
            this.btnVentas.BackColor = System.Drawing.Color.Orange;
            this.btnVentas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVentas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVentas.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVentas.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnVentas.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVentas.IconSize = 80;
            this.btnVentas.Location = new System.Drawing.Point(773, 213);
            this.btnVentas.Name = "btnVentas";
            this.btnVentas.Size = new System.Drawing.Size(141, 119);
            this.btnVentas.TabIndex = 11;
            this.btnVentas.Text = "Ventas";
            this.btnVentas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnVentas.UseVisualStyleBackColor = false;
            this.btnVentas.Click += new System.EventHandler(this.btnVentas_Click);
            // 
            // bntReporte
            // 
            this.bntReporte.BackColor = System.Drawing.Color.Crimson;
            this.bntReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntReporte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntReporte.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.bntReporte.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bntReporte.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.bntReporte.IconSize = 80;
            this.bntReporte.Location = new System.Drawing.Point(558, 394);
            this.bntReporte.Name = "bntReporte";
            this.bntReporte.Size = new System.Drawing.Size(141, 119);
            this.bntReporte.TabIndex = 12;
            this.bntReporte.Text = "Reportes";
            this.bntReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.bntReporte.UseVisualStyleBackColor = false;
            this.bntReporte.Click += new System.EventHandler(this.bntReporte_Click);
            // 
            // btnTrending
            // 
            this.btnTrending.BackColor = System.Drawing.Color.Plum;
            this.btnTrending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrending.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrending.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTrending.IconChar = FontAwesome.Sharp.IconChar.ChartGantt;
            this.btnTrending.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTrending.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTrending.IconSize = 80;
            this.btnTrending.Location = new System.Drawing.Point(773, 394);
            this.btnTrending.Name = "btnTrending";
            this.btnTrending.Size = new System.Drawing.Size(141, 119);
            this.btnTrending.TabIndex = 13;
            this.btnTrending.Text = "Trending";
            this.btnTrending.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnTrending.UseVisualStyleBackColor = false;
            this.btnTrending.Click += new System.EventHandler(this.btnTrending_Click);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Orange;
            this.iconPictureBox1.ForeColor = System.Drawing.Color.Lime;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.iconPictureBox1.IconColor = System.Drawing.Color.Lime;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 63;
            this.iconPictureBox1.Location = new System.Drawing.Point(928, -1);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(82, 63);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox1.TabIndex = 27;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            this.iconPictureBox1.MouseLeave += new System.EventHandler(this.iconPictureBox1_MouseLeave);
            this.iconPictureBox1.MouseHover += new System.EventHandler(this.iconPictureBox1_MouseHover);
            // 
            // btnhistorial
            // 
            this.btnhistorial.BackColor = System.Drawing.Color.SlateBlue;
            this.btnhistorial.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnhistorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhistorial.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhistorial.IconChar = FontAwesome.Sharp.IconChar.FileEdit;
            this.btnhistorial.IconColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnhistorial.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnhistorial.IconSize = 80;
            this.btnhistorial.Location = new System.Drawing.Point(322, 394);
            this.btnhistorial.Name = "btnhistorial";
            this.btnhistorial.Size = new System.Drawing.Size(141, 119);
            this.btnhistorial.TabIndex = 28;
            this.btnhistorial.Text = "Historial";
            this.btnhistorial.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnhistorial.UseVisualStyleBackColor = false;
            this.btnhistorial.Click += new System.EventHandler(this.btnhistorial_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(413, 538);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Joeldiaz703.jd@gmail.com";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(23, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 30;
            this.pictureBox1.TabStop = false;
            // 
            // Mainfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 563);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnhistorial);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.btnTrending);
            this.Controls.Add(this.bntReporte);
            this.Controls.Add(this.btnVentas);
            this.Controls.Add(this.btnProductos);
            this.Controls.Add(this.btnCompra);
            this.Controls.Add(this.btnEstable);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mainfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Panel";
            this.Load += new System.EventHandler(this.Mainfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombre;
        private FontAwesome.Sharp.IconButton btnUsuario;
        private FontAwesome.Sharp.IconButton btnEstable;
        private FontAwesome.Sharp.IconButton btnCompra;
        private FontAwesome.Sharp.IconButton btnProductos;
        private FontAwesome.Sharp.IconButton btnVentas;
        private FontAwesome.Sharp.IconButton bntReporte;
        private FontAwesome.Sharp.IconButton btnTrending;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton btnhistorial;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

