using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace III.Awaiter
{
    public class AsyncClass
    {

        public void MoveNet()
        {
            Task task = new Task(() => Console.WriteLine("task"));

            var task0 = Task.Run(() => Console.WriteLine("额外的task"));
            try
            {
                Action task1Run = task0.Start;

                Console.WriteLine("主线程开始");
                TaskAwaiter taskAwaiter1 = task.GetAwaiter();
                task0.GetAwaiter().AwaitUnsafeOnCompleted(ref taskAwaiter1, this);

                //ThreadPool.UnsafeQueueUserWorkItem(new WaitCallback(), false);
                Console.WriteLine("");
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void awaitTaskContinuation(object state)
        {
            throw new NotImplementedException();
        }
    }

    public static class TaskAwaiterrrr
    {

        public static void AwaitUnsafeOnCompleted(this TaskAwaiter taskAwaiter, ref TaskAwaiter taskAwaiter1, AsyncClass asyncClass)
        {
            //一是创建了一个Action，MoveNext方法的信息已经随着stateMachine被封装进去了。

            Action action =()=> { asyncClass.MoveNet(); };
            //二是把上面这个Action交给Awaiter，让它在await的操作完成后执行这个Action。
            taskAwaiter1.UnsafeOnCompleted(action);
        }



        //    [__DynamicallyInvokable, SecuritySafeCritical]
        //    public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(
        //ref TAwaiter awaiter, ref TStateMachine stateMachine)
        //where TAwaiter : ICriticalNotifyCompletion
        //where TStateMachine : IAsyncStateMachine
        //    {
        //        try
        //        {
        //            Action completionAction = this.m_coreState
        //                .GetCompletionAction<AsyncVoidMethodBuilder, TStateMachine>(ref this, ref stateMachine);
        //            awaiter.UnsafeOnCompleted(completionAction);
        //        }
        //        catch (Exception exception)
        //        {
        //            AsyncMethodBuilderCore.ThrowAsync(exception, null);
        //        }
        //    }
    }
}

