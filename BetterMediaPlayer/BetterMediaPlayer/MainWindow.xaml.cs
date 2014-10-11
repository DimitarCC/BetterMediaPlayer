using com.ptrampert.LibVLCBind;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BetterMediaPlayer
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private IVLCInstance vlc;
		private IMedia media;
		private IVideoPlayer player;
		private const string filename = @"W:\Action\Batman (1989).mkv";
		public MainWindow()
		{
			InitializeComponent();
			IVLCFactory factory = new TwoflowerVLCFactory();
			vlc = factory.InitializeVLC(new string[1] { "--subsdec-encoding=Windows-1251" });
			media = vlc.GetVLCMedia(filename, true);
			player = vlc.CreateMediaPlayer<IVideoPlayer>();
			player.Media = media;
			player.Drawable = this.VideoCanvas.Handle;
			player.Mute = false;
			player.Play();
		}
	}
}
