Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Public Class TopForm

    'データベースのパス
    Public dbFilePath As String = My.Application.Info.DirectoryPath & "\dayservice.mdb"
    Public DB_dayservice As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbFilePath

    'エクセルのパス
    Public excelFilePass As String = My.Application.Info.DirectoryPath & "\書式.xls"

    '.iniファイルのパス
    Public iniFilePath As String = My.Application.Info.DirectoryPath & "\dayservice.ini"

    '画像パス
    Public imageFilePath As String = My.Application.Info.DirectoryPath & "\rira.bmp"

    'フォーム
    Private monthlyPlanForm As 月間予定表
    Private mealForm As 食事伝票
    Private kaigoForm As 介護度一覧
    Private userRegistForm As 利用者登録

    Private Sub TopForm_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'データベース、エクセル、構成ファイルの存在チェック
        If Not System.IO.File.Exists(dbFilePath) Then
            MsgBox("データベースファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(excelFilePass) Then
            MsgBox("エクセルファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(iniFilePath) Then
            MsgBox("構成ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        If Not System.IO.File.Exists(imageFilePath) Then
            MsgBox("画像ファイルが存在しません。ファイルを配置して下さい。")
            Me.Close()
            Exit Sub
        End If

        Me.WindowState = FormWindowState.Maximized

        '期限切れリストのymdbox初期値設定(値が変更されるのでYmdTextChangeイベントが動きます)
        timeLimitYmdBox.setADStr(Today.ToString("yyyy/MM/dd"))

        '画像表示
        topPicture.ImageLocation = imageFilePath

        initPrintState()

    End Sub

    Private Sub initPrintState()
        Dim state As String = Util.getIniString("System", "Printer", iniFilePath)
        If state = "Y" Then
            rbtnPrint.Checked = True
        Else
            rbtnPreview.Checked = True
        End If
    End Sub

    Private Sub rbtnPreview_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPreview.CheckedChanged
        If rbtnPreview.Checked = True Then
            Util.putIniString("System", "Printer", "N", iniFilePath)
        End If
    End Sub

    Private Sub rbtnPrint_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbtnPrint.CheckedChanged
        If rbtnPrint.Checked = True Then
            Util.putIniString("System", "Printer", "Y", iniFilePath)
        End If
    End Sub

    Private Sub settingTimeLimitList()
        timeLimitList.Items.Clear()
        Dim Cn As New OleDbConnection(Me.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        Dim Adapter As New OleDbDataAdapter(SQLCm)
        Dim Table As New DataTable

        Util.EnableDoubleBuffering(DataGridView1)

        SQLCm.CommandText = "SELECT Nam, kai, KikanS, KikanE, Riyo, Kyotaku FROM Kai WHERE KikanE LIKE '%" & timeLimitYmdBox.getADYmStr() & "%' ORDER BY KikanE"
        Adapter.Fill(Table)
        DataGridView1.DataSource = Table

        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            timeLimitList.Items.Add(DataGridView1(0, i).Value & " (" & Strings.Right(DataGridView1(3, i).Value, 5) & ")")
        Next
    End Sub

    Private Sub timeLimitYmdBox_YmdTextChange(sender As Object, e As System.EventArgs) Handles timeLimitYmdBox.YmdTextChange
        settingTimeLimitList()
    End Sub

    Private Sub topPicture_Click(sender As System.Object, e As System.EventArgs) Handles topPicture.Click
        Me.Close()
    End Sub

    Private Sub btnMonthlyPlan_Click(sender As System.Object, e As System.EventArgs) Handles btnMonthlyPlan.Click
        If IsNothing(monthlyPlanForm) OrElse monthlyPlanForm.IsDisposed Then
            monthlyPlanForm = New 月間予定表()
            monthlyPlanForm.Owner = Me
            monthlyPlanForm.Show()
        End If
    End Sub

    Private Sub btnMeal_Click(sender As System.Object, e As System.EventArgs) Handles btnMeal.Click
        If IsNothing(mealForm) OrElse mealForm.IsDisposed Then
            mealForm = New 食事伝票()
            mealForm.Owner = Me
            mealForm.Show()
        End If
    End Sub

    Private Sub btnKaigo_Click(sender As System.Object, e As System.EventArgs) Handles btnKaigo.Click
        If IsNothing(kaigoForm) OrElse kaigoForm.IsDisposed Then
            kaigoForm = New 介護度一覧()
            kaigoForm.Owner = Me
            kaigoForm.Show()
        End If
    End Sub

    Private Sub btnUserRegist_Click(sender As System.Object, e As System.EventArgs) Handles btnUserRegist.Click
        If IsNothing(userRegistForm) OrElse userRegistForm.IsDisposed Then
            userRegistForm = New 利用者登録()
            userRegistForm.Owner = Me
            userRegistForm.StartPosition = FormStartPosition.CenterScreen
            userRegistForm.Show()
        End If
    End Sub

End Class
