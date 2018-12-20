using UnityEngine;
using UnityEditor;
using System.Collections;

// TODO:
// comments.



public static class EditorExtension
{
    public static int CustomBitMaskFieldDrawer(Rect aPosition, int aMask, System.Type aType, GUIContent aLabel, ref bool foldout)
    {
        var itemNames = System.Enum.GetNames(aType);
        var itemValues = System.Enum.GetValues(aType) as int[];
        int rows = itemValues.Length + 1;

        int val = aMask;

        if (GUI.Button(new Rect(aPosition.width- 160, aPosition.y, 80,16), "Set all to off"))
        {
            return 0;
        }
        if (GUI.Button(new Rect(aPosition.width - 70, aPosition.y, 80,16), "Set all to on"))
        {
            for (int i = 0; i < itemValues.Length; i++)
            {
                val |= 1 << i;
            }
            return val;
        }

        foldout = EditorGUI.Foldout(new Rect(aPosition.x, aPosition.y, aPosition.width, 16), foldout, aLabel);
        if (foldout)
        {

            for (int i = 0; i < itemValues.Length; i++)
            {
                if (EditorGUI.ToggleLeft(new Rect(8 + aPosition.x, aPosition.y + (aPosition.height / rows) * (i + 1), aPosition.width, aPosition.height / rows), itemNames[i], (val & 1 << i) != 0))
                {
                    val |= itemValues[i];
                }
                else
                {
                    val &= ~itemValues[i];
                }
            }
        }
        return val;
    }
}

[CustomPropertyDrawer(typeof(BitMaskAttribute))]
public class EnumBitMaskPropertyDrawer : PropertyDrawer
{
    [SerializeField]
    bool foldout = false;
    int[] itemValues;
    
    public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
    {
        var typeAttr = attribute as BitMaskAttribute;
        // Add the actual int value behind the field name

        label.text = label.text + "(" + prop.intValue + ")";
        itemValues = System.Enum.GetValues(typeAttr.propType) as int[];
        prop.intValue = EditorExtension.CustomBitMaskFieldDrawer(position, prop.intValue, typeAttr.propType, label, ref foldout);
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return base.GetPropertyHeight(property, label) * (foldout ? itemValues.Length : 1) + 10;  // assuming original is one row
    }
}