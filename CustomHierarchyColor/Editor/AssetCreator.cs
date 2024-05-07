#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace CustomHierarchyColor
{
    public static class AssetCreator
    {
        // �t�H���_�����݂��Ȃ��ꍇ�͍쐬���A�A�Z�b�g���쐬���܂��B
        public static void CreateAssetWithFolders<T>(string path) where T : ScriptableObject
        {
            // �p�X����t�H���_�\�����m�ۂ��܂��B
            EnsureFolderHierarchy(path);

            // �A�Z�b�g���쐬���܂��B
            T asset = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(asset, path);
            AssetDatabase.SaveAssets();

            // �쐬�����A�Z�b�g���G�f�B�^�őI�����܂��B
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = asset;
        }

        // �w�肳�ꂽ�p�X�ɕK�v�ȃt�H���_�\�����쐬���܂��B
        private static void EnsureFolderHierarchy(string path)
        {
            string[] folders = path.Split('/');

            // "Assets"�܂ł̃p�X���m�ۂ��܂��B
            string currentPath = "Assets";

            for (int i = 1; i < folders.Length - 1; i++) // �Ō�̗v�f�̓t�@�C�����Ȃ̂ŃX�L�b�v
            {
                currentPath = System.IO.Path.Combine(currentPath, folders[i]);

                // �t�H���_�����݂��Ȃ��ꍇ�͍쐬
                if (!AssetDatabase.IsValidFolder(currentPath))
                {
                    AssetDatabase.CreateFolder(System.IO.Path.GetDirectoryName(currentPath), System.IO.Path.GetFileName(currentPath));
                }
            }
        }
    }
}
#endif