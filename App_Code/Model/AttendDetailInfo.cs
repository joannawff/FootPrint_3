using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// AttendDetailInfo 的摘要说明
/// </summary>
public class AttendDetailInfo
{
    public AttendDetailInfo()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public AttendDetailInfo(int id, AttendInfo attendInfo, UserInfo userInfo, string curMonthDay01, string curMonthDay02, string curMonthDay03, string curMonthDay04, string curMonthDay05, string curMonthDay06, string curMonthDay07, string curMonthDay08, string curMonthDay09, string curMonthDay10, string curMonthDay11, string curMonthDay12, string curMonthDay13, string curMonthDay14, string curMonthDay15, string curMonthDay16, string curMonthDay17, string curMonthDay18, string curMonthDay19, string curMonthDay20, string curMonthDay21, string curMonthDay22, string curMonthDay23, string curMonthDay24, string curMonthDay25, string curMonthDay26, string curMonthDay27, string curMonthDay28, string curMonthDay29, string curMonthDay30, string curMonthDay31, string nextMonthDay01, string nextMonthDay02, string nextMonthDay03, string nextMonthDay04, string nextMonthDay05, string nextMonthDay06, string nextMonthDay07, string nextMonthDay08, string nextMonthDay09, string nextMonthDay10, string nextMonthDay11, string nextMonthDay12, string nextMonthDay13, string nextMonthDay14, string nextMonthDay15, string nextMonthDay16, string nextMonthDay17, string nextMonthDay18, string nextMonthDay19, string nextMonthDay20, string nextMonthDay21, string nextMonthDay22, string nextMonthDay23, string nextMonthDay24, string nextMonthDay25, string nextMonthDay26, string nextMonthDay27, string nextMonthDay28, string nextMonthDay29, string nextMonthDay30, string nextMonthDay31,string remark)
    {
        this.id = id;
        this.attendInfo = attendInfo;
        this.userInfo = userInfo;
        this.curMonthDay01 = curMonthDay01;
        this.curMonthDay02 = curMonthDay02;
        this.curMonthDay03 = curMonthDay03;
        this.curMonthDay04 = curMonthDay04;
        this.curMonthDay05 = curMonthDay05;
        this.curMonthDay06 = curMonthDay06;
        this.curMonthDay07 = curMonthDay07;
        this.curMonthDay08 = curMonthDay08;
        this.curMonthDay09 = curMonthDay09;
        this.curMonthDay10 = curMonthDay10;
        this.curMonthDay11 = curMonthDay11;
        this.curMonthDay12 = curMonthDay12;
        this.curMonthDay13 = curMonthDay13;
        this.curMonthDay14 = curMonthDay14;
        this.curMonthDay15 = curMonthDay15;
        this.curMonthDay16 = curMonthDay16;
        this.curMonthDay17 = curMonthDay17;
        this.curMonthDay18 = curMonthDay18;
        this.curMonthDay19 = curMonthDay19;
        this.curMonthDay20 = curMonthDay20;
        this.curMonthDay21 = curMonthDay21;
        this.curMonthDay22 = curMonthDay22;
        this.curMonthDay23 = curMonthDay23;
        this.curMonthDay24 = curMonthDay24;
        this.curMonthDay25 = curMonthDay25;
        this.curMonthDay26 = curMonthDay26;
        this.curMonthDay27 = curMonthDay27;
        this.curMonthDay28 = curMonthDay28;
        this.curMonthDay29 = curMonthDay29;
        this.curMonthDay30 = curMonthDay30;
        this.curMonthDay31 = curMonthDay31;
        this.nextMonthDay01 = nextMonthDay01;
        this.nextMonthDay02 = nextMonthDay02;
        this.nextMonthDay03 = nextMonthDay03;
        this.nextMonthDay04 = nextMonthDay04;
        this.nextMonthDay05 = nextMonthDay05;
        this.nextMonthDay06 = nextMonthDay06;
        this.nextMonthDay07 = nextMonthDay07;
        this.nextMonthDay08 = nextMonthDay08;
        this.nextMonthDay09 = nextMonthDay09;
        this.nextMonthDay10 = nextMonthDay10;
        this.nextMonthDay11 = nextMonthDay11;
        this.nextMonthDay12 = nextMonthDay12;
        this.nextMonthDay13 = nextMonthDay13;
        this.nextMonthDay14 = nextMonthDay14;
        this.nextMonthDay15 = nextMonthDay15;
        this.nextMonthDay16 = nextMonthDay16;
        this.nextMonthDay17 = nextMonthDay17;
        this.nextMonthDay18 = nextMonthDay18;
        this.nextMonthDay19 = nextMonthDay19;
        this.nextMonthDay20 = nextMonthDay20;
        this.nextMonthDay21 = nextMonthDay21;
        this.nextMonthDay22 = nextMonthDay22;
        this.nextMonthDay23 = nextMonthDay23;
        this.nextMonthDay24 = nextMonthDay24;
        this.nextMonthDay25 = nextMonthDay25;
        this.nextMonthDay26 = nextMonthDay26;
        this.nextMonthDay27 = nextMonthDay27;
        this.nextMonthDay28 = nextMonthDay28;
        this.nextMonthDay29 = nextMonthDay29;
        this.nextMonthDay30 = nextMonthDay30;
        this.nextMonthDay31 = nextMonthDay31;
        this.remark = remark;
    }

