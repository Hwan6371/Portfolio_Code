using UnityEngine;

public class DontDestroyOnLoadOnlyOneObject : MonoBehaviour
{
    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
