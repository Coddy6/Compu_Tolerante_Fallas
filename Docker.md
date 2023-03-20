

Aqui podemos ver la aplicacion de escritorio de docker
![image](https://user-images.githubusercontent.com/86500224/226464479-3fb18028-7e44-4726-8996-a822daba4c5d.png)

En este ejemplo vamos a bajar una imagen del repositorio de docker
Primeramente para poder descargar una imagen, es necesario hacer un docker login

![image](https://user-images.githubusercontent.com/86500224/226465341-13422b08-c84d-4924-8574-9d3d566734ea.png)

Para descargar una imagen necesitamos utilizar el comando "pull" junto con la imagen a descargar que en este caso sera ubuntu

![image](https://user-images.githubusercontent.com/86500224/226465788-0545c51e-23b3-4130-8e32-82209e6d9f55.png)

Y podemos verificar que ya instalamos la imagen con el siguiente comando

![image](https://user-images.githubusercontent.com/86500224/226468463-f84ff2a2-61f9-42d3-b4aa-c969135b226b.png)

Despues de ello vamos anecesitar intanciar la imagen para despues usar el contendedor con el siguiente comando usando -it significa modo interactivo
levanta la terminal para poder ingresar a la terminal del contenedor. Esto siguiendo con la imagen y el comando siguiente /bin/bash, para entrar
directamente a la terminal del contenedor. Y podemos ejecutar como si fuera raiz tipo linux y ejecutamos el comando ls, la cual
nos muestra todo lo contenido en la carpeta.

![image](https://user-images.githubusercontent.com/86500224/226469916-5180fbc5-b6c6-4049-af82-41bc72a02b8a.png)

Abrimos otra terminar para listar los contendeores que esten o no en ejcucion con el siguiente comando.

![image](https://user-images.githubusercontent.com/86500224/226470244-16af7653-f8f2-4cbc-898e-f34da03c5855.png)

Y salimos de la terminal anterior, y si listamos de nuevo los contenedores nos mostrara que salimos.

![image](https://user-images.githubusercontent.com/86500224/226470416-b02519e4-18d8-4c65-888c-b3040df5918b.png)
![image](https://user-images.githubusercontent.com/86500224/226470473-1369f750-c640-45a3-bda3-a9214d64a494.png)

Para inicar de nuevo un contendeor que se encuentra pausado, usamos el siguiente comando junto con el id del contenedor,
no se ocupa ingresar todo. Ya una vez levantado, verificamos que lo esta ingresando a la terminal con exec con el id del contenedor, ingresa a la terminal
y si salimos de la terminal. Al verificar el contenedor seguira levantado.

![image](https://user-images.githubusercontent.com/86500224/226471267-a6fb78d7-5315-4a6c-9595-638fbe3b5c23.png)
![image](https://user-images.githubusercontent.com/86500224/226471430-4c987588-d5e9-49ca-97d2-5965ed6b8d4c.png)

Para detener la ejecucion del contenedor, utilizamos stop junto con el id del contendeor. Y comprobamos que esta en pausa

![image](https://user-images.githubusercontent.com/86500224/226471600-d91af280-faca-4f9b-b4f0-8f37dc2d31a9.png)
![image](https://user-images.githubusercontent.com/86500224/226471722-58e7def3-4f5b-4310-9bd7-7e792b7d82ad.png)

Tambien podemos eliminar el contendeor que no necesitemos. Y listamos la lista de contenedores.

![image](https://user-images.githubusercontent.com/86500224/226471919-c4c30161-cbaa-4e99-9be0-9f5a9fae55f7.png)
![image](https://user-images.githubusercontent.com/86500224/226472007-5e85d088-1ab7-4ce5-960f-e7ca3f37aaeb.png)

Y con ello tendriamos un ejemplo basico utilizando docker.


