using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Sprite[] bullets;
    public int damage;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = bullets[Random.Range(0, bullets.Length)];
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().SubHealth(damage);
            Destroy(gameObject);
        }
    }
}
