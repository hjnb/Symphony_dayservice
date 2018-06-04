<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TopForm
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
        Me.btnMonthlyPlan = New System.Windows.Forms.Button()
        Me.btnKaigo = New System.Windows.Forms.Button()
        Me.btnMeal = New System.Windows.Forms.Button()
        Me.btnUserRegist = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.timeLimitYmdBox = New ymdBox.ymdBox()
        Me.timeLimitList = New System.Windows.Forms.ListBox()
        Me.rbtnPreview = New System.Windows.Forms.RadioButton()
        Me.rbtnPrint = New System.Windows.Forms.RadioButton()
        Me.topPicture = New System.Windows.Forms.PictureBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.topPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnMonthlyPlan
        '
        Me.btnMonthlyPlan.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMonthlyPlan.ForeColor = System.Drawing.Color.ForestGreen
        Me.btnMonthlyPlan.Location = New System.Drawing.Point(70, 70)
        Me.btnMonthlyPlan.Name = "btnMonthlyPlan"
        Me.btnMonthlyPlan.Size = New System.Drawing.Size(179, 98)
        Me.btnMonthlyPlan.TabIndex = 0
        Me.btnMonthlyPlan.Text = "月間予定表"
        Me.btnMonthlyPlan.UseVisualStyleBackColor = True
        '
        'btnKaigo
        '
        Me.btnKaigo.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnKaigo.ForeColor = System.Drawing.Color.Blue
        Me.btnKaigo.Location = New System.Drawing.Point(426, 70)
        Me.btnKaigo.Name = "btnKaigo"
        Me.btnKaigo.Size = New System.Drawing.Size(179, 98)
        Me.btnKaigo.TabIndex = 2
        Me.btnKaigo.Text = "介護度一覧"
        Me.btnKaigo.UseVisualStyleBackColor = True
        '
        'btnMeal
        '
        Me.btnMeal.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnMeal.ForeColor = System.Drawing.Color.DarkOrange
        Me.btnMeal.Location = New System.Drawing.Point(248, 70)
        Me.btnMeal.Name = "btnMeal"
        Me.btnMeal.Size = New System.Drawing.Size(179, 98)
        Me.btnMeal.TabIndex = 3
        Me.btnMeal.Text = "食事伝票"
        Me.btnMeal.UseVisualStyleBackColor = True
        '
        'btnUserRegist
        '
        Me.btnUserRegist.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.btnUserRegist.ForeColor = System.Drawing.Color.Red
        Me.btnUserRegist.Location = New System.Drawing.Point(426, 458)
        Me.btnUserRegist.Name = "btnUserRegist"
        Me.btnUserRegist.Size = New System.Drawing.Size(179, 98)
        Me.btnUserRegist.TabIndex = 6
        Me.btnUserRegist.Text = "利用者登録"
        Me.btnUserRegist.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.timeLimitYmdBox)
        Me.GroupBox1.Controls.Add(Me.timeLimitList)
        Me.GroupBox1.Location = New System.Drawing.Point(84, 360)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(165, 196)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "期限切れ近し!!"
        '
        'timeLimitYmdBox
        '
        Me.timeLimitYmdBox.boxType = 7
        Me.timeLimitYmdBox.DateText = ""
        Me.timeLimitYmdBox.EraLabelText = "H30"
        Me.timeLimitYmdBox.EraText = ""
        Me.timeLimitYmdBox.Location = New System.Drawing.Point(26, 15)
        Me.timeLimitYmdBox.MonthLabelText = "06"
        Me.timeLimitYmdBox.MonthText = ""
        Me.timeLimitYmdBox.Name = "timeLimitYmdBox"
        Me.timeLimitYmdBox.Size = New System.Drawing.Size(120, 46)
        Me.timeLimitYmdBox.TabIndex = 11
        '
        'timeLimitList
        '
        Me.timeLimitList.BackColor = System.Drawing.SystemColors.Control
        Me.timeLimitList.FormattingEnabled = True
        Me.timeLimitList.ItemHeight = 12
        Me.timeLimitList.Location = New System.Drawing.Point(13, 64)
        Me.timeLimitList.Name = "timeLimitList"
        Me.timeLimitList.Size = New System.Drawing.Size(141, 124)
        Me.timeLimitList.TabIndex = 0
        '
        'rbtnPreview
        '
        Me.rbtnPreview.AutoSize = True
        Me.rbtnPreview.Location = New System.Drawing.Point(635, 65)
        Me.rbtnPreview.Name = "rbtnPreview"
        Me.rbtnPreview.Size = New System.Drawing.Size(63, 16)
        Me.rbtnPreview.TabIndex = 8
        Me.rbtnPreview.TabStop = True
        Me.rbtnPreview.Text = "ﾌﾟﾚﾋﾞｭｰ"
        Me.rbtnPreview.UseVisualStyleBackColor = True
        '
        'rbtnPrint
        '
        Me.rbtnPrint.AutoSize = True
        Me.rbtnPrint.Location = New System.Drawing.Point(711, 65)
        Me.rbtnPrint.Name = "rbtnPrint"
        Me.rbtnPrint.Size = New System.Drawing.Size(47, 16)
        Me.rbtnPrint.TabIndex = 9
        Me.rbtnPrint.TabStop = True
        Me.rbtnPrint.Text = "印刷"
        Me.rbtnPrint.UseVisualStyleBackColor = True
        '
        'topPicture
        '
        Me.topPicture.Location = New System.Drawing.Point(635, 143)
        Me.topPicture.Name = "topPicture"
        Me.topPicture.Size = New System.Drawing.Size(174, 232)
        Me.topPicture.TabIndex = 10
        Me.topPicture.TabStop = False
        '
        'TopForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 646)
        Me.Controls.Add(Me.topPicture)
        Me.Controls.Add(Me.rbtnPrint)
        Me.Controls.Add(Me.rbtnPreview)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnUserRegist)
        Me.Controls.Add(Me.btnMeal)
        Me.Controls.Add(Me.btnKaigo)
        Me.Controls.Add(Me.btnMonthlyPlan)
        Me.Name = "TopForm"
        Me.Text = "デイサービス"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.topPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnMonthlyPlan As System.Windows.Forms.Button
    Friend WithEvents btnKaigo As System.Windows.Forms.Button
    Private WithEvents btnMeal As System.Windows.Forms.Button
    Friend WithEvents btnUserRegist As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents timeLimitList As System.Windows.Forms.ListBox
    Friend WithEvents rbtnPreview As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPrint As System.Windows.Forms.RadioButton
    Friend WithEvents topPicture As System.Windows.Forms.PictureBox
    Friend WithEvents timeLimitYmdBox As ymdBox.ymdBox

End Class
