
                                   Centro Universitario de Ciencias Exactas e Ingenierías

                                                Depto. Ciencias computacionales

                                               Carrera: Ingeniería en Computación

                                             Materia: Computación tolerante a fallas

                                                         Sección: D06

                                              Profesor: Lopez Franco Michel Emanuel

                                                  Alumno: Huerta Sigala Aaron

                                                      Código: 220791152

                                                      Tema: Kubernetes

                                                        24/Abril/2023

Introducción

¿Qué es Kubernetes?

Kubernetes es una plataforma portable y extensible de código abierto para administrar cargas de trabajo y servicios. Kubernetes facilita la automatización y la configuración declarativa. Tiene un ecosistema grande y en rápido crecimiento. El soporte, las herramientas y los servicios para Kubernetes están ampliamente disponibles. Kubernetes ofrece un entorno de administración centrado en contenedores. Kubernetes orquesta la infraestructura de cómputo, redes y almacenamiento para que las cargas de trabajo de los usuarios no tengan que hacerlo. Esto ofrece la simplicidad de las Plataformas como Servicio (PaaS) con la flexibilidad de la Infraestructura como Servicio (IaaS) y permite la portabilidad entre proveedores de infraestructura.

¿Qué es Ingress?

Ingress es un servicio que equilibra cargas de trabajo de tráfico de red en el clúster reenviando solicitudes públicas o privadas a sus apps. Puede utilizar Ingress para exponer varios servicios de app a la red privada o pública mediante un único dominio privado o público.

En el clúster, el controlador de Ingress de Red Hat OpenShift es un equilibrador de carga de capa 7 que implementa un controlador de Ingress de HAProxy. Un servicio de LoadBalancer de capa 4 expone el controlador de Ingress, para que el controlador de Ingress pueda recibir las solicitudes externas que entran en el clúster. A continuación, el controlador de Ingress reenvía las solicitudes a los pods de aplicación en el clúster basándose en las distintas características de protocolo de la capa 7 como, por ejemplo, las cabeceras.

Clúster de una sola zona

En el siguiente diagrama se muestra cómo Ingress dirige la comunicación procedente de internet a una app en un clúster clásico de una sola zona.

![image](https://user-images.githubusercontent.com/86500224/233797427-50ae47c5-8eb8-46b4-9042-011d7fc0ac44.png)


¿Qué es un LoadBalancer?

El balance de carga (load Balance) se refiere a la distribución del tráfico de red entrante a través de un grupo de servidores backend, también conocido como Server Farm (conjunto de servidor) o Server Pool (conjunto de servidores).
Los sitios web modernos de alto tráfico deben atender a cientos de miles (algunos hasta millones)  de solicitudes concurrentes de usuarios o clientes y devolver los textos, imágenes, videos o datos de aplicaciones correspondientes, todo de manera rápida y confiable. Para lograrlo de forma rentable y cumplir con estos altos volúmenes, la mejor práctica de informática moderna generalmente requiere agregar más servidores. El balance de carga actúa como el “Oficial de tránsito” frente a sus servidores y enruta las solicitudes de los clientes en todos los servidores para satisfacer esas solicitudes de manera que maximice la velocidad y la capacidad para poder garantizar que ningún servidor esté sobrecargado, ya que la saturación podría afectar el rendimiento . Si un único servidor falla, el balanceador de carga redirige el tráfico a los servidores en línea restantes. Cuando se agrega un nuevo servidor al grupo de servidores, el balanceador de carga comienza a integrarlo y automáticamente a enviarle solicitudes.
De esta manera, un Load Balance realiza las siguientes funciones:

Distribuye las solicitudes de los clientes o la carga de la red de manera eficiente en varios servidores

Asegura alta disponibilidad y confiabilidad al enviar solicitudes solo a servidores que están en línea

Proporciona la flexibilidad de agregar o restar servidores según la demanda

.
.

                            Implementacion de una aplicación Resilient Go en Kubernetes en DigitalOcean

Main.go

Importamos las bibliotecas de entrada y salida de texto y la de servidor y cliente de HTTP.
'Responsewriter' y request, el primero construye la respuesta mientras que el segundo representa una solicitud entrante. 'Setuproutes' asignara las solicitudes entrantes a sus funciones de controlador http. LLamando al homepage para que imprime el texto escrito "My awesome Go App".
La funcion main es el inicio de la aplicacion y hara las funciones dichas.

          package main

          import (
            "fmt"
            "net/http"
          )

          func homePage(w http.ResponseWriter, r *http.Request) {
            fmt.Fprintf(w, "My Awesome Go App")
          }

          func setupRoutes() {
            http.HandleFunc("/", homePage)
          }

          func main() {
            fmt.Println("Go Web App Started on Port 3000")
            setupRoutes()
            http.ListenAndServe(":3000", nil)
          }


Dockerfile

Especificamos la imagen a utilizar, luego el contenedor y despues el directorio.
La siguiente linea nos dice donde se ejecutaran los comandos y el siguiente ejecutara el main.

          FROM golang:1.12.0-alpine3.9
          RUN mkdir /app
          ADD . /app
          WORKDIR /app
          RUN go build -o main .
          CMD ["/app/main"]


deployment.yml

Aqui usamos el kubernets lo cual usaremos el deployment, definiremos el metadata.
De ahi creamos el spec el cual es necesario para cada objeto de kubernetes.
Luego el selector que se usara como un selector de etiquetas para sus pods, y le pondremos el nombre correspondiente a la etiqueta.
Despues colocamos template el cual usara las etiquetas para su desarrollo.
Y al final el spec, diferenciado al otro spec ya que este usara los template creados con las etiquetas.


          apiVersion: apps/v1
          kind: Deployment
          metadata:
            name: go-web-app
          spec:
            replicas: 5
            selector:
              matchLabels:
                name: go-web-app
            template:
              metadata:
                labels:
                  name: go-web-app
              spec:
                containers:
                - name: application
                  image: sammy/go-web-app
                  imagePullPolicy: IfNotPresent
                  ports:
                    - containerPort: 3000


service.yml
          
Creamos un servicio, la version de la api 1, le pondremos nombre al metadata.
Luego el spec que daremos el tipo de servicio y despues los puertos que usara y al final el selector que  mandara a llamar el archivo dicho.

          apiVersion: v1
          kind: Service
          metadata:
            name: go-web-service
          spec:
            type: LoadBalancer
            ports:
            - name: http
              port: 80
              targetPort: 3000
            selector:
              name: go-web-app


![image](https://user-images.githubusercontent.com/86500224/233797987-e1759e55-161a-4fa8-9e0a-5e5a2a3d174d.png)



Conclusión

La creación de la aplicacion Go y luego colocarla en el contenedor Docker e implementarlo con kubernetes fue algo tedioso y complicacdo al no tener las experiencias necesarias para trabajar con este. El video ayudo de cierta forma pero aun asi es complicado configurar las aplicaciones y que funcionen concretamente como uno desea. Pero fue algo simple aun asi es interesante como es que funcionan todas estas aplicaciones.

Bibliografia

https://kubernetes.io/es/docs/concepts/overview/what-is-kubernetes/

https://cloud.ibm.com/docs/openshift?topic=openshift-ingress-about-roks4&locale=es#:~:text=Ingress%20es%20un%20servicio%20que,único%20dominio%20privado%20o%20público.

https://quanti.com.mx/articulos/que-es-load-balance-o-balance-de-carga/





