using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject projectile;
    public int projectileCount = 3;

	void Start () {
        CheckGameState();
    }

    public void CheckGameState()
    {
        if (projectileCount > 0)
        {
            GameObject.Instantiate(projectile);
            projectileCount--;
        }
    }
}
