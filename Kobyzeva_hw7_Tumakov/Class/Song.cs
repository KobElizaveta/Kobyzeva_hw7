namespace Kobyzeva_hw7_Tumakov.Class
{
    internal class Song
    {
        public string Name { set; get; }

        public string Author { set; get; }

        public Song Prev { get; set; }

        public Song(string name, string author)
        {
            Name = name;
            Author = author;
            Prev = null;
        }
        public Song(string name, string author, Song prev)
        {
            Name = name;
            Author = author;
            Prev = prev;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Название - {Name}, исполнитель - {Author}");
        }

        public string Title()
        {
            return Name + "+" + Author;
        }

        public override bool Equals(object d)
        {
            try
            {
                Song PrevSong = (Song)d;
                if (PrevSong.Name == Name && PrevSong.Author == Author)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
