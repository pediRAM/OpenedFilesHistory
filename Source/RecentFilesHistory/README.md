![logo](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/icon.png)

[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Release](https://img.shields.io/github/release/pediRAM/RecentFilesHistory.svg?sort=semver)](https://github.com/pediRAM/RecentFilesHistory/releases)
[![NuGet](https://img.shields.io/nuget/v/RecentFilesHistory)](https://www.nuget.org/packages/RecentFilesHistory)

This is the english documentation. Following translations are available:
- [普通话 (Mandarin) :cn:](https://github.com/pediRAM/RecentFilesHistory/blob/main/Documentation/Mandarin.md)
- [Español :es:](https://github.com/pediRAM/RecentFilesHistory/blob/main/Documentation/Spanish.md)
- [Pусский :ru:](https://github.com/pediRAM/RecentFilesHistory/blob/main/Documentation/Russian.md)
- [Deutsch :de: :austria: :switzerland:](https://github.com/pediRAM/RecentFilesHistory/blob/main/Documentation/German.md)
- [हिंदी :india:](https://github.com/pediRAM/RecentFilesHistory/blob/main/Documentation/Hindi.md)
- [Türkçe :tr:](https://github.com/pediRAM/RecentFilesHistory/blob/main/Documentation/Turkish.md)
- [فارسی :iran: :afghanistan: :tajikistan:](https://github.com/pediRAM/RecentFilesHistory/blob/main/Documentation/Farsi.md)

# RecentFilesHistory Library
This Library Facilitating Easy and Efficient File Access in Desktop Applications, Mirroring Popular Feature like "**Recent Files**" or "**Last Opened Files**" or "**File History**" from Notable Editors and Design Applications. 

Latest opened/saved/closed **N** files (text/image/project/...) are saved with [LRU policy](https://en.wikipedia.org/wiki/Cache_replacement_policies#Least_recently_used_(LRU)).

**N**: N is the configurable capacity.

## Usage Example
![Recent File History](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/demo-window-history-of-recently-opened-closed-or-saved-files.png)

## UML Class Diagram
![UML Class Diagram](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/uml-class-diagramm-of-recent-files-history.png)

## How It Works
The library includes the generic abstract class `RecentlyFilesHistoryManager<T>`, which manages elements in the `ObservableCollection<T> Items` using an LRU (Least Recently Used) cache policy.

To add a file to the history, simply use the `PutAtFront(item)` method. If the item already exists in the collection, it will be moved to the first position (considered most recent).

To use this library, implement the generic abstract class by specifying the data type for the generic type. Then, implement the `Load()` and `Save()` methods to manage the history of recently opened, saved, and closed files.

## Demo Project

You can explore the [demo WPF desktop project](https://github.com/pediRAM/RecentFilesHistory/tree/main/Source/RecentFilesHistoryDemoWpfApp), which demonstrates how to use the library to manage filepaths (strings).
