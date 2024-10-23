using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace Calculator.Classes.ViewModel
{
    public abstract class Notifier : INotifyPropertyChanged
    {
        /// <summary>
        /// Вызывается, когда свойство этого объекта приобретает новое значение.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Вызывает событие PropertyChanged этого объекта.
        /// </summary>
        /// <param name="propertyName">Свойство, имеющее новое значение.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Проверяет, соответствует ли свойство требуемому значению. 
        /// Устанавливает свойство и уведомляет слушателей только при необходимости.
        /// </summary>
        /// <typeparam name="T">Тип свойства.</typeparam>
        /// <param name="storage">Ссылка на свойства как с геттера, так и с сеттера</param>
        /// <param name="value">Желаемое значение для свойства.</param>
        /// <param name="propertyName">Имя свойства, используемого для уведомления слушателей. 
        /// Это значение необязательно и может быть предоставлено автоматически при вызове из компиляторов, 
        /// поддерживающих CallerMemberName.</param>
        /// <returns>True, если значение было изменено, и false, если существующее значение соответствовало
        /// желаемому значению.</returns>
        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
                return false;
            storage = value;
            this.OnPropertyChanged(propertyName);
            return true;
        }
    }

}
