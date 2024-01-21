

namespace RecentFilesHistoryDemoWpfApp
{
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <summary>
    /// Provides method to extracts the filename of a given filepath, e.g.: returns "FileName.txt" for given "C:\Folder\FileName.txt".
    /// </summary>
    public class FileNameExtractionConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider pServiceProvider)
            => this;

        public object Convert(object pValue)
            => System.IO.Path.GetFileName((string)pValue);

        public virtual object Convert(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture)
            => Convert(pValue);

        public virtual object ConvertBack(object pValue, Type pTargetType, object pParameter, CultureInfo pCulture)
            => throw new InvalidOperationException("This ValueConverter does not support converting types backward!");
    }
}
