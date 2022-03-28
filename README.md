# Napster

## UI (Consola)
Consulta de datos por medio de CLI en formato `Entidad` `Filtro'

### Consulta de generos y subgeneros
```sh
$> ./napster-cli genre all
```

### Consulta de artistas por genero
```sh
$> ./napster-cli artist genre_name
```

```sh
$> ./napster-cli artist genre_id
```

### Consulta de albumes por artista

```sh
$> ./napster-cli album artist_id
```

```sh
$> ./napster-cli album artist_name
```

### Consulta de canciones por album

```sh
$> ./napster-cli track album_id
```

```sh
$> ./napster-cli track album_name
```

### Consulta de artista por cancion

```sh
$> ./napster-cli artist track_id
```

```sh
$> ./napster-cli artist track_name
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