using System;
using PropertyChanged;
using System.Windows.Input;

namespace Calculator.ViewModels;

[AddINotifyPropertyChangedInterface]
public partial class CalculatorViewModel
{
    public string? Formula { get; set; }
    public string? Result { get; set; } = "0";

    public ICommand ClearFormulaCommand => new Command(() =>
    {
        Result = "0";
        Formula = "";
    });

    public ICommand BackspaceCommand => new Command(() =>
    {
        if (Formula!. Length > 0)
            Formula = Formula.Substring(0, Formula.Length - 1);
    });

    public ICommand OperationCommand => new Command((number) => { Formula += number; });

    public ICommand CalculateCommand => new Command(() =>
    {
        if (Formula!.Length == 0) return;

        var calculation = Dangl.Calculator.Calculator.Calculate(Formula);
        Result = calculation.Result.ToString();
    });
}
