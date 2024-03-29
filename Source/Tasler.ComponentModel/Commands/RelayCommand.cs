using System;
using System.Windows.Input;

namespace Tasler.ComponentModel
{
    /// <summary>
    /// An <see cref="ICommand"/> whose delegates do not take any parameters for <see cref="Execute()"/> and <see cref="CanExecute()"/>.
    /// </summary>
    /// <see cref="RelayCommandBase"/>
    /// <see cref="DelegateCommand{T}"/>
    public class RelayCommand : RelayCommandBase
    {
        Action _executeMethod;
        Func<bool> _canExecuteMethod;

        /// <summary>
        /// Creates a new instance of <see cref="RelayCommand"/> with the <see cref="Action"/> to invoke on execution.
        /// </summary>
        /// <param name="executeMethod">The <see cref="Action"/> to invoke when <see cref="ICommand.Execute(object)"/> is called.</param>
        public RelayCommand(Action executeMethod)
            : this(executeMethod, () => true)
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="RelayCommand"/> with the <see cref="Action"/> to invoke on execution
        /// and a <see langword="Func" /> to query for determining if the command can execute.
        /// </summary>
        /// <param name="executeMethod">The <see cref="Action"/> to invoke when <see cref="ICommand.Execute"/> is called.</param>
        /// <param name="canExecuteMethod">The <see cref="Func{TResult}"/> to invoke when <see cref="ICommand.CanExecute"/> is called</param>
        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
            : base()
        {
            ValidateArgument.IsNotNull(executeMethod, nameof(executeMethod));
            ValidateArgument.IsNotNull(canExecuteMethod, nameof(canExecuteMethod));

            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        ///<summary>
        /// Executes the command.
        ///</summary>
        public void Execute()
        {
            _executeMethod();
        }

        /// <summary>
        /// Determines if the command can be executed.
        /// </summary>
        /// <returns>Returns <see langword="true"/> if the command can execute,otherwise returns <see langword="false"/>.</returns>
        public bool CanExecute()
        {
            return _canExecuteMethod();
        }

        /// <summary>
        /// Handle the internal invocation of <see cref="ICommand.Execute(object)"/>
        /// </summary>
        /// <param name="parameter">Command Parameter</param>
        protected override void Execute(object parameter)
        {
            Execute();
        }

        /// <summary>
        /// Handle the internal invocation of <see cref="ICommand.CanExecute(object)"/>
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns><see langword="true"/> if the Command Can Execute, otherwise <see langword="false" /></returns>
        protected override bool CanExecute(object parameter)
        {
            return CanExecute();
        }

        ///// <summary>
        ///// Observes a property that implements INotifyPropertyChanged, and automatically calls DelegateCommandBase.RaiseCanExecuteChanged on property changed notifications.
        ///// </summary>
        ///// <typeparam name="T">The object type containing the property specified in the expression.</typeparam>
        ///// <param name="propertyExpression">The property expression. Example: ObservesProperty(() => PropertyName).</param>
        ///// <returns>The current instance of DelegateCommand</returns>
        //public RelayCommand ObservesProperty<T>(Expression<Func<T>> propertyExpression)
        //{
        //    ObservesPropertyInternal(propertyExpression);
        //    return this;
        //}

        ///// <summary>
        ///// Observes a property that is used to determine if this command can execute, and if it implements INotifyPropertyChanged it will automatically call DelegateCommandBase.RaiseCanExecuteChanged on property changed notifications.
        ///// </summary>
        ///// <param name="canExecuteExpression">The property expression. Example: ObservesCanExecute(() => PropertyName).</param>
        ///// <returns>The current instance of DelegateCommand</returns>
        //public RelayCommand ObservesCanExecute(Expression<Func<bool>> canExecuteExpression)
        //{
        //    _canExecuteMethod = canExecuteExpression.Compile();
        //    ObservesPropertyInternal(canExecuteExpression);
        //    return this;
        //}
    }
}
