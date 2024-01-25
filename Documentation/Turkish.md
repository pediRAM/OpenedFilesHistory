# RecentFilesHistory Kütüphanesi
Bu kütüphane masaüstü uygulamalarda dosyalara kolay ve verimli erişimi sağlar ve tanınmış editörlerden ve tasarım uygulamalarından "Dosya Geçmişi", "Son Açılan Dosyalar" ve "Son Dosyalar" gibi popüler özellikleri yansıtır.

## Kullanım Örneği
![Son Dosya Geçmişi](demo-window-history-of-recently-opened-closed-or-saved-files.png)

## UML Sınıf Diyagramı
![UML Sınıf Diyagramı](uml-class-diagramm-of-recent-files-history.png)

## Nasıl Çalışır
Kütüphane, LRU (Son Kullanılan En Az) önbellek politikası kullanarak `ObservableCollection<T> Items` koleksiyonundaki öğeleri yöneten genel soyut sınıf `RecentlyFilesHistoryManager<T>` içerir.

Bir dosyayı geçmişe eklemek için sadece `PutAtFront(item)` yöntemini kullanın. Öğe koleksiyonda zaten varsa, ilk pozisyona taşınır (en son kullanılan olarak kabul edilir).

Bu kütüphaneyi kullanmak için, genel soyut sınıfı belirli tür için belirterek uygulayın. Ardından, son zamanlarda açılan, kaydedilen ve kapatılan dosyaların geçmişini yönetmek için `Load()` ve `Save()` yöntemlerini uygulayın.

## Demo Projesi
Kütüphaneyi dosya yollarını (dizeleri) yönetmek için nasıl kullanacağınızı gösteren demo projesini inceleyebilirsiniz.