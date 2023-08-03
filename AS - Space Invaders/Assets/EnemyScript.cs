using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private Animator animator;
    public float speed;
    static private Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        direction = Vector2.right;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("death");
        Destroy(gameObject, 1f);
        Destroy(collision.gameObject);
    }

    void Update()
    {
        transform.Translate(direction * Time.deltaTime * speed);

        if (transform.position.x > 22f)
        {
            direction = Vector2.left;
            MoveDown();
        }

        if (transform.position.x < -22f)
        {
            direction = Vector2.right;
            MoveDown();
        }
    }

    private void MoveDown()
    {
        foreach (EnemyScript enemy in FindObjectsOfType(typeof(EnemyScript)))
        {
            enemy.transform.Translate(Vector2.down);
        }
    }
}
