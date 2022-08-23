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
        int i = 0;

        public override void Run(string[] args)
        {
            base.Run(args);
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            Window window = NUIApplication.GetDefaultWindow();
            // Only show a text button.
            Button textButton = new Button();
            textButton.Size = new Size(150, 150);
            textButton.Position2D = new Position2D(10, 10);
            textButton.TextLabel.Text = "NUI text button";
            textButton.Focusable = true;

            NUIFlutterView flutterView = new NUIFlutterView()
            {
                Size2D = new Size2D(640, 900),
                Position2D = new Position2D(50, 300),
            };

            if (flutterView.RunEngine())
            {
                GeneratedPluginRegistrant.RegisterPlugins(flutterView.Engine);
                window.Add(flutterView);
            }

            window.Add(textButton);

            textButton.Clicked += (o, e) =>
            {
                if (i == 0)
                {
                    flutterView.Resize(200, 500);
                    i = 1;
                }
                else if (i == 1)
                {
                    flutterView.Resize(640, 300);
                    i = 2;
                }
                else if (i == 2)
                {
                    flutterView.Resize(640, 900);
                    i = 0;
                }
            };
        }

        static void Main(string[] args)
        {
            var app = new App();
            app.Run(args);
        }
    }
}
