/****************************************************
    文件：GameRoot.cs
	作者：杨成超
    邮箱: 382657000@qq.com
    日期：2019/10/3 21:25:22
	功能：游戏开始入口
*****************************************************/

using Protocal;
using UnityEngine;

public class GameRoot : MonoBehaviour 
{
    #region 自定义变量
    private LoginSys loginSys;
    private MainCitySys mainCitySys;
    private FubenSys fubenSys;
    private BatleSys batleSys;
    private ResSvc resSvc;
    private AudioSvc audioSvc;
    private NetSvc netSvc;
    private TimerSvc timerSvc;
    private PlayerData playerDate;
    public static GameRoot Instance = null;
    public LoadingWnd loadingWnd;
    public DynamicWnd dynamicWnd;
    #endregion

    #region 系统函数
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        Init();
    }
    #endregion

    #region 自定义函数
    /// <summary>
    /// 初始化服务和系统资源
    /// </summary>
    private void Init()
    {
        resSvc = GetComponent<ResSvc>();
        audioSvc = GetComponent<AudioSvc>();
        netSvc = GetComponent<NetSvc>();
        timerSvc = GetComponent<TimerSvc>();
        loginSys = GetComponent<LoginSys>();
        mainCitySys = GetComponent<MainCitySys>();
        fubenSys = GetComponent<FubenSys>();
        batleSys = GetComponent<BatleSys>();

        resSvc.InitResSvc();
        netSvc.InitNetSvc();
        audioSvc.InitAudioSvc();
        timerSvc.InitTimerSvc();
        loginSys.InitSystem();
        mainCitySys.InitSystem();
        fubenSys.InitSystem();
        batleSys.InitSystem();

        SetPanelActive();

        loginSys.EnterGame();
    }

    /// <summary>
    /// 初始化所有面板的激活
    /// </summary>
    private void SetPanelActive()
    {
        Transform canvas = transform.Find("Canvas");
        for (int i = 0; i < canvas.childCount; i++)
        {
            canvas.GetChild(i).gameObject.SetActive(false);
        }
        dynamicWnd.gameObject.SetActive(true);
    }

    /// <summary>
    /// 全局显示提示信息
    /// </summary>
    public static void AddShowText(string msg)
    {
        Instance.dynamicWnd.AddQueueTxt(msg);
        Instance.dynamicWnd.transform.SetAsLastSibling();
    }


    /// <summary>
    /// 保存人物数据
    /// </summary>
    public void SetPlayerData(PlayerData _playerdata)
    {
        this.playerDate = _playerdata;
    }
    public PlayerData Playerdata
    {
        get { return playerDate; }
        set { playerDate = value; }
    }

    /// <summary>
    /// 重置人物名字
    /// </summary>
    public void SetPlayerName(string name)
    {
        Playerdata.name = name;
    }

    /// <summary>
    /// 根据任务数据更新玩家数据 
    /// </summary>
    public void UpdataPlayerDataByGuide(int guideId,int exp,int coin,int lv)
    {
        playerDate.taskGuideId = guideId;
        playerDate.exp = exp;
        playerDate.coin = coin;
        playerDate.lv = lv;
    }

    /// <summary>
    /// 根据强化数据更新玩家数据
    /// </summary>
    public void UpdataPlayerDataByStrong(RspStrong rspstrong)
    {
        playerDate.ad = rspstrong.ad;
        playerDate.addef = rspstrong.adddef;
        playerDate.ap = rspstrong.ap;
        playerDate.apdef = rspstrong.apddef;
        playerDate.coin = rspstrong.coin;
        playerDate.crystal = rspstrong.crystal;
        playerDate.strong = rspstrong.starlvArray;
    }

    /// <summary>
    /// 根据交易数据更新玩家数据
    /// </summary>
    public void UpdataPlayerDataByBuy(RspBuy rspBuy)
    {
        playerDate.power = rspBuy.power;
        playerDate.coin = rspBuy.coin;
        playerDate.diamond = rspBuy.diamond;
    }

    /// <summary>
    /// 根据恢复体力值
    /// </summary>
    public void UpdataPlayerDataByPushPower(PushPower pushPower)
    {
        playerDate.power = pushPower.power;
    }

    /// <summary>
    /// 根据任务领奖
    /// </summary>
    public void UpdataPlayerDataByTakeTask(RspTakeTask rspTakeTask)
    {
        playerDate.coin = rspTakeTask.coin;
        playerDate.exp = rspTakeTask.exp;
        playerDate.lv = rspTakeTask.lv;
        playerDate.taskInfo = rspTakeTask.takeTask;
    }

    /// <summary>
    /// 根据任务进度
    /// </summary>
    public void UpdataPlayerDataByPushTask(PushTaskprgs pushTaksprgs)
    {
        playerDate.taskInfo = pushTaksprgs.takeTask;
    }

    /// <summary>
    /// 根据副本进度
    /// </summary>
    public void UpdataPlayerDataByFbFight(RspFbFight rspFbFight)
    {
        playerDate.power = rspFbFight.power;
    }
    #endregion
}