using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MaterialEditor
{
    private MenuController mc;
    private List<GameObject> gameObjects;
    private Slider slider;
    private Dictionary<string, Toggle> selected;

    private Dictionary<string, MeshRenderer> meshRenderers = new Dictionary<string, MeshRenderer>();

    public MaterialEditor(MenuController mc, List<GameObject> goList, Slider slider, Dictionary<string, Toggle> selected)
    {
        this.mc = mc;
        this.gameObjects = goList;
        this.slider = slider;
        this.selected = selected;

        foreach (GameObject obj in gameObjects)
        {
            meshRenderers.Add(obj.name, obj.GetComponent<MeshRenderer>());
        }

        slider.onValueChanged.AddListener(delegate { SetTransparency(); });
    }

    private void SetTransparency()
    {
        foreach (string mr in meshRenderers.Keys)
        {
            if (meshRenderers[mr] != null & selected[mr].isOn)
            {
                Color color = meshRenderers[mr].material.color;
                color.a = slider.value;
                meshRenderers[mr].material.color = color;
            }
        }
        mc.SetSliderBgTransparency(slider.value);
    }
}
