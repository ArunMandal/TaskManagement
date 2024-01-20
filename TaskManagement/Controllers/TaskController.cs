using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.Threading.Tasks;
using TaskManagement.Models;
using TaskManagement.Repository;

namespace TaskManagement.Controllers
{

    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskRepository<Tasks> _taskRepository;

        public TaskController(ITaskRepository<Tasks> taskRepository)
        {
            _taskRepository = taskRepository;
        }


        // GET: TaskController
        public ActionResult Index()
        {
            var taskList= _taskRepository.GetAll();
            return View(taskList);
        }

        // GET: TaskController/Details/5
        public ActionResult Details(int id)
        {
            var task = _taskRepository.GetTask(id);
            return View(task);
        }

        // GET: TaskController/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: TaskController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Don't set the TaskId here; let the database handle it
                    _taskRepository.CreateTask(task);
                }

                TempData["alertmessage"] = "Task created successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                ModelState.AddModelError(string.Empty, "An error occurred while creating the task.");
                return View();
            }
        }


        // GET: TaskController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var task = _taskRepository.GetTask(id);
                return View(task);

            }
            catch (Exception ex)
            {
                return View();
            }
            
        }

        // POST: TaskController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tasks task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _taskRepository.UpdateTask(task);
                   
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TaskController/Delete/5
        public ActionResult Delete(int id)
        {
          var task=  _taskRepository.GetTask(id);
            return View(task);
        }

        // POST: TaskController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Tasks task)
        {
            try
            {
                _taskRepository.DeleteTask(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
