![logo](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/icon.png)

[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Release](https://img.shields.io/github/release/pediRAM/RecentFilesHistory.svg?sort=semver)](https://github.com/pediRAM/RecentFilesHistory/releases)
[![NuGet](https://img.shields.io/nuget/v/RecentFilesHistory)](https://www.nuget.org/packages/RecentFilesHistory)

# RecentFilesHistory库
这个库为桌面应用程序提供了便捷高效的文件访问功能，模仿了知名编辑器和设计应用程序中的流行功能，如“文件历史记录”、“最近打开的文件”和“最近文件”。

## 使用示例
![最近文件历史记录](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/demo-window-history-of-recently-opened-closed-or-saved-files.png)

## UML类图
![UML类图](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/uml-class-diagramm-of-recent-files-history.png)

## 工作原理
该库包括泛型抽象类 `RecentlyFilesHistoryManager<T>`，使用LRU（最近最少使用）缓存策略来管理 `ObservableCollection<T> Items` 中的元素。

要将文件添加到历史记录中，只需使用 `PutAtFront(item)` 方法。如果项目已经存在于集合中，它将被移到第一个位置（被视为最近的）。

要使用此库，请通过指定泛型类型的数据类型来实现泛型抽象类。然后，实现 `Load()` 和 `Save()` 方法来管理最近打开、保存和关闭文件的历史记录。

## 演示项目
您可以探索演示项目，演示了如何使用此库来管理文件路径（字符串）。