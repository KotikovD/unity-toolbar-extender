using UnityEditor;
using UnityEngine;
using UnityToolbarExtender;

namespace AutoChess.Editor
{
	internal static class ToolbarStyles
	{
		#region Constants
		public static readonly GUIStyle CommandButtonStyle;
		public static readonly GUIStyle LabelStyle;
		#endregion

		#region Constructors
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
		#endregion
	}

	[InitializeOnLoad]
	public class ToolBarTimeScaleSwitcher
	{
		#region Constructors
		static ToolBarTimeScaleSwitcher()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}
		#endregion

		#region Private Members
		private static void OnToolbarGUI()
		{
			if (!EditorApplication.isPlaying && !EditorApplication.isPaused || !TestUtilFunctions._instance)
			{
				return;
			}

			GUILayout.FlexibleSpace();

			GUILayout.Label(TestUtilFunctions._instance.myTimeScale.ToString(), ToolbarStyles.LabelStyle);
			GUILayout.Space(10);

			if (GUILayout.Button(new GUIContent("x0.2", "Set timescale * 0.2"), ToolbarStyles.CommandButtonStyle))
			{
				TestUtilFunctions._instance.myTimeScale *= 0.2f;
			}
			if (GUILayout.Button(new GUIContent("x0.5", "Set timescale * x0.5"), ToolbarStyles.CommandButtonStyle))
			{
				TestUtilFunctions._instance.myTimeScale *= 0.5f;
			}
			if (GUILayout.Button(new GUIContent("1", "Set timescale = 1"), ToolbarStyles.CommandButtonStyle))
			{
				TestUtilFunctions._instance.myTimeScale = 1f;
			}
			if (GUILayout.Button(new GUIContent("x2", "Set timescale * 2 "), ToolbarStyles.CommandButtonStyle))
			{
				TestUtilFunctions._instance.myTimeScale *= 2f;
			}
			if (GUILayout.Button(new GUIContent("x5", "Set timescale * 5"), ToolbarStyles.CommandButtonStyle))
			{
				TestUtilFunctions._instance.myTimeScale *= 5f;
			}

			GUILayout.Space(10);
		}
		#endregion
	}
}
