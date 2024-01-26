# Biblioteca RecentFilesHistory
Esta biblioteca facilita el acceso fácil y eficiente a archivos en aplicaciones de escritorio, reflejando características populares como "Historial de archivos", "Últimos archivos abiertos" y "Archivos recientes" de editores y aplicaciones de diseño destacados.

## Ejemplo de Uso
![Historial de archivos recientes](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/demo-window-history-of-recently-opened-closed-or-saved-files.png)

## Diagrama de Clases UML
![Diagrama de Clases UML](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/uml-class-diagramm-of-recent-files-history.png)

## Cómo Funciona
La biblioteca incluye la clase abstracta genérica `RecentlyFilesHistoryManager<T>`, que gestiona elementos en la colección `ObservableCollection<T> Items` utilizando una política de caché LRU (Menos Recientemente Utilizado).

Para agregar un archivo al historial, simplemente utiliza el método `PutAtFront(item)`. Si el elemento ya existe en la colección, se moverá a la primera posición (considerado el más reciente).

Para usar esta biblioteca, implementa la clase abstracta genérica especificando el tipo de datos para el tipo genérico. Luego, implementa los métodos `Load()` y `Save()` para gestionar el historial de archivos abiertos, guardados y cerrados recientemente.

## Proyecto de Demostración
Puedes explorar el proyecto de demostración, que muestra cómo utilizar la biblioteca para gestionar rutas de archivos (cadenas).