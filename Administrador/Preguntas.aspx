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
                        <asp:TextBox ID="txtOpc8" runat="server" TextMode="MultiLine" Height="40px" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <strong>Opc 9</strong>
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
                        <strong>Url Imagen</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtUrlImg" runat="server" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                        <strong>Ayuda</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAyuda" runat="server" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <strong>Tipo de pregunta </strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLTipo" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>No Utilizar verdadero-falso</td>
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
                    <td align="right">
                        <strong>Tema</strong>
                    </td>
                    <td>
                        <asp:DropDownList ID="DDLTema" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">&nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnEnviar" runat="server" Text="Guardar" OnClick="btnEnviar_Click" />
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                        <strong>Agregar Tema</strong>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTema" runat="server" Width="208px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td align="right">&nbsp;
                    </td>
                    <td align="right">
                        <asp:Button ID="btnEnviarTema" runat="server" Text="Guardar" OnClick="btnEnviarTema_Click" />
                    </td>
                </tr>
            </table>

</asp:Content>
