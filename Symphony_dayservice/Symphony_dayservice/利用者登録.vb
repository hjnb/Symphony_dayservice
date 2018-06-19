Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
Public Class 利用者登録

    Private Sub 利用者登録_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub 利用者登録_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Util.EnableDoubleBuffering(DataGridView1)
        With DataGridView1
            .RowTemplate.Height = 16
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .ReadOnly = True '編集禁止
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect 'クリック時に行選択
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        SQLCm.CommandText = "SELECT Autono, Nam As 利用者氏名, Kana As ｶﾅ, Dsp FROM UsrM ORDER BY Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .RowHeadersWidth = 40
            .Columns(0).Visible = False
            .Columns(1).Width = 115
            .Columns(2).Width = 138
            .Columns(3).Visible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        KeyPreview = True

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim i As Integer = DataGridView1.CurrentRow.Index
        lblAutono.Text = Util.checkDBNullValue(DataGridView1(0, i).Value)
        txtName.Text = Util.checkDBNullValue(DataGridView1(1, i).Value)
        txtKana.Text = Util.checkDBNullValue(DataGridView1(2, i).Value)
        If Util.checkDBNullValue(DataGridView1(3, i).Value) = "1" Then
            chkHyouji.Checked = True
        ElseIf Util.checkDBNullValue(DataGridView1(3, i).Value) = "0" Then
            chkHyouji.Checked = False
        End If
    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting
        '列ヘッダを対象外しておかないと列ヘッダにも番号を表示してしまう

        If e.ColumnIndex < 0 And e.RowIndex >= 0 Then

            'セルを描画する

            e.Paint(e.ClipBounds, DataGridViewPaintParts.All)

            '行番号を描画する範囲を決定する

            Dim idxRect As Rectangle = e.CellBounds

            'e.Padding(値を表示する境界線からの間隔)を考慮して描画位置を決める

            Dim rectHeight As Long = e.CellStyle.Padding.Top

            Dim rectLeft As Long = e.CellStyle.Padding.Left

            idxRect.Inflate(rectLeft, rectHeight)

            '行番号を描画する

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(), e.CellStyle.Font, idxRect, e.CellStyle.ForeColor, TextFormatFlags.Right Or TextFormatFlags.VerticalCenter)

            '描画完了の通知

            e.Handled = True

        End If

    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        If txtName.Text = "" OrElse txtKana.Text = "" Then
            MsgBox("漢字氏名とフリガナを入力してください。")
            Return
        End If

        Dim count As Integer = DataGridView1.Rows.Count
        For i As Integer = 0 To count - 1
            If lblAutono.Text = DataGridView1(0, i).Value Then
                '行が選択されていたら変更
                Hennkou()
                btnKousinn.PerformClick()
                Exit Sub
            End If
        Next

        '行が選択されていなかったら
        Tuika()
        btnKousinn.PerformClick()
    End Sub
    Private Sub Hennkou()
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Table As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        Dim Dsp As String = ""
        If chkHyouji.Checked = True Then
            Dsp = "1"
        ElseIf chkHyouji.Checked = False Then
            Dsp = "0"
        End If

        Dim SQL As String = ""
        SQL = "UPDATE UsrM SET Nam = '" & txtName.Text & "', Kana = '" & txtKana.Text & "', Dsp = '" & Dsp & "' WHERE Autono = " & lblAutono.Text

        SQLCm.CommandText = SQL
        Cn.Open()
        SQLCm.ExecuteNonQuery()
        Cn.Close()

        Table.AcceptChanges()
        Table.Dispose()
        SQLCm.Dispose()
        Cn.Dispose()
        MsgBox("変更しました")
    End Sub
    Private Sub Tuika()
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Table As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        Dim Row As DataRow = Table.NewRow

        Row("利用者氏名") = txtName.Text
        Row("ｶﾅ") = txtKana.Text
        If chkHyouji.Checked = True Then
            Row("Dsp") = "1"
        ElseIf chkHyouji.Checked = False Then
            Row("Dsp") = "0"
        End If

        Cn.Open()
        Dim SQL As String = ""
        SQL = "INSERT INTO UsrM (Nam, Kana, Dsp) VALUES ('" & Row("利用者氏名") & "', '" & Row("ｶﾅ") & "', '" & Row("Dsp") & "')"

        SQLCm.CommandText = SQL
        SQLCm.ExecuteNonQuery()
        Cn.Close()
        SQLCm.Dispose()
        Cn.Dispose()
        MsgBox("追加しました")
    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click
        If lblAutono.Text = "0" Then
            MsgBox("削除する行を選択してください。", , "削除")
            Return
        End If

        If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
            Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
            Dim SQLCm As OleDbCommand = Cn.CreateCommand
            Dim SQL As String = ""
            SQL = "DELETE FROM UsrM WHERE (Autono = " & lblAutono.Text & ") AND (Nam ='" & txtName.Text & "')"
            SQLCm.CommandText = SQL
            Cn.Open()
            SQLCm.ExecuteNonQuery()
            Cn.Close()

            SQLCm.Dispose()
            Cn.Dispose()

            btnKousinn.PerformClick()
        End If
    End Sub

    Private Sub btnKousinn_Click(sender As System.Object, e As System.EventArgs) Handles btnKousinn.Click
        btnKuria.PerformClick()

        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Util.EnableDoubleBuffering(DataGridView1)
        With DataGridView1
            .RowTemplate.Height = 16
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .ReadOnly = True '編集禁止
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect 'クリック時に行選択
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        SQLCm.CommandText = "SELECT Autono, Nam As 利用者氏名, Kana As ｶﾅ, Dsp FROM UsrM ORDER BY Kana"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .RowHeadersWidth = 40
            .Columns(0).Visible = False
            .Columns(1).Width = 115
            .Columns(2).Width = 138
            .Columns(3).Visible = False
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        KeyPreview = True
    End Sub

    Private Sub btnKuria_Click(sender As System.Object, e As System.EventArgs) Handles btnKuria.Click
        txtName.Text = ""
        txtKana.Text = ""
        chkHyouji.Checked = False
    End Sub
End Class