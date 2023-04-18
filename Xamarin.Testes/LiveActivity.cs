using Android.App;
using Android.Content;
using Android.Drm;
using Android.Media;
using Android.Net;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static Android.Telecom.Call;

namespace Xamarin.Testes
{
    [Activity(Label = "LiveActivity", Theme = "@style/AppTheme", MainLauncher = true)]
    public class LiveActivity : Activity
    {
        private VideoView videoView;
        private MediaPlayer mediaPlayer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.live_activity);

            // Localiza a visualização do vídeo pelo id
            videoView = FindViewById<VideoView>(Resource.Id.videoView);

            MediaController mc = new MediaController(this);
            videoView.SetMediaController(mc);

            videoView.Completion += VideoView_Completion1;

          // Uri teste = Uri.Parse("https://moctobpltc-i.akamaihd.net/hls/live/571329/eight/playlist.m3u8");

            Uri teste = Uri.Parse("https://social-storage-staging.fra1.digitaloceanspaces.com/lives/20230418_114912_88565531/live-master-manifest.m3u8");

            RunOnUiThread(() => {
                videoView.SetVideoURI(teste);
                videoView.Start();

            });
             

            videoView.Completion += VideoView_Completion;
            #region lixo
            // Cria uma instância do MediaPlayer
            /*mediaPlayer = new MediaPlayer();

            // Configura o MediaPlayer para reproduzir a fonte do vídeo
            mediaPlayer.SetDataSource("https://moctobpltc-i.akamaihd.net/hls/live/571329/eight/playlist.m3u8");
           
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                mediaPlayer.SetAudioAttributes(new AudioAttributes.Builder()
                    .SetUsage(AudioUsageKind.Media)
                    .SetContentType(AudioContentType.Movie)
                    .Build());

                videoView.Set

            }

            // Prepara o MediaPlayer para a reprodução do vídeo
            mediaPlayer.PrepareAsync();

            // Manipula o evento de conclusão do preparo do MediaPlayer
            mediaPlayer.Prepared += (sender, args) =>
            {
                // Inicia a reprodução do vídeo
                mediaPlayer.Start();
            };

            // Manipula o evento de finalização do vídeo
            mediaPlayer.Completion += (sender, args) =>
            {
                // Para a reprodução do vídeo
                mediaPlayer.Stop();
                mediaPlayer.Reset();
            };*/
            #endregion
        }

        private void VideoView_Completion1(object sender, System.EventArgs e)
        {
            System.Console.WriteLine("TERMINEI A PUTA DA LIVE!");
        }

        private void VideoView_Completion(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        // Pausa a reprodução do vídeo
        private void PauseVideo()
        {
            if (mediaPlayer != null && mediaPlayer.IsPlaying)
            {
                mediaPlayer.Pause();
            }
        }

        // Retoma a reprodução do vídeo
        private void ResumeVideo()
        {
            if (mediaPlayer != null && !mediaPlayer.IsPlaying)
            {
                mediaPlayer.Start();
            }
        }

        // Para a reprodução do vídeo
        private void StopVideo()
        {
            if (mediaPlayer != null)
            {
                mediaPlayer.Stop();
                mediaPlayer.Reset();
            }
        }

    }
}