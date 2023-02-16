using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace UnityToolbarExtender.Editor
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
		
		static ToolBarTimeScaleSwitcher()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}
		
		private static void OnToolbarGUI()
		{
			if (!EditorApplication.isPlaying && !EditorApplication.isPaused)
				return;

			GUILayout.FlexibleSpace();
			GUILayout.Label(Time.timeScale.ToString("#.###"), ToolbarStyles.LabelStyle);
			GUILayout.Space(10);

			if (GUILayout.Button(new GUIContent("x0.2", "Set timescale * 0.2"), ToolbarStyles.CommandButtonStyle))
			{
				Time.timeScale = Mathf.Clamp(Time.timeScale * 0.2f, _minTimeScale, _maxTimeScale);
			}
			if (GUILayout.Button(new GUIContent("x0.5", "Set timescale * x0.5"), ToolbarStyles.CommandButtonStyle))
			{
				Time.timeScale = Mathf.Clamp(Time.timeScale * 0.5f, _minTimeScale, _maxTimeScale);
			}
			if (GUILayout.Button(new GUIContent("1", "Set timescale = 1"), ToolbarStyles.CommandButtonStyle))
			{
				Time.timeScale = 1f;
			}
			if (GUILayout.Button(new GUIContent("x2", "Set timescale * 2 "), ToolbarStyles.CommandButtonStyle))
			{
				Time.timeScale = Mathf.Clamp(Time.timeScale * 2f, _minTimeScale, _maxTimeScale);
			}
			if (GUILayout.Button(new GUIContent("x5", "Set timescale * 5"), ToolbarStyles.CommandButtonStyle))
			{
				Time.timeScale = Mathf.Clamp(Time.timeScale * 5f, _minTimeScale, _maxTimeScale);
			}

			GUILayout.Space(10);
		}
	}
}
