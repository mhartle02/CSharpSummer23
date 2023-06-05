﻿using PracticePanther.MAUI.ViewModels;
namespace PracticePanther.MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();

        }

        private void Button_Clicked(object sender, EventArgs e)
        {

        }

        private void DeleteClick(object sender, EventArgs e)
        {
            (BindingContext as MainViewModel).Delete();
        }
    }
}