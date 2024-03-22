Public Class reportszz
    Private Sub BunifuButton8_Click(sender As Object, e As EventArgs) Handles BunifuButton8.Click
        salesReport.MdiParent = MAINform
        salesReport.Dock = DockStyle.Fill
        salesReport.Show()
        salesReport.BringToFront()
    End Sub

    Private Sub BunifuButton9_Click(sender As Object, e As EventArgs) Handles BunifuButton9.Click
        oS.MdiParent = MAINform
        oS.Dock = DockStyle.Fill
        oS.Show()
        oS.BringToFront()
    End Sub

    Private Sub BunifuButton1_Click(sender As Object, e As EventArgs) Handles BunifuButton1.Click
        MechSalaryRpt.MdiParent = MAINform
        MechSalaryRpt.Dock = DockStyle.Fill
        MechSalaryRpt.Show()
        MechSalaryRpt.BringToFront()
    End Sub
End Class