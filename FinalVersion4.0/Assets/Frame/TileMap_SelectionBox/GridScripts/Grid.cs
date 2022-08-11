using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class Grid<TGridObject>{
    public event EventHandler<OnGridObjectChangedEventArgs> OnGridObjectChanged;

    public class OnGridObjectChangedEventArgs : EventArgs{
        public int x;
        public int y;
    }

    private int gridX;
    private int girdY;
    private float gridSize;
    private Vector3 originPosition;
    private TGridObject[,] gridArray;

    public Grid(int gridX, int girdY, float gridSize, 
    Vector3 originPosition, Func<Grid<TGridObject>, int, int, TGridObject> createGridObject){
        this.gridX = gridX;
        this.girdY = girdY;
        this.gridSize = gridSize;
        this.originPosition = originPosition;

        gridArray = new TGridObject[gridX, girdY];
        //draw grid map with grid object
        for(int x = 0; x < gridArray.GetLength(0); x++){
            for(int y = 0; y < gridArray.GetLength(1); y++){
                gridArray[x,y] = createGridObject(this, x, y);
            }
        }
        ////////////////////////////////Debug
        bool showDebug = false;
        if (showDebug) {
            TextMesh[,] debugTextArray = new TextMesh[gridX, girdY];

            for (int x = 0; x < gridArray.GetLength(0); x++) {
                for (int y = 0; y < gridArray.GetLength(1); y++) {
                    debugTextArray[x, y] = UtilsClass.CreateWorldText(gridArray[x, y]?.ToString(), null, GetWorldPosition(x, y) + new Vector3(gridSize, gridSize) * .5f, 30, Color.white, TextAnchor.MiddleCenter);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white, 100f);
                    Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white, 100f);
                }
            }
            Debug.DrawLine(GetWorldPosition(0, girdY), GetWorldPosition(gridX, girdY), Color.white, 100f);
            Debug.DrawLine(GetWorldPosition(gridX, 0), GetWorldPosition(gridX, girdY), Color.white, 100f);

            OnGridObjectChanged += (object sender, OnGridObjectChangedEventArgs eventArgs) => {
                debugTextArray[eventArgs.x, eventArgs.y].text = gridArray[eventArgs.x, eventArgs.y]?.ToString();
            };
        }
}

    public int GetGridX(){
        return gridX;
    }
    public int GetGridY(){
        return girdY;
    }
    public float GetGridSize(){
        return gridSize;
    }
    public Vector3 GetWorldPosition(int x, int y){
        return new Vector3(x,y) * gridSize + originPosition;
    }
    public void GetXY(Vector3 worldPosition, out int x, out int y){
        x = Mathf.FloorToInt((worldPosition - originPosition).x/gridSize);
        y = Mathf.FloorToInt((worldPosition - originPosition).y/gridSize);
    }

    public void SetGridObject(int x, int y, TGridObject value){
        if(x>=0 && y >=0 && x < gridX && y < girdY){
            gridArray[x,y] = value;
            TriggerGridObjectChanged(x,y);
        }
    }
    public void TriggerGridObjectChanged(int x, int y){
        OnGridObjectChanged?.Invoke(this, new OnGridObjectChangedEventArgs {x = x, y = y});
    }
    public void SetGridObject(Vector3 worldPosition, TGridObject value){
        GetXY(worldPosition, out int x, out int y);
        SetGridObject(x, y, value);
    }

    public TGridObject GetGridObject(int x, int y){
        if(x >=0 && y >= 0 && x < gridX & y < girdY){
            return gridArray[x,y];
        } else{
            return default(TGridObject);
        }
    }
    public TGridObject GetGridObject(Vector3 worldPosition){
        int x,y;
        GetXY(worldPosition, out x, out y);
        return GetGridObject(x,y);
    }

}