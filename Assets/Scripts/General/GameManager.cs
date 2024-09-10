using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MenuController menuController;
    [SerializeField] private Transform objectsContainer;
    [SerializeField] private Slider slider;

    private List<GameObject> objects = new ();
    private Dictionary<string, Toggle> selectedObjects = new Dictionary<string, Toggle>();
    private Dictionary<string, UIImage> objectsVisibility = new Dictionary<string, UIImage>();

    private CameraController cc;

    private void Awake()
    {
        foreach (Transform t in objectsContainer.transform)
        {
            GameObject go = t.gameObject;
            objects.Add(go);
            selectedObjects.Add(go.name, null);
            objectsVisibility.Add(go.name, null);

            go.GetComponent<InteractiveObject>().NewPosition += UpdateCameraFocusPoint;
        }

        MaterialEditor materialEditor = new MaterialEditor(menuController, objects, slider, selectedObjects);

        menuController.FillContent(objects, selectedObjects, objectsVisibility);

        cc = Camera.main.GetComponent<CameraController>();
    }

    private void UpdateCameraFocusPoint(Vector3 newFocus)
    {
        cc.FocusPoint = newFocus;
    }

    private void Update()
    {
        foreach (GameObject go in objects)
        {
            go.SetActive(objectsVisibility[go.name].Colored);
        }    
    }
}
