using CommandQueue.Domain.Azure;
using CommandQueue.Domain.Interfaces;
using Microsoft.WindowsAzure.ServiceRuntime;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;

namespace CommandQueue.Worker
{
    public class WorkerRole : RoleEntryPoint
    {
        public override void Run()
        {
            var queue = new Queue();
            var commandInterface = typeof(ICommand);

            // NOTE: If no reference is made to the CommandQueue.Domain assembly in this class the following query won't find the classes that implement ICommand.
            var commandTypes = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                                from type in assembly.GetTypes() 
                                where (commandInterface.IsAssignableFrom(type)) && (commandInterface != type) select type).ToList();

            while (true)
            {
                try
                {
                    foreach (var commandType in commandTypes)
                    {
                        var message = queue.GetMessage(commandType.Name, 4);

                        if (message != null)
                        {
                            dynamic command = JsonConvert.DeserializeObject(message.AsString, commandType);
                            command.Execute();

                            queue.DeleteMessage(commandType.Name, message);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Trace.TraceError(exception.Message);
                }

                Thread.Sleep(1000);
            }
        }

        public override bool OnStart()
        {
            ServicePointManager.DefaultConnectionLimit = 12;

            return base.OnStart();
        }
    }
}
