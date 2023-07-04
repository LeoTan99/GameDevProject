using UnityEngine;

public class PointManager : MonoBehaviour
{
    public static PointManager instance;
    public int point = 0;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
