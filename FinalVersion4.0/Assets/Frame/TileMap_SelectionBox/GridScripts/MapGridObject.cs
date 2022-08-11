using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGridObject{
    public enum Type{
        Room,
        Tile,
        SelectedTile,
        UnselectedTile,
        //Portal,
    }
    private Grid<MapGridObject> grid;
    private int x;
    private int y;
    private Type type;
    private bool isPlayerInside;
    private bool isTile;
    private bool isSelected;
    private bool isRoom;
    private bool isConnected;
    //private bool isCancled;

    //grid setting
    public MapGridObject(Grid<MapGridObject> grid, int x, int y){
        this.grid = grid;
        this.x = x;
        this.y = y;
        type = Type.Room;
        isRoom = false;
    }
    public int GetX() => x;
    public int GetY() => y;

    public Type GetGridType(){
        return type;
    }
    public void SetGridType(Type type){
        this.type = type;
    } 
    public void Reveal() {
        isRoom = true;
        grid.TriggerGridObjectChanged(x, y);
    }
    public bool IsRoom(){
        return isRoom;
    } 
    public bool IsSelected(){
        return isSelected;
    }  
    public void SetSelectedVisible(){
        isSelected = true;
        grid.TriggerGridObjectChanged(x,y);
    }
}