using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map{
    private Grid<MapGridObject> grid;
    public float gridSize = 0.75f;
    public Map(){
        grid = new Grid<MapGridObject>(55,50, gridSize, new Vector3(-50,-50), (Grid<MapGridObject> g, int x, int y) => new MapGridObject(g, x, y));      //SET GRID SIZE
    }
    public Grid<MapGridObject> GetGrid(){
        return grid;
    }
    public MapGridObject.Type RevealGridPosition(Vector3 worldPosition) {
        MapGridObject mapGridObject = grid.GetGridObject(worldPosition);
        return RevealGridPosition(mapGridObject);
    }
    public MapGridObject.Type RevealGridPosition(MapGridObject mapGridObject) {
        if (mapGridObject == null) return MapGridObject.Type.Room;
        // Reveal this object
        mapGridObject.Reveal();
        return mapGridObject.GetGridType();
    }
    public void SelectedGridPosition(Vector3 worldPosition){
        MapGridObject mapGridObject = grid.GetGridObject(worldPosition);
        if(mapGridObject != null){
            mapGridObject.SetSelectedVisible();
        }
    }
}