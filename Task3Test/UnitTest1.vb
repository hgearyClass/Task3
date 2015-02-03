Imports System.Text

Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

<TestClass()>
Public Class UnitTest1

    <TestMethod()>
    Public Sub AddToCartTest()
        Dim myCart As New Task3.ShoppingCart

        myCart.AddItemToCart(1, 2, 10.0)
        myCart.AddItemToCart(2, 1, 5.0)

        Assert.AreEqual(2, myCart.CartItems.Count)
    End Sub

    <TestMethod()>
    Public Sub RemoveItemFromCartTest()
        Dim myCart As New Task3.ShoppingCart

        Dim ProductId As Integer = 1
        Dim Quantity As Integer = 1
        Dim PricePerQty As Double = 10.0

        myCart.AddItemToCart(ProductId, Quantity, PricePerQty)
        myCart.AddItemToCart(2, 1, 3.5)

        myCart.RemoveItemFromCart(ProductId, Quantity, PricePerQty)

        Assert.AreEqual(1, myCart.CartItems.Count)
    End Sub

    <TestMethod()>
    Public Sub EmptyCart()
        Dim myCart As New Task3.ShoppingCart

        myCart.AddItemToCart(1, 1, 10.0)
        myCart.AddItemToCart(2, 1, 10.0)
        myCart.EmptyCart()

        Assert.AreEqual(0, myCart.CartItems.Count)
    End Sub

    <TestMethod()>
    Public Sub CalculateSubTotalTest()
        Dim myCart As New Task3.ShoppingCart

        myCart.AddItemToCart(1, 2, 10.0)
        myCart.AddItemToCart(2, 1, 5.0)
        myCart.CalculateSubTotal()

        Assert.AreEqual(25.0, myCart.SubTotal())
    End Sub

    <TestMethod()>
    Public Sub CalculateTotalTest()
        Dim myCart As New Task3.ShoppingCart

        myCart.AddItemToCart(1, 2, 10.0)
        myCart.AddItemToCart(2, 1, 5.0)
        myCart.CalculateSubTotal()
        myCart.CalculateTax()
        myCart.CalculateTotal()

        Assert.AreEqual(25.0, myCart.Total())
    End Sub

    <TestMethod()>
    Public Sub CalculateTaxTest()
        Dim myCart As New Task3.ShoppingCart

        myCart.AddItemToCart(1, 2, 10.0)
        myCart.AddItemToCart(2, 1, 5.0)
        myCart.CalculateSubTotal()
        myCart.CalculateTax()

        Assert.AreEqual(0.0, myCart.Tax())
    End Sub

    <TestMethod()>
    Public Sub UpdateItemInCartTest()
        Dim myCart As New Task3.ShoppingCart
        Dim cItem As New Task3.CartItem

        cItem.ProductId = 1
        cItem.Quantity = 2
        cItem.PricePerQty = 10

        myCart.AddItemToCart(cItem.ProductId, cItem.Quantity, cItem.PricePerQty)

        cItem.Quantity = 4

        myCart.UpdateItemInCart(cItem.ProductId, cItem.Quantity, cItem.PricePerQty)
    End Sub

    <TestMethod()>
    Public Sub IsProductIdValidTest()
        Dim myBoard As New Task3.ShoppingCart
        Assert.IsTrue(myBoard.IsProductIdValid("1"))
    End Sub

    <TestMethod()>
    Public Sub IsPriceValidTest()
        Dim myBoard As New Task3.ShoppingCart
        Assert.IsTrue(myBoard.IsPriceValid("10.00"))
    End Sub

    <TestMethod()>
    Public Sub IsQuantityValidTest()
        Dim myBoard As New Task3.ShoppingCart
        Assert.IsTrue(myBoard.IsQuantityValid("1"))
    End Sub
End Class
