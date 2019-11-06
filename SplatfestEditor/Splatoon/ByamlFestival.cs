using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplatfestEditor.Splatoon
{

    public class FestActionEntryObject
    {
        public string CameraType { get; set; }
        public string Command { get; set; }
        public string Emotion { get; set; }
        public string Speaker { get; set; }
        public string Text { get; set; }
        public bool WaitButton { get; set; }

        public FestActionEntryObject()
        {
            CameraType = ByamlFestival.CameraTypes[0];
            Command = "Speak";
            Emotion = ByamlFestival.Emotions[0];
            Speaker = ByamlFestival.Speakers[0];
            Text = "";
            WaitButton = false;
        }
    }
    public class FestNewsObject
    {
        public List<FestActionEntryObject> EUde { get; set; }
        public List<FestActionEntryObject> EUen { get; set; }
        public List<FestActionEntryObject> EUes { get; set; }
        public List<FestActionEntryObject> EUfr { get; set; }
        public List<FestActionEntryObject> EUit { get; set; }
        public List<FestActionEntryObject> EUnl { get; set; }
        public List<FestActionEntryObject> EUru { get; set; }
        public List<FestActionEntryObject> JPja { get; set; }
        public string NewsType { get; set; }
        public List<FestActionEntryObject> USen { get; set; }
        public List<FestActionEntryObject> USes { get; set; }
        public List<FestActionEntryObject> USfr { get; set; }

        public List<FestActionEntryObject> GetActions(string lang)
        {
            if (lang == nameof(NewsType) || GetType().GetProperty(lang) == null)
                throw new ArgumentException("Invalid Lang");
            return (List<FestActionEntryObject>)GetType().GetProperty(lang).GetValue(this);
        }
        public void SetActions(string lang, List<FestActionEntryObject> value)
        {
            if (lang == nameof(NewsType) || GetType().GetProperty(lang) == null)
                throw new ArgumentException("Invalid Lang");
            GetType().GetProperty(lang).SetValue(this, value);
        }

        public override string ToString()
        {
            return NewsType;
        }
    }
    public class FestRegionAttrObject
    {
        public int GetAttr(string region)
        {
            if (GetType().GetProperty(region) == null)
                throw new ArgumentException("Invalid Region");
            return (int)GetType().GetProperty(region).GetValue(this);
        }
        public void SetAttr(string region, int value)
        {
            if (GetType().GetProperty(region) == null)
                throw new ArgumentException("Invalid Region");
            GetType().GetProperty(region).SetValue(this, value);
        }

        public int EU { get; set; }
        public int JP { get; set; }
        public int US { get; set; }
}
    public class FestCPntObject
    {
        public int HighRate1 { get; set; }
        public int HighRate2 { get; set; }
        public int LowRate { get; set; }
        public float ShrinkRatio { get; set; }
}
    public class FestTeamEntryObject
    {
        public List<object> Color { get; set; }
        public Dictionary<string, string> Name { get; set; }
        public Dictionary<string, string> ShortName { get; set; }

        public Color GetColor()
        {
            int r = (int)(Convert.ToSingle(Color[0]) * 255);
            int g = (int)(Convert.ToSingle(Color[1]) * 255);
            int b = (int)(Convert.ToSingle(Color[2]) * 255);
            int a = (int)(Convert.ToSingle(Color[3]) * 255);

            return System.Drawing.Color.FromArgb(a, r, g, b);
        }
        public void SetColor(Color c)
        {
            Color[0] = ((float)c.R) / 255;
            Color[1] = ((float)c.G) / 255;
            Color[2] = ((float)c.B) / 255;
            Color[3] = ((float)c.A) / 255;
        }
    }
    public class FestTimeObject
    {
        public string Announce { get; set; }
        public string End { get; set; }
        public string Result { get; set; }
        public string Start { get; set; }
    }
    public class FestWeightMatchEntryObject
    {
        public int count { get; set; }
        public int point { get; set; }
        public int yellow { get; set; }
    }
    public class FestWeightMatchObject
    {
        public FestWeightMatchEntryObject WeightHundredMatch { get; set; }
        public FestWeightMatchEntryObject WeightTenMatch { get; set; }
    }


    public class ByamlFestival
    {
        public readonly static string[] SplatoonLangs =
        {
            "EUde",
            "EUen",
            "EUes",
            "EUfr",
            "EUit",
            "EUnl",
            "EUru",
            "JPja",
            "USes",
            "USen",
            "USfr",
        };
        public readonly static string[] SplatoonRegions =
        {
            "EU",
            "JP",
            "US",
        };
        public readonly static string[] NewsTypes =
        {
            "Announcment",
            "Start",
            "ResultA",
            "ResultB",
        };
        public readonly static string[] Speakers =
        {
            "Invalid",
            "Left",
            "Right",
            "Both",
        };
        public readonly static string[] CameraTypes =
        {
            "Invalid",
            "Normal",
            "Left",
            "Right",
            "FestMonitor",
            "BigNamazu",
        };
        public readonly static string[] Emotions =
        {
            "Wait",
            "Talk",
            "Talk_LookOther",
            "Talk_Smirk",
            "Talk_LookOther_Smirk",
            "Angry",
            "DisappointedA",
            "DisappointedB",
            "SurprisedA",
            "SurprisedB",
            "Happy",
            "GoodGrief",
            "SignatureReady",
            "SignaturePose",
            "Special",
            "Excited",
            "Greeting",
            "Attention",
            "GoodGriefB",
            "Point",
            "Attention_LookOther",
        };

        public int DayChangeRetryLimitSec { get; set; }
        public int DayChangeRetryWaitAddSec { get; set; }
        public int FesSameTeamMatchWaitTime { get; set; }
        public int FestivalId { get; set; }
        public List<FestNewsObject> News { get; set; }
        public FestRegionAttrObject RegionAttr { get; set; }
        public int RequiredBattleTimes { get; set; }
        public string Rule { get; set; }
        public int SpecialStage { get; set; }
        public string SpecialType { get; set; }
        public int StartDelayTimeMax { get; set; }
        public List<FestTeamEntryObject> Teams { get; set; }
        public FestTimeObject Time { get; set; }
        public int Version { get; set; }
        public int VoteAnimType { get; set; }
        public int VoteTextType { get; set; }
        public FestWeightMatchObject WeightMatchRequirements { get; set; }
        public float WeightTenMatchRate { get; set; }
        public int WinBonusPoint { get; set; }
        public int WinnerCacheMinutes { get; set; }
        public int WinnerMyselfCacheMinutes { get; set; }

        public FestCPntObject cPnt { get; set; }
    }
}
