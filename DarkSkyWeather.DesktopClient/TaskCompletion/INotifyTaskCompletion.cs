using System;
using System.Threading.Tasks;

namespace DarkSkyWeather.DesktopClient.TaskCompletion
{
    public abstract class NotifyTaskCompletionBase<TResult>
    {
        public Action<TResult> TaskCompleted;
        public Action<Exception> OnError;

        public abstract void Execute(Task<TResult> task);
    }
}
