---------------------------------------------------------------------------------------------------------
                                                          Aaron Huerta Sigala
---------------------------------------------------------------------------------------------------------


Hacer la primer función conseguimos evitar el error para que no haya colapso, la aplicación manda informacion y se cierra.
En la segunda función lo que hace es verificar si tiene o no el target un .exe si no, se lo agrega.
La tercera funcion lo que hace es cerrar el proceso que se este ejecutando en ese momento del argumento que se haya mandado anteriormente, cada vez que se abra se cerrara.
El main, solo sirve para entrar a las funciones y que siga funcionando y validando segun lo necesario

    import sys
    import psutil


    def check_arguments():
        if len(sys.argv) == 1:
          print('Este programa no funciona sin argumentos')
            sys.exit(0)

    def get_targets():

        targets = sys.argv[1:]

        i = 0
        while i < len(targets):

          if not targets[i].endswith('.exe'):
            targets[i] = targets[i] + '.exe'
            i += 1

        return targets

    def lock(target):
        for proc in psutil.process_iter():
          if proc.name().lower() == target.lower():
            proc.kill()


    if __name__ == '__main__':

        check_arguments()
        targets = get_targets()

        while True:
          for target in targets:
            lock(target)

Tenemos nuestro archivo .py junto con el nssm para crear un servicio

![image](https://user-images.githubusercontent.com/86500224/220229213-492f8ec1-02e3-4d70-b33e-e8bebf57306b.png)

Vamos a la carpeta y ejecutamos la aplicacion, nos abrira el siguiente formulario para crear el servicio.

![image](https://user-images.githubusercontent.com/86500224/220229515-3fc520eb-40c6-432f-8100-0169a8838e66.png)

![image](https://user-images.githubusercontent.com/86500224/220229548-3d694f5d-9e0b-4aa2-98ac-081eb54e1029.png)

Indicamos donde se encuentra nuestro ejecutable de .py, en donde se encuentra nuestro archivo .py que creamos con el codigo y en los argumentos colocamos nuestro archivo creado con las aplicaciones que se cerraran.

![image](https://user-images.githubusercontent.com/86500224/220229973-fbde9872-fd86-4038-a53e-0d77256e31f7.png)

Le daremos a instalar y nos mandara el mensaje de instalado

![image](https://user-images.githubusercontent.com/86500224/220230210-a8dcb247-be4b-411a-a0c4-63c629dcea9d.png)

Utilizamos el siguiente comando para inciar el servicio, diciendonos que fue exitoso.

![image](https://user-images.githubusercontent.com/86500224/220230375-36836229-926a-44f7-b374-e4733fdc6b89.png)

![image](https://user-images.githubusercontent.com/86500224/220230464-7196212e-1d22-4192-a0a4-4a42d5d65769.png)

Y como se puede observar esta abierto el servicio.

![image](https://user-images.githubusercontent.com/86500224/220230585-f4c05bc7-61f9-4f67-ab8b-d44124534c25.png)

Lo detenemos usando el siguiente comando.

![image](https://user-images.githubusercontent.com/86500224/220230699-75bf5adc-e698-46fd-a1e8-4db7049cb701.png)


Asi concluye esta practica, lo mas interesante es que cuando se inicie dicha aplicacion o programa, este se cierre al instante segun el servicio que usemos y validaciones que hagamos. Si el servicio esta encendido y se inicia al iniciar la pc este evitara el despliegue de la aplicación que quieras abrir que hayas puesto como argumento.

