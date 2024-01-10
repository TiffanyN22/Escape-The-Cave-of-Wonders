using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tilemap background;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile hiddenPaperStandInteractableTile;
    [SerializeField] private Tile hiddenStreamInteractableTile;
    [SerializeField] private Tile hiddenPaintingInteractableTile;
    [SerializeField] private Tile hiddenHourglassInteractableTile;
    [SerializeField] private Tile hiddenTraderInteractableTile;
    [SerializeField] private Tile hiddenGobletStandInteractableTile;
    [SerializeField] private Tile hiddenBorderRockInteractableTile;
    [SerializeField] private Tile hiddenSpecialRockStandInteractableTile;

    [SerializeField] private Tile hiddenRedGemInteractableTile;
    [SerializeField] private Tile hiddenBlueGemInteractableTile;
    [SerializeField] private Tile hiddenGreenGemInteractableTile;
    [SerializeField] private Tile hiddenPurpleGemInteractableTile;
    [SerializeField] private Tile brokenRockTile;
    [SerializeField] private Tile redGemTile; //TODO: update
    [SerializeField] private Tile greenGemTile;
    [SerializeField] private Tile blueGemTile;
    [SerializeField] private Tile purpleGemTile;
    [SerializeField] private Tile emptyGemTile;

    [SerializeField] List<Tile> shadowWallTile;
    [SerializeField] List<Tile> darkShadowWallTile;

    void Start()
    {
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {
            TileBase tile = interactableMap.GetTile(position);
            if (tile != null){ 
                switch(tile.name){
                    case "Interactable_Visible":
                        interactableMap.SetTile(position, hiddenInteractableTile);
                        break;
                    case "Paper_Stand_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenPaperStandInteractableTile);
                        break;
                    case "Stream_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenStreamInteractableTile);
                        break;
                    case "Painting_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenPaintingInteractableTile);
                        break;
                    case "Hourglass_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenHourglassInteractableTile);
                        break;
                    case "Trader_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenTraderInteractableTile);
                        break;
                    case "Goblet_Stand_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenGobletStandInteractableTile);
                        break;
                    case "Border_Rock_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenBorderRockInteractableTile);
                        break;
                    case "Special_Rock_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenSpecialRockStandInteractableTile);
                        break;
                    case "Red_Gem_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenRedGemInteractableTile);
                        break;
                    case "Blue_Gem_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenBlueGemInteractableTile);
                        break;
                    case "Green_Gem_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenGreenGemInteractableTile);
                        break;
                    case "Purple_Gem_Interactable_Visible":
                        interactableMap.SetTile(position, hiddenPurpleGemInteractableTile);
                        break;
                }
            }
        }
    }

    //public bool IsInteractable(Vector3Int position)
    //{
    //    TileBase tile = interactableMap.GetTile(position);
    //    if (tile != null)
    //    {
    //        return tile.name == "Interactable";
    //    }
    //    return false;
    //}
   

    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, brokenRockTile); 
    }

    public void SetLight(Vector3Int position)
    {
        Vector3Int positionTop = new Vector3Int(position.x, position.y + 2, 0);
        interactableMap.SetTile(positionTop, shadowWallTile[position.x - 21]);
        Vector3Int positionMiddle = new Vector3Int(position.x,position.y + 1, 0);
        interactableMap.SetTile(positionMiddle, shadowWallTile[position.x - 21 + 8]);
        Vector3Int positionBottom = new Vector3Int(position.x, position.y, 0);
        interactableMap.SetTile(positionBottom, shadowWallTile[position.x - 21 + 16]);
         
    }

    public void SetShadow(Vector3Int position)
    {
        Vector3Int positionTop = new Vector3Int(position.x, position.y + 2, 0);
        interactableMap.SetTile(positionTop, darkShadowWallTile[0]);
        Vector3Int positionMiddle = new Vector3Int(position.x,position.y + 1, 0);
        interactableMap.SetTile(positionMiddle, darkShadowWallTile[1]);
        Vector3Int positionBottom = new Vector3Int(position.x, position.y, 0);
        interactableMap.SetTile(positionBottom, darkShadowWallTile[2]);

        // interactableMap.SetTile(position, brokenRockTile);
    }

    public void SetDoor(){
        for(int x = 36; x < 40; x++){
            for(int y = 48; y < 50; y++){
                Vector3Int position = new Vector3Int(x, y, 0);
                interactableMap.SetTile(position, emptyGemTile); //TODO: make door art
            }
        }
    }

    public void SetGem(Vector3Int position, string gemColor)
    {
        // Debug.Log("Setting gem: " + gemColor);
        switch(gemColor){
            case "Red":
                background.SetTile(position, redGemTile);
                break;
            case "Green":
                background.SetTile(position, greenGemTile);
                break;
            case "Blue":
                background.SetTile(position, blueGemTile);
                break;
            case "Purple":
                background.SetTile(position, purpleGemTile);
                break;
            case "None":
                background.SetTile(position, emptyGemTile);
                break;
        }
    }
     
    public string GetTileName(Vector3Int position)
    {
        if(interactableMap != null)
        {
            TileBase tile = interactableMap.GetTile(position);

            if(tile != null)
            {
                return tile.name;
            }
        }

        return "";
    }
}
