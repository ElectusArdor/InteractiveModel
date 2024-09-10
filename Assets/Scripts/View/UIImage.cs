using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Extended class Image with property "colored" and color map
/// </summary>
public class UIImage : Image
{
    private Color colorOff = new Color(0.75f, 0.75f, 0.75f, 1);
    private Color colorOn = new Color(0f, 0f, 0.5f, 1);

    public Dictionary<bool, Color> Colors { get; private set; }
    public bool Colored { get; set; }

    protected new void Awake()
    {
        base.Awake();
        Colors = new Dictionary<bool, Color>() { { true, colorOn }, { false, colorOff } };
    }
}
