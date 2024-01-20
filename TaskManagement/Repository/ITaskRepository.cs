namespace TaskManagement.Repository
{
    public interface ITaskRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetTask(int id);
        public void CreateTask(T task);
        public void DeleteTask(int id); 
        public void UpdateTask(T task);

    }
}
