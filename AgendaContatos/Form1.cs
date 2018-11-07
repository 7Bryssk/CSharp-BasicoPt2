using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaContatos
{
    public partial class frmAgendaContatos : Form
    {

        private OperacaoEnum acao;

        public frmAgendaContatos()
        {
            InitializeComponent();
        }

        private void frmAgendaContatos_Shown(object sender, EventArgs e)
        {
            EstadoComponentes(false);
            CarregarListaContatos();
        }

        private void EstadoComponentes(bool estado)
        {
            btnSalvar.Enabled = estado;
            btnCanelar.Enabled = estado;
            txtNome.Enabled = estado;
            txtEmail.Enabled = estado;
            txtTelefone.Enabled = estado;
            btnIncluir.Enabled = !estado;
            btnAlterar.Enabled = !estado;
            btnExcluir.Enabled = !estado;
            txtNome.Text = "";
            txtEmail.Text = "";
            txtTelefone.Text = "";
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            EstadoComponentes(true);
            acao = OperacaoEnum.INCLUIR;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            EstadoComponentes(true);
            PreencherSelecionado();
            acao = OperacaoEnum.ALTERAR;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            List<Contato> contatosList = new List<Contato>();

            foreach (Contato contatoLista in lbxContatos.Items)
            {
                contatosList.Add(contatoLista);
            }

            contatosList.RemoveAt(lbxContatos.SelectedIndex);

            ManipuladorArquivo.EscreverArquivo(contatosList);
            CarregarListaContatos();

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Contato contato = new Contato
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text
            };

            List<Contato> contatosList = new List<Contato>();

            foreach (Contato contatoLista in lbxContatos.Items)
            {
                contatosList.Add(contatoLista);
            }

            if (acao == OperacaoEnum.INCLUIR)
            {
                contatosList.Add(contato);
            }
            else if(acao == OperacaoEnum.ALTERAR)
            {
                contatosList[lbxContatos.SelectedIndex] = contato;
            }

            ManipuladorArquivo.EscreverArquivo(contatosList);

            CarregarListaContatos();

            EstadoComponentes(false);
        }

        private void CarregarListaContatos()
        {
            lbxContatos.Items.Clear();
            lbxContatos.Items.AddRange(ManipuladorArquivo.LerArquivo().ToArray());
        }

        private void btnCanelar_Click(object sender, EventArgs e)
        {
            EstadoComponentes(false);
        }

        private void lbxContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            PreencherSelecionado();
        }

        private void PreencherSelecionado()
        {
            Contato contato = (Contato)lbxContatos.Items[lbxContatos.SelectedIndex];

            txtNome.Text = contato.Nome;
            txtEmail.Text = contato.Email;
            txtTelefone.Text = contato.Telefone;
        }
    }
}
