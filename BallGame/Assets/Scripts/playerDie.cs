﻿using UnityEngine;
using System.Collections;

public class playerDie : MonoBehaviour {

	private int lives;
    public GameObject player;

	void OnTriggerEnter (Collider playerSphereCollider){

		if(WorldScript.playerLives > 0) {

            // Decrement lives
            WorldScript.playerLives -= 1;

            // TODO add count down timer for player before respawn
            // Spawn new player sphere
            Instantiate(player,new Vector3(0.0f, 0.0f, 0.0f), Quaternion.identity);
            return;

        } else {
            // TODO Create 'new game' menu (also shows latest score and top scores)
        }
	}
}
