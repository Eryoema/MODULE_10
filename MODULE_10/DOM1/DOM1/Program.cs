using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DOM1
{
    public class TV
    {
        public void On()
        {
            Console.WriteLine("Телевизор включен.");
        }

        public void Off()
        {
            Console.WriteLine("Телевизор выключен.");
        }

        public void SetChannel(int channel)
        {
            Console.WriteLine($"Телевизор переключен на канал {channel}.");
        }

        public void SetAudioInput()
        {
            Console.WriteLine("Аудиовход на телевизоре установлен.");
        }
    }

    public class AudioSystem
    {
        public void On()
        {
            Console.WriteLine("Аудиосистема включена.");
        }

        public void Off()
        {
            Console.WriteLine("Аудиосистема выключена.");
        }

        public void SetVolume(int volume)
        {
            Console.WriteLine($"Громкость аудиосистемы установлена на {volume}.");
        }
    }

    public class DVDPlayer
    {
        public void Play()
        {
            Console.WriteLine("Воспроизведение DVD начато.");
        }

        public void Pause()
        {
            Console.WriteLine("Воспроизведение DVD приостановлено.");
        }

        public void Stop()
        {
            Console.WriteLine("Воспроизведение DVD остановлено.");
        }
    }

    public class GameConsole
    {
        public void On()
        {
            Console.WriteLine("Игровая консоль включена.");
        }

        public void PlayGame(string game)
        {
            Console.WriteLine($"Запуск игры: {game}.");
        }
    }

    public class HomeTheaterFacade
    {
        private TV tv;
        private AudioSystem audioSystem;
        private DVDPlayer dvdPlayer;
        private GameConsole gameConsole;

        public HomeTheaterFacade(TV tv, AudioSystem audioSystem, DVDPlayer dvdPlayer, GameConsole gameConsole)
        {
            this.tv = tv;
            this.audioSystem = audioSystem;
            this.dvdPlayer = dvdPlayer;
            this.gameConsole = gameConsole;
        }

        public void WatchMovie()
        {
            tv.On();
            audioSystem.On();
            dvdPlayer.Play();
            tv.SetAudioInput();
            Console.WriteLine("Настройка для просмотра фильма завершена.\n");
        }

        public void EndMovie()
        {
            dvdPlayer.Stop();
            audioSystem.Off();
            tv.Off();
            Console.WriteLine("Система выключена.\n");
        }

        public void PlayGame(string game)
        {
            tv.On();
            gameConsole.On();
            gameConsole.PlayGame(game);
            Console.WriteLine("Игровая консоль готова к использованию.\n");
        }

        public void ListenToMusic(int volume)
        {
            tv.On();
            audioSystem.On();
            audioSystem.SetVolume(volume);
            tv.SetAudioInput();
            Console.WriteLine("Настройка для прослушивания музыки завершена.\n");
        }

        public void SetVolume(int volume)
        {
            audioSystem.SetVolume(volume);
        }
    }

    public class Program
    {
        public static void Main()
        {
            TV tv = new TV();
            AudioSystem audioSystem = new AudioSystem();
            DVDPlayer dvdPlayer = new DVDPlayer();
            GameConsole gameConsole = new GameConsole();

            HomeTheaterFacade homeTheater = new HomeTheaterFacade(tv, audioSystem, dvdPlayer, gameConsole);

            homeTheater.WatchMovie();
            homeTheater.SetVolume(15);
            homeTheater.EndMovie();

            homeTheater.PlayGame("Super Mario");

            homeTheater.ListenToMusic(20);
        }
    }
}
