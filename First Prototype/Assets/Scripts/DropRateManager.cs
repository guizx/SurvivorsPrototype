 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }
    public List<Drops> drops;

    private void OnDestroy()
    {
        if (!gameObject.scene.isLoaded) return;
        float randomNumer = UnityEngine.Random.Range(0f, 100f);
        List<Drops> possibleDrops = new List<Drops>();

        foreach (Drops rate in drops)
        {
            if (randomNumer <= rate.dropRate) possibleDrops.Add(rate);
        }

        if(possibleDrops.Count > 0){
            Drops drops = possibleDrops[UnityEngine.Random.Range(0, possibleDrops.Count - 1)];
            Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);
        }
    }
}
