using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItem : MonoBehaviour
{
    public string menunamestring;
    public bool isActiveMenu;

    public void SetMenuActive()
    {
        isActiveMenu = true;
        gameObject.SetActive(true);
    }
    public void SetMenuInactive() 
    {
        isActiveMenu = false;
        gameObject.SetActive(false);
    }
}
