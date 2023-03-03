---------------------------------------------------------------------------------------------------------
                                                          Aaron Huerta Sigala
---------------------------------------------------------------------------------------------------------


Hilos usados con python
Se basa e la utilización de los subprocesos los cuales tienen el principal y los que siguen despues de ese, el cual se ejecutan uno despues del otro.
Se ejecuta ese hilo principal y despues se ejecuta el seguno hilo.

Este es un codigo sobre hilos.

    import threading

    def print_something(something):
        print(something)

    t = threading.Thread(target=print_something, args=("hello",))
    t.start()
    print("thread started")
    t.join()
    
![image](https://user-images.githubusercontent.com/86500224/222814687-f49e942f-2fa1-40ef-977d-76fe57b64c3d.png)


En este caso se imprime el primer subproceso que es el de thread started y despues empieza con el join() el segundo subproceso. Con esto obtenemos que el programa parecera bloqueado entonces unimos ese hilo con un demonio. Con ello obtendremos que cuando el programa finalice con el susbproceso principal terminara.

    import threading

    def print_something(something):
        print(something)

    t = threading.Thread(target=print_something, args=("hello",))
    t.daemon = True
    t.start()
    print("thread started")

![image](https://user-images.githubusercontent.com/86500224/222814874-b8747c1c-a29f-45c5-b1a0-3910d9a93c42.png)


Despues de ello tenemos los procesos, en lugar de hilos se pueden usar los procesos. El multiprocessingpaquete es una buena opción de alto nivel para los procesos. Proporciona una interfaz que inicia nuevos procesos. Cada proceso es una instancia nueva e independiente, por lo que cada proceso tiene su propio estado global independiente.

    import random
    import multiprocessing

    def compute(results):
        results.append(sum(
            [random.randint(1, 100) for i in range(1000000)]))

    if __name__ == "__main__":
        with multiprocessing.Manager() as manager:
            results = manager.list()
            workers = [multiprocessing.Process(target=compute, args=(results,))
                       for x in range(8)]
            for worker in workers:
                worker.start()
            for worker in workers:
                worker.join()
            print("Results: %s" % results)

![image](https://user-images.githubusercontent.com/86500224/222815747-1e011a5f-3eaa-44e8-b95d-520fa541feb3.png)

Cuando el trabajo se puede paralelizar durante un cierto período de tiempo, es mejor usar trabajos de bifurcación y multiprocesamiento. Esto distribuye la carga de trabajo entre varios núcleos de CPU.

    import multiprocessing
    import random

    def compute(n):
        return sum(
            [random.randint(1, 100) for i in range(1000000)])

    if __name__ == "__main__":
        # Start 8 workers
        pool = multiprocessing.Pool(processes=8)
        print("Results: %s" % pool.map(compute, range(8)))

Usamos una funcion de multiprocessing que utiliza Pool, asi nos hace mas facil todo el procesamiento mas sencillo.
En conjunto se pueden hacer procesos junto con daemons que hacen mas facil su implementacion. LLamandolos procesos de ejecucion prolongada.

Cotyledonutiliza varios subprocesos internamente. Es por eso que el threading.Eventobjeto se usa para sincronizar nuestra ejecución y terminatemétodos.

    import threading
    import time
    import cotyledon

    class PrinterService(cotyledon.Service):
        name = "printer"

        def __init__(self, worker_id):
            super(PrinterService, self).__init__(worker_id)
            self._shutdown = threading.Event()

        def run(self):
            while not self._shutdown.is_set():
                print("Doing stuff")
                time.sleep(1)

        def terminate(self):
            self._shutdown.set()

    # Create a manager
    manager = cotyledon.ServiceManager()
    # Add 2 PrinterService to run
    manager.add(PrinterService, 2)
    # Run all of that
    manager.run()

Cotyledonejecuta un proceso maestro que es responsable de manejar todos sus hijos. Luego inicia las dos instancias de PrinterServicey da nuevos nombres de proceso para que sean fáciles de rastrear. Con Cotyledon, si uno de los procesos falla, se reinicia automáticamente.






