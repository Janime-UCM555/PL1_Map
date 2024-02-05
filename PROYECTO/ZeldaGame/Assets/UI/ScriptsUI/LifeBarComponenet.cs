using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeBarComponenet : MonoBehaviour
{

    public GameObject healthPrefab;
    public LinkHealth playerHealth;
    public Health _healthUP;
    List<LifeComponent> hearts = new List<LifeComponent>();
    private void OnEnable()
    {
        LinkHealth.OnPlayerDamaged += DrawHearts;

    }
    private void OnDisable()
    {
        LinkHealth.OnPlayerDamaged -= DrawHearts;
    }
    public void DrawHearts()
    {
        ClearHearts();
        float maxHealthRemainder = playerHealth.maxHealth % 2;
        int heartToMake = (int)(playerHealth.maxHealth / 2 + maxHealthRemainder);
        for (int i = 0; i < heartToMake; i++)
        {
            CreateEmptyHeart();
        }
        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);
        }
    }
    public void CreateEmptyHeart()
    {
        GameObject newheart = Instantiate(healthPrefab);
        newheart.transform.SetParent(transform);
        LifeComponent healthComponent = newheart.GetComponent<LifeComponent>();
        healthComponent.SetHeartImage(HeartStatus.Empty);
        hearts.Add(healthComponent);
    }
    public void ClearHearts()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.gameObject);
        }
        hearts = new List<LifeComponent>();
    }
    /*public void HealthUP()
    {
        ClearHearts();
        float maxHealthRemainder = (playerHealth.maxHealth + 2) % 2;
        int heartToMake = (int)((playerHealth.maxHealth + 2) / 2 + maxHealthRemainder);
        for (int i = 0; i < heartToMake; i++)
        {
            CreateEmptyHeart();
        }
        for (int i = 0; i < hearts.Count; i++)
        {
            int heartStatusRemainder = (int)Mathf.Clamp(playerHealth.health - (i * 2), 0, 2);
            hearts[i].SetHeartImage((HeartStatus)heartStatusRemainder);  
        }
    }
    */
    private void Start()
    {
        DrawHearts();
    }
}