    private int id;
    private AttendInfo attendInfo;
    private UserInfo userInfo;
    private String curMonthDay01;
    private String curMonthDay02;
    private String curMonthDay03;
    private String curMonthDay04;
    private String curMonthDay05;
    private String curMonthDay06;
    private String curMonthDay07;
    private String curMonthDay08;
    private String curMonthDay09;
    private String curMonthDay10;
    private String curMonthDay11;
    private String curMonthDay12;
    private String curMonthDay13;
    private String curMonthDay14;
    private String curMonthDay15;
    private String curMonthDay16;
    private String curMonthDay17;
    private String curMonthDay18;
    private String curMonthDay19;
    private String curMonthDay20;
    private String curMonthDay21;
    private String curMonthDay22;
    private String curMonthDay23;
    private String curMonthDay24;
    private String curMonthDay25;
    private String curMonthDay26;
    private String curMonthDay27;
    private String curMonthDay28;
    private String curMonthDay29;
    private String curMonthDay30;
    private String curMonthDay31;
    private String nextMonthDay01;
    private String nextMonthDay02;
    private String nextMonthDay03;
    private String nextMonthDay04;
    private String nextMonthDay05;
    private String nextMonthDay06;
    private String nextMonthDay07;
    private String nextMonthDay08;
    private String nextMonthDay09;
    private String nextMonthDay10;
    private String nextMonthDay11;
    private String nextMonthDay12;
    private String nextMonthDay13;
    private String nextMonthDay14;
    private String nextMonthDay15;
    private String nextMonthDay16;
    private String nextMonthDay17;
    private String nextMonthDay18;
    private String nextMonthDay19;
    private String nextMonthDay20;
    private String nextMonthDay21;
    private String nextMonthDay22;
    private String nextMonthDay23;
    private String nextMonthDay24;
    private String nextMonthDay25;
    private String nextMonthDay26;
    private String nextMonthDay27;
    private String nextMonthDay28;
    private String nextMonthDay29;
    private String nextMonthDay30;
    private String nextMonthDay31;
    private String remark;

