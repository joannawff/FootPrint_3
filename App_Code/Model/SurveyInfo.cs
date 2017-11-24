using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// SurveyInfo 的摘要说明
/// </summary>
public class SurveyInfo
{
    public SurveyInfo()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public SurveyInfo(int id, string title, DateTime surveyDate, ProjectInfo projectInfo)
    {
        this.id = id;
        Title = title;
        this.surveyDate = surveyDate;
        this.projectInfo = projectInfo;
    }

    private int id;
    private String Title;
    private DateTime surveyDate;
    private ProjectInfo projectInfo;

    public int Id { get => id; set => id = value; }
    public string Title1 { get => Title; set => Title = value; }
    public DateTime SurveyDate { get => surveyDate; set => surveyDate = value; }
    public ProjectInfo ProjectInfo { get => projectInfo; set => projectInfo = value; }
}