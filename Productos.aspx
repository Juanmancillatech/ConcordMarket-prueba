<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Marketwebform.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div class="content">
        <div class="col-lg-12 col-md-12 col-sm-12">
        <h2>Productos:</h2>

          <br />
         <asp:UpdatePanel ID="UpdatePaneldetalle" UpdateMode ="Conditional" runat="server">
          <ContentTemplate>
          <div class="row">
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
              <div class="row">
                <label>ID</label>
                <input runat="server" id="Proid" class="form-control" readonly="readonly" />
                <br />
                <label>Categoria ID</label>
                <select runat="server" id="selcateg" class="form-control"  onclick="findcat"  datasourceid="SqlDataSourceCat" datatextfield="id" datavaluefield="id"   >
                    <option value="0">Seleccionar</option>
                </select>
                  <asp:Label ID="Label1" runat="server" CssClass="glyphicon-text-color:red" Text=""></asp:Label>
              </div>
            </div>
            <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
                <div class="row">
                    <label>Nombre</label>
                    <input runat="server" id="NombrePro" class="form-control" disabled ="disabled" ng-controller="personCtrl" />
                    <input type="hidden" runat="server" id="nombreimagen" />
                    <br />
                    <label>Foto</label>
                    <asp:FileUpload ID="FileUpload1" accept="jpg" runat="server" CssClass="form-control"  />
                    <asp:Image ID="Image1" runat="server" Height="150" Width="170" />
                </div>
            </div>
           <div class="col-lg-4 col-md-4 col-sm-6 col-xs-12">
              <div class="row">
                <label>Stock</label>
                <input runat="server" id="Cantidad" class="form-control" disabled ="disabled" />
                <br />
                <label>Precio</label>
                <input runat="server" id="precio" class="form-control" disabled ="disabled" />
              </div>
           </div>
          </div>
          </ContentTemplate>
         </asp:UpdatePanel>
           <br />
            <div class="row">
                 <div class="col-lg-12 col-md-12 col-sm-12">
                     <div class="row inline">
                          <input runat="server" id="filtro" class="input-lg" /><asp:Button runat="server" ID="buscar" Text="Button" Class=" btn btn-warning btn-lg"  OnClick="filtroBus"/>
                     </div>
                 </div>               
            </div>
            <br />
            <br />
          <asp:UpdatePanel ID="UpdatePanelBottons" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <div class="row">
             <div class="col-lg-12 col-md-12 col-sm-12">
              <div class="row inline">
                <asp:Button ID="NuevoPro" runat="server" Text="Nuevo" CssClass="btn btn-primary btn_lg" OnClick="NuevoProClick" />
                <asp:Button ID="guardarPro" runat="server" Text="Guardar" CssClass="btn btn-success btn_lg" OnClick="GuardarProClick" Enabled ="false" />
                <asp:Button ID="modificarPro" runat="server" Text="Modificar" CssClass="btn btn-warning btn_lg" OnClick="ModificarProClick" Enabled="false"  />
              </div>
             </div>
            </div>
           </ContentTemplate>
          </asp:UpdatePanel>
            <br />
            <asp:UpdatePanel ID="UpdatePanelPro" runat="server" UpdateMode="Conditional">
                <ContentTemplate>

                    <asp:GridView ID="GridPro" runat="server" CssClass="mGrid" PagerStyle-CssClass="pgr" FooterStyle-HorizontalAlign="NotSet" ShowFooter="True" AutoGenerateColumns="False" DataKeyNames="id" AllowPaging="True" OnRowCommand="GridPro_RowCommand" PageSize="5">
                        <Columns>
                            <asp:BoundField HeaderText="id" HeaderStyle-CssClass="text-left headertxt" ItemStyle-CssClass="text-left lines" DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                            <asp:BoundField DataField="nombre" HeaderText="nombre" SortExpression="nombre">
                                <HeaderStyle CssClass="text-left headertxt"></HeaderStyle>
                                <ItemStyle CssClass="text-left lines"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="stock" HeaderText="stock" SortExpression="stock">
                                <HeaderStyle CssClass="text-left headertxt"></HeaderStyle>
                                <ItemStyle CssClass="text-left lines"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField HeaderText="precio" HeaderStyle-CssClass="text-left headertxt" ItemStyle-CssClass="text-left lines" DataField="precio" SortExpression="precio" />
                            <asp:BoundField HeaderText="categoria" HeaderStyle-CssClass="text-left headertxt" ItemStyle-CssClass="text-left lines" DataField="categoria" SortExpression="categoria" />
                            <asp:ImageField DataImageUrlFormatString="~/Imagenes/{0}" DataImageUrlField="imagen" ControlStyle-Width="170px" NullImageUrl="~/Imagenes/default.jpg"></asp:ImageField>
                            <asp:ButtonField CommandName="Selectedrow" Text="Seleccion" ControlStyle-CssClass="btn btn-default"></asp:ButtonField>
                            <asp:ButtonField CommandName="EliminarPro" Text="Eliminar" ControlStyle-CssClass="btn btn-danger" ></asp:ButtonField>
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
    <asp:SqlDataSource ID="SqlDataSourcePro" runat="server" ConnectionString='<%$ ConnectionStrings:ConcormarketConnectionString %>' SelectCommand="SELECT [id], [nombre], [stock], [precio], [imagen], [categoria] FROM [productos]"></asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceCat" runat="server" ConnectionString='<%$ ConnectionStrings:ConcormarketConnectionString %>' SelectCommand="SELECT [id], [nombre] FROM [categorias]"></asp:SqlDataSource>
</asp:Content>
