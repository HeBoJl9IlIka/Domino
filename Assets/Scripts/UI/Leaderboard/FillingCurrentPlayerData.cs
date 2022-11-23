using TMPro;
using UnityEngine;

public class FillingCurrentPlayerData : MonoBehaviour
{
    [SerializeField] private TMP_Text _rank;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _score;

    public void Set(LeaderboardPlayer player)
    {
        if(player.Rank == 0)
            _rank.text = "-";

        _rank.text = player.Rank.ToString();
        _name.text = player.Name.ToString();
        _score.text = player.Score.ToString();
    }
}
