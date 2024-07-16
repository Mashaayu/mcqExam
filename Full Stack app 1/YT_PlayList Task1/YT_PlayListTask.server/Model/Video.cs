namespace YTPlaylist.Server.Model
{
    public class Video:BaseEntity
    {
        public string Title { get; set; }   
        public string VideoURL { get; set; }
        public string thumbnailImage { get; set; }
        public string ChannelImage { get; set; }
        public string views { get; set; }
        public string ChannelName { get; set; }
        public string ChannelURL { get; set; }
        public string EmbedURL { get; set; }
    }
}
