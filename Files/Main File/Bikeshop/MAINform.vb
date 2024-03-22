Public Class MAINform
    Dim bd As New BUTTONdatamanagement
    Private Sub BunifuImageButton1_Click(sender As Object, e As EventArgs) Handles BunifuImageButton1.Click
        Me.Close()
    End Sub
    Private Sub MAINform_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HOME.MdiParent = Me
        HOME.Dock = DockStyle.Fill
        HOME.Show()
    End Sub

    Private Sub WAGES_Click(sender As Object, e As EventArgs) Handles WAGES.Click
        BUTTONdatamanagement.MdiParent = Me
        BUTTONdatamanagement.Dock = DockStyle.Fill
        BUTTONdatamanagement.Show()
        BUTTONdatamanagement.BringToFront()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        bd.MdiParent = Me
        bd.Dock = DockStyle.Fill
        bd.Show()
        bd.BringToFront()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs)
        CRUDprctBikeservice.MdiParent = Me
        CRUDprctBikeservice.Dock = DockStyle.Fill
        CRUDprctBikeservice.Show()
        CRUDprctBikeservice.BringToFront()
    End Sub

    Private Sub BunifuButton2_Click_1(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        BUTTONtransaction.MdiParent = Me
        BUTTONtransaction.Dock = DockStyle.Fill
        BUTTONtransaction.Show()
        BUTTONtransaction.BringToFront()
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        reportszz.MdiParent = Me
        reportszz.Dock = DockStyle.Fill
        reportszz.Show()
        reportszz.BringToFront()
    End Sub
End Class