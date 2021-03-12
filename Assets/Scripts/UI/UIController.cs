using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public TowerScript[] towers;
    public GameObject[] menuSegments;
    private List<GameObject> towersInMenu = new List<GameObject>();
    public List<SpriteRenderer> iconHolders;
    void Start()
    {
        if (towers.Length == 4 && menuSegments.Length == 4)
        {   
            for (int i = 0; i < 4; i++)
            {
                iconHolders[i].sprite = towers[i].icon;
                //menuSegments[i].setIcon(towers[i].icon);
            }
        }
    }
    public GameObject getTower(int index)
    {
       Debug.Log(index);
       for (int i = 0; i < menuSegments.Length; i++)
        {
            towersInMenu.Add(towers[i].tower);
        }
        return towersInMenu[index];
    }

}
