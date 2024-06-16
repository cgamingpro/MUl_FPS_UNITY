using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMangaer : MonoBehaviour
{
    public static MenuMangaer Instance;
    [SerializeField] MenuItem[] menuArray;

    public void Awake()
    {
        Instance = this; 
    }

    public void OpenMenustr(string menuName)
    {
        for (int i = 0; i < menuArray.Length; i++) 
        {
            if (menuArray[i].menunamestring == menuName)
            {
                OpenMenuobj(menuArray[i]);
            }
            else if (menuArray[i].isActiveAndEnabled)
            {
                CloseMenuobj(menuArray[i]);
            }
        }
    }
    public void OpenMenuobj(MenuItem menuObj)
    {
        
        for(int i = 0;i < menuArray.Length;i++) 
        {
            if (menuArray[i].isActiveAndEnabled)
            {
                CloseMenuobj(menuArray[i]);
            }
        }
        menuObj.SetMenuActive();
    }
    public void CloseMenuobj(MenuItem menu_obj) 
    {
        menu_obj.SetMenuInactive();
    }
}
