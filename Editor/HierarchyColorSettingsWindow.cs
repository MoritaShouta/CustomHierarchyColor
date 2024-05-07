#if UNITY_EDITOR

using UnityEditor;
using UnityEngine;
namespace CustomHierarchyColor
{
    public class HierarchyColorSettingsWindow : EditorWindow
    {
        [MenuItem("Figse/Hierarchy Color Settings")]
        public static void ShowWindow()
        {
            GetWindow<HierarchyColorSettingsWindow>("Hierarchy Color Settings");
        }

        void OnGUI()
        {
            GUILayout.Label("Hierarchy Color Settings", EditorStyles.boldLabel);

            bool assetExists = AssetDatabase.LoadAssetAtPath<HierarchyColorScriptable>(CustomHierarchyColor.SETTING_FILE_PATH) != null;

            EditorGUI.BeginDisabledGroup(assetExists);
            if (GUILayout.Button("Create HierarchyColorSettings Asset"))
            {
                AssetCreator.CreateAssetWithFolders<HierarchyColorScriptable>(CustomHierarchyColor.SETTING_FILE_PATH);

            }
            EditorGUI.EndDisabledGroup();

            if (GUILayout.Button("Refresh"))
            {
                CustomHierarchyColor.RefreshSetting();
                Debug.Log("[Hierarchy Color Settings] Refresh");
            }
        }
    }
}
#endif