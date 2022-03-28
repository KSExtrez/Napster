# Napster

## Extraccion de datos

Usando Python y Scrapy
```sh
$> cd src/Napster.Scrapy
$> scrapy runspider napster/spiders/music.py
```

## UI (Consola)
Construir el proyecto
```sh
$> dotnet build ./src/Napster.CLI
```

Ir a la carpeta `\bin\net6.0`
```sh
$> cd \bin\net6.0
```

Consulta de datos por medio de CLI en formato [`Entidad`] [`Filtro`]

### Consulta de generos y subgeneros
```sh
$> ./bin/napster-cli genre all
```

### Consulta de artistas por genero
```sh
$> ./bin/napster-cli artist genre_name
```

```sh
$> ./bin/napster-cli artist genre_id
```

### Consulta de albumes por artista

```sh
$> ./bin/napster-cli album artist_id
```

```sh
$> ./bin/napster-cli album artist_name
```

### Consulta de canciones por album

```sh
$> ./bin/napster-cli track album_id
```

```sh
$> ./bin/napster-cli track album_name
```

### Consulta de artista por cancion

```sh
$> ./bin/napster-cli artist track_id
```

```sh
$> ./bin/napster-cli artist track_name
```