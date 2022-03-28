# Napster

# UI (Consola)

## Aprovisionar Datos

```sh
$> ./napster-cli init
```

Aprovisionar desde una carga anterior
```sh
$> ./napster-cli database init load
```

# API

## Genres

|Descripcion|Url|Ejemplo|
|----------------|-------------------------------|-----------------------------|
|Generos y sub Generos|api/genres |https://localhost:44388/api/genres|
|Generos por Id|api/genres/{genreId}|https://localhost:44388/api/genres/g.115|
|Sub-generos por Id|api/genres/{genreId}/sub-genres|https://localhost:44388/api/genres/g.115/sub-genres|

## Artists

### Albums

### Tracks