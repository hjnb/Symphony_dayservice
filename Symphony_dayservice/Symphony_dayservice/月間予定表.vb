Imports System.Data.OleDb

Public Class 月間予定表

    '土曜日の列のセルスタイル
    Private saturdayColumnCellStyle As DataGridViewCellStyle

    '日曜日の列のセルスタイル
    Private sundayColumnCellStyle As DataGridViewCellStyle

    '日にちの行のセルスタイル
    Private dateRowCellStyle As DataGridViewCellStyle

    '曜日の行のセルスタイル
    Private dayRowCellStyle As DataGridViewCellStyle

    '
    Private dt As DataTable = New DataTable()

    Private Sub 月間予定表_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        '利用者リストの表示
        displayUserList()

        '
        initDgvPlan()

        '現在年月設定
        ymBox.setADStr(Today.ToString("yyyy/MM/dd"))

    End Sub

    Private Sub createCellStyle()
        '日にちの行のセルスタイル
        dateRowCellStyle = New DataGridViewCellStyle()
        dateRowCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dateRowCellStyle.Font = New Font("MS UI Gothic", 9)

        '曜日の行のセルスタイル
        dayRowCellStyle = New DataGridViewCellStyle()
        dayRowCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dayRowCellStyle.Font = New Font("MS UI Gothic", 9)

        '土曜日の列のセルスタイル
        saturdayColumnCellStyle = New DataGridViewCellStyle()
        saturdayColumnCellStyle.BackColor = Color.FromArgb(200, 200, 255)
        saturdayColumnCellStyle.Font = New Font("MS UI Gothic", 8)

        '日曜日の列のセルスタイル
        sundayColumnCellStyle = New DataGridViewCellStyle()
        sundayColumnCellStyle.BackColor = Color.FromArgb(255, 200, 200)
        sundayColumnCellStyle.Font = New Font("MS UI Gothic", 8)
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
            .DefaultCellStyle.Font = New Font("MS UI Gothic", 8)
        End With
    End Sub

    Private Sub settingDgvPlanColumn()
        With dgvPlan
            With .Columns("Count")
                .Width = 30
            End With

            For i As Integer = 1 To 16
                With .Columns("D" & i)
                    .Width = 60
                End With
            Next
        End With
    End Sub

    Private Sub initDgvPlan()
        'dgv設定
        settingDgvPlan()

        '列追加
        dt.Columns.Add("Count", Type.GetType("System.String"))
        For i As Integer = 1 To 16
            dt.Columns.Add("D" & i, Type.GetType("System.String"))
        Next

        '日にちの行、空の行追加
        Dim row As DataRow
        For i As Integer = 0 To 55
            row = dt.NewRow()
            If i = 0 Then
                For j As Integer = 1 To 16
                    row("D" & j) = j
                Next
            ElseIf i = 28 Then
                For j As Integer = 1 To 15
                    row("D" & j) = j + 16
                Next
            End If
            dt.Rows.Add(row)
        Next

        '表示
        dgvPlan.DataSource = dt

        '列設定等
        settingDgvPlanColumn()

    End Sub

End Class