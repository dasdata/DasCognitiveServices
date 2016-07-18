<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.btnTakePic = New System.Windows.Forms.Button()
        Me.btnVideoFormat = New System.Windows.Forms.Button()
        Me.btnVideoSource = New System.Windows.Forms.Button()
        Me.imgVideo = New System.Windows.Forms.PictureBox()
        Me.lblDetectIt = New System.Windows.Forms.TextBox()
        Me.lblDistance = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.cbxDetectFace = New System.Windows.Forms.CheckBox()
        Me.txtInfo = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.imgVideo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnTakePic
        '
        Me.btnTakePic.Location = New System.Drawing.Point(108, 311)
        Me.btnTakePic.Name = "btnTakePic"
        Me.btnTakePic.Size = New System.Drawing.Size(75, 23)
        Me.btnTakePic.TabIndex = 0
        Me.btnTakePic.Text = "Detect"
        Me.btnTakePic.UseVisualStyleBackColor = True
        '
        'btnVideoFormat
        '
        Me.btnVideoFormat.Location = New System.Drawing.Point(267, 311)
        Me.btnVideoFormat.Name = "btnVideoFormat"
        Me.btnVideoFormat.Size = New System.Drawing.Size(32, 23)
        Me.btnVideoFormat.TabIndex = 2
        Me.btnVideoFormat.Text = "[-]"
        Me.btnVideoFormat.UseVisualStyleBackColor = True
        '
        'btnVideoSource
        '
        Me.btnVideoSource.Location = New System.Drawing.Point(305, 311)
        Me.btnVideoSource.Name = "btnVideoSource"
        Me.btnVideoSource.Size = New System.Drawing.Size(37, 23)
        Me.btnVideoSource.TabIndex = 3
        Me.btnVideoSource.Text = "[::]"
        Me.btnVideoSource.UseVisualStyleBackColor = True
        '
        'imgVideo
        '
        Me.imgVideo.Location = New System.Drawing.Point(27, 82)
        Me.imgVideo.Name = "imgVideo"
        Me.imgVideo.Size = New System.Drawing.Size(315, 224)
        Me.imgVideo.TabIndex = 4
        Me.imgVideo.TabStop = False
        '
        'lblDetectIt
        '
        Me.lblDetectIt.BackColor = System.Drawing.SystemColors.Menu
        Me.lblDetectIt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDetectIt.Location = New System.Drawing.Point(27, 377)
        Me.lblDetectIt.Multiline = True
        Me.lblDetectIt.Name = "lblDetectIt"
        Me.lblDetectIt.Size = New System.Drawing.Size(315, 53)
        Me.lblDetectIt.TabIndex = 5
        '
        'lblDistance
        '
        Me.lblDistance.AutoSize = True
        Me.lblDistance.Font = New System.Drawing.Font("Microsoft Sans Serif", 50.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDistance.Location = New System.Drawing.Point(26, 3)
        Me.lblDistance.Name = "lblDistance"
        Me.lblDistance.Size = New System.Drawing.Size(99, 76)
        Me.lblDistance.TabIndex = 6
        Me.lblDistance.Text = "---"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(27, 311)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 7
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'cbxDetectFace
        '
        Me.cbxDetectFace.AutoSize = True
        Me.cbxDetectFace.Location = New System.Drawing.Point(260, 59)
        Me.cbxDetectFace.Name = "cbxDetectFace"
        Me.cbxDetectFace.Size = New System.Drawing.Size(82, 17)
        Me.cbxDetectFace.TabIndex = 8
        Me.cbxDetectFace.Text = "Detect face"
        Me.cbxDetectFace.UseVisualStyleBackColor = True
        '
        'txtInfo
        '
        Me.txtInfo.BackColor = System.Drawing.SystemColors.Menu
        Me.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtInfo.Location = New System.Drawing.Point(27, 340)
        Me.txtInfo.Multiline = True
        Me.txtInfo.Name = "txtInfo"
        Me.txtInfo.Size = New System.Drawing.Size(315, 39)
        Me.txtInfo.TabIndex = 9
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(375, 82)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(781, 224)
        Me.DataGridView1.TabIndex = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1168, 442)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtInfo)
        Me.Controls.Add(Me.cbxDetectFace)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lblDistance)
        Me.Controls.Add(Me.lblDetectIt)
        Me.Controls.Add(Me.imgVideo)
        Me.Controls.Add(Me.btnVideoSource)
        Me.Controls.Add(Me.btnVideoFormat)
        Me.Controls.Add(Me.btnTakePic)
        Me.Name = "Form1"
        Me.Text = "AIFace"
        CType(Me.imgVideo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnTakePic As Button
    Friend WithEvents btnVideoFormat As Button
    Friend WithEvents btnVideoSource As Button
    Friend WithEvents imgVideo As PictureBox
    Friend WithEvents lblDetectIt As TextBox
    Friend WithEvents lblDistance As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cbxDetectFace As CheckBox
    Friend WithEvents txtInfo As TextBox
    Friend WithEvents DataGridView1 As DataGridView
End Class
