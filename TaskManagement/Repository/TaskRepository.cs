using TaskManagement.Data;
using TaskManagement.Models;

namespace TaskManagement.Repository
{
    public class TaskRepository : ITaskRepository<Tasks>
    {
        public readonly ApplicationDbContext _db;

        public TaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void CreateTask(Tasks task)
        {
            if (task != null)
            {
                var newTask=new Tasks{
                    Title = task.Title,
                    Description = task.Description,
                    Status = task.Status,
                    DueDate = task.DueDate
                    
                };
                _db.Tasks.Add(newTask);
                _db.SaveChanges();
            }
           
            
            
           
        }

        public void DeleteTask(int id)
        {
          var task=  _db.Tasks.Find(id);
            if(task != null)
            {
                _db.Tasks.Remove(task); 
            }
            _db.SaveChanges();
        }

        public IEnumerable<Tasks> GetAll()
        {
            var taskList= _db.Tasks.ToList();
            return taskList;
            
        }

        public Tasks GetTask(int id)
        {
            var tasks= _db.Tasks.Find(id);
            if(tasks != null)
            {
                return tasks;
            }
            else
            {
                throw new Exception($"Task with id {id} not found.");

            }
          
           
        }

        public void UpdateTask(Tasks task)
        {
            _db.Tasks.Update(task);
            _db.SaveChanges();
            
        }
    }
}
