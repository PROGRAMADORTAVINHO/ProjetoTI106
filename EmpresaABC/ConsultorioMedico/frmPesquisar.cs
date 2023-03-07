using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ConsultorioMedico
{
    public partial class frmPesquisar : Form
    {
        public frmPesquisar()
        {
            InitializeComponent();
            txtDescricao.Enabled = false;
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;
        }

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            txtDescricao.Enabled = true;
            txtDescricao.Focus();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtDescricao.Enabled = false;
            rdbNome.Checked = false;
            rdbCodigo.Checked = false;
            txtDescricao.Clear();
            ltbItensPesquisados.Items.Clear();

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbCodigo.Checked)
            {
                ltbItensPesquisados.Items.Clear();
                //ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaCodigo(txtDescricao.Text);

            }
            else if (rdbNome.Checked)
            {
                //ltbItensPesquisados.Items.Clear();
                //ltbItensPesquisados.Items.Add(txtDescricao.Text);
                pesquisaNome(txtDescricao.Text);
            }


        }

        public void pesquisaCodigo(string codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbPaciente where codpac = " + codigo + ";";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbItensPesquisados.Items.Clear();

            ltbItensPesquisados.Items.Add(DR.GetString(1));

            Conexao.fecharConexao();

        }

        public void pesquisaNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbPaciente where nome like '%" + nome + "%';";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();

            ltbItensPesquisados.Items.Clear();

            while (DR.Read())
            {

                ltbItensPesquisados.Items.Add(DR.GetString(1));
            }
            Conexao.fecharConexao();


        }

        //private void btnTeste_Click(object sender, EventArgs e)
        //{
        //    //Pegando o indice selecionado

        //    //int i = ltbItensPesquisados.SelectedIndex;

        //    //MessageBox.Show("O indice selecionado foi " + i);

        //    //Pegando o valor selecionado

        //    //string valor = ltbItensPesquisados.SelectedItem.ToString();

        //    // MessageBox.Show("O valor selecionado foi: " + valor);
        //}

        private void ltbItensPesquisados_SelectedIndexChanged(object sender, EventArgs e)
        {
            string valor = ltbItensPesquisados.SelectedItem.ToString();
            //MessageBox.Show("Resultado: " + valor);
            frmPacientes abrir = new frmPacientes(valor);
            abrir.Show();
            this.Hide();

        }
    }
}
