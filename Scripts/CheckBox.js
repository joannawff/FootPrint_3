var frm = document.form1;

function CheckAll( checkall)
{
	var actVar = checkall.checked ;
	for(i=0;i< frm.length;i++) 
	{
		e=frm.elements[i];
		
		if(e.type=='checkbox')
		{
		    if (e.name.indexOf("check1") != -1)
		    {
			     e.checked= actVar ; 
		        if(actVar)
		        {
		            if(frm.Hselcet.value.indexOf(e.value) == -1)
		               frm.Hselcet.value += "," + e.value; //后加
		        }
		        else
		        {
		            frm.Hselcet.value = frm.Hselcet.value.replace("," + e.value,""); 
		        }
		    }
		}
	}
}

function Check_Item()
{
	for(i=0;i< frm.length;i++)
	{
		e=frm.elements[i]; 
		
		if(e.type=='checkbox')
		{
		    //Checkall
		    if (e.name.indexOf("checkall") != -1 )
		    {
			    e.checked = false ;
		    }
		    //Check1
		    if (e.name.indexOf("check1") != -1 )
		    {
		        if(e.checked)
		        {
		           if(frm.Hselcet.value.indexOf(e.value) == -1)
			           frm.Hselcet.value += "," + e.value; //后加
			    }
			    else
			        frm.Hselcet.value = frm.Hselcet.value.replace("," + e.value,""); 
		    }
		}
	}
}