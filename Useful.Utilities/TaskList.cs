using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Useful.Utilities
{
    /// <summary>
    /// Provides functions for running async work.
    /// </summary>
    public class TaskList
    {
        private readonly int _maxThreads = 50;
        private readonly SemaphoreSlim _maxThreadSlim;
        private readonly List<Task> _asyscTasks;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskList"/> class with a max thread count of 50.
        /// </summary>
        public TaskList()
        {
            _maxThreadSlim = new SemaphoreSlim(_maxThreads);
            _asyscTasks = new List<Task>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskList"/> class with a limited number of threads.
        /// </summary>
        /// <param name="threads">The number of threads to limit.</param>
        public TaskList(int threads)
        {
            _maxThreads = threads;
            _maxThreadSlim = new SemaphoreSlim(_maxThreads);
            _asyscTasks = new List<Task>();
        }

        /// <summary>
        /// Adds the task to the list. If a thread is available work starts right away 
        /// otherwise it waits for a thread then starts
        /// </summary>
        /// <param name="work">The action to run.</param>
        public void AddTask(Action work)
        {
            _maxThreadSlim.Wait();
            _asyscTasks.Add(Task.Factory.StartNew(work).ContinueWith(task => _maxThreadSlim.Release()));
        }
        /// <summary>
        /// Waits for all tasks in the list to finish. Then clears the lists
        /// </summary>
        public void WaitForAll()
        {
            Task.WaitAll(_asyscTasks.ToArray());
            _asyscTasks.Clear();
        }
        /// <summary>
        /// Gets all the tasks in the list.
        /// </summary>
        public List<Task> Tasks
        {
            get { return _asyscTasks; }
        }

        /// <summary>
        /// Runs the specified work.
        /// If work action threw an error and error action is provided, 
        /// it will be called before the after action.
        /// If after action is provided, it is ran once the work action is done.
        /// The after action is passed true if work completed successfully, false if work faulted.
        /// After and error actions are ran in the Current Synchronization Context (usually the UI thread)
        /// </summary>
        /// <param name="work">The work to the run.</param>
        /// <param name="after">The action to run after work is complete.</param>
        /// <param name="error">The on error action if work faulted</param>
        /// <returns></returns>
        public static Task Run(Action work, Action<bool> after = null, Action<Exception> error = null)
        {
            var task = Task.Factory.StartNew(work.Invoke).ContinueWith(t =>
                {
                    if (!t.IsFaulted) return true;
                    if (t.IsFaulted && error != null && t.Exception != null)
                        error(t.Exception.Flatten());
                    return false;
                }, TaskScheduler.FromCurrentSynchronizationContext())
                 .ContinueWith(t =>
                 {
                     if (after != null) after(t.Result);
                     return t.Result;

                 }, TaskScheduler.FromCurrentSynchronizationContext());

            return task;
        }


        /// <summary>
        /// Runs the specified work.
        /// If work action threw an error and error action is provided, 
        /// it will be called before the after action.
        /// If after action is provided, it is ran once the work action is done.
        /// The after action is passed the result of work action if it was successful.
        /// If work action faulted, after action will be passed the default of <see cref="T"/>.
        /// After and error actions are ran in the Current Synchronization Context (usually the UI thread)
        /// </summary>
        /// <typeparam name="T">Type returned from work function and input to after action</typeparam>
        /// <param name="work">The work function to run</param>
        /// <param name="after">The after action to run</param>
        /// <param name="error">The on error action if work faulted</param>
        /// <returns></returns>
        public static Task<T> Run<T>(Func<T> work, Action<T> after = null, Action<Exception> error = null)
        {
            var task = Task.Factory.StartNew<T>(work.Invoke).ContinueWith(t =>
                 {
                     if (!t.IsFaulted) return t.Result;
                     if (t.IsFaulted && error != null && t.Exception != null)
                         error(t.Exception.Flatten());
                     return default(T);
                 }, TaskScheduler.FromCurrentSynchronizationContext())
                 .ContinueWith(t =>
                 {
                     if (after != null) after(t.Result);
                     return t.Result;

                 }, TaskScheduler.FromCurrentSynchronizationContext());

            return task;

        }

    }
}
