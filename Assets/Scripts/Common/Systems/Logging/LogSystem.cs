using System;
using System.Linq;
using Common.Components;
using Common.Enums;
using Leopotam.Ecs;
using UnityEngine;

namespace Common.Systems.Logging
{
    public class LogSystem: BaseSystem, IEcsRunSystem
    {
        public void Run()
        {
            while (LogService.LogModels.Any())
            {
                var logModel = LogService.LogModels.First();
                
                switch (logModel.Level)
                {
                    case LogLevel.Debug:
                        Debug.Log(logModel.Message);
                        break;
                    case LogLevel.Info:
                        Debug.Log(logModel.Message);
                        break;
                    case LogLevel.Warning:
                        Debug.LogWarning(logModel.Message);
                        break;
                    case LogLevel.Error:
                        Debug.LogError(logModel.Message);
                        break;
                    case LogLevel.Fatal:
                        Debug.LogError(logModel.Message);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                if (logModel.Exception != null)
                    Debug.LogException(logModel.Exception);

                LogService.LogModels.Remove(logModel);
            }
        }
    }
}