using System.Collections.Generic;
using System.Globalization;
using Common.Consts;
using Leopotam.Ecs;
using UnityEngine;
using UnityEngine.UI;

namespace Common.Systems.Logging
{
    public class FpsSystem : BaseSystem, IEcsRunSystem
    {
        private Text _fpsText;
        
        public void Run()
        {
            if (_fpsText == null)
            {
                _fpsText = GameObject.Find(UiObjectNames.FpsText).GetComponent<Text>();
            }

            _fpsText.text = (1.0f / Time.smoothDeltaTime).ToString("F1");
        }
    }
}