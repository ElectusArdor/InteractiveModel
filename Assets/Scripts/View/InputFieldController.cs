using UnityEngine;
using UnityEngine.UI;

public class InputFieldController : MonoBehaviour
{
    public UIImage img;
    public Text text;

    private void Start()
    {
        img.Colored = true;
    }

    public void OnEyeClick()
    {
        img.Colored = !img.Colored;
        ChangeColor(img.Colored);
    }

    private void ChangeColor(bool eyeOn)
    {
        img.color = img.Colors[eyeOn];
        img.Colored = eyeOn;
    }
}
