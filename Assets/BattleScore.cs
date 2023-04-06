using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BattleScore : MonoBehaviour
{
    [SerializeField]
    private Player player;
    [SerializeField]
    private TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnScoreChanged(int battleScore) {
        textMeshPro.text = battleScore.ToString();
    }
}
