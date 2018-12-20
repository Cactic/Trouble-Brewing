using UnityEngine;

public class OurSerilizableDictionaryAttribute : PropertyAttribute
{
    public System.Type propType;
    public OurSerilizableDictionaryAttribute(System.Type aType)
    {
        propType = aType;
    }
}
