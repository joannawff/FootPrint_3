var path = location.href.substring(0, location.href.lastIndexOf('/') + 1);

//接审单打印
function Print1(taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("接审单");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向    
    //打印项目二维码
    LODOP.ADD_PRINT_HTM(0, 0, 160, 160, "URL:../ServiceHandler/ImgGrCode.ashx?taskID=" + taskID);
    //LODOP.ADD_PRINT_HTM(0, 0, 140, 140, "URL:../Business/TaskGrCode.aspx?taskID=" + taskID);
    LODOP.ADD_PRINT_HTM(115, 5, 160, 30, "<font size=2>扫描查询项目信息</font>");
    //打印微信二维码
    LODOP.ADD_PRINT_HTM(0, 630, 160, 160, "URL:../Images/weixin" + taskID.substring(0, 3) + ".jpg");
    LODOP.ADD_PRINT_HTM(115, 635, 160, 30, "<font size=2>扫描关注单位微信</font>");
    //打印接审单
    LODOP.ADD_PRINT_URL(40, 0, "100%", "100%", path + "TaskArchivesReceipt.aspx?taskID=" + taskID);
    //LODOP.SET_PRINT_STYLEA(0, "HOrient", 1);
    //LODOP.SET_PRINT_STYLEA(0, "VOrient", 1);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", ""); //该语句隐藏进度条或修改提示信息
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");//该语句隐藏进度条或修改提示信息
    LODOP.PREVIEW();
}

//审查意见书打印
function Print2(taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("审查意见书");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向
    //打印项目二维码
    LODOP.ADD_PRINT_HTM(0, "500px", "300px", "200px", "URL:../ServiceHandler/PDF417.ashx?id=" + taskID);
    LODOP.SET_PRINT_STYLEA(0, "ItemType", 1);
    LODOP.ADD_PRINT_URL("10mm", "20mm", "100%", "100%", path + "TaskPositionPaper.aspx?taskID=" + taskID);
    //LODOP.SET_PRINT_STYLEA(1, "HOrient", 1);
    //LODOP.SET_PRINT_STYLEA(1, "VOrient", 1);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", "");
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");
    LODOP.PREVIEW();
}


//各专业审查意见书打印
function Print4(eid, taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("专业审查意见书");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向
    //打印项目二维码
    LODOP.ADD_PRINT_HTM(0, "500px", "300px", "200px", "URL:../ServiceHandler/PDF417.ashx?id=" + taskID);
    LODOP.SET_PRINT_STYLEA(0, "ItemType", 1);
    LODOP.ADD_PRINT_URL(0, "20mm", "100%", "100%", path + "TaskCensorOfProfessionalPrint.aspx?eid=" + eid);
    //LODOP.SET_PRINT_STYLEA(0, "HOrient", 1);
    //LODOP.SET_PRINT_STYLEA(0, "VOrient", 1);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", ""); //该语句隐藏进度条或修改提示信息
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");//该语句隐藏进度条或修改提示信息
    LODOP.PREVIEW();
}


//复审单打印
function Print5(taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("复审单");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向
    LODOP.ADD_PRINT_URL("10mm", "20mm", "100%", "100%", path + "TaskReviewReceipt.aspx?taskID=" + taskID);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", ""); //该语句隐藏进度条或修改提示信息
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");//该语句隐藏进度条或修改提示信息
    LODOP.PREVIEW();
}

//复审意见书打印
function Print6(reid, taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("复审意见书");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向
    //打印项目二维码
    LODOP.ADD_PRINT_HTM(0, "500px", "300px", "200px", "URL:../ServiceHandler/PDF417.ashx?id=" + taskID);
    LODOP.SET_PRINT_STYLEA(0, "ItemType", 1);
    LODOP.ADD_PRINT_URL("20mm", "20mm", "100%", "100%", path + "TaskReviewOfProfessionPrint.aspx?reid=" + reid);
    //LODOP.SET_PRINT_STYLEA(0, "HOrient", 1);
    //LODOP.SET_PRINT_STYLEA(0, "VOrient", 1);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", ""); //该语句隐藏进度条或修改提示信息
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");//该语句隐藏进度条或修改提示信息
    LODOP.PREVIEW();
}

//复审变更通知单打印
function Print7(taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("变更通知单");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向
    LODOP.ADD_PRINT_URL("10mm", "20mm", "100%", "100%", path + "TaskReviewModify.aspx?taskID=" + taskID);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", ""); //该语句隐藏进度条或修改提示信息
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");//该语句隐藏进度条或修改提示信息
    LODOP.PREVIEW();
}

//收费单打印
function Print8(taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("收费单");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向
    LODOP.ADD_PRINT_URL("10mm", "20mm", "100%", "100%", path + "TaskChargeBill.aspx?taskID=" + taskID);
    //LODOP.SET_PRINT_STYLEA(1, "HOrient", 1);
    //LODOP.SET_PRINT_STYLEA(1, "VOrient", 1);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", "");
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");
    LODOP.PREVIEW();
}

//复审单打印
function Print9(taskID) {
    LODOP = getLodop();
    LODOP.PRINT_INIT("专项审查表");
    LODOP.SET_PRINT_PAGESIZE(1, 0, 0, "A4");//纸张大小与方向
    LODOP.ADD_PRINT_URL("10mm", "20mm", "100%", "100%", path + "TaskReviewReceiptSpecial.aspx?taskID=" + taskID);
    LODOP.SET_SHOW_MODE("MESSAGE_GETING_URL", ""); //该语句隐藏进度条或修改提示信息
    LODOP.SET_SHOW_MODE("MESSAGE_PARSING_URL", "");//该语句隐藏进度条或修改提示信息
    LODOP.PREVIEW();
}