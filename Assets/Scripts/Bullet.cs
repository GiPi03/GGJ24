using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public int damage;
   

    // Update is called once per frame
    void Start()
    {
        Destroy(gameObject, 2f);
    }
    

    
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
