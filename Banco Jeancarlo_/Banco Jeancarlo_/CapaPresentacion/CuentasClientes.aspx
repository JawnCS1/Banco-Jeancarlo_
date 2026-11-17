<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CuentasClientes.aspx.cs" Inherits="Banco.CapaPresentacion.CuentasClientes" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cuentas de clientes</title>
    <link rel="stylesheet" type="text/css" href="/css/Estilos.css" />
</head>
<body>
<form id="form1" runat="server">
    <div>
        <ul>
            <li><a href="Inicio.aspx">Inicio</a></li>
            <li><a href="Clientes.aspx">Clientes</a></li>
            <li><a class="active" href="CuentasClientes.aspx">Cuentas de clientes</a></li>
        </ul>
    </div>
    <h1>Gestión de Cuentas de Clientes</h1>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    <br />
    <asp:Label ID="lblcodigo" runat="server" Text="Código de cuenta"></asp:Label>
    <asp:TextBox ID="txtcodigo" runat="server"></asp:TextBox><br />
    <asp:Label ID="lbltipo" runat="server" Text="Tipo"></asp:Label>
    <asp:TextBox ID="txttipo" runat="server"></asp:TextBox><br />
    <asp:Label ID="lblcodigocliente" runat="server" Text="Código del cliente"></asp:Label>
    <asp:TextBox ID="txtcodigocliente" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Cuenta" OnClick="btnAgregar_Click" />
    <asp:Button ID="btnBorrar" runat="server" Text="Borrar Cuenta" OnClick="btnBorrar_Click" />
    <asp:Button ID="btnEditar" runat="server" Text="Modificar Cuenta" OnClick="btnEditar_Click" />
    <br /><br />
    <asp:Label ID="lblMensaje" runat="server"></asp:Label>
</form>
</body>
</html>