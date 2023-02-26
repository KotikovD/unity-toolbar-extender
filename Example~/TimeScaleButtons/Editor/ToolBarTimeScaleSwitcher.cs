@@ -0,0 +1,72 @@
using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace UnityToolbarExtender.Examples
{
    internal static class ToolbarStyles
    {
        public static readonly GUIStyle CommandButtonStyle;
        public static readonly GUIStyle LabelStyle;
		
        static ToolbarStyles()
        {
            CommandButtonStyle = new GUIStyle("Command")
            {
                fontSize = 11,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.ImageAbove,
                fontStyle = FontStyle.Bold
            };
	
            LabelStyle = new GUIStyle("Label")
            {
                fontSize = 14,
                alignment = TextAnchor.MiddleCenter,
                imagePosition = ImagePosition.TextOnly,
                fontStyle = FontStyle.Bold
            };
        }
    }

    [InitializeOnLoad]
    public class ToolBarTimeScaleSwitcher
    {
        private const float _maxTimeScale = 100;
        private const float _minTimeScale = 0.001f;
        private const float _upMultiplier = 5f;
        private const float _downMultiplier = 0.25f;

        static ToolBarTimeScaleSwitcher()
        {
            ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
        }
		
        private static void OnToolbarGUI()
        {
            if (!EditorApplication.isPlaying && !EditorApplication.isPaused)
            	return;

            GUILayout.FlexibleSpace();
            var text = Time.timeScale < 1
                ? Time.timeScale.ToString("F3")
                : Time.timeScale.ToString("N1");
            GUILayout.Label(text, ToolbarStyles.LabelStyle);
            GUILayout.Space(10);

            if (GUILayout.Button(new GUIContent($"x{_downMultiplier}", $"Set timescale * {_downMultiplier}"), ToolbarStyles.CommandButtonStyle))
                SetTimeScale(_downMultiplier);

            if (GUILayout.Button(new GUIContent("1", "Set timescale = 1"), ToolbarStyles.CommandButtonStyle))
                SetTimeScale(1f / Time.timeScale);

            if (GUILayout.Button(new GUIContent($"x{_upMultiplier}", $"Set timescale * {_upMultiplier}"), ToolbarStyles.CommandButtonStyle))
                SetTimeScale(_upMultiplier);
        }

        private static void SetTimeScale(float value)
        {
            Time.timeScale = Mathf.Clamp(Time.timeScale * value, _minTimeScale, _maxTimeScale);
        }
    }
}