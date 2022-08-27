using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTileMap : MonoBehaviour
{
 [SerializeField] private PrefabVisual prefabVisual;

    private Map map;
    //private bool isGameActive;

    private void Start()     
    {
        map = new Map();
        prefabVisual.Setup(map.GetGrid());//call grid setup
    }
}
    
