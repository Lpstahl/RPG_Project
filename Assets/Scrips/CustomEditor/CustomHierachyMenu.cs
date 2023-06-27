using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CustomHierachyMenu : EditorWindow
{
    [MenuItem("GAmeObject/Create Custom Header")]

    static void CreateCustomHeader(MenuCommand _menuCommand)
    {
        GameObject obj = new GameObject("Header");
        Undo.RegisterCreatedObjectUndo(obj, "Create Custom Header");

        GameObjectUtility.SetParentAndAlign(obj, _menuCommand.context as GameObject);
        obj.AddComponent<CustomHeaderObjects>();
        Selection.activeObject = obj;
    }
}
