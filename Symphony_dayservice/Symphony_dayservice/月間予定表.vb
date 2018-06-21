Imports System.Data.OleDb

Public Class 月間予定表

    '曜日配列
    Private dayArray() As String = {"日", "月", "火", "水", "木", "金", "土"}

    '土曜日の列のセルスタイル
    Private saturdayColumnCellStyle As DataGridViewCellStyle

    '日曜日の列のセルスタイル
    Private sundayColumnCellStyle As DataGridViewCellStyle

    '日にちの行のセルスタイル
    Private dateRowCellStyle As DataGridViewCellStyle

    '曜日の行のセルスタイル
    Private dayRowCellStyle As DataGridViewCellStyle

    'デフォルトのセルスタイル
    Private defaultCellStyle As DataGridViewCellStyle

    'Count列の5までのセルスタイル
    Private count5CellStyle As DataGridViewCellStyle

    'Count列の10までのセルスタイル
    Private count10CellStyle As DataGridViewCellStyle

    'Count列の15までのセルスタイル
    Private count15CellStyle As DataGridViewCellStyle

    'Count列の20までのセルスタイル
    Private count20CellStyle As DataGridViewCellStyle

    'Count列の25までのセルスタイル
    Private count25CellStyle As DataGridViewCellStyle

    '計の行のセルスタイル
    Private totalRowCellStyle As DataGridViewCellStyle

    '表示用データテーブル
    Private dtPlan As DataTable = New DataTable()

    '入力制御用
    Private inputFlg As Boolean = False

    Private Sub 月間予定表_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        'スタイル定義
        createCellStyle()

        '利用者リストの表示
        displayUserList()

        'dgv初期化
        initDgvPlan()

        '現在年月設定()
        ymBox.setADStr(Today.ToString("yyyy/MM/dd"))

    End Sub

    Private Sub createCellStyle()
        'デフォルトのセルスタイル
        defaultCellStyle = New DataGridViewCellStyle()
        defaultCellStyle = dgvPlan.DefaultCellStyle

        '日にちの行のセルスタイル
        dateRowCellStyle = New DataGridViewCellStyle()
        dateRowCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dateRowCellStyle.Font = New Font("MS UI Gothic", 10)

        '曜日の行のセルスタイル
        dayRowCellStyle = New DataGridViewCellStyle()
        dayRowCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dayRowCellStyle.Font = New Font("MS UI Gothic", 9)
        dayRowCellStyle.BackColor = Color.FromKnownColor(KnownColor.Control)

        '土曜日の列のセルスタイル
        saturdayColumnCellStyle = New DataGridViewCellStyle()
        saturdayColumnCellStyle.BackColor = Color.FromArgb(200, 200, 255)
        saturdayColumnCellStyle.Font = New Font("MS UI Gothic", 8)

        '日曜日の列のセルスタイル
        sundayColumnCellStyle = New DataGridViewCellStyle()
        sundayColumnCellStyle.BackColor = Color.FromArgb(255, 200, 200)
        sundayColumnCellStyle.Font = New Font("MS UI Gothic", 8)

        'Count列の5までのセルスタイル
        count5CellStyle = New DataGridViewCellStyle()
        count5CellStyle.BackColor = Color.FromArgb(255, 242, 255)
        count5CellStyle.Font = New Font("MS UI Gothic", 10)
        count5CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の10までのセルスタイル
        count10CellStyle = New DataGridViewCellStyle()
        count10CellStyle.BackColor = Color.FromArgb(254, 222, 253)
        count10CellStyle.Font = New Font("MS UI Gothic", 10)
        count10CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の15までのセルスタイル
        count15CellStyle = New DataGridViewCellStyle()
        count15CellStyle.BackColor = Color.FromArgb(248, 154, 245)
        count15CellStyle.Font = New Font("MS UI Gothic", 10)
        count15CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の20までのセルスタイル
        count20CellStyle = New DataGridViewCellStyle()
        count20CellStyle.BackColor = Color.FromArgb(233, 31, 233)
        count20CellStyle.Font = New Font("MS UI Gothic", 10)
        count20CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の25までのセルスタイル
        count25CellStyle = New DataGridViewCellStyle()
        count25CellStyle.BackColor = Color.FromArgb(194, 18, 172)
        count25CellStyle.Font = New Font("MS UI Gothic", 10)
        count25CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '計の行のセルスタイル
        totalRowCellStyle = New DataGridViewCellStyle()
        totalRowCellStyle.Font = New Font("MS UI Gothic", 9)
        totalRowCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Private Sub displayUserList()
        '背景色の設定
        UserListBox.BackColor = Color.FromKnownColor(KnownColor.Control)

        'データ取得、表示
        Dim reader As System.Data.OleDb.OleDbDataReader
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        SQLCm.CommandText = "select Nam from UsrM where Dsp='1' order by Kana"
        Cn.Open()
        reader = SQLCm.ExecuteReader()
        While reader.Read() = True
            UserListBox.Items.Add(Util.checkDBNullValue(reader("Nam")))
        End While
        reader.Close()
        Cn.Close()
    End Sub

    Private Sub settingDgvPlan()
        'DoubleBufferedプロパティをTrue
        Util.EnableDoubleBuffering(dgvPlan)

        'dgv設定
        With dgvPlan
            .AllowUserToAddRows = False '行追加禁止
            .AllowUserToResizeColumns = False '列の幅をユーザーが変更できないようにする
            .AllowUserToResizeRows = False '行の高さをユーザーが変更できないようにする
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
            .RowHeadersVisible = False
            .ColumnHeadersVisible = False
            .RowTemplate.Height = 14
            .ShowCellToolTips = False
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 6.5)
            .DefaultCellStyle.SelectionForeColor = Color.Black
            .ImeMode = Windows.Forms.ImeMode.Hiragana
        End With
    End Sub

    Private Sub settingDgvPlanStyle()
        With dgvPlan
            'Count列
            With .Columns("Count")
                .Width = 28
                .ReadOnly = True
            End With

            'Count列以外
            For i As Integer = 1 To 16
                With .Columns("D" & i)
                    .Width = 64
                End With
            Next

            '日にちの行のスタイル設定
            With .Rows(0)
                .DefaultCellStyle = dateRowCellStyle
                .Height = 15
                .ReadOnly = True
            End With
            With .Rows(28)
                .DefaultCellStyle = dateRowCellStyle
                .Height = 15
                .ReadOnly = True
            End With

            '曜日の行のスタイル設定
            With .Rows(1)
                .DefaultCellStyle = dayRowCellStyle
                .Height = 15
                .ReadOnly = True
            End With
            With .Rows(29)
                .DefaultCellStyle = dayRowCellStyle
                .Height = 15
                .ReadOnly = True
            End With

            'Count列の5までのセルスタイル
            For i As Integer = 2 To 6
                .Rows(i).Cells("Count").Style = count5CellStyle
                .Rows(i + 28).Cells("Count").Style = count5CellStyle
            Next

            'Count列の10までのセルスタイル
            For i As Integer = 7 To 11
                .Rows(i).Cells("Count").Style = count10CellStyle
                .Rows(i + 28).Cells("Count").Style = count10CellStyle
            Next

            'Count列の15までのセルスタイル
            For i As Integer = 12 To 16
                .Rows(i).Cells("Count").Style = count15CellStyle
                .Rows(i + 28).Cells("Count").Style = count15CellStyle
            Next

            'Count列の20までのセルスタイル
            For i As Integer = 17 To 21
                .Rows(i).Cells("Count").Style = count20CellStyle
                .Rows(i + 28).Cells("Count").Style = count20CellStyle
            Next

            'Count列の25までのセルスタイル
            For i As Integer = 22 To 26
                .Rows(i).Cells("Count").Style = count25CellStyle
                .Rows(i + 28).Cells("Count").Style = count25CellStyle
            Next

            '計の行のセルスタイル
            .Rows(27).DefaultCellStyle = totalRowCellStyle
            .Rows(27).ReadOnly = True
            .Rows(55).DefaultCellStyle = totalRowCellStyle
            .Rows(55).ReadOnly = True

        End With

    End Sub

    Private Sub initDgvPlan()
        'dgv設定
        settingDgvPlan()

        '列追加
        dtPlan.Columns.Add("Count", Type.GetType("System.String"))
        For i As Integer = 1 To 16
            dtPlan.Columns.Add("D" & i, Type.GetType("System.String"))
        Next

        '日にちの行、空の行追加
        Dim row As DataRow
        For i As Integer = 0 To 55
            row = dtPlan.NewRow()
            If i = 0 Then
                '日にち(1～16)
                For j As Integer = 1 To 16
                    row("D" & j) = j
                Next
            ElseIf i > 1 AndAlso i < 28 AndAlso (i - 1) Mod 5 = 0 Then
                row("Count") = i - 1
            ElseIf i = 27 OrElse i = 55 Then
                row("Count") = "計"
            ElseIf i = 28 Then
                '日にち(17～31)
                For j As Integer = 1 To 15
                    row("D" & j) = j + 16
                Next
            ElseIf i > 29 AndAlso (i + 1) Mod 5 = 0 Then
                row("Count") = i - 30 + 1
            End If
            dtPlan.Rows.Add(row)
        Next

        '表示
        dgvPlan.DataSource = dtPlan

        '列、行のスタイル設定等
        settingDgvPlanStyle()

        'セル選択解除
        dgvPlan.CurrentCell.Selected = False

    End Sub

    Private Sub clearDgv()
        inputFlg = False

        '曜日行の文字クリア、計の行クリア
        For i As Integer = 1 To 16
            dgvPlan.Rows(1).Cells("D" & i).Value = ""
            dgvPlan.Rows(27).Cells("D" & i).Value = ""
            dgvPlan.Rows(29).Cells("D" & i).Value = ""
            dgvPlan.Rows(55).Cells("D" & i).Value = ""
        Next

        '氏名入力部分の文字、スタイルクリア
        For i As Integer = 2 To 54
            For j As Integer = 1 To 16
                dgvPlan.Rows(i).Cells("D" & j).Value = ""
                dgvPlan.Rows(i).Cells("D" & j).Style = defaultCellStyle
                dgvPlan.Rows(i).Cells("D" & j).ReadOnly = False
            Next
            If i = 26 Then
                i = 29
            End If
        Next

    End Sub

    Private Sub setDay(ymStr As String)
        Dim year As Integer = CInt(ymStr.Substring(0, 4))
        Dim month As Integer = CInt(ymStr.Substring(5, 2))
        Dim firstDayNum As Integer = New DateTime(year, month, 1).DayOfWeek '最初の曜日の数値
        Dim dayLimit As Integer = DateTime.DaysInMonth(year, month) '月の日数
        Dim dayStr As String = ""

        '１～１６日の曜日行の値設定
        For i As Integer = 1 To 16
            dayStr = dayArray((firstDayNum + (i - 1)) Mod 7)
            dgvPlan.Rows(1).Cells("D" & i).Value = dayStr
            If dayStr = "土" Then
                For j As Integer = 2 To 26
                    dgvPlan.Rows(j).Cells("D" & i).Style = saturdayColumnCellStyle
                    dgvPlan.Rows(j).Cells("D" & i).ReadOnly = True
                Next
            ElseIf dayStr = "日" Then
                For j As Integer = 2 To 26
                    dgvPlan.Rows(j).Cells("D" & i).Style = sundayColumnCellStyle
                    dgvPlan.Rows(j).Cells("D" & i).ReadOnly = True
                Next
            End If
        Next
        '１７～３１日の曜日行の値設定
        For i As Integer = 1 To 15 - (31 - dayLimit)
            dayStr = dayArray((firstDayNum + 2 + (i - 1)) Mod 7)
            dgvPlan.Rows(29).Cells("D" & i).Value = dayStr
            If dayStr = "土" Then
                For j As Integer = 30 To 54
                    dgvPlan.Rows(j).Cells("D" & i).Style = saturdayColumnCellStyle
                    dgvPlan.Rows(j).Cells("D" & i).ReadOnly = True
                Next
            ElseIf dayStr = "日" Then
                For j As Integer = 30 To 54
                    dgvPlan.Rows(j).Cells("D" & i).Style = sundayColumnCellStyle
                    dgvPlan.Rows(j).Cells("D" & i).ReadOnly = True
                Next
            End If
        Next

        '対象の月に存在しない日の列を編集不可にする
        For i As Integer = 16 - (31 - dayLimit) To 16
            For j As Integer = 30 To 54
                dgvPlan.Rows(j).Cells("D" & i).ReadOnly = True
            Next
        Next

    End Sub

    Private Sub displayPlan(ymStr As String)
        '選択氏名ラベルクリア
        selectUserLabel.Text = ""
        UserListBox.ClearSelected()

        '選択解除
        dgvPlan.CurrentCell = dgvPlan("Count", 0)
        dgvPlan.CurrentCell.Selected = False

        Dim gyoNum, dayNum As Integer
        Dim nam As String
        Dim reader As System.Data.OleDb.OleDbDataReader
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        SQLCm.CommandText = "select Gyo, Ym, Day, Nam from PlnM where Ym=@ym order by Day, Gyo"
        SQLCm.Parameters.Clear()
        SQLCm.Parameters.Add("@ym", OleDbType.Char).Value = ymStr
        Cn.Open()
        reader = SQLCm.ExecuteReader()
        While reader.Read() = True
            gyoNum = If(Util.checkDBNullValue(reader("Gyo")) = "", -1, CInt(reader("Gyo")))
            dayNum = If(Util.checkDBNullValue(reader("Day")) = "", -1, CInt(reader("Day")))
            If gyoNum = -1 OrElse dayNum = -1 Then
                Continue While
            End If
            nam = Util.checkDBNullValue(reader("Nam"))
            If dayNum >= 17 Then
                gyoNum = gyoNum + 29
                dayNum = dayNum - 16
            Else
                gyoNum = gyoNum + 1
            End If
            dtPlan.Rows(gyoNum).Item("D" & dayNum) = nam
        End While
        reader.Close()
        Cn.Close()

        '計の行の書き込み処理
        writeTotalNum()

        inputFlg = True
    End Sub

    Private Sub writeTotalNum()
        Dim count As Integer = 0
        '１～１６日の計
        For i As Integer = 1 To 16
            count = 0
            For j As Integer = 2 To 26
                If Util.checkDBNullValue(dtPlan.Rows(j).Item("D" & i)) <> "" Then
                    count += 1
                End If
            Next
            If count <> 0 Then
                dtPlan.Rows(27).Item("D" & i) = count
            End If
        Next
        '１７～３１日の計
        For i As Integer = 1 To 15
            count = 0
            For j As Integer = 30 To 54
                If Util.checkDBNullValue(dtPlan.Rows(j).Item("D" & i)) <> "" Then
                    count += 1
                End If
            Next
            If count <> 0 Then
                dtPlan.Rows(55).Item("D" & i) = count
            End If
        Next
    End Sub

    Private Sub dgvPlan_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPlan.CellEnter
        If inputFlg = True Then
            dgvPlan.BeginEdit(True)
        End If
    End Sub

    Private Sub dgvPlan_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvPlan.CellPainting
        If (e.RowIndex = 28) AndAlso (e.PaintParts And DataGridViewPaintParts.Border) = DataGridViewPaintParts.Border Then
            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Inset
        End If

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)
            Dim pParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    Private Sub ymBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymBox.YmdTextChange
        'dgvのデータクリア
        clearDgv()

        '曜日設定
        setDay(ymBox.getADYmStr())

        'データ表示
        displayPlan(ymBox.getADYmStr())

    End Sub

    Private Sub btnTextClear_Click(sender As System.Object, e As System.EventArgs) Handles btnTextClear.Click
        For i As Integer = 2 To 55
            For j As Integer = 1 To 16
                dgvPlan.Rows(i).Cells("D" & j).Value = ""
            Next
            If i = 27 Then
                i = 29
            End If
        Next
    End Sub

    Private Sub UserListBox_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UserListBox.MouseClick
        selectUserLabel.Text = UserListBox.SelectedItem
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If Not IsNothing(dgvPlan.CurrentCell) AndAlso dgvPlan.CurrentCell.Selected = True AndAlso dgvPlan.CurrentCell.ReadOnly = False Then
            dgvPlan.CurrentCell.Value = selectUserLabel.Text
        End If
    End Sub

    Private Sub btnRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnRegist.Click
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand

        '該当月のデータ削除
        SQLCm.CommandText = "delete from PlnM where Ym=@ym"
        SQLCm.Parameters.Clear()
        SQLCm.Parameters.Add("@ym", OleDbType.Char).Value = ymBox.getADYmStr()
        Cn.Open()
        SQLCm.ExecuteNonQuery()
        Cn.Close()

        'データ登録
        'Dim adapter As New OleDbDataAdapter()
        'adapter.InsertCommand = New OleDbCommand("insert into PlnM values (@gyo, @ym, @day, @nam)", Cn)
        'adapter.InsertCommand.Parameters.Add("@gyo", OleDbType.Integer, 2, "Gyo")
        'adapter.InsertCommand.Parameters.Add("@ym", OleDbType.Char, 7, "Ym")
        'adapter.InsertCommand.Parameters.Add("@day", OleDbType.Integer, 2, "Day")
        'adapter.InsertCommand.Parameters.Add("@nam", OleDbType.Char, 10, "Nam")

        'Dim sw As New Stopwatch()

        'sw.Start()
        'Dim ym As String = ymBox.getADYmStr()
        'Dim dt As New DataTable()
        'dt.Columns.Add("Gyo", Type.GetType("System.Int32"))
        'dt.Columns.Add("Ym", Type.GetType("System.String"))
        'dt.Columns.Add("Day", Type.GetType("System.Int32"))
        'dt.Columns.Add("Nam", Type.GetType("System.String"))
        'Dim row As DataRow
        'For i As Integer = 1 To 16
        '    For j As Integer = 2 To 26
        '        row = dt.NewRow()
        '        row("Gyo") = j - 1
        '        row("Ym") = ym
        '        row("Day") = i
        '        row("Nam") = Util.checkDBNullValue(dgvPlan("D" & i, j).Value)
        '        dt.Rows.Add(row)
        '    Next
        'Next
        'For i As Integer = 1 To 15
        '    For j As Integer = 30 To 54
        '        row = dt.NewRow()
        '        row("Gyo") = j - 1 - 28
        '        row("Ym") = ym
        '        row("Day") = i + 16
        '        row("Nam") = Util.checkDBNullValue(dgvPlan("D" & i, j).Value)
        '        dt.Rows.Add(row)
        '    Next
        'Next
        'adapter.Update(dt.Select(Nothing, Nothing, DataViewRowState.Added))
        'sw.Stop()
        'MsgBox(sw.ElapsedMilliseconds)


        '2.8秒くらい
        'Dim sw As New Stopwatch()
        'sw.Start()
        'Dim gyo, day As Integer
        'Dim nam As String
        'Dim ym As String = ymBox.getADYmStr()
        'Cn.Open()
        'For i As Integer = 1 To 16
        '    day = i
        '    For j As Integer = 2 To 26
        '        gyo = j - 1
        '        nam = Util.checkDBNullValue(dgvPlan("D" & i, j).Value)
        '        SQLCm.CommandText = "insert into PlnM values(@gyo, @ym, @day, nam)"
        '        SQLCm.Parameters.Clear()
        '        SQLCm.Parameters.Add("@gyo", OleDbType.Integer).Value = gyo
        '        SQLCm.Parameters.Add("@ym", OleDbType.Char).Value = ym
        '        SQLCm.Parameters.Add("@day", OleDbType.Integer).Value = day
        '        SQLCm.Parameters.Add("@nam", OleDbType.Char).Value = nam
        '        SQLCm.ExecuteNonQuery()
        '    Next
        'Next
        'For i As Integer = 1 To 15
        '    day = i + 16
        '    For j As Integer = 30 To 54
        '        gyo = j - 1 - 28
        '        nam = Util.checkDBNullValue(dgvPlan("D" & i, j).Value)
        '        SQLCm.CommandText = "insert into PlnM values(@gyo, @ym, @day, nam)"
        '        SQLCm.Parameters.Clear()
        '        SQLCm.Parameters.Add("@gyo", OleDbType.Integer).Value = gyo
        '        SQLCm.Parameters.Add("@ym", OleDbType.Char).Value = ym
        '        SQLCm.Parameters.Add("@day", OleDbType.Integer).Value = day
        '        SQLCm.Parameters.Add("@nam", OleDbType.Char).Value = nam
        '        SQLCm.ExecuteNonQuery()
        '    Next
        'Next
        'Cn.Close()
        'sw.Stop()
        'MsgBox(sw.ElapsedMilliseconds)

        'dgvのデータクリア
        clearDgv()

        '曜日設定
        setDay(ymBox.getADYmStr())

        'データ表示
        displayPlan(ymBox.getADYmStr())
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MessageBox.Show("本月登録済みのデータを抹消しますか？", "dayservice", MessageBoxButtons.YesNo)
        If result = Windows.Forms.DialogResult.Yes Then
            Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
            Dim SQLCm As OleDbCommand = Cn.CreateCommand
            SQLCm.CommandText = "delete from PlnM where Ym=@ym"
            SQLCm.Parameters.Clear()
            SQLCm.Parameters.Add("@ym", OleDbType.Char).Value = ymBox.getADYmStr()
            Cn.Open()
            SQLCm.ExecuteNonQuery()
            Cn.Close()

            'dgvのデータクリア
            clearDgv()

            '曜日設定
            setDay(ymBox.getADYmStr())

            'データ表示
            displayPlan(ymBox.getADYmStr())
        End If
    End Sub

    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        'Dim objExcel As Object
        'Dim objWorkBooks As Object
        'Dim objWorkBook As Object
        'Dim oSheet As Object

        'objExcel = CreateObject("Excel.Application")
        'objWorkBooks = objExcel.Workbooks
        'objWorkBook = objWorkBooks.Open(TopForm.excelFilePass)
        'oSheet = objWorkBook.Worksheets("MonthlyUsr2")
    End Sub

    Private Sub dataGridViewTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        If tb.ImeMode <> Windows.Forms.ImeMode.Hiragana Then
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub dgvPlan_EditingControlShowing(sender As Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvPlan.EditingControlShowing
        If TypeOf e.Control Is DataGridViewTextBoxEditingControl Then
            Dim dgv As DataGridView = CType(sender, DataGridView)
            Dim tb As DataGridViewTextBoxEditingControl = CType(e.Control, DataGridViewTextBoxEditingControl)

            'イベントハンドラを削除
            RemoveHandler tb.KeyDown, AddressOf dataGridViewTextBox_KeyDown

            'イベントハンドラを追加
            AddHandler tb.KeyDown, AddressOf dataGridViewTextBox_KeyDown
        End If
    End Sub
End Class