# README #

## Ocelot-aggregator
This is POC for microservice with api gateway using ocelot

### How to run? ###

* Run all projects as parallel.

* from api gateway project, send GET request in browser
* GET Product- /product
* GET Payment- /payment
* To get aggregate response from product and payment, use endpoint /agg.




## RabbitMqMassTransitDemo
### How to run? ###
* Install and run docker image of rabbit mq.

```docker run --rm -it --hostname my-rabbit -p 15672:15672 -p 5672:5672 rabbitmq:3-management```

* Open management window from browser as http://localhost:15672/
* login with username as 'guest' and password as 'guest'
* run producer.api and consumer api as parallel
* produce a messge by posting order api as ```https://localhost:44392/api/order```
* check the logs of consumer service.

