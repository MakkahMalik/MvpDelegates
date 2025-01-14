<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductPage.aspx.cs" Inherits="MVPdemo.Views.ProductPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/css/bootstrap.min.css">
  <script src="https://cdn.jsdelivr.net/npm/jquery@3.7.1/dist/jquery.slim.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.1/dist/umd/popper.min.js"></script>
  <script src="https://cdn.jsdelivr.net/npm/bootstrap@4.6.2/dist/js/bootstrap.bundle.min.js"></script>
    <title></title>
</head>
<body>



    <div class="container">
  <h2>Stacked form</h2>
    <form id="form2" runat="server">
   
<%--      <div class="form-group">--%>
     
    <%--  <asp:Label ID="Label2" runat="server" Text="Id"></asp:Label>
     <asp:TextBox ID="txtId" runat="server" CssClass="form-control"></asp:TextBox>
    </div>--%>
   
      
      <div class="form-group">
      <asp:Label ID="Label1" runat="server" Text="ProdcutName"></asp:Label>
     <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
   

      
      <div class="form-group mt-5">
      <asp:Label ID="Label3" runat="server" Text="ProdcutDescription"></asp:Label>
     <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
     <asp:Button ID="btnSave" runat="server" Text="Save Product" CssClass="btn btn-danger mt-4"  OnClick="btnSave_Click" />

    </div>

       <asp:GridView ID="gvProduct" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvProduct_RowCommand" >           
        <Columns>
      <asp:BoundField DataField="Id" HeaderText="Id" />
      <asp:BoundField DataField="Name" HeaderText="Name" />
      <asp:BoundField DataField="Description" HeaderText="Description" /> 

           <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                    CommandName="DeleteProduct" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" />                            
                <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                CommandName="EditProduct" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-sm" />

            </ItemTemplate> 
                 
      
  
        </asp:TemplateField>
   </Columns>

   </asp:GridView>     

           
            <br/>           
            <br/>
            <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
       

    </form>
     </div>
</body>
</html>




