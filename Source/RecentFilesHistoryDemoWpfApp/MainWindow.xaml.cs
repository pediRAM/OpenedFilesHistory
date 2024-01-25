namespace RecentFilesHistoryDemoWpfApp
{
    using Microsoft.Win32;
    using RecentFilesHistory;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;


    public partial class MainWindow : Window
    {
        private RecentFilesHistoryManager _recentFileHistoryManager;
        private OpenFileDialog _openFileDialog = new OpenFileDialog();


        public MainWindow()
        {
            InitializeComponent();

            // Save paths before closing app.
            Closing += OnMainWindow_Closing;

            // Path to the json file to save paths persistently.
            string path = "Files History.json";

            // Create the file history manager.
            _recentFileHistoryManager = new RecentFilesHistoryManager(path);

            // Load saved paths if json file exists.
            if (File.Exists(path))
                _recentFileHistoryManager.Load();

            DataContext = _recentFileHistoryManager.Items;
        }


        private void OnMainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
            => _recentFileHistoryManager.Save(); // Save paths persistently into json file.


        public void OnProjectHistoryClicked(object sender, RoutedEventArgs e)
        {
            string? path = ((MenuItem)sender).Tag as string;
            _ = MessageBox.Show(path);

            _recentFileHistoryManager?.PutAtFront(path);
        }

        private void OnOpenFileClicked(object sender, RoutedEventArgs e)
        {
            if (_openFileDialog.ShowDialog() == true)
                _recentFileHistoryManager.PutAtFront(_openFileDialog.FileName);
        }

        private void OnClearFilesHistoryClicked(object sender, RoutedEventArgs e) => _recentFileHistoryManager?.Clear();

        private void OnLoadFilesHistoryClicked(object sender, RoutedEventArgs e) => _recentFileHistoryManager?.Load();

        private void OnSaveFilesHistoryClicked(object sender, RoutedEventArgs e) => _recentFileHistoryManager?.Save();
    }
}