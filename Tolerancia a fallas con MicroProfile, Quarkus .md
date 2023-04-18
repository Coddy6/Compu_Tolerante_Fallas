
                                       Centro Universitario de Ciencias Exactas e Ingenierías

                                                    Depto. Ciencias computacionales

                                                   Carrera: Ingeniería en Computación

                                                 Materia: Computación tolerante a fallas

                                                             Sección: D06

                                                  Profesor: Lopez Franco Michel Emanuel

                                                      Alumno: Huerta Sigala Aaron

                                                          Código: 220791152

                                             Tema: Tolerancia a fallas con MicroProfile, Quarkus

                                                            17/Abril/2023
                                
                                
Introducción

MicroProfile es una excelente manera de crear pequeñas aplicaciones Java que se pueden implementar de forma rápida y sencilla en servicios como Azure Web App for Containers.
Los stack de Java tradicionales se diseñaron para aplicaciones monolíticas con largos tiempos de inicio y grandes requisitos de memoria en un mundo en el que no existían la nube, los contenedores ni Kubernetes. Los frameworks de Java debían evolucionar para satisfacer las necesidades de este nuevo mundo.

Quarkus fue creado para permitir a los desarrolladores de Java crear aplicaciones para un mundo moderno y nativo de la nube. Quarkus es un marco Java nativo de Kubernetes adaptado a GraalVM y HotSpot, elaborado a partir de las mejores bibliotecas y estándares Java. El objetivo es convertir a Java en la plataforma líder en Kubernetes y entornos sin servidor, al tiempo que ofrece a los desarrolladores un marco para abordar una gama más amplia de arquitecturas de aplicaciones distribuidas.


¿Que es Java EE?

Java Platform, Enterprise Edition (Java EE) se basa en la especificación Java SE. Representa una colaboración entre varios proveedores y líderes del sector y proporciona el soporte de la infraestructura para las aplicaciones.

En la infraestructura de Java EE, añada las reglas en dos niveles:
En la capa de la aplicación, para gestionar la lógica empresarial dinámica y el flujo de tareas.
En la capa de presentación, para personalizar el flujo de páginas y el flujo de trabajo y para construir páginas personalizadas basándose en el estado de la sesión.
Java EE es portable y escalable, y soporta la integración existente y los componentes basados en la arquitectura EJB. Java EE simplifica las aplicaciones empresariales definiendo y especificando un complejo conjunto de servicios estándar comunes, como denominación, gestión de transacciones, simultaneidad, seguridad y acceso a base de datos.

Java EE también define un modelo de contenedor, que aloja y gestiona instancias de componentes de aplicaciones Java EE. Los contenedores están a su vez alojados en servidores Java EE.

¿Que es Java SE?

Java Platform, Standard Edition (Java SE) es una especificación que describe una plataforma Java de resumen. Proporciona una base para crear y desplegar aplicaciones de negocio centradas en la red que van desde un ordenador de escritorio PC a un servidor de grupo de trabajo. Java SE lo implementa el kit de desarrollo de software (SDK) Java.

Rule Execution Server puede ejecutar conjuntos de reglas con código Java SE 100%. Muchos casos de uso existen para la ejecución pura de Java SE como, por ejemplo, la ejecución de lotes o la ejecución de reglas desde un proveedor Java Message Service (JMS) o un Enterprise Service Bus (ESB) no Java EE.

¿Que es Jakarta EE?

Jakarta EE es la nueva plataforma de Java Enterprise Edition o Java EE que como todos conocemos ha llegado hasta la versión 8. Hasta este momento todas las especificaciones han sido fuertemente lideradas por Oracle que es el que mantiene la propiedad de Java como lenguaje y por lo tanto de Java EE como extensión natural de este. Sin embargo cada día es más necesario que Java EE se dirija hacia el mundo Open Source de tal forma que los standards sean mas abiertos.

¿Que es MicroProfile?

MicroProfile es una excelente manera de crear pequeñas aplicaciones Java que se pueden implementar de forma rápida y sencilla en servicios como Azure Web App for Containers.
Los stack de Java tradicionales se diseñaron para aplicaciones monolíticas con largos tiempos de inicio y grandes requisitos de memoria en un mundo en el que no existían la nube, los contenedores ni Kubernetes. Los frameworks de Java debían evolucionar para satisfacer las necesidades de este nuevo mundo.

¿Que es Spring boot?

Spring Boot es un framework desarrollado para el trabajo con Java como lenguaje de programación. Se trata de un entorno de desarrollo de código abierto y gratuito. Spring Boot cuenta con una serie de características que han incrementado su popularidad y, en consecuencia, su uso por parte de los desarrolladores back-end. Spring Boot facilita la creación de todo tipo de aplicaciones basadas en él de manera independiente con el mínimo esfuerzo por parte de los desarrolladores. Y es que se trata de una tecnología que facilita que los desarrolladores se centren solo en la parte de programación, sin necesidad de preocuparse por aspectos como la arquitectura.

¿Que es Quarkus?

Quarkus fue creado para permitir a los desarrolladores de Java crear aplicaciones para un mundo moderno y nativo de la nube. Quarkus es un marco Java nativo de Kubernetes adaptado a GraalVM y HotSpot, elaborado a partir de las mejores bibliotecas y estándares Java. El objetivo es convertir a Java en la plataforma líder en Kubernetes y entornos sin servidor, al tiempo que ofrece a los desarrolladores un marco para abordar una gama más amplia de arquitecturas de aplicaciones distribuidas.

¿Que es Maven?

Maven es una herramienta de gestión de proyectos de desarrollo utilizada principalmente en el entorno de computación Java utilizando conceptos provenientes de Apache Ant.

