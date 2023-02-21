'Aaron Huerta Sigala'
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load 'funcion cuando carga el formulario
        TextBox1.Text = My.Settings.usuario                      'se cargan a los textBox (usuario y contraseña)
                                                                'los valores que quedaron guardados en la aplicacion al ser cerrada
        TextBox2.Text = My.Settings.contraseña

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click   'evento al hacer click en loguear (button1)
        If TextBox1.Text = "usuario" And TextBox2.Text = "Contraseña" Then             'verifica que por defualt contraseña y usuario son
                                                                                        'los valores de los textbox
            If CheckBox1.Checked = True Then                                            'checkbox es para guardar usuario
                My.Settings.usuario = TextBox1.Text                                 'se guarda en los settings el valor de textox
                                                                                    'si es que entro al if, y con reload, recarga los nuevos datos
                                                                                        'con la contraseña hace los mismos pasos
                My.Settings.Save()
                My.Settings.Reload()
            End If

            If CheckBox2.Checked = True Then                                        'checkbox es para guardar contraseña
                My.Settings.contraseña = TextBox2.Text
                My.Settings.Save()
                My.Settings.Reload()
            End If

            MsgBox("Logueo correcto")
        Else
            MsgBox("Logueo incorrecto")

        End If
    End Sub
    'boton de limpiar (button2), limpia los valores de settings y los textbox
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click     
        My.Settings.contraseña = ""
        My.Settings.usuario = ""
        TextBox1.Text = ""
        TextBox2.Text = ""
        My.Settings.Save()
        My.Settings.Reload()
    End Sub
    'evento hacia el cierre de la aplicacion, se cargan los textbox de usuario y contraseña a los settings para ser recuperados
    'al iniciar de nuevo la aplicacion
    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        My.Settings.usuario = TextBox1.Text
        My.Settings.contraseña = TextBox2.Text
        My.Settings.Save()
        My.Settings.Reload()
        Application.Exit()

    End Sub
    'evento del cierre (botton3) hace las mismas verificaciones que el evento de loguear (button1), pero en este caso usamos un else
    'para borrar los datos si no se marco la opcion de guarda dato de usuario o contrasaeña
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
            'si esta vacio , salimos sin guardar nada
            If TextBox1.Text = "" And TextBox2.Text = "" Then
                MsgBox("Exito al salir")
            Else
                'al ingresar un inicio de sesion incorrecto con usuario y contraseña que no son, no se guardaran los datos
                'aunque se selecciones las opciones de guardar
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
