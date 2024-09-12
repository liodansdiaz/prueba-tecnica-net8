# Prueba Técnica - .NET 8 y Docker

## Descripción

Este repositorio contiene una prueba técnica que involucra la creación de cuatro proyectos utilizando .NET 8 y Docker. Los proyectos incluyen:

1. **Kafka Producer**: Una aplicación que produce datos para un clúster de Kafka.
2. **Kafka Consumer**: Una aplicación que consume mensajes del clúster de Kafka.
3. **API Consumer**: Una aplicación de consola que consume una API externa y muestra la respuesta en la consola.
4. **Unit Tests**: Pruebas unitarias para la aplicación de consumo de API.

## Requisitos

Antes de ejecutar los proyectos, asegúrate de tener instalados los siguientes requisitos:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Configuración del Entorno

1. **Clonar el Repositorio**

   git clone https://github.com/liodansdiaz/prueba-tecnica-net8.git
   cd prueba-tecnica-net8
   
2. Configurar Docker

   Asegúrate de que Docker esté en funcionamiento y puedes comprobarlo ejecutando:

   docker --version
   docker-compose --version
   

3. Configuración de Docker Compose
    Ejecuta los siguientes comandos para construir y levantar los servicios definidos en docker-compose.yml:

   docker-compose up --build

  Esto levantará los contenedores para Kafka, Zookeeper y las aplicaciones de productor y consumidor.

 Ejecución de Aplicaciones
   
   1. Productor de Kafka   
      La aplicación de productor se ejecuta dentro de un contenedor Docker. Una vez que el contenedor esté en funcionamiento, empezará a producir mensajes al tópico de Kafka configurado.
   
   2. Consumidor de Kafka   
      Similar al productor, el consumidor también se ejecuta en un contenedor Docker y consumirá mensajes del tópico de Kafka.
   
   3. Consumidor de API   
      Puedes ejecutar esta aplicación de consola directamente desde la línea de comandos:
      
        dotnet KafkaConsumer.dll
      
      Asegúrate de que el archivo appsettings.json esté configurado correctamente con la URL de la API y los parámetros necesarios.
   
   5. Pruebas Unitarias   
       Las pruebas unitarias para la aplicación de consumo de API se encuentran en el proyecto KafkaConsumerTests. Puedes ejecutarlas con el siguiente comando:
      
        dotnet test
      
