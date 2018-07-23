<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 介護度一覧
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
        Me.lstName = New System.Windows.Forms.ListBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.YmdBox1 = New ymdBox.ymdBox()
        Me.YmdBox2 = New ymdBox.ymdBox()
        Me.cmbKaigodo = New System.Windows.Forms.ComboBox()
        Me.txtBikou = New System.Windows.Forms.TextBox()
        Me.chkRiyou = New System.Windows.Forms.CheckBox()
        Me.btnTouroku = New System.Windows.Forms.Button()
        Me.btnSakujo = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btnKuria = New System.Windows.Forms.Button()
        Me.btnKousinn = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstName
        '
        Me.lstName.FormattingEnabled = True
        Me.lstName.ItemHeight = 12
        Me.lstName.Location = New System.Drawing.Point(26, 16)
        Me.lstName.Name = "lstName"
        Me.lstName.Size = New System.Drawing.Size(135, 556)
        Me.lstName.TabIndex = 0
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("MS UI Gothic", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblName.ForeColor = System.Drawing.Color.Blue
        Me.lblName.Location = New System.Drawing.Point(190, 25)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(71, 29)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "氏名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(221, 91)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "有効期限"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(221, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "介護度"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(221, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "備　考"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(221, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 12)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "利　用"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(415, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 12)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "～"
        '
        'YmdBox1
        '
        Me.YmdBox1.boxType = 2
        Me.YmdBox1.DateText = ""
        Me.YmdBox1.EraLabelText = "H30"
        Me.YmdBox1.EraText = ""
        Me.YmdBox1.Location = New System.Drawing.Point(292, 80)
        Me.YmdBox1.MonthLabelText = "07"
        Me.YmdBox1.MonthText = ""
        Me.YmdBox1.Name = "YmdBox1"
        Me.YmdBox1.Size = New System.Drawing.Size(110, 34)
        Me.YmdBox1.TabIndex = 7
        '
        'YmdBox2
        '
        Me.YmdBox2.boxType = 2
        Me.YmdBox2.DateText = ""
        Me.YmdBox2.EraLabelText = "H30"
        Me.YmdBox2.EraText = ""
        Me.YmdBox2.Location = New System.Drawing.Point(442, 80)
        Me.YmdBox2.MonthLabelText = "07"
        Me.YmdBox2.MonthText = ""
        Me.YmdBox2.Name = "YmdBox2"
        Me.YmdBox2.Size = New System.Drawing.Size(110, 34)
        Me.YmdBox2.TabIndex = 8
        '
        'cmbKaigodo
        '
        Me.cmbKaigodo.FormattingEnabled = True
        Me.cmbKaigodo.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.cmbKaigodo.Items.AddRange(New Object() {"要支援 １", "要支援 ２", "ーーーーーー", "要介護 １", "要介護 ２", "要介護 ３", "要介護 ４", "要介護 ５", "（暫定中）"})
        Me.cmbKaigodo.Location = New System.Drawing.Point(292, 117)
        Me.cmbKaigodo.Name = "cmbKaigodo"
        Me.cmbKaigodo.Size = New System.Drawing.Size(92, 20)
        Me.cmbKaigodo.TabIndex = 9
        '
        'txtBikou
        '
        Me.txtBikou.ImeMode = System.Windows.Forms.ImeMode.Hiragana
        Me.txtBikou.Location = New System.Drawing.Point(290, 148)
        Me.txtBikou.Name = "txtBikou"
        Me.txtBikou.Size = New System.Drawing.Size(262, 19)
        Me.txtBikou.TabIndex = 10
        '
        'chkRiyou
        '
        Me.chkRiyou.AutoSize = True
        Me.chkRiyou.Location = New System.Drawing.Point(290, 180)
        Me.chkRiyou.Name = "chkRiyou"
        Me.chkRiyou.Size = New System.Drawing.Size(84, 16)
        Me.chkRiyou.TabIndex = 11
        Me.chkRiyou.Text = "利用中（★）"
        Me.chkRiyou.UseVisualStyleBackColor = True
        '
        'btnTouroku
        '
        Me.btnTouroku.Location = New System.Drawing.Point(415, 22)
        Me.btnTouroku.Name = "btnTouroku"
        Me.btnTouroku.Size = New System.Drawing.Size(69, 28)
        Me.btnTouroku.TabIndex = 12
        Me.btnTouroku.Text = "登録"
        Me.btnTouroku.UseVisualStyleBackColor = True
        '
        'btnSakujo
        '
        Me.btnSakujo.Location = New System.Drawing.Point(524, 22)
        Me.btnSakujo.Name = "btnSakujo"
        Me.btnSakujo.Size = New System.Drawing.Size(69, 28)
        Me.btnSakujo.TabIndex = 13
        Me.btnSakujo.Text = "削除"
        Me.btnSakujo.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(214, 226)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 21
        Me.DataGridView1.Size = New System.Drawing.Size(561, 331)
        Me.DataGridView1.TabIndex = 14
        '
        'btnKuria
        '
        Me.btnKuria.Location = New System.Drawing.Point(474, 31)
        Me.btnKuria.Name = "btnKuria"
        Me.btnKuria.Size = New System.Drawing.Size(10, 10)
        Me.btnKuria.TabIndex = 15
        Me.btnKuria.Text = "クリア"
        Me.btnKuria.UseVisualStyleBackColor = True
        '
        'btnKousinn
        '
        Me.btnKousinn.Location = New System.Drawing.Point(462, 31)
        Me.btnKousinn.Name = "btnKousinn"
        Me.btnKousinn.Size = New System.Drawing.Size(10, 10)
        Me.btnKousinn.TabIndex = 16
        Me.btnKousinn.Text = "更新"
        Me.btnKousinn.UseVisualStyleBackColor = True
        '
        '介護度一覧
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(811, 589)
        Me.Controls.Add(Me.btnTouroku)
        Me.Controls.Add(Me.btnKousinn)
        Me.Controls.Add(Me.btnKuria)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnSakujo)
        Me.Controls.Add(Me.chkRiyou)
        Me.Controls.Add(Me.txtBikou)
        Me.Controls.Add(Me.cmbKaigodo)
        Me.Controls.Add(Me.YmdBox2)
        Me.Controls.Add(Me.YmdBox1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.lstName)
        Me.Name = "介護度一覧"
        Me.Text = "介護度一覧"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lstName As System.Windows.Forms.ListBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents YmdBox1 As ymdBox.ymdBox
    Friend WithEvents YmdBox2 As ymdBox.ymdBox
    Friend WithEvents cmbKaigodo As System.Windows.Forms.ComboBox
    Friend WithEvents txtBikou As System.Windows.Forms.TextBox
    Friend WithEvents chkRiyou As System.Windows.Forms.CheckBox
    Friend WithEvents btnTouroku As System.Windows.Forms.Button
    Friend WithEvents btnSakujo As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btnKuria As System.Windows.Forms.Button
    Friend WithEvents btnKousinn As System.Windows.Forms.Button
End Class