Es muy utilizada en proyectos WSO2, es profundamente personalizable, permitiendo finalizar tareas complejas de forma rápida y reutilizando los resultados de ejecuciones pasadas.

La configuración de un proyecto se basa en un fichero XML en el cual se declaran los requerimientos para la construcción.

Maven añade principalmente las siguientes funcionalidades a Apache Ant:

Gestión de repositorios.

Gestión de dependencias.

Gestión del ciclo de vida.

El rendimiento de Maven es lento en comparación con Gradle

Los scripts de Maven son un poco largos en comparación con Gradle

Utiliza XML

En Maven se definen objetivos vinculados al proyecto

No admite compilaciones incrementales

Soporte en la mayoría de herramientas de Integración continua

¿Que es Gradle?

Gradle es una herramienta de automatización de compilación del código abierto, que obtuvo una rápida popularidad ya que fue diseñada fundamentalmente para construir multiproyectos, utilizando conceptos provenientes de Apache Maven.

Gradle mejora principalmente las siguientes funcionalidades de Maven:

Lenguaje

Gestión del ciclo de vida.

El tiempo de construcción de Gradle es corto y rápido

Los scripts de Gradle son mucho más cortos y limpios

Utiliza lenguaje específico de dominio (DSL)

Se basa en la tarea mediante la cual se realiza el trabajo

Admite compilaciones incrementales de la clase java

Soporte en la mayoría de herramientas de Integración continua

                                                        Codigo de ejemplo


Esto ayuda a la implementacion hacia la tolerancia a fallas, se utiliza quartus. Los cuales son patrones o reglas personalizadas
para cuando se cumpla alguna de esats que se considere fallo, se mandara al usuario a un camino alternativo para evitar el fallo.
Se hacen retrys para reintentar cualquier solicutud cada vez que se haga un fallo

Getting resource
              
              package com.asprans.controller;

              import javax.ws.rs.GET;
              import javax.ws.rs.Path;
              import javax.ws.rs.Produces;
              import javax.ws.rs.core.MediaType;

              @Path("/hello-resteasy")
              public class GreetingResource {

                  @GET
                  @Produces(MediaType.TEXT_PLAIN)
                  public String hello() {
                      return "Hello RESTEasy";
                  }
              }

Person cotroler

                package com.asprans.controller;

                import com.asprans.model.Person;
                import org.eclipse.microprofile.faulttolerance.*;

                import javax.ws.rs.GET;
                import javax.ws.rs.Path;
                import javax.ws.rs.Produces;
                import javax.ws.rs.core.MediaType;
                import java.util.ArrayList;
                import java.util.List;
                import java.util.Random;
                import java.util.logging.Logger;

                @Path("/persons")
                @Produces(MediaType.APPLICATION_JSON)
                public class PersonController {

                    List<Person> personList = new ArrayList<>();
                    Logger LOGGER = Logger.getLogger("Demologger");

                    @GET
                    //@Timeout(value = 5000L)
                    //@Retry(maxRetries = 4)
                    //@CircuitBreaker(failureRatio = 0.1, delay = 15000L)
                    //@Bulkhead(value = 0)
                    @Fallback(fallbackMethod = "getPersonFallbackList")
                    public List<Person> getPersonList(){
                        LOGGER.info("Ejecutando person list");
                        doFail();
                        //doWait();
                        return this.personList;
                    }

                    public List<Person> getPersonFallbackList(){
                        var person = new Person(-1L, "Asprans", "me.asprans.com");
                        return List.of(person);
                    }

                    public void doWait(){
                        var random = new Random();
                        try {
                            LOGGER.warning("Haciendo un sleep");
                            Thread.sleep((random.nextInt(10) + 4) * 1000L);
                        }catch (Exception ex){

                        }
                    }

                    public void doFail(){
                        var random = new Random();
                        if(random.nextBoolean()){
                            LOGGER.warning("Se produce una falla");
                            throw  new RuntimeException("Haciendo que la implementacion falle");
                        }
                    }
                }


Person

uso de una clase persona colocando sus getters y setters para obtener y retornar datos segun se requieran


              package com.asprans.model;

              public class Person {
                  private Long personId;
                  private String name;
                  private String email;

                  public Person(){

                  }

                  public Person(Long personId, String name, String email) {
                      this.personId = personId;
                      this.name = name;
                      this.email = email;
                  }

                  public Long getPersonId() {
                      return personId;
                  }

                  public void setPersonId(Long personId) {
                      this.personId = personId;
                  }

                  public String getName() {
                      return name;
                  }

                  public void setName(String name) {
                      this.name = name;
                  }

                  public String getEmail() {
                      return email;
                  }

                  public void setEmail(String email) {
                      this.email = email;
                  }
              }


Conclusión

El uso de esta herramienta es interesante en cierta foram como hace el uso de quartus y con el codigo visto en el video, como funciona este programa.
Con la tolerancia a fallos y si sucede alguno a donde es redirigido, segun los parametros que se implementan, y daemas de reintentar los envios 
de solicitudes si sucede algo para entrar en alguna funcion para que no haya error con caminos alternativos.







Bibliografia

https://es.quarkus.io/about/

https://learn.microsoft.com/es-es/azure/developer/java/eclipse-microprofile/deploy-microprofile-to-web-app-for-containers

https://www.ibm.com/docs/es/odm/8.5.1?topic=application-java-se-java-ee-applications

https://www.arquitecturajava.com/jakarta-ee/

https://www.tokioschool.com/noticias/spring-boot/

https://www.chakray.com/es/gradle-vs-maven-definiciones-diferencias/

https://www.youtube.com/watch?v=sTkolTRuPlE&t=2s




