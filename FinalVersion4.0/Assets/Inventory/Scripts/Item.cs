using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item {

    public enum ItemType {
        Pickle,
        KeyForPinkPortal,
        KeyForOrangePortal,
        KeyForBluePortal,
        KeyForGreenPortal,
        RabbitPuppet,
        CatMint,
        Parfume,
        Bottel,
        Fisch,
        Brosche,
        Macdonalds
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite() {
        switch (itemType) {
        default:
        case ItemType.Pickle: return ItemAssets.Instance.PickleSprite;
        case ItemType.KeyForPinkPortal: return ItemAssets.Instance.KeyForPinkPortalSprite;
        case ItemType.KeyForOrangePortal: return ItemAssets.Instance.KeyForOrangePortalSprite;
        case ItemType.KeyForBluePortal: return ItemAssets.Instance.KeyForBluePortalSprite;
        case ItemType.KeyForGreenPortal: return ItemAssets.Instance.KeyForGreenPortalSprite;
        case ItemType.RabbitPuppet: return ItemAssets.Instance.RabbitPuppetSprite;
        case ItemType.CatMint: return ItemAssets.Instance.CatMintSPrite;
        case ItemType.Parfume: return ItemAssets.Instance.ParfumeSPrite;
            case ItemType.Bottel: return ItemAssets.Instance.BottelSPrite;
            case ItemType.Fisch: return ItemAssets.Instance.FischSprite;
            case ItemType.Brosche: return ItemAssets.Instance.BroscheSprite;
            case ItemType.Macdonalds: return ItemAssets.Instance.MacDonaldsSprite;



        }
    }

    // public Color GetColor() {
    //     switch (itemType) {
    //     default:
    //     case ItemType.KeyForPinkPortal:        return new Color(1, 1, 1);
    //     case ItemType.Pickle: return new Color(1, 0, 0);
    //     case ItemType.KeyForPinkPortal:   return new Color(0, 0, 1);
    //     case ItemType.KeyForNormalPortal:         return new Color(1, 1, 0);
    //     case ItemType.Medkit:       return new Color(1, 0, 1);
    //     }
    // }

    public bool IsStackable() {
        switch (itemType) {
        default:
        case ItemType.Pickle:
        case ItemType.KeyForPinkPortal:
        case ItemType.KeyForOrangePortal:
        case ItemType.KeyForBluePortal:
        case ItemType.KeyForGreenPortal:
        case ItemType.RabbitPuppet:
        case ItemType.CatMint:
        case ItemType.Parfume: 
        case ItemType.Bottel: 
        case ItemType.Fisch: 
        case ItemType.Brosche:
        case ItemType.Macdonalds:

                return true;
        // case ItemType.KeyForPinkPortal:
        // case ItemType.Medkit:
        //     return false;
        }
    }

}
