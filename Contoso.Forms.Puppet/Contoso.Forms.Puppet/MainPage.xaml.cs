﻿using System;
using System.IO;
using Microsoft.Sonoma.Crashes;

namespace Contoso.Forms.Puppet
{
    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void GoToSubPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SubPage());
        }

        private void CrashWithDivsionByZero(object sender, EventArgs e)
        {
            // ReSharper disable once RedundantAssignment
            // ReSharper disable once UnusedVariable
            var count = 0 / int.Parse("0");
        }

        private void GenerateTestCrash(object sender, EventArgs e)
        {
            Crashes.GenerateTestCrash();
        }

        private void CrashWithAggregateException(object sender, EventArgs e)
        {
            throw PrepareException();
        }

        private static Exception PrepareException()
        {
            try
            {
                throw new AggregateException(SendHttp(), new ArgumentException("Invalid parameter", ValidateLength()));
            }
            catch (Exception e)
            {
                return e;
            }
        }

        private static Exception SendHttp()
        {
            try
            {
                throw new IOException("Network down");
            }
            catch (Exception e)
            {
                return e;
            }
        }

        private static Exception ValidateLength()
        {
            try
            {
                throw new ArgumentOutOfRangeException(null, "It's over 9000!");
            }
            catch (Exception e)
            {
                return e;
            }
        }
    }
}