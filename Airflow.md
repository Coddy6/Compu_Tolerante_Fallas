---------------------------------------------------------------------------------------------------------
                                                          Aaron Huerta Sigala
---------------------------------------------------------------------------------------------------------

El DAG es el modelo central de Airflow que representa un flujo de trabajo recurrente.
Los operadores permiten la generación de ciertos tipos de tareas que se convierten en nodos en el DAG cuando se instancian. Todos los operadores se derivan BaseOperatory heredan muchos atributos y métodos de esa manera.
Nunca eh utilizado Airflow pero parece interesante aunque algo tedioso con el tema de windows y muchos temas mas. A decir verdad estas cosas que eh visto
en los trabajos, tareas y asi me resultan interesantes pero a la vez algo duros de manejar.


Se hace el uso de DAG para usar el airflow.
Se importan algunos modulos para su uso con funcciones de python, usamos days ago para saber caundo se tenia que haber ejecutado, logging para el logueo.
Se define un diccionario el cual se definen los parametros a utilizar.
Utilizaremos 3 funciones para el logeo de información, se hace un scrape descargando informacion despues procesarla yal final guardarla.


    from datetime import timedelta

    from airflow import DAG

    from airflow.operators.python import PythonOperator
    from airflow.utils.dates import days_ago

    import logging

    # You can override them on a per-task basis during operator initialization
    default_args = {
        'owner': 'airflow',
        'depends_on_past': False,
        'email': ['airflow@example.com'],
        'email_on_failure': False,
        'email_on_retry': False,
        'retries': 1,
        'retry_delay': timedelta(minutes=5),
    }

    def scrape():
        logging.info("performing scraping")

    def process():
        logging.info("performing processing")

    def save():
        logging.info("performing saving")

    with DAG(
        'first',
        default_args=default_args,
        description='A simple tutorial DAG',
        schedule_interval=timedelta(days=1),
        start_date=days_ago(2),
        tags=['example'],
    ) as dag:
        scrape_task = PythonOperator(task_id="scrape", python_callable=scrape)
        process_task = PythonOperator(task_id="process", python_callable=process)
        save_task = PythonOperator(task_id="save", python_callable=save)

        scrape_task >> process_task >> save_task
        

y con ello podemos crear los dags para obtenerlos dentro de airflow.

![image](https://user-images.githubusercontent.com/86500224/224862938-d35c8fb2-18f4-4a1c-871f-fbd97e69d996.png)

![image](https://user-images.githubusercontent.com/86500224/224863067-89c75188-6c41-4c71-886c-9a321503a45c.png)

![image](https://user-images.githubusercontent.com/86500224/224863135-5a725ebb-653d-404d-9f59-0f937974d0d7.png)

