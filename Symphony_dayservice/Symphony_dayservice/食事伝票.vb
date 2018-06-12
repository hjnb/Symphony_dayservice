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

    Private Sub YoteiGoukei(sender As System.Object, e As System.EventArgs) Handles cmbYotei1.SelectedIndexChanged, cmbYotei2.SelectedIndexChanged, cmbYotei3.SelectedIndexChanged, cmbYotei4.SelectedIndexChanged, cmbYotei5.SelectedIndexChanged, cmbYotei6.SelectedIndexChanged, cmbYotei7.SelectedIndexChanged, cmbYotei8.SelectedIndexChanged, cmbYotei9.SelectedIndexChanged, cmbYotei10.SelectedIndexChanged, cmbYotei11.SelectedIndexChanged, cmbYotei12.SelectedIndexChanged, cmbYotei13.SelectedIndexChanged, cmbYotei14.SelectedIndexChanged, cmbYotei15.SelectedIndexChanged, cmbYotei16.SelectedIndexChanged, cmbYotei17.SelectedIndexChanged, cmbYotei18.SelectedIndexChanged, cmbYotei19.SelectedIndexChanged, cmbYotei20.SelectedIndexChanged, cmbYotei21.SelectedIndexChanged, cmbYotei22.SelectedIndexChanged, cmbYotei23.SelectedIndexChanged, cmbYotei24.SelectedIndexChanged, cmbYotei25.SelectedIndexChanged
        Dim Kei As Integer = 0

        For i As Integer = 1 To 25
            If Controls("cmbYotei" & i).Text = "　　　○　　" Then
                Kei = Kei + 1
            End If
        Next

        txtYoteiKei.Text = Kei
    End Sub

    Private Sub KetteiGoukei(sender As System.Object, e As System.EventArgs) Handles cmbKettei1.SelectedIndexChanged, cmbKettei2.SelectedIndexChanged, cmbKettei3.SelectedIndexChanged, cmbKettei4.SelectedIndexChanged, cmbKettei5.SelectedIndexChanged, cmbKettei6.SelectedIndexChanged, cmbKettei7.SelectedIndexChanged, cmbKettei8.SelectedIndexChanged, cmbKettei9.SelectedIndexChanged, cmbKettei10.SelectedIndexChanged, cmbKettei11.SelectedIndexChanged, cmbKettei12.SelectedIndexChanged, cmbKettei13.SelectedIndexChanged, cmbKettei14.SelectedIndexChanged, cmbKettei15.SelectedIndexChanged, cmbKettei16.SelectedIndexChanged, cmbKettei17.SelectedIndexChanged, cmbKettei18.SelectedIndexChanged, cmbKettei19.SelectedIndexChanged, cmbKettei20.SelectedIndexChanged, cmbKettei21.SelectedIndexChanged, cmbKettei22.SelectedIndexChanged, cmbKettei23.SelectedIndexChanged, cmbKettei24.SelectedIndexChanged, cmbKettei25.SelectedIndexChanged
        Dim Kei As Integer = 0

        For i As Integer = 1 To 25
            If Controls("cmbKettei" & i).Text = "　　　○　　" Then
                Kei = Kei + 1
            End If
        Next

        txtKetteikei.Text = Kei
    End Sub

    Private Sub btnKuria_Click(sender As System.Object, e As System.EventArgs) Handles btnKuria.Click
        For i As Integer = 1 To 25
            Controls("txtName" & i).Text = ""
            Controls("cmbYotei" & i).Text = ""
            Controls("cmbKettei" & i).Text = ""
            Controls("txtBikou" & i).Text = ""
        Next
        txtYoteiKei.Text = "0"
        txtKetteikei.Text = "0"
    End Sub

    Private Sub btnYomikomi_Click(sender As System.Object, e As System.EventArgs) Handles btnYomikomi.Click

    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click

    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click

    End Sub

    Private Sub btnInnsatu_Click(sender As System.Object, e As System.EventArgs) Handles btnInnsatu.Click

    End Sub

    Private Sub YmdBox1_YmdTextChange(sender As Object, e As System.EventArgs) Handles YmdBox1.YmdTextChange
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Dim ymd As String = YmdBox1.getADStr()
        SQLCm.CommandText = "SELECT * FROM Lnch WHERE Ymd = '" & ymd & "' ORDER BY Gyo"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        btnKuria.PerformClick()
        Dim DGV1rowcount As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To DGV1rowcount - 1
            If DataGridView1(1, i).Value = i + 1 Then
                Controls("txtName" & i + 1).Text = Util.checkDBNullValue(DataGridView1(2, i).Value)
                Dim findYotei As Integer = Util.checkDBNullValue(DataGridView1(3, i).Value).IndexOf("○")
                If findYotei > -1 Then
                    Controls("cmbYotei" & i + 1).Text = "　　　○　　"
                End If
                Dim findKettei As Integer = Util.checkDBNullValue(DataGridView1(4, i).Value).IndexOf("✕")
                If findKettei > -1 Then
                    Controls("cmbKettei" & i + 1).Text = "　　　✕　　"
                End If
                Controls("txtBikou" & i + 1).Text = Util.checkDBNullValue(DataGridView1(5, i).Value)
            End If
        Next

        Dim SQLCm2 As OleDbCommand = Cn.CreateCommand
        Dim Adapter2 As New OleDbDataAdapter(SQLCm2)
        Dim Table2 As New DataTable

        SQLCm2.CommandText = "SELECT * FROM Lnch WHERE Ymd = '" & ymd & "' ORDER BY Gyo"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

    End Sub

    
End Class