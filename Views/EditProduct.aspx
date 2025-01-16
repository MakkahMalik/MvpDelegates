<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="MVPdemo.Views.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
 <script src="https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.slim.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <title>Edit Product</title>
</head>
<body>

        <div class="container">
  <h2>Update Product</h2>
    <form id="form2" runat="server">
   
<%--      <div class="form-group">--%>
     
    <%--  <asp:Label ID="Label2" runat="server" Text="Id"></asp:Label>
     <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
    </div>--%>
   
        <asp:HiddenField ID="hdnProductId" runat="server" />
      
      <div class="form-group">
      <asp:Label ID="Label1" runat="server" Text="ProdcutName"></asp:Label>
     <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
        
      <div class="form-group mt-5">
     <asp:Label ID="Label3" runat="server" Text="ProdcutDescription"></asp:Label>
     <asp:TextBox ID="txtProductDescription" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

   <asp:Button ID="btnUpdate" runat="server" Text="Update Product" CssClass="btn btn-danger mt-4"  OnClick="btnUpdate_Click" />

   <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
       

    </form>
 






</body>
</html>
