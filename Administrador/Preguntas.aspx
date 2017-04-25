<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Preguntas.aspx.cs" Inherits="Administrador.Preguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Cargar Preguntas</h1>

      <h2 class="style1">Insertar Pregunta:</h2>
            <table>
                <tr>
                    <td align="right">
                        <strong>Pregunta</strong>
                    </td>
                    <td>
                        <%--<asp:TextBox ID="txtPregunta" runat="server"></asp:TextBox>--%>
                        <asp:TextBox id="txtPregunta"  runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <strong>Opción Correcta</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpcCorrecta" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <strong>Opc 2</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc2" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 3</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc3" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 4</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc4" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 5</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc5" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 6</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc6" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 7</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc7" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 8</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc9" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 10</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtOpc10" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <strong>Tipo</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLTipo" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Examen</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLExamen" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
            </table>

</asp:Content>
