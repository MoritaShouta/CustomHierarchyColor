#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CustomHierarchyColor
{
    public static class AssetCreator
    {
        // フォルダが存在しない場合は作成し、アセットを作成します。
        public static void CreateAssetWithFolders<T>(string path) where T : ScriptableObject
        {
            // パスからフォルダ構造を確保します。
            EnsureFolderHierarchy(path);

            // アセットを作成します。
            T asset = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();

            // 作成したアセットをエディタで選択します。
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        // 指定されたパスに必要なフォルダ構造を作成します。
        private static void EnsureFolderHierarchy(string path)
        {
            string[] folders = path.Split('/');

            // "Assets"までのパスを確保します。
            string currentPath = "Assets";

            for (int i = 1; i < folders.Length - 1; i++) // 最後の要素はファイル名なのでスキップ
            {
                currentPath = System.IO.Path.Combine(currentPath, folders[i]);

                // フォルダが存在しない場合は作成
                if (!AssetDatabase.IsValidFolder(currentPath))
                {
                    AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(currentPath), System.IO.Path.GetFileName(currentPath));
                }
            }
        }
    }
}
#endif