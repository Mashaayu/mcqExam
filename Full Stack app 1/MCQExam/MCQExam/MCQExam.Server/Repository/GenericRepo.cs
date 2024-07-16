using MCQExam.Server.Context;
using MCQExam.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace MCQExam.Server.Repository
{
    public class GenericRepo <T>:IGenericRepo<T> where T : BaseEntity
    {
        private readonly MCQExamDbContext dbContext;

        public GenericRepo(MCQExamDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            T data = await dbContext.Set<T>().FirstAsync(x=>x.Id == id);
            return data;
        }

        public async Task<List<T>> DeleteByID(int id)
        {

            T data = await dbContext.Set<T>().FirstAsync(x => x.Id == id);
            
            await dbContext.SaveChangesAsync();
         
            try
            {
                 dbContext.Set<T>().Remove(data);
            }
            catch (ArgumentNullException arn)
            {
                Console.WriteLine(arn.Message);
            }
            catch(InvalidOperationException op)
            {
                Console.WriteLine(op.Message);
            }
            return await dbContext.Set<T>().ToListAsync();
        }
    }
}
