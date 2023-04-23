using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit
{
    public int calories;
    public GameObject spritePrefab;

    public Fruit(int calories, GameObject spritePrefab)
    {
        this.calories = calories;
        this.spritePrefab = spritePrefab;
    }
}

public class Vegetable
{
    public int calories;
    public GameObject spritePrefab;

    public Vegetable(int calories, GameObject spritePrefab)
    {
        this.calories = calories;
        this.spritePrefab = spritePrefab;
    }
}

public class FoodManager : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bokchoiPrefab;
    public Vector3 spawnOffset;
    public float spawnDelay;

    private Fruit apple;
    private Vegetable bokchoi;
    private System.Collections.Generic.List<object> food;

    void Start()
    {
        apple = new Fruit(100, applePrefab);
        bokchoi = new Vegetable(200, bokchoiPrefab);

        food = new System.Collections.Generic.List<object>();
        food.Add(apple);
        food.Add(bokchoi);
    }

    void OnMouseDown()
    {
        StartCoroutine(SpawnFood());
    }

    IEnumerator SpawnFood()
    {
        foreach (object item in food)
        {
            if (item is Fruit)
            {
                Fruit fruit = item as Fruit;
                Instantiate(fruit.spritePrefab, transform.position + spawnOffset, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
            else if (item is Vegetable)
            {
                Vegetable vegetable = item as Vegetable;
                Instantiate(vegetable.spritePrefab, transform.position + spawnOffset, Quaternion.identity);
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }
}