using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAWB.WPF.State.Navigators
{
    /// <summary>
    /// An interface declaring a method to change the current viewmodel without using the navigation bar
    /// </summary>
    public interface IRenavigator
    {
        void Renavigate();
    }
}
