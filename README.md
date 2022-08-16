# DemoWebService

Very crude service that implements a few endpoints. Tried to avoid using too many 
abstractions to make it easier to follow the code.

# Endpoints

## Create Value

```sh
curl http://localhost:5233/Samples -d '{"Value": "Created"}' -H "Content-Type: application/json"
```

## Show Value

```sh
curl http1//localhost:5233/Samples/1
```

## Show all values

```sh
curl http://localhost:5233/Samples/
```

