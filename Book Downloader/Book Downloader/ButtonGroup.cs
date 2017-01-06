using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book_Downloader
{
    class SpeciaRadioButton<V> : RadioButton
    {
        public V Value { get; set; }
        public override bool Equals(object obj)
        {
            if (this == null || obj == null) return false;
            if (this.GetType() != obj.GetType())
                return false;
            return Value.Equals((obj as SpeciaRadioButton<V>).Value);
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
        class ButtonGroup<V>
    {
        private readonly Dictionary<RadioButton, V> _elements;
        private RadioButton last;
        public RadioButton Checked { get { return last; } }
        public V Value { get { return _elements[last]; } }
        public ButtonGroup()
        {
            _elements = new Dictionary<RadioButton, V>();
        }
        public ButtonGroup(IEnumerable<Tuple<RadioButton, V>> values):this()
        {
            foreach(Tuple<RadioButton,V> element in values)
            {
                Add(element.Item1, element.Item2);
                if (element.Item1.Checked)
                    last = element.Item1;
            }
        }
        public void Add(RadioButton button, V value)
        {
            _elements.Add(button, value);
            button.CheckedChanged += Button_CheckedChanged;
        }
        public void Remove(RadioButton button)
        {
            _elements.Remove(button);
        }
        private void Button_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != this && last != null)
                last.Checked = false;
            last = (RadioButton)sender;
        }
    }
}
