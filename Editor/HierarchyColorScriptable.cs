#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using UnityEngine;
namespace CustomHierarchyColor
{
    [CreateAssetMenu(fileName = "HierarchyColorSettings", menuName = "HierarchyColorSettings", order = 1)]
    public class HierarchyColorScriptable : ScriptableObject
    {
        [SerializeField]
        public List<HierarchyColorKeyPair> hierarchyColorKeyPairs = new List<HierarchyColorKeyPair>();
    }

    [Serializable]
    public class HierarchyColorKeyPair
    {
        public string key = "";
        public Color backGroundColor = Color.white;
        public Color fontColor = Color.black;
    }
}
#endif