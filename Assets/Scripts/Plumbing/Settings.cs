using System;
using UnityEngine;

namespace Plumbing {
    public static class Settings {
        public static void SetDefaultStyles(Font font){
            var f = new GUIStyle();
            f.normal.textColor = new Color(255, 132, 0, 255);
            f.fontSize = 25;
            f.font = font;

            //GUI.backgroundColor = new Color(34, 47, 223, 255);
            

            GUI.skin.label = f;
            GUI.skin.button = f;

            StylesSet = true;
        }

        public static bool StylesSet; 
    }
}