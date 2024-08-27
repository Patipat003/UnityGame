using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SearchManager : MonoBehaviour
{
    public InputField searchInputField;
    public Button searchButton;
    public Text resultText; // ใช้ Text หรือ ScrollView สำหรับแสดงผลลัพธ์การค้นหา
    public GameObject MainWikiUI;
    public GameObject m1911UI; 
    public GameObject GlockUI; 
    public GameObject BerettaUI; 
    public GameObject SIGUI;
    public GameObject SpringfieldXDUI;
    public GameObject HK45UI;
    public GameObject SWMP45UI;
    public GameObject SWBodyguard380UI;
    public GameObject RugerLCPUI;
    public GameObject Glock42UI;
    public GameObject AK47UI;
    public GameObject SKSUI;
    public GameObject RugerMini30UI;
    public GameObject Remington700UI;
    public GameObject Winchester70UI;
    public GameObject SakoTRG42UI;
    public GameObject WeatherbyMarkVUI;
    public GameObject Remington870UI;
    public GameObject Mossberg500UI;
    public GameObject Winchester1300UI;
    public GameObject BenelliM4Super90UI;
    public GameObject USDollarUI;
    public GameObject YenUI;
    public GameObject YuanUI;
    public GameObject RicinUI;
    public GameObject ArsenicUI;
    public GameObject ThalliumUI;
    public GameObject StrychnineUI;
    public GameObject CyanideUI;
    public GameObject OpiumUI;
    public GameObject MorphineUI;
    public GameObject HeroinUI;
    public GameObject CocaineUI;
    public GameObject CannabisUI;
    public GameObject KratomUI;
    public GameObject MagicMushroomUI;
    public GameObject AmphetamineUI;
    public GameObject EcstasyUI;
    public GameObject PantocidTabletUI;
    public GameObject RivotrilUI;
    public GameObject AmoxicillinUI;

    private List<string> itemList = new List<string> {};

    void Start()
    {
        searchButton.onClick.AddListener(OnSearchButtonClicked);
        SetUIObjectsActive(false); // ซ่อนทุก UI object เมื่อเริ่มต้น
    }

    void OnSearchButtonClicked()
    {
        string searchQuery = searchInputField.text.Trim().ToLower(); // รับข้อความค้นหาและแปลงเป็นตัวพิมพ์เล็กทั้งหมด
        SearchItem(searchQuery);
    }


    void SearchItem(string query)
    {
    // รีเซ็ตผลลัพธ์การค้นหา

        if (string.IsNullOrEmpty(query))
        {
            MainWikiUI.SetActive(true);
            return;
        }

        // แสดง UI object ที่ตรงกับ query
        SetUIObjectsActive(false); // ซ่อนทุก UI object ก่อนที่จะแสดงใหม่

        if (query == "colt" || query == "m1911" || query == "colt m1911")
        {
            m1911UI.SetActive(true);
        }
        else if (query == "glock 17" || query == "glock17" || query == "glock_17" || query == "glock-17")
        {
            GlockUI.SetActive(true);
        }
        else if (query == "beretta 92fs" || query == "beretta" || query == "92fs" || query == "beretta92fs")
        {
            BerettaUI.SetActive(true);
        }
        else if (query == "sig sauer p226" || query == "sigsauerp226" || query == "sauer p226" || query == "sig sauer" || query == "sig" || query == "sauer" || query == "p226")
        {
            SIGUI.SetActive(true);
        }
        else if (query == "springfield xd" || query == "springfield")
        {
            SpringfieldXDUI.SetActive(true);
        }
        else if (query == "hk45" || query == "hk")
        {
            HK45UI.SetActive(true);
        }
        else if (query == "smith & wesson m&p 45" || query == "swmp45" || query == "smith & wesson mp45")
        {
            SWMP45UI.SetActive(true);
        }
        else if (query == "smith & wesson bodyguard 380" || query == "sw bodyguard 380" || query == "bodyguard 380")
        {
            SWBodyguard380UI.SetActive(true);
        }
        else if (query == "ruger lcp" || query == "ruger" || query == "lcp")
        {
            RugerLCPUI.SetActive(true);
        }
        else if (query == "glock 42" || query == "glock42" || query == "glock_42" || query == "glock-42")
        {
            Glock42UI.SetActive(true);
        }
        else if (query == "ak-47" || query == "ak47" || query == "ak 47" || query == "ak")
        {
            AK47UI.SetActive(true);
        }
        else if (query == "sks")
        {
            SKSUI.SetActive(true);
        }
        else if (query == "ruger mini-30" || query == "mini-30" || query == "ruger mini30" || query == "ruger mini")
        {
            RugerMini30UI.SetActive(true);
        }
        else if (query == "remington model 700" || query == "remington 700" || query == "model 700")
        {
            Remington700UI.SetActive(true);
        }
        else if (query == "winchester model 70" || query == "winchester 70" || query == "model 70")
        {
            Winchester70UI.SetActive(true);
        }
        else if (query == "sako trg-42" || query == "trg-42" || query == "sako trg42" || query == "sako")
        {
            SakoTRG42UI.SetActive(true);
        }
        else if (query == "weatherby mark v" || query == "mark v" || query == "weatherby markv")
        {
            WeatherbyMarkVUI.SetActive(true);
        }
        else if (query == "remington 870" || query == "remington870" || query == "870")
        {
            Remington870UI.SetActive(true);
        }
        else if (query == "mossberg 500" || query == "mossberg500" || query == "500")
        {
            Mossberg500UI.SetActive(true);
        }
        else if (query == "winchester model 1300" || query == "winchester 1300" || query == "model 1300")
        {
            Winchester1300UI.SetActive(true);
        }
        else if (query == "benelli m4 super 90" || query == "benelli m4" || query == "m4 super 90" || query == "benelli m4super90")
        {
            BenelliM4Super90UI.SetActive(true);
        }
        else if (query == "us dollar" || query == "usdollar" || query == "dollar")
        {
            USDollarUI.SetActive(true);
        }
        else if (query == "yen")
        {
            YenUI.SetActive(true);
        }
        else if (query == "yuan")
        {
            YuanUI.SetActive(true);
        }
        else if (query == "ricin")
        {
            RicinUI.SetActive(true);
        }
        else if (query == "arsenic")
        {
            ArsenicUI.SetActive(true);
        }
        else if (query == "thallium")
        {
            ThalliumUI.SetActive(true);
        }
        else if (query == "strychnine")
        {
            StrychnineUI.SetActive(true);
        }
        else if (query == "cyanide")
        {
            CyanideUI.SetActive(true);
        }
        else if (query == "opium")
        {
            OpiumUI.SetActive(true);
        }
        else if (query == "morphine")
        {
            MorphineUI.SetActive(true);
        }
        else if (query == "heroin")
        {
            HeroinUI.SetActive(true);
        }
        else if (query == "cocaine")
        {
            CocaineUI.SetActive(true);
        }
        else if (query == "cannabis")
        {
            CannabisUI.SetActive(true);
        }
        else if (query == "kratom")
        {
            KratomUI.SetActive(true);
        }
        else if (query == "magic mushroom" || query == "magicmushroom")
        {
            MagicMushroomUI.SetActive(true);
        }
        else if (query == "amphetamine")
        {
            AmphetamineUI.SetActive(true);
        }
        else if (query == "ecstasy" || query == "mdma" || query == "ecstacy")
        {
            EcstasyUI.SetActive(true);
        }
        else if (query == "pantocid tablet" || query == "pantocid")
        {
            PantocidTabletUI.SetActive(true);
        }
        else if (query == "rivotril")
        {
            RivotrilUI.SetActive(true);
        }
        else if (query == "amoxicillin")
        {
            AmoxicillinUI.SetActive(true);
        }
        else
        {
            resultText.text = "ไม่พบไอเทมที่คุณค้นหา";
        }
    }

    // ฟังก์ชันเพื่อซ่อนหรือแสดง UI object ตามที่ต้องการ
    void SetUIObjectsActive(bool active)
    {
        MainWikiUI.SetActive(active);
        m1911UI.SetActive(active);
        GlockUI.SetActive(active);
        BerettaUI.SetActive(active);
        SIGUI.SetActive(active);
        SpringfieldXDUI.SetActive(active);
        HK45UI.SetActive(active);
        SWMP45UI.SetActive(active);
        SWBodyguard380UI.SetActive(active);
        RugerLCPUI.SetActive(active);
        Glock42UI.SetActive(active);
        AK47UI.SetActive(active);
        SKSUI.SetActive(active);
        RugerMini30UI.SetActive(active);
        Remington700UI.SetActive(active);
        Winchester70UI.SetActive(active);
        SakoTRG42UI.SetActive(active);
        WeatherbyMarkVUI.SetActive(active);
        Remington870UI.SetActive(active);
        Mossberg500UI.SetActive(active);
        Winchester1300UI.SetActive(active);
        BenelliM4Super90UI.SetActive(active);
        USDollarUI.SetActive(active);
        YenUI.SetActive(active);
        YuanUI.SetActive(active);
        RicinUI.SetActive(active);
        ArsenicUI.SetActive(active);
        ThalliumUI.SetActive(active);
        StrychnineUI.SetActive(active);
        CyanideUI.SetActive(active);
        OpiumUI.SetActive(active);
        MorphineUI.SetActive(active);
        HeroinUI.SetActive(active);
        CocaineUI.SetActive(active);
        CannabisUI.SetActive(active);
        KratomUI.SetActive(active);
        MagicMushroomUI.SetActive(active);
        AmphetamineUI.SetActive(active);
        EcstasyUI.SetActive(active);
        PantocidTabletUI.SetActive(active);
        RivotrilUI.SetActive(active);
        AmoxicillinUI.SetActive(active);
    }
}