    public int Id { get => id; set => id = value; }
    public AttendInfo AttendInfo { get => attendInfo; set => attendInfo = value; }
    public UserInfo UserInfo { get => userInfo; set => userInfo = value; }
    public string CurMonthDay01 { get => curMonthDay01; set => curMonthDay01 = value; }
    public string CurMonthDay02 { get => curMonthDay02; set => curMonthDay02 = value; }
    public string CurMonthDay03 { get => curMonthDay03; set => curMonthDay03 = value; }
    public string CurMonthDay04 { get => curMonthDay04; set => curMonthDay04 = value; }
    public string CurMonthDay05 { get => curMonthDay05; set => curMonthDay05 = value; }
    public string CurMonthDay06 { get => curMonthDay06; set => curMonthDay06 = value; }
    public string CurMonthDay07 { get => curMonthDay07; set => curMonthDay07 = value; }
    public string CurMonthDay08 { get => curMonthDay08; set => curMonthDay08 = value; }
    public string CurMonthDay09 { get => curMonthDay09; set => curMonthDay09 = value; }
    public string CurMonthDay10 { get => curMonthDay10; set => curMonthDay10 = value; }
    public string CurMonthDay11 { get => curMonthDay11; set => curMonthDay11 = value; }
    public string CurMonthDay12 { get => curMonthDay12; set => curMonthDay12 = value; }
    public string CurMonthDay13 { get => curMonthDay13; set => curMonthDay13 = value; }
    public string CurMonthDay14 { get => curMonthDay14; set => curMonthDay14 = value; }
    public string CurMonthDay15 { get => curMonthDay15; set => curMonthDay15 = value; }
    public string CurMonthDay16 { get => curMonthDay16; set => curMonthDay16 = value; }
    public string CurMonthDay17 { get => curMonthDay17; set => curMonthDay17 = value; }
    public string CurMonthDay18 { get => curMonthDay18; set => curMonthDay18 = value; }
    public string CurMonthDay19 { get => curMonthDay19; set => curMonthDay19 = value; }
    public string CurMonthDay20 { get => curMonthDay20; set => curMonthDay20 = value; }
    public string CurMonthDay21 { get => curMonthDay21; set => curMonthDay21 = value; }
    public string CurMonthDay22 { get => curMonthDay22; set => curMonthDay22 = value; }
    public string CurMonthDay23 { get => curMonthDay23; set => curMonthDay23 = value; }
    public string CurMonthDay24 { get => curMonthDay24; set => curMonthDay24 = value; }
    public string CurMonthDay25 { get => curMonthDay25; set => curMonthDay25 = value; }
    public string CurMonthDay26 { get => curMonthDay26; set => curMonthDay26 = value; }
    public string CurMonthDay27 { get => curMonthDay27; set => curMonthDay27 = value; }
    public string CurMonthDay28 { get => curMonthDay28; set => curMonthDay28 = value; }
    public string CurMonthDay29 { get => curMonthDay29; set => curMonthDay29 = value; }
    public string CurMonthDay30 { get => curMonthDay30; set => curMonthDay30 = value; }
    public string CurMonthDay31 { get => curMonthDay31; set => curMonthDay31 = value; }
    public string NextMonthDay01 { get => nextMonthDay01; set => nextMonthDay01 = value; }
    public string NextMonthDay02 { get => nextMonthDay02; set => nextMonthDay02 = value; }
    public string NextMonthDay03 { get => nextMonthDay03; set => nextMonthDay03 = value; }
    public string NextMonthDay04 { get => nextMonthDay04; set => nextMonthDay04 = value; }
    public string NextMonthDay05 { get => nextMonthDay05; set => nextMonthDay05 = value; }
    public string NextMonthDay06 { get => nextMonthDay06; set => nextMonthDay06 = value; }
    public string NextMonthDay07 { get => nextMonthDay07; set => nextMonthDay07 = value; }
    public string NextMonthDay08 { get => nextMonthDay08; set => nextMonthDay08 = value; }
    public string NextMonthDay09 { get => nextMonthDay09; set => nextMonthDay09 = value; }
    public string NextMonthDay10 { get => nextMonthDay10; set => nextMonthDay10 = value; }
    public string NextMonthDay11 { get => nextMonthDay11; set => nextMonthDay11 = value; }
    public string NextMonthDay12 { get => nextMonthDay12; set => nextMonthDay12 = value; }
    public string NextMonthDay13 { get => nextMonthDay13; set => nextMonthDay13 = value; }
    public string NextMonthDay14 { get => nextMonthDay14; set => nextMonthDay14 = value; }
    public string NextMonthDay15 { get => nextMonthDay15; set => nextMonthDay15 = value; }
    public string NextMonthDay16 { get => nextMonthDay16; set => nextMonthDay16 = value; }
    public string NextMonthDay17 { get => nextMonthDay17; set => nextMonthDay17 = value; }
    public string NextMonthDay18 { get => nextMonthDay18; set => nextMonthDay18 = value; }
    public string NextMonthDay19 { get => nextMonthDay19; set => nextMonthDay19 = value; }
    public string NextMonthDay20 { get => nextMonthDay20; set => nextMonthDay20 = value; }
    public string NextMonthDay21 { get => nextMonthDay21; set => nextMonthDay21 = value; }
    public string NextMonthDay22 { get => nextMonthDay22; set => nextMonthDay22 = value; }
    public string NextMonthDay23 { get => nextMonthDay23; set => nextMonthDay23 = value; }
    public string NextMonthDay24 { get => nextMonthDay24; set => nextMonthDay24 = value; }
    public string NextMonthDay25 { get => nextMonthDay25; set => nextMonthDay25 = value; }
    public string NextMonthDay26 { get => nextMonthDay26; set => nextMonthDay26 = value; }
    public string NextMonthDay27 { get => nextMonthDay27; set => nextMonthDay27 = value; }
    public string NextMonthDay28 { get => nextMonthDay28; set => nextMonthDay28 = value; }
    public string NextMonthDay29 { get => nextMonthDay29; set => nextMonthDay29 = value; }
    public string NextMonthDay30 { get => nextMonthDay30; set => nextMonthDay30 = value; }
    public string NextMonthDay31 { get => nextMonthDay31; set => nextMonthDay31 = value; }
    public string Remark { get => remark; set => remark = value; }
}