using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Docuemnts", menuName = "Documents/DocumentReadable", order = 1)]
public class SO_Documents : ScriptableObject
{
    public string DocName;

    public string DocType;

    public string DocDesc;

    public Sprite DocBackground;
}
