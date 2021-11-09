Public Class Form1
    Private Sub btnRita_Click(sender As Object, e As EventArgs) Handles btnRita.Click
        ' Definiering av variabler som behövs till o rita
        Dim x, y, hastighet, tid, vinkel As Single
        Dim punkt As System.Drawing.Graphics                   ' En punkt som ritas
        Dim penna As New System.Drawing.Pen(Brushes.Black, 4)  ' En penna som ritar

        'Hämta data
        hastighet = Val(txtHastighet.Text)
        vinkel = Val(txtVinkel.Text)
        punkt = picKurwa.CreateGraphics()

        Do
            'Öka tiden
            tid = tid + 0.25

            ' Beräkna aktuell position
            x = hastighet * Math.Cos(vinkel * Math.PI / 180) * tid
            y = picKurwa.Height - (hastighet * Math.Sin(vinkel * Math.PI / 180) * tid - 9.82 * tid * tid / 2)

            ' Rita ut punkten
            punkt.DrawEllipse(penna, x, y, 2, 2)


        Loop While x < picKurwa.Width And y > 0 And y < picKurwa.Height   ' Loopa medans punkten är inne i picbox
    End Sub

    Private Sub btnRensa_Click(sender As Object, e As EventArgs) Handles btnRensa.Click
        ' Rensa alla inmatningar samt pictureBox
        picKurwa.CreateGraphics.Clear(picKurwa.BackColor)
        txtHastighet.Text = ""
        txtVinkel.Text = ""
    End Sub

    Private Sub txtVinkel_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtVinkel.Validating
        ' Tillåt endast godkända värden och disabla rita om fel
        If (Val(txtVinkel.Text) > 90 Or Val(txtVinkel.Text) < 0) Then
            btnRita.Enabled = False
            txtVinkel.BackColor = Color.Pink
        Else
            btnRita.Enabled = True
            txtVinkel.BackColor = SystemColors.Window
        End If
    End Sub
End Class
