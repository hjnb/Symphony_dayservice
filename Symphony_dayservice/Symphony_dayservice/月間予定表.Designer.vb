<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 月間予定表
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UserListBox = New System.Windows.Forms.ListBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'UserListBox
        '
        Me.UserListBox.FormattingEnabled = True
        Me.UserListBox.ItemHeight = 12
        Me.UserListBox.Location = New System.Drawing.Point(12, 31)
        Me.UserListBox.Name = "UserListBox"
        Me.UserListBox.Size = New System.Drawing.Size(129, 544)
        Me.UserListBox.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(161, 131)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 349)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "追加>>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        '月間予定表
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1024, 642)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.UserListBox)
        Me.Name = "月間予定表"
        Me.Text = "月間予定表"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents UserListBox As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
