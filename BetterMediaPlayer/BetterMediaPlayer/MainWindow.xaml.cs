using Declarations;
using Declarations.Media;
using Declarations.Players;
using Implementation;
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
		IMediaPlayerFactory m_factory;
		IDiskPlayer m_player;
		IMediaFromFile m_media;
		private const string filename = @"W:\Action\Batman (1989).mkv";
		public MainWindow()
		{
			InitializeComponent();
			m_factory = new MediaPlayerFactory(true);
			m_player = m_factory.CreatePlayer<IDiskPlayer>();
			m_player.WindowHandle = this.VideoCanvas.Handle;
			

		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
			if (ofd.ShowDialog() == true)
			{
				m_media = m_factory.CreateMedia<IMediaFromFile>(ofd.FileName);
				//m_media.Events.DurationChanged += new EventHandler<MediaDurationChange>(Events_DurationChanged);
				//m_media.Events.StateChanged += new EventHandler<MediaStateChange>(Events_StateChanged);
				//m_media.Events.ParsedChanged += new EventHandler<MediaParseChange>(Events_ParsedChanged);

				m_player.Open(m_media);
				m_media.Parse(true);

				m_player.Play();
			}
		}
	}
}
