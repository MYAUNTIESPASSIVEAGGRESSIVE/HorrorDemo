using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Docuemnts", menuName = "Documents/DocumentReadable", order = 1)]
public class SO_Documents : ScriptableObject
{
    public string DocumentName;
    public enum DocType
    {
        Professional,
        Medical,
        Letter,
        Ripped
    }
    public DocType DocumentType;

    public string DocumentDesc;

    public Sprite DocumentBackground;
}
