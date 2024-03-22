Public Class BUTTONdatamanagement
    'start
    Private Sub BunifuButton18_Click(sender As Object, e As EventArgs) Handles BunifuButton18.Click
        'products
        CRUDproducts.MdiParent = MAINform
        CRUDproducts.Dock = DockStyle.Fill
        CRUDproducts.Show()
        CRUDproducts.BringToFront()
    End Sub

    Private Sub BunifuButton17_Click(sender As Object, e As EventArgs) Handles BunifuButton17.Click
        CRUDcustomer.MdiParent = MAINform
        CRUDcustomer.Dock = DockStyle.Fill
        CRUDcustomer.Show()
        CRUDcustomer.BringToFront()
    End Sub

    Private Sub BunifuButton7_Click(sender As Object, e As EventArgs) Handles BunifuButton7.Click
        CRUDaccessories.MdiParent = MAINform
        CRUDaccessories.Dock = DockStyle.Fill
        CRUDaccessories.Show()
        CRUDaccessories.BringToFront()
    End Sub

    Private Sub BunifuButton6_Click_1(sender As Object, e As EventArgs) Handles BunifuButton6.Click
        'Bike services
        CRUDbikeservices.MdiParent = MAINform
        CRUDbikeservices.Dock = DockStyle.Fill
        CRUDbikeservices.Show()
        CRUDbikeservices.BringToFront()
    End Sub

    Private Sub BunifuButton5_Click(sender As Object, e As EventArgs) Handles BunifuButton5.Click
        CRUDmechanics.MdiParent = MAINform
        CRUDmechanics.Dock = DockStyle.Fill
        CRUDmechanics.Show()
        CRUDmechanics.BringToFront()
    End Sub

    Private Sub BunifuButton4_Click(sender As Object, e As EventArgs) Handles BunifuButton4.Click
        CRUDsupplier.MdiParent = MAINform
        CRUDsupplier.Dock = DockStyle.Fill
        CRUDsupplier.Show()
        CRUDsupplier.BringToFront()
    End Sub

    Private Sub BunifuButton11_Click(sender As Object, e As EventArgs) Handles BunifuButton11.Click
        CRUDwages.MdiParent = MAINform
        CRUDwages.Dock = DockStyle.Fill
        CRUDwages.Show()
        CRUDwages.BringToFront()
    End Sub

    Private Sub BunifuButton3_Click(sender As Object, e As EventArgs) Handles BunifuButton3.Click
        'Brand
        CRUDbrands.MdiParent = MAINform
        CRUDbrands.Dock = DockStyle.Fill
        CRUDbrands.Show()
        CRUDbrands.BringToFront()
    End Sub

    Private Sub BunifuButton2_Click(sender As Object, e As EventArgs) Handles BunifuButton2.Click
        'Operating Expenses
        CRUDoperationsexp.MdiParent = MAINform
        CRUDoperationsexp.Dock = DockStyle.Fill
        CRUDoperationsexp.Show()
        CRUDoperationsexp.BringToFront()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        'Percentage per service
        CRUDprctBikeservice.MdiParent = MAINform
        CRUDprctBikeservice.Dock = DockStyle.Fill
        CRUDprctBikeservice.Show()
        CRUDprctBikeservice.BringToFront()
    End Sub

    Private Sub BunifuButton8_Click(sender As Object, e As EventArgs) Handles BunifuButton8.Click
        CRUDbikeserviceRecord.MdiParent = MAINform
        CRUDbikeserviceRecord.Dock = DockStyle.Fill
        CRUDbikeserviceRecord.Show()
        CRUDbikeserviceRecord.BringToFront()
    End Sub

    Private Sub BunifuButton9_Click(sender As Object, e As EventArgs) Handles BunifuButton9.Click
        CRUDpurchrec.MdiParent = MAINform
        CRUDpurchrec.Dock = DockStyle.Fill
        CRUDpurchrec.Show()
        CRUDpurchrec.BringToFront()
    End Sub

    Private Sub BunifuButton10_Click(sender As Object, e As EventArgs) Handles BunifuButton10.Click
        CRUDsuppRecs.MdiParent = MAINform
        CRUDsuppRecs.Dock = DockStyle.Fill
        CRUDsuppRecs.Show()
        CRUDsuppRecs.BringToFront()
    End Sub

    Private Sub BUTTONdatamanagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class