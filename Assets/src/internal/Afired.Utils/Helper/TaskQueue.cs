using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Afired.Utils.Helper {
    
    /// <summary>
    /// task based "event callback" that can be either async or sync awaited when invoked
    /// </summary>
    public class TaskQueue {
        
        private Queue<Func<Task>> _queuedTaskFunctions;
        
        
        public TaskQueue() {
            _queuedTaskFunctions = new Queue<Func<Task>>();
        }
        
        /// <summary>
        /// invokes all queued tasks sequential
        /// </summary>
        public async Task InvokeSequential() {
            while(_queuedTaskFunctions.Count > 0) {
                await _queuedTaskFunctions.Dequeue().Invoke();
            }
        }
        
        /// <summary>
        /// invokes all queued tasks parallel
        /// </summary>
        public async Task InvokeParallel() {
            List<Task> tasks = new List<Task>();
            while(_queuedTaskFunctions.Count > 0) {
                tasks.Add(_queuedTaskFunctions.Dequeue().Invoke());
            }
            await Task.WhenAll(tasks);
        }
        
        public static TaskQueue operator +(TaskQueue taskQueue, Func<Task> taskFunction) {
            taskQueue.Add(taskFunction);
            return taskQueue;
        }
        
        /// <summary>
        /// adds a task to the task queue
        /// </summary>
        public void Add(Func<Task> taskFunction) {
            _queuedTaskFunctions.Enqueue(taskFunction);
        }
        
        /// <summary>
        /// clears all queued tasks
        /// </summary>
        public void Clear() {
            _queuedTaskFunctions.Clear();
        }

    }
    
}
