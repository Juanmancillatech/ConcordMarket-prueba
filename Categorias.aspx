<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categorias.aspx.cs" Inherits="Marketwebform.Categorias" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <div class="col-lg-12 col-md-12 col-sm-12">
        <h2>Categoria:</h2>
           <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
               <ContentTemplate>
            <div class="row">
                <asp:Label ID="catid" runat="server" Text="ID" CssClass=""></asp:Label>
                <input runat="server" id="catinid" name="catinid" class="form-control" readonly="readonly" />
            </div>
            <br />
            <div class="row">
                <asp:Label ID="catnom" runat="server" Text="Nombre" CssClass=""></asp:Label>
                <input runat="server" id="catnombre" name="catnombre" class="form-control" />
            </div>
              </ContentTemplate>
           </asp:UpdatePanel>
            <br />
            <div class="row inline">
                <asp:Button ID="Nuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btn_lg" OnClick="NuevoClick" />
                <asp:Button ID="guardar" runat="server" Text="Guardar" CssClass="btn btn-success btn_lg" OnClick="GuardarClick" />
                <asp:Button ID="eliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger btn_lg" OnClick="EliminarClick" />
                <asp:Button ID="modificar" runat="server" Text="Modificar" CssClass="btn btn-warning btn_lg" OnClick="ModificarClick" />
            </div>
        <br />
            <div class="row">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode ="Conditional" >
                    <ContentTemplate>
                        <asp:GridView ID="GridCat" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr" RowStyle-CssClass="rows" AllowPaging="true"
                            AutoGenerateColumns="False" Style="width: 100%; font-size: small" DataKeyNames="id" ShowFooter="true" OnRowCommand="GridCat_RowCommand" DataSourceID="SqlDataSource1">
                            <Columns>
                                <asp:BoundField DataField="id" HeaderStyle-CssClass="text-left headertxt" ItemStyle-CssClass="text-left lines" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id"></asp:BoundField>
                                <asp:BoundField DataField="nombre" ItemStyle-CssClass="text-left lines" HeaderStyle-CssClass="text-Left headertxt" HeaderText="Nombre de Categoria" SortExpression="nombre"></asp:BoundField>
                                <asp:ButtonField CommandName="Selectedrow"  Text="Seleccionar" ControlStyle-CssClass="btn btn-info"  ButtonType="Button"></asp:ButtonField>
                            </Columns>
                            <FooterStyle CssClass="foot" Font-Bold="true" />
                            <EmptyDataTemplate>
                                Actualmente no hay informacion en esta tabla
                            </EmptyDataTemplate>
                        </asp:GridView>
                  </ContentTemplate>
               </asp:UpdatePanel>
             </div>
           
            </div>
            <br />
         </div>
        <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString='<%$ ConnectionStrings:ConcormarketConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [categorias]"></asp:SqlDataSource>
</asp:Content>
