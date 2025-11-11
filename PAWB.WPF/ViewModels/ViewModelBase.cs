using PAWB.WPF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PAWB.WPF.ViewModels
{
    //Encapsulates a method that creates a ViewModel of type TViewModel, where TViewModel is a ViewModel.
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
    public class ViewModelBase : ObservableObjects
    {
    
    }
}
