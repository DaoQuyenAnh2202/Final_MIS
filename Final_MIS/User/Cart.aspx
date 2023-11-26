<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Final_MIS.User.Cart" %>

<%@ Import Namespace="Final_MIS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container pr-0 mt-5 mb-5" style="min-height: 510px;">
        <div class="row" id="root-cart">
                <div class="col-9">
                    <div class="row">
                        <div class="col">
                            <div class="h2">Giỏ hàng</div>
                        </div>
                        <div class="col d-flex justify-content-end align-items-center text-right">
                            
                        </div>
                    </div>
                    <div class="mt-3">
                        <table class="table">
                            <thead>
                                <tr>
                                    <th scope="col" class="text-center">Mã sản phẩm</th>
                                    <th scope="col" class="text-center">Tên sản phẩm</th>
                                    <th scope="col" class="text-center">Đơn giá</th>
                                    <th scope="col" class="text-center">Số lượng</th>
                                    <th scope="col" class="text-center">Thành tiền</th>
                                    <th scope="col" class="text-center"></th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rCarts" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                        <td class="text-center align-middle">
                                            <%# Eval("productID") %>
                                        </td>
                                        <td class="text-center align-middle">
                                            <%# Eval("productName") %>
                                        </td>
                                        <td class="text-center align-middle">
                                            <%# String.Format("{0:C0}", Eval("price")) %>
                                        </td>
                                        <td class="text-center align-middle">
                                            <input 
                                                   type="number" 
                                                   value="<%# Eval("quantity") %>" 
                                                   class="form-control quantity-input"
                                                    data-id="<%# Eval("productID") %>"
                                                />
                                        </td>
                                        <td class="text-center align-middle">
                                            <%# String.Format("{0:C0}", Eval("money")) %>
                                        </td>
                                        <td class="text-center align-middle">
                                            <a href="#" class="btn btn-danger del-cart" data-id="<%# Eval("productID") %>"><i class="fa fa-trash"></i></a>
                                        </td>
                                    </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
                <div class="col">
                    <div class="h2">Tổng tiền</div>
                    <div class="row">
                        <div class="mt-3 col">Tạm tính</div>
                        
                            <asp:Label ID="sumPrice" runat="server" CssClass="mt-3 col text-danger text-right sumPrice">

                            </asp:Label>
                    </div>
                    <div class="mt-3 text-right">
                        <a href="#" class="btn btn-success" id="checkout">Thanh toán</a>
                    </div>
                </div>
            </div>
    </div>
</asp:Content>
