using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapis_roulant : MonoBehaviour
{
    public enum Direction { gauche, droite, haut, bas};
    [SerializeField] private Direction direction;
    [SerializeField] private float moveSpeed;

    private Vector2 bounds;
    private Renderer rd;

    private Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        rd = gameObject.GetComponent<Renderer>();
        switch (direction)
        {
            case Direction.haut:
                dir = Vector2.up;
                bounds = new Vector2(rd.bounds.size.x * 0.9f, rd.bounds.size.y);
                break;
            case Direction.bas:
                dir = Vector2.down;
                bounds = new Vector2(rd.bounds.size.x * 0.9f, rd.bounds.size.y);
                break;
            case Direction.gauche:
                dir = Vector2.left;
                bounds = new Vector2(rd.bounds.size.x, rd.bounds.size.y*.9f);
                break;
            case Direction.droite:
                dir = Vector2.right;
                bounds = new Vector2(rd.bounds.size.x, rd.bounds.size.y*.9f);
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, bounds, 0);
        foreach (Collider2D collider in colliders)
        {
            if (collider.tag.Equals("Movable") || collider.tag.Equals("Crystal") )
                collider.transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;
            else if (collider.tag.Equals("Player"))
            {
                if (collider.gameObject.GetComponent<Grab>().IsGrabbing)
                    collider.gameObject.GetComponent<Grab>().DropMovable();
                else
                    collider.transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;
            }
        }
    }
}
