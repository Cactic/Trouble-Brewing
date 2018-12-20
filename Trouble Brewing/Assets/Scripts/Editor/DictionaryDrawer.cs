using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(OurSerilizableDictionaryAttribute))]
public class DictionaryDrawer : SerializableDictionaryPropertyDrawer {}