                                   Centro Universitario de Ciencias Exactas e Ingenierías

                                                Depto. Ciencias computacionales

                                               Carrera: Ingeniería en Computación

                                             Materia: Computación tolerante a fallas

                                                         Sección: D06

                                              Profesor: Lopez Franco Michel Emanuel

                                                  Alumno: Huerta Sigala Aaron

                                                      Código: 220791152

                                                     Tema: Cheeky monkey

                                                        23/Mayo/2023
                                                       
                                                       
Introducción

Es una herramienta muy usada para los servidores de produccion de grandes empresas. Se conecta a los kubernetes para matar pods para eliminar un proceso.


Con el comando en kubernetes de vim constants.py, se accede a la configuración del cheeky monkey.

![image](https://github.com/Coddy6/Compu_Tolerante_Fallas/assets/86500224/941dcbbe-1354-4bc2-a88b-7a3178b28405)

Aqui podremos ver lo que contiene en minicube, se tienen 5 namespace, y tambien podemos ver los pods que se encuentran y locus se usa para hacer la carga a servidores.

![image](https://github.com/Coddy6/Compu_Tolerante_Fallas/assets/86500224/111df15e-912b-4fa2-9e5e-7e9189d69b89)

Asi se ve la aplicacion de locus y hostea al servicio que estes queriendo usar.

![image](https://github.com/Coddy6/Compu_Tolerante_Fallas/assets/86500224/5d20d456-71a7-4668-a6d1-02dec6469483)

Podemos ver cuales pods se estan muriendo al golpear las cajas del cheeky monkey y cuantos abia creado al inicio.

![image](https://github.com/Coddy6/Compu_Tolerante_Fallas/assets/86500224/e7d4bf1f-c899-4100-99de-f3b915bdfc94)

LA INGENIERÍA DEL CAOS ES: "la disciplina de experimentar en un sistema distribuido para generar confianza en la capacidad del sistema para soportar condiciones turbulentas en la producción".

![image](https://github.com/Coddy6/Compu_Tolerante_Fallas/assets/86500224/24cf13d7-b3d7-4ceb-a5ac-eb955ffc9533)

Este juego es más para fines de diversión y demostración que para ser una herramienta genuina de ingeniería del caos. Dicho esto, es posible que con el tiempo agregue otras características disruptivas más allá de simplemente matar pods. ¡Siéntase libre de abrir un "problema" con cualquier sugerencia!

Los pods de Kubernetes están representados por cajas en el juego. ¡Cuantas más vainas tengas, más cajas caerán!

Controlas al mono con las flechas del teclado y golpeas las cajas con la barra espaciadora. También puedes mantener presionada la tecla 'G' para agarrar una caja a tu derecha y arrastrarla.

Cada vez que el mono destruye una caja, se selecciona y elimina aleatoriamente una cápsula de tu grupo.

Conclusion

Esta forma en la que se utiliza kubernetes para hacer el servicio para hostearlo y que vayan llegano clientes a tal servicio es interesante, ademas de que al utilizar el cheeky monkey el como destruir los pods que tenemos y como con locus no hay perdidas porque cada que se desstruye se vuelve a contruir sin errores. Seguira recibiendo datos hacia el servidor sin perder nada. Ademas de que cheeky monkey es de utilidad ya que nos ayuda a visualizar mejor si va funcionando bien nuestro programa que utiliza algun servidor.

Bibliografia

https://www.youtube.com/watch?v=y4gSbi9VsYY

https://github.com/richstokes/cheekymonkey



