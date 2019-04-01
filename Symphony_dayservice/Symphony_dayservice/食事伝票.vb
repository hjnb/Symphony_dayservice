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
        Me.WindowState = FormWindowState.Maximized
        YmdBox1.setADStr(Today.ToString("yyyy/MM/dd"))

        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Dim ymd As String = YmdBox1.getADStr()
        SQLCm.CommandText = "SELECT * FROM Lnch WHERE Ymd = '" & ymd & "' ORDER BY Gyo"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        KeyPreview = True

    End Sub

    Private Sub textboxEnter(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtName1.KeyPress, txtName2.KeyPress, txtName3.KeyPress, txtName4.KeyPress, txtName5.KeyPress, txtName6.KeyPress, txtName7.KeyPress, txtName8.KeyPress, txtName9.KeyPress, txtName10.KeyPress, txtName11.KeyPress, txtName12.KeyPress, txtName13.KeyPress, txtName14.KeyPress, txtName15.KeyPress, txtName16.KeyPress, txtName17.KeyPress, txtName18.KeyPress, txtName19.KeyPress, txtName20.KeyPress, txtName21.KeyPress, txtName22.KeyPress, txtName23.KeyPress, txtName24.KeyPress, txtName25.KeyPress, txtBikou1.KeyPress, txtBikou2.KeyPress, txtBikou3.KeyPress, txtBikou4.KeyPress, txtBikou5.KeyPress, txtBikou6.KeyPress, txtBikou7.KeyPress, txtBikou8.KeyPress, txtBikou9.KeyPress, txtBikou10.KeyPress, txtBikou11.KeyPress, txtBikou12.KeyPress, txtBikou13.KeyPress, txtBikou14.KeyPress, txtBikou15.KeyPress, txtBikou16.KeyPress, txtBikou17.KeyPress, txtBikou18.KeyPress, txtBikou19.KeyPress, txtBikou20.KeyPress, txtBikou21.KeyPress, txtBikou22.KeyPress, txtBikou23.KeyPress, txtBikou24.KeyPress, txtBikou25.KeyPress
        If e.KeyChar = vbCr Then e.Handled = True
    End Sub

    Private Sub YoteiGoukei(sender As System.Object, e As System.EventArgs) Handles cmbYotei1.SelectedIndexChanged, cmbYotei2.SelectedIndexChanged, cmbYotei3.SelectedIndexChanged, cmbYotei4.SelectedIndexChanged, cmbYotei5.SelectedIndexChanged, cmbYotei6.SelectedIndexChanged, cmbYotei7.SelectedIndexChanged, cmbYotei8.SelectedIndexChanged, cmbYotei9.SelectedIndexChanged, cmbYotei10.SelectedIndexChanged, cmbYotei11.SelectedIndexChanged, cmbYotei12.SelectedIndexChanged, cmbYotei13.SelectedIndexChanged, cmbYotei14.SelectedIndexChanged, cmbYotei15.SelectedIndexChanged, cmbYotei16.SelectedIndexChanged, cmbYotei17.SelectedIndexChanged, cmbYotei18.SelectedIndexChanged, cmbYotei19.SelectedIndexChanged, cmbYotei20.SelectedIndexChanged, cmbYotei21.SelectedIndexChanged, cmbYotei22.SelectedIndexChanged, cmbYotei23.SelectedIndexChanged, cmbYotei24.SelectedIndexChanged, cmbYotei25.SelectedIndexChanged
        Yoteikei()
    End Sub
    Private Sub Yoteikei()
        Dim YoteiKei As Integer = 0

        For i As Integer = 1 To 25
            If Controls("cmbYotei" & i).Text = "　　　○　　" Then
                YoteiKei = YoteiKei + 1
            End If
        Next

        txtYoteiKei.Text = YoteiKei
    End Sub
    Private Sub KetteiGoukei(sender As System.Object, e As System.EventArgs) Handles cmbKettei1.SelectedIndexChanged, cmbKettei2.SelectedIndexChanged, cmbKettei3.SelectedIndexChanged, cmbKettei4.SelectedIndexChanged, cmbKettei5.SelectedIndexChanged, cmbKettei6.SelectedIndexChanged, cmbKettei7.SelectedIndexChanged, cmbKettei8.SelectedIndexChanged, cmbKettei9.SelectedIndexChanged, cmbKettei10.SelectedIndexChanged, cmbKettei11.SelectedIndexChanged, cmbKettei12.SelectedIndexChanged, cmbKettei13.SelectedIndexChanged, cmbKettei14.SelectedIndexChanged, cmbKettei15.SelectedIndexChanged, cmbKettei16.SelectedIndexChanged, cmbKettei17.SelectedIndexChanged, cmbKettei18.SelectedIndexChanged, cmbKettei19.SelectedIndexChanged, cmbKettei20.SelectedIndexChanged, cmbKettei21.SelectedIndexChanged, cmbKettei22.SelectedIndexChanged, cmbKettei23.SelectedIndexChanged, cmbKettei24.SelectedIndexChanged, cmbKettei25.SelectedIndexChanged
        Ketteikei()
    End Sub
    Private Sub Ketteikei()
        Dim KetteiKei As Integer = 0

        For i As Integer = 1 To 25
            If Controls("cmbKettei" & i).Text = "　　　○　　" Then
                KetteiKei = KetteiKei + 1
            End If
        Next

        txtKetteikei.Text = KetteiKei
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
        For i As Integer = 0 To DataGridView2.Rows.Count - 1
            Controls("txtName" & i + 1).Text = Util.checkDBNullValue(DataGridView2(3, i).Value)
        Next
    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        Dim rowcount As Integer = DataGridView1.Rows.Count

        If rowcount > 0 Then
            Henkou()
            btnKousinn.PerformClick()
        Else
            Tuika()
            btnKousinn.PerformClick()
        End If

    End Sub
    Private Sub Henkou()
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim SQL As String = ""
        SQL = "DELETE FROM Lnch WHERE Ymd = '" & YmdBox1.getADStr() & "'"
        SQLCm.CommandText = SQL

        Cn.Open()
        SQLCm.ExecuteNonQuery()
        Cn.Close()

        SQLCm.Dispose()
        Cn.Dispose()

        Tuika()
        btnKousinn.PerformClick()
    End Sub
    Private Sub Tuika()
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Table As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        Dim ymd, nam, yotei, ketei, biko As String
        Dim gyo As Integer = 0

        ymd = YmdBox1.getADStr()
        Cn.Open()
        Dim SQL As String = ""
        For i As Integer = 1 To 25
            gyo = i
            If Controls("txtName" & i).Text <> "" Then
                nam = Controls("txtName" & i).Text
                If Controls("cmbYotei" & i).Text = "　　　○　　" = True Then
                    yotei = "○"
                ElseIf Controls("cmbYotei" & i).Text = "　　　✕　　" = True Then
                    yotei = "✕"
                Else
                    yotei = ""
                End If
                If Controls("cmbKettei" & i).Text = "　　　○　　" = True Then
                    ketei = "○"
                ElseIf Controls("cmbKettei" & i).Text = "　　　✕　　" = True Then
                    ketei = "✕"
                Else
                    ketei = ""
                End If
                biko = Controls("txtBikou" & i).Text
            ElseIf Controls("txtName" & i).Text = "" Then
                nam = ""
                yotei = ""
                ketei = ""
                biko = Controls("txtBikou" & i).Text
            Else
                nam = ""
                yotei = ""
                ketei = ""
                biko = Controls("txtBikou" & i).Text
            End If

            SQL = "INSERT INTO Lnch (Ymd, Gyo, Nam, Yotei, Ketei, Biko) VALUES ('" & ymd & "', " & gyo & ", '" & nam & "', '" & yotei & "', '" & ketei & "', '" & biko & "')"
            SQLCm.CommandText = SQL
            SQLCm.ExecuteNonQuery()
        Next

        Cn.Close()
        SQLCm.Dispose()
        Cn.Dispose()
    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click
        If DataGridView1.Rows.Count = 0 Then
            MsgBox("削除するデータがありません。")
            Return
        End If

        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim SQL As String = ""

        If MsgBox("この日付の食事伝票記録を削除しますか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
            SQL = "DELETE FROM Lnch WHERE Ymd = '" & YmdBox1.getADStr() & "'"
        Else
            Return
        End If

        SQLCm.CommandText = SQL

        Cn.Open()
        SQLCm.ExecuteNonQuery()
        Cn.Close()

        SQLCm.Dispose()
        Cn.Dispose()

        btnKousinn.PerformClick()

    End Sub

    Private Sub btnInnsatu_Click(sender As System.Object, e As System.EventArgs) Handles btnInnsatu.Click
        Dim objExcel As Object
        Dim objWorkBooks As Object
        Dim objWorkBook As Object
        Dim oSheets As Object
        Dim oSheet As Object
        Dim day As DateTime = DateTime.Today

        objExcel = CreateObject("Excel.Application")
        objWorkBooks = objExcel.Workbooks
        objWorkBook = objWorkBooks.Open(TopForm.excelFilePass)
        oSheets = objWorkBook.Worksheets
        oSheet = objWorkBook.Worksheets("lunch")

        Dim Wareki, Youbi As String
        If Strings.Left(YmdBox1.getWarekiStr(), 1) = "H" Then
            Wareki = "平成"
        Else
            Wareki = "令和"
        End If
        Youbi = Strings.Left(WeekdayName(Weekday(YmdBox1.getADStr())), 1)

        oSheet.Range("B5").Value = Wareki & " " & Strings.Mid(YmdBox1.getWarekiStr(), 2, 2) & " 年 " & Strings.Mid(YmdBox1.getWarekiStr(), 5, 2) & " 月 " & Strings.Right(YmdBox1.getWarekiStr(), 2) & " 日 " & Youbi & " 曜日"
        oSheet.Range("E33").Value = txtYoteiKei.Text

        Dim countrowDGV1 As Integer = DataGridView1.Rows.Count

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            oSheet.Range("C" & i + 7).Value = Util.checkDBNullValue(DataGridView1(2, i).Value)
            oSheet.Range("D" & i + 7).Value = Util.checkDBNullValue(DataGridView1(3, i).Value)
            oSheet.Range("G" & i + 7).Value = Util.checkDBNullValue(DataGridView1(4, i).Value)
            oSheet.Range("K" & i + 7).Value = Util.checkDBNullValue(DataGridView1(5, i).Value)
        Next

        '保存
        objExcel.DisplayAlerts = False

        ' エクセル表示
        objExcel.Visible = True

        '印刷
        If TopForm.rbtnPreview.Checked = True Then
            oSheet.PrintPreview(1)
        ElseIf TopForm.rbtnPrint.Checked = True Then
            oSheet.Printout(1)
        End If


        ' EXCEL解放
        objExcel.Quit()
        Marshal.ReleaseComObject(oSheet)
        Marshal.ReleaseComObject(objWorkBook)
        Marshal.ReleaseComObject(objExcel)
        oSheet = Nothing
        objWorkBook = Nothing
        objExcel = Nothing
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

        SQLCm2.CommandText = "SELECT * FROM PlnM WHERE Ym = '" & Strings.Left(ymd, 7) & "' and Day = " & Int(Strings.Right(ymd, 2)) & " ORDER BY Gyo"
        Adapter2.Fill(Table2)
        DataGridView2.DataSource = Table2

        Yoteikei()
        Ketteikei()

    End Sub

    Private Sub btnKousinn_Click(sender As System.Object, e As System.EventArgs) Handles btnKousinn.Click
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Dim ymd As String = YmdBox1.getADStr()
        SQLCm.CommandText = "SELECT * FROM Lnch WHERE Ymd = '" & ymd & "' ORDER BY Gyo"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        KeyPreview = True

    End Sub
End Class