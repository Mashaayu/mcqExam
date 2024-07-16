using MCQExam.Server.Models;

namespace MCQExam.Server.Repository
{
    public interface IGenericRepo<T> where T : BaseEntity
    {
        public Task<List<T>> GetAllAsync();
        public Task<List<T>> DeleteByID(int id);
        public Task<T> GetByID(int id);
    } 
}
