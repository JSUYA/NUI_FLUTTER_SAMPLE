using Tizen.Flutter.Embedding;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Runner
{
    public class App : NUIApplication
    {
        int i = 0;

        public override void Run(string[] args)
        {
            base.Run(args);
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            Window window = NUIApplication.GetDefaultWindow();
            View rootView = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical }
            };

            Button textButton = new Button();
            textButton.Size = new Size(300, 200);
            textButton.Position2D = new Position2D(400, 10);
            textButton.TextLabel.Text = "Change view size";
            rootView.Add(textButton);
            NUIFlutterView flutterView = new NUIFlutterView()
            {
                //Relative Layout
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                // or Size2D = new Size2D(300, 200)
            };
            if (flutterView.RunEngine())
            {
                GeneratedPluginRegistrant.RegisterPlugins(flutterView.Engine);
                rootView.Add(flutterView);
            }

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
                            textButton.TextLabel.Text = "Add button";
                            i = 3;
                        }
                        else if (i == 3)
                        {
                            i = 0;
                            textButton.TextLabel.Text = "Change view size";
                            Button btn = new Button();
                            btn.TextLabel.Text = "Test Button";
                            rootView.Add(btn);
                        }

                    };

            window.Add(rootView);
        }

        static void Main(string[] args)
        {
            var app = new App();
            app.Run(args);
        }
    }
}
