using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Colorable))]
[CanEditMultipleObjects]
public class ColorableEditor : Editor
{
  private readonly string lable = "My Color";
  int drawCount = 0;

  public override void OnInspectorGUI()
  {
    FoldoutAttempt();
  }

  private void BaseChangeColor()
  {
    drawCount++;
    Colorable myTarget = target as Colorable;

    Color currentColor = myTarget.GetComponent<MeshRenderer>().material.color;

    currentColor = EditorGUILayout.ColorField(lable, currentColor);
    currentColor.a = EditorGUILayout.Slider("Transparency", currentColor.a, 0.0F, 1.0F);

    myTarget.GetComponent<MeshRenderer>().material.color = currentColor;

    EditorGUILayout.LabelField(drawCount.ToString());
  }

  bool ShowColorEditing;

  private void FoldoutAttempt()
  {
    ShowColorEditing = EditorGUILayout.Foldout(ShowColorEditing, lable);
    if (ShowColorEditing)
    {
      if (Selection.activeTransform)
      {
        drawCount++;
        Colorable myTarget = target as Colorable;

        Color currentColor = myTarget.GetComponent<MeshRenderer>().material.color;

        currentColor = EditorGUILayout.ColorField(lable, currentColor);
        currentColor.a = EditorGUILayout.Slider("Transparency", currentColor.a, 0.0F, 1.0F);

        myTarget.GetComponent<MeshRenderer>().material.color = currentColor;
      }
    }

    EditorGUILayout.LabelField(drawCount.ToString());
  }

}
