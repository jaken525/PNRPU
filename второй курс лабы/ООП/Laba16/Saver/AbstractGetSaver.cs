using System.Collections.Generic;
using System.Windows.Forms;

namespace Laba16
{
    public abstract class AbstractGetSaver<T> where T : Form
    {
        T form;
        public AbstractGetSaver(T form)
        {
            this.form = form;
        }

        public abstract IEnumerable<ToolStripMenuItem> GetSavers();
    }
}
