using System;
using System.Collections.Generic;
using UI.Core.Windows;
using UnityEngine;

namespace UI.Core.Settings
{
    [Serializable]
    public class UISettings
    {
        [Serializable]
        public class WindowSettings
        {
            public WindowId WindowId;
            public GameObject WindowPrefab;
        }

        public List<WindowSettings> Windows;
    }
}