Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = My.Settings.usuario
        TextBox2.Text = My.Settings.contraseña

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "usuario" And TextBox2.Text = "Contraseña" Then
            If CheckBox1.Checked = True Then
                My.Settings.usuario = TextBox1.Text
                My.Settings.Save()
                My.Settings.Reload()
            End If

            If CheckBox2.Checked = True Then
                My.Settings.contraseña = TextBox2.Text
                My.Settings.Save()
                My.Settings.Reload()
            End If

            MsgBox("Logueo correcto")
        Else
            MsgBox("Logueo incorrecto")

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Settings.contraseña = ""
        My.Settings.usuario = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        My.Settings.Save()
        My.Settings.Reload()
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        My.Settings.usuario = TextBox1.Text
        My.Settings.contraseña = TextBox2.Text
        My.Settings.Save()
        My.Settings.Reload()
        Application.Exit()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If TextBox1.Text = "usuario" And TextBox2.Text = "Contraseña" Then
            If CheckBox1.Checked = True Then
                My.Settings.usuario = TextBox1.Text
                My.Settings.Save()
                My.Settings.Reload()
            Else
                My.Settings.usuario = ""
                TextBox1.Text = ""
                My.Settings.Save()
                My.Settings.Reload()
            End If

            If CheckBox2.Checked = True Then
                My.Settings.contraseña = TextBox2.Text
                My.Settings.Save()
                My.Settings.Reload()
            Else
                My.Settings.contraseña = ""
                TextBox2.Text = ""
                My.Settings.Save()
                My.Settings.Reload()
            End If
        Else
            If TextBox1.Text = "" And TextBox2.Text = "" Then
                MsgBox("Exito al salir")
            Else
                MsgBox("Datos incorrectos/no se guardaran")
                My.Settings.contraseña = ""
                My.Settings.usuario = ""
                TextBox1.Text = ""
                TextBox2.Text = ""
                My.Settings.Save()
                My.Settings.Reload()
            End If
        End If
        Application.Exit()
    End Sub
End Class
