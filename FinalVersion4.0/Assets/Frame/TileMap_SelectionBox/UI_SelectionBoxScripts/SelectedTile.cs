using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTile : MonoBehaviour
{
    private GameObject Tile;


    private void Awake()
    {
        Tile = transform.Find("Tile").gameObject;

        SetSelectedVisible(true);
    }

    public void SetSelectedVisible(bool visible)
    {
        Tile.SetActive(visible);
    }

}
