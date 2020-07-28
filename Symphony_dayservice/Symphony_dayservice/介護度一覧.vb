Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
Public Class 介護度一覧

    Private Sub 介護度一覧_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim forward As Boolean = e.Modifiers <> Keys.Shift
            Me.SelectNextControl(Me.ActiveControl, forward, True, True, True)
            e.Handled = True
        End If
    End Sub

    Private Sub 介護度一覧_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        lblName.Text = ""
        YmdBoxStart.setADStr(Today.ToString("yyyy/MM/dd"))
        YmdBoxEnd.setADStr(Today.ToString("yyyy/MM/dd"))

        Dim reader As System.Data.OleDb.OleDbDataReader
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        SQLCm.CommandText = "select Nam from UsrM WHERE Dsp = '1' order by Kana"
        Cn.Open()
        reader = SQLCm.ExecuteReader()
        While reader.Read() = True
            lstName.Items.Add(reader("Nam"))
        End While
        reader.Close()
        Cn.Close()

        KeyPreview = True
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

    Private Sub DataGridView1_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        If DataGridView1.Columns(e.ColumnIndex).Name = "利用" Then
            If Util.checkDBNullValue(e.Value) = 1 Then
                e.Value = "★"
                e.FormattingApplied = True
            ElseIf Util.checkDBNullValue(e.Value) = 0 Then
                e.Value = ""
                e.FormattingApplied = True
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim dgv1rowcount As Integer = DataGridView1.Rows.Count
        If dgv1rowcount = 0 Then
            Return
        End If
        Dim i As Integer = DataGridView1.CurrentRow.Index
        cmbKaigodo.Text = Util.checkDBNullValue(DataGridView1(1, i).Value)
        YmdBoxStart.setADStr(Util.checkDBNullValue(DataGridView1(2, i).Value))
        YmdBoxEnd.setADStr(Util.checkDBNullValue(DataGridView1(4, i).Value))
        If Util.checkDBNullValue(DataGridView1(5, i).Value) = 1 Then
            chkRiyou.Checked = True
        ElseIf Util.checkDBNullValue(DataGridView1(5, i).Value) <> 1 Then
            chkRiyou.Checked = False
        End If
        txtBikou.Text = Util.checkDBNullValue(DataGridView1(6, i).Value)

    End Sub

    Private Sub lstName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstName.SelectedIndexChanged
        btnKuria.PerformClick()
        DataGridView1.Columns.Clear()
        lblName.Text = lstName.Text

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
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        SQLCm.CommandText = "SELECT Nam, kai As 介護度, KikanS As 開始日, KikanE As 満了日, Riyo As 利用, Kyotaku As 備考 FROM Kai WHERE Nam = '" & lblName.Text & "' ORDER BY KikanS"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .RowHeadersWidth = 20
            .Columns(0).Visible = False
            .Columns(1).Width = 60
            .Columns(2).Width = 70
            .Columns(3).Width = 70
            .Columns(4).Width = 40
            .Columns(5).Width = 284

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        Dim TextColumn As New DataGridViewTextBoxColumn
        Me.DataGridView1.Columns.Insert(3, TextColumn)
        TextColumn.Name = "a"
        TextColumn.HeaderText = ""

        DataGridView1.Columns(3).Width = 15

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1(3, i).Value = "～"
        Next

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.Selected = True Then
                row.Selected = False
                Exit For
            End If
        Next

    End Sub

    Private Sub btnKousinn_Click(sender As System.Object, e As System.EventArgs) Handles btnKousinn.Click
        btnKuria.PerformClick()
        DataGridView1.Columns.Clear()

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
            .RowHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        SQLCm.CommandText = "SELECT Nam, kai As 介護度, KikanS As 開始日, KikanE As 満了日, Riyo As 利用, Kyotaku As 備考 FROM Kai WHERE Nam = '" & lblName.Text & "' ORDER BY KikanS"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        With DataGridView1
            .RowHeadersWidth = 20
            .Columns(0).Visible = False
            .Columns(1).Width = 60
            .Columns(2).Width = 70
            .Columns(3).Width = 70
            .Columns(4).Width = 40
            .Columns(5).Width = 284

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With

        For Each c As DataGridViewColumn In DataGridView1.Columns
            c.SortMode = DataGridViewColumnSortMode.NotSortable
        Next c

        Dim TextColumn As New DataGridViewTextBoxColumn
        Me.DataGridView1.Columns.Insert(3, TextColumn)
        TextColumn.Name = "a"
        TextColumn.HeaderText = ""

        DataGridView1.Columns(3).Width = 15

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            DataGridView1(3, i).Value = "～"
        Next
    End Sub

    Private Sub btnKuria_Click(sender As System.Object, e As System.EventArgs) Handles btnKuria.Click
        YmdBoxStart.setADStr(Today.ToString("yyyy/MM/dd"))
        YmdBoxEnd.setADStr(Today.ToString("yyyy/MM/dd"))
        cmbKaigodo.Text = ""
        txtBikou.Text = ""
        chkRiyou.Checked = False
    End Sub

    Private Sub btnTouroku_Click(sender As System.Object, e As System.EventArgs) Handles btnTouroku.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択してください。")
            Return
        End If

        If YmdBoxStart.getADStr() >= YmdBoxEnd.getADStr() Then
            MsgBox("有効期限が正しくありません。")
            Return
        End If

        If cmbKaigodo.Text = "" Then
            MsgBox("介護度を入力してください。")
            Return
        End If

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            If YmdBoxStart.getADStr() = DataGridView1(2, i).Value Then
                Henkou()
                Riyou()
                btnKousinn.PerformClick()
                Exit Sub
            End If
        Next

        Tuika()
        Riyou()

        btnKousinn.PerformClick()

    End Sub
    Private Sub Henkou()
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim SQL As String = ""
        SQL = "DELETE FROM Kai WHERE (Nam = '" & lblName.Text & "') AND (KikanS ='" & YmdBoxStart.getADStr() & "')"
        SQLCm.CommandText = SQL

        Cn.Open()
        SQLCm.ExecuteNonQuery()
        Cn.Close()

        SQLCm.Dispose()
        Cn.Dispose()

        Tuika()
    End Sub
    Private Sub Tuika()
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Table As DataTable = DirectCast(DataGridView1.DataSource, DataTable)
        Dim nam, kikans, kikane, kai, kyotaku As String
        Dim riyo As Integer = 0
        nam = lblName.Text
        kikans = YmdBoxStart.getADStr()
        kikane = YmdBoxEnd.getADStr()
        kai = cmbKaigodo.Text
        If chkRiyou.Checked = True Then
            riyo = 1
        ElseIf chkRiyou.Checked = False Then
            riyo = 0
        End If
        kyotaku = txtBikou.Text

        Cn.Open()
        Dim SQL As String = ""
        SQL = "INSERT INTO Kai (Nam, KikanS, KikanE, kai, Riyo, Kyotaku) VALUES ('" & nam & "', '" & kikans & "', '" & kikane & "', '" & kai & "', " & riyo & ", '" & kyotaku & "')"

        SQLCm.CommandText = SQL
        SQLCm.ExecuteNonQuery()
        Cn.Close()
        SQLCm.Dispose()
        Cn.Dispose()

    End Sub
    Private Sub Riyou()
        If DataGridView1.Rows.Count >= 1 Then
            Dim riyo As Integer
            If chkRiyou.Checked = True Then
                riyo = 1
            Else
                riyo = 0
            End If
            If DataGridView1(5, 0).Value <> riyo Then
                Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
                Dim SQLCm As OleDbCommand = Cn.CreateCommand
                Dim nam, kikans, kikane, kai, kyotaku As String
                'Dim riyo As Integer
                nam = lblName.Text
                'If chkRiyou.Checked = True Then
                '    riyo = 1
                'ElseIf chkRiyou.Checked = False Then
                '    riyo = 0
                'End If
                Cn.Open()
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    kikans = Util.checkDBNullValue(DataGridView1(2, i).Value)
                    kikane = Util.checkDBNullValue(DataGridView1(4, i).Value)
                    kai = Util.checkDBNullValue(DataGridView1(1, i).Value)
                    kyotaku = Util.checkDBNullValue(DataGridView1(6, i).Value)

                    Dim SQL As String = ""
                    SQL = "UPDATE Kai SET "
                    SQL &= " kikans = '" & kikans & "', "
                    SQL &= " kikane = '" & kikane & "', "
                    SQL &= " kai = '" & kai & "', "
                    SQL &= " riyo = " & riyo & ", "
                    SQL &= " kyotaku = '" & kyotaku & "' "
                    SQL &= " WHERE "
                    SQL &= " Nam = '" & nam & "' AND kikans = '" & kikans & "' "

                    SQLCm.CommandText = SQL

                    SQLCm.ExecuteNonQuery()
                Next

                Cn.Close()
                SQLCm.Dispose()
                Cn.Dispose()
            End If
        End If
    End Sub

    Private Sub btnSakujo_Click(sender As System.Object, e As System.EventArgs) Handles btnSakujo.Click
        If lblName.Text = "" Then
            MsgBox("利用者を選択してください。")
            Return
        End If

        Dim selectedRow As Integer = If(IsNothing(DataGridView1.CurrentRow), -1, DataGridView1.CurrentRow.Index)

        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim SQL As String = ""
        If selectedRow = -1 Then    '選択されていない場合は全消去
            If MsgBox(lblName.Text & "　様の全データを削除しますか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
                SQL = "DELETE FROM Kai WHERE Nam = '" & lblName.Text & "'"
            Else
                Return
            End If
        Else
            If MsgBox("削除してよろしいですか？", MsgBoxStyle.YesNo + vbExclamation, "削除確認") = MsgBoxResult.Yes Then
                SQL = "DELETE FROM Kai WHERE (Nam = '" & lblName.Text & "') AND (KikanS ='" & YmdBoxStart.getADStr() & "')"
            Else
                Return
            End If
        End If

        SQLCm.CommandText = SQL

        Cn.Open()
        SQLCm.ExecuteNonQuery()
        Cn.Close()

        SQLCm.Dispose()
        Cn.Dispose()

        btnKousinn.PerformClick()

    End Sub


End Class