using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTile : MonoBehaviour
{
    private GameObject Tile;


    private void Start()
    {
        Tile = transform.Find("Tile").gameObject;

        SetSelectedVisible(true);
    }

    public void SetSelectedVisible(bool visible)
    {
        if (Tile == null)
            return;

        Tile.SetActive(visible);
    }

}
