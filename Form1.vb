Public Class Form1

    'Globala variabler
    Dim xMal, yMal As Single
    Dim antalTraffar As Integer
    Private Sub btnRita_Click(sender As Object, e As EventArgs) Handles btnRita.Click

        ' Definiering av variabler som behövs till o rita
        Dim x, y, hastighet, tid, vinkel As Single
        Dim punkt As System.Drawing.Graphics                   ' En punkt som ritas
        Dim penna As New System.Drawing.Pen(Brushes.Black, 4)  ' En penna som ritar

        'Hämta och sätt data
        hastighet = Val(txtHastighet.Text)
        vinkel = Val(txtVinkel.Text)
        punkt = picKurwa.CreateGraphics()

        Do
            'Öka tiden
            tid = tid + 1 / hastighet ' Justerar mellanrum mellan prickar

            ' Beräkna aktuell position
            x = hastighet * Math.Cos(vinkel * Math.PI / 180) * tid
            y = picKurwa.Height - (hastighet * Math.Sin(vinkel * Math.PI / 180) * tid - 9.82 * tid * tid / 2)

            ' Rita ut punkten
            punkt.DrawEllipse(penna, x, y, 2, 2)

            ' Kolla om träff av mål
            If Traff(x, y) Then
                Exit Do

            End If

        Loop While x < picKurwa.Width And y > 0 And y < picKurwa.Height   ' Loopa medans punkten är inne i picbox
    End Sub

    Private Sub btnRensa_Click(sender As Object, e As EventArgs) Handles btnRensa.Click

        ' Rensa alla inmatningar samt pictureBox
        picKurwa.CreateGraphics.Clear(picKurwa.BackColor)
        txtHastighet.Text = ""
        txtVinkel.Text = ""
        NyttMal()
        RitaMal(xMal, yMal)
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

    Private Sub RitaMal(xMal As Single, yMal As Single)

        ' Definiera variabler för mål
        Dim punkt As System.Drawing.Graphics
        Dim penna As New System.Drawing.Pen(Brushes.Red, 4)

        ' Rita ut målet
        punkt = picKurwa.CreateGraphics
        punkt.DrawEllipse(penna, xMal, yMal, 10, 10)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Skriv ut antalet träffar och ge nya kordinater för mål
        lblAntalTraffar.Text = antalTraffar
        NyttMal()
    End Sub

    Private Sub Form1_Paint(sender As Object, e As EventArgs) Handles Me.Paint
        ' Rita mål vid laddning
        RitaMal(xMal, yMal)
    End Sub

    Private Function Traff(x As Single, y As Single) As Boolean

        ' Kolla om samma x, y kordinater som målet
        If Math.Abs(x + 5 - xMal) < 10 And Math.Abs(y + 5 - yMal) < 10 Then
            ' Öka antalet träffar
            antalTraffar += 1
            lblAntalTraffar.Text = antalTraffar
            ' Rensa rutan och rita nytt mål
            btnRensa.PerformClick()
            ' Returnera att det var en träff
            Return True
        End If

        ' Returnera miss
        Return False

    End Function

    Private Function NyttMal()
        ' Hitta kordinater för mål
        xMal = picKurwa.Width * Rnd()
        yMal = picKurwa.Height * Rnd()
        Return True
    End Function
End Class
