using UnityEngine;

[System.Serializable]
public class Dialogue 
{
    public string name;
    public GameObject image;

    [TextArea(3,10)]
    public string[] sentences;
}
