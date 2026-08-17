using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;



[CustomPropertyDrawer(typeof(DrawScriptableObjectAttribute))]
// [DrawScriptableObjectAttribute] on a variable to show the ScriptableObject drawer
public class ScriptableObjectDrawer : PropertyDrawer
{
    private static int recursionDepth = 0;
    private const int MAX_RECURSION_DEPTH = 100;
    private const int indentation = 12;
    public override void OnGUI(Rect dataPosition, SerializedProperty dataSerializedProperty, GUIContent dataLabel)
    {
        if(dataSerializedProperty == null) return;

        ScriptableObject dataScriptableObject = dataSerializedProperty.objectReferenceValue as ScriptableObject;
        Rect propertyFieldRect = new Rect(dataPosition);
        Rect foldoutBodyRect;
        Rect contentsRect;
        GUIContent foldoutGUIContent = new GUIContent(dataLabel);
        string key = $"ScriptableObjectDrawer_{dataScriptableObject.GetEntityId()}";
        bool isExpanded = EditorPrefs.GetBool(key,false);

        if(dataScriptableObject == null)
        // if the Scriptable Object is null, display the field normally
        {
            EditorGUI.PropertyField(dataPosition, dataSerializedProperty, dataLabel);
            return;
        }

        propertyFieldRect.height = EditorGUIUtility.singleLineHeight;
        EditorGUI.PropertyField(propertyFieldRect, dataSerializedProperty, dataLabel);

        foldoutBodyRect = new Rect(propertyFieldRect);
        foldoutBodyRect.height = EditorGUIUtility.singleLineHeight;
        foldoutBodyRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
        foldoutGUIContent.text += " contents";
        isExpanded = EditorGUI.Foldout(foldoutBodyRect, isExpanded, foldoutGUIContent);
        EditorPrefs.SetBool(key, isExpanded);

        if(isExpanded)
        {
            contentsRect = new Rect(foldoutBodyRect);
            contentsRect.y += EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
            DrawScriptableObjectContents(contentsRect, dataSerializedProperty, dataLabel);
        }
    }

    public void DrawScriptableObjectContents(Rect position, SerializedProperty serializedProperty, GUIContent label)
    {
        ScriptableObject scriptableObject = serializedProperty.objectReferenceValue as ScriptableObject;
        SerializedObject serializedObject = new SerializedObject(scriptableObject);
        SerializedProperty fieldProperty;

        ScriptableObjectDrawer.recursionDepth++;
        position.x += indentation;
        position.width -= indentation;

        if(ScriptableObjectDrawer.recursionDepth > ScriptableObjectDrawer.MAX_RECURSION_DEPTH)
        {
            throw new StackOverflowException("Scriptable object recursion overflow.");
        }

        if(serializedProperty.objectReferenceValue == null)
        // If the serializedProperty is null, display it as normal
        {
            EditorGUI.PropertyField(position, serializedProperty, label);
            return;
        }

        foreach(FieldInfo field in AnalyzeFields(scriptableObject))
        {
            fieldProperty = serializedObject.FindProperty(field.Name);
            if(fieldProperty == null) continue;

            position.height = EditorGUI.GetPropertyHeight(fieldProperty, true);

            if(typeof(ScriptableObject).IsAssignableFrom(field.FieldType))
            {
                DrawScriptableObjectContents(position, fieldProperty, label);
            }
            else EditorGUI.PropertyField(position, fieldProperty, true);

            position.y += position.height + EditorGUIUtility.standardVerticalSpacing;
        }

        serializedObject.ApplyModifiedProperties();
        ScriptableObjectDrawer.recursionDepth--;
    }

    public override float GetPropertyHeight(SerializedProperty serializedProperty, GUIContent label)
    {
        ScriptableObject scriptableObject = serializedProperty.objectReferenceValue as ScriptableObject;
        if(scriptableObject == null) return EditorGUIUtility.singleLineHeight;
        float drawerHeight = (EditorGUIUtility.singleLineHeight * 2) + (EditorGUIUtility.standardVerticalSpacing * 2);
        SerializedObject serializedObject = new SerializedObject(scriptableObject);
        SerializedProperty fieldProperty;
        string key = $"ScriptableObjectDrawer_{scriptableObject.GetEntityId()}";
        bool isExpanded = EditorPrefs.GetBool(key, false);

        if(isExpanded)
        {
            foreach(FieldInfo field in AnalyzeFields(scriptableObject))
            {
                fieldProperty = serializedObject.FindProperty(field.Name);
                if(fieldProperty == null) {
                    drawerHeight += EditorGUIUtility.standardVerticalSpacing;
                    continue;
                }
                drawerHeight += EditorGUI.GetPropertyHeight(fieldProperty, true) + EditorGUIUtility.standardVerticalSpacing;
            }
        }

        return drawerHeight;
    }

    public List<FieldInfo> AnalyzeFields(ScriptableObject scriptableObject)
    {
        List<FieldInfo> result = new List<FieldInfo>();
        Type type = scriptableObject.GetType();
        FieldInfo[] fields = type.GetFields(
            System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance
        );

        foreach(FieldInfo field in fields)
        {
            if(field.GetCustomAttribute<NonSerializedAttribute>() != null) continue;

            if(field.IsPublic) result.Add(field);

            if(!field.IsPublic && field.GetCustomAttribute<SerializeField>() != null) result.Add(field);
        }

        return result;
    }



}


