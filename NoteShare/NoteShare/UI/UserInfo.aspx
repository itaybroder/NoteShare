<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="UserInfo.aspx.cs" Inherits="NoteShare.UI.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .backbtn {
            margin-left: 20px;
        }

        .personal-info {
            border-style: solid;
            margin-top: 30px;
            width: 50vh;
        }

        .personal-info-header {
            text-align: center;
        }
    </style>

    <style>
        .backbtn {
            margin-left: 20px;
        }
    </style>

    <asp:Button ID="BackBTN" runat="server" Text="Back" OnClick="BackBTN_Click" class="backbtn btn btn-warning" CausesValidation="false" /><br />

    <center>

        <asp:Panel runat="server" ID="UserInfoPanel">
            <div id="personal-info" class="personal-info">
                <h3 class="personal-info-header">Personal information</h3>
                <div style="font-size: larger">
                    <p>
                        name:
                    <asp:Label ID="NameLBL" runat="server" Text=""></asp:Label>
                    </p>

                    <p>
                        password: 
                    <asp:Label ID="PassLBL" runat="server" Text=""></asp:Label>
                    </p>

                    <p>
                        birthday:
                    <asp:Label ID="BDLBL" runat="server" Text=""></asp:Label>
                    </p>

                    <p>
                        schools:
                    <asp:Label ID="SchoolLBL" runat="server" Text=""></asp:Label>
                    </p>

                    <p>
                        address:
                    <asp:Label ID="AdressLBL" runat="server" Text=""></asp:Label>
                    </p>

                    <p>
                        username:
                    <asp:Label ID="UsernameLBL" runat="server" Text=""></asp:Label>
                    </p>

                </div>
            </div>
        </asp:Panel>
        <br />
        <asp:Button Text="Edit Info" runat="server" ID="EditButton" OnClick="EditButton_Click" class="btn btn-primary" /><br />
        <br />
        <asp:Panel runat="server" ID="EditUserPanel" Visible="false">
            <asp:TextBox runat="server" ID="FirstNameTB" CssClass="login-textbox" placeholder="First name" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorFN" runat="server" ErrorMessage="Required Field!" ControlToValidate="FirstNameTB"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox runat="server" ID="LastNameTB" CssClass="login-textbox" placeholder="Last name" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorLN" runat="server" ErrorMessage="Required Field!" ControlToValidate="LastNameTB"></asp:RequiredFieldValidator>
            <br />
            <asp:TextBox runat="server" ID="UsernameTB" CssClass="login-textbox" placeholder="Username" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorU" runat="server" ErrorMessage="Required Field!" ControlToValidate="UsernameTB"></asp:RequiredFieldValidator>
            <br />
            <br />
            <asp:TextBox runat="server" ID="AdressTB" CssClass="login-textbox" placeholder="Address" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdd" runat="server" ErrorMessage="Required Field!" ControlToValidate="AdressTB"></asp:RequiredFieldValidator>
            <br />
            <p>birthday:</p>
            <asp:TextBox ID="from_date" runat="server" placeholder="From" type="date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBD" runat="server" ErrorMessage="Required Field!" ControlToValidate="from_date"></asp:RequiredFieldValidator>
            <br />
            <br />
            <p>Your password should contain minimum eight characters, at least one letter and one number</p>
            <asp:TextBox runat="server" ID="PasswordTB" CssClass="login-textbox" placeholder="Password" type="password" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass" runat="server" ErrorMessage="Required Field!" ControlToValidate="PasswordTB"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidatorPasswordRegex" runat="server" ErrorMessage="Password not in format" ControlToValidate="PasswordTB" ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"></asp:RegularExpressionValidator>
            <br />
            <asp:TextBox runat="server" ID="PasswordTB2" CssClass="login-textbox" placeholder="re-enter password" type="password" /><br />
            <asp:RequiredFieldValidator ID="RequiredFieldValidatorPass2" runat="server" ErrorMessage="Required Field!" ControlToValidate="PasswordTB2"></asp:RequiredFieldValidator>
            <br />

            <asp:DataList ID="SchoolsDataList" runat="server" Height="40px" RepeatDirection="Horizontal" Width="268px">
                <ItemTemplate>
                    <asp:RadioButton Text='<%# Eval("Name") %>' runat="server" ID="CheckBox" AutoPostBack="true" />
                </ItemTemplate>

            </asp:DataList>



            <asp:Button ID="RegisterBTN" runat="server" Text="submit" CssClass="btn btn-danger login-btn" OnClick="RegisterBTN_Click" />
            <asp:Button ID="CancelButton" runat="server" Text="cancel" CausesValidation="false" CssClass="btn btn-warning login-btn" OnClick="CancelButton_Click" /><br />

            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error"></asp:Label>
            <br />
        </asp:Panel>

    </center>
</asp:Content>
