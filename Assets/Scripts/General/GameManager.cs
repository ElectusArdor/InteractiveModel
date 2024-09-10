using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MenuController menuController;
    /// <summary>Сюда кидаем контейнер с объектами</summary>
    [SerializeField] private Transform objectsContainer;
    /// <summary>Регулятор прозрачности</summary>
    [SerializeField] private Slider slider;

    private List<GameObject> objects = new ();
    private Dictionary<string, Toggle> selectedObjects = new Dictionary<string, Toggle>();
    private Dictionary<string, UIImage> objectsVisibility = new Dictionary<string, UIImage>();

    private CameraController cc;

    private void Awake()
    {
        CollectData();

        MaterialEditor materialEditor = new MaterialEditor(menuController, objects, slider, selectedObjects);
        menuController.FillContent(objects, selectedObjects, objectsVisibility);
    }

    /// <summary>
    /// Собираем данные со всех объектов
    /// </summary>
    private void CollectData()
    {
        foreach (Transform t in objectsContainer.transform)
        {
            GameObject go = t.gameObject;
            objects.Add(go);
            selectedObjects.Add(go.name, null);
            objectsVisibility.Add(go.name, null);

            go.GetComponent<InteractiveObject>().NewPosition += UpdateCameraFocusPoint;
        }

        cc = Camera.main.GetComponent<CameraController>();
    }

    /// <summary>
    /// Задаём точку привязки камеры.
    /// </summary>
    /// <param name="newFocus">Точка привязки камеры</param>
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
