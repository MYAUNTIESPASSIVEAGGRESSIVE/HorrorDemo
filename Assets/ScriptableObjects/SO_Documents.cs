using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu (fileName = "New Document", menuName = "Readable Document")]
public class SO_Documents : ScriptableObject
{
    public string DocumentName;
    public string DocumentType;

    public Sprite DocumentImage;

    public TextMeshPro DocumentText;

    public TextMeshPro ClearDocumentText;
}
