using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Book_Downloader
{
    public class ButtonGroup<V>
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
