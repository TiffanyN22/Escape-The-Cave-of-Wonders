using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile hiddenPaperStandInteractableTile;
    [SerializeField] private Tile hiddenStreamInteractableTile;
    [SerializeField] private Tile plowedTile;

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
        interactableMap.SetTile(position, plowedTile);
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
