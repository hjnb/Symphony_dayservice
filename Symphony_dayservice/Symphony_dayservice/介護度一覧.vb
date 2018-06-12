Imports System.Data.OleDb
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Interop
Imports Microsoft.Office.Core
Public Class 介護度一覧

    Private Sub 介護度一覧_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub 介護度一覧_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized

        Dim reader As System.Data.OleDb.OleDbDataReader
        Dim Cn As New OleDbConnection(TopForm.DB_dayservice)
        Dim SQLCm As OleDbCommand = Cn.CreateCommand
        SQLCm.CommandText = "select Nam from UsrM order by Kana"
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
            End If
        End If
    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick

    End Sub

    Private Sub lstName_TextChanged(sender As Object, e As System.EventArgs) Handles lstName.TextChanged
        
    End Sub

    Private Sub lstName_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstName.SelectedIndexChanged
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
            .Columns(5).Width = 250

            .Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        End With
    End Sub
End Class