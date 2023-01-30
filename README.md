
                                         Centro Universitario de Ciencias Exactas e Ingenierías

                                                  Depto. Ciencias computacionales

                                                 Carrera: Ingeniería en Computación

                                               Materia: Computación tolerante a fallas

                                                           Sección: D06

                                                Profesor: Lopez Franco Michel Emanuel

                                                    Alumno: Huerta Sigala Aaron

                                                        Código: 220791152

                                           Tema: Otras herramientas para el manejar errores.

                                                          30/Enero/2023
                                                          
                                                          
                                                  USO DE try, throw y catch en C++
                                                  
Para implementar el control de excepciones en C++, se usan las expresiones try, throw y catch.
                                                          
En primer lugar, se debe usar un bloque try para incluir una o más instrucciones que pueden iniciar una excepción.

Una expresión throw indica que se ha producido una condición excepcional, a menudo un error, en un bloque try. Se puede usar un objeto de cualquier tipo como operando de una expresión throw. Normalmente, este objeto se emplea para comunicar información sobre el error.

Para controlar las excepciones que se puedan producir, implemente uno o varios bloques catch inmediatamente después de un bloque try. Cada bloque catch especifica el tipo de excepción que puede controlar.


Ejemplo: Divisin entre dos numeros

Si se divide entre cero se tira el error de que la division es indefinida, ya que no se puede dividir entre cero. 


    #include <bits/stdc++.h>
    using namespace std;
    double divide(int a, int b) {
      if (b == 0) {
        throw "error: Division entre cero esta indefinida";
      }
      return (a/b);
    }
    int main() {
      int x = 8 , y=0;
      double res = 0;
      try {
        res = divide(x, y);
        cout << res << endl;
      }
      catch (const char* e) {
        cerr << e << endl;
      }
      return 0;
    }
    
Y nos muestra el siguiente mensaje de error.

    error: Division by zero is undefined                
Por lo tanto, de esta manera, podemos manejar excepciones desconocidas e imprimirlas.

Conclusión.

El uso de estas clausulas nos ayudan a diseñar mejor nuestros codigos tomando instrucciones e intentnado hacer dichas operaciones, manejando errores por si algo sale mal ademas de evitar errores. Y podamos arreglarlos despues.


Bibliografía

corob-msft, v.-k. n. (25 de Octubre de 2022). Microsoft. Recuperado el 30 de Enero de 2023, de Microsoft: https://learn.microsoft.com/es-es/cpp/cpp/try-throw-and-catch-statements-cpp?view=msvc-170

