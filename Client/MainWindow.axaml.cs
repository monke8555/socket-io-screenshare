using System;
using Avalonia;
using System.IO;
using SocketIOClient;
using Avalonia.Media;
using Avalonia.Layout;
using Avalonia.Controls;
using Avalonia.Threading;
using Avalonia.Markup.Xaml;
using Image = System.Drawing.Image;
using Color = Avalonia.Media.Color;
using Bitmap = Avalonia.Media.Imaging.Bitmap;
using ImageControl = Avalonia.Controls.Image;

namespace ScreenShareClient {
	public partial class MainWindow : Window {

		public MainWindow() {
			InitializeComponent();

			this.FindControl<Button>("Connect").Click += delegate {
				Connect();
			};

#if DEBUG
			this.AttachDevTools();
#endif
		}

		private void InitializeComponent() {
			AvaloniaXamlLoader.Load(this);
		}

		async void Connect() {
			try {
				string url = this.FindControl<TextBox>("URL").Text;

				var client = new SocketIO(url, new SocketIOOptions() { ConnectionTimeout = new TimeSpan(0, 0, 10), AllowedRetryFirstConnection = true, Reconnection = true, EIO = 4 });

				// Event Handling
				client.OnConnected += async (sender, e) => {
					await client.EmitAsync("hello", "Client connected");
				};

				client.On("screen", data => {
					LoadBase64(data.GetValue<string>()).Save("screen.png");
					Dispatcher.UIThread.InvokeAsync(async () => {
						this.FindControl<ImageControl>("Screen").Source = new Bitmap("screen.png");
					});
				});

				await client.ConnectAsync();
			} catch (Exception ex) {
				var window = new Window { Width = 400, Height = 200, Background = new SolidColorBrush(new Color(255, 37, 37, 38)) };
				window.Content = new TextBlock { Text = "An exception occured: " + ex.Message, FontFamily = "Cascadia Code, Segoe UI, Tahoma", Foreground = new SolidColorBrush(new Color(255, 241, 241, 241)), VerticalAlignment = VerticalAlignment.Center, HorizontalAlignment = HorizontalAlignment.Center };
				window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				await window.ShowDialog((Window)VisualRoot);
			}
		}

		public static Image LoadBase64(string base64) {
			byte[] bytes = Convert.FromBase64String(base64);
			Image image;
			using (MemoryStream ms = new MemoryStream(bytes)) {
				image = Image.FromStream(ms);
			}
			return image;
		}
	}
}