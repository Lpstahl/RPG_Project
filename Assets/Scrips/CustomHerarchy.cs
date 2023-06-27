using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using System;

[InitializeOnLoad]
public class CustomHerarchy : MonoBehaviour
{
    static CustomHerarchy()
    {
        EditorApplication.hierarchyWindowItemOnGUI += RenderObjects;
    }

    private static void RenderObjects(int instanceID, Rect selectionRect)
    {
        GameObject gameObject = EditorUtility.InstanceIDToObject(instanceID) as GameObject;

        if (gameObject == null) return;

        if (gameObject.TryGetComponent<CustomHeaderObjects>(out var customHeaderObjects))
        {
            EditorGUI.DrawRect(selectionRect, customHeaderObjects.backgroundColor);
            EditorGUI.LabelField(selectionRect, gameObject.name.ToUpper(), new GUIStyle()
            {
                alignment = TextAnchor.MiddleCenter,
                fontStyle = FontStyle.Bold,
                normal = new GUIStyleState() { textColor = customHeaderObjects.textColor }
            });
        }
    }
}
