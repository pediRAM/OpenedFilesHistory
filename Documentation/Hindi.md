![logo](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/icon.png)

[![License](https://img.shields.io/badge/License-MIT-green.svg)](LICENSE)
[![Release](https://img.shields.io/github/release/pediRAM/RecentFilesHistory.svg?sort=semver)](https://github.com/pediRAM/RecentFilesHistory/releases)
[![NuGet](https://img.shields.io/nuget/v/RecentFilesHistory)](https://www.nuget.org/packages/RecentFilesHistory)

# हाल की फ़ाइल इतिहास पुस्तकालय
इस पुस्तकालय ने डेस्कटॉप ऐप्लिकेशन्स में आसान और दक्ष फ़ाइल एक्सेस को सुविधाजनक बनाया है, जो लोकप्रिय संपादकों और डिज़ाइन एप्लिकेशन्स से "फ़ाइल इतिहास", "आख़री खोली गई फ़ाइलें" या "हाल की फ़ाइलें" जैसे पॉपुलर फ़ीचर का परिचाय करता है।

## उपयोग का उदाहरण
![हाल की फ़ाइल इतिहास](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/demo-window-history-of-recently-opened-closed-or-saved-files.png)

## UML कक्ष आरेख
![UML कक्ष आरेख](https://raw.githubusercontent.com/pediRAM/RecentFilesHistory/main/Documentation/uml-class-diagramm-of-recent-files-history.png)

## कैसे काम करता है
यह पुस्तकालय जेनेरिक अब्स्ट्रैक्ट क्लास `RecentlyFilesHistoryManager<T>` को शामिल करता है, जो LRU (कम हाल में उपयोग किया गया) कैश पॉलिसी का उपयोग करके `ObservableCollection<T> Items` में तत्वों का प्रबंधन करता है।

फ़ाइल को इतिहास में जोड़ने के लिए, बस `PutAtFront(item)` मेथड का उपयोग करें। यदि आइटम पहले से संग्रह में मौजूद है, तो यह पहले स्थान पर हो जाएगा (सबसे हाल को माना जाता है)।

इस पुस्तकालय का उपयोग करने के लिए, जेनेरिक अब्स्ट्रैक्ट क्लास को उपयोग करके जेनेरिक प्रकार के लिए डेटा प्रकार की निर्दिष्टि करके करें। फिर, हाल की खोली गई, सहेजी गई और बंद की गई फ़ाइलों का इतिहास प्रबंधित करने के लिए `Load()` और `Save()` मेथड को अमल करें।

## डेमो प्रोजेक्ट
आप डेमो प्रोजेक्ट की जांच कर सकते हैं, जिसमें दिखाया गया है कि पुस्तकालय का उपयोग फ़ाइल पथों (स्ट्रिंग्स) को प्रबंधित करने के लिए कैसे किया जा सकता है।