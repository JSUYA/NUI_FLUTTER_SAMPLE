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


            FocusManager.Instance.EnableDefaultAlgorithm(true);

            ImageView image = new ImageView();
            image.Size = new Size(300, 200);
            image.SetImage("/usr/ug/res/edje/icons/icons/doc_icon_rss.png");
            window.Add(image);

            image.Focusable = true;
            image.FocusableInTouch = true;
            image.KeyEvent += (object s, View.KeyEventArgs e) =>
            {
                image.Size = new Size(500, 200);
                return true;
            };

            image.TouchEvent += (object s, View.TouchEventArgs e) =>
            {
                FocusManager.Instance.SetCurrentFocusView(image);
                image.Size = new Size(100, 200);
                return true;
            };
            /*
                        Window.Instance.InterceptKeyEvent += (s, e) =>
                        {
                            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
                            {
                                Exit();
                            }
                        };

            */

            window.Add(rootView);
            Button textButton = new Button();
            textButton.Size = new Size(300, 200);
            textButton.Position2D = new Position2D(400, 10);
            textButton.TextLabel.Text = "Change view size";
            textButton.Focusable = true;
            textButton.FocusableInTouch = true;
            rootView.Add(textButton);

            /*TextEditor editor = new TextEditor();
            //editor.Position2D = new Position2D(10, 10);
            editor.Size2D = new Size2D(200, 400);
            editor.BackgroundColor = Color.Red;
            editor.PointSize = 10;
            editor.TextColor = Color.White;
            editor.Text = "This is a multiline text.\n I can write several lines.\n";
            editor.Focusable = true;*/
            //Window.Instance.Add(editor);


            NUIFlutterView flutterView = new NUIFlutterView()
            {
                //Relative Layout
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                //Size2D = new Size2D(640, 700)
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
                            flutterView.Size2D = new Size2D(200, 500);
                            i = 1;
                        }
                        else if (i == 1)
                        {
                            flutterView.Size2D = new Size2D(640, 300);
                            i = 2;
                        }
                        else if (i == 2)
                        {
                            flutterView.Size2D = new Size2D(640, 900);
                            textButton.TextLabel.Text = "Add button";
                            i = 3;
                        }
                        else if (i == 3)
                        {
                            i = 0;
                            textButton.TextLabel.Text = "Change view size";
                            Button btn = new Button();
                            btn.TextLabel.Text = "Test Button";
                            btn.Focusable = true;
                            btn.FocusableInTouch = true;
                            rootView.Add(btn);
                        }

                    };

            //window.Add(rootView);
        }

        static void Main(string[] args)
        {
            var app = new App();
            app.Run(args);
        }
    }
}
