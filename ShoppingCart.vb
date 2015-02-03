Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel

Public Class ShoppingCart
    Property CartItems As Collection(Of CartItem)
    Property SubTotal As Double = 0
    Property Tax As Double = 0
    Property Total As Double = 0

    Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Add item to cart
    ''' </summary>
    ''' <param name="productId"></param>
    ''' <param name="qty"></param>
    ''' <param name="price"></param>
    ''' <remarks></remarks>
    Sub AddItemToCart(ByVal productId As Integer, ByVal qty As Integer, ByVal price As Double)
        Dim cItem As New CartItem
        Dim tmpCartList As New Collection(Of CartItem)

        If (Not CartItems Is Nothing) Then
            tmpCartList = CartItems
        End If

        cItem.ProductId = productId
        cItem.Quantity = qty
        cItem.PricePerQty = price

        tmpCartList.Add(cItem)

        CartItems = tmpCartList
    End Sub

    ''' <summary>
    ''' Remove item from cart
    ''' </summary>
    ''' <param name="myCartItem"></param>
    ''' <remarks></remarks>
    Sub RemoveItemFromCart(ByVal productId As Integer, ByVal qty As Integer, ByVal price As Double)
        Dim cItem As New Task3.CartItem
        Dim tmpCartList As New Collection(Of Task3.CartItem)
        Dim removeItem As Boolean = False
        Dim index As Integer = 0

        If (Not CartItems Is Nothing) Then
            tmpCartList = CartItems

            cItem.ProductId = productId
            cItem.Quantity = qty
            cItem.PricePerQty = price

            For i As Integer = 0 To CartItems.Count - 1
                If (CartItems(i).ProductId = productId) Then
                    removeItem = True
                End If
            Next

            If (removeItem) Then
                CartItems.RemoveAt(index)
            End If
        End If

        CartItems = tmpCartList
    End Sub

    ''' <summary>
    ''' Remove all items from cart
    ''' </summary>
    ''' <remarks></remarks>
    Sub EmptyCart()
        If (Not CartItems Is Nothing) Then
            CartItems.Clear()
        End If
    End Sub

    ''' <summary>
    ''' Calculate cart subtotal
    ''' </summary>
    ''' <remarks></remarks>
    Sub CalculateSubTotal()
        Dim stotal As Double = 0

        If (Not CartItems Is Nothing) Then
            For Each cItem As CartItem In CartItems
                stotal = stotal + (cItem.PricePerQty * cItem.Quantity)
            Next
        End If

        SubTotal = stotal
    End Sub

    ''' <summary>
    ''' Calculate cart tax - Placeholder
    ''' </summary>
    ''' <remarks>need to determine how to handle various rates</remarks>
    Sub CalculateTax()
        Tax = 0
    End Sub

    ''' <summary>
    ''' Calculate cart total
    ''' </summary>
    ''' <remarks></remarks>
    Sub CalculateTotal()
        Total = SubTotal + Tax
    End Sub

    ''' <summary>
    ''' Update specified item in cart
    ''' </summary>
    ''' <param name="productId"></param>
    ''' <param name="qty"></param>
    ''' <param name="price"></param>
    ''' <remarks></remarks>
    Sub UpdateItemInCart(ByVal productId As Integer, ByVal qty As Integer, ByVal price As Double)
        Throw New NotImplementedException
    End Sub

    ''' <summary>
    ''' Determine if product id is valid
    ''' </summary>
    ''' <param name="productId"></param>
    ''' <returns>True if integer > 0; otherwise False</returns>
    ''' <remarks>product id should come from database; this is just in case</remarks>
    Function IsProductIdValid(ByVal productId As String) As Boolean
        Return IsIdValid(productId)
    End Function

    ''' <summary>
    ''' Determine if product price is valid
    ''' </summary>
    ''' <param name="price"></param>
    ''' <returns>True if double >= 0; otherwise False</returns>
    ''' <remarks>price should come from the database; this is just in case</remarks>
    Function IsPriceValid(ByVal price As String) As Boolean
        Dim parsedPrice As Double = 0

        If (String.IsNullOrWhiteSpace(price.Trim)) Then
            Return False
        Else
            If (Double.TryParse(price.Trim, parsedPrice)) Then
                If (parsedPrice >= 0) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

    ''' <summary>
    ''' Determine if user entered quantity is valid
    ''' </summary>
    ''' <param name="qty"></param>
    ''' <returns>True if integer >= 0; otherwise False</returns>
    ''' <remarks></remarks>
    Function IsQuantityValid(ByVal qty As String) As Boolean
        Dim parsedQty As Integer = 0

        If (String.IsNullOrWhiteSpace(qty.Trim)) Then
            Return False
        Else
            If (Integer.TryParse(qty.Trim, parsedQty)) Then
                If (parsedQty >= 0) Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        End If
    End Function

End Class
