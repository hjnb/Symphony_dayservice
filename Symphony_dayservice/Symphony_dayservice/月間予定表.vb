Imports System.Data.OleDb

Public Class 月間予定表

    Private Sub 月間予定表_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        '利用者リストの表示
        displayUserList()
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
End Class