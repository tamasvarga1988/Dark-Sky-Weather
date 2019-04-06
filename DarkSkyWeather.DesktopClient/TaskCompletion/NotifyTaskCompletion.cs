using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace DarkSkyWeather.DesktopClient.TaskCompletion
{
    // based on: https://msdn.microsoft.com/en-us/magazine/dn605875.aspx

    public sealed class NotifyTaskCompletion<TResult> : NotifyTaskCompletionBase<TResult>, INotifyPropertyChanged
    {
        public override void Execute(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
            }
            else
            {
                CompleteTask(task);
            }
        }

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            catch
            {
            }

            CompleteTask(task);
        }

        private void CompleteTask(Task task)
        {
            var propertyChanged = PropertyChanged;

            propertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCompleted"));
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsNotCompleted"));

            if (task.IsCanceled)
            {
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsCanceled"));
                OnError?.Invoke(InnerException);
            }
            else if (task.IsFaulted)
            {
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsFaulted"));
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs("Exception"));
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs("InnerException"));
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs("ErrorMessage"));
                OnError?.Invoke(InnerException);
            }
            else
            {
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsSuccessfullyCompleted"));
                propertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
                TaskCompleted?.Invoke(Task.Result);
            }
        }
        
        public Task<TResult> Task { get; private set; }
        public TResult Result
        {
            get
            {
                return (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult);
            }
        }
        public TaskStatus Status { get { return Task.Status; } }
        public bool IsCompleted { get { return Task.IsCompleted; } }
        public bool IsNotCompleted { get { return !Task.IsCompleted; } }
        public bool IsSuccessfullyCompleted
        {
            get
            {
                return Task.Status == TaskStatus.RanToCompletion;
            }
        }
        public bool IsCanceled { get { return Task.IsCanceled; } }
        public bool IsFaulted { get { return Task.IsFaulted; } }
        public AggregateException Exception { get { return Task.Exception; } }
        public Exception InnerException
        {
            get
            {
                return (Exception == null) ? null : Exception.InnerException;
            }
        }
        public string ErrorMessage
        {
            get
            {
                return (InnerException == null) ? null : InnerException.Message;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;        
    }
}