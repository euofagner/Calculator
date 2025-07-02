using Calculator.ViewModels;

namespace Calculator.Views;

public partial class CalculatorView : ContentPage
{
	public CalculatorView(CalculatorViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}