







Descargue las versiones de istio para windows usando la 1.17.2, ya que se usa mas para linux. Lo intente usar en una maquina virtual pero no finciono.

![image](https://user-images.githubusercontent.com/86500224/235370340-52e878c8-c489-4ed8-98c4-21d096724d1d.png)

Abro powershell y verificar que se usa como variable de entorno, y cual version es.

![image](https://user-images.githubusercontent.com/86500224/235370686-2c087aad-3dbd-4ae7-85f6-691b1f6557e8.png)

Intente instalar istio de forma con el powershell, pero no me funciono. Al parecer me bloquea el puerto de entrada hacia el html del localhost, no deja entrar.
Busque información pero no encontre como hacer para que pueda entrar a usar el localhsot en ese puerto.

Voy a explicar como funciona un codigo de ejemplo que sale en youtube para aprender y ver su funcionamiento. Se instalan los componentes de istio y se crea la biblioteca.

![image](https://user-images.githubusercontent.com/86500224/235372798-abddcf90-8eac-4e38-bd64-0221c0d251a4.png)

Para crear la bliblioteca propia se usa el comando del nombre que le quieras poner y propiedad enable.

![image](https://user-images.githubusercontent.com/86500224/235372833-7a082462-347f-45ca-aa70-89238a82741a.png)

Dentro de ello se tiene la aplicacion helloapp, es solo un deployment el cual usa el puerto 8080

![image](https://user-images.githubusercontent.com/86500224/235372861-f6a26ee2-4ce3-45fd-8b18-9ef50e6db18b.png)
![image](https://user-images.githubusercontent.com/86500224/235372917-921e6414-21d6-43ed-9488-4b08bc96d1a2.png)

Se aplican los manifiestos, con las version 2, se inicializan los conetnedores, se utilizxan dos contenedores en cada pods

![image](https://user-images.githubusercontent.com/86500224/235372963-ae834d1e-6fc9-4209-b34a-50daedeff816.png)

Luego con el siguiente comando miramos que hace el pods, el cual contiene un init container, redirecciona el trafico de ese pod para que primero pase por un proxy

![image](https://user-images.githubusercontent.com/86500224/235372998-46289287-03e2-445c-8bea-80a62b981dbe.png)
![image](https://user-images.githubusercontent.com/86500224/235373034-9cdb18f9-204c-462e-a14b-6b7f2bcc2f16.png)

Luego tenemos el contenedor hello, el cual se creo en el manifiesto, se crea en el contenedor dentro del pod.

![image](https://user-images.githubusercontent.com/86500224/235373053-ff9b49ef-8b75-4387-8581-92c55ff2a0a6.png)

Como se puede observar con el istioctl se entra a una pagina web llamada kiali la cual nos muestra los contenedores y los servicios, los triangulos son los servicios y los cuadrados son los contenedores

![image](https://user-images.githubusercontent.com/86500224/235374008-f5d52e19-dd18-40eb-bc39-8218c274492f.png)

A uno de los pods empezamos a mandar trafico cada 1 segundo, del contenedor v2 al servicio v1.

![image](https://user-images.githubusercontent.com/86500224/235374072-f1cb9aa3-e51b-4860-929e-674b330755d3.png)
![image](https://user-images.githubusercontent.com/86500224/235374092-6aa7abf0-0ca1-4715-ae61-d3605e9c3723.png)






Conclusión


Bibliografia

https://www.enmilocalfunciona.io/instalando-istio-con-docker-en-windows-10/
