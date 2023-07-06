using PropertyChanged;

namespace ChatModels
{
    [AddINotifyPropertyChangedInterface]
    public class User
    {
        public string Nick { get; set; }

        public Uri Pic { get; set; }

        public bool IsWriting { get; set; }
    }
}