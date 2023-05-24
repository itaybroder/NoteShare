<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Site1.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="NoteShare.UI.WebForm2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
        <div <%--class="animate__animated animate__rubberBand"--%>>
            <h1>Register</h1>
            <br />
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
            
      

            <asp:TextBox ID="from_date" runat="server" placeholder="From" type="date" style="font-size:20px;" ></asp:TextBox>
            <script>
                // Get the birthday input element
                const birthdayInput = document.getElementById("ContentPlaceHolder1_from_date");


                // Calculate the minimum and maximum allowed dates
                const maxDate = new Date().toISOString().split("T")[0];
                const minDate = new Date();
                minDate.setFullYear(minDate.getFullYear() - 90);
                const minDateISO = minDate.toISOString().split("T")[0];

                // Set the minimum and maximum attributes on the input element
                birthdayInput.setAttribute("min", minDateISO);
                birthdayInput.setAttribute("max", maxDate);
            </script>
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
            <h2>Choose which schools you are in:</h2>
            <asp:DataList ID="SchoolsDataList" runat="server" Height="117px" RepeatDirection="Horizontal" Width="268px">
                <ItemTemplate>
                    <asp:RadioButton Text='<%# Eval("Name") %>' runat="server" ID="CheckBox" AutoPostBack="true" />
                </ItemTemplate>

            </asp:DataList>


            <asp:Button ID="RegisterBTN" runat="server" Text="Register" CssClass="btn btn-danger login-btn" OnClick="RegisterBTN_Click" /><br />
            <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error"></asp:Label>

            <a href="Login.aspx">already have an account?</a>
        </div>
    </center>
</asp:Content>
