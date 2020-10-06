using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Templates
{
    public partial class RoundedPictureBox : Component
    {
        public RoundedPictureBox()
        {
            InitializeComponent();
        }

        public RoundedPictureBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
