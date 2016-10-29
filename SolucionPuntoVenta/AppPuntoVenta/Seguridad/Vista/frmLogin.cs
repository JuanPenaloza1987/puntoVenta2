﻿using SRATAPV.Seguridad.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPuntoVenta.Seguridad.Vista
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            clsLogin cLogin = new clsLogin();
            cLogin.usuario = txtUsuario.Text;
            cLogin.pwd = txtContrasena.Text;

            string mensaje = "";
            try
            {
                if (cLogin.autentificar())
                {
                    clsUsuarios cUsuario = new clsUsuarios();
                    DataTable usuario = cUsuario.leerUnicoUsuario(txtUsuario.Text).Tables[0];
                    Sesion.Usuario = usuario.Rows[0][0].ToString();
                    Sesion.NombreUsuario = usuario.Rows[0][2].ToString();

                    Sesion.Permisos = cLogin.leerPermisosPorUsuario(txtUsuario.Text);
                    DialogResult = DialogResult.OK;
                    if (Sesion.Permisos.Count == 0)
                    {
                        MessageBox.Show("El usuario no tiene permisos asignados", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    Close();
                }
                else
                {
                    MessageBox.Show("El usuario y/o contraseña son incorrectos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
