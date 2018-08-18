<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CadastroClientes.aspx.cs" Inherits="WebApplication1.CadastroClientes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <link rel="stylesheet" href="css/bootstrap.css"/>
</head>
<body>
        <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
          <a class="navbar-brand" href="#">OnGest</a>
          <div class="collapse navbar-collapse" id="navbarNavAltMarkup">
            <div class="navbar-nav">
              <a class="nav-item nav-link active" href="CadastroClientes.aspx">Clientes</a>
            </div>
          </div>
        </nav>  
    <form id="form1" runat="server">
     
        <div class="col" style="margin-top:10px;margin-bottom:100px;">
        <asp:Label ID="lblid" runat="server" Text="ID: " Visible="False"></asp:Label>
        <div class="form-group"><asp:TextBox ID="txtId" runat="server" Enabled="false" Visible="False"></asp:TextBox></div>
        <div class="form-group"><asp:Label ID="Label1" runat="server" Text="Nome do Cliente: "></asp:Label>
        <asp:TextBox ID="txtNomeCliente" Font-Italic="True" Font-Names="Georgia" runat="server" MaxLength="255"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Endereço do Cliente: "></asp:Label>
        <asp:TextBox ID="txtEnderecoCliente" Font-Italic="True" Font-Names="Georgia" runat="server" MaxLength="255"></asp:TextBox></div>
        <div class="form-group"><asp:Label ID="Label3" runat="server" Text="Email do Cliente: "></asp:Label>
        <asp:TextBox ID="txtEmailCliente" Font-Italic="True" Font-Names="Georgia" runat="server" MaxLength="255"></asp:TextBox>
        <asp:Label ID="Label4" runat="server" Text="Telefone do Cliente: "></asp:Label>
        <asp:TextBox ID="txtTelefoneCliente" Font-Italic="True" Font-Names="Georgia" runat="server" MaxLength="15"></asp:TextBox></div>
        <div class="form-group"><asp:Label ID="Label5" runat="server" Text="Status do Cliente: "></asp:Label>
        <asp:DropDownList ID="ddlStatusCliente" runat="server" Font-Italic="True" Font-Names="Georgia"></asp:DropDownList></div>
        <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label><br/>
        
        <asp:Button ID="btnSalvarNoBanco" CssClass="btn btn-primary" runat="server" Text="Salvar" OnClick="btnSalvarNoBanco_Click" />
        <asp:Button ID="btnAtualizarCliente" CssClass="btn btn-primary" runat="server" Text="Atualizar" OnClick="btnAtualizarCliente_Click" />
        <asp:Button ID="btnExcluirCliente" CssClass="btn btn-danger" runat="server" Text="Excluir" OnClientClick="if(!confirm('Deseja realmente excluir esse cliente?')) return false;" OnClick="btnExcluirCliente_Click" />
        <asp:Button ID="btnLimparCampos" CssClass="btn btn-primary" runat="server" Text="Limpar Campos" OnClick="btnLimparCampos_Click" />
        <br/>
        <asp:Button ID="btnPesquisar" CssClass="btn btn-primary" style="margin-top:5px;margin-bottom:5px;" runat="server" Text="Pesquisar" OnClick="btnPesquisar_Click" BorderStyle="None"/>
        <asp:TextBox ID="txtPesquisa" runat="server"></asp:TextBox>
        <asp:Button ID="btnVisualizarOpcoes" CssClass="btn btn-primary" runat="server" Text="Exibir Opções" OnClick="btnVisualizarOpcoes_Click" /><asp:Button ID="btnOcultarOpcoes" CssClass="btn btn-primary" runat="server" Text="Ocultar Opções" OnClick="btnOcultarOpcoes_Click" />   
        <asp:GridView ID="gvClienteCadastrado" CssClass="table" runat="server" DataKeyNames="Id,Status" AutoGenerateColumns="False" OnSelectedIndexChanged="gvClienteCadastrado_SelectedIndexChanged" BorderStyle="Solid" BorderWidth="3px" Font-Bold="False" Font-Italic="True" Font-Names="Georgia">
            <Columns>
                <asp:BoundField HeaderText="Nome do Cliente" DataField="Nome" />
                <asp:BoundField HeaderText="Endereço do Cliente" DataField="Endereco" />
                <asp:BoundField HeaderText="Email do Cliente" DataField="Email" />
                <asp:BoundField HeaderText="Telefone do Cliente" DataField="Telefone" />
                <asp:BoundField HeaderText="Status do Cliente" DataField="Desc_status" />
                <asp:CommandField ButtonType="Button" SelectText="Selecionar" ShowSelectButton="True" ControlStyle-CssClass="btn btn-primary">
                <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                </asp:CommandField>
            </Columns>
        </asp:GridView>
        </div>
    </form>

    <nav class="navbar navbar-expand-lg navbar-dark bg-primary fixed-bottom">
         <a class="navbar-brand" href="#">©AlphaTechnologies - 2018</a>
        </nav>  
</body>
</html>
