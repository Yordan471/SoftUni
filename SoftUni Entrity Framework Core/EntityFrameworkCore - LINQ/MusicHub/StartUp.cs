namespace MusicHub
{
    using System;
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
            throw new NotImplementedException();
        }
    }
}
