<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Final_MIS.User.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <!-- book section -->
 <section class="book_section layout_padding">
    <div class="container">
        <div class="heading_container">
            <div class="align-self-end">
                <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
            </div>
            <asp:Label ID="lblHeaderMsg" runat="server" Text="<h2>User Registration</h2>"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="form_container">
                    <div>
                        <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="Name is required" ControlToValidate="txtName"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revName" runat="server" ErrorMessage="Name must be in characters only"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[a-zA-Z\sàáạảãâầấậẩẫăằắặẳẵèéẹẻẽêềếệểễđìíịỉĩòóọỏõôồốộổỗơờớợởỡùúụủũưừứựửữỳýỵỷỹÀÁẠẢÃÂẦẤẬẨẪĂẰẮẶẲẴÈÉẸẺẼÊỀẾỆỂỄĐÌÍỊỈĨÒÓỌỎÕÔỒỐỘỔỖƠỜỚỢỞỠÙÚỤỦŨƯỪỨỰỬỮỲÝỴỶỸ]+$" 
                            ControlToValidate="txtName"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter Full School Name"
                            ToolTip="Full Name"></asp:TextBox>
                    </div>
                        
                    <div>
                        <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="Email is required" ControlToValidate="txtEmail"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"
                            ToolTip="Email"></asp:TextBox>
                    </div>

                    <div>
                        <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ErrorMessage="Phone Number is required" ControlToValidate="txtPhone"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revPhone" runat="server" ErrorMessage="Phone Number must have 10 digits"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationExpression="^[0-9]{10}$" 
                            ControlToValidate="txtPhone"></asp:RegularExpressionValidator>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control" placeholder="Enter Phone Number"
                            ToolTip="Phone Number"></asp:TextBox>
                    </div>

                    <div>
                         <asp:RequiredFieldValidator ID="revAddress" runat="server" ErrorMessage="Address is required" ControlToValidate="txtAddress"
                             ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                         <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Address"
                             ToolTip="Address"></asp:TextBox>
                    </div>

                    <div>
                        <asp:RequiredFieldValidator ID="revNumofStu" runat="server" ErrorMessage="Number of Student is required" ControlToValidate="txtNumofStu"
                            ForeColor="Red" Display="Dynamic" SetFocusOnError="true"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtNumofStu" runat="server" CssClass="form-control" placeholder="Enter Number of Student"
                            ToolTip="Phone Number"></asp:TextBox>
                    </div>

                </div>
                <div class="row pl-4">
                    <div class="btn-box">
                        <asp:Button ID="btRegister" runat="server" Text="Register" CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white" 
                            OnClick="btnRegister_Click"/>
                        <asp:Label ID="lblAlreadyUser" runat="server" CssClass="pl-3 text-black-100" 
                            Text="Already registered? <a href='Login.aspx' class='badge badge-info'>Login here…</a>"></asp:Label>
                    </div>
                </div>
            </div>

        </div>
     </div>
 </section>
 <!-- end book section -->
</asp:Content>
