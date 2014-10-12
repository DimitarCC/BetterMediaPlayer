using Declarations;
using Declarations.Media;
using Declarations.Players;
using Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

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
			m_player.Events.PlayerPositionChanged += Events_PlayerPositionChanged;
			m_player.Events.PlayerStopped += Events_PlayerStopped;
			m_player.Events.MediaEnded += Events_MediaEnded;
			

		}

		void Events_MediaEnded(object sender, EventArgs e)
		{
			isFromEvent = true;
			if (!isEventHandled)
			{
				Dispatcher.Invoke(DispatcherPriority.Background,
				new Action(() => this.ProgressBar.Value = 0));
			}
			else
			{
				isEventHandled = false;
			}
			isFromEvent = false;
		}

		void Events_PlayerStopped(object sender, EventArgs e)
		{
			isFromEvent = true;
			if (!isEventHandled)
			{
				Dispatcher.Invoke(DispatcherPriority.Background,
				new Action(() => this.ProgressBar.Value = 0));
			}
			else
			{
				isEventHandled = false;
			}
			isFromEvent = false;
		}
		bool isFromEvent = false;
		bool isEventHandled = false;
		void Events_PlayerPositionChanged(object sender, Declarations.Events.MediaPlayerPositionChanged e)
		{
			isFromEvent = true;
			if (!isEventHandled)
			{
				Dispatcher.Invoke(DispatcherPriority.Background,
				new Action(() => this.ProgressBar.Value = e.NewPosition));
			}
			else
			{
				isEventHandled = false;
			}
			isFromEvent = false;
			
		}
		string filenamef;
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Microsoft.Win32.OpenFileDialog ofd = new Microsoft.Win32.OpenFileDialog();
			if (ofd.ShowDialog() == true)
			{
				isFromEvent = true;
				System.Windows.Forms.Application.DoEvents();
				filenamef = ofd.FileName;
				m_media = m_factory.CreateMedia<IMediaFromFile>(filenamef);
				Thread t = new Thread(() =>
				{


					if (m_player.CurrentMedia != null)
						m_player.CurrentMedia.Dispose();
					//m_media.Events.DurationChanged += new EventHandler<MediaDurationChange>(Events_DurationChanged);
					//m_media.Events.StateChanged += new EventHandler<MediaStateChange>(Events_StateChanged);
					//m_media.Events.ParsedChanged += new EventHandler<MediaParseChange>(Events_ParsedChanged);
					//System.Windows.Forms.Application.DoEvents();
					m_player.Open(m_media);
					//System.Windows.Forms.Application.DoEvents();
					m_media.Parse(true);
					//System.Windows.Forms.Application.DoEvents();
					m_player.Play();
				});
				t.Start();
				//isFromEvent = false;
			}
		}

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			//m_media = m_factory.CreateMedia<IMediaFromFile>(filenamef);
			////m_media.Events.DurationChanged += new EventHandler<MediaDurationChange>(Events_DurationChanged);
			////m_media.Events.StateChanged += new EventHandler<MediaStateChange>(Events_StateChanged);
			////m_media.Events.ParsedChanged += new EventHandler<MediaParseChange>(Events_ParsedChanged);

			//m_player.Open(m_media);
			//m_media.Parse(true);
			m_player.Play();
		}

		private void Button_Click_2(object sender, RoutedEventArgs e)
		{
			m_player.Pause();
		}

		private void Button_Click_3(object sender, RoutedEventArgs e)
		{
			m_player.Stop();
		}

		private void ProgressBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (!isFromEvent)
			{
				isEventHandled = true;
				m_player.Position = (float)e.NewValue;
			}
		}
	}
}
