DataProject = new List();
function ConvertTextToDataProject( InputText )
{
	RealText = "";
	for( i = 0; i < InputText.length; i ++)
	{
		if( InputText.charAt(i) == '	')
		{
			RealText = RealText + "~";
		}
		else
		{
			RealText = RealText + InputText.charAt(i);
		}
	}
	MainLocalDP = new List();
	for( i = 0; i < RealText.split(/\n/).length; i ++)
	{
		TextI = RealText.split(/\n/)[ i ] + "";
		LocalDP = new List();
		for( j = 0; j <RealText.split(/\n/)[ i ].split(/~/).length; j ++)
		{
			TextIJ = RealText.split(/\n/)[ i ].split(/~/)[ j ] + "";
			LocalDP.add( TextIJ );
		}
		MainLocalDP.add( LocalDP );
	}
	return MainLocalDP;
}
function ConvertDataProjectToTable_TypeAfterInput(InputDP,OutpuPoint)
{
	flag = true;
	for( iCDPTT_TAI = 0; iCDPTT_TAI < InputDP.Count(); iCDPTT_TAI ++)
	{
		if( InputDP.at( iCDPTT_TAI ).Count() > 1)
		{
			HTMLText = "";
			LocalIDP = InputDP.at( iCDPTT_TAI );
			for( jCDPTT_TAI = 0; jCDPTT_TAI < LocalIDP.Count(); jCDPTT_TAI ++)
			{
				TextIJ = LocalIDP.at( jCDPTT_TAI );
				HTMLText = HTMLText + '<td>' + TextIJ + "" + '</td>';
			}
			if( iCDPTT_TAI == 0)
			{
				HTMLText = '<tr class="error">' + HTMLText + '</tr>';
			}
			else
			{
				if( flag == true)
				{
					HTMLText = '<tr class="success">' + HTMLText + '</tr>';
				}
				if( flag == false)
				{
					HTMLText = '<tr class="info">' + HTMLText + '</tr>';
				}
			}
			if( flag == true)
			{
				flag = false;
			}
			else
			{
				flag = true;
			}
			OutpuPoint.innerHTML += HTMLText;
		}
	}
}