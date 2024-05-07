#if UNITY_EDITOR
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace CustomHierarchyColor
{

    [InitializeOnLoad]
    public class CustomHierarchyColor
    {
        public const string SETTING_FILE_PATH = "Assets/Editor/CustomHierarchyColor/HierarchyColorSettings.asset";

        private static HierarchyColorScriptable hierarchyColorScriptable;

        static CustomHierarchyColor()
        {
            RefreshSetting();
            EditorApplication.hierarchyWindowItemOnGUI += OnHierarchyWindowItemOnGUI;
        }

        public async static void RefreshSetting()
        {
            hierarchyColorScriptable = AssetDatabase.LoadAssetAtPath<HierarchyColorScriptable>(SETTING_FILE_PATH);

            await Task.Delay(100);

            if (hierarchyColorScriptable == null)
            {
                Debug.LogError("[HierarchyColorBeforeName] Can't find setting file.\n Create assets in the [ Figse/Hierarchy Color Settings ] window.");
                return;
            }
        }


        private static void OnHierarchyWindowItemOnGUI(int instanceID, Rect selectionRect)
        {
            GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;
            if (gameObject == null) return;

            if (TryGetFormattedName(gameObject.name, out string formattedName, out Color color, out Color fontColor))
            {
                // colorが透けるとオブジェクトの元の名前が見えちゃうから、強制的に1にする
                color.a = 1;

                EditorGUI.DrawRect(selectionRect, color);

                // GUIStyleのインスタンスを作成し、フォントサイズとフォントスタイルを変更
                var style = new GUIStyle(GUI.skin.label) { fontSize = 12, fontStyle = FontStyle.Bold };

                style.normal.textColor = fontColor;

                style.alignment = TextAnchor.MiddleCenter;

                EditorGUI.LabelField(selectionRect, formattedName, style);
            }
        }

        private static bool TryGetFormattedName(string originalName, out string formattedName, out Color backGroundColor, out Color fontColor)
        {
            formattedName = originalName;
            backGroundColor = Color.white;
            fontColor = Color.black;
            if (hierarchyColorScriptable == null) return false;
            foreach (var pair in hierarchyColorScriptable.hierarchyColorKeyPairs)
            {
                if (string.IsNullOrEmpty(pair.key)) continue;

                if (originalName.Contains(pair.key))
                {
                    formattedName = originalName.Replace(pair.key, "");
                    backGroundColor = pair.backGroundColor;
                    fontColor = pair.fontColor;
                    return true;
                }
            }
            return false;
        }
    }
}
#endif