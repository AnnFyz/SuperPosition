using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    private void Awake() {
        Instance = this;
    }
    public Transform pfItemWorld;
    public Sprite PickleSprite;
    public Sprite KeyForPinkPortalSprite;
    public Sprite KeyForOrangePortalSprite;
    public Sprite KeyForBluePortalSprite;
    public Sprite KeyForGreenPortalSprite;
    public Sprite RabbitPuppetSprite;
    public Sprite CatMintSPrite;
    public Sprite ParfumeSPrite;
    public Sprite FischSprite;
    public Sprite BottelSPrite;
    public Sprite BroscheSprite;
    public Sprite MacDonaldsSprite;


}
