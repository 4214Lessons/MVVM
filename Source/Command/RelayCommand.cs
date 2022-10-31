using System;
using System.Windows.Input;

namespace Source.Command;

public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }


    private readonly Action<object?> _execute;
    private readonly Predicate<object?>? _canExecute;


    public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
    {
        ArgumentNullException.ThrowIfNull(execute, nameof(execute));

        _execute = execute;
        _canExecute = canExecute;
    }


    public void Execute(object? parameter)
        => _execute.Invoke(parameter);


    public bool CanExecute(object? parameter)
        => _canExecute is null || _canExecute.Invoke(parameter);
}