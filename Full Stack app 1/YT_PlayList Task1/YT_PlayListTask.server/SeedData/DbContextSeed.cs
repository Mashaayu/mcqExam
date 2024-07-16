using Microsoft.EntityFrameworkCore.Metadata.Internal;
using YTPlaylist.Server.Context;
using YTPlaylist.Server.Model;

namespace YTPlaylist.Server.SeedData
{
    public class DbContextSeed
    {
        public static async Task AddSeedData(YTPlayListDbContext dbContext)
        {
            Video video1 = new Video() { 

                Title = "01_Day_JavaScript_Refresher",
                VideoURL = "https://www.youtube.com/watch?v=100pKUE3OPI",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "1050 views",
                EmbedURL = "https://www.youtube.com/embed/100pKUE3OPI"
            };
            Video video2 = new Video()
            {

                Title = "02_Day_Introduction_to_React",
                VideoURL = "https://www.youtube.com/watch?v=TeeAp5zkYnI",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "700 views",
                EmbedURL = "https://www.youtube.com/embed/TeeAp5zkYnI"
            };
            Video video3 = new Video()
            {

                Title = "React Components",
                VideoURL = "https://www.youtube.com/watch?v=NJ_qbsLf52w",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "121 views",
                EmbedURL = "https://www.youtube.com/embed/NJ_qbsLf52w"
            };
            Video video4 = new Video()
            {

                Title = "React Props Day 4_react",
                VideoURL = "https://www.youtube.com/watch?v=kHJSNFU7H4U",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "99 views",
                EmbedURL = "https://www.youtube.com/embed/kHJSNFU7H4U"
            };
            Video video5 = new Video()
            {

                Title = "React states Day 5 tutorial for beginner",
                VideoURL = "https://www.youtube.com/watch?v=K0q-8ytGlVA",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "456 views",
                EmbedURL = "https://www.youtube.com/embed/K0q-8ytGlVA"
            };
            Video video6 = new Video()
            {

                Title = "09_Day_Conditional_Rendering",
                VideoURL = "https://www.youtube.com/watch?v=74nEOGolDhI",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "6786 views",
                EmbedURL = "https://www.youtube.com/embed/74nEOGolDhI"
            };
            Video video7 = new Video()
            {

                Title = "React Project Folder Structure",
                VideoURL = "https://www.youtube.com/watch?v=UUga4-z7b6s",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "9067 views",
                EmbedURL = "https://www.youtube.com/embed/UUga4-z7b6s"
            };
            Video video8 = new Video()
            {

                Title = "13_Day_Controlled_Versus_Uncontrolled_Input",
                VideoURL = "https://www.youtube.com/watch?v=ecY3QSxZZYY",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "452 views",
                EmbedURL = "https://www.youtube.com/embed/ecY3QSxZZYY"
            };
            Video video9 = new Video()
            {

                Title = "React Component LifeCycle tutorial for beginner",
                VideoURL = "https://www.youtube.com/watch?v=yHdX4dCl5CY",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "55 views",
                EmbedURL = "https://www.youtube.com/embed/yHdX4dCl5CY"
            };
            Video video10 = new Video()
            {

                Title = "React Higher Order Component ",
                VideoURL = "https://www.youtube.com/watch?v=B6aNv8nkUSw",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "21 views",
                EmbedURL = "https://www.youtube.com/embed/B6aNv8nkUSw"
            };
            Video video11 = new Video()
            {

                Title = "React Router in just 45 minutes",
                VideoURL = "https://www.youtube.com/watch?v=Ul3y1LXxzdU",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "3213 views",
                EmbedURL = "https://www.youtube.com/embed/Ul3y1LXxzdU"
            };
            Video video12 = new Video()
            {

                Title = "React fetch and axios boilerplate",
                VideoURL = "https://www.youtube.com/watch?v=PmPkAAu_QF4",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "0567 views",
                EmbedURL = "https://www.youtube.com/embed/PmPkAAu_QF4"
            };
            Video video13 = new Video()
            {

                Title = "React Introducing Hooks in 9 minutes only",
                VideoURL = "https://www.youtube.com/watch?v=O6P86uwfdR0",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "97 views",
                EmbedURL = "https://www.youtube.com/embed/O6P86uwfdR0"
            };

            Video video14 = new Video()
            {

                Title = "React tutorial for beginners",
                VideoURL = "https://www.youtube.com/watch?v=O6P86uwfdR0",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "32321 views",
                EmbedURL = "https://www.youtube.com/embed/O6P86uwfdR0"
            };
            Video video15 = new Video()
            {

                Title = "React  Fetching Data Using Hooks",
                VideoURL = "https://www.youtube.com/watch?v=Vspeudp-M9k",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "1261 views",
                EmbedURL = "https://www.youtube.com/embed/Vspeudp-M9k"
            };
            Video video16 = new Video()
            {

                Title = "React create custom hooks in just 9 min",
                VideoURL = "https://www.youtube.com/watch?v=6ThXsUwLWvc",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "6746 views",
                EmbedURL = "https://www.youtube.com/embed/6ThXsUwLWvc"
            };
            Video video17 = new Video()
            {

                Title = "React Course - Beginner's Tutorial for React.js",
                VideoURL = "https://www.youtube.com/watch?v=bMknfKXIFA8",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "291 views",
                EmbedURL = "https://www.youtube.com/embed/bMknfKXIFA8"
            };
            Video video18 = new Video()
            {

                Title = "React History : How A Small Team of Developers Created React at Facebook",
                VideoURL = "https://www.youtube.com/watch?v=8pDqJVdNa44",
                thumbnailImage = "../../../assets/thumbnail.png",
                ChannelImage = "../../../assets/channel_Image.png",
                ChannelName = "Code Shef",
                ChannelURL = "https://www.youtube.com/channel/UC7PNRuno1rzYPb1xLa4yktw",
                views = "1121 views",
                EmbedURL = "https://www.youtube.com/embed/8pDqJVdNa44"
            };

            await dbContext.AddRangeAsync(video1, video2, video3, video4,video5, video6, video7,video8, video9, video10, video11, video12, video13, video14, video15, video16, video17, video18);
            await dbContext.SaveChangesAsync();


        }
    }
}
