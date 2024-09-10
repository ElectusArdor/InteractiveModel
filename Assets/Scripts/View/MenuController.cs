using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private Image sliderBG;

    [SerializeField] private List<Text> texts;
    [SerializeField] private List<Toggle> toggles;
    [SerializeField] private List<UIImage> eyes;
    [SerializeField] private List<InputField> fields;
    [SerializeField] private RectTransform contentRT, menuPanelRT;
    [SerializeField] private InputField inputField;
    [SerializeField] private int pixDeltaHeight = 75;

    private bool allSelected = false;
    private bool allVisible = true;

    void Start()
    {
        foreach (UIImage eye in eyes)
        {
            SetImgProperties(eye, true);
        }

        foreach (Text text in texts)
        {
            text.enabled = true;
        }
    }

    public void SetImgProperties(UIImage img, bool eyeOn)
    {
        img.color = img.Colors[eyeOn];
        img.Colored = eyeOn;
    }

    public void OnShowBtnClick()
    {
        if (menu.activeSelf)
            menu.SetActive(false);
        else menu.SetActive(true);
    }

    public void OnOffAllEyes()
    {
        allVisible = !allVisible;
        for (int i = 0; i < eyes.Count; i++)
        {
            SetImgProperties(eyes[i], allVisible);
        }
    }

    public void OnOffAllToggles()
    {
        allSelected = !allSelected;
        foreach (Toggle toggle in toggles)
        {
            toggle.isOn = allSelected;
        }
    }

    public void SetSliderBgTransparency(float alpha)
    {
        Color color = sliderBG.material.color;
        color.a = 0.2f + alpha * 0.8f;
        sliderBG.material.color = color;
    }

    public void FillContent(List<GameObject> objects, Dictionary<string, Toggle> selectedObjects, Dictionary<string, UIImage> objectsVisibility)
    {
        foreach (GameObject go in objects)
        {
            if (go == null) continue;
            UiContainer uc = AddInputField(go.name);
            selectedObjects[go.name] = uc.Toggle;
            objectsVisibility[go.name] = uc.Image;
        }
    }

    private UiContainer AddInputField(string name)
    {
        int deltaHeight = pixDeltaHeight * fields.Count;
        FitHeight(deltaHeight);

        InputField iField = Instantiate(inputField);
        RectTransform rt = iField.GetComponent<RectTransform>();
        rt.SetParent(contentRT, false);
        rt.localPosition = new Vector3(260, -45 - deltaHeight, 0);

        iField.text = name;

        Toggle toggle = rt.transform.GetChild(2).gameObject.GetComponent<Toggle>();
        UIImage img = rt.transform.GetChild(3).gameObject.GetComponent<UIImage>();

        fields.Add(iField);
        texts.Add(rt.transform.GetChild(1).gameObject.GetComponent<Text>());
        toggles.Add(toggle);
        eyes.Add(img);

        return new UiContainer(toggle, img);
    }

    // На случай необходимости удалить объекты
    private void RemoveFields(List<int> indexses)
    {
        foreach(int i in indexses)
        {
            Destroy(fields[i].gameObject);
            fields.RemoveAt(i);
            texts.RemoveAt(i);
            toggles.RemoveAt(i);
            eyes.RemoveAt(i);
            FitHeight(75 * (fields.Count - 1));
        }
    }

    private void FitHeight(int deltaHeight)
    {
        if (deltaHeight > 510)
            menuPanelRT.sizeDelta = new Vector2(600, 800);
        else
            menuPanelRT.sizeDelta = new Vector2(600, 290 + deltaHeight);
        contentRT.sizeDelta = new Vector2(520, 135 + deltaHeight);
    }
}
