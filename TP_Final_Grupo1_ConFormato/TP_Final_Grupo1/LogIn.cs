using Datos;
using Entidades;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace TP_Final_Grupo1
{
    public partial class frm_Login : Form
    {
        private UsuarioConsulta usuarioConsulta;
        private List<Permiso> permisos;
        private Administrador administrador;
        private Vendedor vendedor;
        private LogInLogica logica;
        private PermisoConsulta permisoConsulta;

        public frm_Login()
        {
            InitializeComponent();
            usuarioConsulta = new UsuarioConsulta(); // Nueva instancia de UsuarioConsulta
            logica = new LogInLogica(usuarioConsulta); // Pasar la instancia de UsuarioConsulta

            // Crear una instancia de PermisoConsulta y paso la conexión
            permisoConsulta = new PermisoConsulta(new ConexionMySql());

            // Cargamos permisos desde la base de datos
            permisos = permisoConsulta.CargarPermisos();
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txt_Usuario.Text;
                string contraseña = txt_Contrasenia.Text;

                Usuario usuarioAutenticado = usuarioConsulta.Login(usuario, contraseña);

                if (usuarioAutenticado != null)
                {
                    if (usuarioAutenticado.Bloqueado)
                    {
                        MessageBox.Show("Usuario Bloqueado", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (usuarioAutenticado.Permisos.Any())
                        {
                            bool tienePermiso = usuarioAutenticado.Permisos.Any(permiso => permisos.Any(p => p.Descripcion == permiso.Descripcion)); // explicar esto que no lo termoino de entender

                            if (tienePermiso)
                            {
                                if (usuarioAutenticado.Permisos[0].Descripcion == "usuario admin")
                                {
                                    Form administrador = new Administrador();
                                    MostrarForm(administrador);
                                    this.Hide();
                                }
                                else if (usuarioAutenticado.Permisos[0].Descripcion == "usuario consulta")
                                {
                                    Form vendedor = new Vendedor();
                                    MostrarForm(vendedor);
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("El usuario no tiene permisos para esta acción.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("El usuario no tiene permisos asignados.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error de autenticación. Verifique su nombre de usuario y contraseña.");
                }

                txt_Usuario.Text = "";
                txt_Contrasenia.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }
        private void MostrarForm(Form objForm)
        {
            objForm.StartPosition = FormStartPosition.CenterScreen;
            objForm.Show();

            // Manejar el evento FormClosed de Form1 para mostrar LogIn nuevamente
            objForm.FormClosed += (sender, e) =>
            {
                if (administrador != null)
                {
                    administrador.Dispose(); // Libera recursos del formulario Form1
                }
                administrador = null; // Establece la referencia a Form1 como nula               

                if (vendedor != null)
                {
                    vendedor.Dispose();
                }
                vendedor = null; // Establece la referencia a Form1 como nula
                this.Show(); // Muestra LogIn nuevamente

            };

        }
    }
}
