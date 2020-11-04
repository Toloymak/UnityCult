using System;
using System.Linq;
using Common.Components;
using Common.Enums;
using Leopotam.Ecs;
using UnityEngine;

namespace Common.Systems.Logging
{
    public class LogSystem: IEcsSystem, IEcsRunSystem, IEcsPreInitSystem
    {
        private EcsWorld _world = null;

        private LogComponent _logComponent;

        public void PreInit()
        {
            _logComponent = _world.NewEntity().Set<LogComponent>();
        }

        public void Run()
        {
            while (_logComponent.LogModels.Any())
            {
                var logModel = _logComponent.LogModels.First();
                
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

                _logComponent.LogModels.Remove(logModel);
            }
        }
    }
}