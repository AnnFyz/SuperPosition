using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabVisual : MonoBehaviour
{
    public static PrefabVisual Instance {get; private set;}
    [SerializeField] private Transform pfGridVisual;
    private SelectedTile selectedTile;


    private List<Transform> visualTileList;
    private Transform[,] visualTileArray;
    private Grid<MapGridObject> grid;
    private bool updateVisual;
    private void Awake() {
        Instance = this;
        visualTileList = new List<Transform>();     
    }
    public void Setup(Grid<MapGridObject> grid){
        this.grid = grid;
        visualTileArray = new Transform[grid.GetGridX(), grid.GetGridY()];
        for(int x= 0; x < grid.GetGridX(); x++){
            for(int y = 0; y < grid.GetGridY(); y++){
                Vector3 gridPosition = new Vector3(x,y) * grid.GetGridSize() + Vector3.one*grid.GetGridSize() *.5f + new Vector3(-50f, -10f); //GRID ORIGIN
                Transform visualTile = CreateVisualTile(gridPosition);
                visualTileArray[x,y] = visualTile;
                visualTileList.Add(visualTile);
            }
        }

        HideTileVisuals();
        UpdateVisual(grid);

        grid.OnGridObjectChanged += Grid_OnGridObjectChanged;
    }

    private void Update(){
        if(updateVisual){
            updateVisual = false;
            UpdateVisual(grid);
        }
    }

    private void Grid_OnGridObjectChanged(object sender, Grid<MapGridObject>.OnGridObjectChangedEventArgs e){
        updateVisual = true;
    }

    public void UpdateVisual (Grid<MapGridObject> grid){
        HideTileVisuals();

        for (int x = 0; x < grid.GetGridX(); x++) {
            for (int y = 0; y < grid.GetGridY(); y++) {
                MapGridObject gridObject = grid.GetGridObject(x, y);
                
                Transform visualTile = visualTileArray[x, y];
                visualTile.gameObject.SetActive(true);
                SetupVisualTile(visualTile, gridObject);
            }
        }
    }
    private void HideTileVisuals(){
        foreach (Transform visualTileTransform in visualTileList){
            visualTileTransform.gameObject.SetActive(false);
        }
    }

    private Transform CreateVisualTile(Vector3 position){
        Transform visualTileTranform = Instantiate(pfGridVisual, position, Quaternion.identity);
        return visualTileTranform;
    }
    //
    private void SetupVisualTile(Transform visualTileTransform, MapGridObject mapGridObject){
        SpriteRenderer hiddenTransform = visualTileTransform.Find("Tile").GetComponent<SpriteRenderer>();

        if(mapGridObject.IsRoom()){//deactive tile

            hiddenTransform.gameObject.SetActive(false);
            //backgroundTransform.gameObject.SetActive(true);
            switch (mapGridObject.GetGridType()) {
            default:
            case MapGridObject.Type.Room://if isRoom hide text and mineIcon
                //iconSpriteRenderer.gameObject.SetActive(false);
                //selectedTile.SetSelectedVisible(false);
                break;
            }
        }
        else{
             hiddenTransform.gameObject.SetActive(true);
             }//active tile

        }


    }


