<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblVinkel = New System.Windows.Forms.Label()
        Me.lblHastighet = New System.Windows.Forms.Label()
        Me.txtVinkel = New System.Windows.Forms.TextBox()
        Me.txtHastighet = New System.Windows.Forms.TextBox()
        Me.btnRita = New System.Windows.Forms.Button()
        Me.btnRensa = New System.Windows.Forms.Button()
        Me.picKurwa = New System.Windows.Forms.PictureBox()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.lblAntalTraffar = New System.Windows.Forms.Label()
        CType(Me.picKurwa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblVinkel
        '
        Me.lblVinkel.AutoSize = True
        Me.lblVinkel.Location = New System.Drawing.Point(12, 17)
        Me.lblVinkel.Name = "lblVinkel"
        Me.lblVinkel.Size = New System.Drawing.Size(59, 25)
        Me.lblVinkel.TabIndex = 0
        Me.lblVinkel.Text = "Vinkel"
        '
        'lblHastighet
        '
        Me.lblHastighet.AutoSize = True
        Me.lblHastighet.Location = New System.Drawing.Point(12, 54)
        Me.lblHastighet.Name = "lblHastighet"
        Me.lblHastighet.Size = New System.Drawing.Size(88, 25)
        Me.lblHastighet.TabIndex = 1
        Me.lblHastighet.Text = "Hastighet"
        '
        'txtVinkel
        '
        Me.txtVinkel.Location = New System.Drawing.Point(106, 14)
        Me.txtVinkel.Name = "txtVinkel"
        Me.txtVinkel.Size = New System.Drawing.Size(150, 31)
        Me.txtVinkel.TabIndex = 2
        '
        'txtHastighet
        '
        Me.txtHastighet.Location = New System.Drawing.Point(106, 51)
        Me.txtHastighet.Name = "txtHastighet"
        Me.txtHastighet.Size = New System.Drawing.Size(150, 31)
        Me.txtHastighet.TabIndex = 3
        '
        'btnRita
        '
        Me.btnRita.Location = New System.Drawing.Point(106, 88)
        Me.btnRita.Name = "btnRita"
        Me.btnRita.Size = New System.Drawing.Size(150, 34)
        Me.btnRita.TabIndex = 4
        Me.btnRita.Text = "Rita!"
        Me.btnRita.UseVisualStyleBackColor = True
        '
        'btnRensa
        '
        Me.btnRensa.Location = New System.Drawing.Point(106, 128)
        Me.btnRensa.Name = "btnRensa"
        Me.btnRensa.Size = New System.Drawing.Size(150, 34)
        Me.btnRensa.TabIndex = 5
        Me.btnRensa.Text = "Rensa!"
        Me.btnRensa.UseVisualStyleBackColor = True
        '
        'picKurwa
        '
        Me.picKurwa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picKurwa.BackColor = System.Drawing.Color.White
        Me.picKurwa.Location = New System.Drawing.Point(278, 12)
        Me.picKurwa.Name = "picKurwa"
        Me.picKurwa.Size = New System.Drawing.Size(496, 410)
        Me.picKurwa.TabIndex = 6
        Me.picKurwa.TabStop = False
        '
        'lbl1
        '
        Me.lbl1.AutoSize = True
        Me.lbl1.Location = New System.Drawing.Point(12, 178)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(111, 25)
        Me.lbl1.TabIndex = 7
        Me.lbl1.Text = "Antal Träffar:"
        '
        'lblAntalTraffar
        '
        Me.lblAntalTraffar.AutoSize = True
        Me.lblAntalTraffar.Location = New System.Drawing.Point(193, 178)
        Me.lblAntalTraffar.Name = "lblAntalTraffar"
        Me.lblAntalTraffar.Size = New System.Drawing.Size(36, 25)
        Me.lblAntalTraffar.TabIndex = 8
        Me.lblAntalTraffar.Text = "<>"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(786, 434)
        Me.Controls.Add(Me.lblAntalTraffar)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.picKurwa)
        Me.Controls.Add(Me.btnRensa)
        Me.Controls.Add(Me.btnRita)
        Me.Controls.Add(Me.txtHastighet)
        Me.Controls.Add(Me.txtVinkel)
        Me.Controls.Add(Me.lblHastighet)
        Me.Controls.Add(Me.lblVinkel)
        Me.MaximumSize = New System.Drawing.Size(1150, 600)
        Me.MinimumSize = New System.Drawing.Size(808, 490)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.picKurwa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblVinkel As Label
    Friend WithEvents lblHastighet As Label
    Friend WithEvents txtVinkel As TextBox
    Friend WithEvents txtHastighet As TextBox
    Friend WithEvents btnRita As Button
    Friend WithEvents btnRensa As Button
    Friend WithEvents picKurwa As PictureBox
    Friend WithEvents lbl1 As Label
    Friend WithEvents lblAntalTraffar As Label
End Class
