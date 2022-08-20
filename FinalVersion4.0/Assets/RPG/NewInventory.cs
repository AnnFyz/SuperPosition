using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewInventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slotsObj;
    public List<int> artickleId;
    public bool isRightArticklea;
    public int currentDesiredArticleId;

    public void FillArtickleIdArray()
    {
        artickleId.Clear();
        for (int i = 0; i < isFull.Length; i++)
        {
            if (isFull[i])
            {
                int x = slotsObj[i].GetComponentInChildren<ItemUIDescription>().idArticle;
                artickleId.Add(x);
            }


        }
    }

   
    public bool CheckCollectedObjects(int desiredObjId, int selectedArticleId) // find a right slot and destroy uiObj
    {
        currentDesiredArticleId = desiredObjId;

        {
            foreach (var item in artickleId)
            {
                if(item == selectedArticleId)
                {
                    if (item == currentDesiredArticleId)
                    {
                        
                        isRightArticklea = true;
                        return true;
                    }
                }
            
                
            }

        }

        return false;

    }
}
