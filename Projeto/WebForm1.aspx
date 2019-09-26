<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Projeto.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script src="https://code.jquery.com/jquery-3.2.1.slim.min.js" integrity="sha384-KJ3o2DKtIkvYIK3UENzmM7KCkRr/rE9/Qpg6aAZGJwFDMVNA/GpGFF93hXpG5KkN" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q" crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous" />
    <link href="Content/style.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="mt-3">
            <asp:GridView ID="GridView1" runat="server" CssClass="table table-bordered table-hover table-active font-size" AutoGenerateColumns="False" Style="width: 1400px" RowStyle-HorizontalAlign="Center" RowStyle-VerticalAlign="Bottom">
                <Columns>

                    <asp:BoundField DataField="categoria" HeaderText="Categoria" ItemStyle-Width="8%" HeaderStyle-CssClass="GridHeader" />


                    <asp:TemplateField HeaderText="Informar CC? Fixo/não Fixo" ItemStyle-Width="10%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList1" CssClass="browser-default custom-select" runat="server">
                                <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                                <asp:ListItem Text="Não" Value="1" />
                                <asp:ListItem Text="Sim" Value="2" />
                            </asp:DropDownList>

                            <asp:CustomValidator ID="CustomValidator1"
                                ControlToValidate="DropDownList1"
                                ClientValidationFunction="ValidaCC"
                                ErrorMessage="Preencha os campos!"
                                CssClass="m-0 p-0"
                                ForeColor="red"
                                Font-Size="12px"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="QTDE" ItemStyle-Width="10%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList2" CssClass="browser-default custom-select" runat="server">
                                <asp:ListItem Text="Selecione..." Value="11" Selected="True" />
                                <asp:ListItem Text="0" Value="0" />
                                <asp:ListItem Text="1" Value="1" />
                                <asp:ListItem Text="2" Value="2" />
                                <asp:ListItem Text="3" Value="3" />
                                <asp:ListItem Text="4" Value="4" />
                                <asp:ListItem Text="5" Value="5" />
                                <asp:ListItem Text="6" Value="6" />
                                <asp:ListItem Text="7" Value="7" />
                                <asp:ListItem Text="8" Value="8" />
                                <asp:ListItem Text="9" Value="9" />
                                <asp:ListItem Text="10" Value="10" />
                            </asp:DropDownList>

                            <asp:CustomValidator ID="CustomValidator2"
                                ControlToValidate="DropDownList2"
                                ClientValidationFunction="ValidaQuant"
                                ErrorMessage="Preencha os campos!"
                                CssClass="m-0 p-0"
                                ForeColor="red"
                                Font-Size="12px"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Regra de Cálculo" ItemStyle-Width="10%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:DropDownList ID="DropDownList3" CssClass="browser-default custom-select" runat="server">
                                <asp:ListItem Text="Selecione..." Value="0" Selected="True" />
                                <asp:ListItem Text="Único Curso" Value="1" />
                                <asp:ListItem Text="CH Proporcional" Value="2" />
                            </asp:DropDownList>
                            <asp:CustomValidator ID="CustomValidator3"
                                ControlToValidate="DropDownList3"
                                ClientValidationFunction="ValidaCalc"
                                ErrorMessage="Preencha os campos!"
                                CssClass="m-0 p-0"
                                ForeColor="red"
                                Font-Size="12px"
                                runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="numCC" HeaderText="n° CC" ItemStyle-Width="5%" HeaderStyle-CssClass="GridHeader" />

                    <asp:TemplateField HeaderText="PUB" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox0" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="DIR" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ADM" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox2" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ENF" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox3" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FIS" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox4" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="PSI" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox5" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CON" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox6" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MED" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox7" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pós Graduação" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox8" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Comitê de Ética" ItemStyle-Width="5%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox9" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Disciplinas Digitais" ItemStyle-Width="2%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox10" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Bioenergia Mestrado" ItemStyle-Width="2%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox11" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="NQA" ItemStyle-Width="1%" HeaderStyle-CssClass="GridHeader">
                        <ItemTemplate>
                            <asp:CheckBox ID="CheckBox12" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <div class="d-flex justify-content-center">
                <asp:Button CssClass="btn btn-primary" ID="btnEnvia" runat="server" Text="Enviar" OnClick="btnEnvia_Click" />
            </div>
        </div>
    </form>

    <div class="container-fluid bg-primary mt-5">
        <asp:Panel ID="Panel1" runat="server" Visible="false" CssClass="display-3 p-2 text-white text-center">Enviado com sucesso!</asp:Panel>
    </div>

</body>
</html>

<script language="javascript"> 
    function ValidaCC(source, arguments) {
        if (arguments.Value == 0) {
            arguments.IsValid = false;
        } else {
            arguments.IsValid = true;
        }
    }

    function ValidaQuant(source, arguments) {
        if (arguments.Value == 11) {
            arguments.IsValid = false;
        } else {
            arguments.IsValid = true;
        }
    }

    function ValidaCalc(source, arguments) {
        if (arguments.Value == 0) {
            arguments.IsValid = false;
        } else {
            arguments.IsValid = true;
        }
    }
</script>

