---------------------------------------------------------------------------------------------------------
                                                          Aaron Huerta Sigala
---------------------------------------------------------------------------------------------------------


¿Qué es perfect?

Es una libreria de python que se usa para hacer ciertas caracteristicas dentro de un codigo de python, ratreara el estado y el resultado de cada tarea en
el flujo de trabajo y permitira que dependan unas de otras, en una variedad de formas.

Aqui podemos encontrar un codigo para hacer el uso de la libreria prefect. LO que hace es usar las abses de datos y abrir una pagina web para obtener
valores y que hagas colecciones segun los datos que se le piden.

    import requests
    import json
    from collections import namedtuple
    from contextlib import closing
    import sqlite3

    from prefect import task, Flow

    ## extract
    @task
    def get_complaint_data():
        r = requests.get("https://www.consumerfinance.gov/data-research/consumer-complaints/search/api/v1/", params={'size':10})
        response_json = json.loads(r.text)
        return response_json['hits']['hits']

    ## transform
    @task
    def parse_complaint_data(raw):
        complaints = []
        Complaint = namedtuple('Complaint', ['data_received', 'state', 'product', 'company', 'complaint_what_happened'])
        for row in raw:
            source = row.get('_source')
            this_complaint = Complaint(
                data_received=source.get('date_recieved'),
                state=source.get('state'),
                product=source.get('product'),
                company=source.get('company'),
                complaint_what_happened=source.get('complaint_what_happened')
            )
            complaints.append(this_complaint)
        return complaints

    ## load
    @task
    def store_complaints(parsed):
        create_script = 'CREATE TABLE IF NOT EXISTS complaint (timestamp TEXT, state TEXT, product TEXT, company TEXT, complaint_what_happened TEXT)'
        insert_cmd = "INSERT INTO complaint VALUES (?, ?, ?, ?, ?)"

        with closing(sqlite3.connect("cfpbcomplaints.db")) as conn:
            with closing(conn.cursor()) as cursor:
                cursor.executescript(create_script)
                cursor.executemany(insert_cmd, parsed)
                conn.commit()

    with Flow("my etl flow") as f:
        raw = get_complaint_data()
        parsed = parse_complaint_data(raw)
        store_complaints(parsed)

    f.run()
    

Conclusión.

Me parecio interesante el tema de el prefect y los usos que se le puede dar, ademas de que pude comprender lo que es el workflow manager. No soy experto
en lo que es el lenguaje de programación de python y se me complico en unas cosas, pero al final nunca me compilo ni me funciono el codigo.
Despues de verificar con mis compañeros de clase resulta que era una version antigua y esta que usa uno hoy en dia es mas actualizada. Por ello no pude
hacer que me funcionara el codigo y no entendi el funcionamiento del todo pero al menos aprendi algo.
Y gracias a mis compañeros que compartieron su información de como hacerlo entendi  mejor como funcionaba, pero de mi parte no logre compilarlo.

