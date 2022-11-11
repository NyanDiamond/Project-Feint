using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Spawnable Enemy")]
public class SpawnableEnemy : ScriptableObject
{
    [Tooltip("The enemy prefab you want to spawn")]
    public GameObject enemy;
    [Tooltip("The position ID you want said enemy to spawn at (STARTS AT 0)")]
    public int spawnPos;
}
