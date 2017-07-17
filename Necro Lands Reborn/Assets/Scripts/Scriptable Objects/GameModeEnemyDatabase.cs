using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeEnemyDatabase : ScriptableObject {

    [SerializeField]
    private Enemy[] enemies;

    public void setEnemies(Enemy[] es) { enemies = es; }
    public Enemy[] getEnemies() { return enemies; }
}
