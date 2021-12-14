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
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 1" });
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 2" });
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 3" });
            menuItems.Add(new MenuItem() { Header = "This is a long menu item 4" });

            mContextMenu = new ContextMenu();
            mContextMenu.Items = menuItems;

            mButton = this.FindControl<Button>("mButton");
            //mButton.ContextMenu = mContextMenu;
            mButton.Click += button_Click;
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
        Button mButton;
    }
}