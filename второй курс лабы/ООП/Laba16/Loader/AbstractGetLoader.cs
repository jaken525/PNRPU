using System.Collections.Generic;
using System.Windows.Forms;

namespace Laba16
{
    public abstract class AbstractGetLoader<T> where T : Form
    {
        T form;
        public AbstractGetLoader(T form)
        {
            this.form = form;
        }
        public abstract IEnumerable<ToolStripMenuItem> GetLoaders();
    }

}
