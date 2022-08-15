using UnityEngine;
using System.Linq;
using System.Collections.Generic;

public class RankCalculator : MonoBehaviour
{
    [SerializeField] private List<CompetitorProgressInfo> competitorProgressInfos;

    private void Update() 
    {
        CalculateRank();
    }

    private void CalculateRank()
    {
        competitorProgressInfos = competitorProgressInfos.OrderBy(x => x.WorldPos_Z()).ToList();

        for(int i = 0; i < competitorProgressInfos.Count; i++)
            competitorProgressInfos[i].Position = competitorProgressInfos.Count - i;
    }
}
