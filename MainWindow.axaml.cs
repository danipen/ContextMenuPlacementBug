using System;
using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace ContextMenuPlacementBug
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.Activated += MainWindow_Activated;

            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.Padding = new Thickness(0);
            this.Margin = new Thickness(0);
            
            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 1" });
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 2" });
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 3" });
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 4" });

            mContextMenu = new ContextMenu();
            mContextMenu.Items = menuItems;

            mButton = this.FindControl<Panel>("mButton");
            mButton.Margin = new Thickness(0);
            mButton.PointerPressed += button_Click;
        }

        private void MainWindow_Activated(object? sender, EventArgs e)
        {
            Console.WriteLine("WindowBounds: {0},{1}, {2}x{3} (IsMaximized={4})", this.Bounds.X, this.Bounds.Y, this.Bounds.Width, this.Bounds.Height, this.WindowState == WindowState.Maximized);
        }

        void button_Click(object? sender, RoutedEventArgs e)
        {
            mContextMenu.PlacementTarget = mButton;
            mContextMenu.PlacementMode = PlacementMode.Bottom;
            mContextMenu.Open(mButton);
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        ContextMenu mContextMenu;
        Panel mButton;
    }
}