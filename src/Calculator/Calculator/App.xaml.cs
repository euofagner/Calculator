﻿using Calculator.ViewModels;
using Calculator.Views;

namespace Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new CalculatorView(new CalculatorViewModel()));
        }
    }
}