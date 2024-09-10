using UnityEngine.UI;

public class UiContainer
{
    private Toggle toggle;
    private UIImage image;

    public Toggle Toggle { get { return toggle; } }
    public UIImage Image { get { return image; } }

    public UiContainer(Toggle toggle, UIImage image)
    {
        this.toggle = toggle;
        this.image = image;
    }
}
