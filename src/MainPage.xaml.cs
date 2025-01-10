namespace src
{
    public partial class MainPage : ContentPage
    {
        string currentNumber;
        int currentState = -1;
        double n1, n2, result;
        string operation;
        Dictionary<string, Operations> operations;

        public MainPage()
        {
            InitializeComponent();
            operations = new Dictionary<string, Operations>() 
            {
                {"+", Operations.soma},
                {"-", Operations.subtração}
            };
        }

        private void Button_Clicked_Operation(object sender, EventArgs e)
        {
            LockNumber(lblResult.Text);

            string pressed;

            if (sender is Button button)
            {
                currentState = -2;
                pressed = button.Text;

                if (pressed == "x")
                {
                    pressed = "*";
                }

                operation = pressed;
            }
        }

        private void LockNumber(string text)
        {
            double number = 0.0;
            if (double.TryParse(text, out number))
            {
                if (currentState == 1)
                {
                    n1 = number;
                }
                else
                {
                    n2 = number;
                }

                currentNumber = string.Empty;
            }
        }

        private void Button_Clicked_Clear(object sender, EventArgs e)
        {
            n1 = 0;
            n2 = 0;
            currentState = 1;
            lblResult.Text = "0";
            currentNumber = string.Empty;
        }

        private void Button_Number_Clicked(object sender, EventArgs e)
        {
            string numberPressed = string.Empty;

            if (sender is Button button)
                numberPressed = button.Text;

            currentNumber += numberPressed;

            if ((lblResult.Text == "0" && numberPressed == "0") 
                ||(currentNumber.Length <= 1 && numberPressed != "0")
                || currentState < 0)
            {
                lblResult.Text = "";
                if (currentState < 0)
                    currentState *= -1;
            }
            
            lblResult.Text += numberPressed;

            //if (sender is Button button)
            //{
            //    if (n1 == 0)
            //    {
            //        n1 = int.Parse(button.Text);
            //        lblResult.Text = n1.ToString();
            //    }
            //    else
            //    {
            //        n2 = int.Parse(button.Text); 
            //        lblResult.Text = n2.ToString();
            //    }
            //}
        }

        private void ResultButton_Clicked(object sender, EventArgs e)
        { 
            if (currentState == 2)
            {
                if (n2 == 0)
                    LockNumber(lblResult.Text);

                double result = Calculator.Calculate(n1, n2, operation);

                CurrentCalculation.Text = $"{n1}{operation}{n2}";

                lblResult.Text = result.ToString();
                n1 = result;
                n2 = 0;
                currentState = -1;
                currentNumber = string.Empty;
            }
        }
    }

    public enum Operations
    {
       soma,
       subtração,
       multiplicacao,
       divisao
    }
}
