using System.Collections;
using System.Collections.Generic;
using System.IO;
using DataTable;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private new void Awake()
    {
        base.Awake();
        DataManager.Instance.Initialize();
        
        ItemManager.Instance.Initialize(DatabaseManager.Instance.LoadDataList<ItemInstance>());
        
        UIManager.Instance.Show<HUD>();     //HUD 생성하는 코드 / 추후 위치가 바뀔 예정
    }

    private void InitalizeMainUI() // 게임 시작 버튼이 눌렸을 때 실행되도록 
    {
        //UIManager.Instance.Show<>();
        UIManager.Instance.Show<VirtualJoystick>(); // 이름 수정하기 >> 프리펩은 hud랑 따로 하는 게 나아보임 >> hud 안에서 조이스틱 이니셜라이즈 같이 해도 괜찮을 듯 
        UIManager.Instance.Show<PlayerAttackButton>(); // 이름 수정하기 >> hub > 조이스틱 스크립트에 접근할 수 있도록 하기  (플레이어 어택 코드도 hud에 넣어도 괜찮을듯) 
        // HUD는 프리펩에 묶어서 관리하고 UImanager로 생성하지 말기.
    }
}
