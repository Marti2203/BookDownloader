using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Book_Downloader
{
    public class DefaultBackgroundHandler : BackgroundHandler
    {
        bool ChangeOnResize = false;
        
        public DefaultBackgroundHandler(BackgroundChange change, Form form) : base(change, form){}

        public override void Resized()
        {
            if (ChangeOnResize)
                ChangeBackground();
        }

        protected override void Startup(BackgroundChange change)
        {
            if (change > BackgroundChange.Never)
                ChangeBackground();          
            if (change == BackgroundChange.Always) ChangeOnResize = true;
            if (change == BackgroundChange.Never)
                _form.Controls.OfType<CustomLabel>()
                .ToList().ForEach(element => element.OutlineForeColor = Color.Gray);
        }
    }
}
