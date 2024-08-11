using EmpanadasApp.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace EmpanadasApp
{
    public partial class Mainfrm : Form
    {
        private static CUsuario _usuario;
        public Mainfrm(CUsuario usuario)
        {
            _usuario = usuario;
           
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuariofrm usuariofrm = new Usuariofrm();
            usuariofrm.Show();  
            this.Hide();

        }

        private void Mainfrm_Load(object sender, EventArgs e)
        {
           lblNombre.Text = _usuario.Nombre;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
           DialogResult dr = System.Windows.Forms.MessageBox.Show("Seguro desea salir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                System.Windows.Forms.Application.Exit();
                
            }
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dr = System.Windows.Forms.MessageBox.Show("Seguro desea salir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                login.Show();
                this.Hide();

            }
        }

        private void btnEstable_Click(object sender, EventArgs e)
        {
            TipoE tipoE = new TipoE();
            tipoE.Show();
            this.Hide();
        }

        private void btnCompra_Click(object sender, EventArgs e)
        {
            frmComprascs frmComprascs = new frmComprascs();
            frmComprascs.Show();
            this.Hide();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frmProductos = new frmProductos();
            frmProductos.Show();
            this.Hide();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            FrmVenta frmVenta = new FrmVenta();
            frmVenta.Show();
            this.Hide();
        }

        private void bntReporte_Click(object sender, EventArgs e)
        {
            FrmReportes frmrRep = new FrmReportes();
            frmrRep.Show();
            this.Hide();
        }

        private void btnhistorial_Click(object sender, EventArgs e)
        {
            frmhistorial frmh = new frmhistorial();
            frmh.Show();
            this.Hide();
        }

        private void btnTrending_Click(object sender, EventArgs e)
        {
            frmtrend frmtrend = new frmtrend();
            frmtrend.Show();
            this.Hide();
        }

        private void iconPictureBox1_MouseHover(object sender, EventArgs e)
        {
            iconPictureBox1.IconColor = Color.Red;
        }

        private void iconPictureBox1_MouseLeave(object sender, EventArgs e)
        {
            iconPictureBox1.IconColor = Color.Lime;
        }
    }
}
