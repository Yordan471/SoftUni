namespace MusicHub
{
    using System;
    using System.Data.Entity;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here

            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            string formatReleaseDate = "MM/dd/yyyy";

            var albums = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    a.Name,
                    ReleaseDate = a.ReleaseDate.ToString(formatReleaseDate),
                    ProducerName = a.Producer.Name,
                    a.Price,
                    Songs = a.Songs.Select(s => new
                    {
                        s.Name,
                        s.Price,
                        WriterName = s.Writer.Name
                    })  
                            
                            .OrderByDescending(s => s.Name)
                            .ThenBy(s => s.WriterName)
                            .ToList()
                })
                .ToList();

            StringBuilder sb = new();

            foreach (var album in albums.OrderByDescending(a => a.Price))
            {
                int countSongs = 0;

                sb.AppendLine($"-AlbumName: {album.Name}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");

                foreach (var song in album.Songs)
                {
                    countSongs++;

                    sb.AppendLine($"---#{countSongs}");
                    sb.AppendLine($"---SongName: {song.Name}");
                    sb.AppendLine($"---Price: {song.Price:F2}");
                    sb.AppendLine($"---Writer: {song.WriterName}");
                }

                sb.AppendLine($"-AlbumPrice: {album.Price:F2}");
            }

            return sb.ToString().TrimEnd();
            //throw new NotImplementedException();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(duration);

            var songs = context.Songs
                .Where(s => s.Duration > timeSpan)
                .Select(s => new
                {
                    s.Name,
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duratiom = s.Duration,
                    PerformersNames = s.SongPerformers.Select(ps => new {ps.Performer.FirstName, ps.Performer.LastName }).ToList()                                
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .AsEnumerable();

            StringBuilder sb = new();

            int countSongs = 0;

            foreach (var song in songs)
            {
                countSongs++;

                sb.AppendLine($"-Song #{countSongs}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                if (song.PerformersNames.Any())
                {
                    foreach( var performer in song.PerformersNames
                        .OrderBy(s => s.FirstName)
                        .ThenBy(s => s.LastName))
                    {
                        sb.AppendLine($"---Performer: {performer.FirstName} {performer.LastName}");
                    }
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duratiom}");
            }


            return sb.ToString().TrimEnd();

            //throw new NotImplementedException();
        }
    }
}
