Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop

Public Class 月間予定表

    '曜日配列
    Private dayArray() As String = {"日", "月", "火", "水", "木", "金", "土"}

    'Count列の5,10,15,20,25までのセルスタイル
    Private count5CellStyle, count10CellStyle, count15CellStyle, count20CellStyle, count25CellStyle, count28CellStyle As DataGridViewCellStyle

    '土曜日,日曜日の列のセルスタイル
    Private saturdayColumnCellStyle, sundayColumnCellStyle As DataGridViewCellStyle

    '日にちの行,曜日の行,計の行のセルスタイル
    Private dateRowCellStyle, dayRowCellStyle, totalRowCellStyle As DataGridViewCellStyle

    'デフォルトのセルスタイル
    Private defaultCellStyle As DataGridViewCellStyle

    '表示用データテーブル
    Private dtPlan As DataTable = New DataTable()

    '入力制御用
    Private inputFlg As Boolean = False

    'アルファベット配列
    Private NAME_COLUMN_VALUES As Char() = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray

    'アルファベット配列長さ
    Private NAME_COLUMN_VALUES_LENGTH As Integer = NAME_COLUMN_VALUES.Length
    ''' <summary>
    ''' loadイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub 月間予定表_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        '現在フォームが存在しているディスプレイを取得
        Dim s As System.Windows.Forms.Screen = System.Windows.Forms.Screen.FromControl(Me)
        'ディスプレイの高さと幅を取得
        Dim h As Integer = s.Bounds.Height
        If h < 900 Then
            dgvPlan.Size = New Size(1072, 649)
        End If

        'スタイル定義
        createCellStyle()

        '利用者リストの表示
        displayUserList()

        'dgv初期化
        initDgvPlan()

        '現在年月設定()
        ymBox.setADStr(Today.ToString("yyyy/MM/dd"))

    End Sub

    ''' <summary>
    ''' セルスタイル作成
    ''' </summary>
    ''' <remarks></remarks>
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
        count5CellStyle.BackColor = Color.FromArgb(255, 255, 255)
        count5CellStyle.Font = New Font("MS UI Gothic", 10)
        count5CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の10までのセルスタイル
        count10CellStyle = New DataGridViewCellStyle()
        count10CellStyle.BackColor = Color.FromArgb(255, 242, 255)
        count10CellStyle.Font = New Font("MS UI Gothic", 10)
        count10CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の15までのセルスタイル
        count15CellStyle = New DataGridViewCellStyle()
        count15CellStyle.BackColor = Color.FromArgb(254, 222, 253)
        count15CellStyle.Font = New Font("MS UI Gothic", 10)
        count15CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の20までのセルスタイル
        count20CellStyle = New DataGridViewCellStyle()
        count20CellStyle.BackColor = Color.FromArgb(248, 154, 245)
        count20CellStyle.Font = New Font("MS UI Gothic", 10)
        count20CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の25までのセルスタイル
        count25CellStyle = New DataGridViewCellStyle()
        count25CellStyle.BackColor = Color.FromArgb(233, 31, 233)
        count25CellStyle.Font = New Font("MS UI Gothic", 10)
        count25CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        'Count列の28までのセルスタイル
        count28CellStyle = New DataGridViewCellStyle()
        count28CellStyle.BackColor = Color.FromArgb(194, 18, 172)
        count28CellStyle.Font = New Font("MS UI Gothic", 10)
        count28CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '計の行のセルスタイル
        totalRowCellStyle = New DataGridViewCellStyle()
        totalRowCellStyle.Font = New Font("MS UI Gothic", 9)
        totalRowCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    ''' <summary>
    ''' 利用者選択リスト表示
    ''' </summary>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' dgv設定
    ''' </summary>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' dgv表示後の行、列スタイル設定
    ''' </summary>
    ''' <remarks></remarks>
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
            With .Rows(31)
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
            With .Rows(32)
                .DefaultCellStyle = dayRowCellStyle
                .Height = 15
                .ReadOnly = True
            End With

            'Count列の5までのセルスタイル
            For i As Integer = 2 To 6
                .Rows(i).Cells("Count").Style = count5CellStyle
                .Rows(i + 31).Cells("Count").Style = count5CellStyle
            Next

            'Count列の10までのセルスタイル
            For i As Integer = 7 To 11
                .Rows(i).Cells("Count").Style = count10CellStyle
                .Rows(i + 31).Cells("Count").Style = count10CellStyle
            Next

            'Count列の15までのセルスタイル
            For i As Integer = 12 To 16
                .Rows(i).Cells("Count").Style = count15CellStyle
                .Rows(i + 31).Cells("Count").Style = count15CellStyle
            Next

            'Count列の20までのセルスタイル
            For i As Integer = 17 To 21
                .Rows(i).Cells("Count").Style = count20CellStyle
                .Rows(i + 31).Cells("Count").Style = count20CellStyle
            Next

            'Count列の25までのセルスタイル
            For i As Integer = 22 To 26
                .Rows(i).Cells("Count").Style = count25CellStyle
                .Rows(i + 31).Cells("Count").Style = count25CellStyle
            Next

            'Count列の28までのセルスタイル
            For i As Integer = 27 To 29
                .Rows(i).Cells("Count").Style = count28CellStyle
                .Rows(i + 31).Cells("Count").Style = count28CellStyle
            Next

            '計の行のセルスタイル
            .Rows(30).DefaultCellStyle = totalRowCellStyle
            .Rows(30).ReadOnly = True
            .Rows(61).DefaultCellStyle = totalRowCellStyle
            .Rows(61).ReadOnly = True

        End With

    End Sub

    ''' <summary>
    ''' dgv初期化処理
    ''' </summary>
    ''' <remarks></remarks>
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
        For i As Integer = 0 To 61
            row = dtPlan.NewRow()
            If i = 0 Then
                '日にち(1～16)
                For j As Integer = 1 To 16
                    row("D" & j) = j
                Next
            ElseIf i >= 2 AndAlso i <= 29 AndAlso (i - 1) Mod 5 = 0 Then
                row("Count") = i - 1
            ElseIf i = 30 OrElse i = 61 Then
                row("Count") = "計"
            ElseIf i = 31 Then
                '日にち(17～31)
                For j As Integer = 1 To 15
                    row("D" & j) = j + 16
                Next
            ElseIf i >= 33 AndAlso (i - 32) Mod 5 = 0 Then
                row("Count") = i - 32
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

    ''' <summary>
    ''' dgvデータクリア
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub clearDgv()
        inputFlg = False

        '曜日行の文字クリア、計の行クリア
        For i As Integer = 1 To 16
            dgvPlan.Rows(1).Cells("D" & i).Value = ""
            dgvPlan.Rows(30).Cells("D" & i).Value = ""
            dgvPlan.Rows(32).Cells("D" & i).Value = ""
            dgvPlan.Rows(61).Cells("D" & i).Value = ""
        Next

        '氏名入力部分の文字、スタイルクリア
        For i As Integer = 2 To 60
            For j As Integer = 1 To 16
                dgvPlan.Rows(i).Cells("D" & j).Value = ""
                dgvPlan.Rows(i).Cells("D" & j).Style = defaultCellStyle
                dgvPlan.Rows(i).Cells("D" & j).ReadOnly = False
            Next
            If i = 29 Then
                i = 32
            End If
        Next

    End Sub

    ''' <summary>
    ''' 対象年月の曜日設定
    ''' </summary>
    ''' <param name="ymStr">年月文字列(yyyy/MM)</param>
    ''' <remarks></remarks>
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
                For j As Integer = 2 To 29
                    dgvPlan.Rows(j).Cells("D" & i).Style = saturdayColumnCellStyle
                Next
            ElseIf dayStr = "日" Then
                For j As Integer = 2 To 29
                    dgvPlan.Rows(j).Cells("D" & i).Style = sundayColumnCellStyle
                Next
            End If
        Next
        '１７～３１日の曜日行の値設定
        For i As Integer = 1 To 15 - (31 - dayLimit)
            dayStr = dayArray((firstDayNum + 2 + (i - 1)) Mod 7)
            dgvPlan.Rows(32).Cells("D" & i).Value = dayStr
            If dayStr = "土" Then
                For j As Integer = 33 To 60
                    dgvPlan.Rows(j).Cells("D" & i).Style = saturdayColumnCellStyle
                Next
            ElseIf dayStr = "日" Then
                For j As Integer = 33 To 60
                    dgvPlan.Rows(j).Cells("D" & i).Style = sundayColumnCellStyle
                Next
            End If
        Next

        '対象の月に存在しない日の列を編集不可にする
        For i As Integer = 16 - (31 - dayLimit) To 16
            For j As Integer = 33 To 60
                dgvPlan.Rows(j).Cells("D" & i).ReadOnly = True
            Next
        Next

    End Sub

    ''' <summary>
    ''' 月間予定表表示
    ''' </summary>
    ''' <param name="ymStr">年月文字列(yyyy/MM)</param>
    ''' <remarks></remarks>
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
                gyoNum = gyoNum + 32
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

    ''' <summary>
    ''' 計の行書き込み
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub writeTotalNum()
        Dim count As Integer = 0
        '１～１６日の計
        For i As Integer = 1 To 16
            count = 0
            For j As Integer = 2 To 29
                If Util.checkDBNullValue(dtPlan.Rows(j).Item("D" & i)) <> "" Then
                    count += 1
                End If
            Next
            If count <> 0 Then
                dtPlan.Rows(30).Item("D" & i) = count
            End If
        Next
        '１７～３１日の計
        For i As Integer = 1 To 15
            count = 0
            For j As Integer = 33 To 60
                If Util.checkDBNullValue(dtPlan.Rows(j).Item("D" & i)) <> "" Then
                    count += 1
                End If
            Next
            If count <> 0 Then
                dtPlan.Rows(61).Item("D" & i) = count
            End If
        Next
    End Sub

    ''' <summary>
    ''' dgvセルエンターイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPlan_CellEnter(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvPlan.CellEnter
        If inputFlg = True Then
            dgvPlan.BeginEdit(True)
        End If
    End Sub

    ''' <summary>
    ''' dgvセルマウスクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPlan_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvPlan.CellMouseClick
        Dim clickedCell As DataGridViewCell = dgvPlan(e.ColumnIndex, e.RowIndex)
        If clickedCell.ReadOnly = True Then
            MsgBox("範囲内をクリックして下さい。")
            Return
        End If
    End Sub

    ''' <summary>
    ''' dgvセルペイントイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dgvPlan_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvPlan.CellPainting
        If (e.RowIndex = 31) AndAlso (e.PaintParts And DataGridViewPaintParts.Border) = DataGridViewPaintParts.Border Then
            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.Inset
        End If

        If e.ColumnIndex >= 0 AndAlso e.RowIndex >= 0 AndAlso (e.PaintParts And DataGridViewPaintParts.Background) = DataGridViewPaintParts.Background Then
            e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)
            Dim pParts As DataGridViewPaintParts = e.PaintParts And Not DataGridViewPaintParts.Background
            e.Paint(e.ClipBounds, pParts)
            e.Handled = True
        End If
    End Sub

    ''' <summary>
    ''' 年月ボックステキスト変更イベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ymBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles ymBox.YmdTextChange
        'dgvのデータクリア
        clearDgv()

        '曜日設定
        setDay(ymBox.getADYmStr())

        'データ表示
        displayPlan(ymBox.getADYmStr())

    End Sub

    ''' <summary>
    ''' テキストクリアボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnTextClear_Click(sender As System.Object, e As System.EventArgs) Handles btnTextClear.Click
        For i As Integer = 2 To 61
            For j As Integer = 1 To 16
                dgvPlan.Rows(i).Cells("D" & j).Value = ""
            Next
            If i = 30 Then
                i = 32
            End If
        Next
    End Sub

    ''' <summary>
    ''' 利用者選択リストクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UserListBox_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles UserListBox.MouseClick
        selectUserLabel.Text = UserListBox.SelectedItem
    End Sub

    ''' <summary>
    ''' 追加ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If selectUserLabel.Text = "" Then
            MsgBox("利用者を選択して下さい。")
            Return
        End If

        If Not IsNothing(dgvPlan.CurrentCell) AndAlso dgvPlan.CurrentCell.Selected = True AndAlso dgvPlan.CurrentCell.ReadOnly = False Then
            dgvPlan.CurrentCell.Value = selectUserLabel.Text
            Dim columnIndex As Integer = dgvPlan.CurrentCellAddress.X
            Dim rowIndex As Integer = dgvPlan.CurrentCellAddress.Y
            If (2 <= rowIndex AndAlso rowIndex <= 28) OrElse (33 <= rowIndex AndAlso rowIndex <= 59) Then
                dgvPlan.CurrentCell = dgvPlan(columnIndex, rowIndex + 1)
            End If
        Else
            MsgBox("挿入箇所を指定して下さい。")
        End If
    End Sub

    ''' <summary>
    ''' 登録ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

        '登録データ作成
        Dim registData(30, 27) As String
        Dim count As Integer
        Dim nam As String = ""
        For i As Integer = 1 To 16
            count = 0
            For j As Integer = 2 To 29
                nam = Util.checkDBNullValue(dgvPlan("D" & i, j).Value)
                If nam <> "" Then
                    registData(i - 1, count) = nam
                    count += 1
                End If
            Next
        Next
        For i As Integer = 1 To 15
            count = 0
            For j As Integer = 33 To 60
                nam = Util.checkDBNullValue(dgvPlan("D" & i, j).Value)
                If nam <> "" Then
                    registData(i - 1 + 16, count) = nam
                    count += 1
                End If
            Next
        Next

        'レコードセットに登録データ追加
        Dim cnn As New ADODB.Connection
        Dim rs As New ADODB.Recordset
        cnn.Open(TopForm.DB_dayservice)
        rs.Open("PlnM", cnn, ADODB.CursorTypeEnum.adOpenForwardOnly, ADODB.LockTypeEnum.adLockPessimistic)
        Dim ym As String = ymBox.getADYmStr()
        For i As Integer = 1 To 16
            For j As Integer = 2 To 29
                With rs
                    .AddNew()
                    .Fields("Gyo").Value = j - 1
                    .Fields("Ym").Value = ym
                    .Fields("Day").Value = i
                    .Fields("Nam").Value = registData(i - 1, j - 2)
                End With
            Next
        Next
        For i As Integer = 1 To 15
            For j As Integer = 33 To 60
                With rs
                    .AddNew()
                    .Fields("Gyo").Value = j - 1 - 31
                    .Fields("Ym").Value = ym
                    .Fields("Day").Value = i + 16
                    .Fields("Nam").Value = registData(i + 15, j - 33)
                End With
            Next
        Next

        '登録
        rs.Update()
        cnn.Close()

        'dgvのデータクリア
        clearDgv()

        '曜日設定
        setDay(ymBox.getADYmStr())

        'データ表示
        displayPlan(ymBox.getADYmStr())
    End Sub

    ''' <summary>
    ''' 削除ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' 印刷ボタンクリックイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPrint_Click(sender As System.Object, e As System.EventArgs) Handles btnPrint.Click
        '
        Dim year As Integer = CInt(ymBox.getADYmStr.Substring(0, 4))
        Dim month As Integer = CInt(ymBox.getADYmStr.Substring(5, 2))
        Dim firstDayWeekNum As Integer = New DateTime(year, month, 1).DayOfWeek '最初の曜日の数値
        Dim lastDayNum As Integer = DateTime.DaysInMonth(year, month) '月の日数

        'データ取得
        Dim dataArray(59, 125) As String
        Dim baseRowNum As Integer = 0
        Dim rowIndex As Integer = 0
        Dim columnIndex As Integer = 0
        Dim youbiIndex As Integer = firstDayWeekNum - 1
        Dim tmpDay As Integer = 0
        Dim cn As New ADODB.Connection()
        cn.Open(TopForm.DB_dayservice)
        Dim sql As String = "select Gyo, Nam, Day from PlnM where Ym='" & ymBox.getADYmStr() & "' order by Day, Gyo"
        Dim rs As New ADODB.Recordset
        rs.Open(sql, cn, ADODB.CursorTypeEnum.adOpenKeyset, ADODB.LockTypeEnum.adLockOptimistic)
        While Not rs.EOF
            Dim day As Integer = Util.checkDBNullValue(rs.Fields("Day").Value)
            Dim nam As String = Util.checkDBNullValue(rs.Fields("Nam").Value)
            If tmpDay <> day Then
                rowIndex = 0
                tmpDay = day
                youbiIndex = (youbiIndex + 1) Mod 7
                columnIndex = youbiIndex * 18
                If youbiIndex = 0 AndAlso day <> 1 Then
                    baseRowNum += 10
                End If

                '日付
                dataArray(rowIndex + baseRowNum, columnIndex) = day

                rowIndex += 2
                columnIndex += 1
            End If

            '名前
            dataArray(rowIndex + baseRowNum, columnIndex) = nam

            rowIndex = (rowIndex + 1) Mod 10
            If rowIndex = 0 Then
                columnIndex += 6
            End If
            rs.MoveNext()
        End While
        rs.Close()
        cn.Close()

        'エクセル
        Dim objExcel As Excel.Application = CreateObject("Excel.Application")
        Dim objWorkBooks As Excel.Workbooks = objExcel.Workbooks
        Dim objWorkBook As Excel.Workbook = objWorkBooks.Open(TopForm.excelFilePass)
        Dim oSheet As Excel.Worksheet = objWorkBook.Worksheets("MonthlyUsr2")
        objExcel.Calculation = Excel.XlCalculation.xlCalculationManual
        objExcel.ScreenUpdating = False

        '年月部分書き込み
        Dim eraNum As String = CInt(ymBox.EraText.Substring(1, 2)).ToString
        oSheet.Range("AK1").Value = ymBox.getWarekiKanji()
        oSheet.Range("AS1").Value = eraNum
        oSheet.Range("BC1").Value = month

        'データ書き込み
        oSheet.Range("A6", "DV65").Value = dataArray

        objExcel.Calculation = Excel.XlCalculation.xlCalculationAutomatic
        objExcel.ScreenUpdating = True

        '変更保存確認ダイアログ非表示
        objExcel.DisplayAlerts = False

        '印刷
        If TopForm.rbtnPrint.Checked = True Then
            oSheet.PrintOut()
        ElseIf TopForm.rbtnPreview.Checked = True Then
            objExcel.Visible = True
            oSheet.PrintPreview(1)
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

    ''' <summary>
    ''' dgvセル内のテキストボックスkeyDownイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub dataGridViewTextBox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        If tb.ImeMode <> Windows.Forms.ImeMode.Hiragana Then
            e.SuppressKeyPress = True
        End If
    End Sub

    ''' <summary>
    ''' dgvセル編集時のイベント
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' エクセル列番号文字列を取得
    ''' </summary>
    ''' <param name="num">列番号数値</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getColumnAlphabet(num As Integer) As String
        Dim s As String = ""
        Do While num > 0
            num -= 1
            Dim m As Integer = num Mod NAME_COLUMN_VALUES_LENGTH
            s = NAME_COLUMN_VALUES(m) & s
            num = Math.Floor(num / NAME_COLUMN_VALUES_LENGTH)
        Loop
        Return s
    End Function

    ''' <summary>
    ''' 対象の日にちのdgvのテキストをエクセルに書き込む
    ''' </summary>
    ''' <param name="dateNum">日にち</param>
    ''' <param name="namList">氏名リスト</param>
    ''' <param name="startCellStrNum">開始列番号</param>
    ''' <param name="startCellRowNum">開始行番号</param>
    ''' <param name="oSheet">エクセルシートオブジェクト</param>
    ''' <remarks></remarks>
    Private Sub writeCalendarCell(dateNum As Integer, namList As List(Of String), startCellStrNum As Integer, startCellRowNum As Integer, oSheet As Object)
        '日付
        oSheet.Range(getColumnAlphabet(startCellStrNum) & startCellRowNum).value = dateNum

        '氏名の1列目
        For i As Integer = 0 To 6
            oSheet.Range(getColumnAlphabet(startCellStrNum + 1) & (startCellRowNum + 2 + i)).value = namList(i)
        Next

        '氏名の2列目
        For i As Integer = 0 To 8
            oSheet.Range(getColumnAlphabet(startCellStrNum + 7) & (startCellRowNum + i)).value = namList(i + 7)
        Next

        '氏名の3列目
        For i As Integer = 0 To 8
            If i + 16 > namList.Count - 1 Then
                Exit For
            End If
            oSheet.Range(getColumnAlphabet(startCellStrNum + 13) & (startCellRowNum + i)).value = namList(i + 16)
        Next
    End Sub

    ''' <summary>
    ''' 対象の日にちテキストをエクセルに書き込む
    ''' </summary>
    ''' <param name="dateNum">日にち</param>
    ''' <param name="startCellStrNum">開始列番号</param>
    ''' <param name="startCellRowNum">開始行番号</param>
    ''' <param name="oSheet">エクセルシートオブジェクト</param>
    ''' <remarks></remarks>
    Private Sub writeCalendarOnlyDateNum(dateNum As Integer, startCellStrNum As Integer, startCellRowNum As Integer, oSheet As Object)
        '日付のみ書き込み
        oSheet.Range(getColumnAlphabet(startCellStrNum) & startCellRowNum).value = dateNum
    End Sub
End Class