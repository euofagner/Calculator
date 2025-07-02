using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
}
