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
        Me.ymBox = New ymdBox.ymdBox()
        Me.btnRegist = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnTextClear = New System.Windows.Forms.Button()
        Me.selectUserLabel = New System.Windows.Forms.Label()
        Me.dgvPlan = New Symphony_dayservice.ExDataGridView()
        CType(Me.dgvPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserListBox
        '
        Me.UserListBox.FormattingEnabled = True
        Me.UserListBox.ItemHeight = 12
        Me.UserListBox.Location = New System.Drawing.Point(7, 31)
        Me.UserListBox.Name = "UserListBox"
        Me.UserListBox.Size = New System.Drawing.Size(103, 544)
        Me.UserListBox.TabIndex = 1
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(118, 131)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(67, 349)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "追加>>"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'ymBox
        '
        Me.ymBox.boxType = 7
        Me.ymBox.DateText = ""
        Me.ymBox.EraLabelText = "H30"
        Me.ymBox.EraText = ""
        Me.ymBox.Location = New System.Drawing.Point(372, 6)
        Me.ymBox.MonthLabelText = "11"
        Me.ymBox.MonthText = ""
        Me.ymBox.Name = "ymBox"
        Me.ymBox.Size = New System.Drawing.Size(120, 46)
        Me.ymBox.TabIndex = 3
        '
        'btnRegist
        '
        Me.btnRegist.Location = New System.Drawing.Point(517, 9)
        Me.btnRegist.Name = "btnRegist"
        Me.btnRegist.Size = New System.Drawing.Size(75, 40)
        Me.btnRegist.TabIndex = 4
        Me.btnRegist.Text = "登　録"
        Me.btnRegist.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(674, 9)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 40)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "印　刷"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(596, 9)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 40)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "削　除"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnTextClear
        '
        Me.btnTextClear.Location = New System.Drawing.Point(1172, 26)
        Me.btnTextClear.Name = "btnTextClear"
        Me.btnTextClear.Size = New System.Drawing.Size(79, 23)
        Me.btnTextClear.TabIndex = 7
        Me.btnTextClear.Text = "テキストクリア"
        Me.btnTextClear.UseVisualStyleBackColor = True
        '
        'selectUserLabel
        '
        Me.selectUserLabel.AutoSize = True
        Me.selectUserLabel.Font = New System.Drawing.Font("MS UI Gothic", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.selectUserLabel.ForeColor = System.Drawing.Color.Blue
        Me.selectUserLabel.Location = New System.Drawing.Point(162, 17)
        Me.selectUserLabel.Name = "selectUserLabel"
        Me.selectUserLabel.Size = New System.Drawing.Size(0, 27)
        Me.selectUserLabel.TabIndex = 9
        '
        'dgvPlan
        '
        Me.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlan.Location = New System.Drawing.Point(196, 66)
        Me.dgvPlan.Name = "dgvPlan"
        Me.dgvPlan.RowTemplate.Height = 21
        Me.dgvPlan.Size = New System.Drawing.Size(1055, 791)
        Me.dgvPlan.TabIndex = 8
        '
        '月間予定表
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1431, 898)
        Me.Controls.Add(Me.selectUserLabel)
        Me.Controls.Add(Me.dgvPlan)
        Me.Controls.Add(Me.btnTextClear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.btnRegist)
        Me.Controls.Add(Me.ymBox)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.UserListBox)
        Me.Name = "月間予定表"
        Me.Text = "月間予定表"
        CType(Me.dgvPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UserListBox As System.Windows.Forms.ListBox
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ymBox As ymdBox.ymdBox
    Friend WithEvents btnRegist As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnTextClear As System.Windows.Forms.Button
    Friend WithEvents dgvPlan As Symphony_dayservice.ExDataGridView
    Friend WithEvents selectUserLabel As System.Windows.Forms.Label
End Class
