using Avalonia;
using Avalonia.Dialogs;
using Avalonia.Logging;
using Avalonia.ReactiveUI;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace FriendOrganizer.UI
{
    public class Program
    {
        public static AppBuilder BuildAvaloniaApp()
        {
            var builder = AppBuilder
                .Configure<App>()
                .UsePlatformDetect()
                .With(new X11PlatformOptions { EnableMultiTouch = true, UseDBusMenu = true, })
                .With(new Win32PlatformOptions { EnableMultitouch = true, AllowEglInitialization = true, })
                .UseSkia()
             .UseReactiveUI();

#if DEBUG
            builder.LogToTrace(LogEventLevel.Debug, LogArea.Property, LogArea.Layout, LogArea.Binding);
#endif
            return builder;
        }

        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [ExcludeFromCodeCoverage]
        static void Main(string[] args) => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }
}
