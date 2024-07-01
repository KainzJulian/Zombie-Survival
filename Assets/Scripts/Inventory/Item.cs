using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour, Pickable
{
    [SerializeField] ItemConfig item;
    [SerializeField] int amount;

    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CircleCollider2D circleCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        setCollider();
        setSprite();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void pick()
    {
        throw new System.NotImplementedException();
    }

    private void setSprite()
    {
        spriteRenderer.sprite = item.sprite;
    }
    private void setCollider()
    {
        circleCollider2D.radius = item.pickupRange;
    }

    private void OnDrawGizmos()
    {
        setSprite();
        setCollider();
    }
}
