﻿/** *
Folder的API： *任务 方法  
*创建文件夹。FileSystemObject.CreateFolder  
*删除文件夹。Folder.Delete 或 FileSystemObject.DeleteFolder  
*移动文件夹。 Folder.Move 或 FileSystemObject.MoveFolder  
*复制文件夹。 Folder.Copy 或 FileSystemObject.CopyFolder  
*检索文件夹的名字。 Folder.Name  
*如果文件夹在驱动器上存在，则找出它。FileSystemObject.FolderExists  
*获得现有 Folder 对象的实例。 FileSystemObject.GetFolder  
*找出文件夹的父文件夹名。 FileSystemObject.GetParentFolderName  
*找出系统文件夹的路径。 FileSystemObject.GetSpecialFolder  */
function ManipFiles(){   
    var fso, f1, f2, s;   
    fso = new ActiveXObject("Scripting.FileSystemObject");   
    f1 = fso.CreateTextFile("c:\\testfile.txt", true); 
    //如果当前文件已经存在的话，则覆盖原有文件   
    alert("Writing file <br>");   // 写一行。  
    f1.Write("This is a test.");   // 关闭文件。  
    f1.Close();   alert("Moving file to c:\\tmp <br>");   
    if(!fso.FolderExists("c:\\tmp")) 
    {
        //如果tmp目录不存在，则创建一个目录        
        fso.CreateFolder("c:\\tmp");   
    }   
    // 获取 C 的根目录(C:\)中的文件的句柄。   
    f2 = fso.GetFile("c:\\testfile.txt");   
    // 把文件移动到 \tmp 目录。如果这个tmp目录下已经有testfile.txt文件了，则会出错。
    //（如果没有tmp这个文件目录也会出错）  
    f2.Move ("c:\\tmp\\testfile.txt");  
    alert("Copying file to c:\\temp <br>"); 
    // 把文件复制到 \temp 目录   
    if(!fso.FolderExists("c:\\temp"))
    {
        //如果temp目录不存在，则创建一个目录       
        fso.CreateFolder("c:\\temp");   
    }   
    f2.Copy ("c:\\temp\\testfile.txt");   
    alert("Deleting files <br>");   
    // 获得文件当前位置的句柄。  
    f2 = fso.GetFile("c:\\tmp\\testfile.txt");   
    f3 = fso.GetFile("c:\\temp\\testfile.txt");   
    // 删除文件。  
    f2.Delete();   
    f3.Delete();   //删除文件夹   
    var fdTmp = fso.GetFolder("c:\\tmp");
    var fdTemp = fso.GetFolder("c:\\temp");
    fdTmp.DeleteFolder();
    fdTemp.DeleteFolder();
    alert("All done!");
}
ManipFiles();//CreateFile();alert("Ok! Write Over!");