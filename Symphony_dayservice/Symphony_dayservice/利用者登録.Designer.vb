<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 利用者登録
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkHyouji = New System.Windows.Forms.CheckBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtKana = New System.Windows.Forms.TextBox()
        Me.btnTouroku = New System.Windows.Forms.Button()
        Me.btnSakujo = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnKousinn = New System.Windows.Forms.Button()
        Me.lblAutono = New System.Windows.Forms.Label()
        Me.btnKuria = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "入居者名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ｶﾅ"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "表示"
        '
        'chkHyouji
        '
        Me.chkHyouji.AutoSize = True
        Me.chkHyouji.Location = New System.Drawing.Point(92, 82)
        Me.chkHyouji.Name = "chkHyouji"
        Me.chkHyouji.Size = New System.Drawing.Size(67, 16)
        Me.chkHyouji.TabIndex = 3
        Me.chkHyouji.Text = "表示する"
        Me.chkHyouji.UseVisualStyleBackColor = True
        '
        'txtName
        '
        Me.txtName.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtName.Location = New System.Drawing.Point(92, 15)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(107, 19)
        Me.txtName.TabIndex = 4
        '
        'txtKana
        '
        Me.txtKana.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf
        Me.txtKana.Location = New System.Drawing.Point(92, 40)
        Me.txtKana.Name = "txtKana"
        Me.txtKana.Size = New System.Drawing.Size(107, 19)
        Me.txtKana.TabIndex = 5
        '
        'btnTouroku
        '
        Me.btnTouroku.Location = New System.Drawing.Point(239, 10)
        Me.btnTouroku.Name = "btnTouroku"
        Me.btnTouroku.Size = New System.Drawing.Size(63, 34)
        Me.btnTouroku.TabIndex = 6
        Me.btnTouroku.Text = "登録"
        Me.btnTouroku.UseVisualStyleBackColor = True
        '
        'btnSakujo
        '
        Me.btnSakujo.Location = New System.Drawing.Point(239, 44)
        Me.btnSakujo.Name = "btnSakujo"
        Me.btnSakujo.Size = New System.Drawing.Size(63, 34)
        Me.btnSakujo.TabIndex = 7
        Me.btnSakujo.Text = "削除"
        Me.btnSakujo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(19, 113)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(313, 336)
        Me.DataGridView1.TabIndex = 8
        '
        'btnKousinn
        '
        Me.btnKousinn.Location = New System.Drawing.Point(259, 16)
        Me.btnKousinn.Name = "btnKousinn"
        Me.btnKousinn.Size = New System.Drawing.Size(10, 10)
        Me.btnKousinn.TabIndex = 9
        Me.btnKousinn.Text = "更新"
        Me.btnKousinn.UseVisualStyleBackColor = True
        '
        'lblAutono
        '
        Me.lblAutono.AutoSize = True
        Me.lblAutono.Location = New System.Drawing.Point(12, 9)
        Me.lblAutono.Name = "lblAutono"
        Me.lblAutono.Size = New System.Drawing.Size(11, 12)
        Me.lblAutono.TabIndex = 10
        Me.lblAutono.Text = "0"
        Me.lblAutono.Visible = False
        '
        'btnKuria
        '
        Me.btnKuria.Location = New System.Drawing.Point(249, 16)
        Me.btnKuria.Name = "btnKuria"
        Me.btnKuria.Size = New System.Drawing.Size(10, 10)
        Me.btnKuria.TabIndex = 11
        Me.btnKuria.Text = "クリア"
        Me.btnKuria.UseVisualStyleBackColor = True
        '
        '利用者登録
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(355, 461)
        Me.Controls.Add(Me.btnTouroku)
        Me.Controls.Add(Me.btnKuria)
        Me.Controls.Add(Me.lblAutono)
        Me.Controls.Add(Me.btnKousinn)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSakujo)
        Me.Controls.Add(Me.txtKana)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.chkHyouji)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "利用者登録"
        Me.Text = "利用者登録"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkHyouji As System.Windows.Forms.CheckBox
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtKana As System.Windows.Forms.TextBox
    Friend WithEvents btnTouroku As System.Windows.Forms.Button
    Friend WithEvents btnSakujo As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnKousinn As System.Windows.Forms.Button
    Friend WithEvents lblAutono As System.Windows.Forms.Label
    Friend WithEvents btnKuria As System.Windows.Forms.Button
End Class
