using System.Collections.Generic;
using System.Threading.Tasks;

namespace VideoAppCore.Models
{
    /// <summary>
    /// [4][3][2] 리포지토리 클래스(비동기 방식): Full ORM인 EF Core를 사용하여 CRUD 구현
    /// </summary>
    public class VideoRepositoryEfCoreAsync : IVideoRepositoryAsync
    {
        public Task<Video> AddVideoAsync(Video model)
        {
            throw new System.NotImplementedException();
        }

        public Task<Video> GetVideoByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Video>> GetVideosAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveVideoAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Video> UpdateVideoAsync(Video model)
        {
            throw new System.NotImplementedException();
        }
    }
}
