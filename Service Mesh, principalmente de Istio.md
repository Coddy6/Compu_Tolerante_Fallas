
                                   Centro Universitario de Ciencias Exactas e Ingenierías

                                                Depto. Ciencias computacionales

                                               Carrera: Ingeniería en Computación

                                             Materia: Computación tolerante a fallas

                                                         Sección: D06

                                              Profesor: Lopez Franco Michel Emanuel

                                                  Alumno: Huerta Sigala Aaron

                                                      Código: 220791152

                                           Tema: Service Mesh, principalmente de Istio

                                                        8/Mayo2023

Introducción

¿Que es Istio?

Istio es una plataforma de malla de servicios con tecnología de open source que permite controlar el intercambio de datos entre los microservicios. Incluye API que le permiten integrarse a cualquier plataforma de registro, telemetría o sistema de políticas. El diseño de esta plataforma facilita su ejecución en distintos entornos: on-premise, alojados en la nube, en contenedores de Kubernetes y en servicios que se ejecutan en máquinas virtuales, entre otros.

La arquitectura de Istio se divide en el plano de datos y el plano de control. En el plano de datos, el soporte de esta plataforma se agrega a un servicio mediante la implementación de un proxy de sidecar dentro de su entorno. Este proxy de sidecar se encuentra junto a un microservicio y envía las solicitudes desde y hacia otros proxies. En conjunto, dichos proxies forman una red que intercepta la comunicación de red entre los microservicios. El plano de control gestiona y configura los proxies para enrutar el tráfico. Este plano también configura los elementos para aplicar las políticas y recopilar datos de telemetría.

Las funciones de Istio le permiten ejecutar una arquitectura de microservicios distribuida. Estas son algunas de sus funciones:

Gestión del tráfico: el enrutamiento del tráfico y la configuración de las reglas en Istio le permiten controlar el flujo del tráfico y las llamadas a la API entre los servicios.

Seguridad: Istio proporciona el canal de comunicación subyacente y gestiona la autenticación, la autorización y el cifrado de la comunicación del servicio a escala. Con Istio, puede aplicar políticas de manera uniforme en distintos protocolos y tiempos de ejecución, sin tener que realizar grandes cambios en la aplicación. Los beneficios de usar Istio con políticas de red de Kubernetes (o de infraestructura) incluyen la capacidad para proteger la comunicación de pod a pod o de servicio a servicio en las capas de la aplicación y la red.

Capacidad de observación: obtenga información sobre la implementación de su malla de servicios con las funciones de registro, supervisión y seguimiento de Istio. La supervisión le permite ver cómo la actividad del servicio afecta al rendimiento upstream y downstream. Los paneles personalizados le permiten conocer el rendimiento de todos sus servicios.

![image](https://user-images.githubusercontent.com/86500224/236310434-3df7e60f-dbe9-4e2e-ba41-1d3d97aec0a4.png)

Provee métodos para configurar toda la flota de proxys que componen nuestra service mesh.

Tiene un control de enrutamiento y del balanceo de la carga.

Implementa por defecto observabilidad, es decir, que tenemos tanto el monitoreo como la trazabilidad de nuestros servicios ya integrado dentro de Istio por defecto.

Podemos hacer testing caótico.

Ofrece opciones de seguridad, ya que provee de una forma para poder comunicar servicio a servicio de forma segura. Además hace que la gestión de llaves, la automatización de la creación de llaves, la generación de certificados, la distribución de ellos mismos, la rotación, la revocación, etcétera, todas estas operaciones sean generadas automáticamente. De esta forma la comunicación entre dos servicios es segura a través de mutual TLS, sin que tengamos que configurar nada, ya que lo hace Istio de forma automatizada.

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

Me parecio interesante el funcionamiento de Istio, como es que maneja los contenedores y servicios para que funcionen y como estos transmiten información entre si con los servicios que se crean, aunque a mi no me quiso funcionar dicha aplicacion en mi computadora, por algo del puerto que queria usar, no encontre solución o una fomra de arreglar eso, al principio queria usarlo en windows con maquina virtual pero no funciono, luego quise hacerlo normal en windwos pero tampoco me funciono por el mismo problema hacia el puerto que abria para acceder hacia la red. Pero con el video que mire sobre el ejemplo, fue algo mas sencillo entenderlo como funciona a pesar de no poder realizarlo del todo.

Bibliografia

https://www.enmilocalfunciona.io/instalando-istio-con-docker-en-windows-10/

https://www.redhat.com/es/topics/microservices/what-is-istio

https://openwebinars.net/blog/que-es-istio/
