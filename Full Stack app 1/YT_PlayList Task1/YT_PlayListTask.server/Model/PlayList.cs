namespace YTPlaylist.Server.Model
{
    public class PlayList:BaseEntity
    {
        public string PlayListName { get; set; }
        public string Category { get; set; }
        ICollection<Video> Videos { get; set; } 
        public int CreatedById { get; set; }
        public DateTime CreateDate { get; set; }
        public int ModifiedById { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
