﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Kerbal_Mechanics
{
    class StyleManager
    {
        static StyleManager instance;

        Dictionary<string, GUIStyle> styles;

        public static bool IsInitialized
        {
            get
            {
                return (instance != null);
            }
        }

        StyleManager()
        {
            styles = new Dictionary<string, GUIStyle>();

            ScreenMessages sm = (ScreenMessages)GameObject.FindObjectOfType(typeof(ScreenMessages));

            GUIStyle upperLeftRed = new GUIStyle(sm.textStyles[0]);
            upperLeftRed.normal.textColor = Color.red;
            styles.Add("Upper Left - Red", upperLeftRed);
        }

        public static void Initialize()
        {
            if (instance == null)
            {
                instance = new StyleManager();
                Logger.DebugLog("Style Manager STARTED.");
            }
        }

        public static GUIStyle GetStyle(string name)
        {
            if (IsInitialized)
            {
                return instance.styles[name];
            }
            else
            {
                Initialize();
                return GetStyle(name);
            }
        }
    }
}
