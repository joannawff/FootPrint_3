using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// SurveyDetailInfo 的摘要说明
/// </summary>
public class SurveyDetailInfo
{
    public SurveyDetailInfo()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public SurveyDetailInfo(int id, SurveyInfo surveyInfo, string leaderAndSecurityOfficer, string projectDetail, string members, string plan, string actual, DateTime offTime, string sortData, string sortDataParticipants, string device, string vehicleRecord, string remark)
    {
        this.id = id;
        this.surveyInfo = surveyInfo;
        this.leaderAndSecurityOfficer = leaderAndSecurityOfficer;
        this.projectDetail = projectDetail;
        this.members = members;
        this.plan = plan;
        this.actual = actual;
        this.offTime = offTime;
        this.sortData = sortData;
        this.sortDataParticipants = sortDataParticipants;
        this.device = device;
        this.vehicleRecord = vehicleRecord;
        this.remark = remark;
    }

    private int id;
    private SurveyInfo surveyInfo;
    private String leaderAndSecurityOfficer;
    private String projectDetail;
    private String members;
    private String plan;
    private String actual;
    private DateTime offTime;
    private String sortData;
    private String sortDataParticipants;
    private String device;
    private String vehicleRecord;
    private String remark;

    public int Id { get => id; set => id = value; }
    public SurveyInfo SurveyInfo { get => surveyInfo; set => surveyInfo = value; }
    public string LeaderAndSecurityOfficer { get => leaderAndSecurityOfficer; set => leaderAndSecurityOfficer = value; }
    public string ProjectDetail { get => projectDetail; set => projectDetail = value; }
    public string Members { get => members; set => members = value; }
    public string Plan { get => plan; set => plan = value; }
    public string Actual { get => actual; set => actual = value; }
    public DateTime OffTime { get => offTime; set => offTime = value; }
    public string SortData { get => sortData; set => sortData = value; }
    public string SortDataParticipants { get => sortDataParticipants; set => sortDataParticipants = value; }
    public string Device { get => device; set => device = value; }
    public string VehicleRecord { get => vehicleRecord; set => vehicleRecord = value; }
    public string Remark { get => remark; set => remark = value; }
}