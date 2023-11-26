<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Final_MIS.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="book_section layout_padding">
   <div class="container">
       <div class="heading_container">
           <div class="align-self-end">
               <asp:Label ID="lblMsg" runat="server" Visible="false"></asp:Label>
           </div>
           <h2>Login</h2>
       </div>
       <div class="row">
           <div class="col-md-6">
               <div class="form_container">
                   <img id="userLogin" src="../TemplateFiles/images/login.png" alt="" class="image-thumbnail">
                </div>
           </div>
           <div class="col-md-6">
               <div class="form_container">
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
                            ToolTip="Phone Number" TextMode="Password"></asp:TextBox>
                    </div>
                    <div class="btn_box">
                        <asp:Button ID="btLogin" runat="server" Text="Login" CssClass="btn btn-success rounded-pill pl-4 pr-4 text-white"
                            OnClick="btnLogin_Click"/>
                        <span class="pl-3 text-info">New User? <a href="Registration.aspx" class="badge badge-info">Register Here…</a></span>
                    </div>
                </div>
           </div>
       </div>
    </div>
</section>
</asp:Content>

