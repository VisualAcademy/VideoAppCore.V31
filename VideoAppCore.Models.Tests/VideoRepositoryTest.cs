using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace VideoAppCore.Models.Tests
{
    [TestClass]
    public class VideoRepositoryTest
    {
        [TestMethod]
        public async Task AddVideoAsyncMethodTest()
        {
            // DbContextOptions 생성
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>().UseInMemoryDatabase(databaseName: "AddVideo").Options;

            // 컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                // 리포지토리 개체 생성
                var repository = new VideoRepositoryEfCoreAsync(context);
                var video = new Video { Title = "제목", Url = "URL", Company = "Hawaso", Name = "박용준" };
                await repository.AddVideoAsync(video);
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                Assert.AreEqual(1, context.Videos.Count());
                Assert.AreEqual("URL", context.Videos.Single().Url);
            }
        }

        [TestMethod]
        public async Task GetVideosAsyncMethodTest()
        {
            // DbContextOptions 생성
            // DbContextOptionsBuilder를 사용하여 인-메모리 데이터베이스 정보를 DbContext에 전달
            var options = new DbContextOptionsBuilder<VideoDbContext>().UseInMemoryDatabase(databaseName: "GetVideos").Options;

            // 컨텍스트 개체 생성
            using (var context = new VideoDbContext(options))
            {
                var video1 = new Video { Title = "제목", Url = "URL", Company = "Hawaso", Name = "박용준" };
                context.Videos.Add(video1);
                var video2 = new Video { Title = "제목", Url = "URL", Company = "Hawaso", Name = "김태영" };
                context.Videos.Add(video2);
                var video3 = new Video { Title = "제목", Url = "URL", Company = "Hawaso", Name = "한상훈" };
                context.Videos.Add(video3);
                context.SaveChanges();
            }

            using (var context = new VideoDbContext(options))
            {
                var repository = new VideoRepositoryEfCoreAsync(context);
                var videos = await repository.GetVideosAsync();
                Assert.AreEqual(3, videos.Count());
                Assert.AreEqual("김태영", videos.Where(v => v.Id == 2).FirstOrDefault()?.Name);
            }
        }
    }
}
