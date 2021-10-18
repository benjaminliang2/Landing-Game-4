using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldSelectionDropdownMenu : MonoBehaviour
{
    [SerializeField] Canvas earthCanvas;
    [SerializeField] Canvas marsCanvas;
    Dropdown worldDropdownMenu;
    public Text worldName;

    private void Awake()
    {
        //worldDropdownMenu = gameObject.GetComponent<Dropdown>().GetComponent<Dropdown>();
        worldDropdownMenu = gameObject.GetComponentInChildren<Dropdown>();
        Debug.LogError(worldDropdownMenu);
        worldDropdownMenu.onValueChanged.AddListener(delegate { DropDownMenuValueChanged(worldDropdownMenu); });


    }
    private void Start()
    {
        earthCanvas.enabled = true;
        marsCanvas.enabled = false;
        //worldDropdownMenu = GetComponent<Dropdown>();
        //worldDropdownMenu.onValueChanged.AddListener(delegate { DropDownMenuValueChanged(worldDropdownMenu); });
    }
    private void Update()
    {

        //Debug.LogError(worldDropdownMenu.value);
        //Debug.LogError(worldName.text);
    }
    void DropDownMenuValueChanged(Dropdown change)
    {
        Debug.Log(change.value);
        if (change.value == 0)
        {
            earthCanvas.enabled = true;
            marsCanvas.enabled = false;

        }
        if (change.value == 1)
        {
            earthCanvas.enabled = false;
            marsCanvas.enabled = true;
        }
    }
}
