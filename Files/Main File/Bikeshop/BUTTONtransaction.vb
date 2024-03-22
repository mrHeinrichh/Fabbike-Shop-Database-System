Public Class BUTTONtransaction
    Private Sub BunifuButton8_Click(sender As Object, e As EventArgs) Handles BunifuButton8.Click
        TRANSACTIONcustomer.MdiParent = MAINform
        TRANSACTIONcustomer.Dock = DockStyle.Fill
        TRANSACTIONcustomer.Show()
        TRANSACTIONcustomer.BringToFront()
    End Sub

    Private Sub BunifuButton9_Click(sender As Object, e As EventArgs) Handles BunifuButton9.Click
        TRANSACTIONsupplier.MdiParent = MAINform
        TRANSACTIONsupplier.Dock = DockStyle.Fill
        TRANSACTIONsupplier.Show()
        TRANSACTIONsupplier.BringToFront()
    End Sub
End Class