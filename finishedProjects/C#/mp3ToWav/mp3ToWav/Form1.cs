using NAudio.Wave;

namespace mp3ToWav
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert(object sender, EventArgs e)
        {
            OpenFileDialog open =  new OpenFileDialog();
            open.Filter = "MP3 File (.*mp3)|*.mp3;";
            if (open.ShowDialog() != DialogResult.OK) return; 

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "WAV File (.*wav)|*.wav;";
            if (save.ShowDialog() != DialogResult.OK) return;

            using (Mp3FileReader mp3 = new Mp3FileReader(open.FileName))
            {
                using (WaveStream pcm = WaveFormatConversionStream.CreatePcmStream(mp3))
                {
                    WaveFileWriter.CreateWaveFile(save.FileName, pcm);
                }
            }
        }
    }
}
