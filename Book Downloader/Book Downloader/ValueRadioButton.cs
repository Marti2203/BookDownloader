using System.Windows.Forms;

namespace Book_Downloader
{
    public class ValueRadioButton<V> : RadioButton
    {
        public V Value { get; set; }
        public override bool Equals(object obj)
        {
            if (this == null || obj == null) return false;
            if (this.GetType() != obj.GetType())
                return false;
            return Value.Equals((obj as ValueRadioButton<V>).Value);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
