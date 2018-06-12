Imports System.ComponentModel

Public Class ReadOnlyComboBox : Inherits System.Windows.Forms.ComboBox
    Sub New()
        Me.ContextMenu = New ContextMenu()
        Me.DropDownStyle = ComboBoxStyle.DropDown
    End Sub

    Protected Overrides Sub OnDropDownStyleChanged(e As EventArgs)
        MyBase.OnDropDownStyleChanged(e)
        If (Me.DropDownStyle <> ComboBoxStyle.DropDown) Then
            Me.DropDownStyle = ComboBoxStyle.DropDown
        End If
    End Sub

    Protected Overrides Sub OnKeyDown(e As KeyEventArgs)
        If e.KeyCode = Keys.Up OrElse e.KeyCode = Keys.Down Then
            MyBase.OnKeyDown(e)
        Else
            e.Handled = True
        End If
    End Sub

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub ReadOnlyComboBox_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        Me.DroppedDown = True
    End Sub

    Private Sub ReadOnlyComboBox_VisibleChanged(sender As Object, e As System.EventArgs) Handles Me.VisibleChanged
        Me.Items.Clear()
        Dim a() As String = {"　　　○　　", "　　　✕　　"}
        Me.Items.AddRange(a)
    End Sub
End Class
