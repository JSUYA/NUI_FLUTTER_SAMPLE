using Tizen.Flutter.Embedding;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Reflection;
using System;

namespace Runner
{
    public class App : NUIApplication
    {
        Timer timer;
        protected override void OnCreate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            Button textButton = new Button();

            textButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            textButton.Size = new Size(350, 100);
            textButton.TextLabel.Text = "NUI text button";

            window.Add(textButton);

            var flutterView = new NUIFlutterView()
            {
                Size2D = new Size2D(600, 600),
                Position2D = new Position2D(0, 150),
            };

            if (flutterView.RunEngine())
            {
                GeneratedPluginRegistrant.RegisterPlugins(flutterView.Engine);
                window.Add(flutterView);
            }
        }

        static void Main(string[] args)
        {
            var app = new App();
            app.Run(args);
        }
    }
}
