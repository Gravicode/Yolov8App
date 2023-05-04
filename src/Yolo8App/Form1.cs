using Emgu.CV;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Yolov8Net;
using static System.Net.Mime.MediaTypeNames;

namespace Yolo8App {
    public partial class Form1 : Form {
        CancellationTokenSource cts;
        bool IsRunning = false;
        IPredictor yolo;
        Thread th1;
        public Form1() {
            InitializeComponent();
            Setup();

        }
        void StartCam(CancellationToken token) {
            try {
                //String win1 = "Test Window (Press any key to close)"; //The name of the window
                //CvInvoke.NamedWindow(win1); //Create the window using the specific name
                IsRunning = true;
                using (Mat frame = new Mat())
                using (VideoCapture capture = new VideoCapture())
                    while (true) {
                        capture.Read(frame);
                        var img = frame.ToBitmap();
                        //this.Invoke((MethodInvoker)(() => {
                        Process(img);
                        //}));
                        if (token.IsCancellationRequested) {
                            break;
                        }
                        //Thread.Sleep(20);

                        //CvInvoke.Imshow(win1, frame);
                    }

            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            finally { IsRunning = false; }

        }

        void Setup() {
            yolo = YoloV8Predictor.Create("Assets/yolov8m.onnx", useCuda: false);
            BtnStart.Click += (a, b) => {
                //Run();
                if (IsRunning) return;
                cts = new CancellationTokenSource();
                th1 = new Thread(() => { StartCam(cts.Token); });
                th1.Start();
            };
            BtnStop.Click += (a, b) => {
                if (IsRunning) {
                    cts.Cancel();
                }
            };
        }
        void Process(System.Drawing.Image image) {

            // Create new Yolov8 predictor, specifying the model (in ONNX format)
            // If you are using a custom trained model, you can provide an array of labels. Otherwise, the standard Coco labels are used.


            // Provide an input image.  Image will be resized to model input if needed.
            //using var image = Image.FromFile("Assets/input.jpg");
            var predictions = yolo.Predict(image);
            var desc = string.Empty;
            // Draw your boxes
            //using var graphics = Graphics.FromImage(image);
            using (Graphics graphics = Graphics.FromImage(image)) {
                graphics.CompositingQuality = CompositingQuality.Default;
                graphics.SmoothingMode = SmoothingMode.Default;
                graphics.InterpolationMode = InterpolationMode.Default;

                // Define Text Options
                Font drawFont = new Font("consolas", 11, FontStyle.Regular);

                SolidBrush fontBrush = new SolidBrush(Color.Black);


                // Define BoundingBox options
                Pen pen = new Pen(Color.Yellow, 2.0f);
                SolidBrush colorBrush = new SolidBrush(Color.Yellow);
                var originalImageHeight = image.Height;
                var originalImageWidth = image.Width;
                foreach (var pred in predictions) {


                    var x = Math.Max(pred.Rectangle.X, 0);
                    var y = Math.Max(pred.Rectangle.Y, 0);
                    var width = Math.Min(originalImageWidth - x, pred.Rectangle.Width);
                    var height = Math.Min(originalImageHeight - y, pred.Rectangle.Height);

                    ////////////////////////////////////////////////////////////////////////////////////////////
                    // *** Note that the output is already scaled to the original image height and width. ***
                    ////////////////////////////////////////////////////////////////////////////////////////////

                    // Bounding Box Text
                    string text = $"{pred.Label.Name} [{pred.Score}]";
                    desc += text + ", ";
                    SizeF size = graphics.MeasureString(text, drawFont);
                    Point atPoint = new Point((int)x, (int)y - (int)size.Height - 1);
                    // Draw text on image 
                    graphics.FillRectangle(colorBrush, (int)x, (int)(y - size.Height - 1), (int)size.Width, (int)size.Height);
                    graphics.DrawString(text, drawFont, fontBrush, atPoint);
                    // Draw bounding box on image
                    graphics.DrawRectangle(pen, x, y, width, height);
                }

            }
            this.Invoke((MethodInvoker)(() => {
                TxtStatus.Text = desc;
                PicBox1.Image = image;
                //PicBox1.Refresh();
            }));

        }
    }
}