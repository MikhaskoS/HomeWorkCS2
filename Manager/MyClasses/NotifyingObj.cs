using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
    public abstract class NotifyingObj : INotifyPropertyChanged
    {
        // Сообщает клиенту об изменении значения свойства.
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null) =>
          PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
    }
}
