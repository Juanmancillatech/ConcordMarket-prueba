<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Marketwebform.Login" %>

<!DOCTYPE html >

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Content/bootstrap.css" />
    <link rel="stylesheet" href="Content/bootstrap-theme.css" />
    <link rel="stylesheet" href="Content/site.css" />
    <script src="Scripts/angular.min.js"></script>
    <title>Login</title>
</head>
<body>
<div class="container">

    <h2>Login</h2>
    <form method="post" class="" runat="server" id="loginform">
    
        <div class="col-lg-12 col-md-12 col-sm-12">
            <div class="row">
                <p><h3>Usuario:</h3></p>
                <asp:Textbox  runat="server" id="usuario" name="usuario" class="form-control" />
            </div>
            <br />
            <div class="row">
                <p><h3>Contraseña:</h3></p>
                <asp:Textbox type="password" runat="server" id="clave" class="form-control" name="clave" />
            </div>
            <br />
            <div class="row">
                <asp:button  runat="server" class="btn btn-primary btn-lg" OnClick="btn_click"  id="entrar" value="Entrar" Text="Entrar" />
            </div>
            <br />
            <div class="row">
                <asp:Label ID="error" runat="server" CssClass="alert-danger glyphicon-text-color:red" Text=""></asp:Label>
            </div>
        </div>
    </form>
    
 </div>
</body>
</html>
