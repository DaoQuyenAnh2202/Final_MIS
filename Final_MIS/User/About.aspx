<%@ Page Title="" Language="C#" MasterPageFile="~/User/User.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Final_MIS.User.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- about section -->

  <section class="about_section layout_padding">
    <div class="container  ">

      <div class="row">
        <div class="col-md-6 ">
          <div class="img-box">
            <img src="../TemplateFiles/images/o3.png" alt="">
          </div>
        </div>
        <div class="col-md-6">
          <div class="detail-box">
            <div class="heading_container">
              <h2>
                StuFood Company
              </h2>
            </div>
            <p>
              The company was founded in 2010 as a small food stall near a primary school. It quickly became popular with students and some parents buying take away breakfast for their children. 
                Therefore, the primary school has decided to order our food for students’ meals since 2015, and in 2020, the company expanded to provide food chains for other schools.
            </p>
              <h4>Objectives:</h4>
              <p>To provide high-quality food to students at a reasonable price.</p>
              <p>To create jobs and support the local economy.</p>
            <a href="">
              Read More
            </a>
          </div>
        </div>
      </div>
    </div>
  </section>

  <!-- end about section -->
</asp:Content>
