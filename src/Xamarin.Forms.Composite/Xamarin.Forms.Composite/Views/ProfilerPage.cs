﻿using Xamarin.Forms.Composite.Helpers;

namespace Xamarin.Forms.Composite.Views
{
    public class ProfilerPage : ContentPage
    {
        readonly string _name;
        MemoryProfiler _memoryProfiler;

        public ProfilerPage()
        {
            _name = GetType().Name;
            Profiler.Start(_name + " Appearing");
            _memoryProfiler = new MemoryProfiler(_name);
        }

        protected override void OnAppearing()
        {
            Device.BeginInvokeOnMainThread(() => Profiler.Stop(_name + " Appearing"));
        }

        protected override void OnDisappearing()
        {
            _memoryProfiler.Dispose();
        }
    }
}