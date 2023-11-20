using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using UnityEditor.Overlays;

public class DragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Image anImage;
    public GameObject textItemPrefab;
    public GameObject descItemPrefab;
    [HideInInspector] public Transform overallCanvas;
    [HideInInspector] public Transform lastParent;
    [HideInInspector] public GameObject newTitle;
    [HideInInspector] public GameObject newDescription;
    private InventorySystem aSystem;

    void Start()
    {
        aSystem = FindObjectOfType<InventorySystem>();
        if (aSystem == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        lastParent = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        anImage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(lastParent);
        anImage.raycastTarget = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        overallCanvas = transform.parent.transform.parent.transform.parent;
        newTitle = Instantiate(textItemPrefab, overallCanvas);
        newTitle.transform.position.Set(670, 330, 0);
        TextMeshProUGUI textPortion = newTitle.GetComponent<TextMeshProUGUI>();
        textPortion.text = transform.name;
        newTitle.SetActive(true);


        newDescription = Instantiate(descItemPrefab, overallCanvas);
        TextMeshProUGUI textDescPortion = newDescription.GetComponent<TextMeshProUGUI>();
        textDescPortion.text = aSystem.descriptions[transform.name];
        newDescription.SetActive(true);

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        newTitle.SetActive(false);
        newDescription.SetActive(false);
        Destroy(newTitle.gameObject);
        Destroy(newDescription.gameObject);
    }
}
