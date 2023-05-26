<?php

$dbhost = "localhost";
$dbuser = "root";
$dbpass = "";
$dbname = "test";

$conn = mysqli_connect($dbhost, $dbuser, $dbpass, $dbname);
if (!$conn)
{
    die("No hay conexion: ".mysqli_connect_error());
}
$nombre = $_POST["txtusuario"];
$pass = $_POST["txtpassword"];

$query = mysqli_query($conn,"SELECT * FROM login WHERE Usuario = '".$nombre."' and password = '".$pass."'");
$nr = mysqli_num_rows($query);

if ($nr == 1)
{
    //header("Location: pagina.html")
    echo "Bienvendio" .$nombre;
    header(header: 'location: http://localhost/pagina/usuario_login.html');

}
else if ($nr == 0)
{
    echo "No Registrado o contraseña y usuario incorrectos :("; 
}

?>