using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Mozart
{
    internal class Program
    {
        static void Main()
        {
            string instrument = GetInstrumentChoice();

            PlaySection(instrument, "minuet", 2);

            PlaySection(instrument, "trio", 1);

            Console.WriteLine("Done!");
        }

        static string GetInstrumentChoice()
        {
            string[] validInstruments = { "piano", "mbira", "clarinet", "flute-harp" };
            string instrument;

            while (true)
            {
                Console.WriteLine("Choose an instrument: piano, mbira, clarinet, flute-harp");
                instrument = Console.ReadLine()?.ToLower() ?? string.Empty;

                if (Array.Exists(validInstruments, elem => elem.Equals(instrument)))
                {
                    return instrument;
                }
                Console.WriteLine("Invalid Instrument, please try again..");
            }
        }

        static void PlaySection(string instrument, string type, int diceCount)
        {
            Random random = new Random();
            var audioFiles = new List<(AudioFileReader Reader, string FilePath)>();
            var rollInfo = new List<(int Phrase, int[] Rolls, int RollSum)>();

            for (int i = 0; i < 16; i++)
            {
                int rollSum = RollDice(random, diceCount, out int[] rolls);
                rollInfo.Add((i, rolls, rollSum));

                string filePath = GetFilePath(instrument, type, i, rollSum);

                if (File.Exists(filePath))
                {
                    audioFiles.Add((new AudioFileReader(filePath), filePath));
                }
                else
                {
                    Console.WriteLine($"File not found: {filePath}");
                }
            }

            PlaySoundWithInfo(audioFiles, instrument, type, rollInfo);
        }

        static int RollDice(Random rnd, int diceCount, out int[] rolls)
        {
            rolls = new int[diceCount];
            int rollSum = 0;
            for (int j = 0; j < diceCount; j++)
            {
                rolls[j] = rnd.Next(1, 7);
                rollSum += rolls[j];
            }
            return rollSum;
        }

        static string GetFilePath(string instrument, string style, int phrase, int roll)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            return Path.Combine(currentDirectory, $"AudioLib\\{instrument}\\{style}{phrase}-{roll}.wav");
        }

        static void DisplayInfo(string instrument, string style, int phrase, int[] rolls, int rollSum, string filePath)
        {
            string fileName = Path.GetFileName(filePath);
            Console.Clear();
            Console.WriteLine($"Playing File: {fileName}");
            Console.WriteLine($"Instrument: {instrument}");
            Console.WriteLine($"Style: {style}");
            Console.WriteLine($"Phrase: {phrase + 1} out of 16");
            Console.WriteLine($"Roll: {string.Join(", ", rolls)} - Sum: ({rollSum})");
            Console.WriteLine("\nChange Volume with ↑ and ↓");
        }

        static void PlaySoundWithInfo(List<(AudioFileReader Reader, string FilePath)> audioFiles, string instrument, string style, List<(int Phrase, int[] Rolls, int RollSum)> rollInfo)
        {
            int volumePercent = 50;
            if (audioFiles.Count > 0)
            {
                var concatenatingProvider = new ConcatenatingSampleProvider(audioFiles.ConvertAll(f => f.Reader));
                using (IWavePlayer waveOutDevice = new WaveOutEvent())
                {
                    waveOutDevice.Init(concatenatingProvider);
                    waveOutDevice.Volume = volumePercent / 100f;
                    waveOutDevice.Play();

                    var volumeControlThread = new Thread(() =>
                    {
                        while (waveOutDevice.PlaybackState == PlaybackState.Playing)
                        {
                            if (Console.KeyAvailable)
                            {
                                var key = Console.ReadKey(intercept: true).Key;
                                if (key == ConsoleKey.UpArrow)
                                {
                                    volumePercent = Math.Min(100, volumePercent + 10);
                                    waveOutDevice.Volume = volumePercent / 100f;
                                    Console.WriteLine($"\nVolume increased to: {volumePercent}%");
                                }
                                else if (key == ConsoleKey.DownArrow)
                                {
                                    volumePercent = Math.Max(0, volumePercent - 10);
                                    waveOutDevice.Volume = volumePercent / 100f;
                                    Console.WriteLine($"\nVolume decreased to: {volumePercent}%");
                                }
                            }
                        }
                    });
                    volumeControlThread.IsBackground = true;
                    volumeControlThread.Start();

                    for (int i = 0; i < audioFiles.Count; i++)
                    {
                        DisplayInfo(instrument, style, rollInfo[i].Phrase, rollInfo[i].Rolls, rollInfo[i].RollSum, audioFiles[i].FilePath);
                        Thread.Sleep((int)(audioFiles[i].Reader.TotalTime.TotalMilliseconds));
                    }
                }
            }
        }
    }
}
