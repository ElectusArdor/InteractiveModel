using UnityEngine;
using UnityEngine.UI;

public class CheckBoxFogConrol : MonoBehaviour
{
    private Image img;

    void Start()
    {
        img = GetComponent<Image>();
    }

    public void SetAlpha(float a)
    {
        img.color = new Color(1, 1, 1, a);
    }
}
