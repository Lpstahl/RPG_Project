using UnityEditor;
using UnityEngine;

public class CustomHeaderObjects : MonoBehaviour
{
    public Color textColor = Color.white;
    public Color backgroundColor = Color.red;

    private void OnValidate()
    {
        EditorApplication.RepaintHierarchyWindow();
    }
}
