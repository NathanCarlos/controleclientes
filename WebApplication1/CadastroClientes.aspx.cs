using Library.BLL;
using Library.Business;
using Library.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CadastroClientes : System.Web.UI.Page
    {
        Cliente c = new Cliente();
        ClienteBLL depService = new ClienteBLL();
        StatusClienteBLL statusClienteService = new StatusClienteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<StatusCliente> listaStatusCliente = statusClienteService.FindAll();
                ddlStatusCliente.DataSource = listaStatusCliente;
                ddlStatusCliente.DataValueField = "Id";
                ddlStatusCliente.DataTextField = "Descricao";
                ddlStatusCliente.DataBind();

                CarregarClientes();
                OcultaOpcoes();
            }
            
        }

        protected void btnSalvarNoBanco_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text != "" && txtEnderecoCliente.Text != "")
            {
                try
                {
                    List<Cliente> listaClientes = new List<Cliente>();
                    bool salvou = false;


                    Cliente d1 = new Cliente();
                    d1.Nome = txtNomeCliente.Text;
                    d1.Endereco = txtEnderecoCliente.Text;
                    d1.Email = txtEmailCliente.Text;
                    d1.Telefone = txtTelefoneCliente.Text;
                    d1.Status = Convert.ToInt32(ddlStatusCliente.SelectedValue);
                    listaClientes.Add(d1);
                    gvClienteCadastrado.DataSource = listaClientes;
                    gvClienteCadastrado.DataBind();
                    foreach (Cliente d in listaClientes)
                    {
                        salvou = depService.Insert(d);
                    }
                    if (salvou)
                    {
                        lblMensagem.Text = "O cliente foi inserido com sucesso!";
                        CarregarClientes();
                    }
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
            else
            {
                lblMensagem.Text = "Os campos de nome e endereço são obrigatórios, preencha os dois."; 
            }
        }

        protected void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
            LimpaMensagem();
        }
        private void LimparCampos()
        {
            txtId.Text = "";
            txtNomeCliente.Text = "";
            txtEmailCliente.Text = "";
            txtTelefoneCliente.Text = "";
            txtEnderecoCliente.Text = "";
            txtPesquisa.Text = "";
            CarregarClientes();
        }
        public void CarregarClientes()
        {
            gvClienteCadastrado.DataSource = depService.FindALL();
            gvClienteCadastrado.DataBind();
        }
        public void setCliente(Cliente c)
        {
            txtId.Text = c.Id.ToString();
            txtNomeCliente.Text = c.Nome;
            txtEnderecoCliente.Text = c.Endereco;
            txtEmailCliente.Text = c.Email;
            txtTelefoneCliente.Text = c.Telefone;
            ddlStatusCliente.SelectedValue = c.Status.ToString();
        }

        protected void gvClienteCadastrado_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvClienteCadastrado.SelectedDataKey["Id"].ToString());
            Cliente cliservice = depService.FindById(id);
            setCliente(cliservice);
            LimpaMensagem();
        }

        protected void btnAtualizarCliente_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text != "" && txtEnderecoCliente.Text != "")
            {
                try
                {
                    Cliente c = new Cliente();
                    c.Nome = txtNomeCliente.Text;
                    c.Email = txtEmailCliente.Text;
                    c.Endereco = txtEnderecoCliente.Text;
                    c.Telefone = txtTelefoneCliente.Text;
                    c.Status = Convert.ToInt32(ddlStatusCliente.Text);
                    c.Id = Convert.ToInt32(txtId.Text);

                    bool atualizou = depService.Update(c);
                    if (atualizou)
                    {
                        lblMensagem.Text = "O cliente: " + c.Nome + ", foi atualizado com sucesso!";
                    }
                    CarregarClientes();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
                LimparCampos();
            }
            else
            {
                lblMensagem.Text = "Os campos de nome e endereço são obrigatórios, preencha os dois.";     
            }
            
        }

        protected void btnExcluirCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(txtId.Text);
                lblMensagem.Text = "Cliente excluído com sucesso!";
                bool excluiu = depService.Delete(id);

                if (excluiu)
                {
                    
                    CarregarClientes();
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            LimparCampos();
        }

        protected void btnPesquisar_Click(object sender, EventArgs e)
        {
            List<Cliente> listCliente = new List<Cliente>();

            foreach (GridViewRow linha in gvClienteCadastrado.Rows)
            {
                Cliente dLinha = new Cliente();
                dLinha.Nome = linha.Cells[0].Text;
                dLinha.Endereco = linha.Cells[1].Text;
                dLinha.Email = linha.Cells[2].Text;
                dLinha.Telefone = linha.Cells[3].Text;
                dLinha.Desc_status = linha.Cells[4].Text;

                listCliente.Add(dLinha);
            }
            Session["SessionClientes"] = listCliente;
            List<Cliente> listFiltro = (from r in listCliente
                                        where r.Nome.Contains(txtPesquisa.Text)
                                        select r).ToList();
            gvClienteCadastrado.DataSource = listFiltro;
            gvClienteCadastrado.DataBind();
        }
        private void LimpaMensagem()
        {
            lblMensagem.Text = "";
        }

        protected void btnVisualizarOpcoes_Click(object sender, EventArgs e)
        {
             
            if (txtNomeCliente.Visible == false)
            {
                ExibeOpcoes();
            }
        }
        private void ExibeOpcoes()
        {
            txtId.Visible = false;
            txtEmailCliente.Visible = true;
            txtNomeCliente.Visible = true;
            txtEnderecoCliente.Visible = true;
            txtTelefoneCliente.Visible = true;
            ddlStatusCliente.Visible = true;
            btnAtualizarCliente.Visible = true;
            btnSalvarNoBanco.Visible = true;
            btnExcluirCliente.Visible = true;
            btnLimparCampos.Visible = true;
            Label1.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
            btnVisualizarOpcoes.Visible = false;
            btnOcultarOpcoes.Visible = true;
        }
        private void OcultaOpcoes()
        {
            txtEmailCliente.Visible = false;
            txtNomeCliente.Visible = false;
            txtEnderecoCliente.Visible = false;
            txtTelefoneCliente.Visible = false;
            ddlStatusCliente.Visible = false;
            btnAtualizarCliente.Visible = false;
            btnSalvarNoBanco.Visible = false;
            btnExcluirCliente.Visible = false;
            btnLimparCampos.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            btnVisualizarOpcoes.Visible = true;
            btnOcultarOpcoes.Visible = false;
        }

        protected void btnOcultarOpcoes_Click(object sender, EventArgs e)
        {
            OcultaOpcoes();
        }
        
    }
}