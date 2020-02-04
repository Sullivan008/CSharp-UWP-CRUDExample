using Windows.UI.Popups;

namespace CRUDOperationsClient.Dialogs
{
    public class NotificationDialog
    {
        private readonly string _content;
        private readonly string _title;

        public NotificationDialog(string content, string title)
        {
            _content = content;
            _title = title;
        }

        public MessageDialog ShowDialog()
        {
            return new MessageDialog(_content, _title);
        }
    }
}
