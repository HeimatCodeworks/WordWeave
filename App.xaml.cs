﻿using Microsoft.Maui.Controls;

namespace WordWeave;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}