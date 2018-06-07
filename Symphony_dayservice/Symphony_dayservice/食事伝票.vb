Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
Public Class 食事伝票

    Private Sub 食事伝票_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub 食事伝票_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))

        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Dim ymd As Date = YmdBox1.getADStr()
        SQLCm.CommandText = "SELECT * FROM Lnch WHERE Ymd = " & ymd & " ORDER BY Gyo"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        KeyPreview = True

    End Sub

    Private Sub textboxEnter(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtName1.KeyPress, txtName2.KeyPress, txtName3.KeyPress, txtName4.KeyPress, txtName5.KeyPress, txtName6.KeyPress, txtName7.KeyPress, txtName8.KeyPress, txtName9.KeyPress, txtName10.KeyPress, txtName11.KeyPress, txtName12.KeyPress, txtName13.KeyPress, txtName14.KeyPress, txtName15.KeyPress, txtName16.KeyPress, txtName17.KeyPress, txtName18.KeyPress, txtName19.KeyPress, txtName20.KeyPress, txtName21.KeyPress, txtName22.KeyPress, txtName23.KeyPress, txtName24.KeyPress, txtName25.KeyPress, txtBikou1.KeyPress, txtBikou2.KeyPress, txtBikou3.KeyPress, txtBikou4.KeyPress, txtBikou5.KeyPress, txtBikou6.KeyPress, txtBikou7.KeyPress, txtBikou8.KeyPress, txtBikou9.KeyPress, txtBikou10.KeyPress, txtBikou11.KeyPress, txtBikou12.KeyPress, txtBikou13.KeyPress, txtBikou14.KeyPress, txtBikou15.KeyPress, txtBikou16.KeyPress, txtBikou17.KeyPress, txtBikou18.KeyPress, txtBikou19.KeyPress, txtBikou20.KeyPress, txtBikou21.KeyPress, txtBikou22.KeyPress, txtBikou23.KeyPress, txtBikou24.KeyPress, txtBikou25.KeyPress
        If e.KeyChar = vbCr Then e.Handled = True
    End Sub

    Private Sub cmbYotei1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbYotei1.SelectedIndexChanged, cmbYotei2.SelectedIndexChanged
        Dim Kei As Integer = 0

        For i As Integer = 1 To 25
            If Controls("cmbYotei" & i).Text = "　　　○" Then
                Kei = Kei + 1
            End If
        Next

        txtYoteiKei.Text = Kei
    End Sub
End Class