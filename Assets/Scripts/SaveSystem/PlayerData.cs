using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //don't know, if it has to be public. learned it from a YT video and he didnt explain
    public float currentStressLvl;
    public int currentItem;
    public float[] position;
    public float timeLeft;

    public PlayerData(playerScript player, float _timeLeft)
    {
        currentStressLvl = player.CurrentStressLvl;
        //if (player.inventory != null)
        //{
        //    currentItem = (int)player.inventory.itemHolder.item.ItemType;
        //}
        //else
        //{
        //    //maybe implement 'none' in enum, so i dont have a nullreference exception
        //}

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        timeLeft = _timeLeft;
    }
}
