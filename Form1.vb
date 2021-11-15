Public Class Form1

    'Globala variabler
    Dim xMal, yMal As Single    ' Målets position
    Dim antalTraffar As Integer ' Antalet träffar
    Dim startTid As Long        ' Start tid

    Private Sub BtnBorja_Click(sender As Object, e As EventArgs) Handles btnBorja.Click

        ' Tillåt skjut knapp och inte börja knapp

        btnBorja.Enabled = False

        ' Nollställ antal träffar
        antalTraffar = 0
        lblAntalTraffar.Text = antalTraffar
        picKurwa.Enabled = True
        RitaMal(xMal, yMal)
        ' Starta timer
        Timer.Start()

        ' Sätt start tid
        startTid = Now.Ticks

    End Sub
    Private Sub skjut()

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

    Private Sub txtVinkel_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles txtVinkel.Validating

        'Om börja knapp är enabled kan vi kolla validering
        If Timer.Enabled = True Then

            ' Tillåt endast godkända värden och disabla rita om fel
            If (Val(txtVinkel.Text) > 90 Or Val(txtVinkel.Text) < 0) Then

                txtVinkel.BackColor = Color.Pink
            Else

                txtVinkel.BackColor = SystemColors.Window
            End If
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

        'Skriv ut antalet träffar och ge nya kordinater för mål, se till att rita knapp är disabled
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
            Rensa()

            ' Returnera att det var en träff
            Return True
        End If

        ' Returnera miss
        Return False
    End Function

    Private Sub NyttMal()

        ' Skapa kordinater för nytt mål
        xMal = (picKurwa.Width - 100) * Rnd() + 50
        yMal = (picKurwa.Height - 100) * Rnd() + 50
    End Sub

    Private Sub Rensa()

        ' Rensa alla inmatningar samt pictureBox, skapa nytt mål och rita målet
        picKurwa.CreateGraphics.Clear(picKurwa.BackColor)
        txtHastighet.Text = ""
        txtVinkel.Text = ""
        NyttMal()
        RitaMal(xMal, yMal)
    End Sub

    Private Sub picKurwa_MouseMove(sender As Object, e As MouseEventArgs) Handles picKurwa.MouseMove

        ' Variabler för mus position och ritfunktioner
        Dim linje As System.Drawing.Graphics                                                    ' Skapa linje
        Dim penna As New System.Drawing.Pen(Brushes.Green, 2)                                   ' Skapa penna
        Dim sudd As New System.Drawing.Pen(picKurwa.BackColor, 2)                               ' Skapa sudd
        Static x, y As Single                                                                   ' Kom ihåg linjens position

        ' Gör om musposition till position i picturebox
        If e.Button = MouseButtons.Left Then                                                    ' Om vänster musknapp trycks ner
            linje = picKurwa.CreateGraphics
            linje.DrawLine(sudd, x, y, 0, picKurwa.Height)                                      ' Sudda gammal linje
            x = e.X                                                                             ' Hämta mus X pos
            y = e.Y                                                                             ' Hämta mus Y pos
            txtHastighet.Text = Math.Round(Math.Sqrt(x * x + (picKurwa.Height - y) ^ 2), 0)     ' Skriv ut hastigheten i txtbox
            txtVinkel.Text = Math.Round(Math.Atan((picKurwa.Height - y) / x) * 180 / Math.PI, 1) ' Skriv ut vinkeln i txtbox
            linje.DrawLine(penna, x, y, 0, picKurwa.Height)                                     ' Rita ny linje
            RitaMal(xMal, yMal)                                                                 ' Rita målet på nytt
        End If
    End Sub

    Private Sub picKurwa_MouseUp(sender As Object, e As MouseEventArgs) Handles picKurwa.MouseUp
        If e.Button = MouseButtons.Left Then
            skjut()
        End If

    End Sub

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick

        ' Varibaler för tid kvar på timer
        Dim tidPaserad As Long = Now.Ticks - startTid
        Dim tidKvar As New TimeSpan(tidPaserad)

        'Skriv ut tid kvar
        lblTid.Text = 60 - tidKvar.TotalSeconds

        If tidKvar.TotalSeconds > 60 Then
            ' Nolla tidstexten
            lblTid.Text = 0
            ' Enabla börja knappen, disabla skjut knapp
            btnBorja.Enabled = True

            ' Stoppa timer
            Timer.Stop()
            ' Inaktivera picturebox
            picKurwa.Enabled = False
        End If
    End Sub
End Class
